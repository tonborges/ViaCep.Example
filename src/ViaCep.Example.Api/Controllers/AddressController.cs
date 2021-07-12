using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ViaCep.Example.Core.Services;

namespace ViaCep.Example.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private readonly IViaCepService viaCepService;

        public AddressController(IViaCepService viaCepService)
        {
            this.viaCepService = viaCepService;
        }

        [HttpGet("zip-code/{zipCode}")]
        public async Task<IActionResult> FindZipCodeAsync([FromRoute]uint zipCode)
        {
            return Json(await viaCepService.GetAsync(zipCode));
        }
    }
}