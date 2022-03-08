using AutoMapper;
using CvOnline.API.Ressources;
using CvOnline.Domain.Models;

namespace MyMusic.API.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //MappageDomain (DB) vers vue (ressources)
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Entreprise, output => output.MapFrom(src => src.Entreprise));
            CreateMap<Entreprise, EntrepriseDto>()
                .ForMember(dest => dest.Address, output => output.MapFrom(src => src.Address));
            CreateMap<Address, AddressDto>();

    
            //Mappage Db vers Input
            //CreateMap<User, SaveUserRessource>();
            //CreateMap<Entreprise, SaveEntrepriseRessource>();
            //CreateMap<Address, SaveAddressRessource>();

            //Mappage vue (ressources) vers Domain (DB) 
            CreateMap<UserDto, User>()
                 .ForMember(dest => dest.Entreprise, output => output.MapFrom(src => src.Entreprise));
            CreateMap<EntrepriseDto, Entreprise>()
                 .ForMember(dest => dest.Address, output => output.MapFrom(src => src.Address));
            CreateMap<AddressDto, Address>();


            //Mappage Input vers Db
            //CreateMap<SaveUserRessource, User>();
            //CreateMap<SaveEntrepriseRessource, Entreprise>();
            //CreateMap<SaveAddressRessource, Address>();
        }
    }
}
