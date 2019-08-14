using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services {  

    public class ManagerBase<TEntity> : DomainService, IManagerBase<TEntity> where TEntity : class, IEntity<int> {

        protected readonly ITestAppGenericRepository<TEntity> _Repository;

    
        public  ManagerBase(ITestAppGenericRepository<TEntity> initRepository) {
            _Repository = initRepository;

        }
        public virtual TEntity Create(TEntity valRecord) {
            valRecord.Id =  _Repository.InsertAndGetId(valRecord);
            return valRecord;
        }

        public virtual void Delete(TEntity valRecord) {
            _Repository.Delete(valRecord);
        }

        public virtual IEnumerable<TEntity> GetAll() {
            return _Repository.GetAll();
        }

        public virtual TEntity GetById(int valId) {
            return _Repository.Get(valId);
        }

        public virtual TEntity Update(TEntity valRecord) {
           return  _Repository.Update(valRecord);
        }

        public TEntity UpdateProperties(TEntity valEntity, params Expression<Func<TEntity, object>>[] valUpdatedProperties) {
            return _Repository.UpdateProperties(valEntity, valUpdatedProperties);
        }

        public virtual IEnumerable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] valUpdatedProperties) {
            return _Repository.GetAllIncluding(valUpdatedProperties);
        }

    }

    public class ManagerBaseMfc<TEntity> : ManagerBase<TEntity> where TEntity : class, IEntity<int> {
        protected IDataFilter _DataFilter;
        public ManagerBaseMfc(ITestAppGenericRepository<TEntity> initRepository) : base(initRepository) {
        }

        public override IEnumerable<TEntity> GetAll() {
            using (UnitOfWorkManager.Current.SetFilterParameter(_DataFilter.FilterName, _DataFilter.ParameterName,_DataFilter.ParameterValue)) {
                return _Repository.GetAll();
            }
        }

        public override TEntity GetById(int valId) {
            using (UnitOfWorkManager.Current.SetFilterParameter(_DataFilter.FilterName, _DataFilter.ParameterName, _DataFilter.ParameterValue)) {
                return _Repository.Get(valId);
            }
        }

        public override IEnumerable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] valUpdatedProperties) {
            using (UnitOfWorkManager.Current.SetFilterParameter(_DataFilter.FilterName, _DataFilter.ParameterName, _DataFilter.ParameterValue)) {
                return _Repository.GetAllIncluding(valUpdatedProperties);
            }
        }


    }
    public interface IManagerBase<TEntity> : IDomainService {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int valId);
        TEntity Create(TEntity valEntity);
        TEntity Update(TEntity valEntity);
        void Delete(TEntity valEntity);
        TEntity UpdateProperties(TEntity valEntity, params Expression<Func<TEntity, object>>[] valUpdatedProperties);
        IEnumerable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] valUpdatedProperties);

    }

    


}
