namespace ChallengeBackend.Application.ViewModels
{
    public class UserVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public AddressVm Address { get; set; }
    }
}
