using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Server
{
    [ExtendObjectType("__EnumValue")]
    public class EnumTypeExtension
    {
        public string GetDisplayName([Parent] IEnumValue enumValue) => enumValue.Value.ToString();
        public string GetLocalizedDescription([Parent] IEnumValue enumValue) => $"[{enumValue.Description}]";
    }
}
