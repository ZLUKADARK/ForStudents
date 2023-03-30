namespace Test.DLL.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        public Task<Entity> CreateAsync(Entity entity);
        public Task<Entity> DeleteAsync(int id);
        public Task<Entity> UpdateAsync(Entity entity);
        public Task<IEnumerable<Entity>> GetAsync();
        public Task<Entity> GetAsync(int id);
    }
}
