using Breed.Contract.People.Dto;
using Breed.Contract.People.Interface;
using System.Collections.Generic;

namespace Breed.Business.People
{
    public class PeopleFacade : IPeopleFacade
    {
        public IEnumerable<PersonDto> GetAll()
        {
            return new List<PersonDto> { new PersonDto(), new PersonDto() };
        }

        public PersonDto Get(int id)
        {
            return new PersonDto { Id = id };
        }

        public PersonDto Create(PersonDto person)
        {
            return person;
        }

        public PersonDto Update(PersonDto person)
        {
            return person;
        }

        public void Delete(int id)
        {
        }
    }
}
