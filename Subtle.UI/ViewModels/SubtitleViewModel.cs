using System;

namespace Subtle.UI.ViewModels
{
    public class SubtitleViewModel
    {
        public string Id { get; set; }
        public string FileName { get; set; }
        public string Language { get; set; }
        public string FileFormat { get; set; }
        public DateTime UploadDate { get; set; }
        public decimal Rating { get; set; }
        public int DownloadCount { get; set; }
        public bool IsFeatured { get; set; }
        public string Url { get; set; }
    }
}