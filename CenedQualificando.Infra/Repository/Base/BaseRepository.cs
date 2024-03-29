﻿using Microsoft.EntityFrameworkCore;
using System;
using CenedQualificando.Infra.Context;
using CenedQualificando.Domain.Models.Base;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using CenedQualificando.Domain.Repositories.Base;

namespace CenedQualificando.Infra.Repository.Base
{
    public class BaseRepository<TEntity> : IWriterBaseRepository<TEntity>, IReaderBaseRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly EntityContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(EntityContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        protected const string SchemaName = "Penitenciario";


        #region ***** READER *****

        public virtual TEntity Get(Expression<Func<TEntity, bool>> query) => DbSet.Where(query).FirstOrDefault();

        public virtual TEntity Get(int id) => DbSet.Find(id);

        public virtual IQueryable<TEntity> List() => DbSet.AsNoTracking();

        public virtual IQueryable<TEntity> List(Expression<Func<TEntity, bool>> query) => DbSet.Where(query).AsNoTracking();

        #endregion


        #region ***** WRITER *****
        public virtual void Add(TEntity obj) => DbSet.Add(obj);
        public void Add(IEnumerable<TEntity> objList)
        {
            foreach (var obj in objList)
            {
                Add(obj);
            }
        }

        public virtual void Attach(TEntity obj) => DbSet.Attach(obj);
        public void Attach(IEnumerable<TEntity> objList)
        {
            foreach (var obj in objList)
            {
                Attach(obj);
            }
        }

        public virtual void Update(TEntity obj) => DbSet.Update(obj);
        public void Update(IEnumerable<TEntity> objList)
        {
            foreach (var obj in objList)
            {
                Update(obj);
            }
        }

        public virtual void Remove(TEntity obj) => DbSet.Remove(obj);
        public void Remove(IEnumerable<TEntity> objList)
        {
            foreach (var obj in objList)
            {
                Remove(obj);
            }
        }
        #endregion

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}