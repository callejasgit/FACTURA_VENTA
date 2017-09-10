using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Dao;
using Model.Entity;

namespace Model.Neg
{    
   public class VendedorNeg
    {
        private VendedorDao objVendedorDao;
        private VentaDao objVentaDao;
        public VendedorNeg()
        {
            objVendedorDao = new VendedorDao();
            objVentaDao = new VentaDao();
        }

        public void create(Vendedor objVendedor)
        {
            bool verificaciion = true;

            //inicio verificacion de idVendedor estado=1
            string codigo = objVendedor.IdVendedor;
            if (codigo == null)
            {
                objVendedor.Estado = 10;
                return;
            }else
            {
                codigo = objVendedor.IdVendedor.Trim();
                verificaciion = codigo.Length > 0 && codigo.Length <= 5;
                if (!verificaciion)
                {
                    objVendedor.Estado = 1;
                    return;
                }
            }
            //fin verificacion de idVendedor

            //inicio verificacion de nombre estado=2
            string nombre = objVendedor.Nombre;
            if (nombre == null)
            {
                objVendedor.Estado = 20;
                return;
            }
            else
            {
                nombre = objVendedor.Nombre.Trim();
                verificaciion = nombre.Length > 0 && nombre.Length <= 30;
                if (!verificaciion)
                {
                    objVendedor.Estado = 2;
                    return;
                }
            }
            //fin verificacion de nombre

            //inicio verificacion de apPaterno estado=3
            string apaterno = objVendedor.Appaterno;
            if (apaterno == null)
            {
                objVendedor.Estado = 30;
                return;
            }
            else
            {
                apaterno = objVendedor.Appaterno.Trim();
                verificaciion = apaterno.Length > 0 && apaterno.Length <= 30;
                if (!verificaciion)
                {
                    objVendedor.Estado = 3;
                    return;
                }
            }
            //fin verificacion de apPaterno

            //inicio verificacion de apMaterno estado=4
            string amaterno = objVendedor.Apmaterno;
            if (amaterno == null)
            {
                objVendedor.Estado = 40;
                return;
            }
            else
            {
                amaterno = objVendedor.Apmaterno.Trim();
                verificaciion = amaterno.Length > 0 && amaterno.Length <= 30;
                if (!verificaciion)
                {
                    objVendedor.Estado = 4;
                    return;
                }
            }
            //fin verificacion de apMaterno

            //inicio verificacion de dni estado=5
            string dni = objVendedor.Dni;
            if (dni == null)
            {
                objVendedor.Estado = 50;
                return;
            }
            else
            {
                dni = objVendedor.Dni.Trim();
                verificaciion = dni.Length > 0 && dni.Length <= 8;
                if (!verificaciion)
                {
                    objVendedor.Estado = 5;
                    return;
                }
            }
            //fin verificacion de dni

            //inicio verificacion de teelfono estado=6
            string tel = objVendedor.Telefono;
            if (tel == null)
            {
                objVendedor.Estado = 60;
                return;
            }
            else
            {
                tel = objVendedor.Telefono.Trim();
                verificaciion = tel.Length > 0 && tel.Length <= 30;
                if (!verificaciion)
                {
                    objVendedor.Estado = 6;
                    return;
                }
            }
            //fin verificacion de telefono

            //inicio verificacion de duplicidad estado=7
            Vendedor objVendedorAux = new Vendedor();
            objVendedorAux.IdVendedor = objVendedor.IdVendedor;
            verificaciion = !objVendedorDao.find(objVendedorAux);
            if (!verificaciion)
            {
                objVendedor.Estado = 7;
                return;
            }
            //fin verificacion de duplicidad

            //todo bien
            objVendedor.Estado = 99;
            objVendedorDao.create(objVendedor);
            return;

        }

        public void update(Vendedor objVendedor)
        {
            bool verificaciion = true;
            
            //inicio verificacion de nombre estado=2
            string nombre = objVendedor.Nombre;
            if (nombre == null)
            {
                objVendedor.Estado = 20;
                return;
            }
            else
            {
                nombre = objVendedor.Nombre.Trim();
                verificaciion = nombre.Length > 0 && nombre.Length <= 30;
                if (!verificaciion)
                {
                    objVendedor.Estado = 2;
                    return;
                }
            }
            //fin verificacion de nombre

            //inicio verificacion de apPaterno estado=3
            string apaterno = objVendedor.Appaterno;
            if (apaterno == null)
            {
                objVendedor.Estado = 30;
                return;
            }
            else
            {
                apaterno = objVendedor.Appaterno.Trim();
                verificaciion = apaterno.Length > 0 && apaterno.Length <= 30;
                if (!verificaciion)
                {
                    objVendedor.Estado = 3;
                    return;
                }
            }
            //fin verificacion de apPaterno

            //inicio verificacion de apMaterno estado=4
            string amaterno = objVendedor.Apmaterno;
            if (amaterno == null)
            {
                objVendedor.Estado = 40;
                return;
            }
            else
            {
                amaterno = objVendedor.Apmaterno.Trim();
                verificaciion = amaterno.Length > 0 && amaterno.Length <= 30;
                if (!verificaciion)
                {
                    objVendedor.Estado = 4;
                    return;
                }
            }
            //fin verificacion de apMaterno

            //inicio verificacion de dni estado=5
            string dni = objVendedor.Dni;
            if (dni == null)
            {
                objVendedor.Estado = 50;
                return;
            }
            else
            {
                dni = objVendedor.Dni.Trim();
                verificaciion = dni.Length > 0 && dni.Length <= 8;
                if (!verificaciion)
                {
                    objVendedor.Estado = 5;
                    return;
                }
            }
            //fin verificacion de dni

            //inicio verificacion de teelfono estado=6
            string tel = objVendedor.Telefono;
            if (tel == null)
            {
                objVendedor.Estado = 60;
                return;
            }
            else
            {
                tel = objVendedor.Telefono.Trim();
                verificaciion = tel.Length > 0 && tel.Length <= 30;
                if (!verificaciion)
                {
                    objVendedor.Estado = 6;
                    return;
                }
            }
            //fin verificacion de telefono

            //todo bien
            objVendedor.Estado = 99;
            objVendedorDao.update(objVendedor);
            return;

        }

        public void delete(Vendedor objVendedor)
        {
            bool verificacion = true;
            //verificacion de existencia
            Vendedor objVendedorAux = new Vendedor();
            objVendedorAux.IdVendedor = objVendedor.IdVendedor;
            verificacion = objVendedorDao.find(objVendedorAux);
            if (!verificacion)
            {
                objVendedor.Estado = 33;
                return;
            }

            //verificaicon de existencia de Ventas
            Venta objVenta = new Venta();
            objVenta.IdVendedor = objVendedor.IdVendedor;
            verificacion = !objVentaDao.findVentaPorVendedorId(objVenta);
            if (!verificacion)
            {
                objVendedor.Estado = 34;
                return;
            }

            objVendedor.Estado = 99;
            objVendedorDao.delete(objVendedor);
            return;
        }

        public bool find(Vendedor objVendedor)
        {
            return objVendedorDao.find(objVendedor);
        }

        public List<Vendedor> findAll()
        {
            return objVendedorDao.findAll();
        }

    }
}
