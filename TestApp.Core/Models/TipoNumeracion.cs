using Abp.Domain.Entities;
using Library.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models {
    [Table("TipoNumeracion")]
    public class TipoNumeracion : Entity {
        [Index("U_TipoNumeracionNombre",IsUnique = true,Order =1)]
        [Varchar]
        [MaxLength(200)]
        [Required]
        public string Nombre { get; set; }

        [Timestamp]
        public Byte[] TimeStamp { get; set; }
    }
}
