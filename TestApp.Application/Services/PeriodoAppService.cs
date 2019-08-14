using Abp.Application.Services;
using Abp.Dependency;
using AutoMapper;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Dtos;
using TestApp.Managers.Interface;
using TestApp.Models;
using TestApp.Services.Interfaces;

namespace TestApp.Services {
    public class PeriodoAppService : AppServiceBase<Periodo, PeriodoDown, PeriodoUp, PeriodoDelete, PeriodoPk> , IPeriodoAppService {
        public PeriodoAppService(IManagerBase<Periodo> initManager, IIocResolver initIIocResolver) : base(initManager, initIIocResolver) {
        }

        public PeriodoUp EscogerPeriodoActual(int valPeriodoId) {
            Library.Helpers.ClaimHelper.SetCurrentMFC(new DataFilters.DataFilterPeriodo().FilterName, valPeriodoId);
            return base.Get(new PeriodoPk() { Id = valPeriodoId });
        }

        public override PeriodoUp Create(PeriodoDown valInput) {
            PeriodoUp vResult = base.Create(valInput);
            return EscogerPeriodoActual(vResult.Id);
        }

        public override PeriodoUp Initialize() {
            PeriodoUp vResult = base.Initialize();
            vResult.FechaDeApertura = DateTime.Now.Date;
            vResult.FechaDeCierre  = DateTime.Now.Date;
            return vResult;
        }
    }
}
