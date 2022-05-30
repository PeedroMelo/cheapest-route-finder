using System.ComponentModel.DataAnnotations;

namespace BestCostRouteFinder.Domain.Entities
{
    public class Place
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
