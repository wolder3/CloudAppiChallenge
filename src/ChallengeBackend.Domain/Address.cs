using ChallengeBackend.Domain.Common;

namespace ChallengeBackend.Domain
{
    public class Address : BaseDomainModel
    {
        public string Street { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zip { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
