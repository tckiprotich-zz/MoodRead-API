using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetBackend.Models
{
    public class BookDetails
    {
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public int PageCount { get; set; }
        public string SmallThumbnail { get; set; }
        public string Thumbnail { get; set; }
        public string PreviewLink { get; set; }
        public string InfoLink { get; set; }
    }
}