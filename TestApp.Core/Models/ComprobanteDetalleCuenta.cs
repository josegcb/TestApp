using Abp.Domain.Entities;
using Library.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.DataFilters;

namespace TestApp.Models {
    [Table("ComprobanteDetalleCuenta")]
    public class ComprobanteDetalleCuenta : Entity {

        public int ComprobanteId { get; set; }

        public int CuentaId { get; set; }
        
        [Required]
        [Display(Name = "Descripción")]        
        [Varchar]
        [MaxLength(300)]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [Display(Name = "Monto Debe")]
        [Decimal(18,5)]
        
        public decimal  MontoDebe { get; set; }

        [Display(Name = "Monto Haber")]
        [Decimal(18, 5)]

        public decimal MontoHaber { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }


        [ForeignKey("ComprobanteId")]
        public virtual Comprobante Comprobante { get; set; }


        [ForeignKey("CuentaId")]
        public virtual Cuenta Cuenta { get; set; }
    }
}
