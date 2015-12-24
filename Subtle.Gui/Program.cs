using System;
using System.Windows.Forms;
using AutoMapper;
using Subtle.Gui.Mapping;

namespace Subtle.Gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<OSDbProfile>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
