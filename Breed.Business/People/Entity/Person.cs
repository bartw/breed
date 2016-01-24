using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breed.Business.People.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool Deceased { get; set; }

        public Person Mother { get; set; }
        public Person Father { get; set; }
    }
}
