using HotChocolate.Data;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module2
{
    public class SecondFilterConvention : FilterConvention
    {
        protected override void Configure(IFilterConventionDescriptor descriptor)
        {
            descriptor.AddDefaults();
            descriptor.AddProviderExtension(new QueryableFilterProviderExtension(x =>
                x.AddFieldHandler<SecondFilterHandler>()));
            descriptor.BindRuntimeType<ISecondInterface, FilterInputType<SecondClass>>();
        }
    }
}
