using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TesteAsp.Classes;
using TesteAsp.Models;

namespace TesteAsp.Controllers
{
    public class EstoqueController : Controller
    {
        private TesteAspContext db = new TesteAspContext();

        // GET: Estoque
        public ActionResult Index()
        {
            var estoques = db.Estoques.Include(e => e.ProdEstoque);
            return View(estoques.ToList());
        }

        // GET: Estoque/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // GET: Estoque/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            ViewBag.produtoId = new SelectList(db.Produtoes, "id", "descricao", estoque.produtoId);
            return View(estoque);
        }

        // POST: Estoque/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "estoqueId,quantidade")] Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                Estoque temp = db.Estoques.Single(x => x.estoqueId.Equals(estoque.estoqueId));
                temp.quantidade = estoque.quantidade;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.produtoId = new SelectList(db.Produtoes, "id", "descricao", estoque.produtoId);
            return View(estoque);
        }

        // GET: Estoque/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estoque estoque = db.Estoques.Find(id);
            if (estoque == null)
            {
                return HttpNotFound();
            }
            return View(estoque);
        }

        // POST: Estoque/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estoque estoque = db.Estoques.Find(id);
            db.Estoques.Remove(estoque);
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
