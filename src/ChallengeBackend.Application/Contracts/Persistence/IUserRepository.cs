using ChallengeBackend.Domain;

namespace ChallengeBackend.Application.Contracts.Persistence
{
    public interface IUserRepository 
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
