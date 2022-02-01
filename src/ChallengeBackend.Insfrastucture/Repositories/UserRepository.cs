using ChallengeBackend.Application.Contracts.Persistence;
using ChallengeBackend.Domain;
using ChallengeBackend.Insfrastucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ChallengeBackend.Insfrastucture.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly UserDbContext _context;

        public UserRepository(UserDbContext context) 
        {
            _context = context;
        }

        public UserDbContext UserDbContext => _context;

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            _context.Entry(user).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return user;

        }

        public async Task DeleteAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(x => x.Address).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.Include(p => p.Address).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.Entry(user).Property(x => x.Id).IsModified = false;
            _context.Entry(user.Address).Property(x => x.Id).IsModified = false;
     
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
