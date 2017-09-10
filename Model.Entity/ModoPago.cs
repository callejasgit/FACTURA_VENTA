using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class ModoPago
    {
        private Int32 numPago;
        private string nombre;
        private string otros;
        private int estado;

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

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public string Otros
        {
            get
            {
                return otros;
            }

            set
            {
                otros = value;
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
        public ModoPago()
        {

        }
        public ModoPago(Int32 numPago, string nombre, string otros)
        {
            this.NumPago = numPago;
            this.Nombre = nombre;
            this.Otros = otros;
        }
       
        public ModoPago(Int32 numPago)
        {
            this.NumPago = numPago;
           
        }
    }
}
