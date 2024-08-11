using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using StatusCodes = Shared.Enums.StatusCodes;

namespace Server.Controllers;

public class BaseController : Controller
{
    protected ObjectResult Created(object? content) => StatusCode((int)StatusCodes.Created, content);
}