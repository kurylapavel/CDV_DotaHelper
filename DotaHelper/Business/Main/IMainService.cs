using Business.Dto;
using DataModel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Main
{
    public interface IMainService
    {
        Task<List<HeroesModel>> GetHeroes();

        Task<List<HeroesModel>> GetTopHeroes(GetTopHeroesDto dto);
    }
}
