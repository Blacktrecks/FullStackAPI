﻿using FullStack.API.Data;
using FullStack.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FullStack.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;
        public UsersController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        /* Get ALL Utilizatori */

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _fullStackDbContext.USers.ToListAsync();

            return Ok(users);
        }

        //Ziua 7: Search Useri
    
       [HttpGet("search")]
       public async Task<IActionResult> SearchUsers([FromQuery] string keyword)
       {
        var users = await _fullStackDbContext.USers
            .Where(e => e.Name.Contains(keyword))
            .ToListAsync();

        return Ok(users);
        }

    /* Post Utilizatori */

    [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User userRequest)
        {
            userRequest.Id = Guid.NewGuid();

            await _fullStackDbContext.USers.AddAsync(userRequest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(userRequest);

        }

        /* Get 1 Utilizator */

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var user = await _fullStackDbContext.USers.FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        /* PUT Utilizator */

        [HttpPut]
        //ID user
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, User updateUserRequest)
        {
            //Corespondenta angajatului cu datele din baza de date
            var user = await _fullStackDbContext.USers.FindAsync(id);
            //Verifca daca user e null
            if (user == null)
            {
                return NotFound();
            }

            //Modifica date user

            user.Name = updateUserRequest.Name;
            user.Email = updateUserRequest.Email;
            user.Password = updateUserRequest.Password;

            //Actualizarea in baza date a modificarilor
            await _fullStackDbContext.SaveChangesAsync();


            //Returneaza status
            return Ok(user);

        }

        //STERGERE UTILIZATOR

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _fullStackDbContext.USers.FindAsync(id);

            //check daca user e null
            if (user == null)
            {
                return NotFound();
            }

            //Sterge utilizator din BD
            _fullStackDbContext.USers.Remove(user);
            await _fullStackDbContext.SaveChangesAsync();

            //Returnare status
            return Ok(user);
        }

        /*Logare User */

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> GetUserId(string email,string password)
        {
            var user = await _fullStackDbContext.USers.FirstOrDefaultAsync(x => (x.Email== email && x.Password == password));

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}