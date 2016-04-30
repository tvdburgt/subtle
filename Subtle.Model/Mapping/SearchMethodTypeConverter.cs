using System;
using AutoMapper;
using Subtle.Model.Models;
using Subtle.Model.Responses;

namespace Subtle.Model.Mapping
{
    public class SearchMethodTypeConverter : TypeConverter<string, SearchMethod>
    {
        protected override SearchMethod ConvertCore(string source)
        {
            switch (source)
            {
                case SubtitleSearchResult.SearchMethods.Hash:
                    return SearchMethod.Hash;
                case SubtitleSearchResult.SearchMethods.FullText:
                    return SearchMethod.FullText;
                case SubtitleSearchResult.SearchMethods.Imdb:
                    return SearchMethod.Imdb;
                default:
                    throw new NotSupportedException($"Unhandled search method: {source}");
            }
        }
    }
}
