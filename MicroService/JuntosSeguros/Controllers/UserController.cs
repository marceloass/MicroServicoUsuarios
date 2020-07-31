using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using JuntosSeguros.Database;
using JuntosSeguros.Database.Models;
using JuntosSeguros.Repository;
using JuntosSeguros.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace JuntosSeguros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        DatabaseContext db;
        public UserController()
        {
            db = new DatabaseContext();
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public bool Post([FromRoute] User value)
        {
            try
            {
                if (value != null)
                {
                    db.Users.Add(value);
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromRoute] User value)
        {
            var user = db.Users.FirstOrDefault(x => x.UserId == id);

            if (user != null)
            {
                user.Name = value.Name;
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var user = db.Users.FirstOrDefault(x => x.UserId == id);

            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            else
                return false;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public dynamic Authenticate([FromBody] User model)
        {
            var user = UserRepository.Read(1);

            if (user == null)
                return NotFound(new { message = "Email não encontrado"});

            var token = TokenService.GenerateToken(user);
            user.Token = token;
            user.Password = "202020"; //Troca de Password quando usuário autenticado, senão default do db.
            db.Users.Add(user);

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
