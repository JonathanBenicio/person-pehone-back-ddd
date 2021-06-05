using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonPhoneController : BaseController
    {
        private IPersonPhoneFacade _facade;

        public PersonPhoneController(IPersonPhoneFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        // GET api/<PersonPhoneController>/5
        [HttpGet("{idPerson}")]
        public async Task<ActionResult<PersonPhoneListResponse>> Get(int idPerson) => Response(await _facade.GetAllAsync(idPerson));

        // POST api/<PersonPhoneController>
        [HttpPost]
        public async Task<ActionResult<PersonPhoneResponse>> Post([FromBody] PersonPhoneRequest personPhoneRequest)
        {
            return Response(await _facade.AddAsync(personPhoneRequest));
        }

        // PUT api/<PersonPhoneController>/5
        [HttpPut]
        public async Task<ActionResult<PersonPhoneResponse>> Put([FromBody] PersonPhoneRequest personPhoneRequest)
        {
            return Response(await _facade.AltAsync(personPhoneRequest));
        }

        // DELETE api/<PersonPhoneController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonPhoneResponse>> Delete(int id)
        {
            return Response(await _facade.DeleteAsync(id));
        }
    }
}
