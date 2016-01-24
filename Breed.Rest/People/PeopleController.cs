using Breed.Business.People;
using Breed.Contract.People.Dto;
using Breed.Contract.People.Interface;
using System.Collections.Generic;
using System.Web.Http;

namespace Breed.Rest.People
{
    [RoutePrefix("api/people")]
    public class PeopleController : ApiController, IPeopleFacade
    {
        private readonly IPeopleFacade _peopleFacade;

        public PeopleController()
        {
            _peopleFacade = new PeopleFacade();
        }

        [HttpGet]
        [Route("")]
        public IEnumerable<PersonDto> GetAll()
        {
            return _peopleFacade.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public PersonDto Get(int id)
        {
            return _peopleFacade.Get(id);
        }

        [HttpPost]
        [Route("")]
        public PersonDto Create(PersonDto person)
        {
            return _peopleFacade.Create(person);
        }

        [HttpPut]
        [Route("")]
        public PersonDto Update(PersonDto person)
        {
            return _peopleFacade.Update(person);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _peopleFacade.Delete(id);
        }
    }
}
