using GraphQLComplexFilter.Interfaces;
using GreenDonut;
using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQLComplexFilter.Module2
{
    public static class SecondModule
    {
        public static IRequestExecutorBuilder AddSecondModule(this IRequestExecutorBuilder builder)
        {
            return builder
                .AddFiltering<SecondFilterConvention>()
                //.BindRuntimeType<ISecondInterface, SecondType>()
                .BindRuntimeType<ISecondInterface, SecondInputType>()
                .AddType<SecondType>()
                .AddTypeExtension<SecondQuery>()
                .AddTypeExtension<SecondMutation>()
                .AddDataLoader<IDataLoader<int, ISecondInterface>, SecondDataLoader>();
        }
    }
}
