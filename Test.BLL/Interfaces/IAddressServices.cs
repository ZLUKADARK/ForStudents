using Test.Domain.DataTransferObject;
using Test.Domain.Entities;

namespace Test.BLL.Interfaces
{
    public interface IAddressServices
    {
        public Task<AddressListDto> CreateAsync(AddressListDto entity);
        public Task<AddressDto> DeleteAsync(int id);
        public Task<AddressListDto> UpdateAsync(AddressListDto entity);
        public Task<IEnumerable<AddressListDto>> GetAsync();
        public Task<AddressDto> GetAsync(int id);
        public Task<AddressDto> AddToPersonAsync(AddressToPerson addressAddToPerson);
        public Task<AddressDto> CreateWithPersonAsync(AddressDto entity);
        public Task<AddressDto> RemoveFromAddressAsync(int addressId, List<int> persinsId);
        public Task<AddressDto> AddPersonsRangeAsync(int addressId, List<int> persinsId);
    }
}
