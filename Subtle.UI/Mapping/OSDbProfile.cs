using System;
using AutoMapper;
using Subtle.Model.Responses;
using Subtle.UI.ViewModels;

namespace Subtle.UI.Mapping
{
    class OSDbProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<string, DateTime>().ConvertUsing(new DateTimeTypeConverter());

            Mapper.CreateMap<SubtitleSearchResult, SubtitleViewModel>()
                .ForMember(dest => dest.IsFeatured, opt => opt.MapFrom(src => src.IsFeatured == "1"));
        }

        public override string ProfileName => GetType().Name;
    }
}
