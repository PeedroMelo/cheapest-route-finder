using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BestCostRouteFinder.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("SqlServer"));
        }
    }
}
