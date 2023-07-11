using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Modelo;

namespace WindowsFormsApp1.Dato
{
    public class VehiculoAdmin
    {
        public List<vehiculo> Consultar()
        {
            using (Database1Entities contexto = new Database1Entities())
            {
                return contexto.vehiculo.AsNoTracking().ToList();
            }
        }

        public void Guardar(vehiculo modelo)
        {
            using(Database1Entities contexto = new Database1Entities())
            {
                contexto.vehiculo.Add(modelo);
                contexto.SaveChanges();
            }
        }
    }
}
