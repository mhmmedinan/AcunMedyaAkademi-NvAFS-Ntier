﻿using Core.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Repositories;

public interface IRepository<TEntity,TEntityId>:IQuery<TEntity>
    where TEntity: BaseEntity<TEntityId>
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
    List<TEntity> GetAll(Expression<Func<TEntity,bool>> predicate=null,Func<IQueryable<TEntity>,IIncludableQueryable<TEntity,object>>? include=null);
    TEntity Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
}

