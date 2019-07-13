using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Exceptions {
    public class ConcurrencyException : Exception {

        public ConcurrencyException() : base("El registro fue modificado o eliminado por otro usuario") {

        }

    }//EndClass
}
