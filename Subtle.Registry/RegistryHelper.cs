using System.Collections.Generic;
using System.Linq;

namespace Subtle.Registry
{
    using Microsoft.Win32;

    public static class RegistryHelper
    {
        private const string VerbKey = "dlsub";
        private const string VerbName = "Download subtitle";

        public static void SetShellCommands(IEnumerable<string> fileTypes, string command, string icon = null)
        {
            foreach (var progId in GetProgIds(fileTypes))
            {
                Registry.SetValue(
                    $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\{VerbKey}",
                    null,
                    VerbName);

                Registry.SetValue(
                    $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\{VerbKey}\command",
                    null,
                    $@"""{command}"" ""%1""");

                if (!string.IsNullOrEmpty(icon))
                {
                    Registry.SetValue(
                        $@"HKEY_CURRENT_USER\SOFTWARE\Classes\{progId}\shell\{VerbKey}",
                        "Icon",
                        $@"""{icon}""");
                }
            }
        }

        public static void DeleteShellCommands(IEnumerable<string> fileTypes)
        {
            foreach (var progId in GetProgIds(fileTypes))
            {
                var subKey = $@"SOFTWARE\Classes\{progId}\dlsub";
                using (var key = Registry.CurrentUser.OpenSubKey(subKey))
                {
                    key?.DeleteSubKey("dlsub");
                }
            }
        }

        private static IEnumerable<string> GetProgIds(IEnumerable<string> types)
        {
            return types
                .Select(ext => (string)Registry.GetValue($@"HKEY_CLASSES_ROOT\.{ext}", null, null))
                .Where(progId => progId != null);
        }
    }
}
