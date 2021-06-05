using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonListResponse> FindAllAsync()
        {
            try
            {
                var result = await _personService.FindAllAsync();
                var response = new PersonListResponse();
                List<PersonDto> personObjects = result.Select(x => _mapper.Map<PersonDto>(x)).ToList();
                response.Data = personObjects;
                return response;
            }
            catch (Exception ex)
            {
                var response = new PersonListResponse();
                response.Success = false;
                response.Errors = new object[] { ex.Message };
                return response;
            }
        }
    }
}
