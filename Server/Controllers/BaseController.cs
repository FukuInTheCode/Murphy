using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers;

public class BaseController : Controller
{
    protected ObjectResult Created(object? content) => StatusCode(201, content);
}