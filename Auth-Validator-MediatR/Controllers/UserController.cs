using Auth_Validator_MediatR.Commands;
using Auth_Validator_MediatR.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Validator_MediatR.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        if (!Guid.TryParse(id, out _))
        {
            var resultUid = await _mediator.Send(new GetUserByUsernameQuery(id));
            
            if(!ModelState.IsValid) throw new ArgumentNullException(nameof(id));
            
            return Ok(resultUid);
        }

        var guid = Guid.Parse(id);
        
        var result = await _mediator.Send(new GetUserByIdQuery(guid));
        
        return result != null ? (IActionResult) Ok(result) : NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddUser([FromBody] AddUserCommand? newUser)
    {
        if (newUser is null)
            return BadRequest(new ArgumentNullException());
        
        if (!ModelState.IsValid)
            return BadRequest(new ArgumentNullException());
        
        var result = await _mediator.Send(newUser);
        return CreatedAtAction("Get", new { id = result.Id}, result);
    }
}