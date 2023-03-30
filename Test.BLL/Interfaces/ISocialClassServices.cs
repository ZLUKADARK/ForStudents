using Test.Domain.DataTransferObject;

namespace Test.BLL.Interfaces
{
    public interface ISocialClassServices
    {
        public Task<SocialClassDto> CreateAsync(SocialClassDto entity);
        public Task<SocialClassDto> DeleteAsync(int id);
        public Task<SocialClassDto> UpdateAsync(SocialClassDto entity);
        public Task<IEnumerable<SocialClassListDto>> GetAsync();
        public Task<SocialClassDto> GetAsync(int id);
        public Task<SocialClassDto> AddToPersonAsync(SocialClassAddToPerson socialClassAddToPerson);
    }
}
