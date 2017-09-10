using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Model.Entity;

namespace Model.Dao
{
    public class DetalleVentaDao
    {
        private ConexionDB objConexionDB;
        private SqlCommand comando;
        private SqlDataReader reader;
        public DetalleVentaDao()
        {
            objConexionDB = ConexionDB.saberEstado();
        }

        public void create(DetalleVenta objDetalleVenta)
        {
            string create = "insert into detalleVenta values('" + objDetalleVenta.NumFacura + "','" + objDetalleVenta.IdVenta + "','" + objDetalleVenta.SubTotal + "','" + objDetalleVenta.IdProducto + "','" + objDetalleVenta.Descuento + "','" + objDetalleVenta.Cantidad + "')";
            try
            {
                comando = new SqlCommand(create, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                objDetalleVenta.Estado = 1;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }
        }
        public void delete(DetalleVenta objDetalleVenta)
        {
            string delete = "delete from detalleVenta where idVenta='"+ objDetalleVenta.IdVenta+ "'and numFactura='"+ objDetalleVenta.NumFacura+ "'";
            try
            {
                comando = new SqlCommand(delete, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                objDetalleVenta.Estado=1000;
            }
            finally
            {
                objConexionDB.getCon().Close();
                objConexionDB.closeDB();
            }

        }
        public bool findPorNumFactura(DetalleVenta objDetalleVenta)
        {
            bool hayRegistros;
            string find = "select*from detalleVenta where numFactura='" + objDetalleVenta.NumFacura + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objDetalleVenta.Estado = 99;
                }
                else
                {
                    objDetalleVenta.Estado = 1;
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
        public bool find(DetalleVenta objDetalleVenta)
        {
            bool hayRegistros;
            string find = "select*from detalleVenta where idDetalle='" + objDetalleVenta.IdDetalleVenta + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objDetalleVenta.NumFacura=Convert.ToInt64(reader[1].ToString());
                    objDetalleVenta.IdVenta= Convert.ToInt64(reader[2].ToString());
                    objDetalleVenta.SubTotal = Convert.ToDouble(reader[3].ToString());
                    objDetalleVenta.IdProducto = reader[4].ToString();
                    objDetalleVenta.Descuento = Convert.ToDouble(reader[5].ToString());
                    objDetalleVenta.Cantidad = Convert.ToInt32(reader[6].ToString());

                    objDetalleVenta.Estado = 99;
                }else
                {
                    objDetalleVenta.Estado = 1;
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
        public List<DetalleVenta> findAll()
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            string findAll = "select*from detalleVenta";
            try
            {
                comando = new SqlCommand(findAll, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
               
                while (reader.Read())
                {
                    DetalleVenta objDetalleVenta = new DetalleVenta();
                    objDetalleVenta.IdDetalleVenta = Convert.ToInt64(reader[0].ToString());
                    objDetalleVenta.NumFacura = Convert.ToInt64(reader[1].ToString());
                    objDetalleVenta.IdVenta = Convert.ToInt64(reader[2].ToString());
                    objDetalleVenta.SubTotal = Convert.ToDouble(reader[3].ToString());
                    objDetalleVenta.IdProducto = reader[4].ToString();
                    objDetalleVenta.Descuento = Convert.ToDouble(reader[5].ToString());
                    objDetalleVenta.Cantidad = Convert.ToInt32(reader[6].ToString());
                    lista.Add(objDetalleVenta);
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

            return lista;
        }
        public bool findPorIdVenta(DetalleVenta objDetalleVenta)
        {
            bool hayRegistros;
            string find = "select*from detalleVenta where idVenta='" + objDetalleVenta.IdVenta + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objDetalleVenta.Estado = 99;
                }
                else
                {
                    objDetalleVenta.Estado = 1;
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
        public bool findDetalleVentaPorProductoId(DetalleVenta objDetalleVenta)
        {
            bool hayRegistros;
            string find = "select*from detalleVenta where idProducto='" + objDetalleVenta.IdProducto + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                SqlDataReader reader = comando.ExecuteReader();
                hayRegistros = reader.Read();
                if (hayRegistros)
                {
                    objDetalleVenta.Estado = 99;
                }
                else
                {
                    objDetalleVenta.Estado = 1;
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
        public List<DetalleVenta> detallesPorIdVenta(DetalleVenta objDetalleVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();


            string find = "select*from detalleVenta where idVenta='" + objDetalleVenta.IdVenta + "'";
            try
            {
                comando = new SqlCommand(find, objConexionDB.getCon());
                objConexionDB.getCon().Open();
                reader = comando.ExecuteReader();
                
                while (reader.Read())
                {                    
                    DetalleVenta objDetalleVentas = new DetalleVenta();
                    objDetalleVentas.IdDetalleVenta = Convert.ToInt64(reader[0].ToString());
                    objDetalleVentas.NumFacura = Convert.ToInt64(reader[1].ToString());
                    objDetalleVentas.IdVenta = Convert.ToInt64(reader[2].ToString());
                    objDetalleVentas.SubTotal = Convert.ToDouble(reader[3].ToString());
                    objDetalleVentas.IdProducto = reader[4].ToString();
                    objDetalleVentas.Descuento = Convert.ToDouble(reader[5].ToString());
                    objDetalleVentas.Cantidad = Convert.ToInt32(reader[6].ToString());

                    lista.Add(objDetalleVentas);
                    
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

            return lista ;
        }

    }
}
