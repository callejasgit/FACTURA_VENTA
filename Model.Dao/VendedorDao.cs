using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class VendedorDao : Obligatorio<Vendedor>
    {
        private  ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public VendedorDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }
        public void create(Vendedor objVendedor)
        {
            string create = "insert into vendedor values('"+ objVendedor.IdVendedor+ "','" + objVendedor.Nombre + "','" + objVendedor.Appaterno + "','" + objVendedor.Apmaterno + "','" + objVendedor.Dni + "','" + objVendedor.Telefono + "')";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
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
        }

        public void delete(Vendedor objVendedor)
        {
            string delete = "delete from vendedor where idVendedor='" + objVendedor.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(delete, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
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
        }

        public bool find(Vendedor objVendedor)
        {
            bool hayRegistros;
            string find = "select*from vendedor where idVendedor='" + objVendedor.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objVendedor.Nombre = reader[1].ToString();
                    objVendedor.Appaterno = reader[2].ToString();
                    objVendedor.Apmaterno = reader[3].ToString();
                    objVendedor.Dni = reader[4].ToString();
                    objVendedor.Telefono = reader[5].ToString();
                    objVendedor.Estado = 99;
                }else
                {
                    objVendedor.Estado = 1;
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

        public List<Vendedor> findAll()
        {
            List<Vendedor> listaVendedores = new List<Vendedor>();
            string find = "select*from vendedor order by nombre asc,apMaterno asc,apPaterno asc";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();                
                while (reader.Read())
                {
                    Vendedor objVendedor = new Vendedor();
                    objVendedor.IdVendedor = reader[0].ToString();
                    objVendedor.Nombre = reader[1].ToString();
                    objVendedor.Appaterno = reader[2].ToString();
                    objVendedor.Apmaterno = reader[3].ToString();
                    objVendedor.Dni = reader[4].ToString();
                    objVendedor.Telefono = reader[5].ToString();
                    listaVendedores.Add(objVendedor);
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

            return listaVendedores;
        }

        public void update(Vendedor objVendedor)
        {
            string update = "update vendedor set  nombre='" + objVendedor.Nombre + "',apPaterno='" + objVendedor.Appaterno + "',apMaterno='" + objVendedor.Apmaterno + "',dni='" + objVendedor.Dni + "',telefono='" + objVendedor.Telefono + "' where idVendedor='" + objVendedor.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(update, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
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
        }
    }
}
