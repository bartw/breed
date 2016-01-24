using System;
using System.Collections.Generic;

namespace Breed.Contract.People.Dto
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool Deceased { get; set; }

        public PersonDto Mother { get; set; }
        public PersonDto Father { get; set; }
        public IEnumerable<PersonDto> Children { get; set; }
    }
}
