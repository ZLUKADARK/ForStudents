using Test.BLL.Interfaces;
using Test.DLL.Interfaces;
using Test.Domain.DataTransferObject;
using Test.Domain.Entities;

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

        public async Task<AddressDto> AddPersonsRangeAsync(int addressId, List<int> persinsId)
        {
            try
            {
                var result = await _repository.AddPersonsRangeAsync( await _repository.GetAsync(addressId), persinsId);
                return new AddressDto
                {
                    Id = result.Id,
                    NumberOfApartment= result.NumberOfApartment,
                    City = result.City,
                    Country = result.Country,
                    District = result.District,
                    Home = result.Home,
                    Person = (from p in result.Person select 
                              new PersonDtoList
                              {
                                  Id = p.Id,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  MiddleName = p.MiddleName,
                                  SocialClassId = p.SocialClassId,
                              }).ToList()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddressDto> AddToPersonAsync(AddressToPerson addressAddToPerson)
        {
            try
            {
                var result = await _repository.AddToPersonAsync(
                    await _repository.GetAsync(addressAddToPerson.AddressId),
                    await _personRepository.GetAsync(addressAddToPerson.PersonId));
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

        public async Task<AddressListDto> CreateAsync(AddressListDto entity)
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
            var result = await _repository.CreateAsync(address);
            return new AddressListDto
            {
                Id = result.Id,
                City = result.City,
                Country = result.Country,
                District = result.District,
                Home = result.Home,
                NumberOfApartment = result.NumberOfApartment,
            };
        }

        public async Task<AddressDto> CreateWithPersonAsync(AddressDto entity)
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
                var result = await _repository.CreateWithPersonsAsync(address);
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

        public async Task<AddressDto> DeleteAsync(int id)
        {
            var result = await _repository.DeleteAsync(id);
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

        public async Task<IEnumerable<AddressListDto>> GetAsync()
        {
            var results = await _repository.GetAsync();
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

        public async Task<AddressDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(id);
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

        public async Task<AddressDto> RemoveFromAddressAsync(int addressId, List<int> persinsId)
        {
            try
            {
                var result = await _repository.RemoveFromPersonAsync(await _repository.GetAsync(addressId), persinsId);
                return new AddressDto
                {
                    Id = result.Id,
                    City = result.City,
                    Country = result.Country,
                    District = result.District,
                    Home = result.Home,
                    NumberOfApartment = result.NumberOfApartment,
                    Person = (from p in result.Person
                              select
                              new PersonDtoList
                              {
                                  Id = p.Id,
                                  FirstName = p.FirstName,
                                  LastName = p.LastName,
                                  MiddleName = p.MiddleName,
                                  SocialClassId = p.SocialClassId,
                              }).ToList(),
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AddressListDto> UpdateAsync(AddressListDto entity)
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
            var result = await _repository.UpdateAsync(address);
            return new AddressListDto
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
