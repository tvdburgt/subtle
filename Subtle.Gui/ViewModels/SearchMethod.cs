using System;

namespace Subtle.Gui.ViewModels
{
    [Flags]
    public enum SearchMethod
    {
        Hash = 1,
        FullText = 2,
        Imdb = 4
    }
}