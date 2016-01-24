using Breed.Business.People.Entity;
using Breed.Contract.People.Dto;
using Breed.Contract.People.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Breed.Business.People
{
    public class PeopleFacade : IPeopleFacade
    {
        public IEnumerable<PersonDto> GetAll()
        {
            return new BreedContext().People.ToList().Select(p => Map(p));
        }

        public PersonDto Get(int id)
        {
            return Map(new BreedContext().People.Where(p => p.Id == id).FirstOrDefault());
        }

        public PersonDto Create(PersonDto person)
        {
            var personToCreate = Map(person);

            if (personToCreate == null)
            {
                return null;
            }

            personToCreate.Id = 0;

            var context = new BreedContext();
            context.People.Add(personToCreate);
            context.SaveChanges();

            return Map(personToCreate);
        }

        public PersonDto Update(PersonDto person)
        {
            if (person == null)
            {
                return null;
            }

            var context = new BreedContext();

            var personToUpdate = context.People.Where(p => p.Id == person.Id).FirstOrDefault();

            if (personToUpdate == null)
            {
                return null;
            }

            personToUpdate.Name = person.Name;
            personToUpdate.Birthdate = person.Birthdate;
            personToUpdate.Deceased = person.Deceased;

            context.SaveChanges();

            return Map(personToUpdate);
        }

        public void Delete(int id)
        {
            var context = new BreedContext();

            var personToDelete = context.People.Where(p => p.Id == id).FirstOrDefault();

            if (personToDelete == null)
            {
                return;
            }

            context.People.Remove(personToDelete);
            context.SaveChanges();
        }

        private PersonDto Map(Person person)
        {
            if (person == null) return null;

            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Birthdate = person.Birthdate,
                Deceased = person.Deceased
            };
        }

        private Person Map(PersonDto person)
        {
            if (person == null) return null;

            return new Person
            {
                Id = person.Id,
                Name = person.Name,
                Birthdate = person.Birthdate,
                Deceased = person.Deceased
            };
        }
    }
}
