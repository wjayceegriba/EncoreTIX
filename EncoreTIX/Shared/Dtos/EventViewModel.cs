namespace EncoreTIX.Shared.Dtos
{
    public class EventDetailsViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public VenueDetailsViewModel Venue { get; set; }
    }
}
