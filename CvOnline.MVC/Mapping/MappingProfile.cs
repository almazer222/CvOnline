using AutoMapper;
using CvOnline.MVC.Dtos;
using CvOnline.MVC.Models;

namespace MyMusic.MVC.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //MappageDomain (DB) vers vue (ressources)
            CreateMap<UserDto, UserModels>();
            CreateMap<EntrepriseDto, EntrepriseModels>();
            CreateMap<AddressDto, AddressModels>();
        }
    }
}
