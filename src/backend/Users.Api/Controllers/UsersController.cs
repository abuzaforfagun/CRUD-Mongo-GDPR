using Microsoft.AspNetCore.Mvc;
using User.Api.Services;
using Users.Api.Models.Dto;
using Users.Api.Services;

namespace Users.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesErrorResponseType(typeof(void))]
public class UsersController : ControllerBase
{
    private readonly IUsersService _service;

    public UsersController(IUsersService service)
    {
        _service = service;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesErrorResponseType(typeof(BadRequestResult))]
    public async Task<IActionResult> CreateAsync(CreateUser model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _service.CreateAsync(model);
        }
        catch (BadHttpRequestException)
        {
            return BadRequest();
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Created();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetUserDetails), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(NotFoundResult))]
    public async Task<IActionResult> GetAsync(string id, CancellationToken cancellationToken)
    {
        GetUserDetails? user;
        try
        {
            user = await _service.GetUserAsync(id, cancellationToken);

            if (user == null)
            {
                return NotFound();
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        return Ok(user);
    }

    [ProducesResponseType(typeof(GetUsers), StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var users = new GetUsers();

        try
        {
            users = await _service.GetUsersAsync(cancellationToken);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return Ok(users);
    }
}