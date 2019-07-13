using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public class CustomDateTimeConverter : IsoDateTimeConverter {
        public CustomDateTimeConverter() {
            base.DateTimeFormat = "dd/MM/yyyy";
        }
    }
}
