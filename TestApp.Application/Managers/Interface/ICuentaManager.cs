using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Models;

namespace TestApp.Managers.Interface {
    public interface ICuentaManager {
        bool ActualizarNaturaleza(Cuenta valRecord);        
    }
}
