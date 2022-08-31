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
            this.BImport = new System.Windows.Forms.Button();
            this.DGVAnalysis = new System.Windows.Forms.DataGridView();
            this.CLocal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CBackup = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.CLBSelection = new System.Windows.Forms.CheckedListBox();
            this.TCMain = new System.Windows.Forms.TabControl();
            this.OFDChoose = new System.Windows.Forms.OpenFileDialog();
            this.TPImport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAnalysis)).BeginInit();
            this.TPExport.SuspendLayout();
            this.TCMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TPImport
            // 
            this.TPImport.AllowDrop = true;
            this.TPImport.Controls.Add(this.BImport);
            this.TPImport.Controls.Add(this.DGVAnalysis);
            this.TPImport.Controls.Add(this.BApply);
            this.TPImport.Controls.Add(this.LAnalysis);
            this.TPImport.Controls.Add(this.LDragDrop);
            this.TPImport.Controls.Add(this.BChoose);
            this.TPImport.Location = new System.Drawing.Point(4, 29);
            this.TPImport.Name = "TPImport";
            this.TPImport.Padding = new System.Windows.Forms.Padding(3);
            this.TPImport.Size = new System.Drawing.Size(760, 465);
            this.TPImport.TabIndex = 1;
            this.TPImport.Text = "Import";
            this.TPImport.UseVisualStyleBackColor = true;
            this.TPImport.DragDrop += new System.Windows.Forms.DragEventHandler(this.TPImport_DragDrop);
            this.TPImport.DragEnter += new System.Windows.Forms.DragEventHandler(this.TPImport_DragEnter);
            // 
            // BImport
            // 
            this.BImport.AutoSize = true;
            this.BImport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BImport.Location = new System.Drawing.Point(183, 88);
            this.BImport.Name = "BImport";
            this.BImport.Size = new System.Drawing.Size(64, 30);
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
            this.DGVAnalysis.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DGVAnalysis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAnalysis.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CLocal,
            this.CBackup});
            this.DGVAnalysis.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DGVAnalysis.Location = new System.Drawing.Point(12, 124);
            this.DGVAnalysis.MultiSelect = false;
            this.DGVAnalysis.Name = "DGVAnalysis";
            this.DGVAnalysis.ReadOnly = true;
            this.DGVAnalysis.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DGVAnalysis.RowTemplate.Height = 25;
            this.DGVAnalysis.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.DGVAnalysis.ShowEditingIcon = false;
            this.DGVAnalysis.Size = new System.Drawing.Size(293, 197);
            this.DGVAnalysis.TabIndex = 4;
            // 
            // CLocal
            // 
            this.CLocal.Frozen = true;
            this.CLocal.HeaderText = "Local";
            this.CLocal.Name = "CLocal";
            this.CLocal.ReadOnly = true;
            this.CLocal.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CLocal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CLocal.Width = 50;
            // 
            // CBackup
            // 
            this.CBackup.Frozen = true;
            this.CBackup.HeaderText = "Backup";
            this.CBackup.Name = "CBackup";
            this.CBackup.ReadOnly = true;
            this.CBackup.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CBackup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CBackup.Width = 63;
            // 
            // BApply
            // 
            this.BApply.AutoSize = true;
            this.BApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BApply.Location = new System.Drawing.Point(6, 429);
            this.BApply.Name = "BApply";
            this.BApply.Size = new System.Drawing.Size(110, 30);
            this.BApply.TabIndex = 3;
            this.BApply.Text = "Apply backup";
            this.BApply.UseVisualStyleBackColor = true;
            this.BApply.Click += new System.EventHandler(this.BApply_Click);
            // 
            // LAnalysis
            // 
            this.LAnalysis.AutoSize = true;
            this.LAnalysis.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LAnalysis.Location = new System.Drawing.Point(6, 85);
            this.LAnalysis.Name = "LAnalysis";
            this.LAnalysis.Size = new System.Drawing.Size(171, 30);
            this.LAnalysis.TabIndex = 2;
            this.LAnalysis.Text = "Backup Analysis";
            // 
            // LDragDrop
            // 
            this.LDragDrop.AutoSize = true;
            this.LDragDrop.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LDragDrop.Location = new System.Drawing.Point(107, 21);
            this.LDragDrop.Name = "LDragDrop";
            this.LDragDrop.Size = new System.Drawing.Size(262, 20);
            this.LDragDrop.TabIndex = 1;
            this.LDragDrop.Text = "...or drag and drop a backup file (.osb)";
            // 
            // BChoose
            // 
            this.BChoose.AutoSize = true;
            this.BChoose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BChoose.Location = new System.Drawing.Point(6, 16);
            this.BChoose.Name = "BChoose";
            this.BChoose.Size = new System.Drawing.Size(95, 30);
            this.BChoose.TabIndex = 0;
            this.BChoose.Text = "Choose File";
            this.BChoose.UseVisualStyleBackColor = true;
            this.BChoose.Click += new System.EventHandler(this.BChoose_Click);
            // 
            // TPExport
            // 
            this.TPExport.Controls.Add(this.LExportHint);
            this.TPExport.Controls.Add(this.BNone);
            this.TPExport.Controls.Add(this.BAll);
            this.TPExport.Controls.Add(this.BExport);
            this.TPExport.Controls.Add(this.LSelection);
            this.TPExport.Controls.Add(this.CLBSelection);
            this.TPExport.Location = new System.Drawing.Point(4, 29);
            this.TPExport.Name = "TPExport";
            this.TPExport.Padding = new System.Windows.Forms.Padding(3);
            this.TPExport.Size = new System.Drawing.Size(760, 465);
            this.TPExport.TabIndex = 0;
            this.TPExport.Text = "Export";
            this.TPExport.UseVisualStyleBackColor = true;
            // 
            // LExportHint
            // 
            this.LExportHint.AutoSize = true;
            this.LExportHint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.LExportHint.Location = new System.Drawing.Point(6, 442);
            this.LExportHint.Name = "LExportHint";
            this.LExportHint.Size = new System.Drawing.Size(438, 20);
            this.LExportHint.TabIndex = 5;
            this.LExportHint.Text = "Exporting might take a while depending on the size of your data.";
            // 
            // BNone
            // 
            this.BNone.AutoSize = true;
            this.BNone.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BNone.Location = new System.Drawing.Point(91, 50);
            this.BNone.Name = "BNone";
            this.BNone.Size = new System.Drawing.Size(96, 30);
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
            this.BAll.Size = new System.Drawing.Size(79, 30);
            this.BAll.TabIndex = 3;
            this.BAll.Text = "Select all";
            this.BAll.UseVisualStyleBackColor = true;
            this.BAll.Click += new System.EventHandler(this.BAll_Click);
            // 
            // BExport
            // 
            this.BExport.AutoSize = true;
            this.BExport.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BExport.Location = new System.Drawing.Point(193, 50);
            this.BExport.Name = "BExport";
            this.BExport.Size = new System.Drawing.Size(62, 30);
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
            this.LSelection.Size = new System.Drawing.Size(199, 20);
            this.LSelection.TabIndex = 1;
            this.LSelection.Text = "Select which data to export";
            // 
            // CLBSelection
            // 
            this.CLBSelection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CLBSelection.CheckOnClick = true;
            this.CLBSelection.Location = new System.Drawing.Point(6, 87);
            this.CLBSelection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CLBSelection.Name = "CLBSelection";
            this.CLBSelection.Size = new System.Drawing.Size(249, 220);
            this.CLBSelection.Sorted = true;
            this.CLBSelection.TabIndex = 0;
            // 
            // TCMain
            // 
            this.TCMain.Controls.Add(this.TPExport);
            this.TCMain.Controls.Add(this.TPImport);
            this.TCMain.Location = new System.Drawing.Point(14, 12);
            this.TCMain.Name = "TCMain";
            this.TCMain.SelectedIndex = 0;
            this.TCMain.Size = new System.Drawing.Size(768, 498);
            this.TCMain.TabIndex = 2;
            // 
            // OFDChoose
            // 
            this.OFDChoose.FileName = "openFileDialog1";
            // 
            // FMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 522);
            this.Controls.Add(this.TCMain);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "osu!backup";
            this.Load += new System.EventHandler(this.FMain_Load);
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
        private CheckedListBox CLBSelection;
        private TabControl TCMain;
        private OpenFileDialog OFDChoose;
        private Label LDragDrop;
        private Button BApply;
        private Label LAnalysis;
        private DataGridView DGVAnalysis;
        private DataGridViewTextBoxColumn CLocal;
        private DataGridViewTextBoxColumn CBackup;
        private Button BImport;
    }
}