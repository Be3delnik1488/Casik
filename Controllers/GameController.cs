using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{

    [ApiController]
    [Route("Game")]
    public class GameController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGame()
        {
            var db = new MydbContext();
            return Ok(db.Games);
        }
        [HttpPost]
        public IActionResult Add(Game g)
        {
            var db = new MydbContext();
            db.Set<Game>().Add(g);
            db.SaveChanges();
            return Ok(db.Games);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDealer(int id)
        {
            var db = new MydbContext();
            List<Game> dlist = new List<Game>();
            foreach (var g in db.Games)
            {
                dlist.Add(g);
            }
            Game CurrentGame = dlist.FirstOrDefault(pl => pl.Id == id);
            if (CurrentGame == null) return NotFound();
            return Ok(CurrentGame);
        }
        [HttpPut]
        public IActionResult Update(Game g)
        {
            var db = new MydbContext();
            db.Set<Game>().Update(g);
            db.SaveChanges();
            return Ok(g);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new MydbContext();
            List<Game> dlist = new List<Game>();
            foreach (var b in db.Games)
            {
                dlist.Add(b);
            }
            Game CurrentGame = dlist.FirstOrDefault(u => u.Id == id);
            if (CurrentGame == null) return NotFound();
            db.Games.Remove(CurrentGame);
            db.SaveChanges();
            return Ok();
        }
    }
}
