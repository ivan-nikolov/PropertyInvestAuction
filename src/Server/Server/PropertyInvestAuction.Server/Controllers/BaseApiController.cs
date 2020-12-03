namespace PropertyInvestAuction.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
        protected const string Id = "{Id}";
    }
}
