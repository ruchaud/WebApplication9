﻿using System;
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
    public class PosicaoController : Controller
    {
        private Model1 db = new Model1();

        // GET: Posicao
        public ActionResult Index()
        {
            return View(db.Posicao.ToList());
        }

        // GET: Posicao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicao posicao = db.Posicao.Find(id);
            if (posicao == null)
            {
                return HttpNotFound();
            }
            return View(posicao);
        }

        // GET: Posicao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posicao/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,descricao")] Posicao posicao)
        {
            if (ModelState.IsValid)
            {
                db.Posicao.Add(posicao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posicao);
        }

        // GET: Posicao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicao posicao = db.Posicao.Find(id);
            if (posicao == null)
            {
                return HttpNotFound();
            }
            return View(posicao);
        }

        // POST: Posicao/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,descricao")] Posicao posicao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posicao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posicao);
        }

        // GET: Posicao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicao posicao = db.Posicao.Find(id);
            if (posicao == null)
            {
                return HttpNotFound();
            }
            return View(posicao);
        }

        // POST: Posicao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posicao posicao = db.Posicao.Find(id);
            db.Posicao.Remove(posicao);
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
