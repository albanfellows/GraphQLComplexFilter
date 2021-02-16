using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module2
{
    public class SecondDataLoader : BatchDataLoader<int, ISecondInterface>
    {
        private readonly IDbContextFactory<SecondDbContext> _dbContextFactory;

        public SecondDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<SecondDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, ISecondInterface>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using SecondDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Seconds
                .Where(s => keys.Contains(s.Id))
                .Cast<ISecondInterface>()
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }

    }
}
