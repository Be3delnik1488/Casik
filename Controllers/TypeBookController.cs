using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{

    [ApiController]
    [Route("TypeBook")]
    public class TypeBookController : ControllerBase
    {

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new MydbContext();
            return Ok(db.TypeBooks);
        }
        [HttpPost]
        public IActionResult Add(TypeBook tb)
        {
            var db = new MydbContext();
            db.Set<TypeBook>().Add(tb);
            db.SaveChanges();
            return Ok(db.TypeBooks);
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPlayer(int id)
        {
            var db = new MydbContext();
            List<TypeBook> tbl = new List<TypeBook>();
            foreach (var tb in db.TypeBooks)
            {
                tbl.Add(tb);
            }
            TypeBook CurrentBook = tbl.FirstOrDefault(tb => tb.Id == id);
            if (CurrentBook == null) return NotFound();
            return Ok(CurrentBook);
        }
        [HttpPut]
        public IActionResult Update(TypeBook tb)
        {
            var db = new MydbContext();
            db.Set<TypeBook>().Update(tb);
            db.SaveChanges();
            return Ok(tb);
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var db = new MydbContext();
            List<TypeBook> tbl = new List<TypeBook>();
            foreach (var tb in db.TypeBooks)
            {
                tbl.Add(tb);
            }
            TypeBook CurrentBook = tbl.FirstOrDefault(tb => tb.Id == id);
            if (CurrentBook == null) return NotFound();
            db.TypeBooks.Remove(CurrentBook);
            db.SaveChanges();
            return Ok();
        }
    }
}
