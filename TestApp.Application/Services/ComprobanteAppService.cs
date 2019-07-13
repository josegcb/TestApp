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
    public class ComprobanteAppService : AppServiceBase<Comprobante, ComprobanteDown, ComprobanteUp, ComprobanteDelete, ComprobantePk> , IComprobanteAppService {

        readonly IManagerBase<ComprobanteDetalleCuenta> _ManagerDetalleCuenta;
        public ComprobanteAppService(IManagerBase<Comprobante> initManager, IManagerBase<ComprobanteDetalleCuenta> initManagerDetalleCuenta) : base(initManager) {
            _ManagerDetalleCuenta = initManagerDetalleCuenta;
        }
    }
}
