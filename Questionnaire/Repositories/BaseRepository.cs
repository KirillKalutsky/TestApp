using Microsoft.EntityFrameworkCore;

namespace Questionnaire.Repositories
{
    public abstract class BaseRepository<T>:IRepository<T>
        where T : class
    {
        protected DbSet<T> items;
        protected DbContext context;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            items = context.Set<T>();
        }

        public async Task<bool> Delete(Guid id)
        {
            var item = await Find(id);

            if(item == null)
                return false;

            items.Remove(item);
            return true;
        }

        public virtual async Task<T> Find(Guid id) =>
            await items.FindAsync(id);

        public abstract Task<Guid> Insert(T entity);

        public async Task SaveChanges() =>
            await context.SaveChangesAsync();

        public abstract Task<List<T>> GetAll();
        public abstract Task Update(T entity);
    }
}
