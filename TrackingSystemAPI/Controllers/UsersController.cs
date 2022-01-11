using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using  Tracker.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using  Tracker.Data.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration; 
        private readonly ApplicationDbContext _context;

        public UsersController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, IConfiguration configuration
            , ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<UsersWithRolesDTO>> GetAllUsersAsync()
        {
            List<UsersWithRolesDTO> usersWithRoles = new List<UsersWithRolesDTO>();
            UsersWithRolesDTO usersWithRolesDTO;
            var users = userManager.Users.ToList();
            var roles = roleManager.Roles.ToList();
            foreach (var User in users)
            {
                foreach (var role in roles)
                {
                    if ( await userManager.IsInRoleAsync(User, role.Name))
                    {
                        usersWithRolesDTO= new UsersWithRolesDTO()
                        {
                            id=User.Id,
                            Email = User.Email,
                            Role = role.Name,
                            UserName = User.UserName
                        };
                        usersWithRoles.Add(usersWithRolesDTO);
                    }
                }
            }
            //return View(model);
            return usersWithRoles;
        }

        [HttpGet]
        [Route("GetUnregisteredUsers")]
        public IEnumerable<Employee> GetUnregisteredUsers()
        {
            //List<Employee> emps = new List<Employee>();
            var users = userManager.Users.ToList();
            var employees = _context.Employees.ToList();
            var emps = _context.Employees.ToList();
            foreach (var employee in employees)
            {
                foreach (var user in users)
                {
                    if (employee.Email == user.Email)
                        emps.Remove(employee);
                }
            }
            return emps;
        }

        [HttpGet]
        [Route("GetUnregisteredUsersClient")]
        public IEnumerable<Client> GetUnregisteredUsersClient()
        {
            var users = userManager.Users.ToList();
            var clients = _context.clients.ToList();
            var allclients = _context.clients.ToList();
            foreach (var client in clients)
            {
                foreach (var user in users)
                {
                    if (client.Email == user.Email)
                        allclients.Remove(client);
                }
            }
            return allclients;
        }
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = userManager.FindByIdAsync(id).Result;
            var result=await userManager.DeleteAsync(user);
            if (result.Succeeded)
                return  Ok();
            else
                return  BadRequest();
        }
    }
}
