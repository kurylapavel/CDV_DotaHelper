using Business.Dto;
using Common.Logger;
using DataModel;
using DataModel.Entities;
using DataModel.OpenDota;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Parser
{
    public class ParserService : IParserService
    {
        private readonly DbContext Context;
        private readonly ICustomFileLogger _logger;

        private IQueryable<Hero> Heroes;
        private List<Matches> Matches = new List<Matches>();
        private ulong MatchId;
        private bool ScanInProgress  = true;

        public ParserService(DbContext context, ICustomFileLogger logger)
        {
            Context = context;
            _logger = logger;

            Heroes = GetHeroes();
        }

        public async Task Parse()
        {
            var processDataThread = new Thread(ProcessDataThread);
            processDataThread.Start();

            var creadentials = await GetCredentials();
            var proxyCount = creadentials.Count;

            int scan = 900;

            MatchId = await GetMathchIdStart();

            var tasks = new Task[scan];

            var maxRequests = proxyCount * Constants.RequestsPerMinute;
            var taskIndex = 0;

            try
            {
                for (int j = 0; j < scan / maxRequests; j++)
                {
                    var stopWatch = new Stopwatch();
                    stopWatch.Start();

                    for (int i = 0; i < maxRequests; i++)
                    {
                        var proxyIndex = i / Constants.RequestsPerMinute;

                        tasks[taskIndex] = RequestOpenDotaApi(MatchId, creadentials[proxyIndex], i);
                        taskIndex++;
                    }

                    var delay = 60000 - (int)stopWatch.Elapsed.TotalMilliseconds;
                    stopWatch.Stop();

                    if (scan > taskIndex + 1)
                    {
                        Thread.Sleep(delay);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex, "try create tasks");
            }

            tasks = tasks.Where(x => x != null).ToArray();

            await Task.WhenAll(tasks);
            ScanInProgress = false;
            await SaveMatchId();
        }

        private void ProcessDataThread()
        {
            while (ScanInProgress || (Matches != null && Matches.Any()))
            {
                if (Matches != null && Matches.Any())
                {
                    try
                    {
                        Task.Run(async () => await ProcessData(Matches[0]));
                        Matches.RemoveAt(0);
                    }
                    catch (Exception ex)
                    {
                        _logger.Log(ex, "Process second thread");
                    }
                    
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private async Task SaveMatchId()
        {
            var config = await Context.Set<ParsedMatches>().FirstOrDefaultAsync();

            config.ParsedMatchesCount = config.ParsedMatchesCount + (int)(MatchId - config.LastParsedMatchId);
            config.LastParsedMatchId = MatchId;

            await Context.SaveChangesAsync();
        }

        private async Task ProcessData(Matches matches)
        {
            var max = 15;

            for (int i=0; i < matches.Players.Count; i++)
            {
                var player = matches.Players[i];

                var heroKDA = (double)(int.Parse(player.Kills) + int.Parse(player.Assists)) / int.Parse(player.Deaths);
                var heroId = int.Parse(player.HeroId);
                var hero = await Heroes.FirstOrDefaultAsync(x => x.Id == heroId);
                var heroAvg = hero.AverageKDA;

                //var points = matches.RadiantWin ? GetPointsWin(heroKDA, heroAvg) : GetPointsLose(heroKDA, heroAvg);
                var point = 0D;

                var teamIds = new List<int>();
                var enemyTeamIds = new List<int>();

                if (i < 5)
                {
                    point = matches.RadiantWin ? GetPointsWin(heroKDA, heroAvg) : GetPointsLose(heroKDA, heroAvg);

                    teamIds = matches.Players.Take(5).Select(x => int.Parse(x.HeroId)).ToList();
                    enemyTeamIds = matches.Players.TakeLast(5).Select(x => int.Parse(x.HeroId)).ToList();
                }
                else
                {
                    point = matches.RadiantWin ? GetPointsLose(heroKDA, heroAvg) : GetPointsWin(heroKDA, heroAvg);

                    teamIds = matches.Players.TakeLast(5).Select(x => int.Parse(x.HeroId)).ToList();
                    enemyTeamIds = matches.Players.Take(5).Select(x => int.Parse(x.HeroId)).ToList();
                }

                await UpdateDb(point, heroId, enemyTeamIds, teamIds);
            }
        }

        private async Task IncreaseMathId()
        {
            MatchId = MatchId + 1;
        }

        private async Task UpdateDb(double points, int heroId, List<int> enemyTeamIds, List<int> teamIds)
        {
            var heroRatingTeams = Context.Set<HeroRatingTeam>()
                .Where(x => x.HeroId == heroId && teamIds.Contains(x.TeamHeroId));

            var heroRatingEnemies = Context.Set<HeroRatingEnemy>()
                .Where(x => x.HeroId == heroId && enemyTeamIds.Contains(x.EnemyHeroId));

            foreach (var teamId in teamIds)
            {
                if (teamId == heroId)
                {
                    continue;
                }

                var heroRatingTeam = await heroRatingTeams
                    .FirstOrDefaultAsync(x => x.TeamHeroId == teamId);

                if (heroRatingTeam == null)
                {
                    var newHeroRatingTeam = new HeroRatingTeam()
                    {
                        HeroId = heroId,
                        FantasyPoint = points,
                        TeamHeroId = teamId,
                        ParsedMatches = 1,
                    };

                    await Context.AddAsync(newHeroRatingTeam);
                }
                else
                {
                    heroRatingTeam.FantasyPoint = heroRatingTeam.FantasyPoint + points;
                    heroRatingTeam.ParsedMatches = heroRatingTeam.ParsedMatches + 1;
                }

                await Context.SaveChangesAsync();
            }

            foreach (var teamId in enemyTeamIds)
            {
                var heroRatingEnemy = await heroRatingEnemies
                    .FirstOrDefaultAsync(x => x.EnemyHeroId == teamId);

                if (heroRatingEnemy == null)
                {
                    
                       var newHeroRatingTeam = new HeroRatingEnemy()
                    {
                        HeroId = heroId,
                        FantasyPoint = points,
                        EnemyHeroId = teamId,
                        ParsedMatches = 1,
                    };

                    await Context.AddAsync(newHeroRatingTeam);
                }
                else
                {
                    heroRatingEnemy.FantasyPoint = heroRatingEnemy.FantasyPoint + points;
                    heroRatingEnemy.ParsedMatches = heroRatingEnemy.ParsedMatches + 1;
                }

                await Context.SaveChangesAsync();
            }

        }

        private double GetPointsWin(double heroKDA, double heroAvg)
        {
            var points = 0D;

            if (heroKDA > heroAvg)
            {
                points += Constants.Weight + Constants.KDAWeight;
            }
            else
            {
                points += Constants.Weight - Constants.KDAWeight;
            }

            return points;
        }

        private double GetPointsLose(double heroKDA, double heroAvg)
        {
            var points = 0D;

            if (heroKDA > heroAvg)
            {
                points -= Constants.Weight - Constants.KDAWeight;
            }
            else
            {
                points -= Constants.Weight + Constants.KDAWeight;
            }

            return points;
        }

        private async Task<List<ProxyCredentials>> GetCredentials()
        {
            var proxies = await File.ReadAllLinesAsync("../../../../Business/Parser/Proxy/Proxy.txt");

            var result = new List<ProxyCredentials>();

            foreach (var proxy in proxies)
            {
                var creads = proxy.Split(':');

                result.Add(new ProxyCredentials()
                {
                    Host = creads[0],
                    Port = int.Parse(creads[1]),
                    UserName = creads[2],
                    Password = creads[3],
                });
            }

            return result;
        }

        private async Task<ulong> GetMathchIdStart()
        {
            var config = await Context.Set<ParsedMatches>()
                .FirstOrDefaultAsync();

            return config.LastParsedMatchId;
        }

        private async Task<Matches> RequestOpenDotaApi(ulong matchId, ProxyCredentials credentials, int id)
        {
            Console.WriteLine($"for id: {id}");
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Constants.DefaulOpenDotaApi}/matches/{matchId}");

                WebProxy myProxy = new WebProxy(credentials.Host, credentials.Port);
                myProxy.Credentials = new NetworkCredential(credentials.UserName, credentials.Password);
                httpWebRequest.Proxy = myProxy;

                var httpWebResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                var response = string.Empty;

                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = sr.ReadToEnd();
                }

                var data = JsonConvert.DeserializeObject<Matches>(response);

                await IncreaseMathId();

                Matches.Add(data);

                return data;
            }
            catch (Exception ex)
            {
                _logger.Log(ex, "Request open dota api");
                await IncreaseMathId();
                return null;
            }
        }

        private IQueryable<Hero> GetHeroes()
        {
            var heroes = Context.Set<Hero>()
                .AsQueryable();

            return heroes;
        }
    }
}
