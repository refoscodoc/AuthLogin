using System.IdentityModel.Tokens.Jwt;
using Auth_Validator_MediatR.Dtos;
using Auth_Validator_MediatR.Handlers;
using Auth_Validator_MediatR.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Validator_MediatR.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private readonly UserManager<UserModel> _userManager; 
    private readonly IMapper _mapper;
    private readonly JwtHandler _jwtHandler;
    
    public AccountsController(UserManager<UserModel> userManager, IMapper mapper, JwtHandler jwtHandler) 
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtHandler = jwtHandler;
    }
    
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] UserForAuthenticationDto userForAuthentication)
    {
        var user = await _userManager.FindByNameAsync(userForAuthentication.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, userForAuthentication.Password))
            return Unauthorized(new AuthResponseDto { ErrorMessage = "Invalid Authentication" });
        
        var signingCredentials = _jwtHandler.GetSigningCredentials();
        var claims = _jwtHandler.GetClaims(user);
        var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        
        return Ok(new AuthResponseDto { IsAuthSuccessful = true, Token = token });
    }
}