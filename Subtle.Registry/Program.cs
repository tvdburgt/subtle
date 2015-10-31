using Subtle.Model;

namespace Subtle.Registry
{
    class Program
    {
        static void Main(string[] args)
        {
            RegistryHelper.SetShellCommands(
                FileTypes.VideoTypes,
                Installer.VerbKey,
                Installer.VerbValue,
                @"C:\Program Files (x86)\Subtle\Subtle.exe",
                @"C:\Program Files (x86)\Subtle\Subtle.ico");

           // RegistryHelper.DeleteShellCommands(FileTypes.VideoTypes, Installer.VerbKey);
        }
    }
}
