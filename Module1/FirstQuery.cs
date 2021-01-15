using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module1
{
    [ExtendObjectType("Query")]
    public class FirstQuery
    {
        [UseDbContext(typeof(FirstDbContext))]
        [UsePaging(DefaultPageSize = 10, IncludeTotalCount = true), UseProjection, UseFiltering, UseSorting]
        public IQueryable<FirstClass> GetFirsts([ScopedService] FirstDbContext context) => context.Firsts;
    }
}
