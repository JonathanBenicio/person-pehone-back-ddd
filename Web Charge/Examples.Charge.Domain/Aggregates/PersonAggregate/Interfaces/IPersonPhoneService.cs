using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService
    {
        Task<List<PersonPhone>> GetAllAsync(int id);
        Task<bool> AddAsync(PersonPhone personPhoneRequest);
        Task<bool> AltAsync(PersonPhone personPhoneRequest);
        Task<bool> DeleteAsync(int id);
    }
}
