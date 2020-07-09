using AutoMapper;
using Differ.Application.ViewModels;
using Differ.Domain.Models;

namespace Differ.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Difference, DifferenceViewModel>();
            CreateMap<DiffResult, DiffViewModel>()
                 .ForMember(dest => dest.Differences,
                        opts => opts.MapFrom(src => src.Differences));

            CreateMap<Diff, LeftDataViewModel>()
                .ForMember(dest => dest.LeftData,
                        opts => opts.MapFrom(src => src.LeftDiffData)).ReverseMap();

            CreateMap<Diff, RightDataViewModel>()
                .ForMember(dest => dest.RightData,
                        opts => opts.MapFrom(src => src.RightDiffData)).ReverseMap();
        }
    }
}