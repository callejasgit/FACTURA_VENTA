using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFacturaMvc.Controllers
{
    public class DetalleVentaController : Controller
    {
        private DetalleVentaNeg objDetalleVentaNeg;
        private FacturaNeg objFacturaNeg;
        private VentaNeg objVentaNeg;
        public DetalleVentaController()
        {
            objDetalleVentaNeg = new DetalleVentaNeg();
            objFacturaNeg = new FacturaNeg();
            objVentaNeg = new VentaNeg();
        }
        // GET: DetalleVenta
        public ActionResult Index()
        {
            List<DetalleVenta> lista = objDetalleVentaNeg.findAll();
            return View(lista);
        }

        public ActionResult Eliminar(long idVenta,long idFactura)
        {
            DetalleVenta objDetalleVenta = new DetalleVenta();
            objDetalleVenta.IdVenta = idVenta;
            objDetalleVenta.NumFacura = idFactura;
            objDetalleVentaNeg.delete(objDetalleVenta);
            //eliminar venta
            Venta objVenta = new Venta(idVenta);
            objVentaNeg.delete(objVenta);

            //eliminar factura
            Factura objFactura = new Factura(idFactura);
            objFacturaNeg.delete(objFactura);

            return View();
        }
    }
}