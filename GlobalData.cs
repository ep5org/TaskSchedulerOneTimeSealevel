using Sealevel;

namespace TaskSchedulerOneTimeSealevel
{
    public static class GlobalData
    {
        public static byte[] SeaMAXdata = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        public static byte[] SeaMAXpresets = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        public static byte[] SeaMAXdirections = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0];
        public static SeaMAX SeaMAX_DeviceHandler = new();
        public static byte[] machineState = new byte[96];

        public const int OFF = 0;
        public const int ON = 1;
        public const int SUCCESS = 0;

        //  These ID numbers identify the output and input channels in the SQL database table, corresponding to the physical I/O
        //  outputs for a simulated residential application
        //  board 1, port A
        public const int KitchenLight1 = 0;
        public const int KitchenLight2 = 1;
        public const int KitchenLight3 = 2;
        public const int PorchLight1 = 3;
        public const int PorchLight2 = 4;
        public const int PantryLight = 5;
        public const int Radio = 6;
        public const int ServerRoomLight = 7;
        //  board 1, port B
        public const int LivingRoomLight1 = 8;
        public const int LivingRoomLight2 = 9;
        public const int LivingRoomLight3 = 10;
        public const int HallLight = 11;
        public const int LibraryLight1 = 12;
        public const int LibraryLight2 = 13;
        public const int DownstairsStoreroomLight = 14;
        public const int YardLight1 = 15;
        //  board 1, port C
        public const int YardLight2 = 16;
        public const int MasterBedroomLight = 17;
        public const int UpstairsStoreroomLight = 18;
        public const int SecondBedroomLight = 19;
        public const int AtticLight = 20;
        public const int AtticEntranceLight = 21;
        public const int UpstairsBathroomLight = 22;
        public const int AlarmBell = 23;
        //  board 2, port A
        public const int Output001 = 24;
        public const int Output002 = 25;
        public const int Output003 = 26;
        public const int Output004 = 27;
        public const int Output005 = 28;
        public const int Output006 = 29;
        public const int Output007 = 30;
        public const int Output008 = 31;
        //  board 2, port B
        public const int Output009 = 32;
        public const int Output010 = 33;
        public const int Output011 = 34;
        public const int Output012 = 35;
        public const int Output013 = 36;
        public const int Output014 = 37;
        public const int Output015 = 38;
        public const int Output016 = 39;
        //  board 2, port C
        public const int Output017 = 40;
        public const int Output018 = 41;
        public const int Output019 = 42;
        public const int Output020 = 43;
        public const int Output021 = 44;
        public const int Output022 = 45;
        public const int Output023 = 46;
        public const int Output024 = 47;
        //  board 3, port A
        public const int Output025 = 48;
        public const int Output026 = 49;
        public const int Output027 = 50;
        public const int Output028 = 51;
        public const int Output029 = 52;
        public const int Output030 = 53;
        public const int Output031 = 54;
        public const int Output032 = 55;
        //  board 3, port B
        public const int Output033 = 56;
        public const int Output034 = 57;
        public const int Output035 = 58;
        public const int Output036 = 59;
        public const int Output037 = 60;
        public const int Output038 = 61;
        public const int Output039 = 62;
        public const int Output040 = 63;

        //  inputs
        //  board 3, port C
        public const int AC_INPUT1 = 64;
        public const int AC_INPUT2 = 65;
        public const int AC_INPUT3 = 66;
        public const int AC_INPUT4 = 67;
        public const int AC_INPUT5 = 68;
        public const int AC_INPUT6 = 69;
        public const int AC_INPUT7 = 70;
        public const int AC_INPUT8 = 71;
        //  board 4, port A
        public const int AC_INPUT9 = 72;
        public const int AC_INPUT10 = 73;
        public const int AC_INPUT11 = 74;
        public const int AC_INPUT12 = 75;
        public const int AC_INPUT13 = 76;
        public const int AC_INPUT14 = 77;
        public const int AC_INPUT15 = 78;
        public const int AC_INPUT16 = 79;
        //  board 4, port B
        public const int AC_INPUT17 = 80;
        public const int AC_INPUT18 = 81;
        public const int AC_INPUT19 = 82;
        public const int AC_INPUT20 = 83;
        public const int AC_INPUT21 = 84;
        public const int AC_INPUT22 = 85;
        public const int AC_INPUT23 = 86;
        public const int AC_INPUT24 = 87;
        //  board 4, port C
        public const int DC_INPUT1 = 88;
        public const int DC_INPUT2 = 89;
        public const int DC_INPUT3 = 90;
        public const int DC_INPUT4 = 91;
        public const int DC_INPUT5 = 92;
        public const int DC_INPUT6 = 93;
        public const int DC_INPUT7 = 94;
        public const int DC_INPUT8 = 95;
    }
}
