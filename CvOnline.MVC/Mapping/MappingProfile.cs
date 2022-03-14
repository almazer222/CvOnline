using AutoMapper;
using CvOnline.MVC.Dtos;
using CvOnline.MVC.Models;

namespace MyMusic.MVC.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //MappageDomain (API) vers vue (Models)
            CreateMap<UserDto, UserModels>();
            CreateMap<EntrepriseDto, EntrepriseModels>();
            CreateMap<AddressDto, AddressModels>();

            //MappageDomain (Models) vers vue (API)
            CreateMap<UserModels, UserDto>();
            CreateMap<EntrepriseModels, EntrepriseDto >();
            CreateMap<AddressModels, AddressDto>();
        }
    }
}
