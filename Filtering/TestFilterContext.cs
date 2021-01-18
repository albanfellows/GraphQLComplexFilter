using GraphQLComplexFilter.Module1;
using HotChocolate.Data.Filters;
using HotChocolate.Data.Filters.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Filtering
{
    public class TestFilterContext : QueryableFilterContext
    {
        public TestFilterContext(IFilterInputType initialType, bool inMemory) : base(initialType, inMemory)
        {
        }
    }
}
