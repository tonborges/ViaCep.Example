using Flunt.Extensions.Br.Localization;
using Flunt.Extensions.Br.Validations;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.Extensions.Configuration;
using Polly;
using Refit;
using System;
using System.Threading.Tasks;
using ViaCep.Example.Core.Common;
using ViaCep.Example.Core.Models;

namespace ViaCep.Example.Core.Services
{
    public class ViaCepService : BaseService<Address>, IViaCepService
    {
        private readonly IViaCepServiceRefit viaCepServiceRefit;

        public ViaCepService(IConfiguration configuration)
        {
            viaCepServiceRefit = RestService.For<IViaCepServiceRefit>(configuration.GetSection("ViaCepUrl").Value);
            CustomRegexPattern.ZipCodeRegexPattern = @"[0-9]{8}";
        }

        public async Task<ServiceResult<Address>> GetAsync(uint zipCode)
        {
            var zip = zipCode.ToString().PadLeft(8, '0');

            Validate(zip);

            if (IsValid)
            {
                var policy = Policy
                                .Handle<ApiException>()
                                .Or<Exception>()
                                .WaitAndRetry(3, retry => TimeSpan.FromSeconds(Math.Pow(2, retry)));

                return await policy.Execute(async () =>
                {
                    return HandleResult(await viaCepServiceRefit.GetAsync(zip));
                });
            }

            return HandleResult(default);
        }

        private void Validate(string zip)
        {
            var errorMessage = "Invalid zip code";

            AddNotifications(new Contract<Notification>()
                                    .IsZipCode(zip, null, errorMessage)
                                    .IsFalse(zip == "00000000", null, errorMessage));
        }
    }
}