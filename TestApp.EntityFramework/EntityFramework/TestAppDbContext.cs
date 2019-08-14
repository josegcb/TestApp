using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Text;
using System.Threading.Tasks;
using Abp;
using Abp.Events.Bus.Entities;
using Abp.Extensions;
using Abp.UI;
using Abp.Zero.EntityFramework;
using EntityFramework.DynamicFilters;
using Library.Exceptions;
using Library.Extenders;
using TestApp.Authorization.Roles;
using TestApp.Authorization.Users;
using TestApp.DataFilters;
using TestApp.Models;
using TestApp.MultiTenancy;

namespace TestApp.EntityFramework
{
    public class TestAppDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public DbSet<TipoNumeracion> TiposNumeracion { get; set; }
        public DbSet<Periodo> Periodos { get; set; }

        public DbSet<Cuenta> Cuentas { get; set; }

        public DbSet<Comprobante> Comprobantes { get; set; }

        public DbSet<ComprobanteDetalleCuenta> ComprobantesDetalleCuenta { get; set; }
        public TestAppDbContext()
            : base("Default")
        {
            
        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in TestAppDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of TestAppDbContext since ABP automatically handles it.
         */
        public TestAppDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TestAppDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public TestAppDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureTimestamp ();
            modelBuilder.ConfigureDecimal();
            modelBuilder.ConfigureVarchar();
            modelBuilder.Filter(new DataFilterPeriodo().FilterName, (IHavePeriodo t, int PeriodoId) => t.PeriodoId == PeriodoId, 0);

        }
        public override int SaveChanges() {
            //new EfDynamicFiltersUnitOfWorkFilterExecuter().ApplyEnableFilter(CurrentUnitOfWorkProvider.Current, this);
            try {
                return base.SaveChanges();
            } catch (DbUpdateConcurrencyException) {
                throw new ConcurrencyException();
            } catch (OptimisticConcurrencyException) {
                throw new ConcurrencyException();
            } catch (DbEntityValidationException valEx) {
                StringBuilder Errors = new StringBuilder();
                if (valEx.EntityValidationErrors != null) {
                    foreach (var vErrors in valEx.EntityValidationErrors) {
                        foreach (var validationError in vErrors.ValidationErrors) {
                            Errors.Append("Propiedad: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage + "\n");
                        }
                    }
                }
                throw new UserFriendlyException(Errors.ToString(), valEx);
            } catch (Exception vEx) {
                throw new Exception(vEx.Message, vEx.InnerException);
            }
        }

        public override Task<int> SaveChangesAsync() {

           // new EfDynamicFiltersUnitOfWorkFilterExecuter().ApplyCurrentFilters(CurrentUnitOfWorkProvider.Current, this);
            try {
                return base.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                throw new ConcurrencyException();
            } catch (OptimisticConcurrencyException) {
                throw new ConcurrencyException();
            } catch (DbEntityValidationException valEx) {
                StringBuilder Errors = new StringBuilder();
                if (valEx.EntityValidationErrors != null) {
                    foreach (var vErrors in valEx.EntityValidationErrors) {
                        foreach (var validationError in vErrors.ValidationErrors) {
                            Errors.Append("Propiedad: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage + "\n");
                        }
                    }
                }
                throw new UserFriendlyException(Errors.ToString(), valEx);
            } catch (Exception vEx) {
                throw new Exception(vEx.Message, vEx.InnerException);
            }
        }

        protected override void ApplyAbpConceptsForAddedEntity(DbEntityEntry entry, long? userId, EntityChangeReport changeReport) {
            base.ApplyAbpConceptsForAddedEntity(entry, userId, changeReport);
            CheckAndSetPeriodoIdProperty(entry.Entity);
        }

        protected int? CurrentPeriodoId;        
        internal virtual int? GetCurrentPeriodoIdOrNull() {
            var value = Library.Helpers.ClaimHelper.GetCurrentMFCOrNull(new DataFilterPeriodo().FilterName);
            if (value != null) {
                return Convert.ToInt32(value);
            }
            return null;
        }
        private void CheckAndSetPeriodoIdProperty(object entityAsObj) {
            if (!(entityAsObj is IHavePeriodo)) {
                return;
            }
            var entity = entityAsObj.As<IHavePeriodo>();
            if (entity.PeriodoId != 0) {
                return;
            }
            var currentPeriodoId = GetCurrentPeriodoIdOrNull();

            if (currentPeriodoId != null) {
                entity.PeriodoId = currentPeriodoId.Value;
            } else {
                throw new AbpException("No puede asignar 0 como Consecutivo Periodo !");
            }
        }
    }
}
