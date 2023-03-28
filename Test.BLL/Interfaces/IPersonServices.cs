using Test.Domain.DataTransferObject;

namespace Test.BLL.Interfaces
{
    public interface IPersonServices
    {
        public Task<PersonDto> Create(PersonDto entity);
        public Task<PersonDto> Delete(int id);
        public Task<PersonDto> Update(PersonDto entity);
        public Task<IEnumerable<PersonDto>> Get();
        public Task<PersonDto> Get(int id);
    }
}
