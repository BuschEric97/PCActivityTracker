
namespace PCActivityTracker
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutDownTrackerButton = new System.Windows.Forms.Button();
            this.startTrackerButton = new System.Windows.Forms.Button();
            this.trackerDataView = new System.Windows.Forms.DataGridView();
            this.reloadDataButton = new System.Windows.Forms.Button();
            this.programName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.programRuntime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackerDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(765, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsMenuItem,
            this.helpMenuItem});
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsMenuItem.Text = "Options";
            // 
            // settingsMenuItem
            // 
            this.settingsMenuItem.Name = "settingsMenuItem";
            this.settingsMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsMenuItem.Text = "Settings";
            this.settingsMenuItem.Click += new System.EventHandler(this.settingsMenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Name = "helpMenuItem";
            this.helpMenuItem.Size = new System.Drawing.Size(116, 22);
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // shutDownTrackerButton
            // 
            this.shutDownTrackerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.shutDownTrackerButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.shutDownTrackerButton.Location = new System.Drawing.Point(493, 415);
            this.shutDownTrackerButton.Name = "shutDownTrackerButton";
            this.shutDownTrackerButton.Size = new System.Drawing.Size(127, 23);
            this.shutDownTrackerButton.TabIndex = 1;
            this.shutDownTrackerButton.Text = "Shut Down Tracker";
            this.shutDownTrackerButton.Click += new System.EventHandler(this.shutDownTrackerButton_Click);
            // 
            // startTrackerButton
            // 
            this.startTrackerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startTrackerButton.Location = new System.Drawing.Point(626, 415);
            this.startTrackerButton.Name = "startTrackerButton";
            this.startTrackerButton.Size = new System.Drawing.Size(127, 23);
            this.startTrackerButton.TabIndex = 2;
            this.startTrackerButton.Text = "Start Tracker";
            this.startTrackerButton.UseVisualStyleBackColor = true;
            this.startTrackerButton.Click += new System.EventHandler(this.startTrackerButton_Click);
            // 
            // trackerDataView
            // 
            this.trackerDataView.AllowUserToAddRows = false;
            this.trackerDataView.AllowUserToDeleteRows = false;
            this.trackerDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackerDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trackerDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.programName,
            this.programRuntime});
            this.trackerDataView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.trackerDataView.Location = new System.Drawing.Point(12, 27);
            this.trackerDataView.Name = "trackerDataView";
            this.trackerDataView.ReadOnly = true;
            this.trackerDataView.Size = new System.Drawing.Size(475, 410);
            this.trackerDataView.TabIndex = 3;
            // 
            // reloadDataButton
            // 
            this.reloadDataButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadDataButton.Location = new System.Drawing.Point(493, 27);
            this.reloadDataButton.Name = "reloadDataButton";
            this.reloadDataButton.Size = new System.Drawing.Size(127, 23);
            this.reloadDataButton.TabIndex = 4;
            this.reloadDataButton.Text = "Reload Data";
            this.reloadDataButton.UseVisualStyleBackColor = true;
            this.reloadDataButton.Click += new System.EventHandler(this.reloadDataButton_Click);
            // 
            // programName
            // 
            this.programName.HeaderText = "Program Name";
            this.programName.Name = "programName";
            this.programName.ReadOnly = true;
            this.programName.Width = 200;
            // 
            // programRuntime
            // 
            this.programRuntime.HeaderText = "Program Runtime";
            this.programRuntime.Name = "programRuntime";
            this.programRuntime.ReadOnly = true;
            this.programRuntime.Width = 200;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 450);
            this.Controls.Add(this.reloadDataButton);
            this.Controls.Add(this.trackerDataView);
            this.Controls.Add(this.startTrackerButton);
            this.Controls.Add(this.shutDownTrackerButton);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "PC Activity Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackerDataView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        private System.Windows.Forms.Button shutDownTrackerButton;
        private System.Windows.Forms.Button startTrackerButton;
        private System.Windows.Forms.DataGridView trackerDataView;
        private System.Windows.Forms.Button reloadDataButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn programName;
        private System.Windows.Forms.DataGridViewTextBoxColumn programRuntime;
    }
}

