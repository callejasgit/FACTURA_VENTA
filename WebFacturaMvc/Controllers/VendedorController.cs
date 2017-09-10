using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Neg;
using Model.Entity;

namespace WebFacturaMvc.Controllers
{
    public class VendedorController : Controller
    {
        private VendedorNeg objVendedorNeg;
        public VendedorController()
        {
            objVendedorNeg = new VendedorNeg();
        }
        // GET: Vendedor
        public ActionResult Index()
        {
            List<Vendedor> lista = objVendedorNeg.findAll();
            return View(lista);
        }
        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vendedor objVendedor)
        {
            mensajeInicioRegistrar();
            objVendedorNeg.create(objVendedor);
            MensajeErrorRegistrar(objVendedor);
            return View("Create");
        }

        public void MensajeErrorRegistrar(Vendedor objVendedor)
        {

            switch (objVendedor.Estado)
            {
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código del Vendedor";
                    break;
                case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre del Vendedor";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido Paterno del Vendedor";
                    break;

                case 3://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apPaterno";
                    break;

                case 40://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido Materno del Vendedor";
                    break;

                case 4://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apMaterno";
                    break;

                case 50://campo dni vacio
                    ViewBag.MensajeError = "Ingrese DNI del Vendedor";
                    break;
                case 5://error de dni
                    ViewBag.MensajeError = "No se permiten mas de 8 caracteres en el campo DNI";
                    break;                
                case 60://campo telefono vacio
                    ViewBag.MensajeError = "Ingrese Telefóno del Cliente";
                    break;
                case 6://error de direccion
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en al campo Teléfono";
                    break;
                case 7://error de duplicidad
                    ViewBag.MensajeError = "Vendedor [" + objVendedor.IdVendedor + "] ya esta Registrado en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Vendedor [" + objVendedor.IdVendedor + "] fue Registrado en el Sistema";
                    break;
            }

        }

        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del Cliente y Click en Guardar";
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            mensajeInicioUpdate();
            Vendedor objVendedor = new Vendedor(id);
            objVendedorNeg.find(objVendedor);
            return View(objVendedor);
        }
        [HttpPost]
        public ActionResult Update(Vendedor objVendedor)
        {
            mensajeInicioUpdate();
            objVendedorNeg.update(objVendedor);
            MensajeErrorUpdate(objVendedor);
            return View();
            //return Redirect("~/Cliente/Index/");
        }

        public void MensajeErrorUpdate(Vendedor objVendedor)
        {

            switch (objVendedor.Estado)
            {
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código del Vendedor";
                    break;
                case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre del Vendedor";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido Paterno del Vendedor";
                    break;

                case 3://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apPaterno";
                    break;

                case 40://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido Materno del Vendedor";
                    break;

                case 4://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apMaterno";
                    break;

                case 50://campo dni vacio
                    ViewBag.MensajeError = "Ingrese DNI del Vendedor";
                    break;
                case 5://error de dni
                    ViewBag.MensajeError = "No se permiten mas de 8 caracteres en el campo DNI";
                    break;
                case 60://campo telefono vacio
                    ViewBag.MensajeError = "Ingrese Telefóno del Cliente";
                    break;
                case 6://error de direccion
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en al campo Teléfono";
                    break;                
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Vendedor [" + objVendedor.IdVendedor + "] fue Registrado en el Sistema";
                    break;
            }

        }

        public void mensajeInicioUpdate()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del Cliente y Click en Guardar";
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            mensajeInicialEliminar();
            Vendedor objVendedor = new Vendedor(id);
            objVendedorNeg.find(objVendedor);
            return View(objVendedor);
        }


        [HttpPost]
        public ActionResult Delete(Vendedor objVendedor)
        {
            mensajeInicialEliminar();            
            objVendedorNeg.delete(objVendedor);
            mostrarMensajeErrorEliminar(objVendedor);
            return View(objVendedor);
        }
        private void mostrarMensajeErrorEliminar(Vendedor objVendedor)
        {

            switch (objVendedor.Estado)
            {
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Vendedor [" + objVendedor.IdVendedor + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "El Vendedor: [" + objVendedor.Appaterno + " " + objVendedor.Apmaterno + ", " + objVendedor.Nombre + " ]ya Fue Eliminado";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar al Vendedor [" + objVendedor.Appaterno + " " + objVendedor.Apmaterno + ", " + objVendedor.Nombre + "] Tiene Ventas Registrados en el Sistema!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Cliente [" + objVendedor.Appaterno + " " + objVendedor.Apmaterno + ", " + objVendedor.Nombre + "] Fue Eliminado!!!";
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

        public ActionResult Find(string id)
        {
            Vendedor objVendedor = new Vendedor(id);
            objVendedorNeg.find(objVendedor);
            //objClienteNeg.find2(objCliente);
            return View(objVendedor);
        }
    }
}