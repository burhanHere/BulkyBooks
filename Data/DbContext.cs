using BulkyBooks.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBooks.Data
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<Catagory> Categories { get; set; }
    }
}