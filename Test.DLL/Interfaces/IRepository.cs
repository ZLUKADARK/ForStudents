namespace Test.DLL.Interfaces
{
    public interface IRepository<Entity> where Entity : class
    {
        public Task<Entity> Create(Entity entity);
        public Task<Entity> Delete(int id);
        public Task<Entity> Update(Entity entity);
        public Task<IEnumerable<Entity>> Get();
        public Task<Entity> Get(int id);
    }
}
