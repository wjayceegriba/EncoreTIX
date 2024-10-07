using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTIX.Shared.Models
{
    public class ClassificationItem
    {
        public string? Id { get;set; }
        public string? Name { get;set; }
    }
    public class Classification
    {
        public bool Primary { get; set; } = false;
        public ClassificationItem? Segment { get; set; }
        public ClassificationItem? Genre { get; set; }
        public ClassificationItem? SubGenre { get; set; }
        public ClassificationItem? Type { get; set; }
        public ClassificationItem? SubType { get; set; }
        public bool Family { get; set; } = false;
    }
}
