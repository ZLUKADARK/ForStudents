using Test.BLL.Interfaces;
using Test.DLL.Interfaces;
using Test.Domain.DataTransferObject;
using Test.Domain.Entities;

namespace Test.BLL.Services
{
    public class PersonServices : IPersonServices
    {
        private readonly IPersonRepository _repository;
        private readonly IAddressRepository _addressRepository;

        public PersonServices(IPersonRepository repository, IAddressRepository addressRepository)
        {
            _repository = repository;
            _addressRepository = addressRepository;
        }

        public async Task<PersonDto> AddToAddress(AddressToPerson addressToPerson)
        {
            try
            {
                var result = await _repository.AddToAddressAsync(
                    await _repository.GetAsync(addressToPerson.PersonId),
                    await _addressRepository.GetAsync(addressToPerson.AddressId));
                return new PersonDto
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    MiddleName = result.MiddleName,
                    SocialClassId = result.SocialClassId,
                    Address = (from a in result.Address
                               select
                               new AddressListDto
                               {
                                   Id = a.Id,
                                   City = a.City,
                                   NumberOfApartment = a.NumberOfApartment,
                                   Country = a.Country,
                                   District = a.District,
                                   Home = a.Home,
                               }).ToList()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PersonDtoList> Create(PersonDtoList entity)
        {
            var person = new Person
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                MiddleName = entity.LastName,
                SocialClassId = entity.SocialClassId,
            };
            var result = await _repository.CreateAsync(person);
            return new PersonDtoList
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                MiddleName = result.MiddleName,
                SocialClassId = result.SocialClassId,
            };
        }

        public async Task<PersonDtoList> Delete(int id)
        {
            var result = await _repository.DeleteAsync(id);
            return new PersonDtoList
            {
                Id = result.Id,
                FirstName = result.FirstName,
                LastName = result.LastName,
                MiddleName = result.MiddleName,
                SocialClassId = result.SocialClassId,
            };
        }

        public async Task<IEnumerable<PersonDtoList>> Get()
        {
            var result = await _repository.GetAsync();
            return from results in result
                   select new PersonDtoList
                   {
                       Id = results.Id,
                       FirstName = results.FirstName,
                       LastName = results.LastName,
                       MiddleName = results.MiddleName,
                       SocialClassId = results.SocialClassId,
                   };
        }

        public async Task<PersonDto> Get(int id)
        {
            var result = await _repository.GetAsync(id);
            return new PersonDto
            {
                Id = result.Id,
                Address = (from address in result.Address
                           select new AddressListDto
                           {
                               City = address.City,
                               Country = address.Country,
                               District = address.District,
                               Home = address.Home,
                               NumberOfApartment = address.NumberOfApartment,
                               Id = address.Id,
                           }).ToList(),
                SocialClass = new SocialClassListDto
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
            var result = await _repository.UpdateAsync(person);
            return new PersonDto
            {
                Id = result.Id,
                Address = (from address in result.Address
                           select new AddressListDto
                           {
                               City = address.City,
                               Country = address.Country,
                               District = address.District,
                               Home = address.Home,
                               NumberOfApartment = address.NumberOfApartment,
                               Id = address.Id,
                           }).ToList(),
                SocialClass = new SocialClassListDto
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
