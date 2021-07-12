using Refit;
using System.Threading.Tasks;
using ViaCep.Example.Core.Models;

namespace ViaCep.Example.Core.Services
{
    public interface IViaCepServiceRefit
    {
        [Get("/ws/{cep}/json/")]
        Task<Address> GetAsync(string cep);
    }
}