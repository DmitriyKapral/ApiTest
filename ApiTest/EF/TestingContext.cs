using Microsoft.EntityFrameworkCore;
using ApiTest.Models;

namespace ApiTest.EF
{
    public class TestingContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Employees> Employees { get; set; }

        public TestingContext(DbContextOptions<TestingContext> options) : base(options)
        {
        }
    }
}
