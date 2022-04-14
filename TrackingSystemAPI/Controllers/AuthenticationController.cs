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
using Tracker.Data.DTO;
using Tracker.Core;
using Tracker.Domain;
using Microsoft.AspNetCore.WebUtilities;

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
        private readonly IEmailSender _emailSender;
        public AuthenticateController(UserManager<ApplicationUser> userManager, IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _emailSender = emailSender;

        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            //  var clientId = userManager.FindByEmailAsync(model.Email);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.name),                  
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
                int usrId = 0;
                int clientId = 0;
                var lstEmployees = _context.Employees.Where(a => a.Email == user.Email).ToList();
                if (lstEmployees.Count > 0)
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


                var name = user.name;
                var Useremail = user.Email;
                var LoginedUserId = user.Id;
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    email = Useremail,
                    UserName =Useremail,
                    Name=name,
                    roles = userRoles,
                    expiration = token.ValidTo,
                    id = usrId,
                    LoginedUserId = user.Id,
                    clientId = clientId
                });
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
                UserName = model.Email,
                name = model.name 
            };
            var result = await userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
            if (model.Roles == "SuperAdmin")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.SuperAdmin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.SuperAdmin));
                await userManager.AddToRoleAsync(user, UserRoles.SuperAdmin);
            }
            else if (model.Roles=="Admin")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                await userManager.AddToRoleAsync(user, UserRoles.Admin);
            }
            else if(model.Roles == "PMO")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.PMO))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.PMO));
                await userManager.AddToRoleAsync(user, UserRoles.PMO);
            }
            else if (model.Roles == "PM")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.PM))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.PM));
                await userManager.AddToRoleAsync(user, UserRoles.PM);
            }
            else if (model.Roles == "TL")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.TL))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.TL));
                await userManager.AddToRoleAsync(user, UserRoles.TL);
            }
            else if (model.Roles == "Employee")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Employee))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Employee));
                await userManager.AddToRoleAsync(user, UserRoles.Employee);
            }
            else if (model.Roles == "Client")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Client))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Client));
                await userManager.AddToRoleAsync(user, UserRoles.Client);
            }
            else if (model.Roles == "ClientManager")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.ClientManager))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.ClientManager));
                await userManager.AddToRoleAsync(user, UserRoles.ClientManager);
            }
            else if(model.Roles == "Receptionist")
            {
                if (!await roleManager.RoleExistsAsync(UserRoles.Receptionist))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Receptionist));
                await userManager.AddToRoleAsync(user, UserRoles.Receptionist); 
            }
           
              //  string url = "http://localhost:4200/#/login";
                  string url = "http://10.10.0.129:7070/#/login";
                // string url =  "";

                var message = new MessageDTO(new string[] { $"{model.Email}" }, "Confirmation Email", $"Dear {model.name}\r\n Hope this email finds you well \r\n This is Al-Mostakbal Technology. As per your registration ," +
                    $" please note that your Email : {model.Email} And Password :{model.Password} follow link to login {url}");
                _emailSender.SendEmail(message);
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
        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDTO forgotPasswordModel)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await userManager.FindByEmailAsync(forgotPasswordModel.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);
            var param = new Dictionary<string, string>
             {
                 {"token", token },
                 {"email", forgotPasswordModel.Email }
             };

            var callback = QueryHelpers.AddQueryString(forgotPasswordModel.ClientURI, param);
            var hash = callback.Split("#");
            var query = hash[0];
            string replace = query.Replace("/?", "/#/Resetpassword?");
            var message = new MessageDTO(new string[] { user.Email }, "Al-Mostakbal Technology.", $"Dear {user.name}\r\n Please follow link to reset your password {replace}");
            // var message = new Message(new string[] { user.Email }, "Al-Mostakbal Technology.", replace);
            _emailSender.SendEmail(message);
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



        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await userManager.FindByEmailAsync(resetPasswordDto.Email);
            if (user == null)
                return BadRequest("Invalid Request");

            var resetPassResult = await userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.Password);
            if (!resetPassResult.Succeeded)
            {
                var errors = resetPassResult.Errors.Select(e => e.Description);

                return BadRequest(new { Errors = errors });
            }

            return Ok();


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
    }
