using Test.Domain.DataTransferObject;

namespace Test.BLL.Interfaces
{
    public interface ISocialClassServices
    {
        public Task<SocialClassDto> Create(SocialClassDto entity);
        public Task<SocialClassDto> Delete(int id);
        public Task<SocialClassDto> Update(SocialClassDto entity);
        public Task<IEnumerable<SocialClassDto>> Get();
        public Task<SocialClassDto> Get(int id);
    }
}
