using System.IO.Compression;
using System.Text.Json;
using System.Media;

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

        private void BExport_Click(object sender, EventArgs e)
        {

            var parts = new List<BackupPart>();
            foreach (var index in CLBSelection.CheckedIndices)
            {
                if (!Enum.IsDefined(typeof(BackupPart), index))
                {
                    continue;
                }
                var part = (BackupPart)index;
                parts.Add(part);
            }
            var exportForm = new FExport(parts);
            exportForm.ShowDialog();
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

        private void BChoose_Click(object sender, EventArgs e)
        {
            if (OFDChoose.ShowDialog() == DialogResult.OK)
            {
                importFile = OFDChoose.FileName;
            }
        }

        private async void BImport_Click(object sender, EventArgs e)
        {
        }

        private void TPImport_DragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data;
            if (data == null) {
                return;
            }
            if (data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
        }

        private void TPImport_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data;
            if (data == null)
            {
                return;
            }
            var args = (string[])data.GetData(DataFormats.FileDrop);
            importFile = args[0];
            MessageBox.Show("The backup file has been set to " + importFile);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void BAnalyse_Click(object sender, EventArgs e)
        {
            if (importFile == null)
            {
                MessageBox.Show("Backup file not specified. You need to select one first to import the data.");
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
            if (Directory.Exists(importPath))
            {
                Directory.Delete(importPath, true);
            }
            Directory.CreateDirectory(importPath);

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

                foreach (var item in contains)
                {
                    if (!Enum.TryParse(item, out BackupPart part))
                    {
                        continue;
                    }
                    switch (part)
                    {
                        case BackupPart.Beatmaps:
                            string beatmapsIn = importPath + "\\Songs";
                            string beatmapsOut = osuPath + "\\Songs";
                            //ZipFile.ExtractToDirectory(beatmapsIn, beatmapsOut, true);
                            break;
                        case BackupPart.Replays:
                            string replaysIn = importPath + "\\Replays";
                            string replaysOut = osuPath + "\\Replays";
                            //ZipFile.ExtractToDirectory(replaysIn, replaysOut, true);
                            //FileUtils.CopyDirectory(replaysOut, osuPath + "\\Replays", true, false);
                            break;
                        case BackupPart.Screenshots:
                            string screenshotsIn = importPath + "\\Screenshots";
                            string screenshotsOut = osuPath + "\\Screenshots";
                            //ZipFile.ExtractToDirectory(screenshotsIn, screenshotsOut, true);
                            //FileUtils.CopyDirectory(screenshotsOut, osuPath + "\\Screenshots", true, false);
                            break;
                        case BackupPart.Skins:
                            string skinsIn = importPath + "\\Skins";
                            string skinsOut = osuPath + "\\Skins";
                            //ZipFile.ExtractToDirectory(skinsIn, skinsOut, true);
                            //FileUtils.CopyDirectory(skinsOut, osuPath + "\\Skins", true, false);
                            break;
                    }
                }
            });
            TCMain.Enabled = true;
            Cursor = Cursors.Default;
            SystemSounds.Exclamation.Play();
            MessageBox.Show("The backup has been imported successfully.",
                "Your import has finished");
        }
    }
}