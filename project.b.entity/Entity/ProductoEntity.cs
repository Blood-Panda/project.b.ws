using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.entity.Entity
{
    public class ProductoEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public TipoEntity tipo { get; set; }
        public PaisEntity pais { get; set; }
        public double precio { get; set; }
    }
}
