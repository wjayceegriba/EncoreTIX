using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace EncoreTIX.Shared.Models
{
    public class Attraction
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
        public string? Locale { get; set; }
        public List<Image> Images { get; set; }
        public Dictionary<string, List<ExternalLink>>? ExternalLinks { get; set; }
        public List<Classification> Classifications { get; set; }

    }
}
