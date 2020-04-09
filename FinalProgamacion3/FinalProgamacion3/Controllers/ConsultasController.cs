using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProgamacion3.Models;
using System.Data.Entity;



namespace FinalProgamacion3.Controllers
{
    public class ConsultasController : Controller
    {
        private Context db = new Context();
        private Entradas entradas = new Entradas();
        private Facturacion facturacion = new Facturacion();
        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Productos(string query)
        {
            if (!string.IsNullOrEmpty(query))
                return View(db.Productos.Where(p => p.Nombre == query));

            return View(db.Productos.ToList());
        }
        public ActionResult Clientes(string query, string seleccion, string opcion)
        {
            if (!string.IsNullOrEmpty(query))
            {
                if (opcion.Equals("0"))
                    return View(db.Clientes.Where(p => p.Nombre == query));
                else
                {
                    if (seleccion.Equals("0"))
                        return View(db.Clientes.ToList());
                    else if (seleccion.Equals("1"))
                        return View(db.Clientes.Where(c => c.Categoria == "premium"));
                    else
                        return View(db.Clientes.Where(c => c.Categoria == "regular"));
                }
            }

            if (!string.IsNullOrEmpty(seleccion))
            {
                if (seleccion.Equals("0"))
                    return View(db.Clientes.ToList());
                else if (seleccion.Equals("1"))
                    return View(db.Clientes.Where(c => c.Categoria == "premium"));
                else
                    return View(db.Clientes.Where(c => c.Categoria == "regular"));
            }

            return View(db.Clientes.ToList());
        }

        public ActionResult Proveedores(string query, string seleccion)
        {
            if (!string.IsNullOrEmpty(query))
            {
                if (seleccion.Equals("0"))
                    return View(db.Proveedores.Where(p => p.Nombre == query));
                else
                    return View(db.Proveedores.Where(p => p.Email == query));
            }

            return View(db.Proveedores.ToList());
        }
        public ActionResult Entradas(string query, string seleccion, string opcion)
        {
            var filtroProducto = db.Entradas.Where(e => e.Productos.Nombre == query);
            var filtroFecha = db.Entradas.Where(e => e.Fecha.Value.Day == 12);
            var filtroProveedor = db.Entradas.Where(e => e.Proveedores.Nombre == query);

            if (!string.IsNullOrEmpty(query))
            {
                if (seleccion.Equals("0"))
                {
                    if (opcion.Equals("0"))
                    {
                        ViewBag.sumatoria = entradas.sumatoria(filtroProducto.ToList());
                        ViewBag.promedio = entradas.promedio(filtroProducto.ToList());
                        ViewBag.conteo = entradas.conteo(filtroProducto.ToList());
                    }

                    return View(filtroProducto);
                }
                else if (seleccion.Equals("1"))
                {
                    if (opcion.Equals("0"))
                    {
                        ViewBag.sumatoria = entradas.sumatoria(filtroFecha.ToList());
                        ViewBag.promedio = entradas.promedio(filtroFecha.ToList());
                        ViewBag.conteo = entradas.conteo(filtroFecha.ToList());
                    }

                    return View(filtroFecha);
                }
                else
                {
                    if (opcion.Equals("0"))
                    {
                        ViewBag.sumatoria = entradas.sumatoria(filtroProveedor.ToList());
                        ViewBag.promedio = entradas.promedio(filtroProveedor.ToList());
                        ViewBag.conteo = entradas.conteo(filtroProveedor.ToList());
                    }

                    return View(filtroProveedor);
                }
            }

            return View(db.Entradas.ToList());
        }
        public ActionResult Facturaciones(string query, string seleccion, string opcion)
        {
            var filtroFecha = db.Facturacion.Where(f => f.Fecha.Value.Day == 12);
            var filtroCliente = db.Facturacion.Where(f => f.Cliente.Nombre == query);

            if (!string.IsNullOrEmpty(query))
            {
                if (seleccion.Equals("0"))
                {
                    if (opcion.Equals("0"))
                    {
                        ViewBag.sumatoria = facturacion.sumatoria(filtroCliente.ToList());
                        ViewBag.promedio = facturacion.promedio(filtroCliente.ToList());
                        ViewBag.conteo = facturacion.conteo(filtroCliente.ToList());
                        ViewBag.min = facturacion.valorMinimo(filtroCliente.ToList());
                        ViewBag.max = facturacion.valorMaximo(filtroCliente.ToList());
                    }

                    return View(filtroCliente);
                }
                else if (seleccion.Equals("1"))
                {
                    if (opcion.Equals("0"))
                    {
                        ViewBag.sumatoria = facturacion.sumatoria(filtroFecha.ToList());
                        ViewBag.promedio = facturacion.promedio(filtroFecha.ToList());
                        ViewBag.conteo = facturacion.conteo(filtroFecha.ToList());
                        ViewBag.min = facturacion.valorMinimo(filtroFecha.ToList());
                        ViewBag.max = facturacion.valorMaximo(filtroFecha.ToList());
                    }

                    return View(filtroFecha);
                }
            }

            return View(db.Facturacion.ToList());
        }

     
    }
}
