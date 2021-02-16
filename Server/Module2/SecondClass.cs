using GraphQLComplexFilter.Module1;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

#nullable enable
namespace GraphQLComplexFilter.Module2
{
    public class SecondClass : ISecondInterface
    {
        public int Id { get; set; }

        public string? FieldFive { get; set; }
        public int? FieldSix { get; set; }
        public decimal? FieldSeven { get; set; }
        public DateTime? FieldEight { get; set; }
        [ForeignKey(nameof(First))] public int? FirstId { get; set; }
        [NotMapped]public IFirstInterface? First { get; set; }
    }
}
#nullable disable
