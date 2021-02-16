using GraphQLComplexFilter.Module1;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module2
{
    public class SecondType : ObjectType<SecondClass>
    {
        protected override void Configure(IObjectTypeDescriptor<SecondClass> descriptor)
        {
            descriptor.Implements<SecondInterfaceType>();
            descriptor.Field(f => f.FirstId)
                .IsProjected();
            descriptor.Field(f => f.First)
                .Resolve(async (resolver, cancellationToken) =>
                {
                    var second = resolver.Parent<SecondClass>();
                    if (second.FirstId == null)
                        return null;
                    var dataloader = resolver.DataLoader<IDataLoader<int, IFirstInterface>>();
                    return await dataloader.LoadAsync(second.FirstId.Value, cancellationToken);
                });
        }
    }
}
