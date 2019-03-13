using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication9.Models;

namespace WebApplication9.Controllers
{
    public class PessoasController : Controller
    {
        private Model1 db = new Model1();


         // GET: Pessoas
        public ActionResult Index(string pesquisaPorNome)
        {
             IQueryable<Pessoa> pessoas;
            
            // Se a caixa de pesquisa por nome não estiver vazia, filtre pessoas pelo nome 
            if (!String.IsNullOrEmpty(pesquisaPorNome))
            {
                // Carrega todas as pessoas do BD
                pessoas = from p in db.Pessoa
                              select p;
                pessoas = pessoas.Where(p => p.nome.Contains(pesquisaPorNome));
                
            }
            else
            {
               pessoas = db.Pessoa.Include(p => p.Posicao).Include(p => p.TipoCadastro);
               
            }

            return View(pessoas.ToList());

        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }

            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            ViewBag.codigo_posicao_parte = new SelectList(db.Posicao, "codigo", "descricao");
            ViewBag.codigo_tipo_cadastro = new SelectList(db.TipoCadastro, "codigo", "descricao");
           
            System.Diagnostics.Debug.WriteLine("create()");

            return View();

        }

        // POST: Pessoas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,nome,data_nascimento,sexo,profissao,nacionalidade,email,pai,mae,data_cadastro,tipo_pessoa,cpf,cnpj,codigo_tipo_cadastro,numero_oab,codigo_posicao_parte")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoa.data_nascimento = Convert.ToDateTime(pessoa.data_nascimento);
                pessoa.data_cadastro = DateTime.Now;
                db.Pessoa.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.codigo_posicao_parte = new SelectList(db.Posicao, "codigo", "descricao", pessoa.codigo_posicao_parte);
            ViewBag.codigo_tipo_cadastro = new SelectList(db.TipoCadastro, "codigo", "descricao", pessoa.codigo_tipo_cadastro);


            System.Diagnostics.Debug.WriteLine("create(xxxx)");

            return View(pessoa);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_posicao_parte = new SelectList(db.Posicao, "codigo", "descricao", pessoa.codigo_posicao_parte);
            ViewBag.codigo_tipo_cadastro = new SelectList(db.TipoCadastro, "codigo", "descricao", pessoa.codigo_tipo_cadastro);

            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,nome,data_nascimento,sexo,profissao,nacionalidade,email,pai,mae,data_cadastro,tipo_pessoa,cpf,cnpj,codigo_tipo_cadastro,numero_oab,codigo_posicao_parte")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_posicao_parte = new SelectList(db.Posicao, "codigo", "descricao", pessoa.codigo_posicao_parte);
            ViewBag.codigo_tipo_cadastro = new SelectList(db.TipoCadastro, "codigo", "descricao", pessoa.codigo_tipo_cadastro);
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa pessoa = db.Pessoa.Find(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = db.Pessoa.Find(id);
            db.Pessoa.Remove(pessoa);
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
