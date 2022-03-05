using AutoMapper;
using Business.Dto;
using Business.Main;
using DataModel.Entities;
using DataModel.Models;
using DataModel.Profilies;
using DotaHelpet_Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DotaHelpet_Tests
{
    [TestClass]
    public class MainServiceTest
    {
        [TestMethod]
        public void GetTopHeroesTest()
        {
            var expected = new List<HeroesModel>()
            {
                new HeroesModel()
                {
                    HeroId = 99,
                    HeroName = "Bristleback",
                },

                new HeroesModel()
                {
                    HeroId = 87,
                    HeroName = "Disruptor",
                },

                new HeroesModel()
                {
                    HeroId = 20,
                    HeroName = "Vengeful Spirit",
                },
            };

            var getTopHeroesDto = new GetTopHeroesDto()
            {
                Team1 = new List<int> { 10, 11 },
                Team2 = new List<int> { 110, 12 },
            };

            var context = DotaHelperTestsContextFactory.CreateDbContext();

            var mappingConfig = new MapperConfiguration(x =>
            {
                x.AddProfile(new DefaultAutoMapperProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();

            MainService mainService = new MainService(context, mapper);

            PrivateObject obj = new PrivateObject(mainService);

            var actual = mainService.GetTopHeroes(getTopHeroesDto).Result;

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);

            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
