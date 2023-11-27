namespace sales_forms.Repositories.Interfaces
{
    public interface IRepository<TEntity> 
        where TEntity : class, new()
    {
        List<TEntity> GetAll();
        TEntity? Get(long id);
        bool Insert(long id);
        bool Update(long id);
        bool Delete(long id);
    }
}
