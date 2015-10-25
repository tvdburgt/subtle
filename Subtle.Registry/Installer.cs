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
        public Installer()
        {
            InitializeComponent();
        }

        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            if (!Context.Parameters.ContainsKey("targetdir"))
            {
                throw new InstallException("Missing 'targetdir' parameter");
            }

            var targetDir = Context.Parameters["targetdir"].TrimEnd(Path.DirectorySeparatorChar);
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