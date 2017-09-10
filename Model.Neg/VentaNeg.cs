using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{
    public class VentaNeg
    {
        private VentaDao objVentaDao;
        private DetalleVentaDao objDetalleVentaDao;
        public VentaNeg()
        {
            objVentaDao = new VentaDao();
            objDetalleVentaDao = new DetalleVentaDao();
        }

        public string create(Venta objVenta)
        {
            bool verificacion = true;           

            //inicio verificacion total estado=2
            string total = objVenta.Total.ToString();
            double total1 = 0;
            if (total == null)
            {
                objVenta.Estado = 20;
                
            }else
            {
                try
                {
                    total1 = Convert.ToDouble(objVenta.Total);
                    verificacion = total1 > 0 && total1 < 999999999999999;

                    if (!verificacion)
                    {
                        objVenta.Estado = 2;
                        
                    }
                }
                catch (Exception e)
                {
                    objVenta.Estado = 200;
                    
                }
            }
            //inicio verificacion total            

            //inicio verificacion fecha estado=4
            string fecha = objVenta.Fecha.ToString();
            
            if (fecha == null)
            {
                objVenta.Estado = 40;
                
            }else
            {
                fecha = objVenta.Fecha.Trim();
                verificacion = fecha.Length > 0 && fecha.Length < 30;          
                if (!verificacion)
                {
                    objVenta.Estado = 4;
                    
                }
            }
            //fin verificacion de fecha

            //todo bien
            objVenta.Estado = 99;
           return  objVentaDao.create(objVenta);
           
        }

        public void update(Venta objVenta)
        {
            bool verificacion = true;           

            //inicio verificacion total estado=2
            string total = objVenta.Total.ToString();
            double total1 = 0;
            if (total == null)
            {
                objVenta.Estado = 20;
                return;
            }
            else
            {
                try
                {
                    total1 = Convert.ToDouble(objVenta.Total);
                    verificacion = total1 > 0 && total1 < 999999999999999;

                    if (!verificacion)
                    {
                        objVenta.Estado = 2;
                        return;
                    }
                }
                catch (Exception e)
                {
                    objVenta.Estado = 200;
                    return;
                }
            }
            //inicio verificacion total           

            //inicio verificacion fecha estado=4
            string fecha = objVenta.Fecha.ToString();

            if (fecha == null)
            {
                objVenta.Estado = 40;
                return;
            }
            else
            {
                fecha = objVenta.Fecha.Trim();
                verificacion = fecha.Length > 0 && fecha.Length < 30;
                if (!verificacion)
                {
                    objVenta.Estado = 4;
                    return;
                }
            }
            //fin verificacion de fecha

            //todo bien
            objVenta.Estado = 99;
            objVentaDao.update(objVenta);
            return;
        }

        public void delete(Venta objVenta)
        { 
            bool verificacion = true;
            //inicio verificacion de existencia
            Venta objVentaAux = new Venta();
            objVentaAux.IdVenta = objVenta.IdVenta;
            verificacion = objVentaDao.find(objVentaAux);
            if (!verificacion)
            {
                objVenta.Estado = 33;
                return;
            }
            //fin verificaicon de existencia de Venta
           
            //verificaicon de existencia de Detalle
            DetalleVenta objDetalleVenta = new DetalleVenta();
            objDetalleVenta.IdVenta = objVenta.IdVenta;
            verificacion = !objDetalleVentaDao.findPorIdVenta(objDetalleVenta);
            if (!verificacion)
            {
                objVenta.Estado = 34;
                return;
            }
            //todo bien
            objVenta.Estado = 99;
            objVentaDao.delete(objVenta);
            return;
        }

        public bool find(Venta objVenta)
        {
            return objVentaDao.find(objVenta);
        }
        public List<Venta> findAll()
        {
            return objVentaDao.findAll();
        }        

        }
}
