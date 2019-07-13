using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.UI;
using Library.Repositories;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Managers.Interface;
using TestApp.Models;

namespace TestApp.Managers {
    public class TipoNumeracionManager<T> : ManagerBase<TipoNumeracion> {
        public TipoNumeracionManager(ITestAppGenericRepository<TipoNumeracion> initRepository) : base(initRepository) {
        }
    }
}
