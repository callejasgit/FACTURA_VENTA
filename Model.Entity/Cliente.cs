using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Cliente
    {
        private long idCliente;
        private string nombre;
        [Display(Name = "Apelido Materno")]
        private string apmaterno;
        
        private string appaterno;
        private string dni;
        private string direccion;
        private string telefono;
        private List<Venta> ventas;
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
        [Display(Name="Codigo")]
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
        [Required(ErrorMessage ="Este Campo es Requerido")]
        [Display(Name = "Nombre")]
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
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Apelido Materno")]
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
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Aoellido Paterno")]
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
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "DNI")]
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
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Dirección")]
        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }
        [Required(ErrorMessage = "Este Campo es Requerido")]
        [Display(Name = "Telefóno")]
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
        [Required(ErrorMessage = "Este Campo es Requerido")]
        public List<Venta> Ventas
        {
            get
            {
                return ventas;
            }

            set
            {
                ventas = value;
            }
        }

        public Cliente()
        {

        }
        public Cliente(long idCliente)
        {
            this.idCliente = idCliente;
        }

        public Cliente(long idCliente, string nombre, string apmaterno, string appaterno, string dni, string direccion, string telefono)
        {
            this.idCliente = idCliente;
            this.Nombre = nombre;
            this.Apmaterno = apmaterno;
            this.Appaterno = appaterno;
            this.Dni = dni;
            this.Direccion = direccion;
            this.Telefono = telefono;
        }
       
    }
}
