using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonPhoneFacade : IPersonPhoneFacade
    {
        private readonly IPersonPhoneService _personService;
        private readonly IMapper _mapper;

        public PersonPhoneFacade(IPersonPhoneService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }
        public async Task<PersonPhoneListResponse> GetAllAsync(int idPerson)
        {
            try
            {
                var result = await _personService.GetAllAsync(idPerson);
                var response = new PersonPhoneListResponse();
                List<PersonPhoneDto> personPhoneObjects = result.Select(x => _mapper.Map<PersonPhoneDto>(x)).ToList();
                response.Data = personPhoneObjects;
                return response;
            }
            catch (Exception ex)
            {
                var response = new PersonPhoneListResponse();
                response.Success = false;
                response.Errors = new object[] { ex.Message };
                return response;
            }
        }
        public async Task<PersonPhoneResponse> AddAsync(PersonPhoneRequest personPhoneRequest)
        {
            try
            {
                PersonPhoneDto personPhoneDto = _mapper.Map<PersonPhoneDto>(personPhoneRequest);
                PersonPhone personPhone = _mapper.Map<PersonPhone>(personPhoneDto);
                var result = await _personService.AddAsync(personPhone);
                var response = new PersonPhoneResponse();
                response.Success = result;
                return response;
            }
            catch (Exception ex)
            {
                var response = new PersonPhoneResponse();
                response.Success = false;
                response.Errors = new object[] { ex.Message };
                return response;
            }
        }
        public async Task<PersonPhoneResponse> DeleteAsync(int id)
        {
            try
            {
                var result = await _personService.DeleteAsync(id);
                var response = new PersonPhoneResponse();
                response.Success = result;
                return response;
            }
            catch (Exception ex)
            {
                var response = new PersonPhoneResponse();
                response.Success = false;
                response.Errors = new object[] { ex.Message };
                return response;
            }
        }

        public async Task<PersonPhoneResponse> AltAsync(PersonPhoneRequest personPhoneRequest)
        {
            try
            {
                PersonPhoneDto personPhoneDto = _mapper.Map<PersonPhoneDto>(personPhoneRequest);
                PersonPhone personPhone = _mapper.Map<PersonPhone>(personPhoneDto);
                var result = await _personService.AltAsync(personPhone);
                var response = new PersonPhoneResponse();
                response.Success = result;
                return response;
            }
            catch (Exception ex)
            {
                var response = new PersonPhoneResponse();
                response.Success = false;
                response.Errors = new object[] { ex.Message };
                return response;
            }
        }
    }
}
