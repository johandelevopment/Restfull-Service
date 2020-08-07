using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines
{
   public class BCategoria
    {
        public static Resultado GetCategories()
        {
           var query = new DCategoria().GetCategories();
            List<ECategoria> CategoriesList = new List<ECategoria>();
            foreach(var item in query)
            {
                ECategoria categoria = new ECategoria
                {
                    Id = item.id_Categoria,
                    Name = item.descripcion
                };
                CategoriesList.Add(categoria);
            }

            if (CategoriesList.Count > 0)
            {
                return new Resultado() { Respuesta = 1, Mensaje = "Categorias encontradas.", Valores = CategoriesList };
            }
            return new Resultado() { Respuesta = 0, Mensaje = "No se encontraron categorias.", Valores = null };
        }
    }
}
