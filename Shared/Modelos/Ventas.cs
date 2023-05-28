using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad18.Shared.Modelos
{
    public class Ventas
    {
        public int Id {  get; set; }

        public int? ClientesId { get; set; }
        public virtual Clientes? Clientes { get; set; }

        public virtual ICollection<Productos>? Productos { get; set; }

        public int Total { get; set; }
        public DateTime Fecha { get; set; }

    }
}
