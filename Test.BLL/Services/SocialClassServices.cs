using Test.BLL.Interfaces;
using Test.DLL.Interfaces;
using Test.Domain.DataTransferObject;
using Test.Domain.Entities;

namespace Test.BLL.Services
{
    public class SocialClassServices : ISocialClassServices
    {
        private readonly ISocialClassRepository _repository;
        private readonly IPersonRepository _personRepository;

        public SocialClassServices(ISocialClassRepository repository, IPersonRepository personRepository) 
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        public async Task<SocialClassDto> AddToPerson(SocialClassAddToPerson socialClassAddToPerson)
        {
            
            try
            {
                var result = await _repository.Get(socialClassAddToPerson.SocialClassId);
                result.Person = new List<Person> { await _personRepository.Get(socialClassAddToPerson.PersonId) };
                result = await _repository.Create(result);

                return new SocialClassDto
                {
                    Id = result.Id,
                    AverageIncome = result.AverageIncome,
                    Title = result.Title,
                    Person = (from results in result.Person select
                              new PersonDtoList
                              {
                                  Id = results.Id,
                                  FirstName = results.FirstName,
                                  LastName = results.LastName,
                                  SocialClassId = results.SocialClassId,
                                  MiddleName = results.MiddleName,
                              }).ToList()
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
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

        public async Task<IEnumerable<SocialClassListDto>> Get()
        {
            var results = await _repository.Get();
            return from result in results select 
                   new SocialClassListDto
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
                Title = result.Title,
                Person = (from resuts in result.Person select 
                          new PersonDtoList 
                          {
                              Id = resuts.Id,
                              FirstName = resuts.FirstName,
                              LastName = resuts.LastName,
                              MiddleName = resuts.MiddleName,
                              SocialClassId = resuts.SocialClassId,
                          }).ToList() 
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
