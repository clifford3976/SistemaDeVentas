using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    [Serializable]
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public int ClienteId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal Abono { get; set; }
        public decimal Monto { get; set; }
        public decimal Devuelta { get; set; }

        public virtual List<FacturasDetalles> Detalles { get; set; }


        public Facturas()
        {
            FacturaId = 0;
            ClienteId = 0;
            SubTotal = 0;
            Total = 0;
            Abono = 0;
            Monto = 0;
            Devuelta = 0;
            this.Detalles = new List<FacturasDetalles>();
        }

        public void AgregarDetalle(int id, int facturaId, int ropaId, int cantidad, int precio, int importe)
        {
            this.Detalles.Add(new FacturasDetalles(id, facturaId, ropaId, cantidad, precio, importe));
        }

    }
}
