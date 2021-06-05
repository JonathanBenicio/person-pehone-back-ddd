using Abp.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> GetAllAsync(int id);
        Task<EntityEntry<PersonAggregate.PersonPhone>> AddAsync(PersonPhone personPhone);
        Task<EntityEntry<PersonAggregate.PersonPhone>> AltAsync(PersonPhone personPhone);
        Task<EntityEntry<PersonAggregate.PersonPhone>> DeleteAsync(int id);

    }
}
