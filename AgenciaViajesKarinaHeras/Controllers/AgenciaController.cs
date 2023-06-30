using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgenciaViajesKarinaHeras.DbContext;
using AgenciaViajesKarinaHeras.Models;
using PagedList;

namespace AgenciaViajesKarinaHeras.Controllers
{
    public class AgenciaController : Controller
    {
        private Context db = new Context();

        // GET: Agencia
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParam = string.IsNullOrEmpty(sortOrder) ? "role_dec" : "";
            ViewBag.DateSortParam = sortOrder == "Date" ? "data_desc" : "";

            if (searchString != null) /*con esto queremos decir que situamos al usuario en la primera pagina si no hay nada en el buscador*/
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.currentFilter = searchString; /*esto es para que mantega lo que pusiste en el buscador al pasar de pagina*/

            var agencias = from a in db.Agencia select a;

            if (!string.IsNullOrEmpty(searchString)) /*aqui "filtramos/buscamos" por el appelido*/
            {
                agencias = agencias.Where(a => a.Role.Equals(searchString) || a.FechaViaje.Equals(searchString));
            }

            switch (sortOrder)
            {
                case "role_dec":
                    agencias = agencias.OrderByDescending(a => a.Role);
                    break;
                case "Date":
                    agencias = agencias.OrderBy(a => a.FechaViaje);
                    break;
                case "data_desc":
                    agencias = agencias.OrderByDescending(a => a.FechaViaje);
                    break;
                default:
                    agencias = agencias.OrderBy(a => a.Role);
                    break;

            }


            int pageSize = 3;
            int pageNumber = page ?? 1;

            return View(agencias.ToPagedList(pageNumber, pageSize)); /**/

            //return View(db.Agencia.ToList());
        }


        // GET: Agencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // GET: Agencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agencia/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AgenciaId,CodigoViaje,Precio,FechaViaje,Role")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Agencia.Add(agencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agencia);
        }
        [Authorize(Roles = "Admin")]
        // GET: Agencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: Agencia/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AgenciaId,CodigoViaje,Precio,FechaViaje,Role")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agencia);
        }
        [Authorize(Roles = "Admin")]
        // GET: Agencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencia.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: Agencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agencia agencia = db.Agencia.Find(id);
            db.Agencia.Remove(agencia);
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
