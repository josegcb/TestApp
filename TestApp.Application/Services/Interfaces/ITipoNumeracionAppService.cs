using Abp.Application.Services;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Dtos;
using TestApp.Models;

namespace TestApp.Services.Interfaces {

    public interface ITipoNumeracionAppService : IAppServiceBase<TipoNumeracion, TipoNumeracionDown, TipoNumeracionUp, TipoNumeracionDelete, TipoNumeracionPk>, IApplicationService {
    }    
}
