using Microsoft.EntityFrameworkCore;
using Sistecredito.OvertimeTracking.Core.Interfaces;
using Sistecredito.OvertimeTracking.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistecredito.OvertimeTracking.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
         where TEntity : class
    {
        protected DbContext _context;
        protected DbSet<TEntity> _Table;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _Table = _context.Set<TEntity>();
        }

        #region Crud

        public async Task<TEntity> CreateAsync(TEntity entity, bool autoSave = true)
        {
            await _Table.AddAsync(entity);
            if (autoSave)
            {
                await SaveChangesAsync();
            }

            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, bool autoSave = true)
        {
            var response = _Table.Remove(entity);

            if (autoSave)
            {
                await SaveChangesAsync();
            }

            return response.Entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = true)
        {
            var oldItem = await FindByIdAsync(GetValuePrimaryKey(entity));

            _context.Entry(oldItem).CurrentValues.SetValues(entity);
            if (autoSave)
            {
                await SaveChangesAsync();
            }
            return entity;
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            var newId = CastPrimaryKey(id);
            return await _Table.FindAsync(newId);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _Table;
        }
        #endregion

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        protected object CastPrimaryKey(object id)
        {
            string keyName = GetPrimaryKeyName();
            Type keyType = typeof(TEntity).GetProperty(keyName).PropertyType;
            return Convert.ChangeType(id, keyType);
        }

        protected string GetPrimaryKeyName()
        {
            var keyNames = _context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name);
            string keyName = keyNames.FirstOrDefault();

            if (keyNames.Count() > 1)
            {
                throw new ApplicationException("");
            }

            if (keyName == null)
            {
                throw new ApplicationException("");
            }

            return keyName;
        }

        protected object GetValuePrimaryKey(TEntity entity)
        {
            string keyName = GetPrimaryKeyName();
            object value = typeof(TEntity).GetProperty(keyName).GetValue(entity);
            return value;
        }
    }
}
