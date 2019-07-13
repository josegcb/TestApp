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
using TestApp.DataFilters;
using TestApp.EntityFramework.Repositories;
using TestApp.Managers.Interface;
using TestApp.Models;


namespace TestApp.Managers {

    public class ComprobanteManager<T> : ManagerBaseMfc<Comprobante> {
        readonly ITestAppGenericRepository<ComprobanteDetalleCuenta> _RepositoryDetalleCuenta;
        public ComprobanteManager(ITestAppGenericRepository<Comprobante> initRepository, ITestAppGenericRepository<ComprobanteDetalleCuenta> initRepositoryRepositoryDetalleCuenta) : base(initRepository) {
            _RepositoryDetalleCuenta = initRepositoryRepositoryDetalleCuenta;
            _DataFilter = new DataFilterPeriodo();
            _DataFilter.ParameterValue =  Library.Helpers.ClaimHelper.GetCurrentMFCOrNull(_DataFilter.FilterName);
        }      
        public override IEnumerable<Comprobante> GetAll() {
            return base.GetAllIncluding(p => p.ComprobanteDetalleCuenta);
        }
        public override Comprobante GetById(int valId) {
            return base.GetAllIncluding(p => p.ComprobanteDetalleCuenta).Where(q => q.Id == valId).FirstOrDefault();
        }
    }
}
