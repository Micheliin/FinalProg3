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
    public class CategoriascsController : Controller
    {
        private Context db = new Context();

        // GET: Categoriascs
        public async Task<ActionResult> Index()
        {
            return View(await db.Categoriascs.ToListAsync());
        }

        // GET: Categoriascs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoriascs categoriascs = await db.Categoriascs.FindAsync(id);
            if (categoriascs == null)
            {
                return HttpNotFound();
            }
            return View(categoriascs);
        }

        // GET: Categoriascs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoriascs/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdCategoriascs,Descripcion")] Categoriascs categoriascs)
        {
            if (ModelState.IsValid)
            {
                db.Categoriascs.Add(categoriascs);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoriascs);
        }

        // GET: Categoriascs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoriascs categoriascs = await db.Categoriascs.FindAsync(id);
            if (categoriascs == null)
            {
                return HttpNotFound();
            }
            return View(categoriascs);
        }

        // POST: Categoriascs/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdCategoriascs,Descripcion")] Categoriascs categoriascs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriascs).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoriascs);
        }

        // GET: Categoriascs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoriascs categoriascs = await db.Categoriascs.FindAsync(id);
            if (categoriascs == null)
            {
                return HttpNotFound();
            }
            return View(categoriascs);
        }

        // POST: Categoriascs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Categoriascs categoriascs = await db.Categoriascs.FindAsync(id);
            db.Categoriascs.Remove(categoriascs);
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
