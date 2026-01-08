using static System.Console;

namespace TaskSchedulerOneTimeSealevel
{
    internal class SingleStep
    {
        const int ON = 1;
        const int OFF = 0;

        /// <summary>
        ///     <param name="doAt">Specifies the date and time when the output must be written to the I/O processor.</param>
        ///     <param name="channelNmbr">This must match the hardware configuration and be an output point.</param>
        ///     <param name="stepState">Indicates to the user whether the digital output is ON or OFF.</param>
        ///     <param name="onOff"> 1 = ON; 0 = OFF</param>
        ///     <returns>This is provision for returning a code indicating successful calling of the I/O write to output function.</returns>
        /// </summary>       
        public static int DoSingleStep(DateTime doAt, int channelNmbr, string stepState, bool onOff)
        {
            while (DateTime.Now < doAt) ;
            WriteLine("Channel nmbr {0} turned {1}", channelNmbr, stepState);
            if (onOff == true)
                GlobalData.machineState[channelNmbr] = ON;
            else
                GlobalData.machineState[channelNmbr] = OFF;
            WriteLine("Output channel is {0}", GlobalData.machineState[channelNmbr]);
            _ = SelectedOutputs.TurnOnSelectedOutputs();
            return 0;
        }
    }
}