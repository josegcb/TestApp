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
    public class TipoNumeracionAppService : AppServiceBase<TipoNumeracion, TipoNumeracionDown, TipoNumeracionUp, TipoNumeracionDelete, TipoNumeracionPk>, ITipoNumeracionAppService {        

        public TipoNumeracionAppService(IManagerBase<TipoNumeracion> initManager, IIocResolver initIIocResolver) : base(initManager, initIIocResolver) {            
        }

    }
}
