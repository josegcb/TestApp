using System;
using System.Linq;
using System.Linq.Expressions;
using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Library.Repositories;

namespace TestApp.EntityFramework.Repositories
{
    public  class TestAppRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<TestAppDbContext, TEntity, TPrimaryKey> 
        where TEntity : class, IEntity<TPrimaryKey> {
        public TestAppRepositoryBase(IDbContextProvider<TestAppDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

        


    }

    public  class TestAppRepositoryBase<TEntity> : TestAppRepositoryBase<TEntity, int>, ITestAppGenericRepository<TEntity>
        where TEntity : class, IEntity<int> {
        public TestAppRepositoryBase(IDbContextProvider<TestAppDbContext> dbContextProvider)
            : base(dbContextProvider) {

        }
        public TEntity UpdateProperties(TEntity valEntity, params Expression<Func<TEntity, object>>[] valUpdatedProperties) {
            if (valEntity != null && valUpdatedProperties != null) {
                AttachIfNot(valEntity);
                var vDbEntityEntry = Context.Entry(valEntity);
                if (valUpdatedProperties.Any()) {
                    foreach (var vProperty in valUpdatedProperties) {
                        vDbEntityEntry.Property(vProperty).IsModified = true;
                    }
                } else {
                    foreach (var vProperty in vDbEntityEntry.OriginalValues.PropertyNames) {
                        var original = vDbEntityEntry.OriginalValues.GetValue<object>(vProperty);
                        var current = vDbEntityEntry.CurrentValues.GetValue<object>(vProperty);
                        if (original != null && !original.Equals(current))
                            vDbEntityEntry.Property(vProperty).IsModified = true;
                    }
                }
            }
            return valEntity;
        }
    }
}
