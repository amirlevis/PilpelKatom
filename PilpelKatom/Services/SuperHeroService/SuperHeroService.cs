namespace PilpelKatom.Services.SuperHeroService;

public class SuperHeroService: ISuperHeroService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public SuperHeroService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    
    public async Task<ServiceResponse<List<GetSuperHeroDto>>> GetAllHeroes()
    {
        var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>
        {
            Data = _mapper.Map<List<GetSuperHeroDto>>(await _context.SuperHeroes.ToListAsync())
        };
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSuperHeroDto>> GetSuperHeroById(int id)
    {
        var hero = await _context.SuperHeroes.FirstOrDefaultAsync(s => s.Id == id);
        var serviceResponse = new ServiceResponse<GetSuperHeroDto>
        {
            Data = _mapper.Map<GetSuperHeroDto>(hero),
            Success = hero is not null,
            Message = hero is not null ? "" : "Hero was not found"
        };

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSuperHeroDto>> AddHero(AddSuperHeroDto hero)
    {
        var serviceResponse = new ServiceResponse<GetSuperHeroDto>();
        try
        {
            
            var result = await _context.SuperHeroes.AddAsync(_mapper.Map<SuperHero>(hero));
            await _context.SaveChangesAsync();
            serviceResponse.Data = _mapper.Map<GetSuperHeroDto>(result.Entity);
        }
        catch (Exception e)
        {
            serviceResponse.Data = null;
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<GetSuperHeroDto>> UpdateHero(int id, GetSuperHeroDto request)
    {
        var serviceResponse = new ServiceResponse<GetSuperHeroDto>();
        try
        {
            var superHero = await _context.SuperHeroes.FirstOrDefaultAsync(s => s.Id == id);
            if (superHero is not null)
            {
                superHero.Name = request.Name;
                superHero.FirstName = request.FirstName;
                superHero.LastName = request.LastName;
                superHero.Place = request.Place;
                await _context.SaveChangesAsync();
            }
            serviceResponse.Data = _mapper.Map<GetSuperHeroDto>(superHero);
            serviceResponse.Success = superHero is not null;
            serviceResponse.Message = superHero is not null ? "" : "Hero was not found";
        }
        catch (Exception e)
        {
            serviceResponse.Data = null;
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetSuperHeroDto>>> RemoveHero(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
        try
        {
            var superHero = await _context.SuperHeroes.FirstOrDefaultAsync(s => s.Id == id);
            if (superHero is not null)
            {
                _context.SuperHeroes.Remove(superHero);
                await _context.SaveChangesAsync();
            }

            serviceResponse.Data = superHero is not null ? _mapper.Map<List<GetSuperHeroDto>>(await _context.SuperHeroes.ToListAsync()) : null;
            serviceResponse.Success = superHero is not null;
            serviceResponse.Message = superHero is not null ? "" : "Hero was not found";
        }
        catch (Exception e)
        {
            serviceResponse.Data = null;
            serviceResponse.Success = false;
            serviceResponse.Message = e.Message;
        }
        return serviceResponse;
    }
}