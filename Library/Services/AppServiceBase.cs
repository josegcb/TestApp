using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using AutoMapper;
using Library.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library.Services {    
    public abstract class AppServiceBase<TEntity, TDtoDown, TDtoUp, TDtoDelete, TDtoPk> : IApplicationService,
       IAppServiceBase<TEntity, TDtoDown, TDtoUp, TDtoDelete, TDtoPk>
          where TEntity : Entity
          where TDtoDown : IEntityDto
          where TDtoUp : IEntityDto
        where TDtoDelete : IEntityDto
          where TDtoPk : IEntityDto {

        protected IManagerBase<TEntity> _Manager;
        public IManagerBase<TEntity> Manager { get; private set; }

        protected AppServiceBase(IManagerBase<TEntity> initManager) {
            _Manager = initManager;
        }
     
        public virtual IEnumerable<TDtoUp> GetAll() {
            var vRecords = _Manager.GetAll().ToList();
            IEnumerable<TDtoUp> vResult = MapToDtoUp(vRecords);
            return vResult;
        }

        public virtual TDtoUp Create(TDtoDown valInput) {
            TEntity vRecord = MapToEntity(valInput);
            vRecord = _Manager.Create(vRecord);
            return MapToDtoUp(vRecord);
        }

        public virtual TDtoUp Update(TDtoDown valInput) {
            TEntity vRecord = MapToEntity(valInput);
            vRecord = _Manager.Update(vRecord);
            return MapToDtoUp(vRecord);
        }

        public virtual void Delete(TDtoDelete valInput) {
            TEntity vRecord = MapToEntity<TDtoDelete>(valInput);
            _Manager.Delete(vRecord);
        }

        public virtual TDtoUp Get(TDtoPk valInput) {
            TEntity vRecord = _Manager.GetById(valInput.Id);
            TDtoUp vResult = MapToDtoUp(vRecord);
            return vResult;
        }

        protected virtual TDtoUp MapToDtoUp(TEntity valEntity) {
            return Mapper.Map<TEntity, TDtoUp>(valEntity);
        }

        protected virtual IEnumerable<TDtoUp> MapToDtoUp(IEnumerable<TEntity> valEntities) {
            return Mapper.Map<IEnumerable<TEntity>, IEnumerable<TDtoUp>>(valEntities);
        }

        protected virtual TEntity MapToEntity(TDtoDown valDtoDown) {
            return Mapper.Map<TDtoDown, TEntity>(valDtoDown);
        }

        protected virtual TEntity MapToEntity(TDtoPk valDtoPk) {
            return Mapper.Map<TDtoPk, TEntity>(valDtoPk);
        }

        protected virtual TEntity MapToEntity<TDto>(TDto valDtoDown) {
            return Mapper.Map<TDto, TEntity>(valDtoDown);
        }

        public virtual List<EnumJson> GetEnumDescription<EnumType>() where EnumType : struct, IComparable, IConvertible, IFormattable {
            return EnumHelper<EnumType>.GetDescriptions();
        }

    }    
    public interface IAppServiceBase<TEntity, TDtoDown, TDtoUp, TDtoDelete, TDtoPk> 
        : IApplicationService 
	    where TEntity : Entity
       where TDtoDown : IEntityDto
       where TDtoUp : IEntityDto
       where TDtoDelete : IEntityDto
       where TDtoPk : IEntityDto {

        IEnumerable<TDtoUp> GetAll();
        TDtoUp Create(TDtoDown valInput);
        TDtoUp Update(TDtoDown valInput);
        void Delete(TDtoDelete valInput);
        TDtoUp Get(TDtoPk valInput);

    }


}

