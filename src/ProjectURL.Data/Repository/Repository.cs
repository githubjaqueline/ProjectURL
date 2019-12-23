using Microsoft.EntityFrameworkCore;
using ProjectURL.Data.Context;
using ProjectURL.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectURL.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ProjectURLContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ProjectURLContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public  void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public  TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public  IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public  void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public  void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
