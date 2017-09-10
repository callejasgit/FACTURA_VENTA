using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Dao;

namespace Model.Neg
{
    public class ProductoNeg
    {
        private ProductoDao objProductoDao;
        private DetalleVentaDao objDetalleVentaDao;
        public ProductoNeg()
        {
            objProductoDao = new ProductoDao();
            objDetalleVentaDao = new DetalleVentaDao();
        }
        public void create(Producto objProducto)
        {
            bool verificacion = true;
            //inicio verificacion de codigo estado=1
            string codigo = objProducto.IdProducto;
            if (codigo == null)
            {
                objProducto.Estado = 10;
                return;
            }
            else
            {
                codigo = objProducto.IdProducto.Trim();
                verificacion = codigo.Length > 0 && codigo.Length <= 5;
                if (!verificacion)
                {
                    objProducto.Estado = 1;
                    return;
                }
            }
            //fin verificacion de codigo

            //inicio verificacion de nombre estado=2
            string nombre = objProducto.Nombre;
            if (nombre == null)
            {
                objProducto.Estado = 20;
                return;
            }
            else
            {
                nombre = objProducto.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 30;
                if (!verificacion)
                {
                    objProducto.Estado = 2;
                    return;
                }
            }
            //fin verificacion de codigo

            //inicio verificacion de precioUnitario estado=3
            string precioUni = objProducto.PrecioUnitario.ToString();
            double preUni = 0;
            if (nombre == null)
            {
                objProducto.Estado = 30;
                return;
            }
            else
            {
                try
                {
                    preUni = Convert.ToDouble(objProducto.PrecioUnitario);
                    verificacion = preUni > 0 && preUni <= 9999999;
                    if (!verificacion)
                    {
                        objProducto.Estado = 3;
                        return;
                    }
                }
                catch (Exception)
                {
                    objProducto.Estado = 300;
                    return;
                }

            }
            //fin verificacion de precioUnitario

            //inicio verificacion de categoria estado=4
            string categoria = objProducto.Categoria;
            if (categoria == null)
            {
                objProducto.Estado = 40;
                return;
            }
            else
            {
                categoria = objProducto.Categoria.Trim();
                verificacion = categoria.Length > 0 && categoria.Length <= 30;
                if (!verificacion)
                {
                    objProducto.Estado = 4;
                    return;
                }
            }
            //fin verificacion de categoria

            //verificacion de duplicidad estado=5
            Producto objProductoAux = new Producto();
            objProductoAux.IdProducto = objProducto.IdProducto;
            verificacion = !objProductoDao.find(objProductoAux);
            if (!verificacion)
            {
                objProducto.Estado = 5;
                return;
            }
            //fin verificacion duplicidad

            //todo bien
            objProducto.Estado = 99;
            objProductoDao.create(objProducto);
            return;
        }

        public void update(Producto objProducto)
        {
            bool verificacion = true;

            //inicio verificacion de nombre estado=2
            string nombre = objProducto.Nombre;
            if (nombre == null)
            {
                objProducto.Estado = 20;
                return;
            }
            else
            {
                nombre = objProducto.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length <= 30;
                if (!verificacion)
                {
                    objProducto.Estado = 2;
                    return;
                }
            }
            //fin verificacion de codigo

            //inicio verificacion de precioUnitario estado=3
            string precioUni = objProducto.PrecioUnitario.ToString();
            decimal preUni = 0;
            if (nombre == null)
            {
                objProducto.Estado = 30;
                return;
            }
            else
            {
                try
                {
                    preUni = Convert.ToDecimal(objProducto.PrecioUnitario);
                    verificacion = preUni > 0 && preUni <= 9999999;
                    if (!verificacion)
                    {
                        objProducto.Estado = 3;
                        return;
                    }
                }
                catch (Exception)
                {
                    objProducto.Estado = 300;
                    return;
                }

            }
            //fin verificacion de precioUnitario

            //inicio verificacion de categoria estado=4
            string categoria = objProducto.Categoria;
            if (categoria == null)
            {
                objProducto.Estado = 40;
                return;
            }
            else
            {
                categoria = objProducto.Categoria.Trim();
                verificacion = categoria.Length > 0 && categoria.Length <= 5;
                if (!verificacion)
                {
                    objProducto.Estado = 4;
                    return;
                }
            }
            //fin verificacion de categoria

            //todo bien
            objProducto.Estado = 99;
            objProductoDao.update(objProducto);
            return;
        }

        public void delete(Producto objProducto)
        {
            bool verificacion = true;
            //verificacion de existencia estado=33
            Producto objProductoAux = new Producto();
            objProductoAux.IdProducto = objProducto.IdProducto;
            verificacion = objProductoDao.find(objProductoAux);
            if (!verificacion)
            {
                objProducto.Estado = 33;
                return;
            }
            //fin verificacion de existencia
            //verificacion de existecia de DetalleVenta estado=34
            DetalleVenta objDetalleVenta = new DetalleVenta();
            objDetalleVenta.IdProducto = objProducto.IdProducto;
            verificacion = !objDetalleVentaDao.findDetalleVentaPorProductoId(objDetalleVenta);
            if (!verificacion)
            {
                objProducto.Estado = 34;
                return;
            }
            //fin verificacion de existencia de Venta

            //todo bien
            objProducto.Estado = 99;
            objProductoDao.delete(objProducto);
            return;

        }

        public bool find(Producto objProducto)
        {
            return objProductoDao.find(objProducto);
        }

        public List<Producto> findAll()
        {
            return objProductoDao.findAll();
        }

        public List<Producto> findPrecioProducto(Producto objPrducto)
        {
            return objProductoDao.findPrecioProducto(objPrducto);
        }

        public List<Producto> findAllProductos(Producto objProducto)
        {
            return objProductoDao.findAllProductos(objProducto);
        }
        public List<Producto> findAllProductosPorCategoria(Producto objProducto)
        {
            return objProductoDao.findAllProductosPorCategoria(objProducto);
        }
    }
}
