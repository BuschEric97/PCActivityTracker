using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

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

        private void MainForm_Load(object sender, EventArgs e) {
            // start the tracker listener
            Console.WriteLine("Creating Tracking Handler!");
            ApplicationTracker.CreateHandler();

            // set buttons appropriately for shutting down tracker listener
            shutDownTrackerButton.Enabled = true;
            startTrackerButton.Enabled = false;

            // load the current day's data into the data grid
            LoadData_PastDay();

            // set the selected choice of amountDataDisplayed to "past day" on load
            amountDataDisplayed.Text = "past day";
        }

        protected override void OnFormClosing(FormClosingEventArgs e) {
            if (new StackTrace().GetFrames().Any(x => x.GetMethod().Name == "Close")) {
                e.Cancel = false;
                Console.WriteLine("Destroying Tracking Handler!");
                ApplicationTracker.DestroyHandler();
            } else {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void shutDownTrackerButton_Click(object sender, EventArgs e) {
            // shut down the tracker listener
            Console.WriteLine("Destroying Tracking Handler!");
            ApplicationTracker.DestroyHandler();

            // set buttons appropriately for restarting tracker listener
            startTrackerButton.Enabled = true;
            shutDownTrackerButton.Enabled = false;
        }

        private void startTrackerButton_Click(object sender, EventArgs e) {
            // start the tracker listener
            Console.WriteLine("Creating Tracking Handler!");
            ApplicationTracker.CreateHandler();

            // set buttons appropriately for shutting down tracker listener
            shutDownTrackerButton.Enabled = true;
            startTrackerButton.Enabled = false;
        }

        private void reloadDataButton_Click(object sender, EventArgs e) {
            switch (amountDataDisplayed.Text) {
                case "past day":
                    LoadData_PastDay();
                    break;
                case "all time":
                    LoadData_AllTime();
                    break;
                default:
                    LoadData_PastDay();
                    break;
            }
        }

        private void LoadData_PastDay() {
            // get today's data filepath
            string dataFile = ApplicationTracker.GetTodayDataFile();

            // deserialize the data from the data file into a dictionary
            Dictionary<string, TimeSpan> trackingData = new Dictionary<string, TimeSpan>();
            if (File.Exists(dataFile)) {
                using (StreamReader sr = File.OpenText(dataFile)) {
                    string json = sr.ReadToEnd();
                    trackingData = JsonConvert.DeserializeObject<Dictionary<string, TimeSpan>>(json);
                }
            }

            // clear the data grid before reloading data
            trackerDataView.Rows.Clear();

            // add the data into the data grid
            foreach (KeyValuePair<string, TimeSpan> kv in trackingData) {
                trackerDataView.Rows.Add(kv.Key, kv.Value);
            }

            // sort the data in ascending order based on program name
            trackerDataView.Sort(trackerDataView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void LoadData_AllTime() {
            // get array of all data filepaths
            string[] dataFiles = Directory.GetFiles(ApplicationTracker.GetDataFilesDirectory());

            // initialize the dictionary to store the data from all data files
            Dictionary<string, TimeSpan> trackingData = new Dictionary<string, TimeSpan>();

            // fill the trackingData dictionary with data from all data files
            foreach (string dataFile in dataFiles) {
                using (StreamReader sr = File.OpenText(dataFile)) {
                    string json = sr.ReadToEnd();
                    Dictionary<string, TimeSpan> tempTrackingData =
                        JsonConvert.DeserializeObject<Dictionary<string, TimeSpan>>(json);
                    foreach (KeyValuePair<string, TimeSpan> kv in tempTrackingData) {
                        if (trackingData.ContainsKey(kv.Key)) {
                            trackingData[kv.Key] += kv.Value;
                        } else {
                            trackingData.Add(kv.Key, kv.Value);
                        }
                    }
                }
            }

            // clear the data grid before reloading data
            trackerDataView.Rows.Clear();

            // add the data into the data grid
            foreach (KeyValuePair<string, TimeSpan> kv in trackingData) {
                trackerDataView.Rows.Add(kv.Key, kv.Value);
            }

            // sort the data in ascending order based on program name
            trackerDataView.Sort(trackerDataView.Columns[0], System.ComponentModel.ListSortDirection.Ascending);
        }

        private void minToNotifAreaButton_Click(object sender, EventArgs e) {
            this.ShowInTaskbar = false;
            this.Hide();
        }

        private void shutDownAppButton_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure you want to close the application?",
                "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                this.Close();
            }
        }

        private void runningNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e) {
            // bring the application out of minimized and back into the taskbar
            this.Show();
            this.ShowInTaskbar = true;
        }
    }
}
