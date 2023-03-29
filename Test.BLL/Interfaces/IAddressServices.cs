using Test.Domain.DataTransferObject;

namespace Test.BLL.Interfaces
{
    public interface IAddressServices
    {
        public Task<AddressDto> Create(AddressDto entity);
        public Task<AddressDto> Delete(int id);
        public Task<AddressDto> Update(AddressDto entity);
        public Task<IEnumerable<AddressListDto>> Get();
        public Task<AddressDto> Get(int id);
        public Task<AddressDto> AddToPerson(AddressAddToPerson addressAddToPerson);
        public Task<AddressDto> CreateWithPerson(AddressDto entity);
    }
}
