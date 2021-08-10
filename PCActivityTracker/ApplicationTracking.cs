using System.Collections.Generic;
using System.Diagnostics;

namespace PCActivityTracker
{
    class ApplicationTracking
    {
        /// <summary>
        /// Get an array of the currently running processes (applications) on the computer
        /// </summary>
        /// <returns></returns>
        public Process[] getAllRunningApplications() {
            var curr_procs_all = Process.GetProcesses();

            List<Process> curr_procs_rel = new List<Process>();

            foreach (Process p in curr_procs_all) {
                if (p.MainWindowTitle.Length > 0) {
                    curr_procs_rel.Add(p);
                }
            }

            return curr_procs_rel.ToArray();
        }

        /// <summary>
        /// Get the currently running process on the computer
        /// </summary>
        /// <returns></returns>
        public Process getCurrentApplication() {
            return Process.GetCurrentProcess();
        }
    }
}
