using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using AgenciaViajesKarinaHeras.DbContext;
using AgenciaViajesKarinaHeras.Models;
using PagedList;

namespace AgenciaViajesKarinaHeras.Controllers
{
    
    public class ViajeroesController : Controller
    {

        private Context db = new Context();
        // GET: Viajeroes
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.SortOrder = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.currentFilter = searchString;

            var viajero = from v in db.Viajero select v;

            if (!string.IsNullOrEmpty(searchString))
            {
                viajero = viajero.Where(v => v.Nombre.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    viajero = viajero.OrderByDescending(v => v.Nombre);
                    break;
                default:
                    viajero = viajero.OrderBy(v => v.Nombre);
                    break;

            }

            int pageSize = 3; /*numero de viajeros por pagina*/
            int pageNumber = page ?? 1; /*si no tiene nada el buscador poner en la pagina 1*/
            //return View(viajero);
            return View(viajero.ToPagedList(pageNumber, pageSize)); ;
        }
   
        // GET: Viajeroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajero viajero = db.Viajero.Find(id);
            if (viajero == null)
            {
                return HttpNotFound();
            }
            return View(viajero);
        }
        [Authorize(Roles = "Admin")]
        //[Authorize(Roles = "Admin, Viajero,Creater,Editor, Delete")]
        // GET: Viajeroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Viajeroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdViajero,Dni,Nombre,Telefono,FechaNacimiento")] Viajero viajero)
        {
            if (ModelState.IsValid)
            {
                db.Viajero.Add(viajero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viajero);
        }
        [Authorize(Roles = "Admin")]
        // GET: Viajeroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajero viajero = db.Viajero.Find(id);
            if (viajero == null)
            {
                return HttpNotFound();
            }
            return View(viajero);
        }
      
        // POST: Viajeroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdViajero,Dni,Nombre,Telefono,FechaNacimiento")] Viajero viajero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viajero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viajero);
        }
        [Authorize(Roles = "Admin")]
        // GET: Viajeroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Viajero viajero = db.Viajero.Find(id);
            if (viajero == null)
            {
                return HttpNotFound();
            }
            return View(viajero);
        }
        [Authorize(Roles = "Admin")]
        // POST: Viajeroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Viajero viajero = db.Viajero.Find(id);
            db.Viajero.Remove(viajero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
