using System;
using Subtle.Model;

namespace Subtle.Registry
{
    class Program
    {
        static void Main(string[] args)
        {
            ShellCommandHelper.DeleteShellCommands(
                FileTypes.VideoTypes,
                Installer.VerbKey);

            //ShellCommandHelper.SetShellCommands(
            //    FileTypes.VideoTypes,
            //    Installer.VerbKey,
            //    Installer.VerbValue,
            //    @"C:\Program Files (x86)\Subtle\subtle.exe",
            //    @"C:\Program Files (x86)\Subtle\subtle.ico");

            Console.ReadLine();
        }
    }
}
