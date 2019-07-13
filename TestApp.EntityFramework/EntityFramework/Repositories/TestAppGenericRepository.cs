using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Library.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.EntityFramework.Repositories {  
    public class TestAppGenericRepository<TEntity> : TestAppRepositoryBase<TEntity> where TEntity : class, IEntity<int> {
        public TestAppGenericRepository(IDbContextProvider<TestAppDbContext> dbContextProvider) : base(dbContextProvider) {
        }
    }

}
