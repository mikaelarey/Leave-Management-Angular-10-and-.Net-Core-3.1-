using System.Linq;
using API.DTO;
using API.Models;
using AutoMapper;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // User lists mapping
            CreateMap<UserDetail, UserListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain == 1).Url);
                })
                .ForMember(dest => dest.Department, opt => {
                    opt.MapFrom(src => src.Department.Name);
                })
                .ForMember(dest => dest.EmploymentType, opt => {
                    opt.MapFrom(src => src.EmploymentType.Name);
                })
                .ForMember(dest => dest.UserRole, opt => {
                    opt.MapFrom(src => src.UserAccount.UserRole.Name);
                });

            // User Details Mapping
            CreateMap<UserPhoto, UserDetailPhotoDTO>();
            CreateMap<UserDetail, UserDetailDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain == 1).Url);
                })
                .ForMember(dest => dest.Department, opt => {
                    opt.MapFrom(src => src.Department.Name);
                })
                .ForMember(dest => dest.EmploymentType, opt => {
                    opt.MapFrom(src => src.EmploymentType.Name);
                })
                .ForMember(dest => dest.UserRole, opt => {
                    opt.MapFrom(src => src.UserAccount.UserRole.Name);
                });
        }
        
    }
}