using MaestroD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaestroD.Controllers
{
    public class EquipoController : Controller
    {


        // GET: Equipo / Vista
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            return View(db.Equipos.ToList());
        }

        // Agregar
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Equipo equipo)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new AppDbContext())
                {

                    db.Equipos.Add(equipo);
                    equipo.Estado = true;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agragar ", ex);
                return View();
            }
        }

        // Editar
       public ActionResult Editar(string Id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                  Equipo e   = db.Equipos.Where(a => a.NombreEquipo == Id).FirstOrDefault();
            
                    return View(e);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Equipo e)
        {
            try
            {
               if (!ModelState.IsValid)
                    return View();
                using (var db = new AppDbContext())
                {
                    Equipo equipo = db.Equipos.Find(e.NombreEquipo);
                    equipo.Pais = e.Pais;
                    equipo.Provincia = e.Provincia;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        // Eliminar
        public ActionResult Eliminar(string Id)
        {
            using (var db = new AppDbContext())
            {
                Equipo E = db.Equipos.Find(Id);
                E.Estado = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

        }
    }
}