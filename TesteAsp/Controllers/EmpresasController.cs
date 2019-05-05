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
    public class EmpresasController : Controller
    {
        private TesteAspContext db = new TesteAspContext();

        // GET: Empresas
        public ActionResult Index()
        {
            return View(db.EmpresasModels.ToList());
        }

        // GET: Empresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresasModel empresasModel = db.EmpresasModels.Find(id);
            if (empresasModel == null)
            {
                return HttpNotFound();
            }
            return View(empresasModel);
        }

        // GET: Empresas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empresa,descricao")] EmpresasModel empresasModel)
        {
            if (ModelState.IsValid)
            {
                db.EmpresasModels.Add(empresasModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresasModel);
        }

        // GET: Empresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresasModel empresasModel = db.EmpresasModels.Find(id);
            if (empresasModel == null)
            {
                return HttpNotFound();
            }
            return View(empresasModel);
        }

        // POST: Empresas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empresa,descricao")] EmpresasModel empresasModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empresasModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empresasModel);
        }

        // GET: Empresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpresasModel empresasModel = db.EmpresasModels.Find(id);
            if (empresasModel == null)
            {
                return HttpNotFound();
            }
            return View(empresasModel);
        }

        // POST: Empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpresasModel empresasModel = db.EmpresasModels.Find(id);
            db.EmpresasModels.Remove(empresasModel);
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
