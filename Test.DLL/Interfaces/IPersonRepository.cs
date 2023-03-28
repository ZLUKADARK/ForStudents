using Test.Domain.Entities;

namespace Test.DLL.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        public Person AddToAddress(Person person, Address address);
    }
}
