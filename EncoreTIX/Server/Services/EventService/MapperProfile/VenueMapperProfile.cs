namespace EncoreTIX.Server.Services.EventService.MapperProfile
{
    public class VenueMapperProfile : AutoMapper.Profile
    {
        public VenueMapperProfile()
        {
            CreateMap<Venue, VenueDetailsViewModel>();
        }
    }
}
