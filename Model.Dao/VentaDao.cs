using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Dao
{
    public class VentaDao
    {
        private ConexionDB objConexinDB;
        private SqlCommand comando;

        public VentaDao()
        {
            objConexinDB = ConexionDB.saberEstado();

        }
       
        public string create(Venta objVenta)
        {
            string idVenta = "";
            string create = "insert into venta(total,idCliente,idVendedor,fecha,IVA) values('" + objVenta.Total + "','" + objVenta.IdCliente + "','" + objVenta.IdVendedor + "','" + objVenta.Fecha + "','"+objVenta.Iva+ "') SELECT SCOPE_IDENTITY();";
            try
            {
                comando = new SqlCommand(create, objConexinDB.getCon());
                objConexinDB.getCon().Open();

                //RECUPERAR EL CODIGO AUTOGENERADO
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    idVenta = reader[0].ToString();
                }

            }
            catch (Exception e)
            {
                objVenta.Estado = 1;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }
            return idVenta;

        }
        public void update(Venta objVenta)
        {
            string update = "update venta set total='" + objVenta.Total + "',idCliente='" + objVenta.IdCliente + "',idVendedor='" + objVenta.IdVendedor + "',fecha='" + objVenta.Fecha + "',IVA='"+objVenta.Iva+"' where idVenta='" + objVenta.IdVenta + "'";
            try
            {
                comando = new SqlCommand(update, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                objVenta.Estado = 1;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }
        }
        public void delete(Venta objVenta)
        {
            string delete = "delete from venta where idVenta='" + objVenta.IdVenta + "'";
            try
            {
                comando = new SqlCommand(delete, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                objVenta.Estado = 1;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

        }
        public bool find(Venta objVenta)
        {
            bool hayRegistros;
            string find = "select*from venta where idVenta='" + objVenta.IdVenta + "'";
            try
            {
                comando = new SqlCommand(find, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objVenta.Total = Convert.ToDouble(reader[1].ToString());
                    objVenta.IdCliente = Convert.ToInt64(reader[2].ToString());
                    objVenta.IdVendedor = reader[3].ToString();
                    objVenta.Fecha = reader[4].ToString();
                    objVenta.Iva = Convert.ToDouble(reader[5].ToString());
                    objVenta.Estado = 99;

                }
                else
                {
                    objVenta.Estado = 1;
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
        public List<Venta> findAll()
        {
            List<Venta> listaVentas = new List<Venta>();
            string findAll = "select*from Venta";
            try
            {
                comando = new SqlCommand(findAll, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Venta objVenta = new Venta();
                    objVenta.IdVenta= Convert.ToInt64(reader[0].ToString());
                    objVenta.Total = Convert.ToDouble(reader[1].ToString());
                    objVenta.IdCliente = Convert.ToInt64(reader[2].ToString());
                    objVenta.IdVendedor = reader[3].ToString();
                    objVenta.Fecha = reader[4].ToString();
                    objVenta.Iva = Convert.ToDouble(reader[5].ToString());
                    listaVentas.Add(objVenta);

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

            return listaVentas;

        }        
        public bool findVentaPorClienteId(Venta objVenta)
        {
            bool hayRegistros;
            string find = "select*from venta where idCliente='" + objVenta.IdCliente + "'";
            try
            {
                comando = new SqlCommand(find, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {                   
                    objVenta.Estado = 99;
                }
                else
                {
                    objVenta.Estado = 1;
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
        public bool findVentaPorVendedorId(Venta objVenta)
        {
            bool hayRegistros;
            string find = "select*from venta where idVendedor='" + objVenta.IdVendedor + "'";
            try
            {
                comando = new SqlCommand(find, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objVenta.Estado = 99;
                }
                else
                {
                    objVenta.Estado = 1;
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

        public void sp_reporteVenta(Venta objVenta)
        {
            string create = "sp_reporte_venta" + objVenta.IdVenta;
            try
            {
                comando = new SqlCommand(create, objConexinDB.getCon());
                objConexinDB.getCon().Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                objVenta.Estado = 1;
            }
            finally
            {
                objConexinDB.getCon().Close();
                objConexinDB.closeDB();
            }

        }


    }
}
