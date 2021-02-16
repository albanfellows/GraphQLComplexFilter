using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module2
{
    [ExtendObjectType("Mutation")]
    internal class SecondMutation
    {
        public async Task<SecondClass> CreateSecond([ScopedService]SecondDbContext dbContext, SecondClass input)
        {
            dbContext.Add(input);
            await dbContext.SaveChangesAsync();
            return input;
        }
    }
}
