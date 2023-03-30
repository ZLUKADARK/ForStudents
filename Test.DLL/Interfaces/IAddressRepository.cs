using Test.Domain.Entities;

namespace Test.DLL.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        public Task<Address> AddToPersonAsync(Address address, Person person);
        public Task<Address> RemoveFromPersonAsync(Address address, List<int> persinsId);
        public Task<Address> AddPersonsRangeAsync(Address address, List<int> persinsId);
        public Task<Address> CreateWithPersonsAsync(Address address);
    }
}
