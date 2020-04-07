using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaFactura2.Models;

namespace SistemaFactura2.Controllers
{
    public class ClientesController : Controller
    {
        private MantenimientoContext db = new MantenimientoContext();

        // GET: Clientes
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Categoria);
            return View(cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Cliente.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Categoria");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDClientes,RNC,Nombre,Telefono,Email,IDCategoria")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Categoria", clientes.IDCategoria);
            return View(clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Cliente.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Categoria", clientes.IDCategoria);
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDClientes,RNC,Nombre,Telefono,Email,IDCategoria")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDCategoria = new SelectList(db.Categorias, "IDCategoria", "Categoria", clientes.IDCategoria);
            return View(clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clientes clientes = db.Cliente.Find(id);
            if (clientes == null)
            {
                return HttpNotFound();
            }
            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clientes clientes = db.Cliente.Find(id);
            db.Cliente.Remove(clientes);
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
