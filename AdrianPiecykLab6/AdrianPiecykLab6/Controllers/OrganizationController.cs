using AdrianPiecykLab6.DataAccess;
using AdrianPiecykLab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdrianPiecykLab6.Controllers
{
    [Route("student")]
    public class OrganizationController : ApiController
    {
        /// <summary>
        /// GET api/<controller>, czyli wyswietlanie Studentow
        /// </summary>
        /// <returns></returns>
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            using (var ctx = new ContactDbContext())
            {
                var orgs = ctx.Students.Include("Courses").ToList();
                return orgs;
            }
        }
        /// <summary>
        /// Wyswietlanie studentow po Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("student/{id}")]
        public Student Get(int id)
        {
            using (var ctx = new ContactDbContext())
            {
                var student = ctx.Students.Single(x => x.Id == id);       
                return student;
            }
  
        }
        /// <summary>
        /// Dodawanie nowego studenta
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("student")]
        public IHttpActionResult Post([FromBody]Student student)
        {
            using (var ctx = new ContactDbContext())
            {
                ctx.Students.Add(student);
                ctx.SaveChanges();
            }

            return Ok();
        }
        /// <summary>
        /// Usuwanie studenta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("student/{id}")]
        public IHttpActionResult Delete(int id)
        {
            using (var ctx = new ContactDbContext())
            {
                var student = ctx.Students.Single(x => x.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                ctx.Students.Remove(student);
                ctx.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }
        /// <summary>
        /// Edytowanie Studenta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("student/{id}")]
        public IHttpActionResult Put(int id,[FromBody]Student student)
        {
            using (var ctx = new ContactDbContext())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var stud = ctx.Students.Single(x => x.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                stud.Name = student.Name;
                stud.Surname = student.Surname;
                stud.DateOfBirth = student.DateOfBirth;
                ctx.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);

            }

        }

        /// <summary>
        /// Wyswietlanie kursow na jakie jest dany student zapisany
        /// </summary>
        /// <param name="stdId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("student/{stdId}/courses")]
        public List<Course> GetCourses([FromUri]long stdId)
        {
            using (var ctx = new ContactDbContext())
            {
                List<Course> list = new List<Course>();
                var student = ctx.Students.Single(x => x.Id == stdId);
                foreach(var course in student.Courses)
                {
                    
                    list.Add(course);
                    
                }

                return list;
            }


        }
        /// <summary>
        /// Dodawanie Studenta na kurs i automatycznie dodawaie kursu do bazy
        /// </summary>
        /// <param name="stdId"></param>
        /// <param name="course"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("student/{stdId}/courses")]
        public IHttpActionResult AddCourse([FromUri]int stdId, [FromBody]Course course)
        {
            using (var ctx = new ContactDbContext())
            {
                var student = ctx.Students.SingleOrDefault(x => x.Id == stdId);
                student.Courses.Add(course);
                if(student!=null)
                {
                   
                    ctx.SaveChanges();
                }
                
            }
            return Ok();
        }
      

    }
}
