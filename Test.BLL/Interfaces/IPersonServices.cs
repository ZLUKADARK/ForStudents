using Test.Domain.DataTransferObject;

namespace Test.BLL.Interfaces
{
    public interface IPersonServices
    {
        public Task<PersonDtoList> Create(PersonDtoList entity);
        public Task<PersonDtoList> Delete(int id);
        public Task<PersonDto> Update(PersonDtoList entity);
        public Task<IEnumerable<PersonDtoList>> Get();
        public Task<PersonDto> Get(int id);
        public Task<PersonDto> AddToAddress(AddressAddToPerson addressAddToPerson);
    }
}
