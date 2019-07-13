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
using TestApp.EntityFramework.Repositories;
using TestApp.Managers.Interface;
using TestApp.Models;


namespace TestApp.Managers {

    public class PeriodoManager<T> : ManagerBase<Periodo> {
        
        public PeriodoManager(ITestAppGenericRepository<Periodo> initRepository) : base(initRepository) {
        }
    }
}
