using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class BairrosController : Controller
    {
        private Model1 db = new Model1();

        // GET: Bairros
        public ActionResult Index()
        {
            var bairro = db.Bairro.Include(b => b.Cidade);
            return View(bairro.ToList());
        }

        // GET: Bairros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairro.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // GET: Bairros/Create
        public ActionResult Create()
        {
            ViewBag.codigo_cidade = new SelectList(db.Cidade, "codigo", "descricao");
            return View();
        }

        // POST: Bairros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,descricao,codigo_cidade")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Bairro.Add(bairro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_cidade = new SelectList(db.Cidade, "codigo", "descricao", bairro.codigo_cidade);
            return View(bairro);
        }

        // GET: Bairros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairro.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_cidade = new SelectList(db.Cidade, "codigo", "descricao", bairro.codigo_cidade);
            return View(bairro);
        }

        // POST: Bairros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,descricao,codigo_cidade")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bairro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_cidade = new SelectList(db.Cidade, "codigo", "descricao", bairro.codigo_cidade);
            return View(bairro);
        }

        // GET: Bairros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairro bairro = db.Bairro.Find(id);
            if (bairro == null)
            {
                return HttpNotFound();
            }
            return View(bairro);
        }

        // POST: Bairros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bairro bairro = db.Bairro.Find(id);
            db.Bairro.Remove(bairro);
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
