using Test.BLL.Interfaces;
using Test.DLL.Interfaces;
using Test.Domain.DataTransferObject;
using Test.Domain.Entities;

namespace Test.BLL.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IRepository<Person> _repository;

        public PersonServices(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<PersonDto> Create(PersonDto entity)
        {
            var person = new Person
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.LastName,
                SocialClassId = entity.SocialClassId,
            };
            var result = await _repository.Create(person);
            return new PersonDto
            {
                Id = result.Id,
                Address = (from address in result.Address
                           select new AddressDto
                           {
                               City = address.City,
                               Country = address.Country,
                               District = address.District,
                               Home = address.Home,
                               NumberOfApartment = address.NumberOfApartment,
                               Id = address.Id,
                           }).ToList(),
                SocialClass = new SocialClassDto
                {
                    Id = result.SocialClass.Id,
                    AverageIncome = result.SocialClass.AverageIncome,
                    Title = result.SocialClass.Title
                },
                FirstName = result.FirstName,
                LastName = result.LastName,
                MiddleName = result.MiddleName,
                SocialClassId = result.SocialClassId,
            };
        }

        public async Task<PersonDto> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return new PersonDto
            {
                Id = result.Id,
                Address = (from address in result.Address
                           select new AddressDto
                           {
                               City = address.City,
                               Country = address.Country,
                               District = address.District,
                               Home = address.Home,
                               NumberOfApartment = address.NumberOfApartment,
                               Id = address.Id,
                           }).ToList(),
                SocialClass = new SocialClassDto
                {
                    Id = result.SocialClass.Id,
                    AverageIncome = result.SocialClass.AverageIncome,
                    Title = result.SocialClass.Title
                },
                FirstName = result.FirstName,
                LastName = result.LastName,
                MiddleName = result.MiddleName,
                SocialClassId = result.SocialClassId,
            };
        }

        public async Task<IEnumerable<PersonDto>> Get()
        {
            var result = await _repository.Get();
            return from results in result
                   select new PersonDto
                   {
                       Id = results.Id,
                       Address = (from address in results.Address
                                  select new AddressDto
                                  {
                                      City = address.City,
                                      Country = address.Country,
                                      District = address.District,
                                      Home = address.Home,
                                      NumberOfApartment = address.NumberOfApartment,
                                      Id = address.Id,
                                  }).ToList(),
                       SocialClass = new SocialClassDto
                       {
                           Id = results.SocialClass.Id,
                           AverageIncome = results.SocialClass.AverageIncome,
                           Title = results.SocialClass.Title
                       },
                       FirstName = results.FirstName,
                       LastName = results.LastName,
                       MiddleName = results.MiddleName,
                       SocialClassId = results.SocialClassId,
                   };
        }

        public async Task<PersonDto> Get(int id)
        {
            var result = await _repository.Get(id);
            return new PersonDto
            {
                Id = result.Id,
                Address = (from address in result.Address
                           select new AddressDto
                           {
                               City = address.City,
                               Country = address.Country,
                               District = address.District,
                               Home = address.Home,
                               NumberOfApartment = address.NumberOfApartment,
                               Id = address.Id,
                           }).ToList(),
                SocialClass = new SocialClassDto
                {
                    Id = result.SocialClass.Id,
                    AverageIncome = result.SocialClass.AverageIncome,
                    Title = result.SocialClass.Title
                },
                FirstName = result.FirstName,
                LastName = result.LastName,
                MiddleName = result.MiddleName,
                SocialClassId = result.SocialClassId,
            };
        }

        public async Task<PersonDto> Update(PersonDto entity)
        {
            var person = new Person
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.LastName,
                SocialClassId = entity.SocialClassId,
            };
            var result = await _repository.Update(person);
            return new PersonDto
            {
                Id = result.Id,
                Address = (from address in result.Address
                           select new AddressDto
                           {
                               City = address.City,
                               Country = address.Country,
                               District = address.District,
                               Home = address.Home,
                               NumberOfApartment = address.NumberOfApartment,
                               Id = address.Id,
                           }).ToList(),
                SocialClass = new SocialClassDto
                {
                    Id = result.SocialClass.Id,
                    AverageIncome = result.SocialClass.AverageIncome,
                    Title = result.SocialClass.Title
                },
                FirstName = result.FirstName,
                LastName = result.LastName,
                MiddleName = result.MiddleName,
                SocialClassId = result.SocialClassId,
            };
        }
    }
}
