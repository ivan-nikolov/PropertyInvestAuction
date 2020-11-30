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

    public class CitiesController : BaseApiController
    {
        private readonly ICitiesService citiesService;

        public CitiesController(ICitiesService citiesService)
        {
            this.citiesService = citiesService;
        }

        [HttpGet]
        [Route(nameof(All))]
        public async Task<IEnumerable<CityResponseModel>> All()
            => await this.citiesService.AllAsync<CityResponseModel>();

        [HttpGet]
        public async Task<IEnumerable<CityResponseModel>> AllByCoutry(string coutryId)
            => await this.citiesService.GetByCountryIdAsync<CityResponseModel>(coutryId);

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

            var result = await this.citiesService.CreateAsync(input.CountryId, input.Name);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut]
        [Route(nameof(Edit))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Edit(EditRequestModel input)
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

            var result = await this.citiesService.EditAsync(input.Id, input.Name);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost]
        [Route(nameof(Delete))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Delete(DeleteRequestModel input)
        {
            var result = await this.citiesService.DeleteAsync(input.Id);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
