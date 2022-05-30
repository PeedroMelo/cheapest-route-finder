using System.ComponentModel.DataAnnotations;

namespace BestCostRouteFinder.Domain.AggregateModels.Place
{
    public class Place
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
