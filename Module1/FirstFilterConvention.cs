using HotChocolate.Data;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module1
{
    public class FirstFilterConvention : FilterConvention
    {
        protected override void Configure(IFilterConventionDescriptor descriptor)
        {
            descriptor.AddDefaults();
            descriptor.AddProviderExtension(new QueryableFilterProviderExtension(x =>
                x.AddFieldHandler<FirstFilterHandler>()));
            descriptor.BindRuntimeType<IFirstInterface, FilterInputType<FirstClass>>();
        }
    }
}
