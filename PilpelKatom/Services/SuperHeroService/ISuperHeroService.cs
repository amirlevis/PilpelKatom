namespace PilpelKatom.Services.SuperHeroService;

public interface ISuperHeroService
{
    Task<ServiceResponse<List<GetSuperHeroDto>>> GetAllHeroes();
    Task<ServiceResponse<GetSuperHeroDto>> GetSuperHeroById(int id);
    Task<ServiceResponse<GetSuperHeroDto>> AddHero(AddSuperHeroDto hero);
    Task<ServiceResponse<GetSuperHeroDto>> UpdateHero(int id, GetSuperHeroDto request);
    Task<ServiceResponse<List<GetSuperHeroDto>>> RemoveHero(int id);
}