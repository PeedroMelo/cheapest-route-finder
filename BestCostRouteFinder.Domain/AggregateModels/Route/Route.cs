using System.ComponentModel.DataAnnotations;

namespace BestCostRouteFinder.Domain.AggregateModels.Route
{
    public class Route
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [MaxLength(3)]
        public string Origin { get; private set; }

        [Required]
        [MaxLength(3)]
        public string Destiny { get; private set; }

        [Required]
        public decimal Cost { get; private set; }

        public Route(int id, string origin, string destiny, decimal cost)
        {
            Id = id;
            Origin = origin;
            Destiny = destiny;
            Cost = cost;
        }

        public Route(string origin, string destiny, decimal cost)
        {
            Origin = origin;
            Destiny = destiny;
            Cost = cost;
        }
    }
}
