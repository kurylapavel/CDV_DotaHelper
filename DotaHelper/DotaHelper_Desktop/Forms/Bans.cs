using DataModel;
using DataModel.OpenDota;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotaHelper_Desktop.Forms
{
    public partial class Bans : Form
    {
        private string DotaFolderPath;

        public Bans()
        {
            InitializeComponent();
            ReadFolderPath();
        }

    

        private async Task GetUsersIdsFromFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath).Reverse();

            var enemyPlayerIds = new List<string>();

            foreach (var line in lines)
            {
                if (line.Contains("(Lobby"))
                {
                    var players = line.Split(' ').Where(x => x.Contains("[U:")).Take(11).ToList();

                    if (players.Count != 11)
                    {
                        continue;
                    }

                    var userId = players.IndexOf(players[10]);

                    if (userId > 4)
                    {
                        enemyPlayerIds = players
                            .TakeLast(5)
                            .Select(x => x.Substring((x.IndexOf("[U:") + 5), 9))
                            .ToList();
                    }
                    else
                    {
                        enemyPlayerIds = players
                            .Take(5)
                            .Select(x => x.Substring((x.IndexOf("[U:") + 5), 9))
                            .ToList();
                    }

                    break;
                }
            }

            await GetTopBanHero(enemyPlayerIds);
        }

        private async Task GetTopBanHero(List<string> enemyPlayerIds)
        {
            var tasks = new Task[5];

            for (int i = 0; i < 5; i++)
            {
                tasks[i] = RequestOpenDotaApi(enemyPlayerIds[i]);
            }

            tasks = tasks.Where(x => x != null).ToArray();

            await Task.WhenAll(tasks);

            var allHeroIds = new List<int>();

            foreach (var task in tasks)
            {
                var heroIds = ((Task<List<int>>)task).Result;

                allHeroIds.AddRange(heroIds);
            }

            if (allHeroIds == null || !allHeroIds.Any())
            {
                MessageBox.Show("Something heppend, we can recomend you ban hero!");

                return;
            }

            var topHeroIds = allHeroIds.GroupBy(x => x).OrderByDescending(x => x.Count()).Take(5).ToList();
            ShowHero(topHeroIds);

        }

        private void ShowHero(List<IGrouping<int, int>> heroIds)
        {
            PBBanHero.ImageLocation = $"HeroImages/{heroIds[0].Key}.png";
            PBBanHeroS1.ImageLocation = $"HeroImages/{heroIds[1].Key}.png";
            PBBanHeroS2.ImageLocation = $"HeroImages/{heroIds[2].Key}.png";
            PBBanHeroS3.ImageLocation = $"HeroImages/{heroIds[3].Key}.png";
            PBBanHeroS4.ImageLocation = $"HeroImages/{heroIds[4].Key}.png";
        }

        private async Task<List<int>> RequestOpenDotaApi(string enemyPlayerId)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest
                    .Create($"{Constants.DefaulOpenDotaApi}/players/{enemyPlayerId}/recentMatches");

                var httpWebResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                var response = string.Empty;

                using (StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream()))
                {
                    response = sr.ReadToEnd();
                }

                var data = JsonConvert.DeserializeObject<List<Heroes>>(response);

                if (data != null)
                {
                    return data.Select(x => Int32.Parse(x.HeroId)).ToList();
                }

                return new List<int>();
            }
            catch (Exception ex)
            {
                return new List<int>();
            }
        }


        private async Task SaveFolderPath()
        {
            await File.WriteAllTextAsync("DotaFolderPath.txt", DotaFolderPath);
        }

        private async Task ReadFolderPath()
        {
            if (File.Exists("DotaFolderPath.txt"))
            {
                var dotaFolderPath = await File.ReadAllTextAsync("DotaFolderPath.txt");
                var dotaFilePath = $"{dotaFolderPath}\\game\\dota\\server_log.txt";

                if (File.Exists(dotaFilePath))
                {
                    DotaFolderPath = dotaFolderPath;
                    labelPath.Text = dotaFolderPath;
                }
                else
                {
                    DotaFolderPath = String.Empty;
                    LBSelectFolder.Text = "Browse your Dota 2 folder location:";
                }
            }
        }

        private async void BTSelectFolder_Click_1(object sender, EventArgs e)
        {

            folderBrowserDialog1.ShowDialog();

            var dotaFolderPath = folderBrowserDialog1.SelectedPath;
            var dotaFilePath = $"{dotaFolderPath}\\game\\dota\\server_log.txt";

            if (!File.Exists(dotaFilePath))
            {
                MessageBox.Show("Game not found");
                return;
            }
            else
            {
                DotaFolderPath = dotaFolderPath;
                LBSelectFolder.Text = dotaFolderPath;
                await SaveFolderPath();

                await GetUsersIdsFromFile(dotaFilePath);
            }

        }

        private async void BRRefresh_Click_1(object sender, EventArgs e)
        {
            var path = $"{DotaFolderPath}\\game\\dota\\server_log.txt";

            if (File.Exists(path))
            {
                await GetUsersIdsFromFile(path);
            }
            else
            {
                MessageBox.Show("Game folder is not  found, please select it again");
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
