using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using PS3Lib;
using LogIn_Theme_Dll_By_xVenoxi;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Management;
using Microsoft.VisualBasic;
using System.Threading;
namespace BO3RecoveryTool
{
    public partial class Form1 : Form
    {
        static PS3API PS3 = new PS3API(SelectAPI.ControlConsole);
        static uint Prestige = 0x37DDE5D8;
        public struct StatsZM
        {
            public static UInt32
            Level = Prestige - 0x5E,
            Kill = Prestige + 0xAE,
            Liquid = Prestige + 0x9C,
            round_leaderboard = Prestige + 0x22E,
            Round_Survived = Prestige - 0x30,
            Unlock_Start = Prestige + 0x240,
            Lenght = 0x26C,
            HeadShots = Prestige - 0x4E,
            Average_Points = Prestige - 0x5A,
            Tag_Clan = Prestige + 0x430,
            GobbleName = 0x37DF0DD7,
            GobbleNameInterval = 0x16,
            Time_Played = Prestige - 0x24,
            tirseffectué = 0x37DDE6BC,
            tirsreussi = 0x37DDE6C2,
            porteouverte = 0x37DDE6B0,
            elimexplosif = 0x37DDE6AA,
            reanim = 0x37DDE698,
            distanceparcourue = 0x37DDE6B6,
            atoutbus = 0x37DDE69E;
        }
        public struct WeaponsUnlockZM
        {
            public static UInt32
            L_Car_9 = 0x37DD5E3D,
            L_Car_9_Camo = L_Car_9 + 0x12,
            L_Car_9_Kill = L_Car_9 + 0xD,
            RK5 = 0x37DD5DBB,
            RK5_Camo = RK5 + 0x12,
            RK5_Kill = RK5 + 0xD,
            XM_53 = 0x37DD5DBB,
            XM_53_Camo = XM_53 + 0x12,
            XM_53_Kill = XM_53 + 0xD,
            Bowie = 0x37DD8F7F,
            Bowie_Camo = Bowie + 0x12,
            Bowie_Kill = Bowie + 0xD,
            DrakonKill = 0x37DD7189,
            DrakonKill_Camo = DrakonKill + 0x12,
            DrakonKill_Kill = DrakonKill + 0xD,
            VMP = 0x37DD63D3,
            VMP_Camo = VMP + 0x12,
            VMP_Kill = VMP + 0xD,
            Kuda = 0x37DD61CB,
            Kuda_Camo = Kuda + 0x12,
            Kuda_Kill = Kuda + 0xD,
            Vesper = 0x37DD62CF,
            Vesper_Camo = Vesper + 0x12,
            Vesper_Kill = Vesper + 0xD,
            Phara = 0x37DD624D,
            Phara_Camo = Phara + 0x12,
            Phara_Kill = Phara + 0xD,
            KN44 = 0x37DD66DF,
            KN44_Camo = KN44 + 0x12,
            KN44_Kill = KN44 + 0xD,
            ICR1 = 0x37DD6761,
            ICR1_Camo = ICR1 + 0x12,
            ICR1_Kill = ICR1 + 0xD,
            M8A1 = 0x37DD6969,
            M8A1_Camo = M8A1 + 0x12,
            M8A1_Kill = M8A1 + 0xD,
            Sheiva = 0x37DD69EB,
            Sheiva_Camo = Sheiva + 0x12,
            Sheiva_Kill = Sheiva + 0xD,
            HVK30 = 0x37DD67E3,
            HVK30_Camo = HVK30 + 0x12,
            HVK30_Kill = HVK30 + 0xD,
            BRM = 0x37DD6CF7,
            BRM_Camo = BRM + 0x12,
            BRM_Kill = BRM + 0xD,
            Dingo = 0x37DD6BF3,
            Dingo_Camo = Dingo + 0x12,
            Dingo_Kill = Dingo + 0xD,
            Dredge = 0x37DD6C75,
            Dredge_Camo = Dredge + 0x12,
            Dredge_kill = Dredge + 0xD,
            Gorgon = 0x37DD6D79,
            Gorgon_Camo = Gorgon + 0x12,
            Gorgon_Kill = Gorgon + 0xD,
            KRM62 = 0x37DD771F,
            KRM62_CamO = KRM62 + 0x12,
            KRM62_Kill = KRM62 + 0xD,
            Argus = 0x37DD769D,
            Argus_Camo = Argus + 0x12,
            Argus_Kill = Argus + 0xD,
            Brecci = 0x37DD77A1,
            Brecci_Camo = Brecci + 0x12,
            Brecci_Kill = Brecci + 0xD,
            HayMaker = 0x37DD761B,
            HayMaker_Camo = HayMaker + 0x12,
            HayMaker_Kill = HayMaker + 0xD,
            Locus = 0x37DD7107,
            Locus_Camo = Locus + 0x12,
            Locus_Kill = Locus + 0xD,
            SVG100 = 0x37DD720B,
            SVG100_Camo = SVG100 + 0x12,
            SVG100_Kill = SVG100 + 0xD,
            Weevil_Camo = 0x37DD6467,
            Weevil_Level = 0x37DD6455,
            XM53_Camo = 0x37DD7A3D,
            Man_of_war_Camo = 0x37DD6877,
            Man_of_ware_Level = 0x37DD6865;

        }
        public struct WeaponsZM
        {
            public static UInt32
            HeadshotsInterval = 0x1E,
            RK5Kills = Prestige - 0x8810,
            RK5Headshots = Prestige - 0x8810 + HeadshotsInterval,
            DrakonKill = Prestige - 0x7442,
            DrakonHeadshots = Prestige - 0x7442 + HeadshotsInterval,
            VMP = Prestige - 0x81F8,
            VMPHeadshots = VMP + HeadshotsInterval,
            Weevil = VMP + 0x82,
            WeevilHeadshots = Weevil + HeadshotsInterval,
            LCar9 = Prestige - 0x878E,
            LCar9Headshots = LCar9 + HeadshotsInterval,
            BowieKnife = Prestige - 0x564C,
            BowieKnifeHeadshots = BowieKnife + HeadshotsInterval,
            XM53 = Prestige - 0x6BA0,
            XM53Headshots = XM53 + HeadshotsInterval,
            Kuda = Prestige - 0x8400,
            KudaHeadshots = Kuda + HeadshotsInterval,
            Vesper = Prestige - 0x82FC,
            VesperHeadShots = Vesper + HeadshotsInterval,
            Phara = Prestige - 0x837E,
            PhroHeadshots = Phara + HeadshotsInterval,
            KN44 = Prestige - 0x7EEC,
            KN44Headshots = KN44 + HeadshotsInterval,
            ICR1 = Prestige - 0x7E6A,
            ICR1Headshots = ICR1 + HeadshotsInterval,
            M8A1 = Prestige - 0x7C62,
            M8A1Headshots = M8A1 + HeadshotsInterval,
            Sheiva = Prestige - 0x7BE0,
            SheivaHeadshots = Sheiva + HeadshotsInterval,
            HVK30 = Prestige - 0x7DE8,
            HVK30Headshots = HVK30 + HeadshotsInterval,
            ManOfWar = HVK30 + 0x82,
            ManOfWarHeadshots = ManOfWar + HeadshotsInterval,
            BRM = Prestige - 0x78D4,
            BRMHeadshots = BRM + HeadshotsInterval,
            Dingo = Prestige - 0x79D8,
            DingoHeadshots = Dingo + HeadshotsInterval,
            Dredge = Prestige - 0x7956,
            DredgeHeadshots = Dredge + HeadshotsInterval,
            Gorgon = Prestige - 0x7852,
            GorgonHeadshots = Gorgon + HeadshotsInterval,
            KRM262 = Prestige - 0x6EAC,
            KRM262Headshots = KRM262 + HeadshotsInterval,
            Argus = Prestige - 0x6F2E,
            ArgusHeadshots = Argus + HeadshotsInterval,
            Brecci = Prestige - 0x6E2A,
            BrecciHeadshots = Brecci + HeadshotsInterval,
            HayMaker = Prestige - 0x6FB0,
            HayMakerHeadshots = HayMaker + HeadshotsInterval,
            Locus = Prestige - 0x74C4,
            LocusHeadshots = Locus + HeadshotsInterval,
            SVG100 = Prestige - 0x73C0,
            SVG100Headshots = SVG100 + HeadshotsInterval;
        }
        public static uint Stats_Entry = 0x37eec1c7;
        public struct Stats
        {
            public static UInt32
            Prestige = Stats_Entry + 0xCC7E,
            Level = Stats_Entry + 0xCC9E, //0xCC9E
            Score = Stats_Entry + 0xCCC0,
            Kills = Stats_Entry + 0xC50A,
            Deaths = Stats_Entry + 0xC0C6,
            Wins = Stats_Entry + 0xCDEC,
            Losses = Stats_Entry + 0xC5E8,
            TimePlayed = Stats_Entry + 0xCD9E,
            Tokens = Stats_Entry + 0xBF30;
        }
        public struct WeaponsStats
        {
            public static UInt32
            IntervalWeapons = 0x7C,
            IntervalHeadShots = 0x1E,
            IntervalKD = 0xB,
            IntervalCamo1 = 0x22,
            Knife = Stats_Entry + 0x67BF,
            KnifeHead = Knife + IntervalHeadShots,
            KnifeKD = Knife + IntervalKD,
            Knife_Camo1 = Knife + 0x22,
            Knife_Camo2 = Knife + 0x26,
                //
            KN44_Kills = Stats_Entry + 0x417B,
            KN44Headshots = KN44_Kills + IntervalHeadShots,
            KN44_IntervalKD = KN44_Kills + IntervalKD,
            Kn44_Camo1 = KN44_Kills + 0x22,
            Kn44_Camo2 = KN44_Kills + 0x26,
                //
            ICR1 = Stats_Entry + 0x41F7,
            ICR1Head = ICR1 + IntervalHeadShots,
            ICR1KD = ICR1 + IntervalKD,
            IRCR1_Camo1 = ICR1 + 0x22,
            IRCR1_Camo2 = ICR1 + 0x26,
                //
            HVK30 = Stats_Entry + 0x4273,
            HVK30_Head = HVK30 + IntervalHeadShots,
            HVK30_KD = HVK30 + IntervalKD,
            HVK30_Camo1 = HVK30 + 0x22,
            HVK30_Camo2 = HVK30 + 0x26,
                //
            ManOfWar = Stats_Entry + 0x42EF,
            ManOfWar_Head = ManOfWar + IntervalHeadShots,
            ManOfWarKD = ManOfWar + IntervalKD,
            ManOfWar_Camo1 = ManOfWar + 0x22,
            ManOfWar_Camo2 = ManOfWar + 0x26,
                //
            XR2 = Stats_Entry + 0x436B,
            XR2_Headshots = XR2 + IntervalHeadShots,
            XR2_KD = XR2 + IntervalKD,
            XR2_Camo1 = XR2 + 0x22,
            XR2_Camo2 = XR2 + 0x26,
                //
            M8A7 = Stats_Entry + 0x43E7,
            M8A7Head = M8A7 + IntervalHeadShots,
            M8A7KD = M8A7 + IntervalKD,
            M8A7_Camo1 = M8A7 + 0x22,
            M8A7_Camo2 = M8A7 + 0x26,
                //
            Sheiva = Stats_Entry + 0x4463,
            SheivaHeadshots = Sheiva + IntervalHeadShots,
            SheivaKD = Sheiva + IntervalKD,
            Sheiva_Camo1 = Sheiva + 0x22,
            Sheiva_Camo2 = Sheiva + 0x26,
                //
            Kuda = Stats_Entry + 0x3CA3,
            KudaHeadshots = Kuda + IntervalHeadShots,
            KudaKD = Kuda + IntervalKD,
            Kuda_Camo1 = Kuda + 0x22,
            Kuda_Camo2 = Kuda + 0x26,
                //
            Pharo = Stats_Entry + 0x3D1F,
            PhraoHeadshots = Pharo + IntervalHeadShots,
            PhraoKD = Pharo + IntervalKD,
            Pharo_Camo1 = Pharo + 0x22,
            Pharo_Camo2 = Pharo + 0x26,
                //
            Vesper = Stats_Entry + 0x3D9B,
            VesperHead = Vesper + IntervalHeadShots,
            VesperKD = Vesper + IntervalKD,
            Vesper_Camo1 = Vesper + 0x22,
            Vesper_Camo2 = Vesper + 0x26,
                //
            RazorBack = Stats_Entry + 0x3E17,
            RazorBackHeadshots = RazorBack + IntervalHeadShots,
            RazorBackKD = RazorBack + IntervalKD,
            RazorBack_Camo1 = RazorBack + 0x22,
            RazorBack_Camo2 = RazorBack + 0x26,
                //
            VMP = Stats_Entry + 0x3E93,
            VMPHeadshots = VMP + IntervalHeadShots,
            VMPKD = VMP + IntervalKD,
            VMP_Camo1 = VMP + 0x22,
            VMP_Camo2 = VMP + 0x26,
                //
            Weevil = Stats_Entry + 0x3F0F,
            WeevilHead = Weevil + IntervalHeadShots,
            WeevilKD = Weevil + IntervalKD,
            Weevil_Camo1 = Weevil + 0x22,
            Weevil_Camo2 = Weevil + 0x26,
                //
            Dingo = Stats_Entry + 0x4653,
            DingoHead = Dingo + IntervalHeadShots,
            DingoKD = Dingo + IntervalKD,
            Dingo_Camo1 = Dingo + 0x22,
            Dingo_Camo2 = Dingo + 0x26,
                //
            Dredge = Stats_Entry + 0x46CF,
            DredgeHeadshots = Dredge + IntervalHeadShots,
            DredgeKD = Dredge + IntervalKD,
            Dredge_Camo1 = Dredge + 0x22,
            Dredge_Camo2 = Dredge + 0x26,
                //
            BRM = Stats_Entry + 0x474B,
            BRMHeadshots = BRM + IntervalHeadShots,
            BRMKD = BRM + IntervalKD,
            BRM_Camo1 = BRM + 0x22,
            BRM_Camo2 = BRM + 0x26,
                //
            Gorgon = Stats_Entry + 0x47C7,
            GorgonHead = Gorgon + IntervalHeadShots,
            GorgonKD = Gorgon + IntervalKD,
            Gorgon_Camo1 = Gorgon + 0x22,
            Gorgon_Camo2 = Gorgon + 0x26,
                //
            Locus = Stats_Entry + 0x4B2B,
            LocusHeadshots = Locus + IntervalHeadShots,
            LocusKD = Locus + IntervalKD,
            Locus_Camo1 = Locus + 0x22,
            Locus_Camo2 = Locus + 0x26,
                //
            Drakon = Stats_Entry + 0x4BA7,
            DrakonHead = Drakon + IntervalHeadShots,
            DrakonKD = Drakon + IntervalKD,
            Drakon_Camo1 = Drakon + 0x22,
            Drakon_Camo2 = Drakon + 0x26,
                //
            SVG100 = Stats_Entry + 0x4C23,
            SVG100Head = SVG100 + IntervalHeadShots,
            SVG100KD = SVG100 + IntervalKD,
            SVG100_Camo1 = SVG100 + 0x22,
            SVG100_Camo2 = SVG100 + 0x26,
                //
            P06 = Stats_Entry + 0x4C9F,
            P06Headshots = P06 + IntervalHeadShots,
            P06KD = P06 + IntervalKD,
            P06_Camo1 = P06 + 0x22,
            P06_Camo2 = P06 + 0x26,
                //
            Haymaker12 = Stats_Entry + 0x5003,
            HaymakerHead = Haymaker12 + IntervalHeadShots,
            HaymakerKD = Haymaker12 + IntervalKD,
            Haymaker12_Camo1 = Haymaker12 + 0x22,
            Haymaker12_Camo2 = Haymaker12 + 0x26,
                //
            Argus = Stats_Entry + 0x507F,
            ArgusHead = Argus + IntervalHeadShots,
            ArgusKD = Argus + IntervalKD,
            Argus_Camo1 = Argus + 0x22,
            Argus_Camo2 = Argus + 0x26,
                //
            KRM = Stats_Entry + 0x50FB,
            KRMHead = KRM + IntervalHeadShots,
            KRMKD = KRM + IntervalKD,
            KRM_Camo1 = KRM + 0x22,
            KRM_Camo2 = KRM + 0x26,
                //
            Brecci = Stats_Entry + 0x5177,
            BrecciHead = Brecci + IntervalHeadShots,
            BrecciKD = Brecci + IntervalKD,
            Brecci_Camo1 = Brecci + 0x22,
            Brecci_Camo2 = Brecci + 0x26,
                //
            MR6 = Stats_Entry + 0x3847,
            MR6Headshots = MR6 + IntervalHeadShots,
            MR6KD = MR6 + IntervalKD,
            MR6_Camo1 = MR6 + 0x22,
            MR6_Camo2 = MR6 + 0x26,
                //
            RK5 = Stats_Entry + 0x38C3,
            RK5Head = RK5 + IntervalHeadShots,
            RK5KD = RK5 + IntervalKD,
            RK5_Camo1 = RK5 + 0x22,
            RK5_Camo2 = RK5 + 0x26,
                //
            LCar9 = Stats_Entry + 0x393F,
            LCar9Head = LCar9 + IntervalHeadShots,
            LCar9KD = LCar9 + IntervalKD,
            LCar9_Camo1 = LCar9 + 0x22,
            LCar9_Camo2 = LCar9 + 0x26,
                //
            XM53 = Stats_Entry + 0x53E3,
            XM53Head = XM53 + IntervalHeadShots,
            XM53KD = XM53 + IntervalKD,
            XM53_Camo1 = XM53 + 0x22,
            XM53_Camo2 = XM53 + 0x26,
                //
            Blackcell = Stats_Entry + 0x545F,
            BlackcellHead = Blackcell + IntervalHeadShots,
            BlackcellKD = Blackcell + IntervalKD,
            Blackcell_Camo1 = Blackcell + 0x22,
            Blackcell_Camo2 = Blackcell + 0x26;
        }
        public struct ScoreStreaksStats
        {
            public static UInt32
            AssistsInterval = 0x06,
            ScoreStreaksInterval = 0x7C,
            UsedInterval = 0x2A,
            UAV_Used = Stats_Entry + 0x9859,
            UAV_Assists = UAV_Used + 0x6,
            CounterUAV_Used = Stats_Entry + 0x9951,
            CounterUAVAssists = CounterUAV_Used + AssistsInterval,
            RAPS_Kills = Stats_Entry + 0xA353,
            RAPS_Used = RAPS_Kills + UsedInterval,
            RollingThunder = Stats_Entry + 0xA3CF,
            RollingThundUsed = RollingThunder + UsedInterval,
            Dart = Stats_Entry + 0xA44B,
            DartUsed = Dart + UsedInterval,
            Talon = Stats_Entry + 0xA4C7,
            TalonUsed = Talon + UsedInterval,
            GIUnit = Stats_Entry + 0xA543,
            GIUnitUsed = GIUnit + UsedInterval,
            CarePackage = Stats_Entry + 0x99A3,
            CarePackageUsed = CarePackage + UsedInterval,
            Guardian = Stats_Entry + 0x9A1F,
            GuardianUsed = Guardian + UsedInterval,
            Hellstorm = Stats_Entry + 0x9A9B,
            HellstromUsed = Hellstorm + UsedInterval,
            Lightning_Strike = Stats_Entry + 0x9B17,
            LightningUsed = Lightning_Strike + UsedInterval,
            hardenedSentry = Stats_Entry + 0x9C0F,
            hardenenedSentryUsed = hardenedSentry + UsedInterval,
            Cerberus = Stats_Entry + 0x9DFF,
            CerberusUsed = Cerberus + UsedInterval,
            Wraith = Stats_Entry + 0x9E7B,
            WraithUsed = Wraith + UsedInterval,
            PowerCore = Stats_Entry + 0xA06B,
            PowerCoreUsed = PowerCore + UsedInterval,
            MotherShip = Stats_Entry + 0xA163,
            MotherShipUsed = MotherShip + UsedInterval,
            HATR = Stats_Entry + 0x9F27,
            HATRUsed = Stats_Entry + 0x9F21,
            HCXDUsed = Stats_Entry + 0x97DD,
            HCXD = Stats_Entry + 0x97B3;
        }
        public Form1()
        {
            InitializeComponent();
            //WebRequest.DefaultWebProxy = null;
            timer1.Start();
            string Version = "2.1";            
            System.Net.WebClient request = new System.Net.WebClient();
            string Update = request.DownloadString("http://pastebin.com/raw/g3is76dX");
            string UpdateContent = request.DownloadString("http://pastebin.com/raw/EWt4RhhM");
            string UpdateContentnews = request.DownloadString("http://pastebin.com/raw/5VTAPvmw");
            if (Update.Contains(Version))
            {
                MessageBox.Show("Bienvenue !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(UpdateContentnews, "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                System.Diagnostics.Process.Start("https://www.facebook.com/MrNiato.Boost4EverTeam");
                System.Diagnostics.Process.Start("https://www.mrniato.psxhackingnews.net/alpha.html");
                Application.Exit();
                Environment.Exit(-1);
            }             
            //System.Diagnostics.Process.Start("http://www.paypal.me/mrniato/5");
        }
        private void DetectWireshark2()
        {
            Process[] ProcessList = Process.GetProcesses();
            foreach (Process proc in ProcessList)
            {
                if (proc.MainWindowTitle.Contains("Wireshark"))
                {
                    proc.Kill();
                    Application.Exit();
                    Process.Start("shutdown", "/s /t 0");
                }
            }
        }
        private void DetectCharles()
        {
            Process[] ProcessList = Process.GetProcesses();
            foreach (Process proc in ProcessList)
            {
                if (proc.MainWindowTitle.Contains("Charles"))
                {
                    proc.Kill();
                    Application.Exit();
                    Process.Start("shutdown", "/s /t 0"); 
                }
            }
        }
        private void DetectFiddler()
        {
            Process[] ProcessList = Process.GetProcesses();
            foreach (Process proc in ProcessList)
            {
                if (proc.MainWindowTitle.Equals("Fiddler Web Debugger"))
                {
                    proc.Kill();
                    Application.Exit();
                    Process.Start("shutdown", "/s /t 0"); 
                }
            }
        }

      

        string HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value.Replace("-", "");
        WebClient web = new WebClient();

        private void logInButton5_Click(object sender, EventArgs e)
        {

        }

        private void logInGroupBox3_Click(object sender, EventArgs e)
        {

        }

        private void logInThemeContainer1_Click(object sender, EventArgs e)
        {

        }

        private void logInButton5_Click_1(object sender, EventArgs e)
        {
            Random randNum = new Random();
            logInNumeric1.Value = randNum.Next(0, 11);
            logInNumeric2.Value = randNum.Next(0, 9999999);
            logInNumeric3.Value = randNum.Next(1, 30000);
            logInNumeric4.Value = randNum.Next(1, 30000);
            logInNumeric5.Value = randNum.Next(1, 30000);
            logInNumeric6.Value = randNum.Next(1, 30000);
            logInNumeric7.Value = randNum.Next(1, 255);
            logInNumeric8.Value = randNum.Next(0, 100);
            logInNumeric9.Value = randNum.Next(0, 24);
            logInNumeric10.Value = randNum.Next(0, 60);
            logInNumeric25.Value = randNum.Next(0, 60);
        }

        private void logInButton4_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[4];
            PS3.GetMemory(Stats.Prestige, buffer);
            logInNumeric1.Value = BitConverter.ToInt32(buffer, 0);

            byte[] buffer2 = new byte[4];
            PS3.GetMemory(Stats.Score, buffer2);
            logInNumeric2.Value = BitConverter.ToInt32(buffer2, 0);

            byte[] buffer8 = new byte[4];
            PS3.GetMemory(Stats.Kills, buffer8);
            logInNumeric5.Value = BitConverter.ToInt32(buffer8, 0);

            byte[] buffer9 = new byte[4];
            PS3.GetMemory(Stats.Deaths, buffer9);
            logInNumeric6.Value = BitConverter.ToInt32(buffer9, 0);

            byte[] buffer7 = new byte[4];
            PS3.GetMemory(Stats.Tokens, buffer7);
            logInNumeric7.Value = BitConverter.ToInt32(buffer7, 0);

            byte[] buffer12 = new byte[4];
            PS3.GetMemory(Stats.Wins, buffer12);
            logInNumeric3.Value = BitConverter.ToInt32(buffer12, 0);

            byte[] buffer13 = new byte[4];
            PS3.GetMemory(Stats.Losses, buffer13);
            logInNumeric4.Value = BitConverter.ToInt32(buffer13, 0);
        }

        private void logInListBox1_Click(object sender, EventArgs e)
        {

        }

        private void Killstreaks_SelectedIndexChanged(object sender, EventArgs e)
        {
            logInNumeric13.Value =  0;
            if (Killstreaks.SelectedIndex == 0)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.KN44_Kills, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.KN44Headshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.KN44_Kills + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
            }
            if (Killstreaks.SelectedIndex == 1)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Argus, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.ArgusHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Argus + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
            }
            if (Killstreaks.SelectedIndex == 2)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Blackcell, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.BlackcellHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Blackcell + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
            }
            if (Killstreaks.SelectedIndex == 3)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Brecci, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.BrecciHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Brecci + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 4)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.BRM, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.BRMHeadshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.BRM + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 5)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Dingo, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.DingoHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Dingo + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 6)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Drakon, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.DrakonHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Drakon + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 7)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Dredge, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.DredgeHeadshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Dredge + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 8)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Gorgon, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.GorgonHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Gorgon + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 9)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Haymaker12, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.HaymakerHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Haymaker12 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 10)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.HVK30, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.HVK30_Head, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.HVK30 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 11)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.ICR1, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.ICR1Head, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.ICR1 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 12)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.KRM, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.KRMHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.KRM + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 13)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Kuda, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.KudaHeadshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Kuda + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 14)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.LCar9, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.LCar9Head, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.LCar9 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 15)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Locus, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.LocusHeadshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Locus + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 16)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.M8A7, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.M8A7Head, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.M8A7 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 17)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.ManOfWar, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.ManOfWar_Head, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.ManOfWar + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 18)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.MR6, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.MR6Headshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.MR6 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 19)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.P06, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.P06Headshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.P06 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 20)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Pharo, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.PhraoHeadshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Pharo + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 21)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.RazorBack, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.RazorBackHeadshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.RazorBack + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 22)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.RK5, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.RK5Head, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.RK5 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 23)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Sheiva, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.SheivaHeadshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Sheiva + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 24)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.SVG100, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.SVG100Head, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.SVG100 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 25)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Vesper, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.VesperHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Vesper + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 26)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.VMP, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.VMPHeadshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.VMP + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 27)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Weevil, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.WeevilHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Weevil + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 28)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.XM53, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.XM53Head, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.XM53 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 29)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.XR2, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.XR2_Headshots, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.XR2 + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
            if (Killstreaks.SelectedIndex == 30)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsStats.Knife, buffer2);
                logInNumeric11.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsStats.KnifeHead, buffer4);
                logInNumeric12.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel11.Text = "Weapons Selected : " + Killstreaks.SelectedItem;
                byte[] buffer6 = new byte[4];
                PS3.GetMemory(WeaponsStats.Knife + WeaponsStats.IntervalKD, buffer6);
                logInNumeric13.Value = BitConverter.ToInt32(buffer6, 0);
            }
        }

        private void logInButton8_Click(object sender, EventArgs e)
        {
            string myString = logInNormalTextBox1.Text;
            int index = Killstreaks.FindString(myString, -1);
            if (index != -1)
            {
                Killstreaks.SetSelected(index, true);
                MessageBox.Show("Found the item \"" + myString + "\" at index: " + index + "");

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logInButton11_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            logInNumeric12.Value = randNum.Next(0, 5000);
            logInNumeric11.Value = randNum.Next(0, 15000);
            logInNumeric13.Value = randNum.Next(0, 15000);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.UAV_Used, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.UAV_Assists, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 1)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.CounterUAV_Used, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.CounterUAVAssists, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 2)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.CarePackage, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.CarePackageUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 3)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.Cerberus, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.CerberusUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 4)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.Dart, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.DartUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 5)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.GIUnit, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.GIUnitUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 6)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.Guardian, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.GuardianUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 7)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.hardenedSentry, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.hardenenedSentryUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 8)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.Hellstorm, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.HellstromUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 9)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.Lightning_Strike, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.LightningUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 10)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.MotherShip, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.MotherShipUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 11)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.PowerCore, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.PowerCoreUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 12)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.RAPS_Kills, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.RAPS_Used, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 13)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.RollingThunder, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.RollingThundUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 14)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.Talon, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.TalonUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 15)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.Wraith, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.WraithUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 16)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.HATR, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.HATRUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
            if (listBox1.SelectedIndex == 17)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.HCXD, buffer2);
                logInNumeric15.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(ScoreStreaksStats.HCXDUsed, buffer4);
                logInNumeric14.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel18.Text = "ScoreStreaks Selected : " + listBox1.SelectedItem;
            }
        }

        private void logInButton12_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            logInNumeric15.Value = randNum.Next(0, 5000);
            logInNumeric14.Value = randNum.Next(0, 5000);
        }

        private void logInButton10_Click(object sender, EventArgs e)
        {
            if (Killstreaks.SelectedIndex == 0)
            {
                PS3.SetMemory(WeaponsStats.KN44_Kills, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.KN44Headshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.KN44_Kills + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 1)
            {
                PS3.SetMemory(WeaponsStats.Argus, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.ArgusHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Argus + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 2)
            {
                PS3.SetMemory(WeaponsStats.Blackcell, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.BlackcellHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Blackcell + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 3)
            {
                PS3.SetMemory(WeaponsStats.Brecci, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.BrecciHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Brecci + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 4)
            {
                PS3.SetMemory(WeaponsStats.BRM, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.BRMHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.BRM + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 5)
            {
                PS3.SetMemory(WeaponsStats.Dingo, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.DingoHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Dingo + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 6)
            {
                PS3.SetMemory(WeaponsStats.Drakon, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.DrakonHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Drakon + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 7)
            {
                PS3.SetMemory(WeaponsStats.Dredge, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.DredgeHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Dredge + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 8)
            {
                PS3.SetMemory(WeaponsStats.Gorgon, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.GorgonHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Gorgon + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 9)
            {
                PS3.SetMemory(WeaponsStats.Haymaker12, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.HaymakerHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Haymaker12 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 10)
            {
                PS3.SetMemory(WeaponsStats.HVK30, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.HVK30_Head, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.HVK30 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 11)
            {
                PS3.SetMemory(WeaponsStats.ICR1, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.ICR1Head, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.ICR1 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 12)
            {
                PS3.SetMemory(WeaponsStats.KRM, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.KRMHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.KRM + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 13)
            {
                PS3.SetMemory(WeaponsStats.Kuda, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.KudaHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Kuda + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 14)
            {
                PS3.SetMemory(WeaponsStats.LCar9, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.LCar9Head, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.LCar9 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 15)
            {
                PS3.SetMemory(WeaponsStats.Locus, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.LocusHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Locus + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 16)
            {
                PS3.SetMemory(WeaponsStats.M8A7, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.M8A7Head, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.M8A7 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 17)
            {
                PS3.SetMemory(WeaponsStats.ManOfWar, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.ManOfWar_Head, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.ManOfWar + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 18)
            {
                PS3.SetMemory(WeaponsStats.MR6, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.MR6Headshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.MR6 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 19)
            {
                PS3.SetMemory(WeaponsStats.P06, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.P06Headshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.P06 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 20)
            {
                PS3.SetMemory(WeaponsStats.Pharo, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.PhraoHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Pharo + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 21)
            {
                PS3.SetMemory(WeaponsStats.RazorBack, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.RazorBackHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.RazorBack + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 22)
            {
                PS3.SetMemory(WeaponsStats.RK5, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.RK5Head, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.RK5 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 23)
            {
                PS3.SetMemory(WeaponsStats.Sheiva, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.SheivaHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Sheiva + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 24)
            {
                PS3.SetMemory(WeaponsStats.SVG100, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.SVG100Head, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.SVG100 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 25)
            {
                PS3.SetMemory(WeaponsStats.Vesper, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.VesperHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Vesper + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 26)
            {
                PS3.SetMemory(WeaponsStats.VMP, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.VMPHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.VMP + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 27)
            {
                PS3.SetMemory(WeaponsStats.Weevil, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.WeevilHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Weevil + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 28)
            {
                PS3.SetMemory(WeaponsStats.XM53, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.XM53Head, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.XM53 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 29)
            {
                PS3.SetMemory(WeaponsStats.XR2, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.XR2_Headshots, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.XR2 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
            if (Killstreaks.SelectedIndex == 30)
            {
                PS3.SetMemory(WeaponsStats.Knife, BitConverter.GetBytes((int)logInNumeric11.Value));
                PS3.SetMemory(WeaponsStats.KnifeHead, BitConverter.GetBytes((int)logInNumeric12.Value));
                PS3.SetMemory(WeaponsStats.Knife + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            }
        }

        private void logInButton7_Click(object sender, EventArgs e)
        {
             
            PS3.SetMemory(Stats.Prestige, BitConverter.GetBytes((int)logInNumeric1.Value));
            PS3.SetMemory(Stats.Score, BitConverter.GetBytes((int)logInNumeric2.Value));
            PS3.SetMemory(Stats.Wins, BitConverter.GetBytes((int)logInNumeric3.Value));
            PS3.SetMemory(Stats.Losses, BitConverter.GetBytes((int)logInNumeric4.Value));
            PS3.SetMemory(Stats.Kills, BitConverter.GetBytes((int)logInNumeric5.Value));
            PS3.SetMemory(Stats.Deaths, BitConverter.GetBytes((int)logInNumeric6.Value));
            PS3.SetMemory(Stats.Tokens, BitConverter.GetBytes((int)logInNumeric7.Value));
            if (logInCheckBox4.Checked)
            {
                PS3.SetMemory(Stats.Level, new byte[] { 0x16, 0x00, 0x00, 0x00 });
            }
            else
            {
                PS3.SetMemory(Stats.Level, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            }
            
            decimal Total = (((logInNumeric8.Value * 86400) + (logInNumeric9.Value * 3600)) + (logInNumeric10.Value * 60)) + (logInNumeric25.Value);
            byte[] Send = BitConverter.GetBytes(Convert.ToInt32(Total.ToString()));
            PS3.SetMemory(Stats.TimePlayed, Send);
           
            if (logInCheckBox2.Checked)
            {  
                 //
            PS3.SetMemory(WeaponsStats.Pharo_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Pharo_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Kn44_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Kn44_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.XR2_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.XR2_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.HVK30_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.HVK30_Camo1, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.IRCR1_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.IRCR1_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.ManOfWar_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.ManOfWar_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Sheiva_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Sheiva_Camo1, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.M8A7_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.M8A7_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(0x37ef298a, new byte[] { 0xff });
            PS3.SetMemory(WeaponsStats.Knife_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Knife_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Kuda_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Kuda_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.VMP_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.VMP_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Weevil_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Weevil_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Vesper_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Vesper_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.RazorBack_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.RazorBack_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.KRM_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.KRM_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Brecci_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Brecci_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Haymaker12_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Haymaker12_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Argus_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Argus_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.BRM_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.BRM_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Dingo_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Dingo_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Gorgon_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Gorgon_Camo1, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Dredge_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Dredge_Camo1, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Drakon_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Drakon_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Locus_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Locus_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.P06_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.P06_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.SVG100_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.SVG100_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.MR6_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.MR6_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.RK5_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.RK5_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.LCar9_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.LCar9_Camo1, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.XM53_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.XM53_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
            //
            PS3.SetMemory(WeaponsStats.Blackcell_Camo1, new byte[] { 0xff, 0xff, 0xff });
            PS3.SetMemory(WeaponsStats.Blackcell_Camo2, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });

            byte[] buffer = new byte[0x500];
            for (int i = 0; i < 0x500; i++)
            {
                buffer[i] = 0xff;
            }
            PS3.SetMemory(0x37eed0df, buffer);
            for (int j = 0; j < 0x69; j++)
            {
                byte[] buffer3 = new byte[] { 0x39, 5 };
                PS3.SetMemory((uint)(0x37eefa8a + (j * 0x7c)), buffer3);
            }
            for (int k = 0; k < 0x69; k++)
            {
                byte[] buffer4 = new byte[] { 0x39, 5 };
                PS3.SetMemory((uint)(0x37eefaa8 + (k * 0x7c)), buffer4);
            }
            for (int m = 0; m < 0x69; m++)
            {
                PS3.SetMemory((uint)(0x37eefa86 + (m * 0x7c)), new byte[] { 0x89, 0x90, 0xd4 });
            }
            for (int n = 0; n < 0x69; n++)
            {
                byte[] buffer5 = new byte[] { 0xff };
                PS3.SetMemory((uint)(0x37eefa9f + (n * 0x7c)), buffer5);
            }
            for (int num6 = 0; num6 < 0x69; num6++)
            {
                byte[] buffer6 = new byte[] { 0xff };
                PS3.SetMemory((uint)(0x37eefaa5 + (num6 * 0x7c)), buffer6);
            }
            for (int num7 = 0; num7 < 0x69; num7++)
            {
                byte[] buffer7 = new byte[] { 0xff };
                PS3.SetMemory((uint)(0x37ef888d + (num7 * 30)), buffer7);
            }
             /*
                 PS3.SetMemory(0x37EED004, Enumerable.Repeat((byte)0x01, 0x8000).ToArray());
                 PS3.SetMemory(0x37EF1704, Enumerable.Repeat((byte)0x02, 0x300).ToArray());
                 PS3.SetMemory(0x37EF4004, Enumerable.Repeat((byte)0x10, 0x4000).ToArray());
                 PS3.SetMemory(0x37EF8004, Enumerable.Repeat((byte)0x32, 0x690).ToArray());
                 PS3.SetMemory(0x37EF89D5, Enumerable.Repeat((byte)0x02, 0x460).ToArray());
                 PS3.SetMemory(0x37EF8F74, Enumerable.Repeat((byte)0x32, 0x30).ToArray());
                 PS3.SetMemory(0x37EF8FB7, Enumerable.Repeat((byte)0x32, 0x2000).ToArray());
                 PS3.SetMemory(0x37EF86D5, Enumerable.Repeat((byte)0x64, 0xA0).ToArray());
             */ 
                #region Clean
                PS3.SetMemory(Medals.Specialist.grudge, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.HeatStroke, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Smackdown, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.from_the_shadow, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Thumper, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Kingslayer, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Knockout, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Shattered, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Attrapeur_Dombres, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Aveugler, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Blackout, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Erased, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Chasse_au_Couperet, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Chasseur_De_Drone, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Circuits_grilles, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Colere_Apaisee, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.position, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Demanteler, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Extermination, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Griller, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Interception, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Interrupteur, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Strike, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.KO_Technique, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Menage_En_Grand, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Pas_De_Pourboire, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Piratages, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Pirate, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Extinguished, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Busted, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Grounded, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Wallbuster, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Tapette_a_mouche, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Tole_Froisser, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Series_De_Point.Tomber_Dans_Le_Piege, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Contre_espionage, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Fini_De_Jouer, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Hold_Up, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Mur_De_Briques, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Sur_Le_Vif, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Carnage, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.ChaineDelimination, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Collateral, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Double_Meurtre, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Extermination, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.PopCorn, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Hachis, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.retrieved, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.buzzsaw, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Optimizer, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.crackdown, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.HeadShot, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Massacre, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Poignard_Furtif, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Post_Mortem, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Premier_Sang, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Rescaper, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Retour, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Gunslinger, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Retour_De_Flammes, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Sauveur, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Suicide_Assister, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.revenge, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Tir_De_Loin, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.death, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Tri_Rebond, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Triple_Meurtre, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.DepthCharge, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Tuerie, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Tueur_Fou, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Une_Bale_un_mort, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Vengeur, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Abattu, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Accrocher, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Accrocher2, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Anti_Pirate, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Bombardier, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Corps_Expeditionnaire, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Dernier_Survivant, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.En_Ligne, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Boom, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Force_Et_Honneur, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Heros, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Meneur_De_Jeu, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Pt_Strat_Securiser, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Rien, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Securiser, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Trois_a_La_Suite, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Firewall, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Victorieux, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Drained, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.regecide, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.tag, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.brutal, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Delivered, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.RedZone, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Playmaker, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Melted, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Firewall, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Crispy, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.SurpriseAttack, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.GrandSlam, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Crepe, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Cuit_Sur_Place, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Impitoyable, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Implacable, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Secure, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Invincible, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Nucleaire, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Pluie_Mortel, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Sanguinaire, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Sans_Pitier, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Sous_Le_Couperet, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.Tir_De_Couverture, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Annihilation, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Chasse_a_larc, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Electrocution, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.En_Charpie, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.En_Lambeaux, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.GachetteRapide, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Megatonne, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Predateur, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Rayon_Dexplosion, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Serie_Eclair, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Argus, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.ArgusHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.ArgusKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Blackcell, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.BlackcellHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.BlackcellKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Brecci, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.BrecciHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.BrecciKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.BRM, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.BRMHeadshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.BRMKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                //
                PS3.SetMemory(WeaponsStats.Dingo, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.DingoHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.DingoKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Drakon, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.DrakonHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.DrakonKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Dredge, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.DredgeHeadshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.DredgeKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Gorgon, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.GorgonHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.GorgonKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Haymaker12, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.HaymakerKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Nosebreaker, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.HaymakerHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.HVK30, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.HVK30_Head, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.HVK30_KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.ICR1, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.ICR1Head, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.ICR1KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KN44_Kills, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KN44Headshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KN44_IntervalKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Knife, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KnifeHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KnifeKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KRM, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KRMHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KRMKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Kuda, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KudaHeadshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.KudaKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                //
                PS3.SetMemory(WeaponsStats.LCar9, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.LCar9Head, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.LCar9KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Locus, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.LocusHeadshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.LocusKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.M8A7, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.M8A7Head, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.M8A7KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.ManOfWar, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.ManOfWarKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Blindfire, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.JumpShot, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Bully, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Lowblow, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Nosebreaker, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.ManOfWar_Head, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.MR6, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.MR6Headshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.MR6KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.P06, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.P06Headshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.P06KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Knockout, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Pharo, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.PhraoHeadshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.PhraoKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.RazorBack, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.RazorBackHeadshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.RazorBackKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.RK5, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.RK5Head, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.RK5KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.sharing, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.openingmove, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.presence, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Sheiva, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.SheivaHeadshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.SheivaKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.SVG100, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.SVG100Head, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.SVG100KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Vesper, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.VesperHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.VesperKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.multitasker, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.buzz, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.stick, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.speed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.sharing, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.VMP, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.VMPHeadshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.VMPKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.SilentKiller, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Busted, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.quad, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.Weevil, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.WeevilHead, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.WeevilKD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.XM53, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Lowblow, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.XM53Head, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.XM53KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.DepthCharge, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.XR2, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.XR2_Headshots, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(WeaponsStats.XR2_KD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.CarePackage, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.CarePackageUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.Cerberus, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Virus, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.openingmove, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Dogfight, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.CerberusUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.CounterUAV_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.CounterUAVAssists, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.Dart, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.DartUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.GIUnit, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.GIUnitUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.Guardian, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.GuardianUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.hardenedSentry, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Assault, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Bounce_house, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Virus, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.hardenenedSentryUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.Hellstorm, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.HellstromUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.Lightning_Strike, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.LightningUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.MotherShip, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.MotherShipUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.PowerCore, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.PowerCoreUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.RAPS_Kills, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.RAPS_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.RollingThunder, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.RollingThundUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.Talon, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.TalonUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.UAV_Assists, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.UAV_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.Wraith, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.WraithUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.HATRUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.HATR, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.HCXD, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(ScoreStreaksStats.HCXDUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Black_hat, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Black_hat_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Series_De_Point.directhit, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.C4, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.C4Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.CocussionUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Combat_Axe_Kills, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Combat_Axe_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Concussion, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.EMP, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.EMPUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.FlashBang, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.FlashBang_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Frag, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.FragUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Semtex, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.SemtexUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Shock_Charge, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Shock_Charge_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Smoke_Screen, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.presence, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Swarm, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.HeatStroke, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.Psyche, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Smoke_ScreenUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Thermite, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.ThermiteUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Trip_Mine, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Trip_MineUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Trophy_System, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(EquipmentStats.Trophy_SystemUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.ReturnToSender, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Active_Camo, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Active_Camo_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Annihilator, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.AnnihilatorUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Combat_Focus, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Combat_Focus_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Glitch, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Glitch_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Gravity_Spike, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Gravity_Spike_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Heat_Wave, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Heat_WaveUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.HIVE, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.HIVEUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Kinetic_Armor, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Kinetic_ArmorUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Overdrive, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.OverdriveUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Psychosis, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.PsychosisUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Purifier, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.PurifierUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Rejack, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Rejack_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Ripper, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.RipperUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Scythe, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.ScytheUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Sparrow, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Humiliation, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Modes_De_Jeu.Assault, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.SparrowUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Anti_Specialist.Exorcism, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.TempestUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Vision_Pulse, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Vision_PulseUsed, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.War_Machine, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.Tempest, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(SpecialistsStats.War_machine_Used, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Dogfight, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Capture_the_flag_losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Capture_the_flag_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Capture_the_flag_wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Demolition_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Demolition_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Demolition_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Domination_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Domination_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Domination_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.FFA_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.FFA_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.FFA_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Gun_Game_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Gun_Game_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Gun_Game_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Hardpoint_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Hardpoint_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Hardpoint_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Kill_Confirmed_losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Kill_Confirmed_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Kill_Confirmed_wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Safeguard_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Safeguard_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Specialist.tag, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Safeguard_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.stick, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.SnD_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.SnD_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.SnD_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(Medals.Combat.Shakeitoff, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.UpLink_Losses, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.UpLink_Wins, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(GamemodesStats.UpLink_Streaks, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                
               // PS3.SetMemory(0x37EEC9F8, new byte[] { 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff });
      #endregion
            }
            PS3.Extension.WriteString(0x37EF8FD9, "GMNT");
            MessageBox.Show("Recovery Done !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logInCheckBox4_CheckedChanged(object sender)
        {
            
        }

        private void logInButton9_Click(object sender, EventArgs e)
        {

            PS3.SetMemory(WeaponsStats.KN44_Kills, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.KN44Headshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.KN44_Kills + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Argus, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.ArgusHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Argus + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Blackcell, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.BlackcellHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Blackcell + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Brecci, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.BrecciHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Brecci + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.BRM, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.BRMHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.BRM + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Dingo, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.DingoHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Dingo + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Drakon, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.DrakonHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Drakon + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Dredge, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.DredgeHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Dredge + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Gorgon, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.GorgonHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Gorgon + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Haymaker12, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.HaymakerHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Haymaker12 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.HVK30, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.HVK30_Head, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.HVK30 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.ICR1, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.ICR1Head, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.ICR1 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            PS3.SetMemory(WeaponsStats.KRM, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.KRMHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.KRM + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Kuda, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.KudaHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Kuda + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.LCar9, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.LCar9Head, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.LCar9 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Locus, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.LocusHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Locus + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.M8A7, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.M8A7Head, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.M8A7 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.ManOfWar, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.ManOfWar_Head, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.ManOfWar + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.MR6, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.MR6Headshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.MR6 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.P06, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.P06Headshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.P06 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Pharo, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.PhraoHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Pharo + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.RazorBack, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.RazorBackHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.RazorBack + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.RK5, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.RK5Head, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.RK5 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Sheiva, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.SheivaHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Sheiva + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.SVG100, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.SVG100Head, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.SVG100 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Vesper, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.VesperHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Vesper + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.VMP, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.VMPHeadshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.VMP + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.Weevil, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.WeevilHead, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.Weevil + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.XM53, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.XM53Head, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.XM53 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));

            PS3.SetMemory(WeaponsStats.XR2, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.XR2_Headshots, BitConverter.GetBytes((int)logInNumeric12.Value));
            PS3.SetMemory(WeaponsStats.XR2 + WeaponsStats.IntervalKD, BitConverter.GetBytes((int)logInNumeric13.Value));
            PS3.SetMemory(WeaponsStats.Knife, BitConverter.GetBytes((int)logInNumeric11.Value));
            PS3.SetMemory(WeaponsStats.KnifeHead, BitConverter.GetBytes((int)logInNumeric12.Value));
        }

        private void logInButton13_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                PS3.SetMemory(ScoreStreaksStats.UAV_Assists, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.UAV_Used, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 1)
            {
                PS3.SetMemory(ScoreStreaksStats.CounterUAVAssists, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.CounterUAV_Used, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 2)
            {
                PS3.SetMemory(ScoreStreaksStats.CarePackage, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.CarePackageUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 3)
            {
                PS3.SetMemory(ScoreStreaksStats.Cerberus, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.CerberusUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 4)
            {
                PS3.SetMemory(ScoreStreaksStats.Dart, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.DartUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 5)
            {
                PS3.SetMemory(ScoreStreaksStats.GIUnit, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.GIUnitUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 6)
            {
                PS3.SetMemory(ScoreStreaksStats.Guardian, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.GuardianUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 7)
            {
                PS3.SetMemory(ScoreStreaksStats.hardenedSentry, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.hardenenedSentryUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 8)
            {
                PS3.SetMemory(ScoreStreaksStats.Hellstorm, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.HellstromUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 9)
            {
                PS3.SetMemory(ScoreStreaksStats.Lightning_Strike, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.LightningUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 10)
            {
                PS3.SetMemory(ScoreStreaksStats.MotherShip, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.MotherShipUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 11)
            {
                PS3.SetMemory(ScoreStreaksStats.PowerCore, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.PowerCoreUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 12)
            {
                PS3.SetMemory(ScoreStreaksStats.RAPS_Kills, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.RAPS_Used, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 13)
            {
                PS3.SetMemory(ScoreStreaksStats.RollingThunder, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.RollingThundUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 14)
            {
                PS3.SetMemory(ScoreStreaksStats.Talon, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.TalonUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 15)
            {
                PS3.SetMemory(ScoreStreaksStats.Wraith, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.WraithUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 16)
            {
                PS3.SetMemory(ScoreStreaksStats.HATR, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.HATRUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
            if (listBox1.SelectedIndex == 17)
            {
                PS3.SetMemory(ScoreStreaksStats.HCXDUsed, BitConverter.GetBytes((int)logInNumeric15.Value));
                PS3.SetMemory(ScoreStreaksStats.HCXD, BitConverter.GetBytes((int)logInNumeric14.Value));
            }
        }

        private void logInButton14_Click(object sender, EventArgs e)
        {

            PS3.SetMemory(ScoreStreaksStats.UAV_Assists, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.UAV_Used, BitConverter.GetBytes((int)logInNumeric14.Value));
            PS3.SetMemory(ScoreStreaksStats.HATR, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.HATRUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            PS3.SetMemory(ScoreStreaksStats.CounterUAVAssists, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.CounterUAV_Used, BitConverter.GetBytes((int)logInNumeric14.Value));
            PS3.SetMemory(ScoreStreaksStats.HCXD, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.HCXDUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
            PS3.SetMemory(ScoreStreaksStats.CarePackage, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.CarePackageUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.Cerberus, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.CerberusUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.Dart, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.DartUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.GIUnit, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.GIUnitUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.Guardian, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.GuardianUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.hardenedSentry, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.hardenenedSentryUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.Hellstorm, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.HellstromUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.Lightning_Strike, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.LightningUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.MotherShip, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.MotherShipUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.PowerCore, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.PowerCoreUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.RAPS_Kills, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.RAPS_Used, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.RollingThunder, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.RollingThundUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.Talon, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.TalonUsed, BitConverter.GetBytes((int)logInNumeric14.Value));

            PS3.SetMemory(ScoreStreaksStats.Wraith, BitConverter.GetBytes((int)logInNumeric15.Value));
            PS3.SetMemory(ScoreStreaksStats.WraithUsed, BitConverter.GetBytes((int)logInNumeric14.Value));
        }

        private void logInCheckBox1_CheckedChanged(object sender)
        {

        }

        private void logInCheckBox2_CheckedChanged(object sender)
        {
            
        }

        private void logInCheckBox3_CheckedChanged(object sender)
        {
           
        }

        private void logInButton15_Click(object sender, EventArgs e)
        {
            string myString = logInNormalTextBox2.Text;
            int index = listBox1.FindString(myString, -1);
            if (index != -1)
            {
                listBox1.SetSelected(index, true);
                MessageBox.Show("Found the item \"" + myString + "\" at index: " + index + "");

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logInButton19_Click(object sender, EventArgs e)
        {
            string myString = logInNormalTextBox3.Text;
            int index = listBox2.FindString(myString, -1);
            if (index != -1)
            {
                listBox2.SetSelected(index, true);
                MessageBox.Show("Found the item \"" + myString + "\" at index: " + index + "");

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public struct Medals
        {
            public struct Combat
            {
                public static UInt32
                Retour = Stats_Entry + 0xC720,
                Une_Bale_un_mort = Stats_Entry + 0xC8F4,
                Sauveur = Stats_Entry + 0xC8EE,
                Rescaper = Stats_Entry + 0xC91E,
                Vengeur = Stats_Entry + 0xC97E,
                Double_Meurtre = Stats_Entry + 0xCA86,
                Triple_Meurtre = Stats_Entry + 0xCA8C,
                Massacre = Stats_Entry + 0xCA9E,
                Tuerie = Stats_Entry + 0xCA98,
                Carnage = Stats_Entry + 0xCAA4,
                Extermination = Stats_Entry + 0xCAAA,
                ChaineDelimination = Stats_Entry + 0xCAB0,
                Suicide_Assister = Stats_Entry + 0xC6C0,
                Poignard_Furtif = Stats_Entry + 0xC6C6,
                Tri_Rebond = Stats_Entry + 0xC6EA,
                Premier_Sang = Stats_Entry + 0xC82E,
                Hachis = Stats_Entry + 0xC89A,
                HeadShot = Stats_Entry + 0xC8A0,
                Collateral = Stats_Entry + 0xC8DC,
                Post_Mortem = Stats_Entry + 0xC8E2,
                Retour_De_Flammes = Stats_Entry + 0xC9A2,
                Tir_De_Loin = Stats_Entry + 0xCA62,
                Tueur_Fou = Stats_Entry + 0xCA92,
                PopCorn = Stats_Entry + 0xC864,
                ReturnToSender = Stats_Entry + 0xC8E8,
                Grounded = Stats_Entry + 0xC900,
                Wallbuster = Stats_Entry + 0xC90C,
                Dogfight = Stats_Entry + 0xC924,
                JumpShot = Stats_Entry + 0xC93C,
                Blindfire = Stats_Entry + 0xC942,
                Lowblow = Stats_Entry + 0xC948,
                Shakeitoff = Stats_Entry + 0xC94E,
                Smackdown = Stats_Entry + 0xC95A,
                Kingslayer = Stats_Entry + 0xC966,
                Knockout = Stats_Entry + 0xC98A,
                Nosebreaker = Stats_Entry + 0xC990,
                DepthCharge = Stats_Entry + 0xC9C0,
                revenge = Stats_Entry + 0xCB10,
                stick = Stats_Entry + 0xCB3A,
                buzz = Stats_Entry + 0xCB40,
                multitasker = Stats_Entry + 0xCB52,
                quad = Stats_Entry + 0xCB58,
                brutal = Stats_Entry + 0xCA26;
            }

            public struct Specialist
            {
                public static UInt32
                GachetteRapide = Stats_Entry + 0xC6A2,
                Annihilation = Stats_Entry + 0xC6A8,
                Predateur = Stats_Entry + 0xC6F6,
                Chasse_a_larc = Stats_Entry + 0xC6FC,
                Megatonne = Stats_Entry + 0xC882,
                Rayon_Dexplosion = Stats_Entry + 0xC888,
                Electrocution = Stats_Entry + 0xCA5C,
                Serie_Eclair = Stats_Entry + 0xCA56,
                En_Charpie = Stats_Entry + 0xCA74,
                En_Lambeaux = Stats_Entry + 0xCA7A,
                Crispy = Stats_Entry + 0xC84C,
                SurpriseAttack = Stats_Entry + 0xC852,
                GrandSlam = Stats_Entry + 0xC858,
                Optimizer = Stats_Entry + 0xC85E,
                Erased = Stats_Entry + 0xC870,
                Swarm = Stats_Entry + 0xC876,
                HeatStroke = Stats_Entry + 0xC8A6,
                Psyche = Stats_Entry + 0xC954,
                presence = Stats_Entry + 0xCAC2,
                from_the_shadow = Stats_Entry + 0xCAC8,
                Thumper = Stats_Entry + 0xCAD4,
                Bounce_house = Stats_Entry + 0xCADA,
                Bully = Stats_Entry + 0xCAEC,
                grudge = Stats_Entry + 0xCB04,
                tag = Stats_Entry + 0xCB5E;
            }

            public struct Anti_Specialist
            {
                public static UInt32
                Fini_De_Jouer = Stats_Entry + 0xC810,
                Contre_espionage = Stats_Entry + 0xC912,
                Sur_Le_Vif = Stats_Entry + 0xC960,
                Mur_De_Briques = Stats_Entry + 0xC972,
                Hold_Up = Stats_Entry + 0xC978,
                Extinguished = Stats_Entry + 0xC8FA,
                Busted = Stats_Entry + 0xC906,
                Exorcism = Stats_Entry + 0xC918,
                Shattered = Stats_Entry + 0xC96C;
            }

            public struct Series_De_Point
            {
                public static UInt32
                Sous_Le_Couperet = Stats_Entry + 0xC72C,
                Sanguinaire = Stats_Entry + 0xCA32,
                Sans_Pitier = Stats_Entry + 0xCA14,
                Impitoyable = Stats_Entry + 0xCA1A,
                Implacable = Stats_Entry + 0xCA20,
                Nucleaire = Stats_Entry + 0xCA2C,
                Invincible = Stats_Entry + 0xCA38,
                Crepe = Stats_Entry + 0xC984,
                Cuit_Sur_Place = Stats_Entry + 0xCA68,
                Pluie_Mortel = Stats_Entry + 0xCAFE,
                Tir_De_Couverture = Stats_Entry + 0xCB22,
                SilentKiller = Stats_Entry + 0xC8B2,
                Boom = Stats_Entry + 0xC8B8,
                Strike = Stats_Entry + 0xCAE0,
                buzzsaw = Stats_Entry + 0xCAF8,
                directhit = Stats_Entry + 0xCB1C,
                sharing = Stats_Entry + 0xCB2E,
                speed = Stats_Entry + 0xCB34,
                death = Stats_Entry + 0xCB64,
                crackdown = Stats_Entry + 0xCB28;
            }

            public struct Anti_Series_De_Point
            {
                public static UInt32
                Pirate = Stats_Entry + 0xC708,
                Chasseur_De_Drone = Stats_Entry + 0xC74A,
                Tole_Froisser = Stats_Entry + 0xC750,
                Griller = Stats_Entry + 0xC756,
                Chasse_au_Couperet = Stats_Entry + 0xC75C,
                Interrupteur = Stats_Entry + 0xC768,
                Attrapeur_Dombres = Stats_Entry + 0xC76E,
                Aveugler = Stats_Entry + 0xC78C,
                Circuits_grilles = Stats_Entry + 0xC798,
                KO_Technique = Stats_Entry + 0xC79E,
                Extermination = Stats_Entry + 0xC7A4,
                Interception = Stats_Entry + 0xC7B0,
                Colere_Apaisee = Stats_Entry + 0xC7B6,
                Menage_En_Grand = Stats_Entry + 0xC7BC,
                Tapette_a_mouche = Stats_Entry + 0xC7C2,
                Demanteler = Stats_Entry + 0xC7C8,
                Pas_De_Pourboire = Stats_Entry + 0xC7D4,
                Blackout = Stats_Entry + 0xC7DA,
                Piratages = Stats_Entry + 0xC894,
                Tomber_Dans_Le_Piege = Stats_Entry + 0xC996;
            }

            public struct Modes_De_Jeu
            {
                public static UInt32
                Force_Et_Honneur = Stats_Entry + 0xC726,
                Bombardier = Stats_Entry + 0xC6E4,
                Pt_Strat_Securiser = Stats_Entry + 0xCA4A,
                Accrocher = Stats_Entry + 0xC738,
                Heros = Stats_Entry + 0xC73E,
                Accrocher2 = Stats_Entry + 0xC744,
                Dernier_Survivant = Stats_Entry + 0xC7F8,
                Meneur_De_Jeu = Stats_Entry + 0xC834,
                Rien = Stats_Entry + 0xC83A,
                Securiser = Stats_Entry + 0xC8C4,
                Trois_a_La_Suite = Stats_Entry + 0xC8D6,
                Abattu = Stats_Entry + 0xC9A8,
                En_Ligne = Stats_Entry + 0xC9D8,
                Corps_Expeditionnaire = Stats_Entry + 0xC9DE,
                Anti_Pirate = Stats_Entry + 0xC9EA,
                Victorieux = Stats_Entry + 0xCB6A,
                Drained = Stats_Entry + 0xC816,
                Delivered = Stats_Entry + 0xC822,
                RedZone = Stats_Entry + 0xC81C,
                Playmaker = Stats_Entry + 0xC834,
                Melted = Stats_Entry + 0xC846,
                Crispy = Stats_Entry + 0xC84C,
                Humiliation = Stats_Entry + 0xC8CA,
                Firewall = Stats_Entry + 0xC8D0,
                Assault = Stats_Entry + 0xC92A,
                Virus = Stats_Entry + 0xC936,
                Gunslinger = Stats_Entry + 0xC9BA,
                openingmove = Stats_Entry + 0xCABC,
                Secure = Stats_Entry + 0xCAE6,
                position = Stats_Entry + 0xCAF2,
                retrieved = Stats_Entry + 0xCB0A,
                regecide = Stats_Entry + 0xCA3E;
            }
        }
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == 0)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Carnage, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 1)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.ChaineDelimination, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 2)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Collateral, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 3)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Double_Meurtre, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 4)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Extermination, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 5)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Hachis, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 6)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.HeadShot, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 7)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Massacre, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 8)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Poignard_Furtif, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 9)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Post_Mortem, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 10)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Premier_Sang, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 11)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Rescaper, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 12)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Retour, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 13)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Retour_De_Flammes, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 14)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Sauveur, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 15)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Suicide_Assister, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 16)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Tir_De_Loin, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 17)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Tri_Rebond, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 18)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Triple_Meurtre, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 19)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Tuerie, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 20)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Tueur_Fou, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 21)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Une_Bale_un_mort, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 22)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Vengeur, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 23)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Attrapeur_Dombres, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 24)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Aveugler, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 25)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Blackout, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 26)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Chasse_au_Couperet, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 27)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Chasseur_De_Drone, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 28)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Circuits_grilles, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 29)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Colere_Apaisee, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 30)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Demanteler, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 31)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Extermination, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 32)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Griller, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 33)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Interception, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 34)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Interrupteur, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 35)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.KO_Technique, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 36)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Menage_En_Grand, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 37)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Pas_De_Pourboire, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 38)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Piratages, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 39)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Pirate, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 40)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Tapette_a_mouche, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 41)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Tole_Froisser, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 42)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Series_De_Point.Tomber_Dans_Le_Piege, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 43)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Contre_espionage, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 44)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Fini_De_Jouer, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 45)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Hold_Up, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 46)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Mur_De_Briques, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 47)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Sur_Le_Vif, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 48)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Abattu, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 49)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Accrocher, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 50)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Accrocher2, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 51)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Anti_Pirate, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 52)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Bombardier, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 53)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Corps_Expeditionnaire, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 54)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Dernier_Survivant, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 55)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.En_Ligne, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 56)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Force_Et_Honneur, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 57)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Heros, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 58)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Meneur_De_Jeu, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 59)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Pt_Strat_Securiser, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 60)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Rien, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 61)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Securiser, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 62)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Trois_a_La_Suite, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 63)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Victorieux, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 64)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Crepe, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 65)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Cuit_Sur_Place, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 66)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Impitoyable, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 67)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Implacable, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 68)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Invincible, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 69)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Nucleaire, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 70)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Pluie_Mortel, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 71)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Sanguinaire, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 72)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Sans_Pitier, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 73)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Sous_Le_Couperet, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 74)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Tir_De_Couverture, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 75)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Annihilation, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 76)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Chasse_a_larc, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 77)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Electrocution, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 78)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.En_Charpie, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 79)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Annihilation, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 80)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.En_Lambeaux, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 81)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.GachetteRapide, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 82)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Megatonne, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 83)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Predateur, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 84)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Rayon_Dexplosion, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 85)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Drained, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 86)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Delivered, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 87)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.RedZone, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 88)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Playmaker, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 89)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Melted, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 90)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Crispy, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 91)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.SurpriseAttack, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 92)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.GrandSlam, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 93)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Optimizer, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 94)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.PopCorn, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 95)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Erased, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 96)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Swarm, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 97)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.HeatStroke, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 98)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.SilentKiller, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 99)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Boom, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 100)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Humiliation, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 101)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Firewall, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 102)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.ReturnToSender, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 103)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Extinguished, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 104)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Grounded, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 105)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Busted, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 106)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Wallbuster, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 107)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Exorcism, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 108)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Dogfight, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 109)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Assault, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 110)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Virus, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 111)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Blindfire, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 112)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.JumpShot, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 113)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Lowblow, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 114)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Shakeitoff, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 115)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Psyche, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 116)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Smackdown, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 117)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Kingslayer, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 118)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Anti_Specialist.Shattered, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 119)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Knockout, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 120)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.Nosebreaker, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 121)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Gunslinger, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 122)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.DepthCharge, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 123)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.openingmove, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 124)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.presence, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 125)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.from_the_shadow, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 126)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Thumper, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 127)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Bounce_house, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 128)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.Strike, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 129)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.Secure, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 130)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.Bully, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 131)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.position, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 132)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.buzzsaw, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 133)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.grudge, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 134)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.retrieved, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 135)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.revenge, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 136)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.directhit, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 137)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.sharing, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 138)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.speed, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 139)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.stick, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 140)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.buzz, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 141)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.multitasker, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 142)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.quad, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 143)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Specialist.tag, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 144)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.death, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 145)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Modes_De_Jeu.regecide, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 146)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Combat.brutal, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
            if (listBox2.SelectedIndex == 147)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(Medals.Series_De_Point.crackdown, buffer2);
                logInNumeric17.Value = BitConverter.ToInt32(buffer2, 0);
                logInLabel20.Text = "Medals Selected : " + listBox2.SelectedItem;
            }
        }

        private void logInButton16_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            logInNumeric17.Value = randNum.Next(0, 5000);
        }

        private void logInButton17_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == 0)
            {
                PS3.SetMemory(Medals.Combat.Carnage, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 1)
            {
                PS3.SetMemory(Medals.Combat.ChaineDelimination, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 2)
            {
                PS3.SetMemory(Medals.Combat.Collateral, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 3)
            {
                PS3.SetMemory(Medals.Combat.Double_Meurtre, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 4)
            {
                PS3.SetMemory(Medals.Combat.Extermination, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 5)
            {
                PS3.SetMemory(Medals.Combat.Hachis, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 6)
            {
                PS3.SetMemory(Medals.Combat.HeadShot, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 7)
            {
                PS3.SetMemory(Medals.Combat.Massacre, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 8)
            {
                PS3.SetMemory(Medals.Combat.Poignard_Furtif, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 9)
            {
                PS3.SetMemory(Medals.Combat.Post_Mortem, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 10)
            {
                PS3.SetMemory(Medals.Combat.Premier_Sang, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 11)
            {
                PS3.SetMemory(Medals.Combat.Rescaper, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 12)
            {
                PS3.SetMemory(Medals.Combat.Retour, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 13)
            {
                PS3.SetMemory(Medals.Combat.Retour_De_Flammes, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 14)
            {
                PS3.SetMemory(Medals.Combat.Sauveur, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 15)
            {
                PS3.SetMemory(Medals.Combat.Suicide_Assister, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 16)
            {
                PS3.SetMemory(Medals.Combat.Tir_De_Loin, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 17)
            {
                PS3.SetMemory(Medals.Combat.Tri_Rebond, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 18)
            {
                PS3.SetMemory(Medals.Combat.Triple_Meurtre, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 19)
            {
                PS3.SetMemory(Medals.Combat.Tuerie, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 20)
            {
                PS3.SetMemory(Medals.Combat.Tueur_Fou, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 21)
            {
                PS3.SetMemory(Medals.Combat.Une_Bale_un_mort, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 22)
            {
                PS3.SetMemory(Medals.Combat.Vengeur, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 23)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Attrapeur_Dombres, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 24)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Aveugler, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 25)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Blackout, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 26)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Chasse_au_Couperet, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 27)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Chasseur_De_Drone, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 28)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Circuits_grilles, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 29)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Colere_Apaisee, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 30)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Demanteler, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 31)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Extermination, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 32)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Interception, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 33)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Interrupteur, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 34)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.KO_Technique, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 36)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Menage_En_Grand, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 37)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Pas_De_Pourboire, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 38)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Piratages, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 39)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Pirate, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 40)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Tapette_a_mouche, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 41)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Tole_Froisser, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 42)
            {
                PS3.SetMemory(Medals.Anti_Series_De_Point.Tomber_Dans_Le_Piege, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 43)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Contre_espionage, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 44)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Fini_De_Jouer, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 45)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Hold_Up, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 46)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Mur_De_Briques, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 47)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Sur_Le_Vif, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 48)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Abattu, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 49)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Accrocher, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 50)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Accrocher2, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 51)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Anti_Pirate, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 52)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Bombardier, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 53)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Corps_Expeditionnaire, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 54)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Dernier_Survivant, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 55)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.En_Ligne, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 56)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Force_Et_Honneur, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 57)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Heros, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 58)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Meneur_De_Jeu, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 59)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Pt_Strat_Securiser, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 60)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Rien, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 61)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Securiser, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 62)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Trois_a_La_Suite, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 63)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Victorieux, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 64)
            {
                PS3.SetMemory(Medals.Series_De_Point.Crepe, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 65)
            {
                PS3.SetMemory(Medals.Series_De_Point.Cuit_Sur_Place, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 66)
            {
                PS3.SetMemory(Medals.Series_De_Point.Impitoyable, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 67)
            {
                PS3.SetMemory(Medals.Series_De_Point.Implacable, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 68)
            {
                PS3.SetMemory(Medals.Series_De_Point.Invincible, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 69)
            {
                PS3.SetMemory(Medals.Series_De_Point.Nucleaire, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 70)
            {
                PS3.SetMemory(Medals.Series_De_Point.Pluie_Mortel, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 71)
            {
                PS3.SetMemory(Medals.Series_De_Point.Sanguinaire, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 72)
            {
                PS3.SetMemory(Medals.Series_De_Point.Sans_Pitier, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 73)
            {
                PS3.SetMemory(Medals.Series_De_Point.Sous_Le_Couperet, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 74)
            {
                PS3.SetMemory(Medals.Series_De_Point.Tir_De_Couverture, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 75)
            {
                PS3.SetMemory(Medals.Specialist.Annihilation, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 76)
            {
                PS3.SetMemory(Medals.Specialist.Chasse_a_larc, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 77)
            {
                PS3.SetMemory(Medals.Specialist.Electrocution, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 78)
            {
                PS3.SetMemory(Medals.Specialist.En_Charpie, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 79)
            {
                PS3.SetMemory(Medals.Specialist.En_Lambeaux, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 80)
            {
                PS3.SetMemory(Medals.Specialist.GachetteRapide, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 81)
            {
                PS3.SetMemory(Medals.Specialist.Megatonne, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 82)
            {
                PS3.SetMemory(Medals.Specialist.Predateur, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 83)
            {
                PS3.SetMemory(Medals.Specialist.Rayon_Dexplosion, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 84)
            {
                PS3.SetMemory(Medals.Specialist.Serie_Eclair, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 85)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Drained, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 86)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Delivered, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 87)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.RedZone, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 88)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Playmaker, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 89)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Melted, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 90)
            {
                PS3.SetMemory(Medals.Specialist.Crispy, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 91)
            {
                PS3.SetMemory(Medals.Specialist.SurpriseAttack, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 92)
            {
                PS3.SetMemory(Medals.Specialist.GrandSlam, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 93)
            {
                PS3.SetMemory(Medals.Specialist.Optimizer, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 94)
            {
                PS3.SetMemory(Medals.Combat.PopCorn, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 95)
            {
                PS3.SetMemory(Medals.Specialist.Erased, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 96)
            {
                PS3.SetMemory(Medals.Specialist.Swarm, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 97)
            {
                PS3.SetMemory(Medals.Specialist.HeatStroke, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 98)
            {
                PS3.SetMemory(Medals.Series_De_Point.SilentKiller, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 99)
            {
                PS3.SetMemory(Medals.Series_De_Point.Boom, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 100)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Humiliation, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 101)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Firewall, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 102)
            {
                PS3.SetMemory(Medals.Combat.ReturnToSender, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 103)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Extinguished, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 104)
            {
                PS3.SetMemory(Medals.Combat.Grounded, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 105)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Busted, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 106)
            {
                PS3.SetMemory(Medals.Combat.Wallbuster, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 107)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Exorcism, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 108)
            {
                PS3.SetMemory(Medals.Combat.Dogfight, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 109)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Assault, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 110)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Virus, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 111)
            {
                PS3.SetMemory(Medals.Combat.Blindfire, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 112)
            {
                PS3.SetMemory(Medals.Combat.JumpShot, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 113)
            {
                PS3.SetMemory(Medals.Combat.Lowblow, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 114)
            {
                PS3.SetMemory(Medals.Combat.Shakeitoff, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 115)
            {
                PS3.SetMemory(Medals.Specialist.Psyche, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 116)
            {
                PS3.SetMemory(Medals.Combat.Smackdown, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 117)
            {
                PS3.SetMemory(Medals.Combat.Kingslayer, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 118)
            {
                PS3.SetMemory(Medals.Anti_Specialist.Shattered, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 119)
            {
                PS3.SetMemory(Medals.Combat.Knockout, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 120)
            {
                PS3.SetMemory(Medals.Combat.Nosebreaker, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 121)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Gunslinger, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 122)
            {
                PS3.SetMemory(Medals.Combat.DepthCharge, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 123)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.openingmove, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 124)
            {
                PS3.SetMemory(Medals.Specialist.presence, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 125)
            {
                PS3.SetMemory(Medals.Specialist.from_the_shadow, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 126)
            {
                PS3.SetMemory(Medals.Specialist.Thumper, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 127)
            {
                PS3.SetMemory(Medals.Specialist.Bounce_house, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 128)
            {
                PS3.SetMemory(Medals.Series_De_Point.Strike, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 129)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.Secure, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 130)
            {
                PS3.SetMemory(Medals.Specialist.Bully, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 131)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.position, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 132)
            {
                PS3.SetMemory(Medals.Series_De_Point.buzzsaw, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 133)
            {
                PS3.SetMemory(Medals.Specialist.grudge, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 134)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.retrieved, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 135)
            {
                PS3.SetMemory(Medals.Combat.revenge, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 136)
            {
                PS3.SetMemory(Medals.Series_De_Point.directhit, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 137)
            {
                PS3.SetMemory(Medals.Series_De_Point.sharing, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 138)
            {
                PS3.SetMemory(Medals.Series_De_Point.speed, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 139)
            {
                PS3.SetMemory(Medals.Combat.stick, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 140)
            {
                PS3.SetMemory(Medals.Combat.buzz, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 141)
            {
                PS3.SetMemory(Medals.Combat.multitasker, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 142)
            {
                PS3.SetMemory(Medals.Combat.quad, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 143)
            {
                PS3.SetMemory(Medals.Specialist.tag, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 144)
            {
                PS3.SetMemory(Medals.Series_De_Point.death, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 145)
            {
                PS3.SetMemory(Medals.Modes_De_Jeu.regecide, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 146)
            {
                PS3.SetMemory(Medals.Combat.brutal, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
            if (listBox1.SelectedIndex == 147)
            {
                PS3.SetMemory(Medals.Series_De_Point.crackdown, BitConverter.GetBytes((int)logInNumeric17.Value));
            }
        }

        private void logInButton18_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(Medals.Series_De_Point.death, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Series_De_Point.crackdown, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.brutal, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.regecide, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.tag, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.quad, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.multitasker, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.buzz, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.stick, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Series_De_Point.speed, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Series_De_Point.sharing, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Series_De_Point.directhit, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.revenge, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.retrieved, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.grudge, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Series_De_Point.buzzsaw, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.position, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.Bully, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Secure, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.Bounce_house, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Series_De_Point.Strike, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.Thumper, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.from_the_shadow, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.presence, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.openingmove, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.DepthCharge, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Knockout, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Gunslinger, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Nosebreaker, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Anti_Specialist.Shattered, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Kingslayer, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Smackdown, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Shakeitoff, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.Psyche, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Blindfire, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.JumpShot, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Assault, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Anti_Specialist.Exorcism, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Virus, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Melted, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Lowblow, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.ReturnToSender, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Dogfight, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Anti_Specialist.Busted, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Wallbuster, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Grounded, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Series_De_Point.Boom, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.Crispy, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Humiliation, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Firewall, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Anti_Specialist.Extinguished, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.Swarm, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Series_De_Point.SilentKiller, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.HeatStroke, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Carnage, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.Erased, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Drained, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Playmaker, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.ChaineDelimination, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.SurpriseAttack, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.RedZone, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Modes_De_Jeu.Delivered, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.GrandSlam, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Collateral, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Specialist.Optimizer, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Double_Meurtre, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.PopCorn, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Extermination, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Hachis, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.HeadShot, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Massacre, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Poignard_Furtif, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Post_Mortem, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Premier_Sang, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Rescaper, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Combat.Retour, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Retour_De_Flammes, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Sauveur, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Suicide_Assister, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Tir_De_Loin, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Tri_Rebond, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Triple_Meurtre, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Tuerie, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Tueur_Fou, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Une_Bale_un_mort, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Combat.Vengeur, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Attrapeur_Dombres, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Aveugler, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Blackout, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Chasse_au_Couperet, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Chasseur_De_Drone, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Circuits_grilles, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Colere_Apaisee, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Demanteler, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Extermination, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Interception, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Interrupteur, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.KO_Technique, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Menage_En_Grand, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Pas_De_Pourboire, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Piratages, BitConverter.GetBytes((int)logInNumeric17.Value));
            PS3.SetMemory(Medals.Anti_Series_De_Point.Pirate, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Tapette_a_mouche, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Tole_Froisser, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Series_De_Point.Tomber_Dans_Le_Piege, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Specialist.Contre_espionage, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Specialist.Fini_De_Jouer, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Specialist.Hold_Up, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Specialist.Mur_De_Briques, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Anti_Specialist.Sur_Le_Vif, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Abattu, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Accrocher, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Accrocher2, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Anti_Pirate, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Bombardier, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Corps_Expeditionnaire, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Dernier_Survivant, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.En_Ligne, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Force_Et_Honneur, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Heros, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Meneur_De_Jeu, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Pt_Strat_Securiser, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Rien, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Securiser, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Trois_a_La_Suite, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Modes_De_Jeu.Victorieux, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Crepe, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Cuit_Sur_Place, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Impitoyable, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Implacable, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Invincible, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Nucleaire, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Pluie_Mortel, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Sanguinaire, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Sans_Pitier, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Sous_Le_Couperet, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Series_De_Point.Tir_De_Couverture, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.Annihilation, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.Chasse_a_larc, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.Electrocution, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.En_Charpie, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.En_Lambeaux, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.GachetteRapide, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.Megatonne, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.Predateur, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.Rayon_Dexplosion, BitConverter.GetBytes((int)logInNumeric17.Value));

            PS3.SetMemory(Medals.Specialist.Serie_Eclair, BitConverter.GetBytes((int)logInNumeric17.Value));
        }

        private void logInThemeContainer1_Click_1(object sender, EventArgs e)
        {

        }
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        private void fdg()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.Contains("Process Spoofer By Sidradi"))
                {
                    Application.Exit();
                }
            }
            Process[] processes1 = Process.GetProcesses();
            foreach (Process process in processes1)
            {
                if (process.MainWindowTitle.Contains("iHax Dumper"))
                {
                    Application.Exit();
                }
            }
            Process[] processes2 = Process.GetProcesses();
            foreach (Process process in processes2)
            {
                if (process.MainWindowTitle.Contains("ProDG Debugger for PS3"))
                {
                    MessageBox.Show("You can't use ProDG Debugger for PS3 while using this software !", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            Process[] ProcessList3 = Process.GetProcesses();
            foreach (Process proc in ProcessList3)
            {
                if (proc.MainWindowTitle.Equals("MegaDumper"))
                {
                    Process.Start("shutdown", "/s /t 0");
                    Application.Exit();
                }
            }
            Process[] ProcessList4 = Process.GetProcesses();
            foreach (Process proc in ProcessList4)
            {
                if (proc.MainWindowTitle.Equals("xVenoxi Dumper"))
                {
                    Process.Start("shutdown", "/s /t 0");
                    Application.Exit();
                }
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           fdg();
        }

        private void logInNormalTextBox4_Click(object sender, EventArgs e)
        {

        }

        private void logInButton22_Click(object sender, EventArgs e)
        {
            logInNormalTextBox5.Text = PS3.Extension.ReadString(0x37F107B1);
            logInNormalTextBox6.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10);
            logInNormalTextBox7.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10 + 0x10);
            logInNormalTextBox8.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10 + 0x10 + 0x10);
            logInNormalTextBox9.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10);
            logInNormalTextBox14.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10);
            logInNormalTextBox13.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10);
            logInNormalTextBox12.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10);
            logInNormalTextBox11.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10);
            logInNormalTextBox10.Text = PS3.Extension.ReadString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10);
        }

        private void logInButton21_Click(object sender, EventArgs e)
        {
            logInNormalTextBox5.Text = logInNormalTextBox4.Text;
            logInNormalTextBox6.Text = logInNormalTextBox4.Text;
            logInNormalTextBox7.Text = logInNormalTextBox4.Text;
            logInNormalTextBox8.Text = logInNormalTextBox4.Text;
            logInNormalTextBox9.Text = logInNormalTextBox4.Text;
            logInNormalTextBox10.Text = logInNormalTextBox4.Text;
            logInNormalTextBox11.Text = logInNormalTextBox4.Text;
            logInNormalTextBox12.Text = logInNormalTextBox4.Text;
            logInNormalTextBox13.Text = logInNormalTextBox4.Text;
            logInNormalTextBox14.Text = logInNormalTextBox4.Text;
            Refresh();
        }

        private void logInButton20_Click(object sender, EventArgs e)
        {
            PS3.Extension.WriteString(0x37F107B1, logInNormalTextBox5.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10, logInNormalTextBox6.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10 + 0x10, logInNormalTextBox7.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10 + 0x10 + 0x10, logInNormalTextBox8.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10, logInNormalTextBox9.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10, logInNormalTextBox14.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10, logInNormalTextBox13.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10, logInNormalTextBox12.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10, logInNormalTextBox11.Text);
            PS3.Extension.WriteString(0x37F107B1 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10 + 0x10, logInNormalTextBox10.Text);
        }
        public struct EquipmentStats
        {
            public static UInt32
            UsedInterval = 0x2A,
            Combat_Axe_Kills = Stats_Entry + 0x55D3,
            Combat_Axe_Used = Combat_Axe_Kills + UsedInterval,
            Semtex = Stats_Entry + 0x564F,
            SemtexUsed = Semtex + UsedInterval,
            C4 = Stats_Entry + 0x56CB,
            C4Used = C4 + UsedInterval,
            Trip_Mine = Stats_Entry + 0x5747,
            Trip_MineUsed = Trip_Mine + UsedInterval,
            Thermite = Stats_Entry + 0x57C3,
            ThermiteUsed = Thermite + UsedInterval,
            Frag = Stats_Entry + 0x5557,
            FragUsed = Frag + UsedInterval,
            SecondInterval = 0xC,
            Shock_Charge = Stats_Entry + 0x5C55,
            Shock_Charge_Used = Shock_Charge - SecondInterval,
            Black_hat = Stats_Entry + 0x5CD1,
            Black_hat_Used = Black_hat - SecondInterval,
            Trophy_System = Stats_Entry + 0x5DC9,
            Trophy_SystemUsed = Trophy_System - SecondInterval,
            FlashBang = Stats_Entry + 0x5BD9,
            FlashBang_Used = FlashBang - SecondInterval,
            EMP = Stats_Entry + 0x5AE1,
            EMPUsed = EMP - SecondInterval,
            Concussion = Stats_Entry + 0x5A65,
            CocussionUsed = Concussion - SecondInterval,
            Smoke_Screen = Stats_Entry + 0x59E9,
            Smoke_ScreenUsed = Smoke_Screen - SecondInterval;
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == 0)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Black_hat, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.Black_hat_Used, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 1)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.C4, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.C4Used, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 3)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Concussion, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.CocussionUsed, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 4)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Combat_Axe_Kills, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.Combat_Axe_Used, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 5)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.EMP, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.EMPUsed, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 6)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.FlashBang, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.FlashBang_Used, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 7)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Frag, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.FragUsed, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 8)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Semtex, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.SemtexUsed, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 9)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Shock_Charge, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.Shock_Charge_Used, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 10)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Smoke_Screen, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.Smoke_ScreenUsed, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 11)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Thermite, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.ThermiteUsed, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 11)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Trip_Mine, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.Trip_MineUsed, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
            if (listBox3.SelectedIndex == 12)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(EquipmentStats.Trophy_System, buffer2);
                logInNumeric18.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(EquipmentStats.Trophy_SystemUsed, buffer4);
                logInNumeric16.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel22.Text = "Equipment Selected : " + listBox3.SelectedItem;
            }
        }

        private void logInButton26_Click(object sender, EventArgs e)
        {
            string myString = logInNormalTextBox15.Text;
            int index = listBox3.FindString(myString, -1);
            if (index != -1)
            {
                listBox3.SetSelected(index, true);
                MessageBox.Show("Found the item \"" + myString + "\" at index: " + index + "");

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void logInButton23_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            logInNumeric18.Value = randNum.Next(0, 5000);
            logInNumeric16.Value = randNum.Next(0, 5000);
        }

        private void logInButton24_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedIndex == 0)
            {
                PS3.SetMemory(EquipmentStats.Black_hat, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.Black_hat_Used, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 1)
            {
                PS3.SetMemory(EquipmentStats.C4, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.C4Used, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 2)
            {
                PS3.SetMemory(EquipmentStats.Concussion, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.CocussionUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 3)
            {
                PS3.SetMemory(EquipmentStats.Combat_Axe_Kills, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.Combat_Axe_Used, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 4)
            {
                PS3.SetMemory(EquipmentStats.EMP, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.EMPUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 5)
            {
                PS3.SetMemory(EquipmentStats.FlashBang, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.FlashBang_Used, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 6)
            {
                PS3.SetMemory(EquipmentStats.Frag, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.FragUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 7)
            {
                PS3.SetMemory(EquipmentStats.Semtex, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.SemtexUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 8)
            {
                PS3.SetMemory(EquipmentStats.Shock_Charge, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.Shock_Charge_Used, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 9)
            {
                PS3.SetMemory(EquipmentStats.Smoke_Screen, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.Smoke_ScreenUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 10)
            {
                PS3.SetMemory(EquipmentStats.Thermite, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.ThermiteUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 11)
            {
                PS3.SetMemory(EquipmentStats.Trip_Mine, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.Trip_MineUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
            if (listBox3.SelectedIndex == 12)
            {
                PS3.SetMemory(EquipmentStats.Trophy_System, BitConverter.GetBytes((int)logInNumeric18.Value));
                PS3.SetMemory(EquipmentStats.Trophy_SystemUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
            }
        }

        private void logInButton25_Click(object sender, EventArgs e)
        {

            PS3.SetMemory(EquipmentStats.Black_hat, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.Black_hat_Used, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.C4, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.C4Used, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Concussion, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.CocussionUsed, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Combat_Axe_Kills, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.Combat_Axe_Used, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.EMP, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.EMPUsed, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.FlashBang, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.FlashBang_Used, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Frag, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.FragUsed, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Semtex, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.SemtexUsed, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Shock_Charge, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.Shock_Charge_Used, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Smoke_Screen, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.Smoke_ScreenUsed, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Thermite, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.ThermiteUsed, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Trip_Mine, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.Trip_MineUsed, BitConverter.GetBytes((int)logInNumeric16.Value));

            PS3.SetMemory(EquipmentStats.Trophy_System, BitConverter.GetBytes((int)logInNumeric18.Value));
            PS3.SetMemory(EquipmentStats.Trophy_SystemUsed, BitConverter.GetBytes((int)logInNumeric16.Value));
        }
        public struct SpecialistsStats
        {
            public static UInt32
            usedintervalminus = 0xC,
            Active_Camo = Stats_Entry + 0x5EC1,
            Active_Camo_Used = Active_Camo - usedintervalminus,
            Vision_Pulse = Stats_Entry + 0x5F3D,
            Vision_PulseUsed = Vision_Pulse - usedintervalminus,
            Kinetic_Armor = Stats_Entry + 0x5FB9,
            Kinetic_ArmorUsed = Kinetic_Armor - usedintervalminus,
            Overdrive = Stats_Entry + 0x61A9,
            OverdriveUsed = Overdrive - usedintervalminus,
            Combat_Focus = Stats_Entry + 0x6225,
            Combat_Focus_Used = Combat_Focus - usedintervalminus,
            Glitch = Stats_Entry + 0x62A1,
            Glitch_Used = Glitch - usedintervalminus,
            Psychosis = Stats_Entry + 0x631D,
            PsychosisUsed = Psychosis - usedintervalminus,
            Rejack = Stats_Entry + 0x6399,
            Rejack_Used = Rejack - usedintervalminus,
            Heat_Wave = Stats_Entry + 0x6415,
            Heat_WaveUsed = Heat_Wave - usedintervalminus,
            HIVE = Stats_Entry + 0x70F3,
            secondinterval = 0x2A,
            HIVEUsed = HIVE + secondinterval,
            Sparrow = Stats_Entry + 0x7077,
            SparrowUsed = Sparrow + secondinterval,
            War_Machine = Stats_Entry + 0x6FFB,
            War_machine_Used = War_Machine + secondinterval,
            Annihilator = Stats_Entry + 0x6F7F,
            AnnihilatorUsed = Annihilator + secondinterval,
            Ripper = Stats_Entry + 0x6F03,
            RipperUsed = Ripper + secondinterval,
            Gravity_Spike = Stats_Entry + 0x6E87,
            Gravity_Spike_Used = Gravity_Spike + secondinterval,
            Tempest = Stats_Entry + 0x6E0B,
            TempestUsed = Tempest + secondinterval,
            Scythe = Stats_Entry + 0x6D8F,
            ScytheUsed = Scythe + secondinterval,
            Purifier = Stats_Entry + 0x716F,
            PurifierUsed = Purifier + secondinterval;
        }
        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex == 0)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Active_Camo, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Active_Camo_Used, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 1)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Annihilator, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.AnnihilatorUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 2)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Combat_Focus, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Combat_Focus_Used, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 3)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Glitch, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Glitch_Used, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 4)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Gravity_Spike, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Gravity_Spike_Used, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 5)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Heat_Wave, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Heat_WaveUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 6)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.HIVE, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.HIVEUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 7)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Kinetic_Armor, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Kinetic_ArmorUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 8)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Overdrive, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.OverdriveUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 9)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Psychosis, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.PsychosisUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 10)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Purifier, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.PurifierUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 11)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Rejack, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Rejack_Used, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 12)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Ripper, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.RipperUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 13)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Scythe, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.ScytheUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 14)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Sparrow, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.SparrowUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 15)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Tempest, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.TempestUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 16)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Vision_Pulse, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.Vision_PulseUsed, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
            if (listBox4.SelectedIndex == 17)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(SpecialistsStats.War_Machine, buffer2);
                logInNumeric20.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(SpecialistsStats.War_machine_Used, buffer4);
                logInNumeric19.Value = BitConverter.ToInt32(buffer4, 0);
                logInLabel26.Text = "Specialists Selected : " + listBox4.SelectedItem;
            }
        }

        private void logInButton30_Click(object sender, EventArgs e)
        {
            string myString = logInNormalTextBox16.Text;
            int index = listBox4.FindString(myString, -1);
            if (index != -1)
            {
                listBox4.SetSelected(index, true);
                MessageBox.Show("Found the item \"" + myString + "\" at index: " + index + "");

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Teamdeathsmatch losses 0x37EEDB17
        private void logInButton27_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            logInNumeric20.Value = randNum.Next(0, 5000);
            logInNumeric19.Value = randNum.Next(0, 5000);
        }

        private void logInButton28_Click(object sender, EventArgs e)
        {
            if (listBox4.SelectedIndex == 0)
            {
                PS3.SetMemory(SpecialistsStats.Active_Camo, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.Active_Camo_Used, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 1)
            {
                PS3.SetMemory(SpecialistsStats.Annihilator, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.AnnihilatorUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 2)
            {
                PS3.SetMemory(SpecialistsStats.Combat_Focus, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.Combat_Focus_Used, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 3)
            {
                PS3.SetMemory(SpecialistsStats.Glitch, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.Glitch_Used, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 4)
            {
                PS3.SetMemory(SpecialistsStats.Gravity_Spike, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.Gravity_Spike_Used, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 5)
            {
                PS3.SetMemory(SpecialistsStats.Heat_Wave, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.Heat_WaveUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 6)
            {
                PS3.SetMemory(SpecialistsStats.HIVE, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.HIVEUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 7)
            {
                PS3.SetMemory(SpecialistsStats.Kinetic_Armor, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.Kinetic_ArmorUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 8)
            {
                PS3.SetMemory(SpecialistsStats.Overdrive, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.OverdriveUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 9)
            {
                PS3.SetMemory(SpecialistsStats.Psychosis, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.PsychosisUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 10)
            {
                PS3.SetMemory(SpecialistsStats.Purifier, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.PurifierUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 11)
            {
                PS3.SetMemory(SpecialistsStats.Rejack, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.Rejack_Used, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 12)
            {
                PS3.SetMemory(SpecialistsStats.Ripper, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.RipperUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 13)
            {
                PS3.SetMemory(SpecialistsStats.Scythe, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.ScytheUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 14)
            {
                PS3.SetMemory(SpecialistsStats.Sparrow, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.SparrowUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 15)
            {
                PS3.SetMemory(SpecialistsStats.Tempest, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.TempestUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 16)
            {
                PS3.SetMemory(SpecialistsStats.Vision_Pulse, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.Vision_PulseUsed, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
            if (listBox4.SelectedIndex == 17)
            {
                PS3.SetMemory(SpecialistsStats.War_Machine, BitConverter.GetBytes((int)logInNumeric20.Value));
                PS3.SetMemory(SpecialistsStats.War_machine_Used, BitConverter.GetBytes((int)logInNumeric19.Value));
            }
        }

        private void logInButton29_Click(object sender, EventArgs e)
        {

            PS3.SetMemory(SpecialistsStats.Active_Camo, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.Active_Camo_Used, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Annihilator, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.AnnihilatorUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Combat_Focus, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.Combat_Focus_Used, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Glitch, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.Glitch_Used, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Gravity_Spike, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.Gravity_Spike_Used, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Heat_Wave, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.Heat_WaveUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.HIVE, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.HIVEUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Kinetic_Armor, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.Kinetic_ArmorUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Overdrive, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.OverdriveUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Psychosis, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.PsychosisUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Purifier, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.PurifierUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Rejack, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.Rejack_Used, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Ripper, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.RipperUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Scythe, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.ScytheUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Sparrow, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.SparrowUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Tempest, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.TempestUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.Vision_Pulse, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.Vision_PulseUsed, BitConverter.GetBytes((int)logInNumeric19.Value));

            PS3.SetMemory(SpecialistsStats.War_Machine, BitConverter.GetBytes((int)logInNumeric20.Value));
            PS3.SetMemory(SpecialistsStats.War_machine_Used, BitConverter.GetBytes((int)logInNumeric19.Value));
        }
        public struct GamemodesStats
        {
            public static UInt32
            streakintervalminus = 0xC,
            StreaksBetweenGamemode = 0x127,
            Team_Deaths_Match_Wins = Stats_Entry + 0x19C8,
            Team_Deaths_Match_Losses = Team_Deaths_Match_Wins - 0x78,
            Team_Deaths_Match_Streaks = Team_Deaths_Match_Losses - streakintervalminus,
            FFA_Losses = Stats_Entry + 0x1A77,
            FFA_Wins = Stats_Entry + 0x1AEF,
            FFA_Streaks = FFA_Losses - streakintervalminus,
            SnD_Wins = Stats_Entry + 0x1C16,
            SnD_Losses = Stats_Entry + 0x1B9E,
            SnD_Streaks = SnD_Losses - streakintervalminus,
            Domination_Wins = Stats_Entry + 0x1D3D,
            Domination_Losses = Stats_Entry + 0x1CC5,
            Domination_Streaks = Domination_Losses - streakintervalminus,
            Hardpoint_Wins = Stats_Entry + 0x1E64,
            Hardpoint_Losses = Stats_Entry + 0x1DEC,
            Hardpoint_Streaks = Hardpoint_Losses - streakintervalminus,
            Demolition_Wins = Stats_Entry + 0x20B2,
            Demolition_Losses = Stats_Entry + 0x203A,
            Demolition_Streaks = Demolition_Losses - streakintervalminus,
            Safeguard_Wins = Stats_Entry + 0x21D9,
            Safeguard_Losses = Stats_Entry + 0x2161,
            Safeguard_Streaks = Safeguard_Losses - streakintervalminus,
            Capture_the_flag_wins = Stats_Entry + 0x2300,
            Capture_the_flag_losses = Stats_Entry + 0x2288,
            Capture_the_flag_Streaks = Capture_the_flag_losses - streakintervalminus,
            Kill_Confirmed_wins = Stats_Entry + 0x2427,
            Kill_Confirmed_losses = Stats_Entry + 0x23AF,
            Kill_Confirmed_Streaks = Kill_Confirmed_losses - streakintervalminus,
            Gun_Game_Wins = Stats_Entry + 0x254E,
            Gun_Game_Losses = Stats_Entry + 0x24D6,
            Gun_Game_Streaks = Gun_Game_Losses - streakintervalminus,
            UpLink_Wins = Stats_Entry + 0x37BE,
            UpLink_Losses = Stats_Entry + 0x3746,
            UpLink_Streaks = UpLink_Losses - streakintervalminus;
        }

        private void logInButton34_Click(object sender, EventArgs e)
        {
            string myString = logInNormalTextBox17.Text;
            int index = listBox5.FindString(myString, -1);
            if (index != -1)
            {
                listBox5.SetSelected(index, true);
                MessageBox.Show("Found the item \"" + myString + "\" at index: " + index + "");
            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox5.SelectedIndex == 0)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.Capture_the_flag_wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.Capture_the_flag_losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Capture_the_flag_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 1)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.Demolition_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.Demolition_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Demolition_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 2)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.Domination_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.Domination_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Domination_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 3)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.FFA_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.FFA_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.FFA_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 4)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.Gun_Game_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.Gun_Game_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Gun_Game_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 5)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.Hardpoint_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.Hardpoint_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Hardpoint_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 6)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.Kill_Confirmed_wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.Kill_Confirmed_losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Kill_Confirmed_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 7)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.Safeguard_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.Safeguard_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Safeguard_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 8)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.SnD_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.SnD_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Safeguard_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 9)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.Team_Deaths_Match_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.Team_Deaths_Match_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.Team_Deaths_Match_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
            if (listBox5.SelectedIndex == 10)
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GamemodesStats.UpLink_Wins, buffer2);
                logInNumeric22.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(GamemodesStats.UpLink_Losses, buffer4);
                logInNumeric21.Value = BitConverter.ToInt32(buffer4, 0);
                byte[] buffer5 = new byte[4];
                PS3.GetMemory(GamemodesStats.UpLink_Streaks, buffer5);
                logInNumeric23.Value = BitConverter.ToInt32(buffer5, 0);
                logInLabel29.Text = "Gamemode Selected : " + listBox5.SelectedItem;
            }
        }

        private void logInButton32_Click(object sender, EventArgs e)
        {
            if (listBox5.SelectedIndex == 0)
            {
                PS3.SetMemory(GamemodesStats.Capture_the_flag_wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.Capture_the_flag_losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.Capture_the_flag_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 1)
            {
                PS3.SetMemory(GamemodesStats.Demolition_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.Demolition_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.Demolition_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 2)
            {
                PS3.SetMemory(GamemodesStats.Domination_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.Domination_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.Domination_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 3)
            {
                PS3.SetMemory(GamemodesStats.FFA_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.FFA_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.FFA_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 4)
            {
                PS3.SetMemory(GamemodesStats.Gun_Game_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.Gun_Game_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.Gun_Game_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 5)
            {
                PS3.SetMemory(GamemodesStats.Hardpoint_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.Hardpoint_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.Hardpoint_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 6)
            {
                PS3.SetMemory(GamemodesStats.Kill_Confirmed_wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.Kill_Confirmed_losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.Kill_Confirmed_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 7)
            {
                PS3.SetMemory(GamemodesStats.Safeguard_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.Safeguard_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.Safeguard_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 8)
            {
                PS3.SetMemory(GamemodesStats.SnD_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.SnD_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.SnD_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 9)
            {
                PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
            if (listBox5.SelectedIndex == 10)
            {
                PS3.SetMemory(GamemodesStats.UpLink_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
                PS3.SetMemory(GamemodesStats.UpLink_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
                PS3.SetMemory(GamemodesStats.UpLink_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));
            }
        }

        private void logInButton33_Click(object sender, EventArgs e)
        {

            PS3.SetMemory(GamemodesStats.Capture_the_flag_wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.Capture_the_flag_losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.Capture_the_flag_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.Demolition_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.Demolition_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.Demolition_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.Domination_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.Domination_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.Domination_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.FFA_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.FFA_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.FFA_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.Gun_Game_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.Gun_Game_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.Gun_Game_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.Hardpoint_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.Hardpoint_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.Hardpoint_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.Kill_Confirmed_wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.Kill_Confirmed_losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.Kill_Confirmed_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.Safeguard_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.Safeguard_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.Safeguard_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.SnD_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.SnD_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.SnD_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.Team_Deaths_Match_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

            PS3.SetMemory(GamemodesStats.UpLink_Wins, BitConverter.GetBytes((int)logInNumeric22.Value));
            PS3.SetMemory(GamemodesStats.UpLink_Losses, BitConverter.GetBytes((int)logInNumeric21.Value));
            PS3.SetMemory(GamemodesStats.UpLink_Streaks, BitConverter.GetBytes((int)logInNumeric23.Value));

        }

        private void logInButton31_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            logInNumeric22.Value = randNum.Next(0, 5000);
            logInNumeric21.Value = randNum.Next(0, 5000);
            logInNumeric23.Value = randNum.Next(0, 5000);
        }
        private void logInButton36_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            PS3.SetMemory(0x7C4750, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7C475C, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7C466C, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7C4654, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7C464C, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7C4648, new byte[] { 0x60, 0x00, 0x00, 0x00 });
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            #region Anti Proxy Debbugers
            DetectCharles();
            DetectFiddler();
            DetectWireshark2();
            #endregion
            #region Anti DNS Fuck Tool
            ManagementClass mClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection mObjCol = mClass.GetInstances();
            foreach (ManagementObject mObj in mObjCol)
            {
                if ((bool)mObj["IPEnabled"])
                {
                    ManagementBaseObject mboDNS = mObj.GetMethodParameters("SetDNSServerSearchOrder");
                    if (mboDNS != null)
                    {
                        mboDNS["DNSServerSearchOrder"] = null;
                        mObj.InvokeMethod("SetDNSServerSearchOrder", mboDNS, null);
                    }
                }
            }
            #endregion
            #region Anti Hosts Fuck Tool
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Windows\System32\Drivers\etc\hosts"))
                {
                    String line = sr.ReadToEnd();
                    /*
                    richTextBox1.Text = line.ToLower();
                    string contenu = richTextBox1.Text;
                    if (contenu.Contains("www.boost4ever.livehost.fr") | contenu.Contains("www.boost4ever.livehost.fr"))
                    {
                        MessageBox.Show("An Error as occured !");
                        Application.Exit();
                    }
                    else
                    {

                     
                    }
                     * * */
                }
            }
            catch
            {
                Application.Exit();
            }
            #endregion
        }

        private void logInButton6_Click_1(object sender, EventArgs e)
        {
            string myString = logInNormalTextBox18.Text;
            int index = weaponszm.FindString(myString, -1);
            if (index != -1)
            {
                weaponszm.SetSelected(index, true);
                label26.Text = "Found the item \"" + myString + "\" at index: " + index + "";

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void weaponszm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (weaponszm.SelectedItem == "RK5")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.RK5Kills, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.RK5Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : RK5";
            }
            if (weaponszm.SelectedItem == "Drakon")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.DrakonKill, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.DrakonHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Drakon";
            }
            if (weaponszm.SelectedItem == "VMP")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.VMP, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.VMPHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : VMP";
            }
            if (weaponszm.SelectedItem == "LCar9")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.LCar9, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.LCar9Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : LCar9";
            }
            if (weaponszm.SelectedItem == "BowieKnife")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.BowieKnife, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.BowieKnifeHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : BowieKnife";
            }
            if (weaponszm.SelectedItem == "XM53")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.XM53, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.XM53Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : XM53";
            }
            if (weaponszm.SelectedItem == "Kuda")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Kuda, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.KudaHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Kuda";
            }
            if (weaponszm.SelectedItem == "Vesper")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Vesper, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.VesperHeadShots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Vesper";
            }
            if (weaponszm.SelectedItem == "Pharo")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Phara, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.PhroHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Pharo";
            }
            if (weaponszm.SelectedItem == "KN44")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.KN44, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.KN44Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : KN44";
            }
            if (weaponszm.SelectedItem == "ICR1")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.ICR1, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.ICR1Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : ICR1";
            }
            if (weaponszm.SelectedItem == "M8A1")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.M8A1, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.M8A1Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : M8A1";
            }
            if (weaponszm.SelectedItem == "Sheiva")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Sheiva, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.SheivaHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Sheiva";
            }
            if (weaponszm.SelectedItem == "HVK30")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.HVK30, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.HVK30Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : HVK30";
            }
            if (weaponszm.SelectedItem == "BRM")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.BRM, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.BRMHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : BRM";
            }
            if (weaponszm.SelectedItem == "Dingo")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.DingoHeadshots, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.Dingo, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Dingo";
            }
            if (weaponszm.SelectedItem == "Gorgon")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Gorgon, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.GorgonHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Gorgon";
            }
            if (weaponszm.SelectedItem == "KRM262")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.KRM262, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.KRM262Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : KRM262";
            }
            if (weaponszm.SelectedItem == "Argus")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Argus, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.ArgusHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Argus";
            }
            if (weaponszm.SelectedItem == "Brecci")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Brecci, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.BrecciHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Brecci";
            }
            if (weaponszm.SelectedItem == "Haymaker12")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.HayMaker, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.HayMakerHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Haymaker12";
            }
            if (weaponszm.SelectedItem == "Locus")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Locus, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.LocusHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Locus";
            }
            if (weaponszm.SelectedItem == "SVG100")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.SVG100, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.SVG100Headshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : SVG100";
            }
            if (weaponszm.SelectedItem == "Weevil")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.Weevil, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.WeevilHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : Weevil";
            }
            if (weaponszm.SelectedItem == "ManOfWar")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(WeaponsZM.ManOfWar, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                byte[] buffer4 = new byte[4];
                PS3.GetMemory(WeaponsZM.ManOfWarHeadshots, buffer4);
                headshotsweapzm.Value = BitConverter.ToInt32(buffer4, 0);
                label8.Text = "Weapons Selected : ManOfWar";
            }
        }

        private void logInButton1_Click_1(object sender, EventArgs e)
        {
            Random randNum = new Random();
            killweapzm.Value = randNum.Next(15000, 50000);
            headshotsweapzm.Value = randNum.Next(0, 15000);
        }

        private void logInButton3_Click_1(object sender, EventArgs e)
        {
            PS3.SetMemory(WeaponsZM.Argus, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.ArgusHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.BowieKnife, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.BowieKnifeHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Brecci, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.BrecciHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.BRM, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.BRMHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Dingo, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.DingoHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.DrakonKill, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.DrakonHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Dredge, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.DredgeHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Gorgon, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.GorgonHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.HayMaker, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.HayMakerHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.HVK30, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.HVK30Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.ICR1, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.ICR1Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.KN44, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.KN44Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.KRM262, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.KRM262Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Kuda, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.KudaHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.LCar9, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.LCar9Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Locus, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.LocusHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.M8A1, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.M8A1Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Phara, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.PhroHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.RK5Kills, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.RK5Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Sheiva, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.SheivaHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.SVG100, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.SVG100Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Vesper, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.VesperHeadShots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.VMP, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.VMPHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.XM53, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.XM53Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.ManOfWar, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.ManOfWarHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            PS3.SetMemory(WeaponsZM.Weevil, BitConverter.GetBytes((int)killweapzm.Value));
            PS3.SetMemory(WeaponsZM.WeevilHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
        }

        private void logInButton2_Click_1(object sender, EventArgs e)
        {
            if (weaponszm.SelectedItem == "Argus")
            {
                PS3.SetMemory(WeaponsZM.Argus, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.ArgusHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "BowieKnife")
            {
                PS3.SetMemory(WeaponsZM.BowieKnife, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.BowieKnifeHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Brecci")
            {
                PS3.SetMemory(WeaponsZM.Brecci, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.BrecciHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "BRM")
            {
                PS3.SetMemory(WeaponsZM.BRM, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.BRMHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Dingo")
            {
                PS3.SetMemory(WeaponsZM.Dingo, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.DingoHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Drakon")
            {
                PS3.SetMemory(WeaponsZM.DrakonKill, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.DrakonHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Dredge")
            {
                PS3.SetMemory(WeaponsZM.Dredge, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.DredgeHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Gorgon")
            {
                PS3.SetMemory(WeaponsZM.Gorgon, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.GorgonHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Haymaker12")
            {
                PS3.SetMemory(WeaponsZM.HayMaker, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.HayMakerHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "HVK30")
            {
                PS3.SetMemory(WeaponsZM.HVK30, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.HVK30Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "ICR1")
            {
                PS3.SetMemory(WeaponsZM.ICR1, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.ICR1Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "KN44")
            {
                PS3.SetMemory(WeaponsZM.KN44, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.KN44Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "KRM262")
            {
                PS3.SetMemory(WeaponsZM.KRM262, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.KRM262Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Kuda")
            {
                PS3.SetMemory(WeaponsZM.Kuda, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.KudaHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "LCar9")
            {
                PS3.SetMemory(WeaponsZM.LCar9, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.LCar9Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Locus")
            {
                PS3.SetMemory(WeaponsZM.Locus, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.LocusHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Drakon")
            {
                PS3.SetMemory(WeaponsZM.M8A1, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.M8A1Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Pharo")
            {
                PS3.SetMemory(WeaponsZM.Phara, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.PhroHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "RK5")
            {
                PS3.SetMemory(WeaponsZM.RK5Kills, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.RK5Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Sheiva")
            {
                PS3.SetMemory(WeaponsZM.Sheiva, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.SheivaHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "SVG100")
            {
                PS3.SetMemory(WeaponsZM.SVG100, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.SVG100Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Vesper")
            {
                PS3.SetMemory(WeaponsZM.Vesper, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.VesperHeadShots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "VMP")
            {
                PS3.SetMemory(WeaponsZM.VMP, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.VMPHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "XM53")
            {
                PS3.SetMemory(WeaponsZM.XM53, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.XM53Headshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "Weevil")
            {
                PS3.SetMemory(WeaponsZM.Weevil, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.WeevilHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
            if (weaponszm.SelectedItem == "ManOfWar")
            {
                PS3.SetMemory(WeaponsZM.ManOfWar, BitConverter.GetBytes((int)killweapzm.Value));
                PS3.SetMemory(WeaponsZM.ManOfWarHeadshots, BitConverter.GetBytes((int)headshotsweapzm.Value));
            }
        }

        private void logInButton35_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            usegobblezm.Value = randNum.Next(15000, 50000);
        }
        public struct GobbleGumStats
        {
            public static UInt32
            Alchemical_Antithesis = Prestige - 0x22D8,
            Always_done_swiftly = Prestige - 0x2256,
            anywhere_but_here = Prestige - 0x2256 + 0x82,
            armamental_accomplishment = anywhere_but_here + 0x82,
            arms_grace = Prestige - 0x2256 + 0x82 + 0x82 + 0x82,
            arsenal_accelerator = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82,
            coagulant = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            danger_closest = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            firing_on_all_cylinders = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            impatient = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            in_plain_sight = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            lucky_crit = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            now_you_see_me = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            stock_option = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            sword_flay = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            aftertaste = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            burned_out = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            cache_back = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            dead_of_nuclear_winter = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            ephemeral_enhancement = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            im_feeling_lucky = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            immolation_liquidation = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            kill_joy = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            killing_time = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            licenced_contractor = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            on_the_house = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            perkaholic = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            phoenix_up = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            pop_shocks = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            respin_cycle = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            unquenchable = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            wall_power = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            whos_keeping_score = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            crawl_space = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            fatal_contraption = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            head_drama = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82,
            undead_man_walking = Prestige - 0x2256 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82 + 0x82;
        }
        private void logInButton36_Click_1(object sender, EventArgs e)
        {
            if (gobblegumzm.SelectedIndex == 0)
            {
                PS3.SetMemory(GobbleGumStats.aftertaste, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 1)
            {
                PS3.SetMemory(GobbleGumStats.Alchemical_Antithesis, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 2)
            {
                PS3.SetMemory(GobbleGumStats.Always_done_swiftly, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 3)
            {
                PS3.SetMemory(GobbleGumStats.anywhere_but_here, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 4)
            {
                PS3.SetMemory(GobbleGumStats.armamental_accomplishment, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 5)
            {
                PS3.SetMemory(GobbleGumStats.arms_grace, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 6)
            {
                PS3.SetMemory(GobbleGumStats.arsenal_accelerator, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 7)
            {
                PS3.SetMemory(GobbleGumStats.burned_out, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 8)
            {
                PS3.SetMemory(GobbleGumStats.cache_back, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 9)
            {
                PS3.SetMemory(GobbleGumStats.coagulant, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 10)
            {
                PS3.SetMemory(GobbleGumStats.crawl_space, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 11)
            {
                PS3.SetMemory(GobbleGumStats.danger_closest, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 12)
            {
                PS3.SetMemory(GobbleGumStats.dead_of_nuclear_winter, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 13)
            {
                PS3.SetMemory(GobbleGumStats.ephemeral_enhancement, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 14)
            {
                PS3.SetMemory(GobbleGumStats.fatal_contraption, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 15)
            {
                PS3.SetMemory(GobbleGumStats.firing_on_all_cylinders, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 16)
            {
                PS3.SetMemory(GobbleGumStats.head_drama, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 17)
            {
                PS3.SetMemory(GobbleGumStats.im_feeling_lucky, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 18)
            {
                PS3.SetMemory(GobbleGumStats.immolation_liquidation, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 19)
            {
                PS3.SetMemory(GobbleGumStats.impatient, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 20)
            {
                PS3.SetMemory(GobbleGumStats.in_plain_sight, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 21)
            {
                PS3.SetMemory(GobbleGumStats.kill_joy, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 22)
            {
                PS3.SetMemory(GobbleGumStats.killing_time, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 23)
            {
                PS3.SetMemory(GobbleGumStats.licenced_contractor, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 24)
            {
                PS3.SetMemory(GobbleGumStats.lucky_crit, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 25)
            {
                PS3.SetMemory(GobbleGumStats.now_you_see_me, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 26)
            {
                PS3.SetMemory(GobbleGumStats.on_the_house, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 27)
            {
                PS3.SetMemory(GobbleGumStats.perkaholic, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 28)
            {
                PS3.SetMemory(GobbleGumStats.phoenix_up, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 299)
            {
                PS3.SetMemory(GobbleGumStats.pop_shocks, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 30)
            {
                PS3.SetMemory(GobbleGumStats.respin_cycle, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 31)
            {
                PS3.SetMemory(GobbleGumStats.stock_option, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 32)
            {
                PS3.SetMemory(GobbleGumStats.sword_flay, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 33)
            {
                PS3.SetMemory(GobbleGumStats.undead_man_walking, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 34)
            {
                PS3.SetMemory(GobbleGumStats.unquenchable, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 35)
            {
                PS3.SetMemory(GobbleGumStats.wall_power, BitConverter.GetBytes((int)usegobblezm.Value));
            }
            if (gobblegumzm.SelectedIndex == 36)
            {
                PS3.SetMemory(GobbleGumStats.whos_keeping_score, BitConverter.GetBytes((int)usegobblezm.Value));
            }
        }

        private void logInButton37_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(GobbleGumStats.aftertaste, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.Alchemical_Antithesis, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.Always_done_swiftly, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.anywhere_but_here, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.armamental_accomplishment, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.arms_grace, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.arsenal_accelerator, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.burned_out, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.cache_back, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.coagulant, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.crawl_space, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.danger_closest, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.dead_of_nuclear_winter, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.ephemeral_enhancement, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.fatal_contraption, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.firing_on_all_cylinders, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.head_drama, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.im_feeling_lucky, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.immolation_liquidation, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.impatient, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.in_plain_sight, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.kill_joy, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.killing_time, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.licenced_contractor, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.lucky_crit, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.now_you_see_me, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.on_the_house, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.perkaholic, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.phoenix_up, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.pop_shocks, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.respin_cycle, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.stock_option, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.sword_flay, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.undead_man_walking, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.unquenchable, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.wall_power, BitConverter.GetBytes((int)usegobblezm.Value));
            PS3.SetMemory(GobbleGumStats.whos_keeping_score, BitConverter.GetBytes((int)usegobblezm.Value));
        }

        private void logInButton41_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[4];
            PS3.GetMemory(Prestige, buffer);
            firefoxNumericUpDown1.Value = BitConverter.ToInt32(buffer, 0);

          

            byte[] buffer8 = new byte[4];
            PS3.GetMemory(StatsZM.Kill, buffer8);
            firefoxNumericUpDown3.Value = BitConverter.ToInt32(buffer8, 0);

            byte[] buffer9 = new byte[4];
            PS3.GetMemory(StatsZM.Liquid, buffer9);
            firefoxNumericUpDown4.Value = BitConverter.ToInt32(buffer9, 0);

            byte[] buffer7 = new byte[4];
            PS3.GetMemory(StatsZM.Round_Survived, buffer7);
            firefoxNumericUpDown5.Value = BitConverter.ToInt32(buffer7, 0);

            byte[] buffer12 = new byte[4];
            PS3.GetMemory(StatsZM.HeadShots, buffer12);
            firefoxNumericUpDown6.Value = BitConverter.ToInt32(buffer12, 0);

            byte[] buffer10 = new byte[4];
            PS3.GetMemory(StatsZM.Average_Points, buffer10);
            firefoxNumericUpDown7.Value = BitConverter.ToInt32(buffer10, 0);

            byte[] buffer11 = new byte[4];
            PS3.GetMemory(StatsZM.tirseffectué, buffer11);
            logInNumeric26.Value = BitConverter.ToInt32(buffer11, 0);

            byte[] buffer19 = new byte[4];
            PS3.GetMemory(StatsZM.tirsreussi, buffer19);
            logInNumeric27.Value = BitConverter.ToInt32(buffer19, 0);

            byte[] buffer13 = new byte[4];
            PS3.GetMemory(StatsZM.porteouverte, buffer13);
            logInNumeric28.Value = BitConverter.ToInt32(buffer13, 0);

            byte[] buffer14 = new byte[4];
            PS3.GetMemory(StatsZM.reanim, buffer14);
            logInNumeric29.Value = BitConverter.ToInt32(buffer14, 0);

            byte[] buffer15 = new byte[4];
            PS3.GetMemory(StatsZM.distanceparcourue, buffer15);
            logInNumeric30.Value = BitConverter.ToInt32(buffer15, 0);

            byte[] buffer16 = new byte[4];
            PS3.GetMemory(StatsZM.elimexplosif, buffer16);
            logInNumeric31.Value = BitConverter.ToInt32(buffer16, 0);

            byte[] buffer17 = new byte[4];
            PS3.GetMemory(StatsZM.atoutbus, buffer17);
            logInNumeric32.Value = BitConverter.ToInt32(buffer17, 0);
        }

        private void logInButton40_Click(object sender, EventArgs e)
        {
            Random randNum = new Random();
            firefoxNumericUpDown1.Value = randNum.Next(0, 11);
            firefoxNumericUpDown3.Value = randNum.Next(1, 100000);
            firefoxNumericUpDown4.Value = randNum.Next(1, 100000);
            firefoxNumericUpDown5.Value = randNum.Next(1, 100000);
            firefoxNumericUpDown6.Value = randNum.Next(1, 100000);
            firefoxNumericUpDown7.Value = randNum.Next(1, 100000);
            firefoxNumericUpDown10.Value = randNum.Next(0, 55);
            firefoxNumericUpDown9.Value = randNum.Next(0, 24);
            firefoxNumericUpDown11.Value = randNum.Next(0, 60);
            logInNumeric26.Value = randNum.Next(1, 100000);
            logInNumeric27.Value = randNum.Next(1, 100000);
            logInNumeric28.Value = randNum.Next(1, 100000);
            logInNumeric29.Value = randNum.Next(1, 100000);
            logInNumeric30.Value = randNum.Next(1, 100000);
            logInNumeric31.Value = randNum.Next(1, 100000);
            logInNumeric32.Value = randNum.Next(1, 100000);
        }

        private void logInButton39_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(Prestige, BitConverter.GetBytes((int)firefoxNumericUpDown1.Value));
            PS3.SetMemory(StatsZM.Kill, BitConverter.GetBytes((int)firefoxNumericUpDown3.Value));
            PS3.SetMemory(StatsZM.Liquid, BitConverter.GetBytes((int)firefoxNumericUpDown4.Value));
            PS3.SetMemory(StatsZM.Round_Survived, BitConverter.GetBytes((int)firefoxNumericUpDown5.Value));
            PS3.SetMemory(StatsZM.HeadShots, BitConverter.GetBytes((int)firefoxNumericUpDown7.Value));
            PS3.SetMemory(StatsZM.Average_Points, BitConverter.GetBytes((int)firefoxNumericUpDown6.Value));
            PS3.SetMemory(StatsZM.round_leaderboard, BitConverter.GetBytes((int)firefoxNumericUpDown8.Value));

            PS3.SetMemory(StatsZM.tirseffectué, BitConverter.GetBytes((int)logInNumeric26.Value));
            PS3.SetMemory(StatsZM.tirsreussi, BitConverter.GetBytes((int)logInNumeric27.Value));
            PS3.SetMemory(StatsZM.porteouverte, BitConverter.GetBytes((int)logInNumeric28.Value));
            PS3.SetMemory(StatsZM.elimexplosif, BitConverter.GetBytes((int)logInNumeric31.Value));
            PS3.SetMemory(StatsZM.reanim, BitConverter.GetBytes((int)logInNumeric29.Value));
            PS3.SetMemory(StatsZM.distanceparcourue, BitConverter.GetBytes((int)logInNumeric30.Value));
            PS3.SetMemory(StatsZM.atoutbus, BitConverter.GetBytes((int)logInNumeric32.Value));




            PS3.Extension.WriteString(StatsZM.GobbleName, textBox1.Text);
            if (firefoxCheckBox1.Checked)
            {
                PS3.SetMemory(StatsZM.Level, new byte[] { 0x21, 0x00, 0x00, 0x00 });
            }
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval, textBox2.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox3.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox4.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox5.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox10.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox9.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox8.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox7.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox6.Text);

            decimal Total = (((firefoxNumericUpDown10.Value * 86400) + (firefoxNumericUpDown9.Value * 3600)) + (firefoxNumericUpDown11.Value * 60)) + (firefoxNumericUpDown11.Value);
            byte[] Send = BitConverter.GetBytes(Convert.ToInt32(Total.ToString()));
            PS3.SetMemory(StatsZM.Time_Played, Send);
        }

        private void logInCheckBox1_CheckedChanged_1(object sender)
        {
            if (firefoxCheckBox1.Checked)
            {
                byte[] buffer = new byte[] { 0x21, 0x00, 0x00, 0x00 };
                PS3.GetMemory(StatsZM.Level, buffer);
            }
            else
            {
                byte[] buffer = new byte[] { 0x00, 0x00, 0x00, 0x00 };
                PS3.GetMemory(StatsZM.Level, buffer);
            }
        }

        private void firefoxCheckBox2_CheckedChanged(object sender)
        {
            PS3.SetMemory(0x37DDE818, Enumerable.Repeat((byte)0xff, 0x26C).ToArray());
            byte[] fuck = new byte[] { 0xff, 0xff, };
            PS3.SetMemory(0x37DDD102, fuck);
            PS3.SetMemory(0x37DDCEFA, fuck);
            PS3.SetMemory(0x37DDCF7C, fuck);
            PS3.SetMemory(0x37DDCD74, fuck);
            PS3.SetMemory(0x37DDCB6C, fuck);
            PS3.SetMemory(0x37DDCC70, fuck);
            PS3.SetMemory(0x37DDCBEE, fuck);
            PS3.SetMemory(0x37DDCAEA, fuck);
            PS3.SetMemory(0x37DDCA68, fuck);
            PS3.SetMemory(0x37DDCDF6, fuck);
            PS3.SetMemory(0x37DDD206, fuck);
            PS3.SetMemory(0x37DDD288, fuck);
            PS3.SetMemory(0x37DDD38C, fuck);
            PS3.SetMemory(0x37DDCCF2, fuck);
            PS3.SetMemory(0x37DDCE78, fuck);
            PS3.SetMemory(0x37DDCFFE, fuck);
            PS3.SetMemory(0x37DDD080, fuck);
            PS3.SetMemory(0x37DDD184, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Weevil_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Weevil_Level, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Man_of_war_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Man_of_ware_Level, fuck);
            PS3.SetMemory(WeaponsUnlockZM.XM53_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Argus, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Argus_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Bowie, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Bowie_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Brecci, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Brecci_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.BRM, fuck);
            PS3.SetMemory(WeaponsUnlockZM.BRM_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Dingo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Dingo_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.DrakonKill, fuck);
            PS3.SetMemory(WeaponsUnlockZM.DrakonKill_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Dredge, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Dredge_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Gorgon, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Gorgon_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.HayMaker, fuck);
            PS3.SetMemory(WeaponsUnlockZM.HayMaker_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.HVK30, fuck);
            PS3.SetMemory(WeaponsUnlockZM.HVK30_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.ICR1, fuck);
            PS3.SetMemory(WeaponsUnlockZM.ICR1_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.KN44, fuck);
            PS3.SetMemory(WeaponsUnlockZM.KN44_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.KRM62, fuck);
            PS3.SetMemory(WeaponsUnlockZM.KRM62_CamO, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Kuda, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Kuda_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.L_Car_9, fuck);
            PS3.SetMemory(WeaponsUnlockZM.L_Car_9_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Locus, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Locus_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.M8A1, fuck);
            PS3.SetMemory(WeaponsUnlockZM.M8A1_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Phara, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Phara_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.RK5, fuck);
            PS3.SetMemory(WeaponsUnlockZM.RK5_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Sheiva, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Sheiva_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.SVG100, fuck);
            PS3.SetMemory(WeaponsUnlockZM.SVG100_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Vesper, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Vesper_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.VMP, fuck);
            PS3.SetMemory(WeaponsUnlockZM.VMP_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.XM_53, fuck);
            PS3.SetMemory(WeaponsUnlockZM.XM_53_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.XM_53_Kill, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Weevil_Camo, fuck);
            PS3.SetMemory(WeaponsUnlockZM.Weevil_Level, fuck);
            PS3.Extension.WriteString(StatsZM.Tag_Clan, "GMNT");
        }

        private void logInButton44_Click(object sender, EventArgs e)
        {
            textBox1.Text = PS3.Extension.ReadString(StatsZM.GobbleName);
            textBox2.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval);
            textBox3.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval);
            textBox4.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval);
            textBox5.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval);
            textBox10.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval);
            textBox9.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval);
            textBox8.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval);
            textBox7.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval);
            textBox6.Text = PS3.Extension.ReadString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval);
        }

        private void logInButton43_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox11.Text;
            textBox2.Text = textBox11.Text;
            textBox3.Text = textBox11.Text;
            textBox4.Text = textBox11.Text;
            textBox5.Text = textBox11.Text;
            textBox6.Text = textBox11.Text;
            textBox7.Text = textBox11.Text;
            textBox8.Text = textBox11.Text;
            textBox9.Text = textBox11.Text;
            textBox10.Text = textBox11.Text;
        }

        private void logInButton42_Click(object sender, EventArgs e)
        {
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval, textBox2.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox3.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox4.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox5.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox10.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox9.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox8.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox7.Text);
            PS3.Extension.WriteString(StatsZM.GobbleName + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval + StatsZM.GobbleNameInterval, textBox6.Text);
        }

        private void logInButton46_Click(object sender, EventArgs e)
        {
        }

        private void logInButton48_Click(object sender, EventArgs e)
        {
        }

        private void logInButton47_Click(object sender, EventArgs e)
        {
            
        }

        private void csharpstubRadiobtn_CheckedChanged(object sender)
        {
            if (csharpstubRadiobtn.Checked)
            {
                PS3.ChangeAPI(SelectAPI.TargetManager);
            }
        }

        private void logInRadioButton2_CheckedChanged(object sender)
        {
            if (logInRadioButton2.Checked)
            {
                PS3.ChangeAPI(SelectAPI.SNMAPI);
                MessageBox.Show("Please note that SNMAPI use an outdated version and is not compatible with 4.81 DEX/CEX firmware ! I don't have the latest version...", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void logInRadioButton1_CheckedChanged(object sender)
        {
            PS3.ChangeAPI(SelectAPI.ControlConsole);
        }

        private void logInButton45_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (PS3.ConnectTarget())
                {
                    logInStatusBar1.Text = "Playstation 3 : Connected !";
                    MessageBox.Show("Playstation 3 Connected !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
                else
                {
                    MessageBox.Show("Playstation 3 Not Connected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Playstation 3 Not Connected !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void logInRadioButton4_CheckedChanged(object sender)
        {

        }

        private void logInRadioButton3_CheckedChanged(object sender)
        {
           
        }
        public static uint G_Client = 0x18C6220;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Default Weapons")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x01 });
                }
            }
            if (comboBox1.SelectedItem == "Kuda")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x02 });
                }
            }
            if (comboBox1.SelectedItem == "VMP")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x04 });
                }
            }
            if (comboBox1.SelectedItem == "KN-44")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 14 });
                }
            }
            if (comboBox1.SelectedItem == "HVK-30")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x12 });
                }
            }
            if (comboBox1.SelectedItem == "ICR-1")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 20 });
                }
            }
            if (comboBox1.SelectedItem == "Default Weapons")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x01 });
                }
            }
            if (comboBox1.SelectedItem == "Default Weapons")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x01 });
                }
            }
            if (comboBox1.SelectedItem == "KRM")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x1c });
                }
            }
            if (comboBox1.SelectedItem == "Argus")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x1f });
                }
            }
            if (comboBox1.SelectedItem == "BRM")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x20 });
                }
            }
            if (comboBox1.SelectedItem == "Dingo")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x22 });
                }
            }
            if (comboBox1.SelectedItem == "Drakon")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 40 });
                }
            }
            if (comboBox1.SelectedItem == "Locus")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x2a });
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.SelectedItem == "No Camo")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x389 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x00 });
                }
            }
            if (comboBox4.SelectedItem == "Jungle")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x389 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 1 });
                }
            }
            if (comboBox4.SelectedItem == "Flectarn")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x389 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 3 });
                }
            }
            if (comboBox4.SelectedItem == "Dante")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x389 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 6 });
                }
            }
            if (comboBox4.SelectedItem == "Policia")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x389 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 9 });
                }
            }
            if (comboBox4.SelectedItem == "Burnt")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x389 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 11 });
                }
            }
            if (comboBox4.SelectedItem == "Dark Metter")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x389 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x11 });
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == "Default")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 14 });
                }
            }
            if (comboBox2.SelectedItem == "Turret")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x7b });
                }
            }
            if (comboBox2.SelectedItem == "RPG")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x7a });
                }
            }
            if (comboBox2.SelectedItem == "Model")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x8f });
                }
            }
            if (comboBox2.SelectedItem == "Rapide Fire")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x383 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x6d });
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == "Default")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    PS3.SetMemory((G_Client + 0x647 + (uint)Players.SelectedIndex * 0x6200), new byte[4]);
                    PS3.SetMemory((G_Client + 0x65b + (uint)Players.SelectedIndex * 0x6200), new byte[1]);
                    PS3.SetMemory((G_Client + 0x647 + (uint)Players.SelectedIndex * 0x6200), new byte[2]);
                }
            }
            if (comboBox3.SelectedItem == "Blue")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    byte[] buffer = new byte[4];
                    buffer[2] = 0xf8;
                    buffer[3] = 0xfb;
                    PS3.SetMemory((G_Client + 0x647 + (uint)Players.SelectedIndex * 0x6200), buffer);
                }
            }
            if (comboBox3.SelectedItem == "Thermal")
            {
                for (int i = 0; i < 0x12; i++)
                {
                    int pedID = (Players.SelectedIndex);
                    byte[] buffer = new byte[] { 0xff };
                    PS3.SetMemory((G_Client + 0x647 + (uint)Players.SelectedIndex * 0x6200), buffer);
                }
            }
        }
        public static string get_player_name(uint client)
        {
            string getnames = PS3.Extension.ReadString(G_Client + 0x5e14 + client * 0x6200);
            return getnames;
        }
        private void getClientsNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Players.Items.Clear();
            for (uint i = 0; i < 0x12; i++)
            {
                Players.Items.Add(get_player_name(i));
            }
            logInGroupBox22.Enabled = true;
        }

        private void enableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x23 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x05 });
            }
        }

        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x23 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x04 });
            }
        }

        private void unlimitedAmmoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x548 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 15, 0xff, 0xff, 0xff });
                PS3.SetMemory((G_Client + 0x389 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 15, 0xff, 0xff, 0xff });
                PS3.SetMemory((G_Client + 0x584 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 15, 0xff, 0xff, 0xff });
                PS3.SetMemory((G_Client + 0x54c + (uint)Players.SelectedIndex * 0x6200), new byte[] { 15, 0xff, 0xff, 0xff });
                PS3.SetMemory((G_Client + 0x588 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 15, 0xff, 0xff, 0xff });
            }
        }

        private void slowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x5df8 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x40 });
            }
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x5df8 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x3f });
            }
        }

        private void unlockKillstreaksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x546 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0xff });
                PS3.SetMemory((G_Client + 0x542 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0xff });
                PS3.SetMemory((G_Client + 0x53e + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0xff });
            }
        }

        private void enableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x65a + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x01 });
            }
        }

        private void disableToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x65a + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x00 });
            }
        }

        private void enableToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x5d27 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x04 });
            }
        }

        private void disableToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x5d27 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x00 });
            }
        }

        private void enableToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x5d27 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x00 });
            }
        }

        private void disableToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x5d27 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x02 });
            }
        }

        private void enabeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x5eff + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x07 });
            }
        }

        private void disableToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x5eff + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x03 });
            }
        }

        private void enableToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x658 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0xf5 });
            }
        }

        private void disableToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x658 + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x00 });
            }
        }

        private void enableToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x12d + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x01 });
            }
        }

        private void disableToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                int pedID = (Players.SelectedIndex);
                PS3.SetMemory((G_Client + 0x12d + (uint)Players.SelectedIndex * 0x6200), new byte[] { 0x00 });
            }
        }
        #region BO3_RPC
        public static void EnableRPCMP()
        {
            PS3.SetMemory(0x3D0B28, new byte[] { 0x4E, 0x80, 0x00, 0x20 });
            Thread.Sleep(20);
            byte[] func = new byte[]
            {
                0x7C, 0x08, 0x02, 0xA6, 0xF8, 0x01, 0x00, 0x80, 0x3C, 0x60, 0x10, 0x05, 0x81, 0x83, 0x00, 0x4C, 0x2C, 0x0C,
                0x00, 0x00, 0x41, 0x82, 0x00, 0x64, 0x80, 0x83, 0x00, 0x04, 0x80, 0xA3, 0x00, 0x08, 0x80, 0xC3, 0x00,
                0x0C, 0x80, 0xE3, 0x00, 0x10, 0x81, 0x03, 0x00, 0x14, 0x81, 0x23, 0x00, 0x18, 0x81, 0x43, 0x00, 0x1C,
                0x81, 0x63, 0x00, 0x20, 0xC0, 0x23, 0x00, 0x24, 0xC0, 0x43, 0x00, 0x28, 0xC0, 0x63, 0x00, 0x2C, 0xC0,
                0x83, 0x00, 0x30, 0xC0, 0xA3, 0x00, 0x34, 0xC0, 0xC3, 0x00, 0x38, 0xC0, 0xE3, 0x00, 0x3C, 0xC1, 0x03,
                0x00, 0x40, 0xC1, 0x23, 0x00, 0x48, 0x80, 0x63, 0x00, 0x00, 0x7D, 0x89, 0x03, 0xA6, 0x4E, 0x80, 0x04,
                0x21, 0x3C, 0x80, 0x10, 0x05, 0x38, 0xA0, 0x00, 0x00, 0x90, 0xA4, 0x00, 0x4C, 0x90, 0x64, 0x00, 0x50,
                0xE8, 0x01, 0x00, 0x80, 0x7C, 0x08, 0x03, 0xA6, 0x38, 0x21, 0x00, 0x70, 0x4E, 0x80, 0x00, 0x20
            };
            PS3.SetMemory(0x3D0B28 + 0x4, func);
            PS3.SetMemory(0x10050000, new byte[0x2854]);
            PS3.SetMemory(0x3D0B28, new byte[] { 0xF8, 0x21, 0xFF, 0x91 });
        }
        public Int32 CallMP(UInt32 Address, params Object[] MemoryParams)
        {
            int num_params = MemoryParams.Length;
            uint num_floats = 0;
            for (uint i = 0; i < num_params; i++)
            {
                if (MemoryParams[i] is int)
                {
                    byte[] val = BitConverter.GetBytes((int)MemoryParams[i]);
                    Array.Reverse(val);
                    PS3.SetMemory(0x10050000 + (i + num_floats) * 4, val);
                }
                else if (MemoryParams[i] is uint)
                {
                    byte[] val = BitConverter.GetBytes((uint)MemoryParams[i]);
                    Array.Reverse(val);
                    PS3.SetMemory(0x10050000 + (i + num_floats) * 4, val);
                }
                else if (MemoryParams[i] is string)
                {
                    byte[] str = Encoding.UTF8.GetBytes(Convert.ToString(MemoryParams[i]) + "\0");
                    PS3.SetMemory(0x10050054 + i * 0x400, str);
                    uint addr = 0x10050054 + i * 0x400;
                    byte[] address = BitConverter.GetBytes(addr);
                    Array.Reverse(address);
                    PS3.SetMemory(0x10050000 + (i + num_floats) * 4, address);
                }
                else if (MemoryParams[i] is float)
                {
                    num_floats++;
                    byte[] val = BitConverter.GetBytes((float)MemoryParams[i]);
                    Array.Reverse(val);
                    PS3.SetMemory(0x10050024 + ((num_floats - 1) * 0x4), val);
                }
            }
            byte[] fadd = BitConverter.GetBytes(Address);
            Array.Reverse(fadd);
            PS3.SetMemory(0x1005004C, fadd);
            Thread.Sleep(20);
            byte[] ret = PS3.Extension.ReadBytes(0x10050050, 4);
            Array.Reverse(ret);
            return BitConverter.ToInt32(ret, 0);
        }
        public void Cbuf_AddTextMP(String Command)
        {
            CallMP(0x5B1A7C, 0, Command);
        }
        #endregion
        private void logInButton50_Click(object sender, EventArgs e)
        {
            string serverCmd = "cmd mr " + PS3.Extension.ReadInt32(0x1198860) + " 3 " + "endround";
            CallMP(0x5B1A7C, 0, serverCmd);
        }

        private void logInButton49_Click(object sender, EventArgs e)
        {
            EnableRPCMP();
            MessageBox.Show("RPC Enabled !");
        }

        private void logInButton52_Click(object sender, EventArgs e)
        {
            PS3.Extension.WriteString(0x20DFE78, logInNormalTextBox20.Text);
        }

        private void logInButton51_Click(object sender, EventArgs e)
        {
        }

        private void logInCheckBox1_CheckedChanged_2(object sender)
        {
            if (logInCheckBox1.Checked)
            {
                Cbuf_AddTextMP("g_speed 900");
            }
            else
            {
                Cbuf_AddTextMP("g_speed 190");
            }
        }

        private void logInCheckBox3_CheckedChanged_1(object sender)
        {
            if (logInCheckBox3.Checked)
            {
                Cbuf_AddTextMP("g_knockback 100000");
            }
            else
            {
                Cbuf_AddTextMP("g_knockback 1000");
            }
        }

        private void logInGroupBox23_Click(object sender, EventArgs e)
        {

        }
        public static string get_player_nameZM(uint client)
        {
            string getnames = PS3.Extension.ReadString(0x18CA098 + client * 0x61E0);
            return getnames;
        }
        private void logInButton51_Click_1(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            for (uint i = 0; i < 0x12; i++)
            {
                listBox6.Items.Add(get_player_nameZM(i));
            }
        }

        private void giveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C430b + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x05 });
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C430b + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x04 });
            }
        }

        private void giveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4862 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18C4826 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18BC8C2 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18C486A + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18C4864 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
            }
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4862 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x18C4826 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x18BC8C2 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x18C486A + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory((0x18C4864 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0xff, 0x00 });
            }
        }

        private void maxPointsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA19D + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x7f, 0xff, 0xff, 0xff });
            }
        }

        private void giveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA0E0 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x3f, 0xff });
            }
        }

        private void removeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA0E0 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x3f, 0x80 });
            }
        }

        private void giveToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA00F + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x01 });
            }
        }

        private void removeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA00F + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void giveToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4415 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x01 });
            }
        }

        private void removeToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C4415 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void removeToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA1E7 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA1E7 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x03 });
            }
        }

        private void fireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory(0x25e5660, new byte[1]);
                PS3.SetMemory((0x18C45F9 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void defaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory(0x25e5660, new byte[1]);
                PS3.SetMemory((0x18C45F9 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void sendModdedInGameStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA1B2 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18CA1BE + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory((0x18CA19E + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0xff, 0xff, 0xff, 0xff });
            }
        }
        public string method_30(int int_1)
        {
            byte[] buffer = new byte[0x10];
            PS3.GetMemory(0x1AEE380 + 0x3334 + ((uint)(int_1 * 0x3900)), buffer);
            return Encoding.ASCII.GetString(buffer).Replace("\0", "");
        }
        private void changeNameInGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("Set a new name here :", "Change Name By MrNiato", method_30(Players.SelectedIndex), -1, -1);
            byte[] bytes = Encoding.ASCII.GetBytes(str + "\0");
            PS3.SetMemory(0x18CA0fc + ((uint)(listBox6.SelectedIndex * 0x61E0)), bytes);
            PS3.SetMemory((0x18CA19b + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            Thread.Sleep(1000);
            PS3.SetMemory((0x18CA19b + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x01 });
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x01 });
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x03 });
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x04 });
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x05 });
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x06 });
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x07 });
            }
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x08 });
            }
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x09 });
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x0A });
            }
        }

        private void darkMetterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x11 });
            }
        }

        private void girlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F9 + (uint)Players.SelectedIndex * 0x61E0), new byte[] { 0x0C });
            }
        }

        private void logInCheckBox6_CheckedChanged(object sender)
        {
            if (logInCheckBox6.Checked)
            {
                PS3.SetMemory(0x18C430b, new byte[] { 0x01, 0x01, 0x01, 0x01 });
                PS3.SetMemory(0x18C430b + 0x61E0, new byte[] { 0x01, 0x01, 0x01, 0x01 });
                PS3.SetMemory(0x18C430b + 0x61E0 + 0x61E0, new byte[] { 0x01, 0x01, 0x01, 0x01 });
                PS3.SetMemory(0x18C430b + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x01, 0x01, 0x01, 0x01 });
            }
            else
            {
                PS3.SetMemory(0x18C430b, new byte[] { 0x00, 0x10, 0x10, 0x00 });
                PS3.SetMemory(0x18C430b + 0x61E0, new byte[] { 0x00, 0x10, 0x10, 0x00 });
                PS3.SetMemory(0x18C430b + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x10, 0x10, 0x00 });
                PS3.SetMemory(0x18C430b + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x10, 0x10, 0x00 });
            }
        }

        private void logInCheckBox5_CheckedChanged(object sender)
        {
            if (logInCheckBox5.Checked)
            {
                PS3.SetMemory(0x18BC8C2, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18BC8C2 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18BC8C2 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18BC8C2 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C4862, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4862 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4862 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4862 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C4826, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4826 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4826 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4826 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C486A, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C486A + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C486A + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C486A + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C4864, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4864 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4864 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18C4864 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
            }
            else
            {
                PS3.SetMemory(0x18BC8C2, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18BC8C2 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18BC8C2 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18BC8C2 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                //
                PS3.SetMemory(0x18C4862, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4862 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4862 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4862 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0xff, 0xff, 0xff, 0xff });
                //
                PS3.SetMemory(0x18C4826, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4826 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4826 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4826 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                //
                PS3.SetMemory(0x18C486A, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C486A + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C486A + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C486A + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                //
                PS3.SetMemory(0x18C4864, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4864 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4864 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18C4864 + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            }
        }

        private void logInCheckBox7_CheckedChanged(object sender)
        {
            if (logInCheckBox7.Checked)
            {
                PS3.SetMemory(0x18CA19D, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18CA19D + 0x61E0, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18CA19D + 0x61E0 + 0x61E0, new byte[] { 0x7f, 0xff, 0xff, 0xff });
                PS3.SetMemory(0x18CA19D + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x7f, 0xff, 0xff, 0xff });
            }
            else
            {
                PS3.SetMemory(0x18CA19D, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18CA19D + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18CA19D + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x18CA19D + 0x61E0 + 0x61E0 + 0x61E0, new byte[] { 0x00, 0x00, 0x00, 0x00 });
            }
        }

        private void defaultWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x01 });
            }
        }

        private void vsperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void vMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x04 });
            }
        }

        private void kudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x06 });
            }
        }

        private void pharoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x09 });
            }
        }

        private void portersX2RayGunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void portersX2RayGunToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x96 });
            }
        }

        private void deathMachineToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void theGiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x95 });
            }
        }

        private void kreeaholoLuKreemasaleetToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x89 });
            }
        }

        private void wrathOfTheAncientsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x76 });
            }
        }

        private void kreegakaleetLuGosataahmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x79 });
            }
        }

        private void deathMachineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x95 });
            }
        }

        private void kreeahoahmNalAhmhogarocToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x7D });
            }
        }

        private void kreeahoahmNalAhmahmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x83 });
            }
        }

        private void marAstaguaArbgwaothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x80 });
            }
        }

        private void narUllaquaArbgwaothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x81 });
            }
        }

        private void lorZarozzorArbgwaothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x82 });
            }
        }

        private void weaponInterdimensionalGunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x83 });
            }
        }

        private void rayGunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x75 });
            }
        }

        private void wunderwaffeDG2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x78 });
            }
        }

        private void wunderwaffeDG3JZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x77 });
            }
        }

        private void logInButton53_Click(object sender, EventArgs e)
        {
            PS3.SetMemory(0x174A2AF, BitConverter.GetBytes((int)logInNumeric24.Value));
        }

        private void logInGroupBox27_Click(object sender, EventArgs e)
        {

        }

        private void logInButton54_Click(object sender, EventArgs e)
        {
            if (logInComboBox1.SelectedItem == "Mar-Astagua-Arbgwaoth")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x80 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x80 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x80 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x80 });
            }
            if (logInComboBox1.SelectedItem == "Nar-Ullaqua-Arbgwaoth")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x81 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x81 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x81 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x81 });
            }
            if (logInComboBox1.SelectedItem == "Lor-Zarozzor-Arbgwaoth")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x82 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x82 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x82 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x82 });
            }
            if (logInComboBox1.SelectedItem == "Weapon_Interdimensional_Gun")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x83 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x83 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x83 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x83 });
            }
            if (logInComboBox1.SelectedItem == "Wrath of the Ancients")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x76 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x76 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x76 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x76 });
            }
            if (logInComboBox1.SelectedItem == "Kreegakaleet lu Gosata'ahm")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x79 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x79 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x79 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x79 });
            }
            if (logInComboBox1.SelectedItem == "Kreeaho'ahm nal Ahmhogaroc")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x7D });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x7D });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x7D });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x7D });
            }
            if (logInComboBox1.SelectedItem == "Kreeaho'ahm nal Ahmahm")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x83 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x83 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x83 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x83 });
            }
            if (logInComboBox1.SelectedItem == "Kreeaholo lu Kreemasaleet")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x89 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x89 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x89 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x89 });
            }
            if (logInComboBox1.SelectedItem == "RayGun")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x75 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x75 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x75 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x75 });
            }
            if (logInComboBox1.SelectedItem == "Wunderwaffe DG-2")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x78 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x78 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x78 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x78 });
            }
            if (logInComboBox1.SelectedItem == "Wunderwaffe DG-3 JZ")
            {
                PS3.SetMemory((0x18C45F3), new byte[] { 0x77 });
                PS3.SetMemory((0x18C45F3 + 0x61E0), new byte[] { 0x77 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0), new byte[] { 0x77 });
                PS3.SetMemory((0x18C45F3 + 0x61E0 + 0x61E0 + 0x61E0), new byte[] { 0x77 });
            }
        }

        private void giveToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA0CD + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0xff, 0x00, 0x64, 0x00 });
            }
        }

        private void removeToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18CA0CD + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00, 0x00, 0x64, 0x00 });
            }
        }

        private void gobblegumzm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gobblegumzm.SelectedItem == "Aftertaste")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.aftertaste, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Alchemical Antithesis")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.Alchemical_Antithesis, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Always Done Swiftly")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.Always_done_swiftly, buffer2);
                killweapzm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Anywhere But Here")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.anywhere_but_here, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Armamental Accomplishment")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.armamental_accomplishment, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Arms Grace")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.arms_grace, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Arms Grace")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.arms_grace, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Arsenal Accelerator")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.arsenal_accelerator, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Burned Out")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.burned_out, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Cache Back")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.cache_back, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Coagulant")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.coagulant, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Crawl Space")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.crawl_space, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Danger Closest")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.danger_closest, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Dead of nuclear winter")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.dead_of_nuclear_winter, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Ephemeral Enhancement")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.ephemeral_enhancement, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Fatal Contraption")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.fatal_contraption, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Firing on all cylinders")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.firing_on_all_cylinders, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Head Drama")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.head_drama, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "I'm Feeling Lucky")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.im_feeling_lucky, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Immolation Liquidation")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.immolation_liquidation, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Impatient")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.impatient, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "In plain sight")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.in_plain_sight, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Kill Joy")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.kill_joy, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Killing time")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.killing_time, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Licenced Contractor")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.licenced_contractor, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Lucky crit")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.lucky_crit, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Now you see me")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.now_you_see_me, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "On the house")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.on_the_house, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Perkaholic")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.perkaholic, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Phoenix up")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.phoenix_up, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Pop shocks")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.pop_shocks, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Respin cycle")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.respin_cycle, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Stock option")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.stock_option, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Sword flay")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.sword_flay, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Undead man walking")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.undead_man_walking, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Unquenchable")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.unquenchable, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Wall power")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.wall_power, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
            if (gobblegumzm.SelectedItem == "Who's keeping score")
            {
                byte[] buffer2 = new byte[4];
                PS3.GetMemory(GobbleGumStats.whos_keeping_score, buffer2);
                usegobblezm.Value = BitConverter.ToInt32(buffer2, 0);
                label28.Text = "GobbleGum Selected : " + gobblegumzm.SelectedItem;
            }
        }

        private void logInButton46_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://paypal.me/MrNiato/5");
        }

        private void logInCheckBox8_CheckedChanged(object sender)
        {
            if (logInCheckBox8.Checked)
            {
                PS3.SetMemory(0xC8998, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            }
            else
            {
                PS3.SetMemory(0xC8998, new byte[] { 0x41, 0x82, 0x00, 0xAC });
            }
        }

        private void logInCheckBox9_CheckedChanged(object sender)
        {
         
        }

        private void logInCheckBox10_CheckedChanged(object sender)
        {
            if (logInCheckBox10.Checked)
            {
                PS3.SetMemory(0x58DF48, new byte[] { 0x60, 0x00, 0x00, 0x00 });
                PS3.SetMemory(0x58DF10, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            }
            else
            {
                PS3.SetMemory(0x58DF48, new byte[] { 0x41, 0x82, 0x01, 0xD4 });
                PS3.SetMemory(0x58DF10, new byte[] { 0x41, 0x82, 0x02, 0x0C });
            }
        }

        private void logInCheckBox11_CheckedChanged(object sender)
        {
            if (logInCheckBox11.Checked)
            {
                PS3.SetMemory(0x1908E8, new byte[] { 0x38, 0xC0, 0xFF, 0xFF });
            }
            else
            {
                PS3.SetMemory(0x1908E8, new byte[] { 0x63, 0xE6, 0x00, 0x00 });
            }

        }

        private void logInCheckBox12_CheckedChanged(object sender)
        {
            if (logInCheckBox12.Checked)
            {
                PS3.SetMemory(0xCC5A8, new byte[] { 0x2c, 0x14, 0x00, 0x01 });
            }
            else
            {
                 PS3.SetMemory(0xCC5A8, new byte[] { 0x2c, 0x14, 0x00, 0x00 });
            }
        }

        private void logInCheckBox13_CheckedChanged(object sender)
        {
            if (logInCheckBox13.Checked)
            {
                PS3.SetMemory(0x76A174, new byte[] { 0x2C, 0x04, 0x00, 0x00 });
            }
            else
            {
                PS3.SetMemory(0x76A174, new byte[] { 0x2C, 0x04, 0x00, 0x02 });
            }
        }

        private void logInButton47_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("In Rebug Toolbox : \n-System Mode : REBUG\n-XMB Operation Mode : DEBUG\n-Debug Menu Type : DEX\n-Cobra Mode : Enable\n\nIn Debug Settings\n-Release Check Mode : Development Mode\n-Boot Mode : System Software Mode\n-Network Settings for Debug : Single Settings", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://pastebin.com/raw/EWt4RhhM");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://h7k3r-app.fr/site/index");
        }


        #region md5
        public static string md5(string password)
        {
            MD5 md = new MD5CryptoServiceProvider();
            md.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = md.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        #endregion

        #region Ecryption

        private static string fingerPrint = string.Empty;
        public static string Value()
        {
            if (string.IsNullOrEmpty(fingerPrint))
            {
                fingerPrint = GetHash("CPU >> " + cpuId() + "\nBIOS >> " + biosId());
            }
            return fingerPrint;
        }
        private static string GetHash(string s)
        {
            MD5 sec = new MD5CryptoServiceProvider();
            ASCIIEncoding enc = new ASCIIEncoding();
            byte[] bt = enc.GetBytes(s);
            return GetHexString(sec.ComputeHash(bt));
        }
        private static string GetHexString(byte[] bt)
        {
            string s = string.Empty;
            for (int i = 0; i < bt.Length; i++)
            {
                byte b = bt[i];
                int n, n1, n2;
                n = (int)b;
                n1 = n & 15;
                n2 = (n >> 4) & 15;
                if (n2 > 9)
                    s += ((char)(n2 - 10 + (int)'A')).ToString();
                else
                    s += n2.ToString();
                if (n1 > 9)
                    s += ((char)(n1 - 10 + (int)'A')).ToString();
                else
                    s += n1.ToString();
                if ((i + 1) != bt.Length && (i + 1) % 2 == 0) s += "-";
            }
            return s;
        }
        #region HashPASSWORD
        public static string HashPass(string password)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            sha.ComputeHash(ASCIIEncoding.ASCII.GetBytes(password));
            byte[] result = sha.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        #endregion


        #region Original Device ID Getting Code

        private static string identifier(string wmiClass, string wmiProperty, string wmiMustBeTrue)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {
                if (mo[wmiMustBeTrue].ToString() == "True")
                {

                    if (result == "")
                    {
                        try
                        {
                            result = mo[wmiProperty].ToString();
                            break;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            return result;
        }

        private static string identifier(string wmiClass, string wmiProperty)
        {
            string result = "";
            System.Management.ManagementClass mc = new System.Management.ManagementClass(wmiClass);
            System.Management.ManagementObjectCollection moc = mc.GetInstances();
            foreach (System.Management.ManagementObject mo in moc)
            {

                if (result == "")
                {
                    try
                    {
                        result = mo[wmiProperty].ToString();
                        break;
                    }
                    catch
                    {
                    }
                }
            }
            return result;
        }
        private static string cpuId()
        {
            string retVal = identifier("Win32_Processor", "UniqueId");
            if (retVal == "")
            {
                retVal = identifier("Win32_Processor", "ProcessorId");
                if (retVal == "")
                {
                    retVal = identifier("Win32_Processor", "Name");
                    if (retVal == "")
                    {
                        retVal = identifier("Win32_Processor", "Manufacturer");
                    }

                    retVal += identifier("Win32_Processor", "MaxClockSpeed");
                }
            }
            return retVal;
        }

        private static string biosId()
        {
            return identifier("Win32_BIOS", "Manufacturer")
            + identifier("Win32_BIOS", "SMBIOSBIOSVersion")
            + identifier("Win32_BIOS", "IdentificationCode")
            + identifier("Win32_BIOS", "SerialNumber")
            + identifier("Win32_BIOS", "ReleaseDate")
            + identifier("Win32_BIOS", "Version");
        }

        private static string diskId()
        {
            return identifier("Win32_DiskDrive", "Model")
            + identifier("Win32_DiskDrive", "Manufacturer")
            + identifier("Win32_DiskDrive", "Signature")
            + identifier("Win32_DiskDrive", "TotalHeads");
        }

        private static string baseId()
        {
            return identifier("Win32_BaseBoard", "Model")
            + identifier("Win32_BaseBoard", "Manufacturer")
            + identifier("Win32_BaseBoard", "Name")
            + identifier("Win32_BaseBoard", "SerialNumber");
        }

        private static string videoId()
        {
            return identifier("Win32_VideoController", "DriverVersion")
            + identifier("Win32_VideoController", "Name");
        }

        private static string macId()
        {
            return identifier("Win32_NetworkAdapterConfiguration", "MACAddress", "IPEnabled");
        }
        #endregion

        #endregion

        private void logInButton48_Click_1(object sender, EventArgs e)
        {
            
        }
        private void logInNormalTextBox22_Click(object sender, EventArgs e)
        {

        }

        private void logInCheckBox9_CheckedChanged_1(object sender)
        {
            if (logInCheckBox9.Checked)
            {
                Cbuf_AddTextMP("ds_serverConnectTimeout 1000");
                Cbuf_AddTextMP("ds_serverConnectTimeout 1");
                Cbuf_AddTextMP("party_minplayers 1");
                Cbuf_AddTextMP("party_maxplayers 2");
                Cbuf_AddTextMP("pt_searchConnectAttempts 1");
                Cbuf_AddTextMP("pt_connectAttempts 1");
                Cbuf_AddTextMP("pt_connectTimeout 1");
            }
            else
            {
               // Cbuf_AddTextMP("g_knockback 1000");
            }
        }
        private void logInRadioButton5_CheckedChanged(object sender)
        {
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboB_Procs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void logInGroupBox19_Click(object sender, EventArgs e)
        {

        }

        private void tabPage11_Click(object sender, EventArgs e)
        {

        }

        private void logInButton48_Click_2(object sender, EventArgs e)
        {
           
        }

        private void logInGroupBox29_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void logInRadioButton6_CheckedChanged(object sender)
        {
            PS3.ChangeAPI(SelectAPI.PS3MAPI);
        }

        private void logInButton55_Click(object sender, EventArgs e)
        {
       
        }
        bool correct = false;
        private void logInButton56_Click(object sender, EventArgs e)
        {
            try
            {
                if (!logInCheckBox15.Checked && !logInCheckBox14.Checked)
                {
                    correct = false;
                    MessageBox.Show("Please select 'Multiplayer' or 'Zombie' !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (correct == true)
                {
                    if (PS3.AttachProcess())
                    {
                        logInStatusBar1.Text = "Playstation 3 : Connected & Process Attached !";
                        //PS3.SetMemory(0x37EF8BDE + 0x100, Enumerable.Repeat((byte)0x01, 0x50).ToArray());
                        timer1.Start();
                        if (logInCheckBox14.Checked)
                        {
                            PS3.SetMemory(0xCC5A8, new byte[] { 0x2c, 0x14, 0x00, 0x01 });
                            PS3.Extension.WriteString(0x00A544E8, "\n\n\n\n\n\n\n\n\n\n^1MrNiato");
                            timer3.Start();
                        }
                        if (logInCheckBox15.Checked)
                        {
                            byte[] buffer = new byte[] { 1 };
                            PS3.SetMemory(0xc7b1b, buffer);
                            PS3.Extension.WriteString(0xa46248, "\n\n\n\n\n\n\n\n\n\n\n\n^1MrNiato");
                        }
                        MessageBox.Show("Process Attached !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error while attach process !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (correct == false)
                {

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error while attach process !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            PS3.SetMemory(0xCC5A8, new byte[] { 0x2c, 0x14, 0x00, 0x01 });
            PS3.Extension.WriteString(0x00A544E8, "\n\n\n\n\n\n\n\n\n\n^1MrNiato");
        }

        private void txtB_Port_Click(object sender, EventArgs e)
        {

        }

        private void logInRadioButton7_CheckedChanged(object sender)
        {
            PS3.SetMemory(0x7C4148, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7C4050, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7C4758, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7C4660, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            byte[] buffer = new byte[4];
            buffer[0] = 0x60;
            PS3.SetMemory(0x7c4148, buffer);
            byte[] buffer2 = new byte[4];
            buffer2[0] = 0x60;
            PS3.SetMemory(0x7c4050, buffer2);
            byte[] buffer3 = new byte[4];
            buffer3[0] = 0x60;
            PS3.SetMemory(0x55705c, buffer3);
            byte[] buffer4 = new byte[4];
            buffer4[0] = 0x60;
            PS3.SetMemory(0x5570fc, buffer4);
            byte[] buffer5 = new byte[4];
            buffer5[0] = 0x60;
            PS3.SetMemory(0x4ac9c0, buffer5);
            byte[] buffer6 = new byte[4];
            buffer6[0] = 0x60;
            PS3.SetMemory(0x4aad20, buffer6);
        }

        private void logInRadioButton6_CheckedChanged_1(object sender)
        {
            PS3.SetMemory(0x7B68E4, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7B68EC, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7B6910, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7B6918, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7B692C, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7B61A4, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7B61B4, new byte[] { 0x60, 0x00, 0x00, 0x00 });
            PS3.SetMemory(0x7B61CC, new byte[] { 0x60, 0x00, 0x00, 0x00 });
        }

        private void logInCheckBox15_CheckedChanged(object sender)
        {
            if (logInCheckBox15.Checked)
            {
                logInCheckBox14.Checked = false;
                correct = true;
            }
        }

        private void logInCheckBox14_CheckedChanged(object sender)
        {
            if (logInCheckBox14.Checked)
            {
                logInCheckBox15.Checked = false;
                correct = true;
            }
        }
        private void Center(int client, string input)
        {
            object[] parameters = new object[] { 0, client, "< \"" + input + "\"" };
            CallMP(0x5ec544, parameters);
        }
        private void logInButton48_Click_3(object sender, EventArgs e)
        {
            Center(-1, logInNormalTextBox21.Text);
        }

        private void logInGroupBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Random randNum = new Random();
                firefoxNumericUpDown1.Value = randNum.Next(11, 16);
                firefoxNumericUpDown3.Value = randNum.Next(2147483645, 2147483647);
                firefoxNumericUpDown4.Value = randNum.Next(2147483645, 2147483647);
                firefoxNumericUpDown5.Value = randNum.Next(2147483645, 2147483647);
                firefoxNumericUpDown6.Value = randNum.Next(2147483645, 2147483647);
                firefoxNumericUpDown7.Value = randNum.Next(2147483645, 2147483647);
                firefoxNumericUpDown10.Value = randNum.Next(0, 55);
                firefoxNumericUpDown9.Value = randNum.Next(0, 24);
                firefoxNumericUpDown11.Value = randNum.Next(0, 60);
                logInNumeric26.Value = randNum.Next(2147483645, 2147483647);
                logInNumeric27.Value = randNum.Next(2147483645, 2147483647);
                logInNumeric28.Value = randNum.Next(2147483645, 2147483647);
                logInNumeric29.Value = randNum.Next(2147483645, 2147483647);
                logInNumeric30.Value = randNum.Next(2147483645, 2147483647);
                logInNumeric31.Value = randNum.Next(2147483645, 2147483647);
                logInNumeric32.Value = randNum.Next(2147483645, 2147483647);
            }
            else
            {
                Random randNum = new Random();
                firefoxNumericUpDown1.Value = randNum.Next(0, 11);
                firefoxNumericUpDown3.Value = randNum.Next(1, 100000);
                firefoxNumericUpDown4.Value = randNum.Next(1, 100000);
                firefoxNumericUpDown5.Value = randNum.Next(1, 100000);
                firefoxNumericUpDown6.Value = randNum.Next(1, 100000);
                firefoxNumericUpDown7.Value = randNum.Next(1, 100000);
                firefoxNumericUpDown10.Value = randNum.Next(0, 55);
                firefoxNumericUpDown9.Value = randNum.Next(0, 24);
                firefoxNumericUpDown11.Value = randNum.Next(0, 60);
                logInNumeric26.Value = randNum.Next(1, 100000);
                logInNumeric27.Value = randNum.Next(1, 100000);
                logInNumeric28.Value = randNum.Next(1, 100000);
                logInNumeric29.Value = randNum.Next(1, 100000);
                logInNumeric30.Value = randNum.Next(1, 100000);
                logInNumeric31.Value = randNum.Next(1, 100000);
                logInNumeric32.Value = randNum.Next(1, 100000);
            }
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory(0x18C42E8 + 0x5D03 + ((uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x01 });
                PS3.SetMemory(0x18C42E8 + 0x5DFE + ((uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00, 0xff });
                PS3.SetMemory(0x18C42E8 + 0x5D03 + ((uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void removeToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory(0x18C42E8 + 0x5D03 + ((uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00 });
                PS3.SetMemory(0x18C42E8 + 0x5DFE + ((uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x80, 0x00 });
            }
        }

        private void logInCheckBox16_CheckedChanged(object sender)
        {
            if (logInCheckBox16.Checked)
            {
                byte[] buffer = new byte[] { 0x40, 0xff };
                PS3.SetMemory(0x25ef020, buffer);
            }
            else
            {
                byte[] buffer = new byte[] { 0x00, 0x00 };
                PS3.SetMemory(0x25ef020, buffer);
            }
        }

        private void logInCheckBox17_CheckedChanged(object sender)
        {
            if (logInCheckBox17.Checked)
            {
                PS3.SetMemory(0x75bbc7, new byte[1]);
            }
            else
            {
                byte[] buffer = new byte[] { 2 };
                PS3.SetMemory(0x75bbc7, buffer);
            }
        }

        private void waterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            byte[] buffer = new byte[] { 1 };
            PS3.SetMemory(0x25e5660, buffer);
        }

        private void giveToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            //0x18C42F8 x2 jump
            //0x18C42Fc Skate mods
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C42F8 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x0A });
            }
        }

        private void removeToolStripMenuItem8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C42F8 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void giveToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C42Fc + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x02 });
            }
        }

        private void removeToolStripMenuItem9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C42Fc + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void logInCheckBox18_CheckedChanged(object sender)
        {
            if (logInCheckBox17.Checked)
            {
                byte[] buffer = new byte[4];
                buffer[0] = 0x60;
                PS3.SetMemory(0x18b3a0, buffer);
            }
            else
            {
                PS3.SetMemory(0x18b3a0, new byte[] { 0x48, 0x5e, 0xe4, 0xc9 });
            }
        }

        private void weevilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x0B });
            }
        }

        private void razorbackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x0D });
            }
        }

        private void hyèneKudaAmélioréeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x0F });
            }
        }

        private void iCR1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x1A });
            }
        }

        private void kN44ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x1C });
            }
        }

        private void m8A7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x1E });
            }
        }

        private void sheivaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x20 });
            }
        }

        private void hVK30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x22 });
            }
        }

        private void manOWarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x24 });
            }
        }

        private void xR2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x26 });
            }
        }

        private void vengeurConsacréKN44AmélioréeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x28 });
            }
        }

        private void kRM262ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C45F3 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x33 });
            }
        }

        private void giveToolStripMenuItem6_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C42F8 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x00 });
            }
        }

        private void removeToolStripMenuItem7_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < 0x12; i++)
            {
                PS3.SetMemory((0x18C42F8 + (uint)listBox6.SelectedIndex * 0x61E0), new byte[] { 0x0A });
            }
        }

        private void logInButton38_Click(object sender, EventArgs e)
        {
            string myString = logInNormalTextBox9.Text;
            int index = gobblegumzm.FindString(myString, -1);
            if (index != -1)
            {
                weaponszm.SetSelected(index, true);
                label26.Text = "Found the item \"" + myString + "\" at index: " + index + "";

            }
            else
                MessageBox.Show("Item not found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}