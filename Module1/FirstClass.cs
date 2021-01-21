using GraphQLComplexFilter.Module2;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace GraphQLComplexFilter.Module1
{
    public class FirstClass : IFirstInterface
    {
        public int Id { get; set; }

        public string? FieldOne { get; set; }
        public int? FieldTwo { get; set; }
        public decimal? FieldThree { get; set; }
        public DateTime? FieldFour { get; set; }

        [ForeignKey(nameof(Second))]public int? SecondId { get; set; }
        [NotMapped]public ISecondInterface? Second { get; set; }

    }
}
#nullable disable
