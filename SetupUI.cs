using static System.Console;

namespace TaskSchedulerOneTimeSealevel{
    public class SetupTheUI
    {
        /// <summary>
        ///     This function needs refining. It must accommodate different screen sizes and resolutions.
        ///     Additionally, it should handle scenarios where the console window cannot be resized or positioned as intended.
        ///     Further, it must deal with Windoze vs Linux.
        /// </summary>
        public static void SetupUI()
        {
            if (OperatingSystem.IsWindows())
            {
                SetWindowPosition(WindowLeft, WindowTop);
                SetWindowSize(100, 34);
                // SetWindowSize(LargestWindowWidth, LargestWindowHeight);
            }
            BackgroundColor = ConsoleColor.Blue;
            ForegroundColor = ConsoleColor.White;
            Clear();
        }
    }
}
