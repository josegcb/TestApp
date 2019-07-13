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
    [AutoMapFrom(typeof(TipoNumeracion))]
    public class TipoNumeracionDown : EntityDto, ICustomValidate {
        [Required]
        [Display(Name = "Descripción")]
        [MaxLength(200, ErrorMessage = "Longitud Maxima 200")]        
       
        public string Nombre { get; set; }
        
        [Timestamp]
        public Byte[] TimeStamp { get; set; }

        public void AddValidationErrors(CustomValidationContext context) {
            if (Nombre.Length < 5) {
                context.Results.Add(new ValidationResult("El Nombnre tiene que ser mayor a 5 caracteres"));
            }
        }
    }

    public class TipoNumeracionUp : TipoNumeracionDown {
        
    }

    public class TipoNumeracionDelete : EntityDto {
        public Byte[] TimeStamp { get; set; }
    }

    public class TipoNumeracionPk : EntityDto {        
    }

    

   

}
