using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Dao
{
    public class ModoPagoDao:Obligatorio<ModoPago>
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public ModoPagoDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }
        public void create(ModoPago objModoPago)
        {
            string create = "insert into modoPago values('" + objModoPago.Nombre + "','" + objModoPago.Otros + "')";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objModoPago.Estado = 1000; 
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public void delete(ModoPago objModoPago)
        {
            string delete = "delete from modoPago where numPago='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(delete, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objModoPago.Estado = 1000; ;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public bool find(ModoPago objModoPago)
        {
            bool hayRegistros;
            string find = "select*from modoPago where numPago='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objModoPago.Nombre = reader[1].ToString();
                    objModoPago.Otros = reader[2].ToString();

                    objModoPago.Estado = 99;
                }
                else
                {
                    objModoPago.Estado = 1;
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

        public List<ModoPago> findAll()
        {
            List<ModoPago> listaModoPagos = new List<ModoPago>();
            string find = "select*from modoPago";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    ModoPago objModoPago = new ModoPago();
                    objModoPago.NumPago = Convert.ToInt32(reader[0].ToString());
                    objModoPago.Nombre = reader[1].ToString();
                    objModoPago.Otros = reader[2].ToString();

                    listaModoPagos.Add(objModoPago);
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

            return listaModoPagos;
        }

        public void update(ModoPago objModoPago)
        {
            string update = "update modoPago set  nombre='" + objModoPago.Nombre + "',otroDetalles='" + objModoPago.Otros + "' where numPago='" + objModoPago.NumPago + "'";
            try
            {
                comando = new SqlCommand(update, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {

                objModoPago.Estado = 1000; ;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }
    }
}
