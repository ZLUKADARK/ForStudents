using Microsoft.EntityFrameworkCore;
using Test.DLL.Data;
using Test.DLL.Interfaces;
using Test.Domain.Entities;

namespace Test.DLL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AppDBContext _db;

        public AddressRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<Address> AddToPerson(Address address, Person person)
        {
            try
            {
                var addressUpdate = _db.Entry<Address>(address);
                addressUpdate.State = EntityState.Modified;
                addressUpdate.Entity.Person.Add(person);
                await _db.SaveChangesAsync();
                return addressUpdate.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> Create(Address entity)
        {
            try
            {
                await _db.Address.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> CreateWithPersons(Address address)
        {
            try
            {
                _db.Person.AddRange(address.Person);
                address.Person = address.Person;
                await _db.Address.AddAsync(address);
                await _db.SaveChangesAsync();
                return address;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> Delete(int id)
        {
            try
            {
                var address = await _db.Address.FindAsync(id);

                if (address == null)
                    throw new Exception();

                _db.Address.Remove(address);
                await _db.SaveChangesAsync();
                return address;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Address>> Get()
        {
            try
            {
                return await _db.Address
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> Get(int id)
        {
            try
            {
                return await _db.Address
                    .AsNoTracking()
                    .Include(x => x.Person)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Address> Update(Address entity)
        {
            try
            {
                var address = _db.Entry<Address>(entity);
                address.State = EntityState.Modified;

                await _db.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
