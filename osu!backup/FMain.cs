using System.IO.Compression;
using System.Text.Json;
using System.Media;
using System.Diagnostics;

namespace osu_backup
{
    public partial class FMain : Form
    {
        private string? importFile = null;
        public bool Imported { private get; set; }
        public Dictionary<BackupPart, List<string>>? importSummary;

        public FMain()
        {
            InitializeComponent();
            var logoFile = "assets/logo.ico";
            if (!File.Exists(logoFile))
            {
                logoFile = "../../../assets/logo.ico"; // find logo when in debug mode
            }

            if (File.Exists(logoFile)) // logo might still not be found
            {
                using var stream = File.OpenRead(logoFile);
                Icon = new Icon(stream);
            }

        }

        private void BAll_Click(object sender, EventArgs e)
        {
            CBSongs.Checked = true;
            CBReplays.Checked = true;
            CBScreenshots.Checked = true;
            CBSkins.Checked = true;
        }

        private void BNone_Click(object sender, EventArgs e)
        {
            CBSongs.Checked = false;
            CBReplays.Checked = false;
            CBScreenshots.Checked = false;
            CBSkins.Checked = false;
        }

        private void BExport_Click(object sender, EventArgs e)
        {
            var parts = new List<BackupPart>();
            string osuPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\osu!";

            if (CBSongs.Checked && Directory.Exists(osuPath + "\\Songs"))
            {
                parts.Add(BackupPart.Songs);
            }
            if (CBReplays.Checked && Directory.Exists(osuPath + "\\Replays"))
            {
                parts.Add(BackupPart.Replays);
            }
            if (CBScreenshots.Checked && Directory.Exists(osuPath + "\\Screenshots"))
            {
                parts.Add(BackupPart.Screenshots);
            }
            if (CBSkins.Checked && Directory.Exists(osuPath + "\\Skins"))
            {
                parts.Add(BackupPart.Skins);
            }

            var exportForm = new FExport(parts);
            exportForm.ShowDialog();
        }

        private void BChoose_Click(object sender, EventArgs e)
        {
            if (OFDChoose.ShowDialog() == DialogResult.OK)
            {
                importFile = OFDChoose.FileName;
                LSelectedFilePath.Text = importFile;
                BImport.Enabled = true;
            }
        }

        private void BImport_Click(object sender, EventArgs e)
        {
            DGVAnalysis.Rows.Clear();
            var importForm = new FImport(OFDChoose.FileName, this);
            importForm.ShowDialog();
            if (Imported)
            {
                BApply.Enabled = true;
            }
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
            var args = (string[]) data.GetData(DataFormats.FileDrop);
            importFile = args[0];
            MessageBox.Show("The backup file has been set to " + importFile);
            LSelectedFilePath.Text = importFile;
            BImport.Enabled = true;
        }

        private void BApply_Click(object sender, EventArgs e)
        {
            string osuPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\osu!";
            if (!Directory.Exists(osuPath))
            {
                MessageBox.Show("osu! installation could not be located. Make sure you have installed osu! correctly.");
                return;
            }

            if (importSummary == null)
            {
                MessageBox.Show("Import data could not be retrieved.");
                return;
            }

            string importPath = osuPath + "\\.backup\\temp";
            var importDir = new DirectoryInfo(importPath);
            foreach (DirectoryInfo dir in importDir.GetDirectories())
            {
                if (!Enum.TryParse(dir.Name, out BackupPart part))
                {
                    continue;
                }

                foreach (string file in importSummary[part])
                {
                    var fileInfo = new FileInfo(file);
                    var dirName = dir.Name.Split("\\").Last<string>();
                    fileInfo.MoveTo(osuPath + "\\" + dirName + "\\" + fileInfo.Name);
                }
            }

            MessageBox.Show("Finished applying the backup.");
        }

        public void UpdateAnalysis(Dictionary<BackupPart, List<string>> summary)
        {
            importSummary = summary;
            foreach (var part in importSummary.Keys)
            {
                DGVAnalysis.Rows.Add(part.ToString(), importSummary[part].Count);
            }
        }
    }
}