using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Subtle.Registry
{
    using Microsoft.Win32;

    public static class RegistryHelper
    {
        public static void SetShellCommands(IEnumerable<string> fileTypes, string verbKey, string verbValue, string command, string icon = null)
        {
            File.Delete(Path.Combine(Path.GetTempPath(), "subtle.log"));

            foreach (var progId in GetProgIds(fileTypes))
            {
                Registry.SetValue(
                    $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\{verbKey}",
                    null,
                    verbValue);

                Registry.SetValue(
                    $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\{verbKey}\command",
                    null,
                    $@"""{command}"" ""%1""");

                if (!string.IsNullOrEmpty(icon))
                {
                    Registry.SetValue(
                        $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\{verbKey}",
                        "Icon",
                        $@"""{icon}""");
                }

                File.AppendAllLines(
                    Path.Combine(Path.GetTempPath(), "subtle.log"),
                    new[] { $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\{verbKey}" });
            }
        }

        public static void DeleteShellCommands(IEnumerable<string> fileTypes, string verbKey)
        {
            foreach (var subKey in GetProgIds(fileTypes).Select(id => $@"SOFTWARE\Classes\{id}\shell"))
            {
                using (var key = Registry.CurrentUser.OpenSubKey(subKey, true))
                {
                    if (key?.OpenSubKey(verbKey) != null)
                    {
                        key.DeleteSubKeyTree(verbKey);
                    }
                }
            }
        }

        private static IEnumerable<string> GetProgIds(IEnumerable<string> types)
        {
            return types
                .Select(ext => (string)Registry.GetValue($@"HKEY_CURRENT_USER\SOFTWARE\Classes\.{ext}", null, null))
                .Where(progId => progId != null);
        }
    }
}
