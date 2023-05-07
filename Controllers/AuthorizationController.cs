using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OOP.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class AuthorizationController : ControllerBase
{
    
    public AuthorizationController()
    {
        
    }

    [HttpPost]
    [AllowAnonymous]
    public bool Post([FromBody]AuthorizationInputData authorizationInputData)
    {
        return true;
    }
}

public class AuthorizationInputData
{
    public string Login { get; set; }
    public string Password { get; set; }
}