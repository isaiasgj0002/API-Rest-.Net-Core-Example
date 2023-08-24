using Microsoft.EntityFrameworkCore;
using miprimerwebapi.Models;

namespace miprimerwebapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {  
        }

        public DbSet<Product> Products { get; set; }
    }
}