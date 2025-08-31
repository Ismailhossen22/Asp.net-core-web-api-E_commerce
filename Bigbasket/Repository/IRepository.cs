namespace Bigbasket_Ecommerce.Repository
{
    public interface IRepository<T>where T:class
    {

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<int> SaveChangesAsync();


    }




}
