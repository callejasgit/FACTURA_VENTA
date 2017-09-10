using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Neg;
using Model.Entity;

namespace WebFacturaMvc.Controllers
{
    public class ModoPagoController : Controller
    {
        private ModoPagoNeg objModoPagoNeg;
        public ModoPagoController()
        {
            objModoPagoNeg = new ModoPagoNeg();
        }
        // GET: ModoPago
        public ActionResult Index()
        {
            List<ModoPago> lista = objModoPagoNeg.findAll();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(ModoPago objModoPago)
        {
            mensajeInicioRegistrar();
            objModoPagoNeg.create(objModoPago);
            MensajeErrorRegistrar(objModoPago);
            return View("Create");
        }
        //mensaje de error
        public void MensajeErrorRegistrar(ModoPago objModoPago)
        {

            switch (objModoPago.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion Insertar";
                    break;
                //case 10://campo codigo vacio
                //    ViewBag.MensajeError = "Ingrese Código del ModoPago";
                //    break;
                //case 100://campo codigo vacio
                //    ViewBag.MensajeError = "Ingrese solo numeros";
                //    break;
                //case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre del ModoPago";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo descripcion vacio
                    ViewBag.MensajeError = "Ingrese Detalles del ModoPago";
                    break;

                case 3://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo detalles";
                    break;

                case 8://error de duplicidad
                    ViewBag.MensajeError = "ModoPago [" + objModoPago.NumPago + "] ya esta Registrada en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "ModoPago [" + objModoPago.Nombre + "] fue Registrado en el Sistema";
                    break;

            }

        }
        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del ModoPago y Click en Guardar";
        }

        public ActionResult Update(int id)
        {
            ModoPago objModoPago = new ModoPago(id);
            objModoPagoNeg.find(objModoPago);
            mensajeInicioActualizar();
            return View(objModoPago);
        }
        [HttpPost]
        public ActionResult Update(ModoPago objModoPago)
        {
            mensajeInicioActualizar();
            objModoPagoNeg.update(objModoPago);
            MensajeErrorActualizar(objModoPago);
            return View();
        }

        //mensaje de error
        public void MensajeErrorActualizar(ModoPago objModoPago)
        {

            switch (objModoPago.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de actualizar";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código del ModoPago";
                    break;
                case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre del ModoPago";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo descripcion vacio
                    ViewBag.MensajeError = "Ingrese Detalles del modo Pago";
                    break;

                case 3://error de precio Unitario
                    ViewBag.MensajeError = "No se permiten mas de 50 caracteres en el campo detalles";
                    break;

                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Datos de la ModoPago [" + objModoPago.NumPago + "] Fueron Actualizados";
                    break;

            }

        }
        public void mensajeInicioActualizar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del ModoPago y Click en Guardar";
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            mensajeInicialEliminar();
            ModoPago objModoPago = new ModoPago(id);
            objModoPagoNeg.find(objModoPago);
            return View(objModoPago);
        }

        [HttpPost]
        public ActionResult Delete(ModoPago objModoPago)
        {
            mensajeInicialEliminar();
            objModoPagoNeg.delete(objModoPago);
            mostrarMensajeEliminar(objModoPago);
            return View();
            //return RedirectToAction("Index");
        }

        //mensaje de error al eliminar
        private void mostrarMensajeEliminar(ModoPago objModoPago)
        {

            switch (objModoPago.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de Eliminar";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "ModoPago [" + objModoPago.NumPago + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "ModoPago: [" + objModoPago.Nombre + "]Ya Fue Eliminada";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar la ModoPago [" + objModoPago.Nombre + "] Tiene  factura asignada!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "ModoPago [" + objModoPago.Nombre + "] Fue Eliminado!!!";
                    break;

                default:
                    ViewBag.MensajeError = "===???===";
                    break;
            }
        }
        public void mensajeInicialEliminar()
        {
            ViewBag.MensajeInicialEliminar = "Formulario de Eliminacion";
        }
        public ActionResult Find(int id)
        {
            ModoPago objModoPago = new ModoPago(id);
            objModoPagoNeg.find(objModoPago);
            //objClienteNeg.find2(objCliente);
            return View(objModoPago);
        }

    }
}