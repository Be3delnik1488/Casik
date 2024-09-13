using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{

    [ApiController]
    [Route("player")]
    public class PlayerController : ControllerBase
    {
        
        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new MydbContext();
            return Ok(db.Players);
        }
        [HttpPost]
        public IActionResult Add(Player player)
        {
            var db = new MydbContext();
            db.Set<Player>().Add(player);
            db.SaveChanges();
            return Ok(db.Players);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPlayer(int id)
        {
            var db = new MydbContext();
            List<Player> players = new List<Player>();
            foreach (var p in db.Players)
            {
                players.Add(p);
            }
            Player CurrentPlayer = players.FirstOrDefault(pl => pl.Id == id);
            if (CurrentPlayer == null) return NotFound();
            return Ok(CurrentPlayer);
        }
        [HttpPut]
        public IActionResult Update(Player p)
        {
            var db = new MydbContext();
            db.Set<Player>().Update(p);
            db.SaveChanges();
            return Ok(p);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new MydbContext();
            List<Player> plist = new List<Player>();
            foreach (var p in db.Players)
            {
                plist.Add(p);
            }
            Player CurrentPlayer = plist.FirstOrDefault(u => u.Id == id);
            if (CurrentPlayer == null) return NotFound();
            db.Players.Remove(CurrentPlayer);
            db.SaveChanges();
            return Ok();
        }
    }
}
