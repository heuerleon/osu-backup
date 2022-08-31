using System.IO.Compression;
using System.Text.Json;
using System.Media;

namespace osu_backup
{
    public partial class FMain : Form
    {
        private string? importFile = null;
        public Dictionary<BackupPart, List<string>>? importSummary;

        public FMain()
        {
            InitializeComponent();
            var logoFile = "assets/logo.ico";
            if (!File.Exists(logoFile))
            {
                logoFile = "../../../assets/logo.ico"; // find logo when in debug mode
            }

            if (File.Exists(logoFile))
            {
                using var stream = File.OpenRead(logoFile);
                Icon = new Icon(stream);
            }

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

        private void BImport_Click(object sender, EventArgs e)
        {
            var importForm = new FImport(OFDChoose.FileName, this);
            importForm.ShowDialog();
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

        private void BApply_Click(object sender, EventArgs e)
        {
            // TODO
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