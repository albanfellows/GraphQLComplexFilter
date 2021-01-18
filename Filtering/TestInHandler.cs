using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Language;
using HotChocolate.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Filtering
{
    public class TestInHandler : QueryableComparableOperationHandler
    {
        public TestInHandler(
            ITypeConverter typeConverter)
    : base(typeConverter)
        {
            CanBeNull = false;
        }
        protected override int Operation => DefaultFilterOperations.In;

        public override Expression HandleOperation(
            QueryableFilterContext context,
            IFilterOperationField field,
            IValueNode value,
            object? parsedValue)
        {
            Expression property = context.GetInstance();
            parsedValue = ParseValue(value, parsedValue, field.Type, context);

            if (parsedValue is null)
            {
                throw new InvalidOperationException();
            }

            return FilterExpressionBuilder.In(
                property,
                context.RuntimeTypes.Peek().Source,
                parsedValue);
        }
    }
}

