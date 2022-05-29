namespace BestCostRouteFinder.Domain.Entities
{
    public class Route
    {
        public int Id { get; }

        public string Origin { get; }

        public string Destiny { get; }

        public decimal Cost { get; }

        public Route(int id, string origin, string destiny, decimal cost)
        {
            Id = id;
            Origin = origin;
            Destiny = destiny;
            Cost = cost;
        }
    }
}
