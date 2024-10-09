using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarefa_Testes.Models;

namespace Tarefa_Testes.Controllers
{
    public class TarefasController : Controller
    {
        private dbloginEntities db = new dbloginEntities();

        // GET: Tarefas
        public ActionResult Index()
        {
            var tarefas = db.Tarefas.Include(t => t.StatusTarefa).Include(t => t.Usuario);
            return View(tarefas.ToList());
        }

        // GET: Tarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            ViewBag.Id_estadotarefa = new SelectList(db.StatusTarefa, "Id", "Descricao");
            ViewBag.Id_usuario = new SelectList(db.Usuario, "id", "Nome");
            return View();
        }

        // POST: Tarefas/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Data,Id_usuario,Id_estadotarefa")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                db.Tarefas.Add(tarefas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_estadotarefa = new SelectList(db.StatusTarefa, "Id", "Descricao", tarefas.Id_estadotarefa);
            ViewBag.Id_usuario = new SelectList(db.Usuario, "id", "Nome", tarefas.Id_usuario);
            return View(tarefas);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_estadotarefa = new SelectList(db.StatusTarefa, "Id", "Descricao", tarefas.Id_estadotarefa);
            ViewBag.Id_usuario = new SelectList(db.Usuario, "id", "Nome", tarefas.Id_usuario);
            return View(tarefas);
        }

        // POST: Tarefas/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Data,Id_usuario,Id_estadotarefa")] Tarefas tarefas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_estadotarefa = new SelectList(db.StatusTarefa, "Id", "Descricao", tarefas.Id_estadotarefa);
            ViewBag.Id_usuario = new SelectList(db.Usuario, "id", "Nome", tarefas.Id_usuario);
            return View(tarefas);
        }

        // GET: Tarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefas tarefas = db.Tarefas.Find(id);
            if (tarefas == null)
            {
                return HttpNotFound();
            }
            return View(tarefas);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefas tarefas = db.Tarefas.Find(id);
            db.Tarefas.Remove(tarefas);
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
