using EncoreTIX.Shared.Models;

namespace EncoreTIX.Shared.Dtos
{
    public class AttractionBaseViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class AttractionListViewModel : AttractionBaseViewModel
    {
        public string? ImageUrl { get; set; }
    }

    public class AttractionDetailsViewModel : AttractionListViewModel
    {
        public List<Image> Images { get; set; }
        public Dictionary<string, List<ExternalLink>> ExternalLinks { get; set; }
        public List<EventDetailsViewModel>? Events { get; set; }
    }
}
