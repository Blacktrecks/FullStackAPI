using FullStack.API.Data;
using FullStack.API.Migrations;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace FullStack.API.Controllers
{
    public class AvatarController : Controller
    {

        private readonly FullStackDbContext _fullStackDbContext;
        public AvatarController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

    }
}