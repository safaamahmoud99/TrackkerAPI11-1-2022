using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Tracker.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Tracker.Data.ViewModels;

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public AuthenticateController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login( LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
          //  var clientId = userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("key","value"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                foreach (var claim in authClaims)
                {
                    await userManager.AddClaimAsync(user, claim);

                }
                // safaa commit 
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                var userId = User.FindFirstValue(ClaimTypes.Email);
                //var usrId = user.Id;
                var x = user.Email;
                int usrId=0;
                int clientId = 0;
               var lstEmployees = _context.Employees.Where(a => a.Email == user.Email).ToList();
                if(lstEmployees.Count > 0)
                {
                    Employee employeeObj = lstEmployees[0];
                     usrId = employeeObj.Id;
                }
                var lstClients = _context.clients.Where(a => a.Email == user.Email).ToList();
                if (lstClients.Count > 0)
                {
                    Client clintObj = lstClients[0];
                    clientId = clintObj.Id;
                }


                var name = user.UserName;
                var Useremail = user.Email;
                var LoginedUserId = user.Id;
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    email = Useremail,
                    UserName = name,
                    roles= userRoles,
                    expiration = token.ValidTo,
                    id= usrId,
                    LoginedUserId=user.Id,
                    clientId = clientId
                }) ;
            }
            return Unauthorized();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] UserVM model)
        {
            var userExists = await userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });
            model.UserName = model.UserName.Replace(' ', '_');
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName=model.UserName
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            if (model.Role == "SuperAdmin")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));
                await userManager.AddToRoleAsync(user, UserRoles.SuperAdmin);
            }
            else if (model.Role=="Admin")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            else if(model.Role == "PMO")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.PMO))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.PMO));
                await userManager.AddToRoleAsync(user, UserRoles.PMO);
            }
            else if (model.Role == "PM")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.PM))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.PM));
                await userManager.AddToRoleAsync(user, UserRoles.PM);
            }
            else if (model.Role == "TL")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.TL))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.TL));
                await userManager.AddToRoleAsync(user, UserRoles.TL);
            }
            else if (model.Role == "Employee")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));
                await userManager.AddToRoleAsync(user, UserRoles.Employee);
            }
            else if (model.Role == "Client")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Client))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Client));
                await userManager.AddToRoleAsync(user, UserRoles.Client);
            }
            else if (model.Role == "ClientManager")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.ClientManager))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.ClientManager));
                await userManager.AddToRoleAsync(user, UserRoles.ClientManager);
            }
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        [HttpPost]
        [Route("changPassword")]
        public async Task<IActionResult> ChangPassword(ChangePassword model)
        {
            var mail = await userManager.FindByNameAsync(model.userName);
            //user != null && await userManager.CheckPasswordAsync(user, model.Password)
            await userManager.ChangePasswordAsync(mail, model.Password, model.NewPassword);
            return Ok();
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));
            if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
            if (await roleManager.RoleExistsAsync(UserRoles.PMO))
                await userManager.AddToRoleAsync(user, UserRoles.PMO);

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }

        // to check homepage interceptor
        //[Authorize]
        //[HttpGet]
        //[Route("checkInterceptor")]
        //public async Task<IActionResult> CheckInterceptor()
        //{
        //    return  Ok();
        //}
    }
}
