using System;
using System.Windows.Forms;

namespace MusicPlayer
{
    internal static class Program
    {
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new View.SecurityCode());
=======
            Application.Run(new MusicPlayerForm());
>>>>>>> 0fce398abddbc293c9f68101b15940c24acdfb23

            // ZingMp3Api api = new ZingMp3Api();
            // var result = ZingMp3ApiUtils.GetSongInfo(api, "Z7Z7A7F0");
            // Console.WriteLine(result);
        }
    }
}