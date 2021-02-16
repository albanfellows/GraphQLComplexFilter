using GraphQLComplexFilter.Interfaces;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module2
{
    public class SecondInterfaceType : InterfaceType<ISecondInterface>
    {
        protected override void Configure(IInterfaceTypeDescriptor<ISecondInterface> descriptor)
        {
        }
    }
}
