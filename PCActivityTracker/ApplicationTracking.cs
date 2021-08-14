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
        static extern int GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        // store the delegate in a class field so that it is not garbage collected while we're using it
        static WinEventDelegate procDelegate = new WinEventDelegate(WinEventProc);

        static IntPtr hhook = IntPtr.Zero;

        static DateTime prevContextSwitchTime;
        static string prevProcExeName = "";

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
            // get current time for calculations
            DateTime now = DateTime.Now;

            // get the executable name of the now current foreground application
            GetWindowThreadProcessId(hwnd, out uint pid);
            Process proc = Process.GetProcessById((int)pid);
            string procExeName = proc.ProcessName;

            // calculate the amount of time spent on the previous process
            TimeSpan prevProcTimeSpent = TimeSpan.Zero;
            if (prevProcExeName != "") {
                prevProcTimeSpent = now - prevContextSwitchTime;
            }

            // log to console
            Console.WriteLine("Active window changed: " + procExeName);
            Console.WriteLine("Previous time spent in " + prevProcExeName + ": " + prevProcTimeSpent.ToString());

            // store current variables as previous for future calculations
            prevContextSwitchTime = now;
            prevProcExeName = procExeName;
        }

        /// <summary>
        /// Call this function to create a handler that does the application tracking
        /// </summary>
        public static void CreateHandler() {
            hhook = SetWinEventHook(EVENT_SYSTEM_FOREGROUND, EVENT_SYSTEM_FOREGROUND,
                IntPtr.Zero, procDelegate, 0, 0, WINEVENT_OUTOFCONTEXT);
        }

        public static void DestroyHandler() {
            UnhookWinEvent(hhook);
            hhook = IntPtr.Zero;
        }
    }
}
