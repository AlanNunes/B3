using AutoMapper;
using Dominio.Entidades;
using Ordens.Application.DTOs;
using Ordens.Application.DTOs.ListaOrdens;
using Ordens.Dominio.Commands.Requests;
using Ordens.Dominio.Commands.Responses;
using Ordens.Dominio.Commands.Responses.ListaOrdens;

namespace Ordens.Infra.CrossCutting.IoC.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EnviaOrdemRequestDTO, EnviaOrdemRequest>().ReverseMap();
            CreateMap<EnviaOrdemResponseDTO, EnviaOrdemResponse>().ReverseMap();
            CreateMap<CancelaOrdemRequestDTO, CancelaOrdemRequest>().ReverseMap();
            CreateMap<CancelaOrdemResponseDTO, CancelaOrdemResponse>().ReverseMap();
            CreateMap<ListaOrdensRequestDTO, ListaOrdensRequest>()
                .ForMember(dst => dst.Intervalo, opt => opt.MapFrom(x => new Intervalo { Inicio = x.DataInicioIntervalo, Fim = x.DataFimIntervalo }));
            CreateMap<ListaOrdensResponseDTO, ListaOrdensResponse>().ReverseMap();

            CreateMap<ListaOrdensResponse, ListaOrdensResponseDTO>()
                .ForMember(dst => dst.Ordens, opt => opt.MapFrom(x => x.Ordens));
            CreateMap<Ordem, OrdemDTO>();

            CreateMap<EnviaOrdemRequest, Ordem>();
            CreateMap<EnviaOrdemRequest, EnviaOrdemResponse>();
            CreateMap<CancelaOrdemRequest, CancelaOrdemResponse>();
        }
    }
}
