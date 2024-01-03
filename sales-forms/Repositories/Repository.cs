using sales_forms.Data;
using sales_forms.Repositories.Interfaces;

namespace sales_forms.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private readonly FormDbContext _dbContext;

        public Repository(FormDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Delete(long id)
        {
            TEntity? entity = Get(id);

            if (entity == null)
            {
                return false;
            }

            _dbContext.Set<TEntity>().Remove(entity);

            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public TEntity? Get(long id) => _dbContext.Set<TEntity>().Find(id);
        public List<TEntity> GetAll() => _dbContext.Set<TEntity>().ToList();

        public bool Insert(long id)
        {
            TEntity? entity = Get(id);

            if (entity == null)
            {
                return false;
            }

            _dbContext.Set<TEntity>().Remove(entity);

            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }

        public bool Update(long id)
        {
            TEntity? entity = Get(id);

            if (entity == null)
            {
                return false;
            }

            _dbContext.Set<TEntity>().Remove(entity);

            if (_dbContext.SaveChanges() > 0)
            {
                return true;
            }

            return false;
        }
    }
}
