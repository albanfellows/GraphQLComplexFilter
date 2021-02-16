using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module1
{
    public class FirstInputType : InputObjectType<FirstClass>
    {
        protected override void Configure(IInputObjectTypeDescriptor<FirstClass> descriptor)
        {
        }
    }
}
