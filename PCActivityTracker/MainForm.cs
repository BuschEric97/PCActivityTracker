using System;
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

        private void MainForm_Load(object sender, EventArgs e) {
            Console.WriteLine("Creating Tracking Handler!");
            ApplicationTracker.CreateHandler();
            Application.ApplicationExit += new EventHandler(Application_Closing);
        }

        private void Application_Closing(object sender, EventArgs e) {
            Console.WriteLine("Destroying Tracking Handler!");
            ApplicationTracker.DestroyHandler();
        }
    }
}
