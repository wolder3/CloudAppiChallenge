using ChallengeBackend.Domain.Common;

namespace ChallengeBackend.Domain
{
    public class User : BaseDomainModel
    {
        public User()
        {
            Address = new Address();
        }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public virtual Address Address { get; set; }

    }
}
