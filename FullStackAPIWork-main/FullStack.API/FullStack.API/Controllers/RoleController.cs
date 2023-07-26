using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace FullStack.API.Controllers
{
    public class RoleController : Controller
    {
        private readonly List<Role> _roles = new List<Role>
        {
            new Role { Id = 1, Name = "admin", CanRead = true, CanWrite = true, CanCreate = true },
            new Role { Id = 2, Name = "user", CanRead = true, CanWrite = false, CanCreate = false },
            // Add other roles as needed
        };

        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetAllRoles()
        {
            return _roles;
        }

        [HttpGet("{id}")]
        public ActionResult<Role> GetRoleById(int id)
        {
            var role = _roles.Find(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }

            return role;
        }
    }
}
