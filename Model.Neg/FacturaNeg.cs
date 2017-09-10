using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{
   public class FacturaNeg
    {
        private FacturaDao objFacturaDao;
        private DetalleVentaDao objDetalleFacturaDao;
        public FacturaNeg()
        {
            objFacturaDao = new FacturaDao();
            objDetalleFacturaDao = new DetalleVentaDao();
        }

        public string create(Factura objFactura)
        {
            bool verificacion = true;

            //inicio verificaicon numFactura retorna estado=!
            string numf = objFactura.NumFactura.ToString();
            int num = 0;
            if (numf == null)
            {
                objFactura.Estado = 10;
            }else
            {
                try
                {
                    num = Convert.ToInt32(objFactura.NumFactura);
                    verificacion = num > 0 && num < 9999;
                    if (!verificacion)
                    {
                        objFactura.Estado = 1;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            //fin verificaicon numFactura retorna estado=!

            //inicio verificacion fecha estado=2
            string fecha = objFactura.Fecha;
            
            if (fecha == null)
            {
                objFactura.Estado = 20;
               
            }
            else
            {
                fecha=objFactura.Fecha.Trim();
                verificacion = fecha.Length>0&&fecha.Length<30;
                if (!verificacion)
                {
                    objFactura.Estado = 2;
                   
                }
            }
            //fin verificacion de fecha

            //inicio verificacion iva estado=3
            string iva = objFactura.Iva.ToString();
            double ivas = 0;
            if (iva == null)
            {
                objFactura.Estado = 30;
            }else
            {
                try
                {
                    ivas = Convert.ToDouble(objFactura.Iva);
                    verificacion = ivas > 0 &&ivas< 99;
                    if (!verificacion)
                    {
                        objFactura.Estado = 3;
                    }
                }
                catch (Exception)
                {

                    objFactura.Estado=300;
                }
            }
            //fin verificacion iva

            //inicio verificacion total estado=4
            string total = objFactura.Total.ToString();
            double tot = 0;
            if (total == null)
            {
                objFactura.Estado = 40;
                
            }else
            {
                try
                {
                    tot = Convert.ToDouble(objFactura.Total);
                    verificacion = tot >= 0 && tot < 99999999;
                    if (!verificacion)
                    {
                        objFactura.Estado = 4;
                       
                    }
                }
                catch (Exception)
                {

                    objFactura.Estado = 400;
                   
                }
            }
            //fin verificacion total

            //inicio verificacion total estado=5
            string nump = objFactura.NumPago.ToString();
            int numpag = 0;
            if (nump == null)
            {
                objFactura.Estado = 50;
                
            }
            else
            {
                try
                {
                    numpag = Convert.ToInt32(objFactura.NumPago);
                    verificacion = numpag >= 0 && numpag < 99999999;
                    if (!verificacion)
                    {
                        objFactura.Estado = 5;
                       
                    }
                }
                catch (Exception)
                {

                    objFactura.Estado = 500;
                   
                }
            }
            //fin verificacion total

            //inicio verificacion de dupliccidad estado=6
            Factura objFacturaAux = new Factura();
            objFacturaAux.NumFactura = objFactura.NumFactura;
            verificacion = !objFacturaDao.find(objFacturaAux);
            if (!verificacion)
            {
                objFactura.Estado = 6;
                
            }

            //todo bien
            objFactura.Estado = 99;
            return objFacturaDao.create(objFactura);
            
        }

        public void update(Factura objFactura)
        {
            bool verificacion = true;
            //inicio verificacion fecha estado=2
            string fecha = objFactura.Fecha.ToString();

            if (fecha == null)
            {
                objFactura.Estado = 20;
                return;
            }
            else
            {
                fecha = objFactura.Fecha.Trim();
                verificacion = fecha.Length > 0 && fecha.Length < 30;
                if (!verificacion)
                {
                    objFactura.Estado = 2;
                    return;
                }
            }
            //fin verificacion de fecha

            //inicio verificacion iva estado=3
            string iva = objFactura.Iva.ToString();
            double ivas = 0;
            if (iva == null)
            {
                objFactura.Estado = 30;
            }
            else
            {
                try
                {
                    ivas = Convert.ToDouble(objFactura.Iva);
                    verificacion = ivas > 0 && ivas < 99;
                    if (!verificacion)
                    {
                        objFactura.Estado = 3;
                    }
                }
                catch (Exception)
                {

                    objFactura.Estado = 300;
                }
            }
            //fin verificacion iva

            //inicio verificacion total estado=4
            string total = objFactura.Total.ToString();
            double tot = 0;
            if (total == null)
            {
                objFactura.Estado = 40;
                return;
            }
            else
            {
                try
                {
                    tot = Convert.ToDouble(objFactura.Total);
                    verificacion = tot >= 0 && tot < 99999999;
                    if (!verificacion)
                    {
                        objFactura.Estado = 4;
                        return;
                    }
                }
                catch (Exception)
                {

                    objFactura.Estado = 400;
                    return;
                }
            }
            //fin verificacion total

            //inicio verificacion total estado=5
            string nump = objFactura.NumPago.ToString();
            int numpag = 0;
            if (nump == null)
            {
                objFactura.Estado = 50;
                return;
            }
            else
            {
                try
                {
                    numpag = Convert.ToInt32(objFactura.NumPago);
                    verificacion = numpag >= 0 && numpag < 99999999;
                    if (!verificacion)
                    {
                        objFactura.Estado = 5;
                        return;
                    }
                }
                catch (Exception)
                {

                    objFactura.Estado = 500;
                    return;
                }
            }
            //fin verificacion total

            
            //todo bien
            objFactura.Estado = 99;
            objFacturaDao.update(objFactura);
            return;
        }

        public void delete(Factura objFactura)
        {
            bool verificacion = true;
            //verificacion de existencia
            Factura objFacturaAux = new Factura();
            objFacturaAux.NumFactura = objFactura.NumFactura;
            verificacion = objFacturaDao.find(objFacturaAux);
            if (!verificacion)
            {
                objFactura.Estado = 33;
                return;
            }

            //verificaicon de existencia de Detalle
            DetalleVenta objDetalleVenta = new DetalleVenta();
            objDetalleVenta.NumFacura = objFactura.NumFactura;
            verificacion = !objDetalleFacturaDao.findPorNumFactura(objDetalleVenta);
            if (!verificacion)
            {
                objFactura.Estado = 34;
                return;
            }
            objFactura.Estado = 99;
            objFacturaDao.delete(objFactura);
            return;
        }
      
        public bool find(Factura objFactura)
        {
            return objFacturaDao.find(objFactura);
        }

        public List<Factura> findAll()
        {
            return objFacturaDao.findAll();
        }
    }
}
