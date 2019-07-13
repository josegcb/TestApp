using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Attributes {
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class DecimalAttribute : Attribute {
        public DecimalAttribute(byte precision, byte scale) {
            Precision = precision;
            Scale = scale;

        }

        public byte Precision { get; set; }
        public byte Scale { get; set; }

    }
}
