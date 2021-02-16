using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GraphQLComplexFilter.Interfaces;
using GreenDonut;
using HotChocolate.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace GraphQLComplexFilter.Module1
{
    internal class FirstDataLoader : BatchDataLoader<int, IFirstInterface>
    {
        private readonly IDbContextFactory<FirstDbContext> _dbContextFactory;

        public FirstDataLoader(IBatchScheduler batchScheduler, IDbContextFactory<FirstDbContext> dbContextFactory) : base(batchScheduler)
        {
            _dbContextFactory = dbContextFactory ??
                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<int, IFirstInterface>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            await using FirstDbContext dbContext =
                _dbContextFactory.CreateDbContext();

            return await dbContext.Firsts
                .Where(s => keys.Contains(s.Id))
                .Cast<IFirstInterface>()
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
