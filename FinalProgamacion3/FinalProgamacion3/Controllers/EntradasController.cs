using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProgamacion3.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProgamacion3.Controllers
{
    public class EntradasController : Controller
    {
        private Context db = new Context();

        // GET: Entradas
        public async Task<ActionResult> Index()
        {
            var entradas = db.Entradas.Include(e => e.Proveedores);
            return View(await entradas.ToListAsync());
        }

        // GET: Entradas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entradas entradas = await db.Entradas.FindAsync(id);
            if (entradas == null)
            {
                return HttpNotFound();
            }
            return View(entradas);
        }

        // GET: Entradas/Create
        public ActionResult Create()
        {
            ViewBag.IDProveedores = new SelectList(db.Proveedores, "IDProveedores", "Nombre");
            return View();
        }

        // POST: Entradas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IDEntradas,Fecha,Cantidad,IDProductos,IDProveedores")] Entradas entradas)
        {
            var existenciaStock = db.Stocks.SingleOrDefault(s => s.IDProductos == entradas.IDProductos);

            if (ModelState.IsValid)
            {
                if (existenciaStock != null)
                    db.Stocks.SingleOrDefault(s => s.IDStock == existenciaStock.IDStock).Cantidad += entradas.Cantidad;

                else
                    db.Stocks.Add(new Stock()
                    {
                        Cantidad = entradas.Cantidad,
                        IDProductos = entradas.IDProductos

                    });
                entradas.Fecha = DateTime.Now;
                db.Entradas.Add(entradas);
                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            ViewBag.IDProveedores = new SelectList(db.Proveedores, "IDProveedores", "Nombre", entradas.IDProveedores);
            ViewBag.IDProducto = new SelectList(db.Productos, "IDProductos", "Nombre", entradas.IDProductos);
            return View(entradas);
        }

        // GET: Entradas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entradas entradas = await db.Entradas.FindAsync(id);
            if (entradas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDProveedores = new SelectList(db.Proveedores, "IDProveedores", "Nombre", entradas.IDProveedores);
            return View(entradas);
        }

        // POST: Entradas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDEntradas,Fecha,Cantidad,IDProductos,IDProveedores")] Entradas entradas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entradas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDProveedores = new SelectList(db.Proveedores, "IDProveedores", "Nombre", entradas.IDProveedores);
            return View(entradas);
        }

        // GET: Entradas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entradas entradas = await db.Entradas.FindAsync(id);
            if (entradas == null)
            {
                return HttpNotFound();
            }
            return View(entradas);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Entradas entradas = await db.Entradas.FindAsync(id);
            db.Entradas.Remove(entradas);
            await db.SaveChangesAsync();
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
