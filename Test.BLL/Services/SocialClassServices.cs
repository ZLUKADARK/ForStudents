using Test.BLL.Interfaces;
using Test.DLL.Interfaces;
using Test.Domain.DataTransferObject;
using Test.Domain.Entities;

namespace Test.BLL.Services
{
    public class SocialClassServices : ISocialClassServices
    {
        private readonly IRepository<SocialClass> _repository;

        public SocialClassServices(IRepository<SocialClass> repository) 
        {
            _repository = repository;
        }

        public async Task<SocialClassDto> Create(SocialClassDto entity)
        {
            var socialClass = new SocialClass 
            { 
                AverageIncome = entity.AverageIncome, 
                Title = entity.Title 
            };
            var result = await _repository.Create(socialClass);
            return new SocialClassDto 
            { 
                Id = result.Id, 
                AverageIncome = result.AverageIncome, 
                Title = result.Title 
            };
        }

        public async Task<SocialClassDto> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return new SocialClassDto
            {
                Id = result.Id,
                AverageIncome = result.AverageIncome,
                Title = result.Title
            };
        }

        public async Task<IEnumerable<SocialClassDto>> Get()
        {
            var results = await _repository.Get();
            return from result in results select 
                   new SocialClassDto
                   {
                       Id = result.Id,
                       AverageIncome = result.AverageIncome,
                       Title = result.Title
                   };
        }

        public async Task<SocialClassDto> Get(int id)
        {
            var result = await _repository.Get(id);
            return new SocialClassDto
            {
                Id = result.Id,
                AverageIncome = result.AverageIncome,
                Title = result.Title
            };
        }

        public async Task<SocialClassDto> Update(SocialClassDto entity)
        {
            var socialClass = new SocialClass
            {
                Id = entity.Id,
                AverageIncome = entity.AverageIncome,
                Title = entity.Title
            };
            var result = await _repository.Update(socialClass);
            return new SocialClassDto
            {
                Id = result.Id,
                AverageIncome = result.AverageIncome,
                Title = result.Title
            };
        }
    }
}
