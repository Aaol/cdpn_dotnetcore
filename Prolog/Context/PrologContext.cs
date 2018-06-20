using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Prolog.Models;

namespace Prolog.Context
{
    class PrologContext : DbContext
    {
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Argument> Arguments { get; set; }
        public DbSet<Variable> Variables { get; set; }
        public DbSet<Atom> Atoms { get; set; }
        public DbSet<ArgumentPosition> ArgumentPositions { get; set; }
        public DbSet<Rule> Rules { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Prolog;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rule>().HasOne(r => r.Response).WithOne(f => f.RuleResponse).HasForeignKey<Rule>(r => r.IdResponse);
        }
    }
}