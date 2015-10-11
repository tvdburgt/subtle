using Subtle.Model;

namespace Subtle.Registry
{
    using Microsoft.Win32;

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


            foreach (var ext in FileTypes.VideoTypes)
            {
                var progId = Registry.GetValue($@"HKEY_CLASSES_ROOT\.{ext}", null, null);

                if (progId == null)
                {
                    continue;
                }

                Registry.SetValue(
                    $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\dlsub",
                    null,
                    "Download subtitle");

                Registry.SetValue(
                    $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\dlsub\command",
                    null,
                    @"""D:\src\Subtle\Subtle.UI\bin\Debug\Subtle.UI.exe"" ""%1""");
            }

            //Console.ReadLine();
        }
    }
}
