using Microsoft.EntityFrameworkCore;
using Test.DLL.Data;
using Test.DLL.Interfaces;
using Test.Domain.Entities;

namespace Test.DLL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDBContext _db;

        public PersonRepository(AppDBContext db) 
        {
            _db = db;
        }

        public async Task<Person> AddToAddressAsync(Person person, Address address)
        {
            person.Address.Add(address);
            try
            {
                await _db.AddAsync(person);
                await _db.SaveChangesAsync();
                return person;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> CreateAsync(Person entity)
        {
            try
            {
                await _db.Person.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> DeleteAsync(int id)
        {
            try
            {
                var person = await _db.Person.FindAsync(id);

                if (person == null)
                    throw new Exception();

                _db.Person.Remove(person);
                await _db.SaveChangesAsync();
                return person;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Person>> GetAsync()
        {
            try
            {
                return await _db.Person
                    .AsNoTracking()
                    .ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> GetAsync(int id)
        {
            try
            {
                return await _db.Person
                    .AsNoTracking()
                    .Include(x => x.SocialClass)
                    .Include(x => x.Address)
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> UpdateAsync(Person entity)
        {
            try
            {
                var person = _db.Entry<Person>(entity);
                person.State = EntityState.Modified;

                await _db.SaveChangesAsync();
                return person.Entity;
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
