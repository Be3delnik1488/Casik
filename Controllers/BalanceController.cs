using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{

    [ApiController]
    [Route("balance")]
    public class BalanceController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllBalance()
        {
            var db = new MydbContext();
            return Ok(db.Balances);
        }
        [HttpPost]
        public IActionResult Add(Balance Balances)
        {
            var db = new MydbContext();
            db.Set<Balance>().Add(Balances);
            db.SaveChanges();
            return Ok(db.Balances);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetBalance(int id)
        {
            var db = new MydbContext();
            List<Balance> blist = new List<Balance>();
            foreach (var b in db.Balances)
            {
                blist.Add(b);
            }
            Balance CurrentBalance = blist.FirstOrDefault(pl => pl.Id == id);
            if (CurrentBalance == null) return NotFound();
            return Ok(CurrentBalance);
        }
        [HttpPut]
        public IActionResult Update(Balance b)
        {
            var db = new MydbContext();
            db.Set<Balance>().Update(b);
            db.SaveChanges();
            return Ok(b);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new MydbContext();
            List<Balance> blist = new List<Balance>();
            foreach (var b in db.Balances)
            {
                blist.Add(b);
            }
            Balance CurrentBalance = blist.FirstOrDefault(u => u.Id == id);
            if (CurrentBalance == null) return NotFound();
            db.Balances.Remove(CurrentBalance);
            db.SaveChanges();
            return Ok();
        }
    }
}
