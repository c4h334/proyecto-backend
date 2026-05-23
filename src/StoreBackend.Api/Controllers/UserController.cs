using Microsoft.AspNetCore.Mvc;
using StoreBackend.Api.Mappers;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Exceptions;
using StoreBackend.Facade;

namespace StoreBackend.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] CreateUserRequestModel user)
        {
            try
            {
                var requestDto = UserMapper.ToDto(user);
                var userDto = await _userFacade.CreateAsync(requestDto);
                var userModel = UserMapper.ToModel(userDto);
                return Ok(userModel);
            }
            catch (BadRequestResponseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "An error occurred while processing the request.");
            }
        }
    }
}