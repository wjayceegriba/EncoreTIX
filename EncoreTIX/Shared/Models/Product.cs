using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTIX.Shared.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
        public List<Classification> Classifications { get; set; }
    }
}
