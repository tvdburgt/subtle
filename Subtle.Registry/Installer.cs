using Subtle.Model;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;

namespace Subtle.Registry
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public const string VerbKey = "dlsub";
        public const string VerbValue = "Download subtitle";
        private const string TargetDirKey = "targetdir";

        public Installer()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary savedState)
        {
            base.Install(savedState);

            if (!Context.Parameters.ContainsKey(TargetDirKey))
            {
                throw new InstallException($"Missing '{TargetDirKey}' parameter.");
            }

            var targetDir = Context.Parameters[TargetDirKey].TrimEnd(Path.DirectorySeparatorChar);
            ShellCommandHelper.SetShellCommands(
                FileTypes.VideoTypes,
                VerbKey,
                VerbValue,
                Path.Combine(targetDir, "subtle.exe"),
                Path.Combine(targetDir, "subtle.ico"));
        }

        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
            ShellCommandHelper.DeleteShellCommands(FileTypes.VideoTypes, VerbKey);
        }
    }
}