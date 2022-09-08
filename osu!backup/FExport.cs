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

            string backupPath = osuPath + "\\.backup";
            if (!Directory.Exists(backupPath))
            {
                Directory.CreateDirectory(backupPath);
            }
            string latestBackupPath = backupPath + "\\latest-backup";
            if (!Directory.Exists(latestBackupPath))
            {
                Directory.CreateDirectory(latestBackupPath);
            }

            var now = DateTime.Now;
            string backupDestination = backupPath + "\\" + now.ToString("yyyy-MM-dd") + "T" + now.ToString("HH-mm-ss") + "_backup.osb";
            var parts = new List<string>();
            PBAll.Maximum = backupParts.Count + 1;

            foreach (var part in backupParts)
            {
                PBStep.Value = 0;
                LStep.Text = "Exporting " + Enum.GetName(typeof(BackupPart), part);

                string dirIn = osuPath + "\\" + part.ToString();
                string dirOut = latestBackupPath + "\\" + part.ToString();

                switch (part)
                {
                    case BackupPart.Songs:
                        await FileUtils.CreateOsuMapFiles(dirIn, dirOut, PBStep);
                        break;
                    case BackupPart.Replays:
                    case BackupPart.Screenshots:
                    case BackupPart.Skins:
                        PBStep.Maximum = 1;
                        await Task.Run(() => FileUtils.CopyDirectory(dirIn, dirOut, true, true));
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

            File.WriteAllText(latestBackupPath + "\\backup-info.json", JsonSerializer.Serialize(info));
            LStep.Text = "Compressing backup";
            PBStep.Maximum = 1;
            PBStep.Value = 0;
            await Task.Run(() => ZipFile.CreateFromDirectory(latestBackupPath, backupDestination, CompressionLevel.Fastest, false));
            PBStep.Value = 1;
            PBAll.PerformStep();
            Directory.Delete(latestBackupPath, true);
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
