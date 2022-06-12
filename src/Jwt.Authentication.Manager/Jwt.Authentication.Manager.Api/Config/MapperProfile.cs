using AutoMapper;
using Jwt.Authentication.Manager.Api.Dtos;
using Jwt.Authentication.Manager.Domain.Entities;
using System.Text.Json.Nodes;

namespace Jwt.Authentication.Manager.Api.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AuthRequest, AuthRequestDto>();
            CreateMap<AuthRequestDto, AuthRequest>();
                 //.ForMember(source => source.Claims, opt => opt.MapFrom(dest => ConvertObject((object)dest.Claims)));

            CreateMap<AuthResponse, AuthResponseDto>();
            CreateMap<AuthResponseDto, AuthResponse>();

            CreateMap<EncryptRequest, EncryptRequestDto>();
            CreateMap<EncryptRequestDto, EncryptRequest>();

            CreateMap<EncryptResponse, EncryptResponseDto>();
            CreateMap<EncryptResponseDto, EncryptResponse>();
        }

        //private string ConvertObject(object obj)
        //{
        //    string result = string.Empty;
        //    if (obj != null)
        //    {
        //        var json = JsonObject.Parse((dynamic)obj);
        //        result = json.ToString();
        //    }

        //    return result;
        //}
    }
}
