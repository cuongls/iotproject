using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace IOTProject.EntityFramework.Repositories
{
    public abstract class IOTProjectRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<IOTProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected IOTProjectRepositoryBase(IDbContextProvider<IOTProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class IOTProjectRepositoryBase<TEntity> : IOTProjectRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected IOTProjectRepositoryBase(IDbContextProvider<IOTProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
