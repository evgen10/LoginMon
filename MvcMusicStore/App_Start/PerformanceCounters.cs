using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MvcMusicStore.App_Start
{
    public static class PerformanceCounters
    {
        public static PerformanceCounter LogIn { get; private set; }

        public static PerformanceCounter LogOff { get; private set; }

        public static PerformanceCounter GoToHome { get; private set; }

        static PerformanceCounters()
        {
            LogIn = new PerformanceCounter(
                "MusStoreCounters",
                "LogInSuccess",
                "MusStore",
                false);

            LogOff = new PerformanceCounter(
                "MusStoreCounters",
                "LogOffSuccess",
                "MusStore",
                false);

            GoToHome = new PerformanceCounter(
                "MusStoreCounters",
                "GoToHome",
                "MusStore",
                false);
        }

        public static void Start()
        {
            LogIn.RawValue = 0;
            LogOff.RawValue = 0;
            GoToHome.RawValue = 0;
        }
    }
}
