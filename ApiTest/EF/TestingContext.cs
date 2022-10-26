using Microsoft.EntityFrameworkCore;
using ApiTest.Models;

namespace ApiTest.EF
{
    public class TestingContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Positions> Positions { get; set; }
        public DbSet<Projects> Projects { get; set; }

        public DbSet<nav_o_fsk> nav_O_Fsks { get; set; }
        public DbSet<nav_o_ia> nav_O_Ias { get; set; }
        public DbSet<nav_o_mes> nav_O_Mes { get; set; }
        public DbSet<nav_o_pmes> nav_O_Pmes { get; set; }
        public DbSet<nav_o_substations> nav_O_Substations { get; set; }

        public TestingContext(DbContextOptions<TestingContext> options) : base(options)
        {
        }
    }
}
