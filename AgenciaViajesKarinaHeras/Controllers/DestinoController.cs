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
  
    public class DestinoController : Controller
    {
        private Context db = new Context();

        // GET: Destino

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

            var destino = from d in db.Destino select d;

            if (!string.IsNullOrEmpty(searchString))
            {
                destino = destino.Where(d => d.Pais.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    destino = destino.OrderByDescending(d => d.Pais);
                    break;
                default:
                    destino = destino.OrderBy(d => d.Pais);
                    break;

            }

            int pageSize = 3; /*numero de viajeros por pagina*/
            int pageNumber = page ?? 1; /*si no tiene nada el buscador poner en la pagina 1*/
            //return View(viajero);
            return View(destino.ToPagedList(pageNumber, pageSize));
            //return View(db.Destino.ToList());
        }
        
        // GET: Destino/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }
        // GET: Destino/Create
        public ActionResult Create()
        {
            return View();
        }
      
        // POST: Destino/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DestinoID,CodigoViaje,ViajeroId,Ciudad,Pais")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Destino.Add(destino);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destino);
        }
        [Authorize(Roles = "Admin")]
        // GET: Destino/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }
     
        // POST: Destino/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DestinoID,CodigoViaje,ViajeroId,Ciudad,Pais")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destino).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destino);
        }
        [Authorize(Roles = "Admin")]
        // GET: Destino/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destino destino = db.Destino.Find(id);
            if (destino == null)
            {
                return HttpNotFound();
            }
            return View(destino);
        }
        [Authorize(Roles = "Admin")]
        // POST: Destino/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destino destino = db.Destino.Find(id);
            db.Destino.Remove(destino);
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
