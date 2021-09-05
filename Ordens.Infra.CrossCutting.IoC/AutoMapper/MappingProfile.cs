using AutoMapper;
using Dominio.Entidades;
using Ordens.Application.DTOs;
using Ordens.Dominio.Commands.Requests;
using Ordens.Dominio.Commands.Responses;

namespace Ordens.Infra.CrossCutting.IoC.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EnviaOrdemRequestDTO, EnviaOrdemRequest>().ReverseMap();
            CreateMap<EnviaOrdemResponseDTO, EnviaOrdemResponse>().ReverseMap();
            CreateMap<EnviaOrdemRequest, Ordem>();
            CreateMap<EnviaOrdemRequest, EnviaOrdemResponse>();
        }
    }
}
