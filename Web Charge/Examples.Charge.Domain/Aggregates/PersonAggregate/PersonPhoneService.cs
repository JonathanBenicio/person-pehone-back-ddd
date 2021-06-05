using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository, IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _personPhoneRepository = personPhoneRepository;
            _phoneNumberTypeRepository = phoneNumberTypeRepository;
        }

        public async Task<List<PersonPhone>> GetAllAsync(int idPerson) => (await _personPhoneRepository.GetAllAsync(idPerson)).ToList();
        public async Task<bool> AddAsync(PersonPhone personPhone)
        {
            var entityEntry = await _personPhoneRepository.AddAsync(personPhone);

            if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Context.SaveChanges();
                return true;
            }
            return false;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var entityEntry = await _personPhoneRepository.DeleteAsync(id);

            if (entityEntry.State == EntityState.Deleted)
            {
                await entityEntry.Context.SaveChangesAsync();
                return true;
            }
            return false;

        }
        public async Task<bool> AltAsync(PersonPhone personPhone)
        {
            personPhone.PhoneNumberType = _phoneNumberTypeRepository.GetAsync(personPhone.PhoneNumberTypeID).Result;

            var entityEntry = await _personPhoneRepository.AltAsync(personPhone);

            if (entityEntry.State == EntityState.Modified)
            {
                await entityEntry.Context.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
