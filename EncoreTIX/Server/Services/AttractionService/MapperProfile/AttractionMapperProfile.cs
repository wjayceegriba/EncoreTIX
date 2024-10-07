namespace EncoreTIX.Server.Services.AttractionService.MapperProfile
{
    public class AttractionMapperProfile : AutoMapper.Profile
    {
        public AttractionMapperProfile()
        {
            CreateMap<Attraction, AttractionListViewModel>();
            CreateMap<Attraction, AttractionDetailsViewModel>();
        }
    }
}
