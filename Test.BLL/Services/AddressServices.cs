using Test.BLL.Interfaces;
using Test.DLL.Interfaces;
using Test.Domain.DataTransferObject;
using Test.Domain.Entities;
using System.Linq;
using System.Net;

namespace Test.BLL.Services
{
    public class AddressServices : IAddressServices
    {
        private readonly IRepository<Address> _repository;

        public AddressServices(IRepository<Address> repository) 
        {
            _repository = repository;
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

        public async Task<IEnumerable<AddressDto>> Get()
        {
            var results = await _repository.Get();
            return from result in results select
                   new AddressDto
                   {
                       Id = result.Id,
                       City = result.City,
                       Country = result.Country,
                       District = result.District,
                       Home = result.Home,
                       NumberOfApartment = result.NumberOfApartment,
                       Person = (from person in result.Person select
                                 new PersonDto
                                 {
                                     Id = person.Id,
                                     FirstName = person.FirstName,
                                     LastName = person.LastName,
                                     MiddleName = person.MiddleName,
                                     SocialClassId = person.SocialClassId
                                 }).ToList()
                   };
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
