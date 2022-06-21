using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaCrudNew.Models;

namespace PruebaCrudNew.Controllers
{
    public class EstudianteController : Controller
    {
        // GET: Estudiante
        public ActionResult Index()
        {
            List<EstudianteCLS> estudiante = null;
            using (var bd = new PruebaCrudNewEntities())
            {
                estudiante =(from Estudiante in bd.Estudiante
                            where Estudiante.BHABILITADO == 1
                            select new EstudianteCLS
                            {
                                IdEstudiante = Estudiante.IDESTUDIANTE,
                                Nombre = Estudiante.NOMBRE,
                                Apellido = Estudiante.APELLIDO,
                                Edad = Estudiante.EDAD,
                                Dirección = Estudiante.DIRECCION
                            }).ToList();
            }
            return View(estudiante);
        }
        public ActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Agregar(EstudianteCLS estudiante)
        {
            if (!ModelState.IsValid)
            {
                return View(estudiante);
            }
            using (var bd = new PruebaCrudNewEntities())
            {
                Estudiante oEstudiante = new Estudiante();
                oEstudiante.IDESTUDIANTE = estudiante.IdEstudiante;
                oEstudiante.NOMBRE = estudiante.Nombre;
                oEstudiante.APELLIDO = estudiante.Apellido;
                oEstudiante.EDAD = estudiante.Edad;
                oEstudiante.DIRECCION = estudiante.Dirección;
                oEstudiante.BHABILITADO = 1;
                bd.Estudiante.Add(oEstudiante);
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Editar(int id)
        {
            EstudianteCLS oEstudiante = new EstudianteCLS();
            using (var bd = new PruebaCrudNewEntities())
            {
                Estudiante estudiante = bd.Estudiante.Where(p => p.IDESTUDIANTE.Equals(id)).First();
                oEstudiante.IdEstudiante = estudiante.IDESTUDIANTE;
                oEstudiante.Nombre = estudiante.NOMBRE;
                oEstudiante.Apellido = estudiante.APELLIDO;
                oEstudiante.Edad= estudiante.EDAD;
                oEstudiante.Dirección = estudiante.DIRECCION;
            }
            return View(oEstudiante);
        }
        [HttpPost]
        public ActionResult Editar(EstudianteCLS editEstudiante)
        {
            if (!ModelState.IsValid)
            {
                return View(editEstudiante);
            }
            int Estudiante = editEstudiante.IdEstudiante;
            using (var bd = new PruebaCrudNewEntities() )
            {
                Estudiante oEstudiante = bd.Estudiante.Where(p => p.IDESTUDIANTE.Equals(Estudiante)).First();
                oEstudiante.IDESTUDIANTE = editEstudiante.IdEstudiante;
                oEstudiante.NOMBRE = editEstudiante.Nombre;
                oEstudiante.APELLIDO = editEstudiante.Apellido;
                oEstudiante.EDAD = editEstudiante.Edad;
                oEstudiante.DIRECCION = editEstudiante.Dirección;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Eliminar(int id)
        {
            using (var bd = new PruebaCrudNewEntities())
            {
                Estudiante oEstudiante = bd.Estudiante.Where(p=>p.IDESTUDIANTE.Equals(id)).First();
                oEstudiante.BHABILITADO = 0;
                bd.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}