using Breed.Business.People;
using Breed.Contract.People.Dto;
using Breed.Contract.People.Interface;
using System;
using Xunit;

namespace Breed.Test.People
{
    public class PeopleFacadeTests
    {
        private readonly IPeopleFacade _peopleFacade;

        public PeopleFacadeTests()
        {
            _peopleFacade = new PeopleFacade();
        }

        [Fact]
        public void GivenAPeopleFacade_WhenGetAllIsCalled_AListOfPeopleIsReturned()
        {
            var people = _peopleFacade.GetAll();

            Assert.NotNull(people);
        }

        [Fact]
        public void GivenAPeopleFacade_WhenGetIsCalledWithAnExistingId_APersonIsReturned()
        {
            var personToReturn = new PersonDto
            {
                Id = 12,
                Name = "name",
                Birthdate = new DateTime(2015, 8, 14)
            };

            var person = _peopleFacade.Get(personToReturn.Id);

            Assert.NotNull(person);
            Assert.Equal(personToReturn.Id, person.Id);
            Assert.Equal(personToReturn.Name, person.Name);
            Assert.Equal(personToReturn.Birthdate, person.Birthdate);
        }

        [Fact]
        public void GivenAPeopleFacade_WhenGetIsCalledWithANonExistingId_NullIsReturned()
        {
            var nonExistingId = 23;

            var person = _peopleFacade.Get(nonExistingId);

            Assert.Null(person);
        }
    }
}
