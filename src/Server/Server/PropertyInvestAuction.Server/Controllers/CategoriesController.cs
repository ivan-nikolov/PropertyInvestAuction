namespace PropertyInvestAuction.Server.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using PropertyInvestAuction.Server.Models.Categories;
    using PropertyInvestAuction.Services.Data;

    using static PropertyInvestAuction.Common.GlobalConstants;
    using static PropertyInvestAuction.Common.ErrorMessages;

    public class CategoriesController : BaseApiController
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponseModel>>> All()
            => Ok(await this.categoriesService.GetAllAsync<CategoryResponseModel>());

        [HttpGet]
        [Route(Id)]
        public async Task<ActionResult<CategoryResponseModel>> GetCategoty(string id)
        {
            var category = await this.categoriesService.GetByIdAsync<CategoryResponseModel>(id);
            if (category == null)
            {
                return BadRequest(CategoryDoesNotExists);
            }

            return Ok(category);
        }

        [HttpPut]
        [Route(Id)]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Edit(string id, CategoryEditModel input)
        {
            var result = await this.categoriesService.EditAsync(id, input.Name);
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
            var result = await this.categoriesService.DeleteAsync(id);
            if (result.Failure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult> Create(CategoryCreateModel input)
        {
            var isNameTaken = await this.categoriesService.CheckIfNameIsTaken(input.Name);
            if (isNameTaken)
            {
                return this.BadRequest(CategoryNameTaken);
            }

            await this.categoriesService.CreateAsync(input.Name);

            return Ok();
        }

        [HttpGet]
        [Route(nameof(CheckIfNameIsTaken))]
        [Authorize(Roles = AdministratorRoleName)]
        public async Task<ActionResult<bool>> CheckIfNameIsTaken([FromQuery]string name)
            => Ok(await this.categoriesService.CheckIfNameIsTaken(name));
    }
}
