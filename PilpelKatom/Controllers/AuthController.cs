using Microsoft.AspNetCore.Mvc;
using PilpelKatom.Data;
using PilpelKatom.Dtos.User;

namespace PilpelKatom.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<int>>> Resgister(UserRegisterDto request)
    {
        var response = await _authRepository.Register(new User
        {
            Username = request.Username
        }, request.Password);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<ActionResult<ServiceResponse<int>>> Login(UserLoginDto request)
    {
        var response = await _authRepository.Login(request.Username,request.Password);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
}