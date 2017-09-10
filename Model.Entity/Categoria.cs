using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Categoria
    {
        private string idCategoria;
        private string nombre;
        private string descripcion;
        private int estado;

        public string IdCategoria
        {
            get
            {
                return idCategoria;
            }

            set
            {
                idCategoria = value;
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

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
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

        public Categoria()
        {
       
        }
        public Categoria(string idCategoria, string nombre, string descripcion)
        {
            this.idCategoria = idCategoria;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }
        public Categoria(string idCategoria)
        {
            this.idCategoria = idCategoria;
            
        }
    }
}
