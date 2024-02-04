using CrystalMeds.Server.Data;
using CrystalMeds.Server.IRepository;
using CrystalMeds.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrystalMeds.Server.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly ApplicationDbContext _context;
		private readonly DbSet<T> _db;

		public GenericRepository(ApplicationDbContext context)
		{
			_context = context;
			_db = _context.Set<T>();
		}








		public async Task<IEnumerable<T>> GetMany(Expression<Func<T, bool>> filter)
		{
			return await _context.Set<T>().Where(filter).ToListAsync();
		}





		public async Task Delete(int id)
		{
			var record = await _db.FindAsync(id);
			_db.Remove(record);
		}

		public void DeleteRange(IEnumerable<T> entities)
		{
			_db.RemoveRange(entities);
		}

		public async Task<T> Get(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
		{
			IQueryable<T> query = _db;

			if (includes != null)
			{
				query = includes(query);
			}

			return await query.AsNoTracking().FirstOrDefaultAsync(expression);
		}

		public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null,
			Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
			Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null)
		{
			IQueryable<T> query = _db;

			if (expression != null)
			{
				query = query.Where(expression);
			}

			if (includes != null)
			{
				query = includes(query);
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			return await query.AsNoTracking().ToListAsync();
		}

		public async Task Insert(T entity)
		{
			await _db.AddAsync(entity);
		}

		public async Task InsertRange(IEnumerable<T> entities)
		{
			await _db.AddRangeAsync(entities);
		}

		public void Update(T entity)
		{
			_db.Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}

		public Task GetMany(Func<object, bool> value)
		{
			throw new NotImplementedException();
		}

	}
}
