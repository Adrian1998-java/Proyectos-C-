using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musica_AdrianJimenez.Data;
using Musica_AdrianJimenez.Models;

namespace Musica_AdrianJimenez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class UsersController : ControllerBase
    {

        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> context)
        {
            _userManager = context;
        }

        private async Task<AppUser> getRolesFromAppUser(AppUser user)
        {
            IList<string> resultRoles = await _userManager.GetRolesAsync(user);
            user.roles = resultRoles.ToList();

            return user;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            List<AppUser> users = await _userManager.Users.ToListAsync();

            for(int i = 0; i< users.Count; i++)
            {
                users[i] = await getRolesFromAppUser(users[i]);
            }
            return users;
        }
    }
}
