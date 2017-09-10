using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Neg;
using Model.Entity;

namespace WebFacturaMvc.Controllers
{
    public class ProductoController : Controller
    {
        ProductoNeg objProductoNeg;
        public ProductoController()
        {
            objProductoNeg = new ProductoNeg();
        }
        // GET: Producto
        public ActionResult Index()
        {

            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;
            
            List<Producto> listaProductos = objProductoNeg.findAll();
            return View(listaProductos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;
            mensajeInicioRegistrar();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Producto objProducto)
        {
            mensajeInicioRegistrar();
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;
            objProductoNeg.create(objProducto);
            MensajeErrorRegistrar(objProducto);
            return View("Create");
        }

        //mensaje de error
        public void MensajeErrorRegistrar(Producto objProducto)
        {

            switch (objProducto.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion Insertar";
                    break;
                case 10://campo codigo vacio
                    ViewBag.MensajeError = "Ingrese Código del Producto";
                    break;
                case 1://error campo cadigo
                    ViewBag.MensajeError = "No se permiten mas de 5 caracteres en al campo Codigo";
                    break;
                case 20://campo nombre vacio
                    ViewBag.MensajeError = "Ingrese Nombre del Producto";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo orecio UNitario vacio
                    ViewBag.MensajeError = "Ingrese Precio Unitario del Producto";
                    break;

                case 3://error de precio Unitario
                    ViewBag.MensajeError = "Precio unitario no valido";
                    break;
                case 300://error de Apellido Paterno
                    ViewBag.MensajeError = "Ingrese un Precio Válido";
                    break;

                case 40://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Categoria";
                    break;

                case 4://error de Apellido Paterno
                    ViewBag.MensajeError = "INgrese una categoria válida";
                    break;                
                case 8://error de duplicidad
                    ViewBag.MensajeError = "Producto [" + objProducto.IdProducto + "] ya esta Registrado en el Sistema";
                    break;
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Producto [" + objProducto.IdProducto + "] fue Registrado en el Sistema";
                    break;

            }

        }

        public void mensajeInicioRegistrar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del Producto y Click en Guardar";
        }

        public ActionResult Update(string id)
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;
            Producto objProducto = new Producto(id);
            objProductoNeg.find(objProducto);
            mensajeInicioActualizar();
            return View(objProducto);
        }
        [HttpPost]
        public ActionResult Update(Producto objProducto)
        {
            mensajeInicioActualizar();
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;
            objProductoNeg.update(objProducto);
            MensajeErrorActualizar(objProducto);
            return View();
        }

        //mensaje de error
        public void MensajeErrorActualizar(Producto objProducto)
        {

            switch (objProducto.Estado)
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
                    ViewBag.MensajeError = "Ingrese Nombre del Producto";
                    break;

                case 2://error de nombre
                    ViewBag.MensajeError = "No se permiten mas de 30 caracteres en el campo Nombre";
                    break;

                case 30://campo orecio UNitario vacio
                    ViewBag.MensajeError = "Ingrese Precio Unitario del Producto";
                    break;

                case 3://error de precio Unitario
                    ViewBag.MensajeError = "Precio unitario no valido";
                    break;
                case 300://error de Apellido Paterno
                    ViewBag.MensajeError = "Ingrese un Precio Válido";
                    break;

                case 40://campo Apellido Paterno vacio
                    ViewBag.MensajeError = "Ingrese Categoria";
                    break;

                case 4://error de Apellido Paterno
                    ViewBag.MensajeError = "INgrese una categoria válida";
                    break;
                
                case 99://carrera registrada con exito
                    ViewBag.MensajeExito = "Datos del Producto [" + objProducto.IdProducto + "] Fueron Actualizados";
                    break;

            }

        }
        public void mensajeInicioActualizar()
        {
            ViewBag.MensajeInicio = "Ingrese Datos Del Producto y Click en Guardar";
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            mensajeInicialEliminar();
            Producto objProducto = new Producto(id);
            objProductoNeg.find(objProducto);
            return View(objProducto);
        }

        [HttpPost]
        public ActionResult Delete(Producto objProducto)
        {
            mensajeInicialEliminar();
            objProductoNeg.delete(objProducto);
            mostrarMensajeEliminar(objProducto);
            Producto objProducto2 = new Producto();
            return View(objProducto2);
            //return RedirectToAction("Index");
        }

        //mensaje de error al eliminar
        private void mostrarMensajeEliminar(Producto objProducto)
        {

            switch (objProducto.Estado)
            {
                case 1000://campo codigo vacio
                    ViewBag.MensajeError = "Error!!! Revise la instruccion de Eliminar";
                    break;
                case 1: //ERROR DE EXISTENCIA
                    ViewBag.MensajeError = "Producto [" + objProducto.IdProducto + "] No Esta Registrado en el Sistema ";
                    break;

                case 33://CLIENTE NO EXISTE
                    ViewBag.MensajeError = "El Producto: [" + objProducto.Nombre + "]Ya Fue Eliminado";
                    break;
                case 34:
                    ViewBag.MensajeError = "No se Puede Eliminar al Producto [" + objProducto.Nombre + "] Tiene  Ventas asignadas!!!";
                    break;
                case 99: //EXITO
                    ViewBag.MensajeExito = "Producto [" + objProducto.Nombre + "] Fue Eliminado!!!";
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
            Producto objProducto = new Producto(id);
            objProductoNeg.find(objProducto);
            //objClienteNeg.find2(objCliente);
            return View(objProducto);
        }

        [HttpGet]
        public ActionResult BuscarProductos()
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;

            List<Producto> listas = objProductoNeg.findAll();
            return View(listas);
        }
        [HttpPost]
        public ActionResult BuscarProductos(string txtproducto, string txtnombre, string ListaCategorias)
        {

            if (txtnombre == "")
            {
                txtnombre = "-1";
            }
            if (txtproducto == "")
            {
                txtproducto = "-1";
            }
            if (ListaCategorias == "")
            {
                ListaCategorias = "-1";
            }

            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;

            Producto objProducto = new Producto();
            objProducto.Nombre = txtnombre;
            objProducto.IdProducto = txtproducto;
            objProducto.Categoria = ListaCategorias;

            List<Producto> Producto = objProductoNeg.findAllProductos(objProducto);
            mensajeErrorServidor(objProducto);
            return View(Producto);
        }

        public void mensajeErrorServidor(Producto objProducto)
        {
            switch (objProducto.Estado)
            {
                case 1000:
                    ViewBag.MensajeError = "ERROR DE SERVIDOR DE SQL SERVER";
                    break;
            }
        }

        [HttpGet]
        public ActionResult BuscarProductosPorCategoria()
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;
            List<Producto> Producto = objProductoNeg.findAll();            
            return View(Producto);
        }

        [HttpPost]
        public ActionResult BuscarProductosPorCategoria(string ListaCategorias)
        {
            CategoriaNeg objCategoriaNeg = new CategoriaNeg();
            List<Categoria> data = objCategoriaNeg.findAll();
            SelectList lista = new SelectList(data, "idCategoria", "nombre");
            ViewBag.ListaCategorias = lista;

            Producto objProducto = new Producto();
            objProducto.Categoria = ListaCategorias;
            List<Producto> Producto = objProductoNeg.findAllProductosPorCategoria(objProducto);
            mensajeErrorServidor(objProducto);
            return View(Producto);
        }       

    }
}