using Microsoft.AspNetCore.Mvc;

namespace Staffer.BackEnd.Controllers;

[ApiController]
[Route("/staffers")]
public class StaffersController : ControllerBase
{
    [HttpGet]
    public JsonResult GetAllStaffers()
    {
        return new JsonResult(DB.GetAllStaffers());
    }
}