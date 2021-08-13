﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PCActivityTracker
{
    public partial class MainForm : Form
    {
        public MainForm() {
            InitializeComponent();
        }

        private void settingsMenuItem_Click(object sender, EventArgs e) {
            // open the settings form modally
            var settings = new SettingsForm();
            settings.ShowDialog();
        }

        private void helpMenuItem_Click(object sender, EventArgs e) {
            // Opening this website is a placeholder for until I make a proper help page
            System.Diagnostics.Process.Start("https://github.com/BuschEric97/PCActivityTracker");
        }

        private void getCurrentApps_Click(object sender, EventArgs e) {
            var tracker = new ApplicationTracking();
            var curr_procs = tracker.getAllRunningApplications();

            string display_message = "Running Processes:\n";
            foreach (Process p in curr_procs) {
                display_message = display_message + " - " + p.ProcessName + "\n";
            }

            MessageBox.Show(display_message);
        }

        private void MainForm_Load(object sender, EventArgs e) {
            ApplicationTracker tracker = new ApplicationTracker();
            tracker.CreateHandler();
        }
    }
}
