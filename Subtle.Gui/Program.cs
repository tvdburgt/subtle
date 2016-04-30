using System;
using AutoMapper;
using Octokit;
using Subtle.Model;
using Application = System.Windows.Forms.Application;
using Subtle.Model.Mapping;

namespace Subtle.Gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            var osdbClient = new OSDbClient(OSDbClient.TestUserAgent);
#else
            var osdbClient = new OSDbClient();
#endif
            var githubClient = new GitHubClient(new ProductHeaderValue(Application.ProductName, Application.ProductVersion));

            Mapper.Initialize(cfg => cfg.AddProfile<OSDbProfile>());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(osdbClient, githubClient));
        }
    }
}
