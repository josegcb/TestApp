using Library.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Models {
    public enum eNaturalezaDeLaCuenta {
        [EnumDescription("DEBE")]
        Debe =0,

        [EnumDescription("HABER")]
        Haber
    }
}
