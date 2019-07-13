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
using TestApp.MultiTenancy;

namespace TestApp.Models {
    [Table("Comprobante")]
    public class Comprobante : Entity, IMustHaveTenant, IHavePeriodo {

        [Index("U_Comprobante", 0, IsUnique = true)]
        public int PeriodoId { get; set; }

        public int TenantId { get; set; }

        [Required]
        [Display(Name = "Numero")]
        [Index("U_Comprobante", 1, IsUnique = true)]
        [Varchar]
        [MaxLength(30)]
        public string Numero { get; set; }

        [Required]
        [Display(Name = "Descripción")]        
        [Varchar]
        [MaxLength(300)]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [Display(Name = "Total Debe")]
        [Decimal(18,5)]
        
        public decimal  TotalDebe { get; set; }

        [Display(Name = "Total Haber")]
        [Decimal(18, 5)]

        public decimal TotalHaber { get; set; }

        public ICollection<ComprobanteDetalleCuenta> ComprobanteDetalleCuenta { get; set; }        

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("PeriodoId")]
        public virtual Periodo Periodo { get; set; }
    }
}
