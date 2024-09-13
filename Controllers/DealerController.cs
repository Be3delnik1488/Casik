using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{

    [ApiController]
    [Route("Dealer")]
    public class DealerController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllDealer()
        {
            var db = new MydbContext();
            return Ok(db.Dealers);
        }
        [HttpPost]
        public IActionResult Add(Dealer d)
        {
            var db = new MydbContext();
            db.Set<Dealer>().Add(d);
            db.SaveChanges();
            return Ok(db.Dealers);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetDealer(int id)
        {
            var db = new MydbContext();
            List<Dealer> dlist = new List<Dealer>();
            foreach (var d in db.Dealers)
            {
                dlist.Add(d);
            }
            Dealer CurrentDealer = dlist.FirstOrDefault(pl => pl.Id == id);
            if (CurrentDealer == null) return NotFound();
            return Ok(CurrentDealer);
        }
        [HttpPut]
        public IActionResult Update(Dealer b)
        {
            var db = new MydbContext();
            db.Set<Dealer>().Update(b);
            db.SaveChanges();
            return Ok(b);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new MydbContext();
            List<Dealer> dlist = new List<Dealer>();
            foreach (var b in db.Dealers)
            {
                dlist.Add(b);
            }
            Dealer CurrentDealer = dlist.FirstOrDefault(u => u.Id == id);
            if (CurrentDealer == null) return NotFound();
            db.Dealers.Remove(CurrentDealer);
            db.SaveChanges();
            return Ok();
        }
    }
}
