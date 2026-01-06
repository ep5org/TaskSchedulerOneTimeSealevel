using static System.Console;
using Sealevel;
using static Sealevel.SeaMAX;

namespace TaskSchedulerOneTimeSealevel
{
    class InitializeIO
    {
        public static int StartUp()
        {
            int SUCCESS = 0;
            int initCode = SUCCESS;

            WriteLine("Initializing the I/O...");
            Array.Clear(GlobalData.machineState);

            try
            {
                if (!GlobalData.SeaMAX_DeviceHandler.IsEthernetInitialized)
                {
                    WriteLine("Opening the Ethernet I/O processor...");
                    GlobalData.SeaMAX_DeviceHandler.SME_Initialize();
                    WriteLine("Opened the Ethernet I/O processor.");
                }

                //  do the initial search for modules on the network
                WriteLine("Beginning scan for modules...");
                int ModuleCount = GlobalData.SeaMAX_DeviceHandler.SME_SearchForModules();
                WriteLine("Modules found = {0}", ModuleCount.ToString());
                if (ModuleCount == 0)
                {
                    WriteLine("No I/O devices were found.");
                    WriteLine("Press the <ANY> key to continue....");
                    _ = ReadKey();
                    return(initCode);
                }
                else if (ModuleCount < 0)
                {
                    WriteLine("Error " + ModuleCount.ToString() + " searching for devices.");
                    _ = ReadKey();
                    return(initCode);
                }

                WriteLine(ModuleCount.ToString() + " device(s) found.");
                //  select the first device found
                int errorNumber = GlobalData.SeaMAX_DeviceHandler.SME_FirstModule();
                if (errorNumber < 0)
                {
                    WriteLine("Error selecting first device.");
                    _ = ReadKey();
                    return(initCode);
                }

                //  ping the device to ensure that it is still available
                errorNumber = GlobalData.SeaMAX_DeviceHandler.SME_Ping();
                WriteLine("Ping was successful.");
                Write("Returned error code {0}....", errorNumber);
                if (errorNumber != 1)
                    return (initCode);
                else
                    WriteLine("Module responded to request; module is powered and accessible.");

                    //  save the IP address
                    string ip = "";
                string netmask = "";
                string gateway = "";
                GlobalData.SeaMAX_DeviceHandler.SME_GetNetworkConfig(ref ip, ref netmask, ref gateway);
                if (errorNumber < 1)
                {
                    WriteLine("The device at " + ip + " failed to respond.");
                    return(initCode);
                }

                string name = "";
                errorNumber = GlobalData.SeaMAX_DeviceHandler.SME_GetName(ref name);
                if (errorNumber < 0)
                {
                    WriteLine("Could not retrieve name of device at " + ip);
                    return(initCode);
                }

                WriteLine("\nThe I/O processor at " + ip + " is identified as " + name + ".");
                WriteLine("It uses net mask {0} and gateway {1}.", netmask, gateway);

                errorNumber = GlobalData.SeaMAX_DeviceHandler.SM_Open(ip);
                if (errorNumber < 0)
                {
                    WriteLine("Open error = " + errorNumber + ".");
                }

                if (GlobalData.SeaMAX_DeviceHandler.IsSeaMAXOpen)
                    WriteLine("SeaMAX is open.");
                int major = 0;
                int minor = 0;
                int revision = 0;
                errorNumber = GlobalData.SeaMAX_DeviceHandler.SM_GetFirmwareVersion(ref major, ref minor, ref revision);
                if (errorNumber < 0)
                {
                    WriteLine("Get firmware error = " + errorNumber + ".");
                }
                else
                {
                    WriteLine("Firmware version:");
                    WriteLine("----------------");
                    WriteLine("Major: \t{0}", major);
                    WriteLine("Major: \t{0}", minor);
                    WriteLine("Major: \t{0}", revision);
                }

                GetPIOSettings(GlobalData.SeaMAX_DeviceHandler);

                //  set up the hardware with presets
                GlobalData.SeaMAXpresets = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
                GlobalData.SeaMAXdirections = [0, 0, 0, 0, 0, 0, 0, 0, 0xff, 0xff, 0xff, 0xff];
                errorNumber = GlobalData.SeaMAX_DeviceHandler.SM_SetPIOPresets(GlobalData.SeaMAXpresets);
                WriteLine("Set presets return value = " + errorNumber + ".");
                errorNumber = GlobalData.SeaMAX_DeviceHandler.SM_SetPIODirection(GlobalData.SeaMAXdirections);
                WriteLine("Set direction return value = " + errorNumber + ".");
            }
            catch (Exception e)
            {
                WriteLine(e.ToString());
            }
            finally
            {

            }
            return(initCode);
        }

        private static void GetPIOSettings(SeaMAX SeaMAX_DeviceHandler)
        {
            byte[] direction = new byte[12];
            byte[] presets = new byte[12];

            // Get the PIO Direction
            int errno = SeaMAX_DeviceHandler.SM_GetPIODirection(direction);
            if (errno < 0)
            {
                throw new Exception("Retrieving PIO Directions failed with " + errno.ToString());
            }

            // 0 = 8 outputs, nonzero = 8 inputs
            WriteLine("\nDirection: 12 11 10  9  8  7  6  5  4  3  2  1     nonzero = inputs, 0 = outputs");
            Write("           ");
            for (int i = direction.Length - 1; i >= 0; i--)
            {
                Write(direction[i].ToString("X2") + " ");
            }
            WriteLine();

            // Get the PIO output presets
            errno = SeaMAX_DeviceHandler.SM_GetPIOPresets(presets);
            if (errno < 0)
            {
                throw new Exception("Retrieving PIO Output Presets failed with " + errno.ToString());
            }

            //0 = 8 outputs, nonzero = 8 inputs
            WriteLine("Presets:   12 11 10  9  8  7  6  5  4  3  2  1     1 = on, 0 = off");
            Write("           ");
            for (int i = presets.Length - 1; i >= 0; i--)
            {
                Write(presets[i].ToString("X2") + " ");
            }
            WriteLine("\n");
        }

        public static void ShutDown()
        {
            int errorCode;

            //	Reset the twelve digital output ports to OFF
            errorCode = GlobalData.SeaMAX_DeviceHandler.SM_WritePIO([0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0]);
            if (errorCode < 0)
                WriteLine("\n\nWriting the digital outputs returned error code: {0}", errorCode);

            //  Deallocate the memory used by the Ethernet API
            if (GlobalData.SeaMAX_DeviceHandler.IsEthernetInitialized)
            {
                if (GlobalData.SeaMAX_DeviceHandler.SME_Cleanup() == 0)
                    WriteLine("\nThe Ethernet I/O processor has been closed.");
                else
                    WriteLine("\nUnable to deinitialize the I/O processor. Invalid handle.");
            }
            //  Close the SeaMAX instance when done
            if (GlobalData.SeaMAX_DeviceHandler.IsSeaMAXOpen)
            {
                GlobalData.SeaMAX_DeviceHandler.SM_Close();
                WriteLine("Dr SeaMAX has left the building.");
            }
            else
                WriteLine("SeaMAX appears not to be open...");
        }
    }
}
