using Abp.Application.Services;
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
    public class CuentaAppService : AppServiceBase<Cuenta, CuentaDown, CuentaUp, CuentaDelete, CuentaPk>, ICuentaAppService {
        public CuentaAppService(IManagerBase<Cuenta> initManager) : base(initManager) {
        }

        public bool CambiarNaturalezaDeLaCuenta(CuentaActualizarNaturalezaDto valCuenta) {
            Cuenta vRecord = MapToEntity<CuentaActualizarNaturalezaDto>(valCuenta);
            ((ICuentaManager)_Manager).ActualizarNaturaleza(vRecord);
            return true;
        }
    }
}
