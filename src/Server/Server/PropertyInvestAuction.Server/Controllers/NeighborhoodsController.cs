namespace PropertyInvestAuction.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PropertyInvestAuction.Server.Models.Neighborhoods;

    using Services.Data;

    using static Common.GlobalConstants;
    using static Common.ErrorMessages;
    using System.Linq;

    public class NeighborhoodsController : BaseApiController
    {
        private readonly INeighborhoodsService neighborhoodsService;
        private readonly ICitiesService citiesService;

        public NeighborhoodsController(
            INeighborhoodsService neighborhoodsService,
            ICitiesService citiesService)
        {
            this.neighborhoodsService = neighborhoodsService;
            this.citiesService = citiesService;
        }

        [HttpGet]
        [Route(nameof(GetByCityId))]
        [Authorize]
        public async Task<ActionResult<IEnumerable<NeighborhoodResponseModel>>> GetByCityId([FromQuery] string cityId)
        {
            if (!await this.citiesService.CheckIfExistsAsync(cityId))
            {
                return this.BadRequest(CityDoesNotExists);
            }

            var neighborhoods = await this.neighborhoodsService.GetByCityIdAsync<NeighborhoodResponseModel>(cityId);

            return Ok(neighborhoods);
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Create(NeighborhoodCreateRequestModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.ValidationProblem(this.ModelState);
            }

            if (!await this.citiesService.CheckIfExistsAsync(input.CityId))
            {
                return this.BadRequest(CityDoesNotExists);
            }

            await this.neighborhoodsService.CreateAsync(input.Name, input.CityId);
            return Ok();
        }

        [HttpPut]
        [Route(Id)]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Edit(string id, NeighborhoodEditRequestModel input)
        {
            if (!this.ModelState.IsValid)
            {
                this.ValidationProblem(this.ModelState);
            }

            var result = await this.neighborhoodsService.EditAsync(id, input.Name);
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
            var result = await this.neighborhoodsService.DeleteAsync(id);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        [Route(nameof(CheckName))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<bool> CheckName([FromQuery] string cityId, string name)
            => await this.neighborhoodsService.CheckName(cityId, name);
    }
}
