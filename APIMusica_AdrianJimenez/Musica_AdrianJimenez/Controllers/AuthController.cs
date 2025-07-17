using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Musica_AdrianJimenez.Data;
using Musica_AdrianJimenez.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Musica_AdrianJimenez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IdentityContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(IdentityContext context,
            UserManager<AppUser> userManager,
            IConfiguration configuration,
            RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(string? email, string password)
        {
            if(email != null && password != null)
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                AppUser? user = _userManager.Users.Where(u => u.Email == email).FirstOrDefault();

                if (!(User == null))
                {
                        bool checkPassword = await _userManager.CheckPasswordAsync(user, password);
                    if(checkPassword)
                        {
                            var searchRoles = await _userManager.GetRolesAsync(user);

                            return Ok(tokenGenerated(user, searchRoles));
                        }
                        return BadRequest("Las contraseñas no coinciden");
                }
                    return BadRequest("El usuario no existe");
            }
            return BadRequest("El modelo pasado no es válido");
        }

        [HttpPost]
        [Route("Registrer")]
        public async Task<ActionResult> Register([FromBody] AppUser appUser)
        {
            if(ModelState.IsValid)
            {
                AppUser? user = _userManager.Users.Where(u => u.UserName == appUser.UserName).FirstOrDefault();

                if(user == null)
                {
                    PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();

                    appUser.PasswordHash = passwordHasher.HashPassword(appUser, appUser.password);

                    var result = await _userManager.CreateAsync(appUser);

                    if(result.Succeeded)
                    {
                        IdentityRole defaultRole = await _roleManager.FindByNameAsync("user");

                        if(defaultRole != null)
                        {
                            IdentityResult roleResult = await _userManager.AddToRoleAsync(appUser, defaultRole.Name);
                            
                            IList<string> searchRole = await _userManager.GetRolesAsync(appUser);

                            return Ok(tokenGenerated(appUser, searchRole));


                        }
                        return BadRequest("No se pudo añadir el rol por defecto");
                    }
                    return BadRequest("Ha habido porblemas al crear el usuario");
                }
                return BadRequest("El usuario ya existe");
            }
            return BadRequest("Uno o más campos no son adecuados");
            /*if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var user = new AppUser
                {
                    UserName = email,
                    Email = email
                };
                var passwordHasher = new PasswordHasher<AppUser>();
                user.PasswordHash = passwordHasher.HashPassword(user, password);

                await _userManager.CreateAsync(user);

                var claims = new List<Claim>
                        {
                            new Claim( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim( JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", user.Id),
                            new Claim("UserName", user.UserName),
                            new Claim("Email", user.Email)
                        };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: credentials);

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest();
            }*/
        }

        private string tokenGenerated(AppUser user, IList<String> roles)
        {
            var claims = new List<Claim>
                        {
                            new Claim( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                            new Claim( JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                            new Claim("UserId", user.Id),
                            new Claim("UserName", user.UserName),
                            new Claim("Email", user.Email),
                            new Claim("Name", user.nombre),
                            new Claim("Apellidos", user.apellidos),
                            new Claim("CodPostal", user.codigoPostal),
                            new Claim(ClaimTypes.Role, string.Join(",", roles))
                        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
