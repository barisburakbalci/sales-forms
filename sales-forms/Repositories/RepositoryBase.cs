using Microsoft.EntityFrameworkCore;
using sales_forms.Data;

namespace sales_forms.Repositories
{
	public class Repository<TEntity> where TEntity : class
	{
		private readonly FormDbContext DbContext;
		private readonly DbSet<TEntity> DbSet;

		public Repository(TEntity entity, FormDbContext dbContext)
		{
			DbContext = dbContext;
			DbSet = dbContext.Set<TEntity>();
		}

		public IEnumerable<TEntity> GetAll()
		{
			return DbSet.ToList();
		}
	}
}

