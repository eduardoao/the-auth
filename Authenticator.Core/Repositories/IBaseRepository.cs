﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Authenticator.Core.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<int> AddAsync(IList<TEntity> entities, CancellationToken cancellationToken = default);

        Task<int> CountAsync(bool disableTracking = true, CancellationToken cancellationToken = default);

        Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, bool disableTracking = true, CancellationToken cancellationToken = default);

        Task<IList<TEntity>> GetAllAsync(bool disableTracking = true, CancellationToken cancellationToken = default);

        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate, bool disableTracking = true, CancellationToken cancellationToken = default);

        Task<TEntity> UpdateAsync(TEntity entity, bool disableTracking = true, CancellationToken cancellationToken = default);
    }
}
