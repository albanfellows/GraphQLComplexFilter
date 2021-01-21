using GraphQLComplexFilter.Module2;
using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module1
{
    public class FirstType : ObjectType<FirstClass>
    {
        protected override void Configure(IObjectTypeDescriptor<FirstClass> descriptor)
        {
            descriptor.Field(f => f.SecondId)
                .IsProjected();
            descriptor.Field(f => f.Second)
                .Resolve(async (resolver, cancellationToken) =>
                {
                    var first = resolver.Parent<FirstClass>();
                    if (first.SecondId == null)
                        return null;
                    var dataloader = resolver.DataLoader<IDataLoader<int, ISecondInterface>>();
                    return await dataloader.LoadAsync(first.SecondId.Value, cancellationToken);
                })
                .Name("second");
        }
    }
}
