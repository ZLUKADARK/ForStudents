using Test.Domain.Entities;

namespace Test.DLL.Interfaces
{
    public interface ISocialClassRepository : IRepository<SocialClass>
    {
        public Task<SocialClass> AddToPerson(SocialClass social, Person person);
    }
}
