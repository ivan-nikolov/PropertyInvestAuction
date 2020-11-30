﻿namespace PropertyInvestAuction.Server.Controllers
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
        [Authorize]
        public async Task<ActionResult<IEnumerable<NeighborhoodResponseModel>>> GetByCityId(string cityId)
        {
            if (!await this.citiesService.CheckIfExistsAsync(cityId))
            {
                return this.BadRequest(CityDoesNotExists);
            }

            var neighborhoods = await this.neighborhoodsService.GetByCItyIdAsync<NeighborhoodResponseModel>(cityId);

            return Ok(neighborhoods);
        }

        [HttpPost]
        [Route(nameof(Create))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Create(CreateRequestModel input)
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

            if (!await this.citiesService.CheckIfExistsAsync(input.CityId))
            {
                return this.BadRequest(CityDoesNotExists);
            }

            await this.neighborhoodsService.CreateAsync(input.Name, input.CityId);
            return Ok();
        }

        [HttpPut]
        [Route(nameof(Edit))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Edit(EditRequestModel input)
        {
            var result = await this.neighborhoodsService.EditAsync(input.Id, input.Name);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Delete(DeleteRequestModel input)
        {
            var result = await this.neighborhoodsService.DeleteAsync(input.Id);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
