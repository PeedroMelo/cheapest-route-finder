namespace BestCostRouteFinder.Domain.Entities
{
    public class Place
    {
        public int Id { get; }

        public string Name { get; }

        public Place(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
