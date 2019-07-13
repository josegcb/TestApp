using Abp.Domain.Entities;
using Library.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.MultiTenancy;

namespace TestApp.Models {
    [Table("Periodo")]
    public class Periodo : Entity, IMustHaveTenant {

        [Index("U_Periodo", 0, IsUnique = true)]
        public int TenantId { get; set; }

        public int TipoNumeracionId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [Index("U_Periodo", 1, IsUnique = true)]
        [Varchar]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Display(Name = "Fecha De Apertura")]
        [Required]
        public DateTime FechaDeApertura { get; set; }

        [Display(Name = "Fecha De Cierrre")]
        [Required]
        public DateTime FechaDeCierrre { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("TipoNumeracionId")]
        public virtual TipoNumeracion TipoNumeracion { get; set; }


    }
}
