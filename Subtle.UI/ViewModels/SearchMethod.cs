using System;

namespace Subtle.UI.ViewModels
{
    [Flags]
    public enum SearchMethod
    {
        Hash = 1,
        FullText = 2,
        Imdb = 4
    }
}