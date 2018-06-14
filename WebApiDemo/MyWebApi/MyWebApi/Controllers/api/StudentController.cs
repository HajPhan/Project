using MyWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApi.Controllers
{
    public class StudentController : ApiController
    {
        //public IHttpActionResult GetAllStudents(bool includeAddress = false)
        //{
        //    IList<StudentViewModel> students = null;
        //    using (var ctx = new SchoolEntities())
        //    {
        //        students = ctx.Students.Include("StudentAddress")
        //                                .Select(s => new StudentViewModel()
        //                                {
        //                                    Id = s.StudentId,
        //                                    FirstName = s.FirstName,
        //                                    LastName = s.LastName
        //                                }).ToList<StudentViewModel>();
        //    }

        //    if (students.Count == 0)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(students);
        //}

        public IHttpActionResult GetAllStudentsWithAddress(bool includeAddress = false)
        {
            IList<StudentViewModel> students = null;

            using (var ctx = new SchoolEntities())
            {
                students = ctx.Students.Include("StudentAddress").Select(x => new StudentViewModel()
                {
                    Id = x.StudentId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,

                    Address = x.StudentAdress == null || includeAddress == false ? null : new AddressViewModel()
                    {
                        StudentId = x.StudentAdress.StudentId,
                        Address1 = x.StudentAdress.Address1,
                        Address2 = x.StudentAdress.Address2,
                        City = x.StudentAdress.City,
                        State = x.StudentAdress.Sate
                    }

                    
                }).ToList<StudentViewModel>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult GetStudentById(int id)
        {
            StudentViewModel student = null;

            using (var ctx = new SchoolEntities())
            {
                student = ctx.Students.Include("StudentAddress")
                                       .Where(s => s.StudentId == id)
                                       .Select(s => new StudentViewModel()
                                       {
                                           Id = s.StudentId,
                                           FirstName = s.FirstName,
                                           LastName = s.LastName
                                       }).FirstOrDefault<StudentViewModel>();
            }

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        public IHttpActionResult GetAllStudents(string name)
        {
            IList<StudentViewModel> students = null;

            using (var ctx = new SchoolEntities())
            {
                students = ctx.Students.Include("StudentAddress")
                                        .Where(s => s.FirstName.ToLower() == name.ToLower())
                                        .Select(s => new StudentViewModel()
                                        {
                                            Id = s.StudentId,
                                            FirstName = s.FirstName,
                                            LastName = s.LastName,
                                            Address = s.StudentAdress == null ? null : new AddressViewModel()
                                            {
                                                StudentId = s.StudentAdress.StudentId,
                                                Address1 = s.StudentAdress.Address1,
                                                Address2 = s.StudentAdress.Address2,
                                                City = s.StudentAdress.City,
                                                State = s.StudentAdress.Sate
                                            }
                                        }).ToList<StudentViewModel>();
            }

            if(students.Count == 0)
            {
                return NotFound();
            }
            return Ok(students);
        }

        public IHttpActionResult GetAllStudentsInSameStandard(int standarId)
        {
            IList<StudentViewModel> students = null;

            using (var ctx = new SchoolEntities())
            {
                students = ctx.Students.Include("StudentAddress").Include("Standard").Where(s => s.StandardId == standarId)
                                        .Select(s => new StudentViewModel()
                                        {
                                            Id = s.StudentId,
                                            FirstName = s.FirstName,
                                            LastName = s.LastName,
                                            Address = s.StudentAdress == null ? null : new AddressViewModel()
                                            {
                                                StudentId = s.StudentAdress.StudentId,
                                                Address1 = s.StudentAdress.Address1,
                                                Address2 = s.StudentAdress.Address2,
                                                City = s.StudentAdress.City,
                                                State = s.StudentAdress.Sate
                                            }
                                            //Standard = new StandardViewModel()
                                            //{
                                            //    StandardtId = s.sta
                                            //    StandardName =
                                            //}
                                        }).ToList<StudentViewModel>();
            }

            if(students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        public IHttpActionResult PostNewStudent(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            using (var ctx = new SchoolEntities())
            {
                ctx.Students.Add(new Student()
                {
                    StudentId = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName
                });

                ctx.SaveChanges();
                
            }

            return Ok();
        }

        public IHttpActionResult Put(StudentViewModel student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not a valid model");
            }

            using (var ctx = new SchoolEntities())
            {
                var exitstingStudent = ctx.Students.Where(s => s.StudentId == student.Id).FirstOrDefault<Student>();

                if(exitstingStudent != null)
                {
                    exitstingStudent.FirstName = student.FirstName;
                    exitstingStudent.LastName = student.LastName;

                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Not a valid student id");
            }

            using (var ctx = new SchoolEntities())
            {
                var student = ctx.Students
                    .Where(s => s.StudentId == id)
                    .FirstOrDefault();

                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }

            return Ok();
        }

        // DELETE
        
    }
}
