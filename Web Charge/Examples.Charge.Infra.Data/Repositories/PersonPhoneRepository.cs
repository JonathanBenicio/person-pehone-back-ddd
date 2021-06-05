using Abp.Domain.Entities;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonPhoneRepository : IPersonPhoneRepository
    {
        private readonly ExampleContext _context;

        public PersonPhoneRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PersonPhone>> GetAllAsync(int idPerson) => await Task.Run(() => _context.PersonPhones.Where(x=>x.BusinessEntityID == idPerson).ToList());
        public async Task<int> GetLastKeyAsync() => await Task.Run(() => _context.PersonPhones.LastOrDefault().Id);

        public async Task<EntityEntry<PersonPhone>> AltAsync(PersonPhone personPhone) => await Task.Run(() => _context.PersonPhones.Update(personPhone));
        public async Task<EntityEntry<PersonPhone>> AddAsync(PersonPhone personPhone) => await Task.Run(() => _context.PersonPhones.Add(personPhone));
        public async Task<EntityEntry<PersonPhone>> DeleteAsync(int id) => await Task.Run(() => _context.PersonPhones.Remove(_context.PersonPhones.Find(id)));
    }
}
