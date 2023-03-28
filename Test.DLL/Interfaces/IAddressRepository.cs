using Test.Domain.Entities;

namespace Test.DLL.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        public Task<Address> AddToPerson(Address address, Person person);
    }
}
