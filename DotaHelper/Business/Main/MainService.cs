using AutoMapper;
using Business.Dto;
using DataModel.Entities;
using DataModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Main
{
    public class MainService : IMainService
    {
        private readonly DbContext Context;
        private readonly IMapper _mapper;

        public MainService(DbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
        }

        public async Task<List<HeroesModel>> GetHeroes()
        {
            var heroes = await Context.Set<Hero>()
                .ToListAsync();

            var result = _mapper.Map<List<HeroesModel>>(heroes.OrderBy(x => x.Id));

            return result;
        }

        public async Task<List<HeroesModel>> GetTopHeroes(GetTopHeroesDto dto)
        {
            var teamHeroes = await Context.Set<HeroRatingTeam>()
                .Where(x => dto.Team1.Contains(x.TeamHeroId))
                .ToListAsync();

            var teamHeroesPoints = teamHeroes
                .GroupBy(x => x.HeroId)
                .Select(x => new HeroesPointsModel()
                {
                        HeroId = x.Key,
                        HeroPoints = x.Sum(s => s.FantasyPoint),
                    })
                .ToList();

            var enemyHeroes = await Context.Set<HeroRatingEnemy>()
                .Where(x => dto.Team2.Contains(x.EnemyHeroId))
                .ToListAsync();

            var enemyHeroesPoints = enemyHeroes
                .GroupBy(x => x.HeroId)
                .Select(x => new HeroesPointsModel()
                {
                    HeroId = x.Key,
                    HeroPoints = x.Sum(s => s.FantasyPoint),
                })
                .ToList();

            var groupedHeroPoints = teamHeroesPoints;
            groupedHeroPoints.AddRange(enemyHeroesPoints);

            var heroPoints = groupedHeroPoints.GroupBy(x => x.HeroId)
                .Select(x => new HeroesPointsModel()
                {
                    HeroId = x.Key,
                    HeroPoints = x.Sum(s => s.HeroPoints),
                })
                .ToList();

            var recommendedHeroes = heroPoints.OrderBy(x => x.HeroPoints).Take(3).Select(x => x.HeroId).ToList();

            var heroes = Context.Set<Hero>()
                .AsNoTracking()
                .Where(x => recommendedHeroes.Contains(x.Id));

            var result = new List<HeroesModel>();

            result = _mapper.Map<List<HeroesModel>>(heroes);

            return result;
        }
    }
}
