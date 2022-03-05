using Business.Dto;
using Business.Parser;
using Common.Logger;
using DataModel.OpenDota;
using DotaHelpet_Tests.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace DotaHelpet_Tests
{
    [TestClass]
    public class ParserServiceTest
    {
        [TestMethod]
        public void GetCredentialsTest()
        {
            var expected = new List<ProxyCredentials>()
            {
                new ProxyCredentials()
                {
                    Host = "103.230.69.185",
                    Port = 59100,
                    UserName = "geskag4",
                    Password = "pass",
                },

                new ProxyCredentials()
                {
                    Host = "166.1.14.247",
                    Port = 59100,
                    UserName = "geskag4",
                    Password = "pass",
                },

                new ProxyCredentials()
                {
                    Host = "166.1.14.88",
                    Port = 59100,
                    UserName = "geskag4",
                    Password = "pass",
                },

                new ProxyCredentials()
                {
                    Host = "166.1.14.248",
                    Port = 59100,
                    UserName = "geskag4",
                    Password = "pass",
                },

                new ProxyCredentials()
                {
                    Host = "166.1.14.89",
                    Port = 59100,
                    UserName = "geskag4",
                    Password = "pass",
                },
            };

            ParserService parserService = new ParserService();

            PrivateObject obj = new PrivateObject(parserService);

            var response = obj.Invoke("GetCredentials");

            var actual = response.GetType().GetProperty("Result").GetValue(response);

            var expectedJson= JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);

            Assert.AreEqual(expectedJson, actualJson);
        }

        [TestMethod]
        public void GetPointsLoseTest_Enter_30_30()
        {
            var expected = -1.3D;

            ParserService parserService = new ParserService();

            PrivateObject obj = new PrivateObject(parserService);

            var actual = obj.Invoke("GetPointsLose", 30, 30);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPointsLoseTest_Enter_30_10()
        {
            var expected = -0.7D;

            ParserService parserService = new ParserService();

            PrivateObject obj = new PrivateObject(parserService);

            var actual = obj.Invoke("GetPointsLose", 30, 10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPointsWinTest_Enter_30_30()
        {
            var expected = 0.7D;

            ParserService parserService = new ParserService();

            PrivateObject obj = new PrivateObject(parserService);

            var actual = obj.Invoke("GetPointsWin", 30, 30);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetPointsWinTest_Enter_30_10()
        {
            var expected = 1.3D;

            ParserService parserService = new ParserService();

            PrivateObject obj = new PrivateObject(parserService);

            var actual = obj.Invoke("GetPointsWin", 30, 10);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RequestOpenDotaApiTest_WrongMatchId()
        {
            Matches expected = null;

            var path = Directory.GetCurrentDirectory();

            ICustomFileLogger customFileLogger = new CustomFileLogger($"{path}/Logs");

            ParserService parserService = new ParserService(customFileLogger);

            PrivateObject obj = new PrivateObject(parserService);

            var ProxyCredentials = new ProxyCredentials()
            {
                Host = "181.214.123.189",
                Port = 59100,
                UserName = "geskag4",
                Password = "G8g6FqX",
            };

            var response = obj.Invoke("RequestOpenDotaApi", 0ul, ProxyCredentials, 0);
            var actual = response.GetType().GetProperty("Result").GetValue(response);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RequestOpenDotaApiTest_WrongCredentials()
        {
            Matches expected = null;

            var path = Directory.GetCurrentDirectory();

            ICustomFileLogger customFileLogger = new CustomFileLogger($"{path}/Logs");

            ParserService parserService = new ParserService(customFileLogger);

            PrivateObject obj = new PrivateObject(parserService);

            var ProxyCredentials = new ProxyCredentials()
            {
                Host = "wrong",
                Port = 59100,
                UserName = "geskag4",
                Password = "G8g6FqX",
            };

            var response = obj.Invoke("RequestOpenDotaApi", 0ul, ProxyCredentials, 0);
            var actual = response.GetType().GetProperty("Result").GetValue(response);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RequestOpenDotaApiTest()
        {
            Matches expected = new Matches()
            {
                MatchId = "6461564000",
                RadiantWin = true,
                Players = new List<Player>()
                {
                    new Player()
                    {
                        Assists = "7",
                        Deaths = "2",
                        HeroId = "94",
                        Kills = "12",
                    },

                    new Player()
                    {
                        Assists = "16",
                        Deaths = "6",
                        HeroId = "84",
                        Kills = "2",
                    },

                    new Player()
                    {
                        Assists = "15",
                        Deaths = "5",
                        HeroId = "67",
                        Kills = "0",
                    },

                    new Player()
                    {
                        Assists = "10",
                        Deaths = "6",
                        HeroId = "104",
                        Kills = "8",
                    },

                    new Player()
                    {
                        Assists = "12",
                        Deaths = "3",
                        HeroId = "40",
                        Kills = "4",
                    },

                    new Player()
                    {
                        Assists = "11",
                        Deaths = "2",
                        HeroId = "42",
                        Kills = "2",
                    },

                    new Player()
                    {
                        Assists = "15",
                        Deaths = "9",
                        HeroId = "50",
                        Kills = "2",
                    },

                    new Player()
                    {
                        Assists = "7",
                        Deaths = "6",
                        HeroId = "81",
                        Kills = "4",
                    },

                    new Player()
                    {
                        Assists = "11",
                        Deaths = "6",
                        HeroId = "2",
                        Kills = "3",
                    },

                    new Player()
                    {
                        Assists = "6",
                        Deaths = "4",
                        HeroId = "101",
                        Kills = "11",
                    },
                },
            };

            var path = Directory.GetCurrentDirectory();

            ICustomFileLogger customFileLogger = new CustomFileLogger($"{path}/Logs");

            ParserService parserService = new ParserService(customFileLogger);

            PrivateObject obj = new PrivateObject(parserService);

            var ProxyCredentials = new ProxyCredentials()
            {
                Host = "181.214.123.189",
                Port = 59100,
                UserName = "geskag4",
                Password = "G8g6FqX",
            };

            var response = obj.Invoke("RequestOpenDotaApi", 6461564000ul, ProxyCredentials, 0);
            var actual = response.GetType().GetProperty("Result").GetValue(response);

            var expectedJson = JsonConvert.SerializeObject(expected);
            var actualJson = JsonConvert.SerializeObject(actual);

            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
