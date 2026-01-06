using Microsoft.Data.SqlClient;
using System.Diagnostics;
using static System.Console;

namespace TaskSchedulerOneTimeSealevel
{
    internal class BusinessRules
    {

        /// <summary>
        ///     This iterates once through all the records in the selected recipe. The database connection remains open until all records have been processed.
        /// </summary>
        public static int ApplyBusinessRules()
        {
            bool listRecords = true;
            string recipeNmbr = "1";
            string stepState = "";
            string currentStatus;
            int counter = 0;

            int recipeID;
            int channelNmbr;
            DateTime doAt;
            bool digitalValue;
            int status;

            /// <remarks>
            ///     Provide a recipe containing time-correct event data to work with, for testing only.
            ///     This external process empties the database table used by this program and then fills it with new data. All events or steps
            ///         are scheduled to occur within a short time after this program is started.
            ///     The data source thus created uses a single fixed date and time for each event.
            /// </remarks>
            Process CreateScheduleToRun = new();
            CreateScheduleToRun.StartInfo.UseShellExecute = true;                           //  This must be true to hide the console window.
            CreateScheduleToRun.StartInfo.FileName = @"Z:\ep5BAS\TaskSchedulerOneTimeSealevel\TableFill\bin\Debug\net10.0\TableFill.exe";
            CreateScheduleToRun.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;       //  Hide the console window.
            CreateScheduleToRun.Start();
            CreateScheduleToRun.WaitForExit();

            /// <remarks>
            ///     This program reads recipe data in real time rather than using an in-memory store in order to minimze database connection time.
            ///     Each time an event is read, the program waits until the specified time before executing.
            ///     Given that the program is intended to run once and then exit, this approach is acceptable, albeit sub-optimal.
            /// </remarks>
            SqlConnection connection = new("Server = System76; Database = TaskSchedulerOneTimeSealevel; Integrated Security = SSPI; TrustServerCertificate = true");
            connection.Open();
            using SqlCommand command = new($"select * from dbo.ControlEvent where recipeID = {recipeNmbr} order by recipeID, doAt", connection);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read() != false)
            {
                recipeID = (int)dataReader["recipeID"];
                doAt = (DateTime)dataReader["doAt"];
                channelNmbr = (int)dataReader["channelNmbr"];
                digitalValue = (bool)dataReader["digitalValue"];
                status = (byte)dataReader["status"];
                if (listRecords)
                {
                    if (digitalValue == true)
                        stepState = "ON";
                    else
                        stepState = "OFF";
                    if (status == 1)
                        currentStatus = "active";
                    else
                        currentStatus = "inactive";
                    WriteLine("do at {0}\tchannel {1}\t{2}\t{3}", doAt.ToString("dddd dd MMMM yyyy  hh:mm:ss.fff"), channelNmbr, stepState, currentStatus);
                }
                counter++;
                /// <remarks>
                ///     This function call causes a single event to be implemented when the specified time is reached.
                ///     It returns a SeaMAX errorcode, with success = 0.
                /// </remarks>
                int erratum = SingleStep.DoSingleStep(doAt, channelNmbr, stepState, digitalValue);
                if (erratum < 0)
                {
                    return erratum;
                }
                // check for operator interrupt/quit
                if (KeyAvailable)
                {
                    char c = ReadKey(true).KeyChar;
                    if (c is 'q' or 'Q' or (char)ConsoleKey.Escape)
                    {
                        for (int i = 0; i < GlobalData.SeaMAXdata.Length; i++)
                        {
                            GlobalData.SeaMAXdata[i] = 0;
                        }
                        break;
                    }
                }
            }
            dataReader.Close();
            connection.Close();
            WriteLine("This recipe contains {0} steps.", counter);
            return 0;
        }
    }
}