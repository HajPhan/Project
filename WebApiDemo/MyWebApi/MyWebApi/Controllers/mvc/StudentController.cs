using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MyWebApi.Models;

namespace MyWebApi.Controllers.mvc
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            IEnumerable<StudentViewModel> students = null;

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53370/api/");

                // HTTP GET
                var responseTask = client.GetAsync("student");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<StudentViewModel>>();
                    readTask.Wait();

                    students = readTask.Result;
                }
                else    // web api sent error response
                {
                    // log response status here.

                    students = Enumerable.Empty<StudentViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administractor.");
                }
            }

            return View(students);
        }

        public ActionResult create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult create(StudentViewModel student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53370/api/student");

                // HTTP POST
                var postTask = client.PostAsJsonAsync<StudentViewModel>("student", student);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administractor.");

            return View(student);
        }


        // Edit
        public ActionResult Edit(int id)
        {
            StudentViewModel student = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53370/api/");

                // HTTP GET
                var responseTask = client.GetAsync("student?id=" + id.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<StudentViewModel>();
                    readTask.Wait();

                    student = readTask.Result;
                }
            }

            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(StudentViewModel student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53370/api/student");

                // HTTP POST
                var putTask = client.PutAsJsonAsync<StudentViewModel>("student", student);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(student);
        }

        // Delete
        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53370/api/");

                // HTTP DELETE
                var deleteTask = client.DeleteAsync("student/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}