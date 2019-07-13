using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.DataFilters {

    public interface IHavePeriodo {
        int PeriodoId { get; set; }
    }

    public class DataFilterPeriodo: IDataFilter {
        public string FilterName => "Periodo";

        public string ParameterName => "PeriodoId";

        public object ParameterValue { get; set;  }
    }

    

}
