using Microsoft.AspNetCore.Mvc;
using Tempo_Backend.Data;
using Tempo_Backend.Models;
using Tempo_Backend.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Tempo_Backend.Authorization;
namespace Tempo_Backend.Controllers

{
    [Route("Tempo/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            // Console.WriteLine("tregsdvgbsjdskd0");
            // return (IEnumerable<User>)TodoItems.GetUsers();
            return _context.users;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        public ActionResult<User> GetById(int id)
        {
            var commandItems = _context.users.Find(id);
            if (commandItems == null)
            {

                return NotFound();
            }
            return commandItems;
        }
        [HttpPost("create")]
        public ActionResult<User> CreateUser([FromBody] User item)
        {
            if (item == null)
            {
                return BadRequest();
            }
            // CreatePasswordHash(item.Password, out byte[] passwordHash, out byte[] passwordSalt);
            // item.Password = Encoding.UTF8.GetString(passwordHash, 0, passwordHash.Length);

            var hash = SecurePasswordHasher.Hash(item.Password);
            item.Password = hash;
            var user = _context.users.Add(item);

            _context.SaveChanges();
            return Ok("User Register Successfully");
        }

        [HttpPost("login")]
        public ActionResult<User> Login(LoginDto requst)
        {
            // const User = _context.users.fi
            var query = (from p in _context.users
                         where p.Email == requst.Email
                         select p);
            var professor = query.ToList();

            Console.WriteLine(professor);
            Console.WriteLine();
            return Ok();
        }



        [HttpPut("{id}")]
        public ActionResult<User> Update(int id, User item)
        {
            var commandItems = _context.users.Find(id);
            if (id != commandItems.Id)
            {
                return BadRequest();
            }
            commandItems.Email = item.Email;
            commandItems.LastName = item.LastName;
            commandItems.FirstName = item.FirstName;
            _context.Entry(commandItems).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var user = _context.users.Find(id);
            if (user == null)
            {
                return NotFound();

            }
            _context.users.Remove(user);
            _context.SaveChanges();
            return user;



        }




    }
}