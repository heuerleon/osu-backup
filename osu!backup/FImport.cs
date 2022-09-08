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

            if (importFile == null)
            {
                MessageBox.Show("Backup file not specified. You need to select one first to import the data.");
                return;
            }

            string backupPath = osuPath + "\\.backup";
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }
            string importPath = backupPath + "\\temp";
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

                string dirIn = importPath + "\\" + item;
                string dirOut = osuPath + "\\" + item;

                switch (part)
                {
                    case BackupPart.Songs:
                        PBStep.Maximum = 1;
                        var songs = new DirectoryInfo(dirIn).GetFiles();
                        foreach (FileInfo song in songs)
                        {
                            var oldFile = new DirectoryInfo(dirOut + "\\" + song.Name[..^4]);
                            if (!oldFile.Exists)
                            {
                                newAssets.Add(song.FullName);
                            }
                        }
                        PBStep.Value = 1;
                        break;
                    case BackupPart.Replays:
                    case BackupPart.Screenshots:
                    case BackupPart.Skins:
                        PBStep.Maximum = 1;
                        var files = new DirectoryInfo(dirIn).GetFiles();
                        foreach (FileInfo file in files)
                        {
                            var oldFile = new FileInfo(dirOut + "\\" + file.Name);
                            if (!oldFile.Exists)
                            {
                                newAssets.Add(file.FullName);
                            }
                        }
                        PBStep.Value = 1;
                        break;
                }

                summary[part] = newAssets;
            }

            SystemSounds.Exclamation.Play();
            MessageBox.Show("The backup has been imported successfully. You can now view the new assets and apply them.",
                "Your import has finished");
            mainRef.UpdateAnalysis(summary);
            mainRef.Imported = true;
            Close();
        }


    }
}
