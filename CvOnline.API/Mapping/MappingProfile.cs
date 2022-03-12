using AutoMapper;
using CvOnline.API.Dtos;
using CvOnline.API.Dtos.CvItmDto;
using CvOnline.Domain.Models;
using CvOnline.Domain.Models.CV_Items;

namespace MyMusic.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //MappageDomain (DB) vers vue (DTO)
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Entreprise, output => output.MapFrom(src => src.Entreprise));
            CreateMap<Entreprise, EntrepriseDto>()
                .ForMember(dest => dest.Address, output => output.MapFrom(src => src.Address));
            CreateMap<Address, AddressDto>();

            CreateMap<CV, CvItemsDto>()
                 .ForMember(dest => dest.Identity, output => output.MapFrom(src => src.Identities))
            .ForMember(dest => dest.Interests, output => output.MapFrom(src => src.Interests))
            .ForMember(dest => dest.Skills, output => output.MapFrom(src => src.Skills))
            .ForMember(dest => dest.Socials, output => output.MapFrom(src => src.Socials))
            .ForMember(dest => dest.Certifications, output => output.MapFrom(src => src.Certifications))
            .ForMember(dest => dest.Experiances, output => output.MapFrom(src => src.Experiances))
            .ForMember(dest => dest.Educations, output => output.MapFrom(src => src.Educations));


            CreateMap<CvItemsDto, CV>()
                 .ForMember(dest => dest.Identities, output => output.MapFrom(src => src.Identity))
            .ForMember(dest => dest.Interests, output => output.MapFrom(src => src.Interests))
            .ForMember(dest => dest.Skills, output => output.MapFrom(src => src.Skills))
            .ForMember(dest => dest.Socials, output => output.MapFrom(src => src.Socials))
            .ForMember(dest => dest.Certifications, output => output.MapFrom(src => src.Certifications))
            .ForMember(dest => dest.Experiances, output => output.MapFrom(src => src.Experiances))
            .ForMember(dest => dest.Educations, output => output.MapFrom(src => src.Educations));

            CreateMap<Identity, IdentityDto>()
              .ForMember(dest => dest.FirstName, output => output.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.LastName, output => output.MapFrom(src => src.LastName))
              .ForMember(dest => dest.KindOfWork, output => output.MapFrom(src => src.KindOfWork))
              .ForMember(dest => dest.Address, output => output.MapFrom(src => src.Address));
            CreateMap<Interest, InterestDto>()
                .ForMember(dest => dest.Description, output => output.MapFrom(src => src.Description))
                .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<Skill, SkillDto>()
                .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<SkillItem, SkillItemsDto>()
                .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<Social, SocialDto>()
                 .ForMember(dest => dest.Url, output => output.MapFrom(src => src.Url))
                 .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<Certification, CertificationDto>()
                .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<Experiance, ExperianceDto>()
                 .ForMember(dest => dest.StartDate, output => output.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.EndDate, output => output.MapFrom(src => src.EndDate))
                 .ForMember(dest => dest.Title, output => output.MapFrom(src => src.Title))
                 .ForMember(dest => dest.Poste, output => output.MapFrom(src => src.Poste))
                 .ForMember(dest => dest.Description, output => output.MapFrom(src => src.Description));
            CreateMap<Education, EducationDto>()
                 .ForMember(dest => dest.StartDate, output => output.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.EndDate, output => output.MapFrom(src => src.EndDate))
                 .ForMember(dest => dest.Degres, output => output.MapFrom(src => src.Degres))
                 .ForMember(dest => dest.KindOfStudy, output => output.MapFrom(src => src.KindOfStudy))
                 .ForMember(dest => dest.School, output => output.MapFrom(src => src.School));

            //Mappage vue (DTO) vers Domain (DB) 
            CreateMap<UserDto, User>()
                 .ForMember(dest => dest.Entreprise, output => output.MapFrom(src => src.Entreprise));
            CreateMap<EntrepriseDto, Entreprise>()
                 .ForMember(dest => dest.Address, output => output.MapFrom(src => src.Address));
            CreateMap<AddressDto, Address>();

            CreateMap<IdentityDto, Identity>()
              .ForMember(dest => dest.FirstName, output => output.MapFrom(src => src.FirstName))
              .ForMember(dest => dest.LastName, output => output.MapFrom(src => src.LastName))
              .ForMember(dest => dest.KindOfWork, output => output.MapFrom(src => src.KindOfWork))
              .ForMember(dest => dest.Address, output => output.MapFrom(src => src.Address));
            CreateMap<InterestDto, Interest>()
               .ForMember(dest => dest.Description, output => output.MapFrom(src => src.Description))
               .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<SkillDto, Skill>()
                 .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name))
                 .ForMember(dest => dest.SkillItems, output => output.MapFrom(src => src.SkillItems));
            CreateMap<SkillItemsDto, SkillItem>()
             .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<SocialDto, Social>()
                 .ForMember(dest => dest.Url, output => output.MapFrom(src => src.Url))
                 .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<CertificationDto, Certification>()
                .ForMember(dest => dest.Name, output => output.MapFrom(src => src.Name));
            CreateMap<ExperianceDto, Experiance>()
                 .ForMember(dest => dest.StartDate, output => output.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.EndDate, output => output.MapFrom(src => src.EndDate))
                 .ForMember(dest => dest.Title, output => output.MapFrom(src => src.Title))
                 .ForMember(dest => dest.Poste, output => output.MapFrom(src => src.Poste))
                 .ForMember(dest => dest.Description, output => output.MapFrom(src => src.Description));
            CreateMap<EducationDto, Education>()
                    .ForMember(dest => dest.StartDate, output => output.MapFrom(src => src.StartDate))
                 .ForMember(dest => dest.EndDate, output => output.MapFrom(src => src.EndDate))
                 .ForMember(dest => dest.Degres, output => output.MapFrom(src => src.Degres))
                 .ForMember(dest => dest.KindOfStudy, output => output.MapFrom(src => src.KindOfStudy))
                 .ForMember(dest => dest.School, output => output.MapFrom(src => src.School));
        }
    }
}
