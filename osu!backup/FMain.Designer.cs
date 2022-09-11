namespace osu_backup
{
    partial class FMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TPImport = new System.Windows.Forms.TabPage();
            this.LSelectedFilePath = new System.Windows.Forms.Label();
            this.LSelectedFile = new System.Windows.Forms.Label();
            this.BImport = new System.Windows.Forms.Button();
            this.DGVAnalysis = new System.Windows.Forms.DataGridView();
            this.CCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CNew = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BApply = new System.Windows.Forms.Button();
            this.LAnalysis = new System.Windows.Forms.Label();
            this.LDragDrop = new System.Windows.Forms.Label();
            this.BChoose = new System.Windows.Forms.Button();
            this.TPExport = new System.Windows.Forms.TabPage();
            this.LExportHint = new System.Windows.Forms.Label();
            this.BNone = new System.Windows.Forms.Button();
            this.BAll = new System.Windows.Forms.Button();
            this.BExport = new System.Windows.Forms.Button();
            this.LSelection = new System.Windows.Forms.Label();
            this.TCMain = new System.Windows.Forms.TabControl();
            this.OFDChoose = new System.Windows.Forms.OpenFileDialog();
            this.CBSongs = new System.Windows.Forms.CheckBox();
            this.CBReplays = new System.Windows.Forms.CheckBox();
            this.CBScreenshots = new System.Windows.Forms.CheckBox();
            this.CBSkins = new System.Windows.Forms.CheckBox();
            this.TPImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAnalysis)).BeginInit();
            this.TPExport.SuspendLayout();
            this.TCMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TPImport
            // 
            this.TPImport.AllowDrop = true;
            this.TPImport.Controls.Add(this.LSelectedFilePath);
            this.TPImport.Controls.Add(this.LSelectedFile);
            this.TPImport.Controls.Add(this.BImport);
            this.TPImport.Controls.Add(this.DGVAnalysis);
            this.TPImport.Controls.Add(this.BApply);
            this.TPImport.Controls.Add(this.LAnalysis);
            this.TPImport.Controls.Add(this.LDragDrop);
            this.TPImport.Controls.Add(this.BChoose);
            this.TPImport.Location = new System.Drawing.Point(4, 34);
            this.TPImport.Name = "TPImport";
            this.TPImport.Padding = new System.Windows.Forms.Padding(3);
            this.TPImport.Size = new System.Drawing.Size(789, 493);
            this.TPImport.TabIndex = 1;
            this.TPImport.Text = "Import";
            this.TPImport.UseVisualStyleBackColor = true;
            this.TPImport.DragDrop += new System.Windows.Forms.DragEventHandler(this.TPImport_DragDrop);
            this.TPImport.DragEnter += new System.Windows.Forms.DragEventHandler(this.TPImport_DragEnter);
            // 
            // LSelectedFilePath
            // 
            this.LSelectedFilePath.AutoSize = true;
            this.LSelectedFilePath.Location = new System.Drawing.Point(109, 17);
            this.LSelectedFilePath.Name = "LSelectedFilePath";
            this.LSelectedFilePath.Size = new System.Drawing.Size(65, 31);
            this.LSelectedFilePath.TabIndex = 7;
            this.LSelectedFilePath.Text = "none";
            // 
            // LSelectedFile
            // 
            this.LSelectedFile.AutoSize = true;
            this.LSelectedFile.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LSelectedFile.Location = new System.Drawing.Point(6, 17);
            this.LSelectedFile.Name = "LSelectedFile";
            this.LSelectedFile.Size = new System.Drawing.Size(151, 31);
            this.LSelectedFile.TabIndex = 6;
            this.LSelectedFile.Text = "Selected file:";
            // 
            // BImport
            // 
            this.BImport.AutoSize = true;
            this.BImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BImport.Enabled = false;
            this.BImport.Location = new System.Drawing.Point(6, 53);
            this.BImport.Name = "BImport";
            this.BImport.Size = new System.Drawing.Size(93, 41);
            this.BImport.TabIndex = 5;
            this.BImport.Text = "Import";
            this.BImport.UseVisualStyleBackColor = true;
            this.BImport.Click += new System.EventHandler(this.BImport_Click);
            // 
            // DGVAnalysis
            // 
            this.DGVAnalysis.AllowUserToAddRows = false;
            this.DGVAnalysis.AllowUserToDeleteRows = false;
            this.DGVAnalysis.AllowUserToResizeColumns = false;
            this.DGVAnalysis.AllowUserToResizeRows = false;
            this.DGVAnalysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.DGVAnalysis.BackgroundColor = System.Drawing.Color.White;
            this.DGVAnalysis.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAnalysis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CCategory,
            this.CNew});
            this.DGVAnalysis.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVAnalysis.Location = new System.Drawing.Point(6, 182);
            this.DGVAnalysis.MultiSelect = false;
            this.DGVAnalysis.Name = "DGVAnalysis";
            this.DGVAnalysis.ReadOnly = true;
            this.DGVAnalysis.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DGVAnalysis.RowTemplate.Height = 25;
            this.DGVAnalysis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGVAnalysis.ShowEditingIcon = false;
            this.DGVAnalysis.Size = new System.Drawing.Size(748, 208);
            this.DGVAnalysis.TabIndex = 4;
            // 
            // CCategory
            // 
            this.CCategory.Frozen = true;
            this.CCategory.HeaderText = "Category";
            this.CCategory.MinimumWidth = 8;
            this.CCategory.Name = "CCategory";
            this.CCategory.ReadOnly = true;
            this.CCategory.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CCategory.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CCategory.Width = 112;
            // 
            // CNew
            // 
            this.CNew.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CNew.HeaderText = "New items";
            this.CNew.MinimumWidth = 8;
            this.CNew.Name = "CNew";
            this.CNew.ReadOnly = true;
            this.CNew.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CNew.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CNew.Width = 128;
            // 
            // BApply
            // 
            this.BApply.AutoSize = true;
            this.BApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BApply.Enabled = false;
            this.BApply.Location = new System.Drawing.Point(6, 440);
            this.BApply.Name = "BApply";
            this.BApply.Size = new System.Drawing.Size(165, 41);
            this.BApply.TabIndex = 3;
            this.BApply.Text = "Apply backup";
            this.BApply.UseVisualStyleBackColor = true;
            this.BApply.Click += new System.EventHandler(this.BApply_Click);
            // 
            // LAnalysis
            // 
            this.LAnalysis.AutoSize = true;
            this.LAnalysis.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LAnalysis.Location = new System.Drawing.Point(6, 134);
            this.LAnalysis.Name = "LAnalysis";
            this.LAnalysis.Size = new System.Drawing.Size(261, 45);
            this.LAnalysis.TabIndex = 2;
            this.LAnalysis.Text = "Backup Analysis";
            // 
            // LDragDrop
            // 
            this.LDragDrop.AutoSize = true;
            this.LDragDrop.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LDragDrop.Location = new System.Drawing.Point(251, 58);
            this.LDragDrop.Name = "LDragDrop";
            this.LDragDrop.Size = new System.Drawing.Size(387, 31);
            this.LDragDrop.TabIndex = 1;
            this.LDragDrop.Text = "or drag and drop a backup file (.osb)";
            // 
            // BChoose
            // 
            this.BChoose.AutoSize = true;
            this.BChoose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BChoose.Location = new System.Drawing.Point(105, 53);
            this.BChoose.Name = "BChoose";
            this.BChoose.Size = new System.Drawing.Size(140, 41);
            this.BChoose.TabIndex = 0;
            this.BChoose.Text = "Choose File";
            this.BChoose.UseVisualStyleBackColor = true;
            this.BChoose.Click += new System.EventHandler(this.BChoose_Click);
            // 
            // TPExport
            // 
            this.TPExport.Controls.Add(this.CBSkins);
            this.TPExport.Controls.Add(this.CBScreenshots);
            this.TPExport.Controls.Add(this.CBReplays);
            this.TPExport.Controls.Add(this.CBSongs);
            this.TPExport.Controls.Add(this.LExportHint);
            this.TPExport.Controls.Add(this.BNone);
            this.TPExport.Controls.Add(this.BAll);
            this.TPExport.Controls.Add(this.BExport);
            this.TPExport.Controls.Add(this.LSelection);
            this.TPExport.Location = new System.Drawing.Point(4, 40);
            this.TPExport.Name = "TPExport";
            this.TPExport.Padding = new System.Windows.Forms.Padding(3);
            this.TPExport.Size = new System.Drawing.Size(789, 487);
            this.TPExport.TabIndex = 0;
            this.TPExport.Text = "Export";
            this.TPExport.UseVisualStyleBackColor = true;
            // 
            // LExportHint
            // 
            this.LExportHint.AutoSize = true;
            this.LExportHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LExportHint.Location = new System.Drawing.Point(6, 453);
            this.LExportHint.Name = "LExportHint";
            this.LExportHint.Size = new System.Drawing.Size(674, 31);
            this.LExportHint.TabIndex = 5;
            this.LExportHint.Text = "Exporting might take a while depending on the size of your data.";
            // 
            // BNone
            // 
            this.BNone.AutoSize = true;
            this.BNone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BNone.Location = new System.Drawing.Point(127, 50);
            this.BNone.Name = "BNone";
            this.BNone.Size = new System.Drawing.Size(142, 41);
            this.BNone.TabIndex = 4;
            this.BNone.Text = "Select none";
            this.BNone.UseVisualStyleBackColor = true;
            this.BNone.Click += new System.EventHandler(this.BNone_Click);
            // 
            // BAll
            // 
            this.BAll.AutoSize = true;
            this.BAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BAll.Location = new System.Drawing.Point(6, 50);
            this.BAll.Name = "BAll";
            this.BAll.Size = new System.Drawing.Size(115, 41);
            this.BAll.TabIndex = 3;
            this.BAll.Text = "Select all";
            this.BAll.UseVisualStyleBackColor = true;
            this.BAll.Click += new System.EventHandler(this.BAll_Click);
            // 
            // BExport
            // 
            this.BExport.AutoSize = true;
            this.BExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BExport.Location = new System.Drawing.Point(275, 50);
            this.BExport.Name = "BExport";
            this.BExport.Size = new System.Drawing.Size(90, 41);
            this.BExport.TabIndex = 2;
            this.BExport.Text = "Export";
            this.BExport.UseVisualStyleBackColor = true;
            this.BExport.Click += new System.EventHandler(this.BExport_Click);
            // 
            // LSelection
            // 
            this.LSelection.AutoSize = true;
            this.LSelection.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LSelection.Location = new System.Drawing.Point(6, 13);
            this.LSelection.Name = "LSelection";
            this.LSelection.Size = new System.Drawing.Size(308, 31);
            this.LSelection.TabIndex = 1;
            this.LSelection.Text = "Select which data to export";
            // 
            // TCMain
            // 
            this.TCMain.Controls.Add(this.TPExport);
            this.TCMain.Controls.Add(this.TPImport);
            this.TCMain.Location = new System.Drawing.Point(14, 12);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(797, 531);
            this.TCMain.TabIndex = 2;
            // 
            // OFDChoose
            // 
            this.OFDChoose.FileName = "openFileDialog1";
            // 
            // CBSongs
            // 
            this.CBSongs.AutoSize = true;
            this.CBSongs.Location = new System.Drawing.Point(6, 115);
            this.CBSongs.Name = "CBSongs";
            this.CBSongs.Size = new System.Drawing.Size(102, 35);
            this.CBSongs.TabIndex = 6;
            this.CBSongs.Text = "Songs";
            this.CBSongs.UseVisualStyleBackColor = true;
            // 
            // CBReplays
            // 
            this.CBReplays.AutoSize = true;
            this.CBReplays.Location = new System.Drawing.Point(6, 156);
            this.CBReplays.Name = "CBReplays";
            this.CBReplays.Size = new System.Drawing.Size(118, 35);
            this.CBReplays.TabIndex = 7;
            this.CBReplays.Text = "Replays";
            this.CBReplays.UseVisualStyleBackColor = true;
            // 
            // CBScreenshots
            // 
            this.CBScreenshots.AutoSize = true;
            this.CBScreenshots.Location = new System.Drawing.Point(6, 197);
            this.CBScreenshots.Name = "CBScreenshots";
            this.CBScreenshots.Size = new System.Drawing.Size(162, 35);
            this.CBScreenshots.TabIndex = 8;
            this.CBScreenshots.Text = "Screenshots";
            this.CBScreenshots.UseVisualStyleBackColor = true;
            // 
            // CBSkins
            // 
            this.CBSkins.AutoSize = true;
            this.CBSkins.Location = new System.Drawing.Point(6, 238);
            this.CBSkins.Name = "CBSkins";
            this.CBSkins.Size = new System.Drawing.Size(92, 35);
            this.CBSkins.TabIndex = 9;
            this.CBSkins.Text = "Skins";
            this.CBSkins.UseVisualStyleBackColor = true;
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(823, 555);
            this.Controls.Add(this.TCMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "osu!backup";
            this.TPImport.ResumeLayout(false);
            this.TPImport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAnalysis)).EndInit();
            this.TPExport.ResumeLayout(false);
            this.TPExport.PerformLayout();
            this.TCMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TabPage TPImport;
        private Button BChoose;
        private TabPage TPExport;
        private Label LExportHint;
        private Button BNone;
        private Button BAll;
        private Button BExport;
        private Label LSelection;
        private TabControl TCMain;
        private OpenFileDialog OFDChoose;
        private Label LDragDrop;
        private Button BApply;
        private Label LAnalysis;
        private DataGridView DGVAnalysis;
        private Button BImport;
        private Label LSelectedFile;
        private Label LSelectedFilePath;
        private DataGridViewTextBoxColumn CCategory;
        private DataGridViewTextBoxColumn CNew;
        private CheckBox CBSkins;
        private CheckBox CBScreenshots;
        private CheckBox CBReplays;
        private CheckBox CBSongs;
    }
}