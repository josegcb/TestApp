using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Library.Repositories;
using Library.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.DataFilters;
using TestApp.EntityFramework.Repositories;
using TestApp.Managers.Interface;
using TestApp.Models;

namespace TestApp.Managers {
    public class CuentaManager<T> : ManagerBaseMfc<Cuenta>, ICuentaManager {
        public CuentaManager(ITestAppGenericRepository<Cuenta> initRepository) : base(initRepository) {
            _DataFilter = new DataFilterPeriodo();
            _DataFilter.ParameterValue = Library.Helpers.ClaimHelper.GetCurrentMFCOrNull(_DataFilter.FilterName);
        }

        public bool ActualizarNaturaleza(Cuenta valRecord) {
            UpdateProperties(valRecord, p => p.Naturaleza);            
            CurrentUnitOfWork.SaveChanges();            
            return true;
        }


        //public override IEnumerable<Cuenta> GetAll() {
        //   // using (UnitOfWorkManager.Current.SetFilterParameter(DataFilterPeriodo.FilterName, DataFilterPeriodo.ParameterName, new Library.Helpers.ClaimHelper().GetCurrentMFCOrNull(DataFilterPeriodo.FilterName))) {
        //        return _Repository.GetAllIncluding(p => p.Periodo);
        //   // }
        //}

        //public override Cuenta GetById(int valId) {
        //    //using (UnitOfWorkManager.Current.SetFilterParameter(DataFilterPeriodo.FilterName, DataFilterPeriodo.ParameterName, new Library.Helpers.ClaimHelper().GetCurrentMFCOrNull(DataFilterPeriodo.FilterName))) {
        //        return base.GetById(valId);
        //    //}
        //}
    }
}
