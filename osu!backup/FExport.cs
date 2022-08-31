using System.IO.Compression;
using System.Text.Json;
using System.Media;

namespace osu_backup
{
    public partial class FExport : Form
    {
        private readonly List<BackupPart> backupParts;

        public FExport(List<BackupPart> backupParts)
        {
            InitializeComponent();
            this.backupParts = backupParts;
        }

        private async void FExport_Load(object sender, EventArgs e)
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

            string cloudPath = osuPath + "\\.backup";
            if (!Directory.Exists(cloudPath))
            {
                Directory.CreateDirectory(cloudPath);
            }
            string backupPath = cloudPath + "\\latest-backup";
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }

            var now = DateTime.Now;
            string backupDestination = cloudPath + "\\" + now.ToString("yyyy-MM-dd") + "T" + now.ToString("HH-mm-ss") + "_backup.osb";
            var parts = new List<string>();
            PBAll.Maximum = backupParts.Count + 1;

            foreach (var part in backupParts)
            {
                PBStep.Value = 0;
                LStep.Text = "Exporting " + Enum.GetName(typeof(BackupPart), part);
                switch (part)
                {
                    case BackupPart.Beatmaps:
                        string beatmapsIn = osuPath + "\\Songs";
                        string beatmapsOsuFiles = backupPath + "\\Songs";
                        await FileUtils.CreateOsuMapFiles(beatmapsIn, beatmapsOsuFiles, PBStep);
                        break;
                    case BackupPart.Replays:
                        PBStep.Maximum = 1;
                        string replaysIn = osuPath + "\\Replays";
                        string replaysOut = backupPath + "\\Replays";
                        await Task.Run(() => FileUtils.CopyDirectory(replaysIn, replaysOut, true, true));
                        PBStep.Value = 1;
                        break;
                    case BackupPart.Screenshots:
                        PBStep.Maximum = 1;
                        string screenshotsIn = osuPath + "\\Screenshots";
                        string screenshotsOut = backupPath + "\\Screenshots";
                        await Task.Run(() => FileUtils.CopyDirectory(screenshotsIn, screenshotsOut, true, true));
                        PBStep.Value = 1;
                        break;
                    case BackupPart.Skins:
                        PBStep.Maximum = 1;
                        string skinsIn = osuPath + "\\Skins";
                        string skinsOut = backupPath + "\\Skins";
                        await Task.Run(() => FileUtils.CopyDirectory(skinsIn, skinsOut, true, true));
                        PBStep.Value = 1;
                        break;
                }
                string? name = Enum.GetName(typeof(BackupPart), part);
                if (name != null)
                {
                    parts.Add(name);
                }
                PBAll.PerformStep();
            }
            var info = new Dictionary<string, object>
            {
                ["backupper_version"] = Program.Version,
                ["contains"] = parts
            };

            File.WriteAllText(backupPath + "\\backup-info.json", JsonSerializer.Serialize(info));
            LStep.Text = "Compressing backup";
            PBStep.Maximum = 1;
            await Task.Run(() => ZipFile.CreateFromDirectory(backupPath, backupDestination, CompressionLevel.Fastest, false));
            PBStep.Value = 1;
            PBAll.PerformStep();
            Directory.Delete(backupPath, true);
            TElapsed.Stop();
            TElapsed.Enabled = false;

            SystemSounds.Exclamation.Play();
            MessageBox.Show("The backup has been created successfully.\n" +
                "File size: " + FileUtils.FileSize(new FileInfo(backupDestination)) + "\n" +
                "Location: " + backupDestination,
                "Your backup is ready");
            Close();
        }
    }
}
