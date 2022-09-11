namespace osu_backup
{
    partial class FImport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LStep = new System.Windows.Forms.Label();
            this.PBStep = new System.Windows.Forms.ProgressBar();
            this.LProgress = new System.Windows.Forms.Label();
            this.PBAll = new System.Windows.Forms.ProgressBar();
            this.LElapsed = new System.Windows.Forms.Label();
            this.TElapsed = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // LStep
            // 
            this.LStep.AutoSize = true;
            this.LStep.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LStep.Location = new System.Drawing.Point(12, 9);
            this.LStep.Name = "LStep";
            this.LStep.Size = new System.Drawing.Size(61, 31);
            this.LStep.TabIndex = 0;
            this.LStep.Text = "Step";
            // 
            // PBStep
            // 
            this.PBStep.Location = new System.Drawing.Point(12, 43);
            this.PBStep.Maximum = 1;
            this.PBStep.Name = "PBStep";
            this.PBStep.Size = new System.Drawing.Size(297, 22);
            this.PBStep.Step = 1;
            this.PBStep.TabIndex = 1;
            // 
            // LProgress
            // 
            this.LProgress.AutoSize = true;
            this.LProgress.Location = new System.Drawing.Point(12, 79);
            this.LProgress.Name = "LProgress";
            this.LProgress.Size = new System.Drawing.Size(180, 31);
            this.LProgress.TabIndex = 2;
            this.LProgress.Text = "Overall Progress";
            // 
            // PBAll
            // 
            this.PBAll.Location = new System.Drawing.Point(12, 113);
            this.PBAll.Maximum = 1;
            this.PBAll.Name = "PBAll";
            this.PBAll.Size = new System.Drawing.Size(297, 22);
            this.PBAll.Step = 1;
            this.PBAll.TabIndex = 3;
            // 
            // LElapsed
            // 
            this.LElapsed.AutoSize = true;
            this.LElapsed.Location = new System.Drawing.Point(12, 176);
            this.LElapsed.Name = "LElapsed";
            this.LElapsed.Size = new System.Drawing.Size(155, 31);
            this.LElapsed.TabIndex = 4;
            this.LElapsed.Text = "Time elapsed:";
            // 
            // TElapsed
            // 
            this.TElapsed.Interval = 1000;
            // 
            // FImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(321, 216);
            this.ControlBox = false;
            this.Controls.Add(this.LElapsed);
            this.Controls.Add(this.PBAll);
            this.Controls.Add(this.LProgress);
            this.Controls.Add(this.PBStep);
            this.Controls.Add(this.LStep);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Importing...";
            this.Load += new System.EventHandler(this.FImport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label LStep;
        private ProgressBar PBStep;
        private Label LProgress;
        private ProgressBar PBAll;
        private Label LElapsed;
        private System.Windows.Forms.Timer TElapsed;
    }
}