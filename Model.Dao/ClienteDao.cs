using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using System.Data.SqlClient;

namespace Model.Dao
{    
    public class ClienteDao : Obligatorio<Cliente>
    {
        private ConexionDB objConexinDB;
        private SqlCommand comando;

        public ClienteDao()
        {
            objConexinDB =ConexionDB.saberEstado();

        }
        public void create1(Cliente objCliente)
        {
            string create = "insert into cliente(nombre,apPaterno,apMaterno,dni,direccion,telefono) values('" + objCliente.Nombre + "','" + objCliente.Appaterno + "','" + objCliente.Apmaterno + "','" + objCliente.Dni + "','" + objCliente.Direccion + "','" + objCliente.Telefono + "')";
            try
            {
                comando = new SqlCommand(create, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                objCliente.Estado = 1;                
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

        }
        public void create(Cliente objCliente)
        {
            string create = "sp_cliente_adc " + objCliente.IdCliente + "," + objCliente.Nombre + "," + objCliente.Appaterno + "," + objCliente.Apmaterno + "," + objCliente.Dni + "," + objCliente.Direccion + "," + objCliente.Telefono + "";
            try
            {
                comando = new SqlCommand(create, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                objCliente.Estado = 1;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

        }

        public void delete(Cliente objCliente)
        {
            string delete = "delete from cliente where idCliente='" + objCliente.IdCliente + "'";
            try
            {
                comando = new SqlCommand(delete, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objCliente.Estado=1;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

        }

        public bool find(Cliente objCliente)
        {
            bool hayRegistros;
            string find = "select*from cliente where idCliente='" + objCliente.IdCliente + "'";
            try
            {
                comando = new SqlCommand(find, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                //bool hayRegistros;
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objCliente.Nombre = reader[1].ToString();
                    objCliente.Appaterno = reader[2].ToString();
                    objCliente.Apmaterno = reader[3].ToString();                    
                    objCliente.Direccion = reader[4].ToString();
                    objCliente.Telefono = reader[5].ToString();
                    objCliente.Dni = reader[6].ToString();

                    objCliente.Estado = 99;

                }
                else
                {
                    objCliente.Estado = 1;
                }
            }
            catch (Exception)
            {

                throw;
            }
           finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }
            return hayRegistros;
        }
      
        public List<Cliente> findAll()
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string findAll = "select*from cliente order by nombre asc, apPaterno asc,apMaterno asc";
            try
            {
                comando = new SqlCommand(findAll, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nombre = reader[1].ToString();
                    objCliente.Appaterno = reader[2].ToString();
                    objCliente.Apmaterno = reader[3].ToString();
                    objCliente.Direccion = reader[4].ToString();
                    objCliente.Telefono = reader[5].ToString();
                    objCliente.Dni = reader[6].ToString();
                    listaClientes.Add(objCliente);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

            return listaClientes;           
           
        }

        public void update(Cliente objCliente)
        {
            string update = "update cliente set nombre='" + objCliente.Nombre + "',apPaterno='" + objCliente.Appaterno + "',apMaterno='" + objCliente.Apmaterno + "',dni='" + objCliente.Dni + "',direccion='" + objCliente.Direccion + "',telefono='" + objCliente.Telefono + "' where idCliente='" + objCliente.IdCliente + "'";
            try
            {
                comando = new SqlCommand(update, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                comando.ExecuteNonQuery();                
            }
            catch (Exception e)
            {

                objCliente.Estado=1;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }
        }

        public bool findClientePorDni(Cliente objCliente)
        {
            bool hayRegistros;
            string find = "select*from cliente where dni='"+objCliente.Dni+"'" ;
            try
            {
                comando = new SqlCommand(find, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                //bool hayRegistros;
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objCliente.Nombre = reader[1].ToString();
                    objCliente.Appaterno = reader[2].ToString();
                    objCliente.Apmaterno = reader[3].ToString();
                    
                    objCliente.Direccion = reader[4].ToString();
                    objCliente.Telefono = reader[5].ToString();
                    objCliente.Dni = reader[6].ToString();

                    objCliente.Estado = 99;

                }
                else
                {
                    objCliente.Estado = 1;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }
            return hayRegistros;
        }

        public List<Cliente> findAllCliente(Cliente objCLiente)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            //string findAll = "select*from cliente where nombre='" + objCLiente.Nombre + "' or dni='" + objCLiente.Dni + "' or idCliente=" + objCLiente.IdCliente + " or apPaterno='" + objCLiente.Appaterno + "'";
            string findAll = "select* from cliente where nombre like '%" + objCLiente.Nombre + "%' or dni like '%" + objCLiente.Dni + "%' or idCliente like '%" + objCLiente.IdCliente + "%' or apPaterno like '%" + objCLiente.Appaterno + "%'";
            try
            {
                comando = new SqlCommand(findAll, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente objCliente = new Cliente();
                    objCliente.IdCliente = Convert.ToInt64(reader[0].ToString());
                    objCliente.Nombre = reader[1].ToString();
                    objCliente.Appaterno = reader[2].ToString();
                    objCliente.Apmaterno = reader[3].ToString();
                    objCliente.Direccion = reader[4].ToString();
                    objCliente.Telefono = reader[5].ToString();
                    objCliente.Dni = reader[6].ToString();
                    listaClientes.Add(objCliente);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

            return listaClientes;

        }
    }
}
