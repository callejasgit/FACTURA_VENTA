using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class CategoriaDao:Obligatorio<Categoria>
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public CategoriaDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }
        public void create(Categoria objCategoria)
        {
            string create = "insert into categoria values('" + objCategoria.IdCategoria + "','" + objCategoria.Nombre + "','" + objCategoria.Descripcion + "')";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objCategoria.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public void delete(Categoria objCategoria)
        {
            string delete = "delete from categoria where idCategoria='" + objCategoria.IdCategoria + "'";
            try
            {
                comando = new SqlCommand(delete, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
objCategoria.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public bool find(Categoria objCategoria)
        {
            bool hayRegistros;
            string find = "select*from categoria where idCategoria='" + objCategoria.IdCategoria + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objCategoria.Nombre = reader[1].ToString();
                    objCategoria.Descripcion = reader[2].ToString();

                    objCategoria.Estado = 99;
                }
                else
                {
                    objCategoria.Estado = 1;
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

        public List<Categoria> findAll()
        {
            
            List<Categoria> listaCategorias = new List<Categoria>();
            string find = "select*from categoria";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Categoria objCategoria = new Categoria();
                    objCategoria.IdCategoria = reader[0].ToString();
                    objCategoria.Nombre = reader[1].ToString();
                    objCategoria.Descripcion = reader[2].ToString();

                    listaCategorias.Add(objCategoria);
                }

            }
            catch (Exception)
            {
                //objCategoria.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }

            return listaCategorias;
        }

        public void update(Categoria objCategoria)
        {
            string update = "update categoria set  nombre='" + objCategoria.Nombre + "',descripcion='" + objCategoria.Descripcion + "' where idCategoria='" + objCategoria.IdCategoria + "'";
            try
            {
                comando = new SqlCommand(update, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objCategoria.Estado = 1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }
    }
}
