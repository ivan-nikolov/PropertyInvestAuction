namespace PropertyInvestAuction.Server.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PropertyInvestAuction.Server.Infrastructure;
    using PropertyInvestAuction.Server.Models.Properties;
    using PropertyInvestAuction.Services;
    using PropertyInvestAuction.Services.Data;
    using PropertyInvestAuction.Services.Models;

    using static PropertyInvestAuction.Common.ErrorMessages;

    public class PropertiesController : BaseApiController
    {
        private readonly IPropertiesService propertiesService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ICategoriesService categoriesService;
        private readonly IAddressesService addressesService;

        public PropertiesController(
            IPropertiesService propertiesService,
            ICloudinaryService cloudinaryService,
            ICategoriesService categoriesService,
            IAddressesService addressesService)
        {
            this.propertiesService = propertiesService;
            this.cloudinaryService = cloudinaryService;
            this.categoriesService = categoriesService;
            this.addressesService = addressesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertiResponseModel>>> All([FromQuery] PropertyQueryModel query)
        {
            var filters = this.GetFilters(query);

            var properties = await this.propertiesService
                .GetAllAsync<PropertiResponseModel, PropertyDto>(query.PageSize, query.Page, filters);

            return Ok(properties);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(PropertyCreateRequestModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return ValidationProblem(this.ModelState);
            }

            if (!await this.addressesService.CheckIfExistsAsync(input.AddressId))
            {
                return BadRequest(AddressDoesNotExists);
            }

            if (!await this.categoriesService.CheckIfExistsAsync(input.CategoryId))
            {
                return BadRequest(CategoryDoesNotExists);
            }

            var userId = this.User.GetId();
            var imageUrls = await this.cloudinaryService.UploadFilesAsync(input.Photos);
            var propertyId = await this.propertiesService.CreateAsync(input.Description, input.AddressId, userId, input.CategoryId, imageUrls);

            return Ok(propertyId);
        }

        [HttpPut]
        [Route(Id)]
        [Authorize]
        public async Task<ActionResult> Edit(string id, PropertyEditRequestModel input)
        {
            var userId = this.User.GetId();
            if (!await this.propertiesService.IsUserAuthorized(id, userId))
            {
                return Unauthorized();
            }

            if (!this.ModelState.IsValid)
            {
                return ValidationProblem(this.ModelState);
            }

            if (!await this.categoriesService.CheckIfExistsAsync(input.CategoryId))
            {
                return BadRequest(CategoryDoesNotExists);
            }

            var photosUrls = await this.cloudinaryService.UploadFilesAsync(input.Photos);

            var result = await this.propertiesService.Edit(id, input.Description, input.CategoryId, photosUrls);

            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        [Route(Id)]
        [Authorize]
        public async Task<ActionResult> Delete(string id)
        {
            var userId = this.User.GetId();
            if (!await this.propertiesService.IsUserAuthorized(id, userId))
            {
                return Unauthorized();
            }

            var result = await this.propertiesService.DeleteAsync(id);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [NonAction]
        private IEnumerable<Expression<Func<PropertyDto, bool>>> GetFilters(PropertyQueryModel query)
        {
            var filters = new List<Expression<Func<PropertyDto, bool>>>();

            if (!string.IsNullOrWhiteSpace(query.CategoryId))
            {
                filters.Add(x => x.CategoryId == query.CategoryId);
            }

            if (!string.IsNullOrWhiteSpace(query.Description))
            {
                filters.Add(x => x.Description.ToLower().Contains(query.Description.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(query.AddressId))
            {
                filters.Add(x => x.AddressId == query.AddressId);
            }
            else if (!string.IsNullOrWhiteSpace(query.NeighborhoodId))
            {
                filters.Add(x => x.Address.NeighborhoodId == query.NeighborhoodId);
            }
            else if (!string.IsNullOrWhiteSpace(query.CityId))
            {
                filters.Add(x => x.Address.CityId == query.AddressId || x.Address.Neighborhood.CityId == query.CityId);
            }
            else if (!string.IsNullOrWhiteSpace(query.CountryId))
            {
                filters.Add(x => x.Address.City.CountryId == query.CountryId 
                || x.Address.Neighborhood.City.CountryId == query.CountryId);
            }

            return filters;
        }
    }
}
