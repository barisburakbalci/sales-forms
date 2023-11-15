namespace sales_forms.Repositories.Interfaces
{
    public interface IRepository<TEntity, TModel> 
        where TEntity : class, new()
        where TModel : class, new()
    {
        List<TEntity> GetAll();
        TEntity? Get(long id);
        bool Insert(long id, TModel model);
        bool Update(long id, TModel model);
        bool Delete(long id);
    }
}
