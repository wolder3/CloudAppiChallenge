using AutoMapper;
using ChallengeBackend.Application.Features.Users.Commands;
using ChallengeBackend.Application.Features.Users.Commands.UpdateUser;
using ChallengeBackend.Application.ViewModels;
using ChallengeBackend.Domain;

namespace ChallengeBackend.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserVm>();
            CreateMap<Address, AddressVm>().ReverseMap(); ;
            CreateMap<CreateUserCommand, User>().ForMember(d => d.Address, opt => opt.MapFrom(s => s)); 
            CreateMap<CreateUserCommand, Address>();
            CreateMap<UpdateUserCommand, User>().ForMember(d => d.Address, opt => opt.MapFrom(s => s)).ForMember(x => x.Id, y => y.Ignore());
            CreateMap<UpdateUserCommand, Address>().ForMember(x => x.Id, y => y.Ignore()); 
        }
    }
}
