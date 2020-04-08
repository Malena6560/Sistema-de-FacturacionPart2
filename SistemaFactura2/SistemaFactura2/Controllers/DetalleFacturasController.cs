using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using SistemaFactura2.Models;

namespace SistemaFactura2.Controllers
{
    public class DetalleFacturasController : Controller
    {
        private MantenimientoContext db = new MantenimientoContext();

        // GET: DetalleFacturas
        public ActionResult Index()
        {
            var detalleFacturas = db.DetalleFacturas.Include(d => d.Factura).Include(d => d.Producto);
            return View(detalleFacturas.ToList());
        }

        // GET: DetalleFacturas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        public ActionResult Imprimir()
        {
            var print = new ActionAsPdf("Index");
            return print;
        }

        // GET: DetalleFacturas/Create
        public ActionResult Create()
        {
            ViewBag.IDFactura = new SelectList(db.Facturas, "IDFactura", "IDFactura");
            ViewBag.IDProducto = new SelectList(db.Producto, "IDProductos", "Nombre");
            return View();
        }

        // POST: DetalleFacturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDDetalle,IDFactura,IDProducto,Cantidad,Precio,SubTotal")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.DetalleFacturas.Add(detalleFactura);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDFactura = new SelectList(db.Facturas, "IDFactura", "IDFactura", detalleFactura.IDFactura);
            ViewBag.IDProducto = new SelectList(db.Producto, "IDProductos", "Nombre", detalleFactura.IDProducto);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDFactura = new SelectList(db.Facturas, "IDFactura", "IDFactura", detalleFactura.IDFactura);
            ViewBag.IDProducto = new SelectList(db.Producto, "IDProductos", "Nombre", detalleFactura.IDProducto);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDDetalle,IDFactura,IDProducto,Cantidad,Precio,SubTotal")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalleFactura).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDFactura = new SelectList(db.Facturas, "IDFactura", "IDFactura", detalleFactura.IDFactura);
            ViewBag.IDProducto = new SelectList(db.Producto, "IDProductos", "Nombre", detalleFactura.IDProducto);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            if (detalleFactura == null)
            {
                return HttpNotFound();
            }
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetalleFactura detalleFactura = db.DetalleFacturas.Find(id);
            db.DetalleFacturas.Remove(detalleFactura);
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
