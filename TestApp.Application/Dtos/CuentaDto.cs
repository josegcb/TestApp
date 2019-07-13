using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Runtime.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Dtos {
    [AutoMapFrom(typeof(Cuenta))]
    public class CuentaDown : EntityDto, ICustomValidate {

        public int TenantId { get; set; }

        public int PeriodoId { get; set; }

        [Required]
        [Display(Name = "Codigo")]      
        [MaxLength(30)]
        public string Codigo { get; set; }

        [Required]
        [Display(Name = "Descripción")]        
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


        public void AddValidationErrors(CustomValidationContext context) {
         
        }
    }

    public class CuentaUp : CuentaDown {
        [Display(Name = "Naturaleza Str")]
        public virtual string NaturalezaStr {
            get {
                return Naturaleza.ToString();
            }
        }

        [Display(Name = "Perido Nombre")]
        public virtual string PeriodoNombre { get; set; }

        [Display(Name = "Tenant Nombre")]
        public virtual string TenantNombre { get; set; }
    }

    public class CuentaDelete : EntityDto {
        public Byte[] TimeStamp { get; set; }
    }

    public class CuentaPk : EntityDto {
        
    }

    public class CuentaActualizarNaturalezaDto : EntityDto {
        [Required]
        [Display(Name = "Naturaleza De La Cuenta")]
        public eNaturalezaDeLaCuenta Naturaleza { get; set; }
        public Byte[] TimeStamp { get; set; }

    }

}
