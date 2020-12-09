namespace PropertyInvestAuction.Server.Controllers
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected const string Id = "{Id}";

        protected List<string> GetValidationErrors()
        {
            var errors = new List<string>();
            foreach (var value in this.ModelState.Values)
            {
                errors.AddRange(value.Errors.Select(e => e.ErrorMessage));
            }

            return errors;
        }
    }
}
