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
    [Table("Cuenta")]
    public class Cuenta : Entity, IMustHaveTenant, IHavePeriodo {

        [Index("U_Cuenta", 0, IsUnique = true)]
        public int PeriodoId { get; set; }

        public int TenantId { get; set; }

        [Required]
        [Display(Name = "Codigo")]
        [Index("U_Cuenta", 1, IsUnique = true)]
        [Varchar]
        [MaxLength(30)]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [Varchar]
        [MaxLength(300)]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Es Titulo")]
        public bool EsTitulo { get; set; }

        [Required]
        [Display(Name = "Naturaleza De La Cuenta")]
        public eNaturalezaDeLaCuenta Naturaleza { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        [ForeignKey("TenantId")]
        public virtual Tenant Tenant { get; set; }

        [ForeignKey("PeriodoId")]
        public virtual Periodo Periodo { get; set; }

    }
}
