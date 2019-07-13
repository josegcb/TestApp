using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library {
    public interface IDataFilter {
        string FilterName { get; }
        string ParameterName { get; }

        object ParameterValue { get; set; }

    }
}
