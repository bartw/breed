using System;
using System.Collections.Generic;

namespace Breed.Business.People.Entity
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool Deceased { get; set; }

        public int? MotherId { get; set; }
        public virtual Person Mother { get; set; }

        public int? FatherId { get; set; }
        public virtual Person Father { get; set; }

        //public virtual IEnumerable<Person> Children { get; set; }
    }
}
