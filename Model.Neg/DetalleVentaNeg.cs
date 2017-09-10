using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using Model.Dao;

namespace Model.Neg
{
   public class DetalleVentaNeg
    {
        private DetalleVentaDao objDetalleVentaDao;
        public DetalleVentaNeg()
        {
            objDetalleVentaDao = new DetalleVentaDao();
        }
        public void create(DetalleVenta objDetalleVenta)
        {
            bool verificacion = true;

            //inicio verificacion de cantidaa estado=1
            int cant = 0;
            string cantidad = objDetalleVenta.Cantidad.ToString();
            if (cantidad == null)
            {
                objDetalleVenta.Estado = 10;
                return;
            }
            else
            {
                try
                {
                    cant = Convert.ToInt32(objDetalleVenta.Cantidad);
                    verificacion = cant > 0 && cant < 999999;
                    if (!verificacion)
                    {
                        objDetalleVenta.Estado = 1;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objDetalleVenta.Estado = 100;
                    return;
                }

            }
            //fin verificacion de cantidad
            objDetalleVenta.Estado = 99;
            objDetalleVentaDao.create(objDetalleVenta);
            return;

        }

        public List<DetalleVenta> detallesPorIdVenta(DetalleVenta objDetalleVenta)
        {
            return objDetalleVentaDao.detallesPorIdVenta(objDetalleVenta);
        }
        public void delete(DetalleVenta objDetalleVenta)
        {            
            objDetalleVentaDao.delete(objDetalleVenta);
        }
        public List<DetalleVenta> findAll()
        {
            return objDetalleVentaDao.findAll();
        }


    }
}
