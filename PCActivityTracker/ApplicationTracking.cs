using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace PCActivityTracker
{
    /// <summary>
    /// This class contains all of the necessary code to create and use an event handler
    /// that is invoked when the foreground application changes
    /// </summary>
    class ApplicationTracker
    {
        delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd,
            int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        [DllImport("user32.dll")]
        static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax,
            IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess,
            uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private const uint EVENT_SYSTEM_FOREGROUND = 3;

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        // store the delegate in a class field so that it is not garbage collected while we're using it
        static WinEventDelegate procDelegate = new WinEventDelegate(WinEventProc);

        /// <summary>
        /// Get the window title of the foreground application
        /// </summary>
        /// <returns></returns>
        private static string GetActiveWindowTitle() {
            const int NCHARS = 256;
            StringBuilder Buff = new StringBuilder(NCHARS);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, NCHARS) > 0) {
                return Buff.ToString();
            }
            return null;
        }

        /// <summary>
        /// This is the function that is called when the foreground application changes.
        /// </summary>
        /// <param name="hWinEventHook"></param>
        /// <param name="eventType"></param>
        /// <param name="hwnd"></param>
        /// <param name="idObject"></param>
        /// <param name="idChild"></param>
        /// <param name="dwEventThread"></param>
        /// <param name="dwmsEventTime"></param>
        static void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd,
            int idObject, int idChild, uint dwEventThread, uint dwmsEventTime) {
            Console.WriteLine("Active window changed to: " + GetActiveWindowTitle());
        }

        /// <summary>
        /// Call this function to create a handler that does the application tracking
        /// </summary>
        public void CreateHandler() {
            IntPtr hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND,
                IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
        }
    }

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
