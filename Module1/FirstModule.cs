using GraphQLComplexFilter.Interfaces;
using GreenDonut;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLComplexFilter.Module1
{
    public static class FirstModule
    {
        public static IRequestExecutorBuilder AddFirstModule(this IRequestExecutorBuilder builder)
        {
            builder.AddFiltering<FirstFilterConvention>()
                //.BindRuntimeType<IFirstInterface,FirstType>()
                .BindRuntimeType<IFirstInterface, FirstInputType>()
                .AddType<FirstType>()
                .AddTypeExtension<FirstQuery>()
                .AddTypeExtension<FirstMutation>()
                .AddDataLoader<IDataLoader<int, IFirstInterface>, FirstDataLoader>();


            return builder;
        }
    }
}
