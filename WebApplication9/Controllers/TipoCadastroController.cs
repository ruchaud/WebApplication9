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
    public class TipoCadastroController : Controller
    {
        private Model1 db = new Model1();

        // GET: TipoCadastro
        public ActionResult Index()
        {
            return View(db.TipoCadastro.ToList());
        }

        // GET: TipoCadastro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCadastro tipoCadastro = db.TipoCadastro.Find(id);
            if (tipoCadastro == null)
            {
                return HttpNotFound();
            }
            return View(tipoCadastro);
        }

        // GET: TipoCadastro/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoCadastro/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,descricao")] TipoCadastro tipoCadastro)
        {
            if (ModelState.IsValid)
            {
                db.TipoCadastro.Add(tipoCadastro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoCadastro);
        }

        // GET: TipoCadastro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCadastro tipoCadastro = db.TipoCadastro.Find(id);
            if (tipoCadastro == null)
            {
                return HttpNotFound();
            }
            return View(tipoCadastro);
        }

        // POST: TipoCadastro/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,descricao")] TipoCadastro tipoCadastro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoCadastro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoCadastro);
        }

        // GET: TipoCadastro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoCadastro tipoCadastro = db.TipoCadastro.Find(id);
            if (tipoCadastro == null)
            {
                return HttpNotFound();
            }
            return View(tipoCadastro);
        }

        // POST: TipoCadastro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoCadastro tipoCadastro = db.TipoCadastro.Find(id);
            db.TipoCadastro.Remove(tipoCadastro);
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
