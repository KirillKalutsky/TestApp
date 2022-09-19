namespace Questionnaire.Repositories
{
    public interface IRepository<T>
    {
        Task<Guid> Insert(T entity);
        Task<bool> Delete(Guid id);
        Task<T> Find(Guid id);
        Task Update(T entity);

        Task SaveChanges();
    }
}
