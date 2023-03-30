using Test.Domain.DataTransferObject;

namespace Test.BLL.Interfaces
{
    public interface IPersonServices
    {
        public Task<PersonDtoList> CreateAsync(PersonDtoList entity);
        public Task<PersonDtoList> DeleteAsync(int id);
        public Task<PersonDtoList> UpdateAsync(PersonDtoList entity);
        public Task<IEnumerable<PersonDtoList>> GetAsync();
        public Task<PersonDto> GetAsync(int id);
        public Task<PersonDto> AddToAddressAsync(AddressToPerson addressToPerson);
    }
}
