using System.IO.Compression;
using System.Text.Json;
using System.Media;

namespace osu_backup
{
    public partial class FImport : Form
    {
        private readonly string? importFile;
        private readonly FMain mainRef;

        public FImport(string? importFile, FMain mainRef)
        {
            InitializeComponent();
            this.importFile = importFile;
            this.mainRef = mainRef;
        }

        private async void FImport_Load(object sender, EventArgs e)
        {
            int elapsed = 0;
            TElapsed.Tick += (_, _) =>
            {
                elapsed++;
                LElapsed.Text = "Time elapsed: " + elapsed + " sec";
            };
            TElapsed.Enabled = true;
            TElapsed.Start();

            string osuPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\osu!";
            if (!Directory.Exists(osuPath))
            {
                MessageBox.Show("osu! installation could not be located. Make sure you have installed osu! correctly.");
                return;
            }

            if (this.importFile == null)
            {
                MessageBox.Show("Backup file not specified. You need to select one first to import the data.");
                return;
            }

            string cloudPath = osuPath + "\\.backup";
            if (!Directory.Exists(cloudPath))
            {
                Directory.CreateDirectory(cloudPath);
            }
            string importPath = cloudPath + "\\temp";
            if (Directory.Exists(importPath))
            {
                Directory.Delete(importPath, true);
            }
            Directory.CreateDirectory(importPath);

            PBAll.Maximum = 5;
            PBStep.Value = 0;
            LStep.Text = "Extracting backup file";

            await Task.Run(() => ZipFile.ExtractToDirectory(importFile, importPath));
            string infoFile = importPath + "\\backup-info.json";
            if (!File.Exists(infoFile))
            {
                MessageBox.Show("The specified backup file is invalid.");
                return;
            }
            var info = JsonSerializer.Deserialize<Dictionary<string, object>>(File.ReadAllText(infoFile));
            if (info == null)
            {
                MessageBox.Show("The specified backup file is invalid.");
                return;
            }
            var contains = JsonSerializer.Deserialize<List<string>>((JsonElement)info["contains"]);
            if (contains == null)
            {
                MessageBox.Show("The specified backup file is invalid.");
                return;
            }

            PBStep.Value = 1;
            PBAll.PerformStep();
            Dictionary<BackupPart, List<string>> summary = new();

            foreach (var item in contains)
            {
                if (!Enum.TryParse(item, out BackupPart part))
                {
                    continue;
                }

                PBStep.Value = 0;
                LStep.Text = "Importing " + Enum.GetName(typeof(BackupPart), part);
                List<string> newAssets = new();

                switch (part)
                {
                    case BackupPart.Beatmaps:
                        PBStep.Maximum = 1;
                        string beatmapsIn = importPath + "\\Songs";
                        string beatmapsOut = osuPath + "\\Songs";
                        var beatmaps = new DirectoryInfo(beatmapsIn).GetFiles();
                        foreach (FileInfo beatmap in beatmaps)
                        {
                            var oldFile = new DirectoryInfo(beatmapsOut + "\\" + beatmap.Name[..^4]);
                            if (!oldFile.Exists)
                            {
                                newAssets.Add(beatmap.FullName);
                            }
                        }
                        PBStep.Value = 1;
                        break;
                    case BackupPart.Replays:
                        PBStep.Maximum = 1;
                        string replaysIn = importPath + "\\Replays";
                        string replaysOut = osuPath + "\\Replays";
                        var replays = new DirectoryInfo(replaysIn).GetFiles();
                        foreach (FileInfo replay in replays)
                        {
                            var oldFile = new FileInfo(replaysOut + "\\" + replay.Name);
                            if (!oldFile.Exists)
                            {
                                newAssets.Add(replay.FullName);
                            }
                        }
                        //FileUtils.CopyDirectory(replaysOut, osuPath + "\\Replays", true, false);
                        PBStep.Value = 1;
                        break;
                    case BackupPart.Screenshots:
                        PBStep.Maximum = 1;
                        string screenshotsIn = importPath + "\\Screenshots";
                        string screenshotsOut = osuPath + "\\Screenshots";
                        var screenshots = new DirectoryInfo(screenshotsIn).GetFiles();
                        foreach (FileInfo screenshot in screenshots)
                        {
                            var oldFile = new FileInfo(screenshotsOut + "\\" + screenshot.Name);
                            if (!oldFile.Exists)
                            {
                                newAssets.Add(screenshot.FullName);
                            }
                        }
                        //FileUtils.CopyDirectory(screenshotsOut, osuPath + "\\Screenshots", true, false);
                        PBStep.Value = 1;
                        break;
                    case BackupPart.Skins:
                        PBStep.Maximum = 1;
                        string skinsIn = importPath + "\\Skins";
                        string skinsOut = osuPath + "\\Skins";
                        var skins = new DirectoryInfo(skinsIn).GetFiles();
                        foreach (FileInfo skin in skins)
                        {
                            var oldFile = new FileInfo(skinsOut + "\\" + skin.Name);
                            if (!oldFile.Exists)
                            {
                                newAssets.Add(skin.FullName);
                            }
                        }
                        //FileUtils.CopyDirectory(skinsOut, osuPath + "\\Skins", true, false);
                        PBStep.Value = 1;
                        break;
                }

                summary[part] = newAssets;
            }

            SystemSounds.Exclamation.Play();
            MessageBox.Show("The backup has been imported successfully. You can now view the new assets and apply them.",
                "Your import has finished");
            mainRef.UpdateAnalysis(summary);
            Close();
        }
    }
}
