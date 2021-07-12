using System.Threading.Tasks;
using ViaCep.Example.Core.Common;
using ViaCep.Example.Core.Models;

namespace ViaCep.Example.Core.Services
{
    public interface IViaCepService
    {
        Task<ServiceResult<Address>> GetAsync(uint zipCode);
    }
}