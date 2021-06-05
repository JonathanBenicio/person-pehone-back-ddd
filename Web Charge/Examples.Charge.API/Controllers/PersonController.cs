using AutoMapper;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }
        // GET: api/<PersonController>
        [HttpGet]
        public async Task<ActionResult<PersonListResponse>> Get() => Response(await _facade.FindAllAsync());
    }
}
