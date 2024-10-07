namespace EncoreTIX.Server.Services.EventService.MapperProfile
{
    public class EventMapperProfile : AutoMapper.Profile
    {
        public EventMapperProfile()
        {
            CreateMap<Event, EventDetailsViewModel>()
                .ForMember(f => f.Date, i => i.MapFrom(m => m.Dates.Start.DateTime));
        }
    }
}
