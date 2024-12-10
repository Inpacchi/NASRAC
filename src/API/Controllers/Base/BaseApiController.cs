using Microsoft.AspNetCore.Mvc;

namespace NASRAC.API.Controllers.Base;

[ApiController]
[Route("api/v1/[controller]")]
public abstract class BaseApiController : ControllerBase
{
}