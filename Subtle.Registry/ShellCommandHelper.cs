using System;
using System.Collections.Generic;

namespace Subtle.Registry
{
    using Microsoft.Win32;

    public static class ShellCommandHelper
    {
        public static void SetShellCommands(IEnumerable<string> fileTypes, string verbKey, string verbValue, string command, string icon = null)
        {
            // Clean up legacy registry keys
            RegistryHelper.DeleteShellCommands(fileTypes, verbKey);

            foreach (var type in fileTypes)
            {
                using (var key = Registry.ClassesRoot.OpenSubKey($@"SystemFileAssociations\.{type}", true))
                {
                    if (key == null)
                    {
                        Console.WriteLine($@" [?] {Registry.ClassesRoot}\SystemFileAssociations\.{type}");
                        continue;
                    }

                    using (var shell = key.CreateSubKey("shell"))
                    using (var verb = shell.CreateSubKey(verbKey))
                    using (var cmd = verb.CreateSubKey("command"))
                    {
                        verb.SetValue(null, verbValue);
                        cmd.SetValue(null, $@"""{command} ""%1""");

                        if (!string.IsNullOrEmpty(icon))
                        {
                            verb.SetValue("Icon", $@"""{icon}""");
                        }
                    }

                    Console.WriteLine($" [+] {key}");
                }
            }
        }

        public static void DeleteShellCommands(IEnumerable<string> fileTypes, string verbKey)
        {
            // Clean up legacy registry keys
            RegistryHelper.DeleteShellCommands(fileTypes, verbKey);

            foreach (var type in fileTypes)
            {
                using (var key = Registry.ClassesRoot.OpenSubKey($@"SystemFileAssociations\.{type}", true))
                {
                    if (key == null)
                    {
                        Console.WriteLine($@" [?] {Registry.ClassesRoot}\SystemFileAssociations\.{type}");
                        continue;
                    }

                    try
                    {
                        key.DeleteSubKeyTree($@"shell\{verbKey}");
                        Console.WriteLine($" [-] {key}");
                    }
                    catch (ArgumentException)
                    {
                        Console.WriteLine($" [=] {key}");
                    }
                }
            }
        }
    }
}
