using GraphQLComplexFilter.Module1;
using HotChocolate;
using HotChocolate.Configuration;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Execution;
using HotChocolate.Execution.Processing;
using HotChocolate.Language;
using HotChocolate.Language.Visitors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Filtering
{
    public class TestFieldHandler : QueryableDefaultFieldHandler
    {
        private IRequestExecutorResolver executorResolver;
        private string idName;

        public override bool CanHandle(ITypeCompletionContext context, IFilterInputTypeDefinition typeDefinition, IFilterFieldDefinition fieldDefinition)
        {
            if (fieldDefinition.Member?.Name == "Second")
            {
                context.ContextData[fieldDefinition.Member.Name] = typeDefinition.EntityType.Name;
                executorResolver = (IRequestExecutorResolver)context.Services.GetService(typeof(IRequestExecutorResolver));
                var attribute = fieldDefinition.Member.GetCustomAttribute<ForeignKeyAttribute>();
                idName = attribute?.Name;
                if (idName == null)
                {
                    // Not on navigation property look back the other way
                    var idField = typeDefinition.EntityType.GetProperties(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault(f =>
                      {
                          attribute = f.GetCustomAttribute<ForeignKeyAttribute>();
                          if (attribute == null)
                              return false;
                          if (attribute.Name == fieldDefinition.Member.Name)
                              return true;

                          return false;
                      }
                    );
                    idName = idField?.Name;
                }

                return true;
            }
            return false;
        }

        public override bool TryHandleEnter(QueryableFilterContext context, IFilterField field, ObjectFieldNode node, [NotNullWhen(true)] out ISyntaxVisitorAction action)
        {
            action = SyntaxVisitor.SkipAndLeave;
            return true;
            //return base.TryHandleEnter(context, field, node, out action);
        }

        public override bool TryHandleLeave(QueryableFilterContext context, IFilterField field, ObjectFieldNode node, [NotNullWhen(true)] out ISyntaxVisitorAction action)
        {
            // This is the property that represents the object
            Expression property = context.GetInstance();


            if (string.IsNullOrEmpty(idName))
            {
                action = SyntaxVisitor.Break;
                return false;

            }

            var filter = node.Value.ToString();
            var query = QueryRequestBuilder.Create($"{{ seconds(where: {filter}) {{ nodes {{id}} }} }}");

            var proxy = new RequestExecutorProxy(executorResolver, Schema.DefaultName);
            var result = proxy.ExecuteAsync(query).GetAwaiter().GetResult();
            proxy.Dispose();

            var data = result as QueryResult;
            var queryData = data.Data["seconds"] as ResultMap;
            var nodes = queryData.GetValueOrDefault("nodes") as ResultMapList;

            var linkProperty = Expression.Property(property, idName);

            var newExpression = FilterExpressionBuilder.In(linkProperty, typeof(int?), nodes.Select(n => (int?)((ResultMap)n).GetValueOrDefault("id")).ToList());

            context.GetLevel().Enqueue(newExpression);

            action = SyntaxVisitor.Continue;
            return true;
        }
    }
}
