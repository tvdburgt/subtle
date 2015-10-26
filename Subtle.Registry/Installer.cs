using Subtle.Model;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;

namespace Subtle.Registry
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        private const string TargetDirKey = "targetdir";

        public Installer()
        {
            InitializeComponent();
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            if (!Context.Parameters.ContainsKey(TargetDirKey))
            {
                throw new InstallException($"Missing '{TargetDirKey}' parameter");
            }

            var targetDir = Context.Parameters[TargetDirKey].TrimEnd(Path.DirectorySeparatorChar);
            RegistryHelper.SetShellCommands(
                FileTypes.VideoTypes,
                Path.Combine(targetDir, "Subtle.exe"),
                Path.Combine(targetDir, "Subtle.ico"));
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
            //RegistryHelper.DeleteShellCommands(FileTypes.VideoTypes);
        }
    }
}