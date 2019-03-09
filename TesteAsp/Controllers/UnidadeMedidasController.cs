using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteAsp.Models;

namespace TesteAsp.Controllers
{
    public class UnidadeMedidasController : Controller
    {
        private TesteAspContext db = new TesteAspContext();

        // GET: UnidadeMedidas
        public ActionResult Index()
        {
            return View(db.UnidadeMedidas.ToList());
        }

        // GET: UnidadeMedidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedidas.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadeMedidas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UMid,unidade,descricao")] UnidadeMedida unidadeMedida)
        {
            if (ModelState.IsValid)
            {
                db.UnidadeMedidas.Add(unidadeMedida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedidas.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // POST: UnidadeMedidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UMid,unidade,descricao")] UnidadeMedida unidadeMedida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadeMedida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidadeMedida);
        }

        // GET: UnidadeMedidas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeMedida unidadeMedida = db.UnidadeMedidas.Find(id);
            if (unidadeMedida == null)
            {
                return HttpNotFound();
            }
            return View(unidadeMedida);
        }

        // POST: UnidadeMedidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UnidadeMedida unidadeMedida = db.UnidadeMedidas.Find(id);
            db.UnidadeMedidas.Remove(unidadeMedida);
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
