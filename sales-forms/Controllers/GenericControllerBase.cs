using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sales_forms.Data;
using sales_forms.ViewModels;
using Microsoft.EntityFrameworkCore;
using sales_forms.Models;

namespace sales_forms.Controllers
{
    public class GenericControllerBase<TEntity, TCreateVM, TUpdateVM> 
        where TEntity : class, IBaseEntity, new()
        where TCreateVM : class
        where TUpdateVM : class, IUpdateVM
    {
        public FormDbContext _dbContext;
        public IMapper _mapper;
        public DbSet<TEntity> _dbSet;

        public GenericControllerBase(FormDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = _dbContext.Set<TEntity>();
        }

        [HttpGet]
        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        [HttpGet("{id}")]
        public TEntity? Get(long id, bool tracking = true)
        {
            if (tracking)
            {
                return _dbSet.AsNoTracking().SingleOrDefault(q => q.Id == id);
            }
            
            return _dbSet.SingleOrDefault(q => q.Id == id);
        }

        [HttpPost]
        public TEntity? Post([FromBody] TCreateVM createVM)
        {
            TEntity entity = _mapper.Map<TEntity>(createVM);
            _dbSet.Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        [HttpPut("{id}")]
        public TEntity? Put([FromBody] TUpdateVM entityData)
        {
            TEntity? entity = _dbSet.SingleOrDefault(q => q.Id == entityData.Id);

            if (entity != null)
            {
                _dbSet.Entry(entity).CurrentValues.SetValues(entityData);
                _dbContext.SaveChanges();
            }

            return entity;
        }

        [HttpDelete("{id}")]
        public TEntity? Delete(long id)
        {
            var entity = _dbSet.SingleOrDefault(q => q.Id == id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
                _dbContext.SaveChanges();
            }

            return entity;
        }
    }
}
