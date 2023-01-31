using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebEscuelaMVC.Data;
using WebEscuelaMVC.Models;

namespace WebEscuelaMVC.Controllers
{
    public class AulaController : Controller
    {

        private readonly EscuelaDBMVCContext context;

        public AulaController(EscuelaDBMVCContext context)
        {
            this.context = context;

        }
        public IActionResult Index()
        {
            var aulas = context.Aulas.ToList();
            return View(aulas);
        }




        private Aula TraerUna(int id)
        {
            return context.Aulas.Find(id);
        }

        //Create
        [HttpGet]
        public ActionResult Create()
        {

            Aula aula = new Aula();

            return View("Register", aula);

        }


        [HttpPost]
        public ActionResult Create(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Aulas.Add(aula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aula);
        }


        //GetDetails


        [HttpGet]
        public ActionResult Details(int id)
        {
            Aula aula = TraerUna(id);
            if (aula == null)
            {
                return NotFound();
            }
            else
            {
                return View("detalle", aula);
            }


        }


        //Edit

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var aula = TraerUna(id);

            if (aula == null)
            {
                return NotFound();
            }
            else
            {
                return View(aula);
            }
        }



        [HttpPost]
        [ActionName("Edit")]

        public ActionResult EditConfirmed(Aula aula)
        {
            if (ModelState.IsValid)
            {
                context.Entry(aula).State = EntityState.Modified;

                context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                return View(aula);
            }
        }




        //Delete

        [HttpGet]


        public ActionResult Delete(int id)
        {
            var aula = TraerUna(id);

            if (aula == null)
            {
                return NotFound();
            }

            else
            {
                return View("Delete",aula);
            }

        }



        [ActionName("Delete")]
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var aula = TraerUna(id);
            if (aula == null)
            {
                return NotFound();
            }
            else
            {
                context.Aulas.Remove(aula);
                context.SaveChanges();
                return RedirectToAction("Index");
            }

        }
 
    }
}
