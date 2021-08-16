using System;
using System.IO;
using System.Windows.Forms;

namespace PCActivityTracker
{
    public partial class SettingsForm : Form
    {
        public SettingsForm() {
            InitializeComponent();
        }

        private void saveSettingsButton_Click(object sender, System.EventArgs e) {
            // get the user's requested data lifetime
            TimeSpan userDataLifetime = TimeSpan.FromDays(Convert.ToDouble(dataLifetimeInput.Text));
            Properties.Settings.Default.dataLifetime = userDataLifetime;

            // get the user's requested break frequency
            if (TimeSpan.TryParse(breakFreqInput.Text, out TimeSpan userBreakFreq)) {
                Properties.Settings.Default.breakFreq = userBreakFreq;
            }

            // save the user requested settings
            Properties.Settings.Default.Save();

            // close the settings form after settings are saved
            Close();
        }

        private void cancelSettingsButton_Click(object sender, System.EventArgs e) {
            // close the settings form without saving the settings
            Close();
        }

        private void SettingsForm_Load(object sender, System.EventArgs e) {
            // populate the settings form with the user's settings from the settings file
            dataLifetimeInput.Text = Properties.Settings.Default.dataLifetime.Days.ToString();
            breakFreqInput.Text = Properties.Settings.Default.breakFreq.ToString();
        }

        private void clearDataButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to clear all data?",
                "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                // get array of all data filepaths
                string[] dataFiles = Directory.GetFiles(ApplicationTracker.GetDataFilesDirectory());

                // delete all files in the directory
                foreach (string dataFile in dataFiles) {
                    File.Delete(dataFile);
                }

                // show a confirmation message that all files were deleted
                MessageBox.Show("Successfully cleared all data!");
            }
        }
    }
}
