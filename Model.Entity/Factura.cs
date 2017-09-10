using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Factura
    {
        private long numFactura;
        private string fecha;
        private double iva;
        private double total;
        private Int32 numPago;
        private int estado;

        public long NumFactura
        {
            get
            {
                return numFactura;
            }

            set
            {
                numFactura = value;
            }
        }

        public string Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
            }
        }

        public double Iva
        {
            get
            {
                return iva;
            }

            set
            {
                iva = value;
            }
        }

        public double Total
        {
            get
            {
                return total;
            }

            set
            {
                total = value;
            }
        }

        public Int32 NumPago
        {
            get
            {
                return numPago;
            }

            set
            {
                numPago = value;
            }
        }

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }
        

        public Factura(string fecha, double iva, double total, Int32 numPago)
        {            
            this.fecha = fecha;
            this.iva = iva;
            this.total = total;
            this.numPago = numPago;
           
        }


        public Factura()
        {
            
        }
        public Factura(long numFactura)
        {
            this.NumFactura = numFactura;            
        }
    }
}
