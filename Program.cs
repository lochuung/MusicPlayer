using System;
using MusicPlayer.MusicApi;
using MusicPlayer.Utils;

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
            var api = new ZingMp3Api();
            var response = ZingMp3ApiUtils.GetSong(api, "Z7U00WDE");
            Console.WriteLine(response);

            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new Form1());
        }
    }
}