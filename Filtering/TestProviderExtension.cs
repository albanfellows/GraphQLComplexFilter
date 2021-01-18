using HotChocolate;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Resolvers;
using HotChocolate.Types.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Filtering
{
    public class TestProviderExtension : FilterProviderExtensions<QueryableFilterContext>
    {
        public TestProviderExtension(Action<IFilterProviderDescriptor<QueryableFilterContext>> configure) : base(configure)
        {
        }

        //protected override void Configure(IFilterProviderDescriptor<TestFilterContext> descriptor)
        //{
        //    descriptor.AddFieldHandler<TestFieldHandler>();
        //}

        //protected override void Complete(IConventionContext context)
        //{
        //    base.Complete(context);
        //}

        //protected override FilterProviderDefinition CreateDefinition(IConventionContext context)
        //{
        //    return base.CreateDefinition(context);
        //}
    }
}
