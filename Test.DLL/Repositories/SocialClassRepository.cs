using Microsoft.EntityFrameworkCore;
using Test.DLL.Data;
using Test.DLL.Interfaces;
using Test.Domain.Entities;

namespace Test.DLL.Repositories
{
    public class SocialClassRepository : ISocialClassRepository
    {
        private readonly AppDBContext _db;

        public SocialClassRepository(AppDBContext db)
        {
            _db = db;
        }

        public async Task<SocialClass> AddToPerson(SocialClass social, Person person)
        {
            social.Person = new List<Person> { person };
            try
            {
                await _db.SocialClass.AddAsync(social);
                await _db.SaveChangesAsync();
                return social;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SocialClass> Create(SocialClass entity)
        {
            try
            {
                await _db.SocialClass.AddAsync(entity);
                await _db.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SocialClass> Delete(int id)
        {
            try
            {
                var socialClass = await _db.SocialClass.FindAsync(id);

                if (socialClass == null)
                    throw new Exception();

                _db.SocialClass.Remove(socialClass);
                await _db.SaveChangesAsync();
                return socialClass;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SocialClass>> Get()
        {
            try
            {
                return await _db.SocialClass.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SocialClass> Get(int id)
        {
            try
            {
                return await _db.SocialClass
                    .Include(x => x.Person)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SocialClass> Update(SocialClass entity)
        {
            try
            {
                var socialClass = _db.Entry<SocialClass>(entity);
                socialClass.State = EntityState.Modified;

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
