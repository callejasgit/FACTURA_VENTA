using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Neg;
using Model.Entity;

namespace WebFacturaMvc.Controllers
{
    public class ClienteController : Controller
    {
        ClienteNeg objClienteNeg;
        public ClienteController()
        {
            objClienteNeg = new ClienteNeg();
        }
        // GET: Cliente
        public ActionResult Index()
        {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cliente objCliente)
        {
            mensajeInicioRegistrar();
            objClienteNeg.create(objCliente);
            MensajeErrorRegistrar(objCliente);
            ModelState.Clear();
            return View("Create");
        }

        //mensaje de error
        public void MensajeErrorRegistrar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {
                //case 10://campo codigo vacio
                //    ViewBag.MensajeError = "Ingrese Código del Cliente";
                //    break;
                //case 1://error campo cadigo
                //    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                //    break;
                case 1000://campo nombre vacio
                    ViewBag.MensajeError = "Error DNI, ha ingresado letras";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre del Cliente";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido Paterno del Cliente";
                    break;

                case 3://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apPaterno";
                    break;

                case 40://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido Materno del Cliente";
                    break;

                case 4://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apMaterno";
                    break;

                case 50://campo dni vacio
                    ViewBag.MensajeError = "Ingrese DNI del Cliente";
                    break;
                case 5://error de dni
                    ViewBag.MensajeError = "Ingrese un Numero de DNI válido";
                    break;
                case 60://campod direccion vacio
                    ViewBag.MensajeError = "Ingrese Dirección del Cliente";
                    break;
                case 6://error de direccion
                    ViewBag.MensajeError = "No se permiten mas de 50 caracteres en al campo Direccion";
                    break;
                case 70://campo telefono vacio
                    ViewBag.MensajeError = "Ingrese Telefóno del Cliente";
                    break;
                case 7://error de direccion
                    ViewBag.MensajeError = "ingrese un numero de Teléfono válido";
                    break;
                case 8://error de duplicidad
                    ViewBag.MensajeError = "Cliente [" + objCliente.IdCliente + "] ya esta Registrado en el Sistema";
                    break;
                case 9://error de duplicidad
                    ViewBag.MensajeError = "Numero de DNI [" + objCliente.Dni + "] ya esta asignado a un Cliente";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Cliente [" + objCliente.Nombre + " "+ objCliente.Appaterno + "] fue Registrado en el Sistema";
                    break;

            }

        }

        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del Cliente y Click en Guardar";
        }


        [HttpGet]
        public ActionResult Update(long id)
        {
            mensajeInicialActualizar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);
            return View(objCliente);
        }
        [HttpPost]
        public ActionResult Update(Cliente objCliente)
        {            
            mensajeInicialActualizar();
            objClienteNeg.update(objCliente);
            MensajeErrorActualizar(objCliente);
            return View();
            //return Redirect("~/Cliente/Index/");
        }

        //mensaje de error al actualizar
        public void MensajeErrorActualizar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código del Cliente";
                    break;
                case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre del Cliente";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido Paterno del Cliente";
                    break;

                case 3://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apPaterno";
                    break;

                case 40://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Apellido Materno del Cliente";
                    break;

                case 4://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo apMaterno";
                    break;

                case 50://campo dni vacio
                    ViewBag.MensajeError = "Ingrese DNI del Cliente";
                    break;
                case 5://error de dni
                    ViewBag.MensajeError = "Ingrese un DNI Válido";
                    break;
                case 60://campod direccion vacio
                    ViewBag.MensajeError = "Ingrese Dirección del Cliente";
                    break;
                case 6://error de direccion
                    ViewBag.MensajeError = "No se permiten mas de 50 caracteres en al campo Direccion";
                    break;
                case 70://campo telefono vacio
                    ViewBag.MensajeError = "Ingrese Telefóno del Cliente";
                    break;
                case 7://error de telefono
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en al campo Teléfono";
                    break;
                case 9://error de duplicidad
                    ViewBag.MensajeError = "Numero de DNI [" + objCliente.Dni + "] ya esta asignado a un Cliente";
                    break;

                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Datos del Cliente [" + objCliente.IdCliente + "] Fueron actualizados";
                    break;

            }

        }
        //mensjae inicial actualizar
        public void mensajeInicialActualizar()
        {
            ViewBag.MensajeInicialActualizar = "Formulario para Actualizar Datos del Cliente";
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            mensajeInicialEliminar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);
            return View(objCliente);
        }
        
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            mensajeInicialEliminar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.delete(objCliente);
            mostrarMensajeEliminar(objCliente);
            return Redirect("~/Cliente/Index/");
        }

        [HttpGet]
        public ActionResult Eliminar(long id)
        {
            mensajeInicialEliminar();
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);
            return View(objCliente);
        }

        [HttpPost]
        public ActionResult Eliminar(Cliente objCliente)
        {
            mensajeInicialEliminar();
            objClienteNeg.delete(objCliente);
            mostrarMensajeEliminar(objCliente);
            Cliente objCLiente2 = new Cliente();
            return View(objCLiente2);
            //return RedirectToAction("Index");
        }

        //mensaje de error al eliminar
        private void mostrarMensajeEliminar(Cliente objCliente)
        {

            switch (objCliente.Estado)
            {
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Cliente [" + objCliente.IdCliente + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "El Cliente: ["+objCliente.Appaterno+" "+objCliente.Apmaterno+", "+objCliente.Nombre+" ]Ya Fue Eliminado";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar al Cliente [" + objCliente.Appaterno + " " + objCliente.Apmaterno + ", " + objCliente.Nombre + "] Tiene Ventas Registrados en el Sistema!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Cliente [" + objCliente.Appaterno + " " + objCliente.Apmaterno + ", " + objCliente.Nombre + "] Fue Eliminado!!!";
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

        public ActionResult Find(long id)
        {
            Cliente objCliente = new Cliente(id);
            objClienteNeg.find(objCliente);
            //objClienteNeg.find2(objCliente);
            return View(objCliente);
        }

        [HttpGet]
        public ActionResult BuscarClientes()
        {
            List<Cliente> lista = objClienteNeg.findAll();
            return View(lista);
        }
        [HttpPost]
        public ActionResult BuscarClientes(string txtnombre, string txtappaterno, string txtdni, long txtcliente = -1)
        {
             
            if (txtnombre == "") 
            {
                txtnombre = "-1";                
            }
            if (txtappaterno == "") {
                txtappaterno = "-1";
            }
            if(txtdni == "")
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
    }
}