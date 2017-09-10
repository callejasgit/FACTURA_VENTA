using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace WebFacturaMvc.Controllers
{
    public class VentaController : Controller
    {
        private VentaNeg objVentaNeg;
        private ClienteNeg objClienteNeg;
        private ProductoNeg objProductoNeg;
        private ModoPagoNeg objModoPagoNeg;
        private FacturaNeg objFacturaNeg;
        private DetalleVentaNeg objDetalleVentaNeg;
        public VentaController()
        {
            objVentaNeg = new VentaNeg();
            objClienteNeg = new ClienteNeg();
            objProductoNeg = new ProductoNeg();
            objModoPagoNeg = new ModoPagoNeg();
            objFacturaNeg = new FacturaNeg();
            objDetalleVentaNeg = new DetalleVentaNeg();
        }
        [HttpGet]
        public ActionResult ObtenerClientes()
        {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }

        [HttpPost]//para buscar clientes
        public ActionResult ObtenerClientes(string txtnombre, string txtappaterno, string txtdni, long txtcliente = -1)
        {
            if (txtnombre == "")
            {
                txtnombre = "-1";
            }
            if (txtappaterno == "")
            {
                txtappaterno = "-1";
            }
            if (txtdni == "")
            {
                txtdni = "-1";
            }
            Cliente objCliente = new Cliente();
            objCliente.Nombre = txtnombre;
            objCliente.IdCliente = txtcliente;
            objCliente.Appaterno = txtappaterno;
            objCliente.Dni = txtdni;

            List<Cliente> cliente = objClienteNeg.findAllClientes(objCliente);
            return View(cliente);
        }
       
        [HttpPost]
        public ActionResult Seleccionar(string idProducto)
        {
            Producto objProducto = new Producto(idProducto);
            objProductoNeg.find(objProducto);            
            return Json(objProducto, JsonRequestBehavior.AllowGet);
            
        }     
        public ActionResult PruebaJson()
        {  // escribir la url directa  para ver el formato      
            List<Producto>lista=objProductoNeg.findAll();
            return Json(lista, JsonRequestBehavior.AllowGet);

        }

        public void cargarProductocmb()
        {
            List<Producto> data = objProductoNeg.findAll();
            SelectList lista = new SelectList(data, "idProducto", "nombre");
            ViewBag.ListaProducto = lista;
        }
        public void cargarModoPagocmb()
        {
            List<ModoPago> data = objModoPagoNeg.findAll();
            SelectList lista = new SelectList(data, "numPago", "nombre");
            ViewBag.ListaModoPago = lista;
        }

        public ActionResult NuevaVenta()
        {
            cargarModoPagocmb();
            cargarProductocmb();
            return View();
        }
        [HttpPost]
        public ActionResult GuardarVenta(string Fecha, string modoPago,string IdCliente,string Total, List<DetalleVenta> ListadoDetalle)
        {
            string mensaje = "";
            double iva = 18;           
            string idVendedor = "32";
            int codigoPago = 0;
            long codigoCliente = 0;
            double total = 0;

            if (Fecha == "" || modoPago == "" || IdCliente == "" || Total == "")
            {
                if (Fecha == "") mensaje = "ERROR EN EL CAMPO FECHA";
                if (modoPago == "") mensaje = "SELECCIONE UN MODO DE PAGO";
                if (IdCliente == "") mensaje = "ERROR CON EL CODIGO DEL CLIENTE";
                if (Total == "") mensaje = "ERROR EN EL CAMPO TOTAL";
            }
            else
            {
                codigoPago = Convert.ToInt32(modoPago);
                codigoCliente = Convert.ToInt64(IdCliente);
                total = Convert.ToDouble(Total);

                //REGISTRO DE VENTA
                Venta objVenta = new Venta(total, codigoCliente, idVendedor, Fecha, iva);
                string codigoVenta = objVentaNeg.create(objVenta);
                if (codigoVenta == "" || codigoVenta == null)
                {
                    mensaje = "ERROR AL REGISTRAR LA VENTA";
                }else
                {
                    Session["idVenta"] = codigoVenta;
                    //REGISTRO DE FACTURA
                    Factura objFactura = new Factura(Fecha, iva, total, codigoPago);
                    string codigoFactura = objFacturaNeg.create(objFactura);
                    if(codigoFactura == "" || codigoFactura == null)
                    {
                            mensaje = "ERROR AL REGISTRAR LA FACTURA";
                    }
                    else
                    {
                        
                        foreach (var data in ListadoDetalle)
                        {
                            string idProducto = data.IdProducto.ToString();
                            int cantidad = Convert.ToInt32(data.Cantidad.ToString());
                            double descuento = Convert.ToDouble(data.Descuento.ToString());
                            double subtotal = Convert.ToDouble(data.SubTotal.ToString());
                            DetalleVenta objDetalleVenta = new DetalleVenta(Convert.ToInt64(codigoFactura), Convert.ToInt64(codigoVenta), idProducto, subtotal,descuento, cantidad);
                            objDetalleVentaNeg.create(objDetalleVenta);

                        }
                        mensaje = "VENTA GUARDADA CON EXITO...";
                    }
                }
                
            }
            
            return Json(mensaje);
        }

        public ActionResult reporteActual()
        {
            if (Session["idVenta"].ToString() != null)
            {
                string idVenta = Session["idVenta"].ToString();
                return Redirect("~/Reportes/frmReporteFactura.aspx?IdVenta="+ idVenta);
            }
            else
            {
                return View ("GuardarVenta");
            }
            
        }

        public ActionResult ReporteVentas()
        {
            List<Venta> lista = objVentaNeg.findAll();
            return View(lista);
        }

        public ActionResult DetallesVenta(long id)
        {
            DetalleVenta objDetalleVenta = new DetalleVenta();
            objDetalleVenta.IdVenta = id;
            List<DetalleVenta> lista = objDetalleVentaNeg.detallesPorIdVenta(objDetalleVenta);
            return View(lista);
        }

       public ActionResult VentaFactura()
        {
            List<Venta> lista = objVentaNeg.findAll();
            return View(lista);
        }

    }
}