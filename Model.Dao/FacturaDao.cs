using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entity;
using System.Data.SqlClient;

namespace Model.Dao
{
    public class FacturaDao
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public FacturaDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }

        public string create(Factura objFactura)
        {
            string codigoFactura = "";
            string create = "insert into factura (fecha,IVA,total,numPago)values('" + objFactura.Fecha + "','" + objFactura.Iva + "','" + objFactura.Total + "','" + objFactura.NumPago + "') SELECT SCOPE_IDENTITY();";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    codigoFactura = reader[0].ToString();
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
            return codigoFactura;
        }

        public void delete(Factura objFactura)
        {
            string delete = "delete from factura where numFactura='" + objFactura.NumFactura + "'";
            try
            {
                comando = new SqlCommand(delete, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objFactura.Estado = 1;
               
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }

        public bool find(Factura objFactura)
        {
            bool hayRegistros;
            string find = "select * from factura where numFactura='" + objFactura.NumFactura + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader= comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objFactura.Fecha =  reader[1].ToString();
                    objFactura.Iva = Convert.ToDouble(reader[2].ToString());
                    objFactura.Total = Convert.ToDouble(reader[3].ToString());
                    objFactura.NumPago = Convert.ToInt32(reader[4].ToString());

                    objFactura.Estado = 99;
                }
                else
                {
                    objFactura.Estado = 1;
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

        public List<Factura> findAll()
        {
            List<Factura> listaFacturas = new List<Factura>();
            string findAll = "select * from factura";
            try
            {
                comando = new SqlCommand(findAll, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();                
                while (reader.Read())
                {
                    Factura objFactura = new Factura();
                    objFactura.NumFactura= Convert.ToInt64(reader[0].ToString());
                    objFactura.Fecha = reader[1].ToString();
                    objFactura.Iva = Convert.ToDouble(reader[2].ToString());
                    objFactura.Total = Convert.ToDouble(reader[3].ToString());
                    objFactura.NumPago = Convert.ToInt32(reader[4].ToString());
                    listaFacturas.Add(objFactura);
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
            return listaFacturas;
        }

        public void update(Factura objFactura)
        {
            string update = "update  factura set fecha='" + objFactura.Fecha + "',IVA='" + objFactura.Iva + "',total='" + objFactura.Total + "',numPago='" + objFactura.NumPago + "' where numFactura='" + objFactura.NumFactura + "'";
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

        public bool findFacturaPorNumPago(Factura objFactura)
        {
            bool hayRegistros;
            string find = "select * from factura where numPago=" + objFactura.NumPago;
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objFactura.Estado = 99;
                }
                else
                {
                    objFactura.Estado = 1;
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

    }
}
