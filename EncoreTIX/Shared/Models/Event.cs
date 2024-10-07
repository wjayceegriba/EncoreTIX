using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncoreTIX.Shared.Models
{
    public class Event
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
        public string? Locale { get; set; }
        public List<Image> Images { get; set; }
        public EventDate Dates { get; set; }
        public List<Classification> Classifications { get; set; }
        public Promoter Promoter { get; set; }
        public List<Promoter> Promoters { get; set; }
        public EventEmbdedded _Embedded { get; set; }
    }

    public class EventEmbdedded
    {
        public List<Venue> Venues { get; set; }
        public List<Attraction> Attractions { get; set; }
    }

    public class EventDate
    {
        public EventDateStart? Start { get; set; }
        public string? Timezone { get; set; }
        public EventStatus? Status { get; set; }
        public bool SpanMultipleDays { get; set; }
    }

    public class EventDateStart
    {
        public string? LocalDate { get; set; }
        public string? LocalTime { get; set; }
        public DateTime? DateTime { get; set; }
    }

    public class EventStatus
    {
        public string? Code { get; set; }
    }
}
