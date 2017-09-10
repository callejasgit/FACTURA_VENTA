using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
   public class Producto
    {
        private string idProducto;
        private string nombre;
        private double precioUnitario;
        private string categoria;
        private int estado;

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

        public string IdProducto
        {
            get
            {
                return idProducto;
            }

            set
            {
                idProducto = value;
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

        public double PrecioUnitario
        {
            get
            {
                return precioUnitario;
            }

            set
            {
                precioUnitario = value;
            }
        }

        public string Categoria
        {
            get
            {
                return categoria;
            }

            set
            {
                categoria = value;
            }
        }

        public Producto()
        {
            
        }
        public Producto(string idProducto)
        {
            this.idProducto = idProducto;
        }
        public Producto(string idProducto, string nombre, double precioUnitario, string categoria)
        {
            this.idProducto = idProducto;
            this.Nombre = nombre;
            this.PrecioUnitario = precioUnitario;
            this.Categoria = categoria;
        }
    }
}
