using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Library.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Dtos {
    [AutoMapFrom(typeof(Comprobante))]

    public class ComprobanteBase : EntityDto, ICustomValidate {

        public int PeriodoId { get; set; }
        public int TenantId { get; set; }

        [Required]
        [Display(Name = "Numero")]
        [MaxLength(30)]
        public string Numero { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(300)]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [Display(Name = "Total Debe")]
        [Decimal(18, 5)]

        public decimal TotalDebe { get; set; }

        [Display(Name = "Total Haber")]
        [Decimal(18, 5)]

        public decimal TotalHaber { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }
        

        public void AddValidationErrors(CustomValidationContext context) {
            
        }
    }

    public class ComprobanteDown : ComprobanteBase {
        public ICollection<ComprobanteDetalleCuentaDown > ComprobanteDetalleCuenta { get; set; }
        
    }

    public class ComprobanteUp : ComprobanteBase {        
      
        [Display(Name = "Perido Nombre")]
        public virtual string PeriodoNombre { get; set; }

        public ICollection<ComprobanteDetalleCuentaUp> ComprobanteDetalleCuenta { get; set; }
    }

    public class ComprobanteDelete : EntityDto {
        public Byte[] TimeStamp { get; set; }
    }

    public class ComprobantePk : EntityDto {

    }
}
