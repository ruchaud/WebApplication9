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

namespace WebApplication8.Controllers
{
    public class EnderecosController : Controller
    {
        private Model1 db = new Model1();
     
        // GET: Enderecos
        public ActionResult Index(int? id)
        {
            IQueryable<Endereco> enderecos;

            //Se a origem do acesso foi da listagem de pessoas, obtém o codigo da pessoa (id) e filtra os dados
            if (id != null)
            {
                enderecos = from e in db.Endereco
                          select e;
                enderecos = enderecos.Where(e => e.codigo_pessoa == id);
              
                Session["codigo_pessoa_select"] = id;
               
            }
            else
            {
                int codpessoa = Convert.ToInt32(Session["codigo_pessoa_select"]);
                enderecos = from e in db.Endereco
                            select e;
                enderecos = enderecos.Where(e => e.codigo_pessoa == codpessoa);
                //Session["codigo_pessoa_select"] = null;
               
                System.Diagnostics.Debug.WriteLine("sem codigo pessoa"+ codpessoa);
              //  enderecos = db.Endereco.Include(e => e.Bairro).Include(e => e.Pessoa).Include(e => e.Cidade).Include(e => e.Estado);

            }
           

            return View(enderecos.ToList());

        }



        // GET: Enderecos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }


        // GET: Enderecos/Create
        public ActionResult Create(int? codigo)
        {
            ViewBag.codigo_bairro = new SelectList(db.Bairro, "codigo", "descricao");
            ViewBag.codigo_cidade = new SelectList(db.Cidade, "codigo", "descricao");
            ViewBag.codigo_estado = new SelectList(db.Estado, "codigo", "descricao");
            if (Session["codigo_pessoa_select"] != null)
            {
                System.Diagnostics.Debug.WriteLine("create - codigo pessoa"+ Session["codigo_pessoa_select"]);
                ViewBag.codigo_pessoa = new SelectList(db.Pessoa, "codigo", "nome", Session["codigo_pessoa_select"]);
               
            }
            else
            {
                ViewBag.codigo_pessoa = new SelectList(db.Pessoa, "codigo", "nome");

            }
           
            return View();
        }

        // POST: Enderecos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigo,rua,numero,cep,complemento,telefone_residencial,telefone_celular,tipo_endereco,codigo_bairro,codigo_pessoa,codigo_cidade,codigo_estado")] Endereco endereco)
        {
            System.Diagnostics.Debug.WriteLine("create(xxxx)");
            if (ModelState.IsValid)
            {
                db.Endereco.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_bairro = new SelectList(db.Bairro, "codigo", "descricao", endereco.codigo_bairro);
            ViewBag.codigo_pessoa = new SelectList(db.Pessoa, "codigo", "nome", endereco.codigo_pessoa);
            ViewBag.codigo_cidade = new SelectList(db.Cidade, "codigo", "descricao", endereco.codigo_cidade);
            ViewBag.codigo_estado = new SelectList(db.Estado, "codigo", "descricao", endereco.codigo_estado);

            return View(endereco);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_bairro = new SelectList(db.Bairro, "codigo", "descricao", endereco.codigo_bairro);
            ViewBag.codigo_pessoa = new SelectList(db.Pessoa, "codigo", "nome", endereco.codigo_pessoa);
            ViewBag.codigo_cidade = new SelectList(db.Cidade, "codigo", "descricao", endereco.codigo_cidade);
            ViewBag.codigo_estado = new SelectList(db.Estado, "codigo", "descricao", endereco.codigo_estado);
            return View(endereco);
        }

        // POST: Enderecos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigo,rua,numero,cep,complemento,telefone_residencial,telefone_celular,tipo_endereco,codigo_bairro,codigo_pessoa,codigo_cidade,codigo_estado")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_bairro = new SelectList(db.Bairro, "codigo", "descricao", endereco.codigo_bairro);
            ViewBag.codigo_pessoa = new SelectList(db.Pessoa, "codigo", "nome", endereco.codigo_pessoa);
            ViewBag.codigo_cidade = new SelectList(db.Cidade, "codigo", "descricao", endereco.codigo_cidade);
            ViewBag.codigo_estado = new SelectList(db.Estado, "codigo", "descricao", endereco.codigo_estado);
            return View(endereco);
        }

        // GET: Enderecos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Endereco endereco = db.Endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Endereco endereco = db.Endereco.Find(id);
            db.Endereco.Remove(endereco);
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

        public ActionResult GetCidadesPorEstado(int estadoId)
        {

            db.Configuration.ProxyCreationEnabled = false;
        
            return Json(db.Cidade.ToList().Where(cids => cids.codigo_estado == estadoId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBairrosPorCidade(int cidadeId)
        {

            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Bairro.ToList().Where(br => br.codigo_cidade == cidadeId), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetPessoa(int cod)
        {

            System.Diagnostics.Debug.WriteLine("entrou no if");
            int codPessoaselect = Convert.ToInt32(ViewBag.codigo_pessoa_select);
            db.Configuration.ProxyCreationEnabled = false;
            return Json(db.Pessoa.ToList().Where(br => br.codigo == codPessoaselect), JsonRequestBehavior.AllowGet);
        }
    }
}
