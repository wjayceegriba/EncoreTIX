using EncoreTIX.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTIX.Shared.Response
{
    public class DiscoveryApiResponse
    {
        public List<dynamic> _Embedded { get; set; }
        public List<dynamic> _Links { get; set; }
        public dynamic Page { get; set; }
    }
}
