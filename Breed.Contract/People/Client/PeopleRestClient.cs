using Breed.Contract.People.Dto;
using Breed.Contract.People.Interface;
using System;
using System.Collections.Generic;

namespace Breed.Contract.People.Client
{
    public class PeopleRestClient : IPeopleFacade
    {
        public IEnumerable<PersonDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonDto Get(int id)
        {
            throw new NotImplementedException();
        }

        public PersonDto Create(PersonDto person)
        {
            throw new NotImplementedException();
        }

        public PersonDto Update(PersonDto person)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
