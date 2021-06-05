

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
    public class PhoneNumberTypeFacade : IPhoneNumberTypeFacade
    {
        private readonly IPhoneNumberTypeService _phoneNumberTypeService;
        private readonly IMapper _mapper;

        public PhoneNumberTypeFacade(IPhoneNumberTypeService phoneNumberTypeService, IMapper mapper)
        {
            _phoneNumberTypeService = phoneNumberTypeService;
            _mapper = mapper;
        }
        public async Task<PhoneNumberTypeListResponse> FindAllAsync()
        {
            try
            {
                var result = await _phoneNumberTypeService.FindAllAsync();
                var response = new PhoneNumberTypeListResponse();
                List<PhoneNumberTypeDto> phoneNumberTypeObjects = result.Select(x => _mapper.Map<PhoneNumberTypeDto>(x)).ToList();
                response.Data = phoneNumberTypeObjects;
                return response;
            }
            catch (Exception ex)
            {
                var response = new PhoneNumberTypeListResponse();
                response.Success = false;
                response.Errors = new object[] { ex.Message };
                return response;
            }

        }
    }
}