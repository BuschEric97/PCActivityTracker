
namespace PCActivityTracker
{
    partial class SettingsForm
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
            this.dataLifetimeLabel = new System.Windows.Forms.Label();
            this.dataLifetimeInput = new System.Windows.Forms.MaskedTextBox();
            this.breakFreqLabel = new System.Windows.Forms.Label();
            this.breakFreqInput = new System.Windows.Forms.MaskedTextBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataLifetimeLabel
            // 
            this.dataLifetimeLabel.AutoSize = true;
            this.dataLifetimeLabel.Location = new System.Drawing.Point(12, 9);
            this.dataLifetimeLabel.Name = "dataLifetimeLabel";
            this.dataLifetimeLabel.Size = new System.Drawing.Size(100, 13);
            this.dataLifetimeLabel.TabIndex = 2;
            this.dataLifetimeLabel.Text = "Data Lifetime (days)";
            // 
            // dataLifetimeInput
            // 
            this.dataLifetimeInput.Location = new System.Drawing.Point(230, 6);
            this.dataLifetimeInput.Mask = "90";
            this.dataLifetimeInput.Name = "dataLifetimeInput";
            this.dataLifetimeInput.Size = new System.Drawing.Size(100, 20);
            this.dataLifetimeInput.TabIndex = 3;
            // 
            // breakFreqLabel
            // 
            this.breakFreqLabel.AutoSize = true;
            this.breakFreqLabel.Location = new System.Drawing.Point(12, 61);
            this.breakFreqLabel.Name = "breakFreqLabel";
            this.breakFreqLabel.Size = new System.Drawing.Size(151, 13);
            this.breakFreqLabel.TabIndex = 4;
            this.breakFreqLabel.Text = "Break Frequency (HH:MM:SS)";
            // 
            // breakFreqInput
            // 
            this.breakFreqInput.Location = new System.Drawing.Point(230, 58);
            this.breakFreqInput.Mask = "90:00:00";
            this.breakFreqInput.Name = "breakFreqInput";
            this.breakFreqInput.Size = new System.Drawing.Size(100, 20);
            this.breakFreqInput.TabIndex = 5;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(174, 130);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsButton.TabIndex = 6;
            this.saveSettingsButton.Text = "Save";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.Location = new System.Drawing.Point(255, 130);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSettingsButton.TabIndex = 7;
            this.cancelSettingsButton.Text = "Cancel";
            this.cancelSettingsButton.UseVisualStyleBackColor = true;
            this.cancelSettingsButton.Click += new System.EventHandler(this.cancelSettingsButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 165);
            this.Controls.Add(this.cancelSettingsButton);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.breakFreqInput);
            this.Controls.Add(this.breakFreqLabel);
            this.Controls.Add(this.dataLifetimeInput);
            this.Controls.Add(this.dataLifetimeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label dataLifetimeLabel;
        private System.Windows.Forms.MaskedTextBox dataLifetimeInput;
        private System.Windows.Forms.Label breakFreqLabel;
        private System.Windows.Forms.MaskedTextBox breakFreqInput;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button cancelSettingsButton;
    }
}