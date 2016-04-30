using System;

namespace Subtle.Model.Models
{
    [Flags]
    public enum SearchMethod
    {
        Hash = 1,
        FullText = 2,
        Imdb = 4
    }
}