using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTIX.Shared.Models
{
    public class Image
    {
        public string? Ratio { get; set; }
        public string? Url { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Fallback { get; set; } = false;
    }
}
