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

        public Person AddToAddress(Person person, Address address)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> Create(Person entity)
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

        public async Task<Person> Delete(int id)
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

        public async Task<IEnumerable<Person>> Get()
        {
            try
            {
                return await _db.Person.ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> Get(int id)
        {
            try
            {
                return await _db.Person.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Person> Update(Person entity)
        {
            try
            {
                var person = _db.Entry<Person>(entity);
                person.State = EntityState.Modified;

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
