using AspNetMVC5.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AspNetMVC5.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext() : base(nameOrConnectionString:"DefaultConnection")
        {

        }


        public DbSet<Aluno> alunos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}