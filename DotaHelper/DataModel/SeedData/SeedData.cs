using DataModel.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DataModel.SeedData
{
    public static class SeedData
    {
        public static void Apply(DbContext context)
        {
            SetHeroes(context);
        }

        private static async void SetHeroes(DbContext context)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Constants.DefaulOpenDotaApi}/heroes");

            var httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();
            var response = string.Empty;

            using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = sr.ReadToEnd();
            }

            var heroes = JsonConvert.DeserializeObject<List<Hero>>(response);

            await context.AddRangeAsync(heroes);

            await context.SaveChangesAsync();
        }
    }
}
