using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Vendedor
    {
        private string idVendedor;
        private string nombre;
        private string appaterno;
        private string apmaterno;
        private string dni;
        private string telefono;
        private int estado;

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

        public string Appaterno
        {
            get
            {
                return appaterno;
            }

            set
            {
                appaterno = value;
            }
        }

        public string Apmaterno
        {
            get
            {
                return apmaterno;
            }

            set
            {
                apmaterno = value;
            }
        }

        public string Dni
        {
            get
            {
                return dni;
            }

            set
            {
                dni = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
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

        public Vendedor()
        {
            
        }
        public Vendedor(string idVendedor)
        {
            this.idVendedor = idVendedor;
        }
        public Vendedor(string idVendedor, string appaterno, string apmaterno, string dni, string telefono)
        {
            this.idVendedor = idVendedor;
            this.Appaterno = appaterno;
            this.Apmaterno = apmaterno;
            this.Dni = dni;
            this.Telefono = telefono;
        }
    }
}
