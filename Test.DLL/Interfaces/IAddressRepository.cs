using Test.Domain.Entities;

namespace Test.DLL.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        public Address AddToPerson(Address address, Person person);
    }
}
