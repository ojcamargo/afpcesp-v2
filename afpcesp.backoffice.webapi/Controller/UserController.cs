using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using afpcesp.backoffice.webapi.ViewModel;
using afpcesp.backoffice.webapi.Mappers;
using afpcesp.application.Services;

namespace afpcesp.backoffice.webapi.Controller
{
    /// <summary>
    /// Controller for managing user-related operations.
    /// Provides endpoints for creating, reading, updating, and deleting users.
    /// Requer autenticação JWT para todos os endpoints.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Protege todos os endpoints deste controller
    public class UserController : ControllerBase
    {
        private readonly IUserApplicationService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The service for user operations.</param>
        public UserController(IUserApplicationService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A list of users.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            var viewModels = ViewModelMapper.ToViewModelList(users);
            return Ok(viewModels);
        }

        /// <summary>
        /// Retrieves a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>The user with the specified ID.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserViewModel>> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var viewModel = ViewModelMapper.ToViewModel(user);
            return Ok(viewModel);
        }

        /// <summary>
        /// Creates a new user.
        /// Requer role 'Admin' para criar usuários.
        /// </summary>
        /// <param name="user">The user to create.</param>
        /// <returns>The created user.</returns>
        [HttpPost]
        [Authorize(Roles = "Admin")] // Apenas Admin pode criar usuários
        [ProducesResponseType(typeof(UserViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UserViewModel>> CreateUser(CreateUserRequest user)
        {
            var createModel = ViewModelMapper.ToCreateModel(user);
            var createdUser = await _userService.CreateUserAsync(createModel);
            var viewModel = ViewModelMapper.ToViewModel(createdUser);
            return CreatedAtAction(nameof(GetUserById), new { id = viewModel.Id }, viewModel);
        }

        /// <summary>
        /// Updates an existing user.
        /// Requer role 'Admin' para atualizar usuários.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="user">The updated user data.</param>
        /// <returns>No content if successful.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")] // Apenas Admin pode atualizar usuários
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var updateModel = ViewModelMapper.ToUpdateModel(user);
            var result = await _userService.UpdateUserAsync(updateModel);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deletes a user by ID.
        /// Requer role 'Admin' para deletar usuários.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>No content if successful.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")] // Apenas Admin pode deletar usuários
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}