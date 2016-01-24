using Breed.Business.People.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breed.Business
{
    public class BreedInitializer : DropCreateDatabaseIfModelChanges<BreedContext>
    {
        protected override void Seed(BreedContext context)
        {
            context.People.Add(new Person { Name = "Linus Wijnants" });
            context.People.Add(new Person { Name = "Otis Wijnants" });
            context.People.Add(new Person { Name = "Nancy Dexters" });
            context.People.Add(new Person { Name = "Bart Wijnants" });
            context.SaveChanges();
        }
    }
}
