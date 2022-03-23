using System.IO.Compression;
using System.Text.Json;
using System.Media;
using System.Runtime.InteropServices;

namespace osu_backup
{
    public partial class FMain : Form
    {
        private string? importFile = null;

        public FMain()
        {
            InitializeComponent();
        }

        private void BAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CLBSelection.Items.Count; i++)
            {
                CLBSelection.SetItemChecked(i, true);
            }
        }

        private void BNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CLBSelection.Items.Count; i++)
            {
                CLBSelection.SetItemChecked(i, false);
            }
        }

        private async void BExport_Click(object sender, EventArgs e)
        {
            string osuPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\osu!";
            if (!Directory.Exists(osuPath))
            {
                MessageBox.Show("osu! installation could not be located. Make sure you have installed osu! correctly.");
                return;
            }

            string cloudPath = osuPath + "\\.cloud";
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

            ActiveForm.Cursor = Cursors.WaitCursor;
            TCMain.Enabled = false;
            await Task.Run(() =>
            {
                var parts = new List<string>();
                foreach(var index in CLBSelection.CheckedIndices)
                {
                    if (!Enum.IsDefined(typeof(BackupPart), index))
                    {
                        continue;
                    }
                    var part = (BackupPart)index;
                    switch(part)
                    {
                        case BackupPart.Beatmaps:
                            string beatmapsIn = osuPath + "\\Songs";
                            string beatmapsOut = backupPath + "\\beatmaps.json";
                            File.WriteAllText(beatmapsIn, JsonSerializer.Serialize(RetrieveBeatmaps(beatmapsOut)));
                            break;
                        case BackupPart.Replays:
                            string replaysIn = osuPath + "\\Replays";
                            string replaysOut = backupPath + "\\replays.zip";
                            ZipFile.CreateFromDirectory(replaysIn, replaysOut, CompressionLevel.SmallestSize, false);
                            break;
                        case BackupPart.Screenshots:
                            string screenshotsIn = osuPath + "\\Screenshots";
                            string screenshotsOut = backupPath + "\\screenshots.zip";
                            ZipFile.CreateFromDirectory(screenshotsIn, screenshotsOut, CompressionLevel.SmallestSize, false);
                            break;
                        case BackupPart.Skins:
                            string skinsIn = osuPath + "\\Skins";
                            string skinsOut = backupPath + "\\skins.zip";
                            ZipFile.CreateFromDirectory(skinsIn, skinsOut, CompressionLevel.SmallestSize, false);
                            break;
                    }
                    string? name = Enum.GetName(typeof(BackupPart), part);
                    if (name != null)
                    {
                        parts.Add(name);
                    }
                }
                var info = new Dictionary<string, object>
                {
                    ["backupper_version"] = Program.Version,
                    ["contains"] = parts
                };
                File.WriteAllText(backupPath + "\\backup-info.json", JsonSerializer.Serialize(info));
                ZipFile.CreateFromDirectory(backupPath, backupDestination, CompressionLevel.Fastest, false);
                Directory.Delete(backupPath, true);
            });
            TCMain.Enabled = true;
            Cursor = Cursors.Default;
            SystemSounds.Exclamation.Play();
            MessageBox.Show("The backup has been created successfully.\n" +
                "File size: " + FileSize(new FileInfo(backupDestination)) + "\n" +
                "Location: " + backupDestination,
                "Your backup is ready");
        }

        private Dictionary<string, string> RetrieveBeatmaps(string source)
        {
            var result = new Dictionary<string, string>();
            foreach (var beatmap in Directory.GetDirectories(source))
            {
                var fullName = new DirectoryInfo(beatmap).Name.Split(' ');
                string id = fullName[0];
                if (!result.ContainsKey(id))
                {
                    string name = string.Join(" ", fullName[1..]);
                    result.Add(id, name);
                }
            }
            return result;
        }

        private void CopyDirectory(string sourceDir, string destinationDir, bool recursive)
        {
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
            {
                return;
            }

            Directory.CreateDirectory(destinationDir);
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }

            DirectoryInfo[] children = dir.GetDirectories();
            if (recursive)
            {
                foreach (DirectoryInfo subDir in children)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    CopyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }

        private string FileSize(FileInfo file)
        {
            long size = file.Length;
            string[] suffixes = { "bytes", "KB", "MB", "GB", "TB"};
            int unit = 0;
            for (int i = 0; i < suffixes.Length; i++) 
            {
                if (size > Math.Pow(1024, i))
                {
                    unit = i;
                }
            }
            double newSize = Math.Floor(size / Math.Pow(1024, unit));
            return newSize + " " + suffixes[unit];
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            foreach (var part in Enum.GetValues(typeof(BackupPart)))
            {
                string? name = Enum.GetName(typeof(BackupPart), part);
                if (name != null)
                {
                    CLBSelection.Items.Add(name);
                }
            }
        }

        private void TPImport_DragDrop(object sender, EventArgs e)
        {

        }

        private void BChoose_Click(object sender, EventArgs e)
        {
            if (OFDChoose.ShowDialog() == DialogResult.OK)
            {
                importFile = OFDChoose.FileName;
            }
        }

        private async void BImport_Click(object sender, EventArgs e)
        {
            if (importFile == null)
            {
                MessageBox.Show("Backkup file not specified. You need to select one first to import the data.");
                return;
            }
            string osuPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\osu!";
            if (!Directory.Exists(osuPath))
            {
                MessageBox.Show("osu! installation could not be located. Make sure you have installed osu! correctly.");
                return;
            }

            string cloudPath = osuPath + "\\.cloud";
            if (!Directory.Exists(cloudPath))
            {
                Directory.CreateDirectory(cloudPath);
            }
            string importPath = cloudPath + "\\temp";
            if (!Directory.Exists(importPath))
            {
                Directory.Delete(importPath, true);
                Directory.CreateDirectory(importPath);
            }

            ActiveForm.Cursor = Cursors.WaitCursor;
            TCMain.Enabled = false;
            await Task.Run(() =>
            {
                ZipFile.ExtractToDirectory(importFile, importPath);
                string infoFile = importPath + "\\backup-info.json";
                if (!File.Exists(infoFile))
                {
                    MessageBox.Show("The specified backup file is invalid.");
                    return;
                }
                var info = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(infoFile));
                if (info == null)
                {
                    MessageBox.Show("The specified backup file is invalid.");
                    return;
                }
                var contains = JsonSerializer.Deserialize<List<string>>(info["contains"]);
                if (contains == null)
                {
                    MessageBox.Show("The specified backup file is invalid.");
                    return;
                }

                Dictionary<string, string>? beatmaps = null;

                foreach (var item in contains)
                {
                    BackupPart part;
                    if (!Enum.TryParse(item, out part))
                    {
                        continue;
                    }
                    switch (part)
                    {
                        case BackupPart.Beatmaps:
                            string beatmapsIn = importPath + "\\beatmaps.json";
                            string beatmapsOut = importPath + "\\Songs";
                            beatmaps = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText(beatmapsIn));
                            break;
                        case BackupPart.Replays:
                            string replays = osuPath + "\\Replays";
                            string replayTarget = backupPath + "\\replays.zip";
                            ZipFile.CreateFromDirectory(replays, replayTarget, CompressionLevel.SmallestSize, false);
                            break;
                        case BackupPart.Screenshots:
                            string screenshots = osuPath + "\\Screenshots";
                            string screenshotTarget = backupPath + "\\screenshots.zip";
                            ZipFile.CreateFromDirectory(screenshots, screenshotTarget, CompressionLevel.SmallestSize, false);
                            break;
                        case BackupPart.Skins:
                            string skins = osuPath + "\\Skins";
                            string skinTarget = backupPath + "\\skins.zip";
                            ZipFile.CreateFromDirectory(skins, skinTarget, CompressionLevel.SmallestSize, false);
                            break;
                    }
                    string? name = Enum.GetName(typeof(BackupPart), part);
                    if (name != null)
                    {
                        parts.Add(name);
                    }
                }
                var info = new Dictionary<string, object>
                {
                    ["backupper_version"] = Program.Version,
                    ["contains"] = parts
                };
                File.WriteAllText(backupPath + "\\backup-info.json", JsonSerializer.Serialize(info));
                ZipFile.CreateFromDirectory(backupPath, backupDestination, CompressionLevel.Fastest, false);
                Directory.Delete(backupPath, true);
            });
            TCMain.Enabled = true;
            Cursor = Cursors.Default;
            SystemSounds.Exclamation.Play();
            MessageBox.Show("The backup has been created successfully.\n" +
                "File size: " + FileSize(new FileInfo(backupDestination)) + "\n" +
                "Location: " + backupDestination,
                "Your backup is ready");
        }
    }
}