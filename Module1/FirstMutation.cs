using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module1
{
    [ExtendObjectType("Mutation")]
    public class FirstMutation
    {
        public async Task<FirstClass> CreateFirst([ScopedService] FirstDbContext dbContext, FirstClass input)
        {
            dbContext.Add(input);
            await dbContext.SaveChangesAsync();
            return input;
        }
    }
}
