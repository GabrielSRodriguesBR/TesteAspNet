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
    public class ProdutoController : Controller
    {
        private TesteAspContext db = new TesteAspContext();

        //Busca produto
        public ActionResult searchProd(string desc)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var prod = db.Produtoes.Where(p => p.descricao.Contains(desc));
            prod = db.Produtoes.Include(p => p.Tipo).Where(p => p.descricao.Contains(desc));
            return View("Index",prod.ToList());
        }


        // GET: Produto
        public ActionResult Index()
        {
            var produtoes = db.Produtoes.Include(p => p.Tipo);
            return View(produtoes.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.TipoId = new SelectList(db.Tipoes, "TipoId", "Descricao");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,descricao,TipoId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Estoques.Add(new Estoque {
                    quantidade = 0,
                    produtoId = produto.id
                });
                db.Produtoes.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoId = new SelectList(db.Tipoes, "TipoId", "Descricao", produto.TipoId);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoId = new SelectList(db.Tipoes, "TipoId", "Descricao", produto.TipoId);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,descricao,TipoId")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoId = new SelectList(db.Tipoes, "TipoId", "Descricao", produto.TipoId);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtoes.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtoes.Find(id);
            db.Produtoes.Remove(produto);
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
