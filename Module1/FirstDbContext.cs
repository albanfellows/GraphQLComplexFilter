using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLComplexFilter.Module1
{
    public class FirstDbContext : DbContext
    {
        public FirstDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        internal DbSet<FirstClass> Firsts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FirstClass>()
                .HasData(
                new FirstClass
                {
                    Id = 1,
                    FieldOne = "One",
                    FieldTwo = 1,

                    SecondId = 1
                },
                new FirstClass
                {
                    Id = 2,
                    FieldOne = "Two",
                    FieldTwo = 2,

                    SecondId = 1
                },
                new FirstClass
                {
                    Id = 3,
                    FieldOne = "Three",

                    SecondId = 1
                },
                new FirstClass
                {
                    Id = 4,
                    FieldOne = "Four",
                    FieldTwo = 4
                },
                new FirstClass
                {
                    Id = 5,
                    FieldOne = "Five",
                    FieldTwo = 5,

                    SecondId = 2
                },
                new FirstClass
                {
                    Id = 6,
                    FieldOne = "Six",

                    SecondId = 2
                },
                new FirstClass
                {
                    Id = 7,
                    FieldOne = "Seven",
                },
                new FirstClass
                {
                    Id = 8,
                    FieldOne = "Eight",

                    SecondId = 2
                });
        }
    }
}
