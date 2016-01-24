using Breed.Contract.People.Dto;
using System.Collections.Generic;

namespace Breed.Contract.People.Interface
{
    public interface IPeopleFacade
    {
        IEnumerable<PersonDto> GetAll();
        PersonDto Get(int id);
        PersonDto Create(PersonDto person);
        PersonDto Update(PersonDto person);
        void Delete(int id);
    }
}
