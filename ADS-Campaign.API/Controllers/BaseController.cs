using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADS_Campaign.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/adscampaign/[controller]")]
    public class BaseController : ControllerBase
    {

    }
}
