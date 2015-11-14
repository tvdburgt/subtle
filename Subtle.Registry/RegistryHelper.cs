using System;
using System.Collections.Generic;
using System.Linq;

namespace Subtle.Registry
{
    using Microsoft.Win32;

    [Obsolete]
    public static class RegistryHelper
    {
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
