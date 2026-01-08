using static System.Console;

namespace TaskSchedulerOneTimeSealevel
{
    internal class SelectedOutputs
    {
        public static int TurnOnSelectedOutputs()
        {
            const int ON = 1;
            const int OFF = 0;

            int errorNumber;
            int xfr;
            int portNumber;

            for (portNumber = 0; portNumber < 6; portNumber++)
            {
                GlobalData.SeaMAXdata[portNumber] = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (GlobalData.machineState[i + (portNumber * 8)] == ON)
                    {
                        xfr = GlobalData.SeaMAXdata[portNumber];
                        GlobalData.SeaMAXdata[portNumber] = (byte)xfr.SetBitTo1(i);
                        GetIntBinaryString(GlobalData.SeaMAXdata[portNumber]);
                    }
                    else
                    {
                        xfr = GlobalData.SeaMAXdata[portNumber];
                        GlobalData.SeaMAXdata[portNumber] = (byte)xfr.SetBitTo0(i);
                        GetIntBinaryString(GlobalData.SeaMAXdata[portNumber]);
                    }
                }
                switch (portNumber)
                {
                    case 0:
                        WriteLine("Port A1 = {0}", GlobalData.SeaMAXdata[portNumber]);
                        break;
                    case 1:
                        WriteLine("Port B1 = {0}", GlobalData.SeaMAXdata[portNumber]);
                        break;
                    case 2:
                        WriteLine("Port C1 = {0}", GlobalData.SeaMAXdata[portNumber]);
                        break;
                    case 3:
                        WriteLine("Port A2 = {0}", GlobalData.SeaMAXdata[portNumber]);
                        break;
                    case 4:
                        WriteLine("Port B2 = {0}", GlobalData.SeaMAXdata[portNumber]);
                        break;
                    case 5:
                        WriteLine("Port C2 = {0}", GlobalData.SeaMAXdata[portNumber]);
                        break;
                    //case 6:
                    //    WriteLine("Port A3 = {0}", GlobalData.SeaMAXdata[portNumber]);
                    //    break;
                    //case 7:
                    //    WriteLine("Port B3 = {0}", GlobalData.SeaMAXdata[portNumber]);
                    //    break;
                }
            }
            //  write full machine state image to I/O processor
            errorNumber = GlobalData.SeaMAX_DeviceHandler.SM_WritePIO(GlobalData.SeaMAXdata);
            if (errorNumber < 0)
            {
                WriteLine("\nWriting the digital outputs returned error code: {0}", errorNumber);
                _ = ReadKey();
            }
            /// <remarks>
            ///      0	Successful completion.
            ///     -1  Invalid SeaMAX handle.
            ///     -2  Connection is not established. Check the provided Connection object state.
            ///     -3  Read error waiting for response. Unknown Modbus exception.
            ///     -4  Illegal Modbus Function(Modbus Exception 0x01).
            ///     -5  Illegal Data Address(Modbus Exception 0x02).
            ///     -6  Illegal Data Value(Modbus Exception 0x03).
            ///     -7  Modbus CRC was invalid. Possible communications problem.
            /// </remarks>
            return errorNumber;
        }

        /// <summary>
        ///     Bit-twiddling functions necessitated by the nature of the Sealevel I/O processor.
        /// </summary>summary>
        static string GetIntBinaryString(int n)
        {
            char[] b = new char[8];
            int pos = 7;
            int i = 0;

            while (i < 8)
            {
                if ((n & (1 << i)) != 0)
                    b[pos] = '1';
                else
                    b[pos] = '0';
                pos--;
                i++;
            }
            return new string(b);
        }
    }

    static class BitExtensions
    {
        public static int SetBitTo1(this int value, int position)
        {
            // Set a bit at position to 1.
            return value |= (1 << position);
        }

        public static int SetBitTo0(this int value, int position)
        {
            // Set a bit at position to 0.
            return value & ~(1 << position);
        }

        public static bool IsBitSetTo1(this int value, int position)
        {
            // Return whether bit at position is set to 1.
            return (value & (1 << position)) != 0;
        }

        public static bool IsBitSetTo0(this int value, int position)
        {
            // If not 1, bit is 0.
            return !IsBitSetTo1(value, position);
        }
    }

}