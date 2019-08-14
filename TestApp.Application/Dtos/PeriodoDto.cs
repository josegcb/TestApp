using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using Library;
using Library.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Dtos {
    [AutoMapFrom(typeof(Periodo))]
    public class PeriodoDown : EntityDto , ICustomValidate {       
        public int TenantId { get; set; }

        public int TipoNumeracionId { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [MaxLength(200, ErrorMessage = "Longitud Maxima 200")]        
       
        public string Nombre { get; set; }

        [Display(Name = "Fecha De Apertura")]
        [Required]
        public DateTime FechaDeApertura { get; set; }

        [Display(Name = "Fecha De Cierre")]
        [Required]
        public DateTime FechaDeCierre { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }


        public void AddValidationErrors(CustomValidationContext context) {
            if (FechaDeApertura > FechaDeCierre) {
                context.Results.Add(new ValidationResult("la fecha de cierre no puede ser menor que la fecha de apertura", new List<string>() { "Fecha de Apertura", "Fecha de Cierre" }));
            }
            DateTime vTmp = FechaDeApertura.AddYears(1);
            if (vTmp < FechaDeCierre) {
                context.Results.Add(new ValidationResult("El periodo no puede ser mayor a un año ", new List<string>() { "Fecha de Apertura", "Fecha de Cierre" }));
            }
        }
    }

    public class PeriodoUp : PeriodoDown , ICustomValidate {
        [Display(Name = "Tenant Name")]
        public virtual string TenantName { get; set; }

        [Display(Name = "Tenant ConnectionString")]
        public virtual string TenantConnectionString { get; set; }

        [Display(Name = "TipoNumeracion Nombre")]
        public virtual string TipoNumeracionNombre { get; set; }
    }

    public class PeriodoPk : EntityDto {        
    }

    public class PeriodoDelete : EntityDto {
        public Byte[] TimeStamp { get; set; }
    }





}
