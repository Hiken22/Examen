using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exam.Contexto;
using Exam.Models;

namespace Exam.Intreface
{
    public class AccesoDatos : IAccesoDatos<Productos, int>
    {
        Context contexto;
        public AccesoDatos(Context context)
        {
            contexto = context;
        }


        public IEnumerable<Productos> ProductosGet()
        {
            var productos = contexto.productos.ToList();
            return productos;
        }

        public Productos ProductosGetId(int id)
        {
            var productos = contexto.productos.FirstOrDefault(x => x.Id_producto == id);
            return productos;
        }



        public int InsertProductos(Productos model)
        {
            contexto.productos.Add(model);
            int respuesta = contexto.SaveChanges();
            return respuesta;
        }

        public int ActualizarProductos(int id, Productos model)
        {
            int respuesta = 0;
            var productos = contexto.productos.Find(id);
            if (productos != null)
            {
                productos.Nombre = model.Nombre;
                productos.Descripcion = model.Descripcion;
                productos.Precio = model.Precio;
                respuesta = contexto.SaveChanges();
            }
            return respuesta;
        }

        public int EliminarProductos(int id)
        {
            int respuesta = 0;
            var productos = contexto.productos.FirstOrDefault(x => x.Id_producto == id);
            if (productos != null)
            {
                contexto.productos.Remove(productos);
                respuesta = contexto.SaveChanges();
            }
            return respuesta;
        }


    }
    public interface IAccesoDatos<Tmodel, model> where Tmodel : class
    {
        IEnumerable<Tmodel> ProductosGet();
        Tmodel ProductosGetId(model id);
        int InsertProductos(Tmodel value);
        int ActualizarProductos(model id, Tmodel value);
        int EliminarProductos(model id);
    }

}
