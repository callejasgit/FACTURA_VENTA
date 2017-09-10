using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Venta
    {
        private long idVenta;
        private double total;        
        private long idCliente;
        private string idVendedor;        
        private string fecha;
        private double iva;
        private int estado;

        public long IdVenta
        {
            get
            {
                return idVenta;
            }

            set
            {
                idVenta = value;
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
        

        public long IdCliente
        {
            get
            {
                return idCliente;
            }

            set
            {
                idCliente = value;
            }
        }

        public string IdVendedor
        {
            get
            {
                return idVendedor;
            }

            set
            {
                idVendedor = value;
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

        public Venta()
        {
            
        }
        public Venta(double total, long idCliente, string idVendedor, string fecha,double iva)
        {            
            this.total = total;           
            this.idCliente = idCliente;
            this.idVendedor = idVendedor;
            this.iva = iva;
            this.fecha = fecha;
        }
        public Venta(long idVenta)
        {
            this.idVenta = idVenta;          
        }
    }
}
