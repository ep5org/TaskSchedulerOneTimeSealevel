/*********************************************************
*              TaskSchedulerOneTimeSealevel              *
*********************************************************/
/*******************************************************************************************************************************************************
*   All Project Files Copyright © 2025, 2026 by The ep5 Educational Broadcasting Foundation. All rights reserved.                                      *
*                                                                                                                                                      *
*   Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”)  *
*	to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, *
*	and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:         *
*                                                                                                                                                      *
*        →  Redistributions of source code must retain the above copyright notice, this list of conditions, and the following disclaimer:              *
*        →  Redistributions in binary form must reproduce the above copyright notice, this list of conditions, and the following disclaimer in the     *
*           documentation and/or other materials provided with the distribution.                                                                       *
*        →  Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this    *
*           software without specific prior written permission.                                                                                        *
*                                                                                                                                                      *
*    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED     *
*    TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO  EVENT SHALL THE COPYRIGHT HOLDER OR     *
*    CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,         *
*    PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF         *
*    LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT, INCLUDING NEGLIGENCE OR OTHERWISE, ARISING IN ANY WAY OUT OF THE USE OF THIS           *
*    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.                                                                                      *
*******************************************************************************************************************************************************/

//  Written/updated 6 January 2026 by David Fisher
//  Copyright © 2025, 2026 by The ep5 Educational Broadcasting Foundation; all rights reserved


using Microsoft.Data.SqlClient;
using System.Diagnostics;
using static System.Console;

namespace TaskSchedulerOneTimeSealevel
{
    /// <summary>
    ///     This code is <b>specific to the Sealevel 463E I/O processor</b>.
    ///     This program reads a set of ON/OFF events from a SQL Server database table and executes them at the specified times.
    ///     It processes this recipe in a single run, turning Sealevel digital output channels ON or OFF as scheduled.
    ///     Once the last instruction has been executed, the program ends.
    /// </summary>
    /// <todo>
    ///     Change database program from MS SQL Server to PostgreSQL or SQLite for better cross-platform compatibility.
    ///     Add the random timing feature that, at run time, selects a random time within the specified range to execute each event.
    ///         This range is defined by two additional fields in the database table: earlyBound and laterBound.
    ///     Consider adding a feature to allow pausing and resuming the execution of the recipe
    ///     Consider restructuring the program to use asynchronous programming techniques to avoid busy-waiting in DoSingleStep().
    ///     Consider adding error handling for database operations and I/O operations to enhance robustness.
    ///     Consider implementing logging to record both the execution of events and any errors that occur.
    ///     Consider adding configuration options to specify the database connection string and recipe ID.
    ///     Consider implementing unit tests for the methods to ensure correctness.
    ///     Consider restructuring the program to fit the ep5BAS modular design pattern for better maintainability and adaptability to other I/O processors.
    ///     <i>Consider combining the data entry project with this project to create a unified application for both scheduling and executing events.</i>
    ///     Consider adding functionality to process inputs from the digital I/O. This would be effected in BusinessRules().
    ///         NOTE: This has been rejected, as this program is not intended to be responsive. Its function is to run a pre-defined recipe and then exit.
    /// </todo>

    internal class Program
    {
        const int ON = 1; 
        const int OFF = 0;

        static int Main()
        {
            SetupTheUI.SetupUI();
            InitializeIO.StartUp();
            BusinessRules.ApplyBusinessRules();
            SelectedOutputs.TurnOnSelectedOutputs();        // This forces all outputs to OFF.
            InitializeIO.ShutDown();
            return 0;
        }
    }
}