using System;
using System.Windows.Forms;

namespace PCActivityTracker
{
    public partial class SettingsForm : Form
    {
        public SettingsForm() {
            InitializeComponent();
        }

        private void saveSettingsButton_Click(object sender, System.EventArgs e) {
            // get the user's requested polling rate
            System.TimeSpan userPollingRate;
            if (System.TimeSpan.TryParse(pollingRateInput.Text, out userPollingRate)) {
                Properties.Settings.Default.pollingRate = userPollingRate;
            }

            // get the user's requested data lifetime
            System.TimeSpan userDataLifetime = System.TimeSpan.FromDays(Convert.ToDouble(dataLifetimeInput.Text));
            Properties.Settings.Default.dataLifetime = userDataLifetime;

            // get the user's requested break frequency
            System.TimeSpan userBreakFreq;
            if (System.TimeSpan.TryParse(breakFreqInput.Text, out userBreakFreq)) {
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
            pollingRateInput.Text = Properties.Settings.Default.pollingRate.ToString();
            dataLifetimeInput.Text = Properties.Settings.Default.dataLifetime.Days.ToString();
            breakFreqInput.Text = Properties.Settings.Default.breakFreq.ToString();
        }
    }
}
