using HotChocolate;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Filtering
{
    public class TestProvider : QueryableFilterProvider
    {
        protected override void Configure(IFilterProviderDescriptor<QueryableFilterContext> descriptor)
        {
            descriptor.AddFieldHandler<TestFieldHandler>();
            base.Configure(descriptor);
        }
    }
}
