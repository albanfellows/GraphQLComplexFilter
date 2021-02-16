using GraphQLComplexFilter.Module1;
using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter
{
    public class TestTypeInterceptor : TypeInterceptor
    {
        public override bool CanHandle(ITypeSystemObjectContext context)
        {
            return base.CanHandle(context);
        }

        public override void OnAfterInitialize(ITypeDiscoveryContext discoveryContext, DefinitionBase definition, IDictionary<string, object> contextData)
        {
            InputObjectTypeDefinition od = null;
            if ((od = definition as InputObjectTypeDefinition) != null
                && od.RuntimeType is IFirstInterface)
            {
                
            }
        }
    }
}
