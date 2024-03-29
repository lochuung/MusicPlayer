﻿using System;
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
            Application.Run(new FormUser());

            // ZingMp3Api api = new ZingMp3Api();
            // var result = ZingMp3ApiUtils.GetSong(api, "Z7Z7A7F0");
            // Console.WriteLine(result);
        }
    }
}