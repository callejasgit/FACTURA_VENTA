using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Dao
{
    public class ProductoDao:Obligatorio<Producto>
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public ProductoDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }
        public void create(Producto objProducto)
        {
            string create = "insert into producto values('" + objProducto.IdProducto + "','" + objProducto.Nombre + "','" + objProducto.PrecioUnitario + "','" + objProducto.Categoria + "')";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objProducto.Estado = 1000;                
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public void delete(Producto objProducto)
        {
            string delete = "delete from producto where idProducto='" + objProducto.IdProducto + "'";
            try
            {
                comando = new SqlCommand(delete, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objProducto.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public bool find(Producto objProducto)
        {
            bool hayRegistros;
            string find = "select*from producto where idProducto='" + objProducto.IdProducto + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objProducto.Nombre = reader[1].ToString();
                    objProducto.PrecioUnitario =Convert.ToDouble(reader[2].ToString());
                    objProducto.Categoria = reader[3].ToString();
                    
                    objProducto.Estado = 99;
                }
                else
                {
                    objProducto.Estado = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }

            return hayRegistros;
        }

        public List<Producto> findAll()
        {
            List<Producto> listaVendedores = new List<Producto>();
            string find = "select*from producto order by nombre asc";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto objProducto = new Producto();
                    objProducto.IdProducto = reader[0].ToString();
                    objProducto.Nombre = reader[1].ToString();
                    objProducto.PrecioUnitario = Convert.ToDouble(reader[2].ToString());
                    objProducto.Categoria = reader[3].ToString();
                    listaVendedores.Add(objProducto);
                }

            }
            catch (Exception)
            {
                Producto objProducto2 = new Producto();
                objProducto2.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }

            return listaVendedores;
        }

        public void update(Producto objProducto)
        {
            string update = "update producto set  nombre='" + objProducto.Nombre + "',precioUnitario='" + objProducto.PrecioUnitario + "',idCategoria='" + objProducto.Categoria + "' where idProducto='" + objProducto.IdProducto + "'";
            try
            {
                comando = new SqlCommand(update, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objProducto.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public bool findProductoPorCategoriaId(Producto objProducto)
        {
            bool hayRegistros;
            string find = "select*from producto where IdCategoria='" + objProducto.Categoria + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objProducto.Estado = 99;
                }
                else
                {
                    objProducto.Estado = 1;
                }
            }
            catch (Exception u)
            {
                throw;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
            return hayRegistros;
        }

        public List<Producto> findAllProductos(Producto objProducto)
        {
            List<Producto> listaProductos = new List<Producto>();
            //string findAll = "select*from cliente where nombre='" + objCLiente.Nombre + "' or dni='" + objCLiente.Dni + "' or idCliente=" + objCLiente.IdCliente + " or apPaterno='" + objCLiente.Appaterno + "'";
            string findAll = "select* from producto where nombre like '%" + objProducto.Nombre + "%' or idProducto like '%" + objProducto.IdProducto + "%' or idCategoria like '%" + objProducto.Categoria + "%'";
            try
            {
                comando = new SqlCommand(findAll, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto objProductos = new Producto();
                    objProductos.IdProducto = reader[0].ToString();
                    objProductos.Nombre = reader[1].ToString();
                    objProductos.PrecioUnitario = Convert.ToDouble(reader[2].ToString());
                    objProductos.Categoria = reader[3].ToString();
                    listaProductos.Add(objProductos);

                }
            }
            catch (Exception)
            {

                objProducto.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }

            return listaProductos;

        }
        public List<Producto> findAllProductosPorCategoria(Producto objProducto)
        {
            List<Producto> listaProductos = new List<Producto>();
            string findAll = "select*from producto where idCategoria='" + objProducto.Categoria + "'";

            //string findAll = "sp_producto_categoria " + objProducto.Categoria;
            try
            {
                comando = new SqlCommand(findAll, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto objProductos = new Producto();
                    objProductos.IdProducto = reader[0].ToString();
                    objProductos.Nombre = reader[1].ToString();
                    objProductos.PrecioUnitario = Convert.ToDouble(reader[2].ToString());
                    objProductos.Categoria = reader[3].ToString();

                    listaProductos.Add(objProductos);

                }
            }
            catch (Exception)
            {

                objProducto.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }

            return listaProductos;

        }

        public List<Producto> findPrecioProducto(Producto objProductos)
        {
            List<Producto> listaVendedores = new List<Producto>();
            string find = "select*from producto where idProducto='"+ objProductos.IdProducto + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Producto objProducto = new Producto();
                    objProducto.IdProducto = reader[0].ToString();
                    objProducto.Nombre = reader[1].ToString();
                    objProducto.PrecioUnitario = Convert.ToDouble(reader[2].ToString());
                    objProducto.Categoria = reader[3].ToString();
                    listaVendedores.Add(objProducto);
                }

            }
            catch (Exception)
            {
                Producto objProducto2 = new Producto();
                objProducto2.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }

            return listaVendedores;
        }

    }
}
