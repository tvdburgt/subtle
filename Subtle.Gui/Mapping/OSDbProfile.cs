using System;
using AutoMapper;
using Subtle.Gui.ViewModels;
using Subtle.Model.Responses;

namespace Subtle.Gui.Mapping
{
    public class OSDbProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
            Mapper.CreateMap<string, decimal?>().ConvertUsing(new DecimalTypeConverter());

            Mapper.CreateMap<SubtitleSearchResult, SubtitleViewModel>()
                .ForMember(dest => dest.IsFeatured, opt => opt.ResolveUsing<BooleanValueResolver>().FromMember(src => src.IsFeatured))
                .ForMember(dest => dest.IsHearingImpaired, opt => opt.ResolveUsing<BooleanValueResolver>().FromMember(src => src.IsHearingImpaired));

            Mapper.AssertConfigurationIsValid();
        }

        public override string ProfileName => GetType().Name;
    }
}
