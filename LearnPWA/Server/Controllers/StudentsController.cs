using LearnPWA.Shared;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LearnPWA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppContext _db;

        public StudentsController(AppContext db)
        {
            _db = db;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public ActionResult<IEnumerable<Student>> Get()
        {
            return _db.Students.ToList();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return _db.Students.Find(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] Student model)
        {
            _db.Students.Add(model);
            _db.SaveChanges();
            return Ok();
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Student model)
        {
            Student student = _db.Students.Find(id);
            student.Name = model.Name;
            _db.Students.Update(student);
            _db.SaveChanges();
            return Ok();
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Student student = _db.Students.Find(id);
            _db.Students.Remove(student);
            _db.SaveChanges();
            return Ok();
        }
    }
}
