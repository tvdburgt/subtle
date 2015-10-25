using Subtle.Model;

namespace Subtle.Registry
{
    class Program
    {
        static void Main(string[] args)
        {
            //foreach (var type in FileTypes.VideoTypes)
            //{
            //    var key = $@"HKEY_CLASSES_ROOT\.{type}";
            //    var val = Microsoft.Win32.Registry.GetValue(key, null, "(not found)");
            //    Console.WriteLine($"{key} => {val}");
            //}

            RegistryHelper.SetShellCommands(
                FileTypes.VideoTypes,
                @"C:\Program Files (x86)\Subtle\Subtle.exe",
                @"C:\Program Files (x86)\Subtle\Subtle.ico");
        }
    }
}
