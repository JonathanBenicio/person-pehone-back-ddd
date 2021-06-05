using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Interfaces
{
    public interface IPersonPhoneFacade
    {
       Task<PersonPhoneListResponse> GetAllAsync(int idPerson);
       Task<PersonPhoneResponse> AddAsync(PersonPhoneRequest personPhoneRequest);
       Task<PersonPhoneResponse> DeleteAsync(int id);
       Task<PersonPhoneResponse> AltAsync(PersonPhoneRequest personPhoneRequest);
    }
}
