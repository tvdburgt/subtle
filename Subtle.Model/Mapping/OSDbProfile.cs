using System;
using AutoMapper;
using Subtle.Model.Responses;
using Subtle.Model.Models;

namespace Subtle.Model.Mapping
{
    public class OSDbProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());
            Mapper.CreateMap<string, decimal?>().ConvertUsing(new DecimalTypeConverter());
            Mapper.CreateMap<string, SearchMethod>().ConvertUsing(new SearchMethodTypeConverter());

            Mapper.CreateMap<SubtitleSearchResult, Subtitle>()
                .ForMember(dest => dest.IsFeatured, opt => opt.ResolveUsing<BooleanValueResolver>().FromMember(src => src.IsFeatured))
                .ForMember(dest => dest.IsHearingImpaired, opt => opt.ResolveUsing<BooleanValueResolver>().FromMember(src => src.IsHearingImpaired));

            Mapper.AssertConfigurationIsValid();
        }

        public override string ProfileName => GetType().Name;
    }
}
