namespace PilpelKatom;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SuperHero, GetSuperHeroDto>();
        CreateMap<AddSuperHeroDto, SuperHero>();
        CreateMap<AddSuperHeroDto, GetSuperHeroDto>();
        
        CreateMap<Character,GetCharacterDto>();
        CreateMap<AddCharacterDto,Character>();
    }
}