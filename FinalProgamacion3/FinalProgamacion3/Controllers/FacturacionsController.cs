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

namespace FinalProgamacion3.Controllers
{
    public class FacturacionsController : Controller
    {
        private Context db = new Context();

        // GET: Facturacions
        public async Task<ActionResult> Index()
        {
            var facturacion = db.Facturacion.Include(f => f.Cliente);
            return View(await facturacion.ToListAsync());
        }

        // GET: Facturacions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturacion facturacion = await db.Facturacion.FindAsync(id);
            if (facturacion == null)
            {
                return HttpNotFound();
            }
            return View(facturacion);
        }

        // GET: Facturacions/Create
        public ActionResult Create()
        {

            var ventas = db.Ventas.Include(c => c.Cliente).Include(c => c.Productos);

            ViewBag.IDCliente = new SelectList(db.Clientes, "IDCliente", "Cedula");
            return View(ventas.ToList()); 
        }

        // POST: Facturacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDFacturacion,IDClientes,Descuento,,Monto,Fecha")] Facturacion facturacion)
        {
            decimal monto = 0, descuento = 0, sumatoria = 0;

            foreach (var item in db.Ventas.Where(c => c.IDCliente == facturacion.IDClientes))
                sumatoria += item.Cantidad * db.Productos.SingleOrDefault(p => p.Id == item.Id).Precio;

            descuento = facturacion.descuento(sumatoria, db.Clientes.SingleOrDefault(c => c.IDClientes == facturacion.IDClientes).Categoria);
            monto = facturacion.itbis(descuento);

            if (ModelState.IsValid)
            {
                facturacion.Descuento = descuento;
                facturacion.Monto = monto;
                facturacion.Fecha = DateTime.Now;

                db.Facturacion.Add(facturacion);
                db.SaveChanges();
                return RedirectToAction("Index", "Clientes");
            }

            ViewBag.cliente_id = new SelectList(db.Clientes, "IDClientes", "RNC_Cedula", facturacion.IDClientes);
            return View(facturacion);
        }

        // GET: Facturacions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturacion facturacion = await db.Facturacion.FindAsync(id);
            if (facturacion == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDClientes = new SelectList(db.Clientes, "IDClientes", "Nombre", facturacion.IDClientes);
            return View(facturacion);
        }

        // POST: Facturacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IDFacturacion,IDClientes,Descuento,Monto,Fecha")] Facturacion facturacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facturacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IDClientes = new SelectList(db.Clientes, "IDClientes", "Nombre", facturacion.IDClientes);
            return View(facturacion);
        }

        // GET: Facturacions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facturacion facturacion = await db.Facturacion.FindAsync(id);
            if (facturacion == null)
            {
                return HttpNotFound();
            }
            return View(facturacion);
        }

        // POST: Facturacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Facturacion facturacion = await db.Facturacion.FindAsync(id);
            db.Facturacion.Remove(facturacion);
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
