using Test.Domain.Entities;

namespace Test.DLL.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        public Task<Person> AddToAddressAsync(Person person, Address address);
    }
}
