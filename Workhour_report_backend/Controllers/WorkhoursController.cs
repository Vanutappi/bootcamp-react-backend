using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Workhour_report_backend.Models;

namespace Workhour_report_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkhoursController : ControllerBase
    {
        /*private readonly BootCampContext _context;

        public WorkhoursController(BootCampContext context)
        {
            _context = context;
        }*/
        
        [HttpGet] // nyt vastaa vain GET-komentoihin
        [Route("")]
        //public List<Workhours> GetAll()
        public List<HelperClass> GetAll()
        {

            //private Demo01Entities db = new Demo01Entities();
            //var workhours = db.Workhours.Include(w => w.Employee).Include(w => w.Project);
            //return View(workhours.ToList());

            //northwindContext context = new northwindContext();
            //List<Customers> asiakkaat = context.Customers.ToList();
            //return asiakkaat;
        
            BootCampContext context = new BootCampContext();

            //List<Workhours> tunnit = context.Workhours.ToList();


            var tunnit2 = (from c in context.Workhours
                           join cn in context.Projects on c.ProjectId equals cn.ProjectId
                           join ct in context.Employees on c.EmployeeId equals ct.EmployeeId

                           select new
                                {
                                WorkhourId = c.WorkhourId,
                                EmployeeId = c.EmployeeId,
                                ProjectId = c.ProjectId,
                                Date = c.Date,
                                Hours = c.Hours,
                                EmployeeName = ct.EmployeeName,
                                ProjectName = cn.ProjectName
                                });

            List<HelperClass> tunnit3 = new List<HelperClass>();

            foreach (var item in tunnit2)
            {
                HelperClass data = new HelperClass();
                data.WorkhourId = item.WorkhourId;
                data.EmployeeId = item.EmployeeId;
                data.ProjectId = item.ProjectId;
                data.Date = item.Date;
                data.Hours = item.Hours;
                data.EmployeeName = item.EmployeeName;
                data.ProjectName = item.ProjectName;
                tunnit3.Add(data);
            }

            

            //string json = JsonConvert.SerializeObject(tunnit2);

            //return Json(json, JsonRequestBehavior.AllowGet);
            return tunnit3;

            //public int WorkhourId { get; set; }
            //public int? EmployeeId { get; set; }
            //public int? ProjectId { get; set; }
            //public DateTime? Date { get; set; }
            //public int? Hours { get; set; }

            //public Employees Employee { get; set; }
            //public Projects Project { get; set; }
            //List<Workhours> tunnit = context.Workhours.Include(d => d.Employee).Include(d => d.Project).ToList();

            //Console.WriteLine(tunnit);


        }
        
        // GET: api/Workhours
        /*[HttpGet]
        [Route("")]
        public IEnumerable<Workhours> GetWorkhours()
        {
            return _context.Workhours;
        }*/

        //// GET: api/Workhours/5
        //[HttpGet]
        //[Route("{id}")]
        //public async Task<IActionResult> GetWorkhours([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var workhours = await _context.Workhours.FindAsync(id);

        //    if (workhours == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(workhours);
        //}

        //// PUT: api/Workhours/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWorkhours([FromRoute] int id, [FromBody] Workhours workhours)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != workhours.WorkhourId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(workhours).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!WorkhoursExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Workhours
        //[HttpPost]
        //public async Task<IActionResult> PostWorkhours([FromBody] Workhours workhours)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Workhours.Add(workhours);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetWorkhours", new { id = workhours.WorkhourId }, workhours);
        //}

        //// DELETE: api/Workhours/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteWorkhours([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var workhours = await _context.Workhours.FindAsync(id);
        //    if (workhours == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Workhours.Remove(workhours);
        //    await _context.SaveChangesAsync();

        //    return Ok(workhours);
        //}

        //private bool WorkhoursExists(int id)
        //{
        //    return _context.Workhours.Any(e => e.WorkhourId == id);
        //}
    }
}