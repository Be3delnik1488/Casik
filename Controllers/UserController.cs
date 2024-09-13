using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{

    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        //static List<User> users = new List<User>();
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new MydbContext();
            return Ok(db.Users);
        }
        [HttpPost]
        public IActionResult Add(User user)
        {
            var db = new MydbContext();
            db.Set<User>().Add(user);
            db.SaveChanges();
            return Ok(db.Users);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetUser(int id)
        {
            var db = new MydbContext();
            List<User> users = new List<User>();
            foreach (var user in db.Users)
            {
                users.Add(user);
            }
            User CurrentUser = users.FirstOrDefault(u => u.Id == id);
            if (CurrentUser == null) return NotFound();
            return Ok(CurrentUser);
        }
        [HttpPut]
        public IActionResult Update(User user)
        {
            var db = new MydbContext();
            db.Set<User>().Update(user);
            db.SaveChanges();
            return Ok(user);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new MydbContext();
            List<User> users = new List<User>();
            foreach (var user in db.Users)
            {
                users.Add(user);
            }
            User CurrentUser = users.FirstOrDefault(u => u.Id == id);
            if (CurrentUser == null) return NotFound();
            db.Users.Remove(CurrentUser);
            db.SaveChanges();
            return Ok();
        }
        [HttpPost]
        [Route("{auth}")]
        public IActionResult Auth(User user)
        {
            var db = new MydbContext();
            List<User> users = new List<User>();
            foreach (var user1 in db.Users)
            {
                users.Add(user1);
            }
            User CurrentUser = users.FirstOrDefault(n => n.Login == user.Login && n.Password == user.Password);
            if (CurrentUser == null) return Forbid();
            return Ok();
        }
    }
}
