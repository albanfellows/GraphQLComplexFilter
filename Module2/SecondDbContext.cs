using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module2
{
    public class SecondDbContext : DbContext
    {
        public SecondDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        internal DbSet<SecondClass> Seconds { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecondClass>()
                .HasData(
                new SecondClass
                {
                    Id = 1,
                    FieldFive="Uno"
                },
                new SecondClass
                {
                    Id = 2,
                    FieldFive="Duo"
                });
        }
    }
}
