namespace PropertyInvestAuction.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PropertyInvestAuction.Server.Models.Countries;
    using PropertyInvestAuction.Server.Models.Country;
    using PropertyInvestAuction.Services.Data;

    using static Common.GlobalConstants;
    using static Common.ErrorMessages;
    using System.Linq;

    public class CountriesController : BaseApiController
    {
        private readonly ICountriesService countryService;

        public CountriesController(ICountriesService countryService)
        {
            this.countryService = countryService;
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Create(CreateInputModel input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid country name");
            }

            var countryId = await this.countryService.CreateAsync(input.Name);

            return Created(nameof(Create), new { countryId });
        }

        [HttpGet]
        [Route(nameof(All))]
        [Authorize]
        public async Task<IEnumerable<CountryListModel>> All()
        {
            return await this.countryService.GetAllAsync<CountryListModel>();
        }

        [HttpDelete]
        [Route(Id)]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await this.countryService.DeleteAsync(id);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut]
        [Route(Id)]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Edit(string id, CountryEditModel input)
        {
            var result = await this.countryService.EditAsync(id, input.Name);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        [Route(nameof(CheckCountryName))]
        [Authorize]
        public async Task<ActionResult> CheckCountryName([FromQuery]string name)
            => Ok(await this.countryService.CheckIfNameIsTaken(name));
    }
}
