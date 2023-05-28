using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad18.Shared.Modelos
{
    public class Productos
    {
        public int Id { get; set; }
        public string? nombre { get; set; }
        public string? categoria { get; set; }
        public int? precio { get; set; }
        public int? VentasId { get; set; }
        public virtual Ventas? Ventas { get; set; }
    }
}
