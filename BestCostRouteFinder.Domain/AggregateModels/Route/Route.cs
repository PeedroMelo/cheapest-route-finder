using System.ComponentModel.DataAnnotations;

namespace CheapestRouteFinder.Domain.AggregateModels.Route
{
    public class Route
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string Origin { get; set; }

        [Required]
        [MaxLength(3)]
        public string Destiny { get; set; }

        [Required]
        public decimal Cost { get; set; }

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
