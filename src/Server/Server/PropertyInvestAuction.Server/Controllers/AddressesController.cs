namespace PropertyInvestAuction.Server.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PropertyInvestAuction.Server.Models.Addresses;
    using PropertyInvestAuction.Services.Data;

    using static PropertyInvestAuction.Common.ErrorMessages;

    public class AddressesController : BaseApiController
    {
        private readonly IAddressesService addressesService;
        private readonly ICitiesService citiesService;
        private readonly INeighborhoodsService neighborhoodsService;


        public AddressesController(
            IAddressesService addressesService,
            ICitiesService citiesService,
            INeighborhoodsService neighborhoodsService)
        {
            this.addressesService = addressesService;
            this.citiesService = citiesService;
            this.neighborhoodsService = neighborhoodsService;
        }

        [HttpGet]
        public async Task<ActionResult<AddressResponseModel>> GetAll(string cityId, string neighborhoodId)
        {
            var addresses = await this.addressesService.GetAllAsync<AddressResponseModel>(cityId, neighborhoodId);

            return Ok(addresses);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(AddressCreateRequestModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return ValidationProblem(this.ModelState);
            }

            if (!await this.citiesService.CheckIfExistsAsync(input.CityId))
            {
                return BadRequest(CityDoesNotExists);
            }

            if (input.NeighborhoodId != null 
                && !await this.neighborhoodsService.CheckIfExistsAsync(input.NeighborhoodId))
            {
                return BadRequest(NeighborhoodDoesNotExists);
            }

            if (!await this.neighborhoodsService.IsNeighborghoodInCity(input.NeighborhoodId, input.CityId))
            {
                return BadRequest(CityHasNoSuchNeighborhood);
            }

            var addressId = await this.addressesService.CreateAsync(input.Name, input.CityId, input.NeighborhoodId);

            return Ok(addressId);
        }
    }
}
