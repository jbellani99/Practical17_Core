using demo17.Infrasturcture;
using demo17.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

namespace demo17.Controllers
{
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudent _repo;
        public StudentController(ILogger<StudentController> logger, IStudent repostiory)
        {

            _logger = logger;
            _repo = repostiory;

        }
        [Authorize(Roles = "Admin,User")]
        public IActionResult Index()
        {
            var item = _repo.GetAll();
            return View(item);
        }

        public IActionResult Details(int id)
        {
            var item = _repo.GetById(id);
            return View(item);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Students students )
        {
            _repo.StudentAdd(students);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int? id) {

            var item = _repo.GetById((int)id);
            return View(item);

        }
        [HttpPost]
        public ActionResult Edit(Students students) {

            if (ModelState.IsValid) {

                _repo.Update(students);
                return RedirectToAction("Index");
            }
            return View(students);
        }
        [HttpGet]
        public ActionResult Delete(int? id) {

            var item = _repo.GetById((int)id);
            return View(item);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        
        }
    }
}
