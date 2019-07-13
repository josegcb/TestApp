using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public class MfcDto {
        public string Key { get; set; }

        public object Value { get; set; }

    }

    public class EnumJson {
        public EnumJson(int initValor, string initDescripcion) {
            Valor = initValor;
            Descripcion = initDescripcion;
        }
        public string Descripcion { get; set; }
        public int Valor { get; set; }
    }
}
