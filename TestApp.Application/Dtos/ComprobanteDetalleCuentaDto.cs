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
    [AutoMapFrom(typeof(ComprobanteDetalleCuenta))]
    public class ComprobanteDetalleCuentaDown : EntityDto, ICustomValidate {

        public int ComprobanteId { get; set; }

        public int CuentaId { get; set; }

        [Required]
        [Display(Name = "Descripción")]        
        [MaxLength(300)]
        public string Descripcion { get; set; }

        [Display(Name = "Fecha")]
        [Required]
        public DateTime Fecha { get; set; }

        [Display(Name = "Monto Debe")]
        [Decimal(18, 5)]

        public decimal MontDebe { get; set; }

        [Display(Name = "Monto Haber")]
        [Decimal(18, 5)]

        public decimal MontoHaber { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        public void AddValidationErrors(CustomValidationContext context) {

        }
    }

    public class ComprobanteDetalleCuentaUp : ComprobanteDetalleCuentaDown {

        [Display(Name = "Cuenta Codigo")]
        public virtual string CuentaCodigo { get; set; }

        [Display(Name = "Cuenta Descripción")]
        public virtual string CuentaDescripcion { get; set; }
    }

    public class ComprobanteDetalleCuentaDelete : EntityDto {
        public Byte[] TimeStamp { get; set; }
    }

    public class ComprobanteDetalleCuentaPk : EntityDto {

    }
}
