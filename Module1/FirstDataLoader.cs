using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQLComplexFilter.Module1
{
    public class FirstDataLoader : BatchDataLoader<int, FirstClass>
    {
        private readonly IDbContextFactory<FirstDbContext> _dbContextFactory;

        public FirstDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<FirstDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, FirstClass>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using FirstDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Firsts
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
