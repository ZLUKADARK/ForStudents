using Test.BLL.Interfaces;
using Test.DLL.Interfaces;
using Test.Domain.DataTransferObject;
using Test.Domain.Entities;
using System.Linq;
using System.Net;
using Test.DLL.Repositories;

namespace Test.BLL.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IAddressRepository _repository;
        private readonly IPersonRepository _personRepository;

        public AddressServices(IAddressRepository repository, IPersonRepository personRepository) 
        {
            _repository = repository;
            _personRepository = personRepository;
        }

        public async Task<AddressDto> AddToPerson(AddressAddToPerson addressAddToPerson)
        {
            try
            {
                var result = await _repository.AddToPerson(
                    await _repository.Get(addressAddToPerson.AddressId),
                    await _personRepository.Get(addressAddToPerson.PersonId));
                return new AddressDto 
                { 
                    Id = result.Id,
                    City = result.City, 
                    Country = result.Country, 
                    District = result.District, 
                    Home = result.Home, 
                    NumberOfApartment = result.NumberOfApartment, 
                    Person = (from p in result.Person select 
                              new PersonDtoList 
                              { 
                                  Id = p.Id,
                                  SocialClassId = p.SocialClassId,
                                  FirstName = p.FirstName, 
                                  LastName = p.LastName, 
                                  MiddleName = p.MiddleName, 
                              }).ToList() 
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddressDto> Create(AddressDto entity)
        {
            var address = new Address 
            { 
                Id = entity.Id,
                NumberOfApartment = entity.NumberOfApartment,
                City = entity.City,
                Country = entity.Country,
                District = entity.District,
                Home = entity.Home,
            };
            var result = await _repository.Create(address);
            return new AddressDto
            {
                Id = result.Id,
                City = result.City,
                Country = result.Country,
                District = result.District,
                Home = result.Home,
                NumberOfApartment = result.NumberOfApartment,
            };
        }

        public async Task<AddressDto> CreateWithPerson(AddressDto entity)
        {
            try
            {
                var address = new Address
                {
                    City = entity.City,
                    Country = entity.Country,
                    NumberOfApartment = entity.NumberOfApartment,
                    District = entity.District,
                    Home = entity.Home,
                    Person = (from person in entity.Person
                              select
                              new Person
                              {
                                  FirstName = person.FirstName,
                                  LastName = person.LastName,
                                  MiddleName = person.MiddleName,
                                  SocialClassId = person.SocialClassId,
                              }).ToList()
                };
                var result = await _repository.CreateWithPersons(address);
                return new AddressDto
                {
                    Id = result.Id,
                    City = result.City,
                    Country = result.Country,
                    NumberOfApartment = result.NumberOfApartment,
                    District = result.District,
                    Home = result.Home,
                    Person = (from person in result.Person
                              select
                              new PersonDtoList
                              {
                                  Id = person.Id,
                                  FirstName = person.FirstName,
                                  LastName = person.LastName,
                                  MiddleName = person.MiddleName,
                                  SocialClassId = person.SocialClassId,
                              }).ToList()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddressDto> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return new AddressDto
            {
                Id = result.Id,
                City = result.City,
                Country = result.Country,
                District = result.District,
                Home = result.Home,
                NumberOfApartment = result.NumberOfApartment,
            };
        }

        public async Task<IEnumerable<AddressListDto>> Get()
        {
            var results = await _repository.Get();
            return (from result in results select
                   new AddressListDto
                   {
                       Id = result.Id,
                       City = result.City,
                       Country = result.Country,
                       District = result.District,
                       Home = result.Home,
                       NumberOfApartment = result.NumberOfApartment
                   }).ToList();
        }

        public async Task<AddressDto> Get(int id)
        {
            var result = await _repository.Get(id);
            return new AddressDto
            {
                Id = result.Id,
                City = result.City,
                Country = result.Country,
                District = result.District,
                Home = result.Home,
                NumberOfApartment = result.NumberOfApartment,
                Person = (from results in result.Person select 
                          new PersonDtoList
                          {
                              Id = results.Id,
                              FirstName = results.FirstName,
                              LastName = results.LastName,
                              MiddleName = results.MiddleName,
                              SocialClassId = results.SocialClassId,
                          }).ToList(),
            };
        }

        public async Task<AddressDto> Update(AddressDto entity)
        {
            var address = new Address
            {
                Id = entity.Id,
                NumberOfApartment = entity.NumberOfApartment,
                City = entity.City,
                Country = entity.Country,
                District = entity.District,
                Home = entity.Home,
            };
            var result = await _repository.Update(address);
            return new AddressDto
            {
                Id = result.Id,
                City = result.City,
                Country = result.Country,
                District = result.District,
                Home = result.Home,
                NumberOfApartment = result.NumberOfApartment,
            };
        }
    }
}
