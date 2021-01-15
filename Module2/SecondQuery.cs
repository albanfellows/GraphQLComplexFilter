using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module2
{
    [ExtendObjectType("Query")]
    public class SecondQuery
    {
        [UseDbContext(typeof(SecondDbContext))]
        [UsePaging(DefaultPageSize = 10, IncludeTotalCount = true), UseProjection, UseFiltering, UseSorting]
        public IQueryable<SecondClass> GetSeconds([ScopedService] SecondDbContext context) => context.Seconds;
    }
}
