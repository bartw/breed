using Breed.Business.People.Entity;
using Breed.Contract.People.Dto;
using Breed.Contract.People.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Breed.Business.People
{
    public class PeopleFacade : IPeopleFacade
    {
        public IEnumerable<PersonDto> GetAll()
        {
            return new BreedContext().People.Include(p => p.Mother).Include(p => p.Father).ToList().Select(p => Map(p));
        }

        public PersonDto Get(int id)
        {
            return Map(new BreedContext().People.Include(p => p.Mother).Include(p => p.Father).Where(p => p.Id == id).FirstOrDefault());
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

        public PersonDto SetMother(int id, int motherId)
        {
            var context = new BreedContext();

            var child = context.People.Include(p => p.Mother).Include(p => p.Father).Where(p => p.Id == id).FirstOrDefault();
            var mother = context.People.Where(p => p.Id == motherId).FirstOrDefault();

            if (child == null || mother == null)
            {
                return null;
            }

            child.Mother = mother;

            context.SaveChanges();

            return Map(child);
        }

        public PersonDto SetFather(int id, int fatherId)
        {
            var context = new BreedContext();

            var child = context.People.Include(p => p.Mother).Include(p => p.Father).Where(p => p.Id == id).FirstOrDefault();
            var father = context.People.Where(p => p.Id == fatherId).FirstOrDefault();

            if (child == null || father == null)
            {
                return null;
            }

            child.Father = father;

            context.SaveChanges();

            return Map(child);
        }

        private PersonDto Map(Person person, int generations = 1)
        {
            if (person == null) return null;

            return new PersonDto
            {
                Id = person.Id,
                Name = person.Name,
                Birthdate = person.Birthdate,
                Deceased = person.Deceased,
                Mother = generations == 0 ? null : Map(person.Mother, generations - 1),
                Father = generations == 0 ? null : Map(person.Father, generations - 1)
            };
        }

        private Person Map(PersonDto person, int generations = 1)
        {
            if (person == null) return null;

            return new Person
            {
                Id = person.Id,
                Name = person.Name,
                Birthdate = person.Birthdate,
                Deceased = person.Deceased,
                Mother = generations == 0 ? null : Map(person.Mother, generations - 1),
                Father = generations == 0 ? null : Map(person.Father, generations - 1)
            };
        }
    }
}
