using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{
    public class ModoPagoNeg
    {
        private ModoPagoDao objModoPagoDao;
        private FacturaDao objFacturaDao;

        public ModoPagoNeg()
        {
            objModoPagoDao = new ModoPagoDao();
            objFacturaDao = new FacturaDao();
        }

        public void create(ModoPago objModoPago)
        {
            bool verificacion = true;
            ////validar numeroPago retorna estado=1;
            //string numP = objModoPago.NumPago.ToString();
            //int numPag = 0;
            //if (numP == null)
            //{
            //    objModoPago.Estado = 10;
            //    return;
            //}else
            //{
            //    try
            //    {
            //        numPag = Convert.ToInt32(objModoPago.NumPago);
            //        verificacion = numPag > 0 && numPag < 999999;
            //        if (!verificacion)
            //        {
            //            objModoPago.Estado = 1;
            //            return;
            //        }
            //    }
            //    catch (Exception e)
            //    {
            //        objModoPago.Estado = 100; ;
            //    }
            //}
            ////fin validar numPago

            //inicio validar nombre estado=2
            string nombre = objModoPago.Nombre;
            if (nombre == null)
            {
                objModoPago.Estado = 20;
            }else
            {
                nombre = objModoPago.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length < 30;
                if (!verificacion)
                {
                    objModoPago.Estado = 2;
                    return;
                }
            }
            //fin validar nombre

            //inicio validar otroDetalle retorna estado=3
            string otro = objModoPago.Otros.Trim();
            verificacion = otro.Length > 0 && otro.Length < 50;
            if (!verificacion)
            {
                objModoPago.Estado = 3;
                return;
            }
            //fin validar otroDetalle retorna estado=3

            //inicio validar duplicicdad estado=4
            ModoPago objModoPagoAux = new ModoPago();
            objModoPagoAux.NumPago = objModoPago.NumPago;
            verificacion = !objModoPagoDao.find(objModoPagoAux);
            if (!verificacion)
            {
                objModoPago.Estado = 4;
                return;
            }
            //fin modoPago

            //todo bien
            objModoPago.Estado = 99;
            objModoPagoDao.create(objModoPago);
            return;

        }

        public void update(ModoPago objModoPago)
        {
            bool verificacion = true;
            

            //inicio validar nombre estado=2
            string nombre = objModoPago.Nombre;
            if (nombre == null)
            {
                objModoPago.Estado = 20;
            }
            else
            {
                nombre = objModoPago.Nombre.Trim();
                verificacion = nombre.Length > 0 && nombre.Length < 30;
                if (!verificacion)
                {
                    objModoPago.Estado = 2;
                    return;
                }
            }
            //fin validar nombre

            //inicio validar otroDetalle retorna estado=3
            string otro = objModoPago.Otros.Trim();
            verificacion = otro.Length > 0 && otro.Length < 50;
            if (!verificacion)
            {
                objModoPago.Estado = 3;
                return;
            }
            //fin validar otroDetalle retorna estado=3

            //todo bien
            objModoPago.Estado = 99;
            objModoPagoDao.update(objModoPago);
            return;

        }

        public void delete(ModoPago objModoPago)
        {
            bool verificacion = true;
            //verificacion de existencia
            ModoPago objModoPagoAux = new ModoPago();
            objModoPagoAux.NumPago = objModoPago.NumPago;
            verificacion = objModoPagoDao.find(objModoPagoAux);
            if (!verificacion)
            {
                objModoPago.Estado = 33;
                return;
            }
            //fin verificaion de existencia


            //verificaicon de existencia de factura
            Factura objFactura = new Factura();
            objFactura.NumPago = objModoPago.NumPago;
            verificacion = !objFacturaDao.findFacturaPorNumPago(objFactura);
            if (!verificacion)
            {
                objModoPago.Estado = 34;
                return;
            }
            objModoPago.Estado = 99;
            objModoPagoDao.delete(objModoPago);
            return;
        }

        public bool find(ModoPago objModoPago)
        {
            return objModoPagoDao.find(objModoPago);
        }
        public List<ModoPago> findAll()
        {
            return objModoPagoDao.findAll();
        }

    }
}
