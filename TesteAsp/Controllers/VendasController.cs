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
    public class VendasController : Controller
    {
        private TesteAspContext db = new TesteAspContext();

        // GET: Vendas
        public ActionResult Index()
        {
            return View(db.VendasModels.ToList());
        }

        // GET: Vendas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendasModel vendasModel = db.VendasModels.Find(id);
            if (vendasModel == null)
            {
                return HttpNotFound();
            }
            return View(vendasModel);
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_venda,cod_produto,qtd")] VendasModel vendasModel)
        {
            if (ModelState.IsValid)
            {

                var estoque = db.Estoques.Where(s => s.produtoId == vendasModel.cod_produto).FirstOrDefault();
                estoque.quantidade -= (float)vendasModel.qtd;

                db.VendasModels.Add(vendasModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vendasModel);
        }

        // GET: Vendas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendasModel vendasModel = db.VendasModels.Find(id);
            if (vendasModel == null)
            {
                return HttpNotFound();
            }
            return View(vendasModel);
        }

        // POST: Vendas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_venda,cod_produto,qtd")] VendasModel vendasModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendasModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vendasModel);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendasModel vendasModel = db.VendasModels.Find(id);
            if (vendasModel == null)
            {
                return HttpNotFound();
            }
            return View(vendasModel);
        }

        public ActionResult GerarVendas()
        {

            VendasModel venda;
            Random random = new Random();
            List<VendasModel> lista = new List<VendasModel>();


            for(int i = 0; i < 3965215; i++)
            {
                venda = new VendasModel()
                {
                    cod_produto = random.Next(1, 6),
                    cod_empresa = random.Next(1, 5),
                    qtd = random.Next(1,1000)                    
                };

                lista.Add(venda);
                //db.VendasModels.Add(venda);
            }

            db.BulkInsert(lista);

            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public class ViewLastChild {

            public string empresa { get; set; }

            public int cod_venda { get; set; }

            public int cod_produto { get; set; }

            public double qtd { get; set; }
        }


        public ActionResult getLastChild()
        {
            List<ViewLastChild> listView = new List<ViewLastChild>();

           

            var result = db.VendasModels.OrderByDescending(c => c.cod_venda)
                .GroupBy(s => s.cod_empresa)
                .Select(s => s.GroupBy(x => x.cod_produto)
                .Select(f => f.Select(v => v).OrderByDescending(g => g.cod_venda).FirstOrDefault())
                              
                ).ToList();

            foreach(var r in result)
            {
                var query = r.Select(s => new ViewLastChild()
                {
                    cod_produto = s.cod_produto,
                    cod_venda = s.cod_venda,
                    empresa = s.Empresas.descricao,
                    qtd = s.qtd

                }).ToList();

                listView.AddRange(query);
            }



            return View(listView.OrderBy(s => s.cod_produto).OrderBy(x => x.empresa).AsQueryable());
        }


        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendasModel vendasModel = db.VendasModels.Find(id);
            db.VendasModels.Remove(vendasModel);
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
