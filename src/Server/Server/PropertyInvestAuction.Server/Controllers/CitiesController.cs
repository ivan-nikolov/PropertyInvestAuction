namespace PropertyInvestAuction.Server.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Server.Models.Cities;

    using Services.Data;

    using static Common.GlobalConstants;
    using static Common.ErrorMessages;

    public class CitiesController : BaseApiController
    {
        private readonly ICitiesService citiesService;
        private readonly ICountriesService countriesService;

        public CitiesController(ICitiesService citiesService, ICountriesService countriesService)
        {
            this.citiesService = citiesService;
            this.countriesService = countriesService;
        }

        [HttpGet]
        [Route(nameof(All))]
        public async Task<IEnumerable<CityResponseModel>> All()
            => await this.citiesService.AllAsync<CityResponseModel>();

        [HttpGet]
        public async Task<IEnumerable<CityResponseModel>> AllByCoutry(string countryId)
            => await this.citiesService.GetByCountryIdAsync<CityResponseModel>(countryId);

        [HttpPost]
        [Route(nameof(Create))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Create(CreateCityRequestModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var value in this.ModelState.Values)
                {
                    errors.AddRange(value.Errors.Select(e => e.ErrorMessage));
                }
                return BadRequest(errors);
            }

            if (!await this.countriesService.CheckIfExistsAsync(input.CountryId))
            {
                return BadRequest(CountryDoesNotExists);
            }

            var result = await this.citiesService.CreateAsync(input.CountryId, input.Name);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut]
        [Route(Id)]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Edit(string id, EditRequestModel input)
        {
            if (!this.ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var value in this.ModelState.Values)
                {
                    errors.AddRange(value.Errors.Select(e => e.ErrorMessage));
                }
                return BadRequest(errors);
            }

            var result = await this.citiesService.EditAsync(id, input.Name);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await this.citiesService.DeleteAsync(id);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        [Route(nameof(CheckCityName))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<bool> CheckCityName([FromQuery]string countryId, string name)
            => await this.citiesService.CheckIfNameIsTaken(countryId, name);
    }
}
