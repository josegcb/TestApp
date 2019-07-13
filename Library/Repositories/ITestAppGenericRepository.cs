using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repositories {
    public interface ITestAppGenericRepository<TEntity> : IRepository<TEntity>, IRepository, ITransientDependency where TEntity : class, IEntity<int> {
        TEntity UpdateProperties(TEntity valEntity, params Expression<Func<TEntity, object>>[] valUpdatedProperties);
    }
}
