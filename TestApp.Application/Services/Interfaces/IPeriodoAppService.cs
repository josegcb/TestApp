using Abp.Application.Services;
using Abp.Dependency;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Dtos;
using TestApp.Models;

namespace TestApp.Services.Interfaces {

    public interface IPeriodoAppService : IAppServiceBase<Periodo, PeriodoDown, PeriodoUp, PeriodoDelete, PeriodoPk>, IApplicationService {
        PeriodoUp EscogerPeriodoActual(int valPeriodoId);

    }

}
