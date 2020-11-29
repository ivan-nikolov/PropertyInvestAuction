namespace PropertyInvestAuction.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PropertyInvestAuction.Server.Models.Country;
    using PropertyInvestAuction.Services.Data;

    using static PropertyInvestAuction.Common.GlobalConstants;

    public class CountriesController : BaseApiController
    {
        private readonly ICountryService countryService;

        public CountriesController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpPost]
        [Route(nameof(Create))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Create(CreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid country name");
            }

            var countryId = await this.countryService.CreateAsync(input.Name);

            return Ok(countryId);
        }

        [HttpGet]
        [Route(nameof(All))]
        [Authorize]
        public async Task<IEnumerable<CountryListModel>> All()
        {
            return await this.countryService.GetAllAsync<CountryListModel>();
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Delete(string id)
        {
            await this.countryService.DeleteAsync(id);
            return Ok();
        }
    }
}
