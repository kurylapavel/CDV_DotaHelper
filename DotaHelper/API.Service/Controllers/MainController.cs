using Business.Dto;
using Business.Main;
using DataModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Service.Controllers
{
    [Route("api/main")]
    public class MainController : Controller
    {
        private readonly IMainService _mainService;
        public MainController(IMainService mainService)
        {
            _mainService = mainService;
        }

        [HttpGet("heroes")]
        [AllowAnonymous]
        public async Task<List<HeroesModel>> GetHeroes()
        {
            var result = await _mainService.GetHeroes();
            return result;
        }

        [HttpGet("top-heroes")]
        [AllowAnonymous]
        public async Task<List<HeroesModel>> GetTopHeroes(GetTopHeroesDto dto)
        {
            var result = await _mainService.GetTopHeroes(dto);
            return result;
        }
    }
}
