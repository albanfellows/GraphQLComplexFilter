using GraphQLComplexFilter.Module1;
using GraphQLComplexFilter.Module2;
using HotChocolate.Data;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Filtering
{
    public class TestFilterConvention : FilterConvention
    {
        protected override void Configure(IFilterConventionDescriptor descriptor)
        {
            descriptor.AddDefaults();
            descriptor.AddProviderExtension(new QueryableFilterProviderExtension(x =>
                x.AddFieldHandler<TestFieldHandler>()));
            descriptor.BindRuntimeType<ISecondInterface, FilterInputType<SecondClass>>();
            descriptor.BindRuntimeType<IFirstInterface, FilterInputType<FirstClass>>();
        }
    }
}
