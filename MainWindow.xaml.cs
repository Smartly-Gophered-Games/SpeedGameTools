using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;
using System.IO;

namespace SpeedGameTools
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenLauncher_Click(object sender, RoutedEventArgs e)
        {
            System.IO.Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "SpeedGame";
            dialog.DefaultExt = ".exe";
            dialog.Filter = "Executable file (.exe)|*.exe";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
            }
        }

        private void OpenGameFromSteam_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "steam://run/1863910",
                UseShellExecute = true
            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Unused");
        }

        private async void GenerateParamsForGame_IniForDediServer_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory("SpeedGameTools/GeneratedFiles/GeneratedParams/DediServer/GameIni/");
            var path = "SpeedGameTools/GeneratedFiles/GeneratedParams/DediServer/GameIni/AddParamsToGameIniDediServer.txt";

            string[] lines = { 
                "[/Game/Data/Code/GameInstances/Main_GameInstance.Main_GameInstance_C]",
                "DSPlayersMax=32",
                "VAC=True",
                "Presence=True",
                "LANOnly=False",
                "SteamGroupID="};
            File.WriteAllLines(path, lines);
        }

        private async void GenerateParamsForEngine_IniForDediServer_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory("SpeedGameTools/GeneratedFiles/GeneratedParams/DediServer/EngineIni/");
            var path = "SpeedGameTools/GeneratedFiles/GeneratedParams/DediServer/EngineIni/AddParamsToEngineIniDediServer.txt";

            string[] lines = { 
                "[/Game/Data/Code/PlayerNameSystem/Blueprints/BP_PlayerNameComponent.BP_PlayerNameComponent_C]", 
                "ShowOwnPlayerName?=False", 
                "ShowRank?=False",
                "",
                "[/Script/EngineSettings.GameMapsSettings]",
                "ServerDefaultMap=/Game/Data/Levels/Map02/Map02_WP.Map02_WP" };
            File.WriteAllLines(path, lines);
        }

        private async void GenerateServerShortcutLaunchParam_Click(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory("SpeedGameTools/GeneratedFiles/GeneratedParams/DediServer/ShortcutLaunchParam/");
            var path = "SpeedGameTools/GeneratedFiles/GeneratedParams/DediServer/ShortcutLaunchParam/ShortcutLaunchParam.txt";

            string[] lines = {
                "-log \"-SteamServerName=Default Project Speed 2 Server\" -port=26900",
                "", };
            File.WriteAllLines(path, lines);
        }
    }
}