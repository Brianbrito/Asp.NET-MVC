using MaestroD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaestroD.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador  / Vista
        public ActionResult Index()
        {
            AppDbContext db = new AppDbContext();
            return View(db.Jugadors.ToList());
        }

        // Agregar
        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Jugador jugador)
        {
            if (!ModelState.IsValid)
               return View();

            try
            {
                using (var db = new AppDbContext())
                {
                   
                    db.Jugadors.Add(jugador);
                    jugador.Estado = true;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error al agregar ", ex);
                return View();
            }
        }

        // Editar
        public ActionResult Editar(int? Id)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                   Jugador j = db.Jugadors.Where(b => b.JugadorId == Id).FirstOrDefault();

                    return View(j);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Jugador j)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View();
                using (var db = new AppDbContext())
                {
                    Jugador jugador = db.Jugadors.Find(j.JugadorId);
                    jugador.Nombre = j.Nombre;
                    jugador.Apellido = j.Apellido;
                    jugador.Posicion = j.Posicion;
                    jugador.NombreEquipo = j.NombreEquipo;
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
        public ActionResult Eliminar(int Id)
        {
            using (var db = new AppDbContext())
            {
                Jugador j = db.Jugadors.Find(Id);
                j.Estado = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}