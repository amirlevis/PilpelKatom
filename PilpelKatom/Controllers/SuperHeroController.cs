using Microsoft.AspNetCore.Mvc;
using PilpelKatom.Services.SuperHeroService;

namespace PilpelKatom.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SuperHeroController : ControllerBase
{
   private readonly ISuperHeroService _superHeroService;

   public SuperHeroController(ISuperHeroService superHeroService)
   {
      _superHeroService = superHeroService;
   }
   
   
   [HttpGet]
   public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> GetAll()
   {
      return Ok(await _superHeroService.GetAllHeroes());
   }

   [HttpGet("Id")]
   public async Task<ActionResult<ServiceResponse<GetSuperHeroDto>>> GetSuperHeroById(int id)
   {
      var result = await _superHeroService.GetSuperHeroById(id);
      return Ok(result);
   
   }

   [HttpPost]
   public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> AddHero(AddSuperHeroDto hero)
   {
      var result = await _superHeroService.AddHero(hero);
      return Ok(result);
   }
   
   
   [HttpPut("Id")]
   public async Task<ActionResult<ServiceResponse<GetSuperHeroDto>>> UpdateHero(int id, GetSuperHeroDto request)
   {
      var result = await _superHeroService.UpdateHero(id, request);
      return Ok(result);
   }
   
   [HttpDelete("Id")]
   public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> UpdateHero(int id)
   {
      var result = await _superHeroService.RemoveHero(id);
      return Ok(result);
   
   }

}