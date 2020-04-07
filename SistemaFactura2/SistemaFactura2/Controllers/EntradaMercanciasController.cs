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
    public class EntradaMercanciasController : Controller
    {
        private MantenimientoContext db = new MantenimientoContext();

        // GET: EntradaMercancias
        public ActionResult Index()
        {
            var entradaMercancias = db.EntradaMercancias.Include(e => e.Producto).Include(e => e.Proveedor);
            return View(entradaMercancias.ToList());
        }

        // GET: EntradaMercancias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMercancia entradaMercancia = db.EntradaMercancias.Find(id);
            if (entradaMercancia == null)
            {
                return HttpNotFound();
            }
            return View(entradaMercancia);
        }

        // GET: EntradaMercancias/Create
        public ActionResult Create()
        {
            ViewBag.IDProducto = new SelectList(db.Producto, "IDProductos", "Nombre");
            ViewBag.IDProveedor = new SelectList(db.Proveedor, "IDProveedores", "Nombre");
            return View();
        }

        // POST: EntradaMercancias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEntrada,IDProducto,Cantidad,IDProveedor,FechaEntrada")] EntradaMercancia entradaMercancia)
        {
            if (ModelState.IsValid)
            {
                db.EntradaMercancias.Add(entradaMercancia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDProducto = new SelectList(db.Producto, "IDProductos", "Nombre", entradaMercancia.IDProducto);
            ViewBag.IDProveedor = new SelectList(db.Proveedor, "IDProveedores", "Nombre", entradaMercancia.IDProveedor);
            return View(entradaMercancia);
        }

        // GET: EntradaMercancias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMercancia entradaMercancia = db.EntradaMercancias.Find(id);
            if (entradaMercancia == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProducto = new SelectList(db.Producto, "IDProductos", "Nombre", entradaMercancia.IDProducto);
            ViewBag.IDProveedor = new SelectList(db.Proveedor, "IDProveedores", "Nombre", entradaMercancia.IDProveedor);
            return View(entradaMercancia);
        }

        // POST: EntradaMercancias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEntrada,IDProducto,Cantidad,IDProveedor,FechaEntrada")] EntradaMercancia entradaMercancia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradaMercancia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDProducto = new SelectList(db.Producto, "IDProductos", "Nombre", entradaMercancia.IDProducto);
            ViewBag.IDProveedor = new SelectList(db.Proveedor, "IDProveedores", "Nombre", entradaMercancia.IDProveedor);
            return View(entradaMercancia);
        }

        // GET: EntradaMercancias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EntradaMercancia entradaMercancia = db.EntradaMercancias.Find(id);
            if (entradaMercancia == null)
            {
                return HttpNotFound();
            }
            return View(entradaMercancia);
        }

        // POST: EntradaMercancias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EntradaMercancia entradaMercancia = db.EntradaMercancias.Find(id);
            db.EntradaMercancias.Remove(entradaMercancia);
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
