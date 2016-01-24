using Breed.Business.People.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breed.Business
{
    public class BreedContext : DbContext
    {
        public BreedContext() : base("BreedContext")
        {

        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Person>()
                .HasOptional(p => p.Mother).WithMany().HasForeignKey(p => p.MotherId);
            modelBuilder.Entity<Person>()
                .HasOptional(p => p.Father).WithMany().HasForeignKey(p => p.FatherId);
        }
    }
}