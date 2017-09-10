using Model.Entity;
using Model.Neg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFacturaMvc.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaNeg objCategoriaNeg;
        private ProductoNeg objProductoNeg;
        public CategoriaController()
        {
            objCategoriaNeg = new CategoriaNeg();
            objProductoNeg = new ProductoNeg();
        }
        // GET: Categoria
        public ActionResult Index()
        {
            Categoria objCategoria = new Categoria();
            List<Categoria> lista = objCategoriaNeg.findAll();
            mensajeErrorServidor(objCategoria);
            return View(lista);
        }

        [HttpGet]
        public ActionResult Create()
        {
            mensajeInicioRegistrar();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Categoria objCategoria)
        {
            mensajeInicioRegistrar();
            objCategoriaNeg.create(objCategoria);
            MensajeErrorRegistrar(objCategoria);
            return View("Create");
        }
        //mensaje de error
        public void MensajeErrorRegistrar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion Insertar";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código de la Categoria";
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

                case 30://campo descripcion vacio
                    ViewBag.MensajeError = "Ingrese Descripcion Paterno de la Categoria";
                    break;

                case 3://error de Apellido Paterno
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Categoria";
                    break;
                                    
                case 8://error de duplicidad
                    ViewBag.MensajeError = "Categoria [" + objCategoria.IdCategoria + "] ya esta Registrada en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Categoria [" + objCategoria.IdCategoria + "] fue Registrado en el Sistema";
                    break;

            }

        }
        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos De la Categoria y Click en Guardar";
        }

        public ActionResult Update(string id)
        {
            Categoria objCategoria = new Categoria(id);
            objCategoriaNeg.find(objCategoria);
            mensajeInicioActualizar();
            return View(objCategoria);
        }
        [HttpPost]
        public ActionResult Update(Categoria objCategoria)
        {
            mensajeInicioActualizar();
            objCategoriaNeg.update(objCategoria);
            MensajeErrorActualizar(objCategoria);
            return View();
        }

        //mensaje de error
        public void MensajeErrorActualizar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de actualizar";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código del Producto";
                    break;
                case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre de la Categoria";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo descripcion vacio
                    ViewBag.MensajeError = "Ingrese Descripcion de la Producto";
                    break;

                case 3://error de precio Unitario
                    ViewBag.MensajeError = "No se permiten mas de 50 caracteres en el campo Categoria";
                    break;

                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Datos de la Categoria [" + objCategoria.IdCategoria + "] Fueron Actualizados";
                    break;

            }

        }
        public void mensajeInicioActualizar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos De la Categoria y Click en Guardar";
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            mensajeInicialEliminar();
            Categoria objCategoria = new Categoria(id);
            objCategoriaNeg.find(objCategoria);
            return View(objCategoria);
        }

        [HttpPost]
        public ActionResult Delete(Categoria objCategoria)
        {
            mensajeInicialEliminar();
            objCategoriaNeg.delete(objCategoria);
            mostrarMensajeEliminar(objCategoria);            
            return View();
            //return RedirectToAction("Index");
        }

        //mensaje de error al eliminar
        private void mostrarMensajeEliminar(Categoria objCategoria)
        {

            switch (objCategoria.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de Eliminar";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Categoria [" + objCategoria.IdCategoria + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "Categoria: [" + objCategoria.Nombre + "]Ya Fue Eliminada";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar la Categoria [" + objCategoria.Nombre + "] Tiene  Productos asignadoss!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Categoria [" + objCategoria.Nombre + "] Fue Eliminado!!!";
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
            Producto objProducto = new Producto();
            objProducto.Categoria = id;
            List<Producto> Producto = objProductoNeg.findAllProductosPorCategoria(objProducto);

            return View(Producto);
        }
        public void mensajeErrorServidor(Categoria objCategoria)
        {
            switch (objCategoria.Estado)
            {
                case 1000:
                    ViewBag.MensajeError = "ERROR DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }


    }
}