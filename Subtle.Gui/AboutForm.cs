using System.Windows.Forms;
using Octokit;
using Subtle.Model;
using Application = System.Windows.Forms.Application;

namespace Subtle.Gui
{
    public partial class AboutForm : Form
    {
        private const string RepositoryOwner = "tvdburgt";
        private const string RepositoryName = "subtle";
        private const string RepositoryUrl = "https://github.com/tvdburgt/subtle";

        private readonly OSDbClient osdbClient;
        private readonly IGitHubClient githubClient;

        public AboutForm(OSDbClient osdbClient, IGitHubClient githubClient)
        {
            this.osdbClient = osdbClient;
            this.githubClient = githubClient;
            InitializeComponent();

            LoadSubtleInfo();
            LoadServerInfo();
        }

        private async void LoadSubtleInfo()
        {
            siteLabel.Text = RepositoryUrl;
            siteLabel.Links[0].LinkData = RepositoryUrl;
            versionLabel.Text = $"v{Application.ProductVersion}";

            var releases = await githubClient.Release.GetAll(RepositoryOwner, RepositoryName);
            var latest = releases[0];

            latestVersionLabel.Text = $"{latest.TagName} ({latest.PublishedAt:d})";
            latestVersionLabel.Links[0].LinkData = latest.HtmlUrl;
        }

        private async void LoadServerInfo()
        {
            var info = await osdbClient.GetServerInfoAsync();

            apiLabel.Text = $"{info.ApiUrl} ({info.ApiVersion})";
            subtitleCountLabel.Text = $"{int.Parse(info.SubtitleCount):n0}";
            userCountLabel.Text = $"{info.OnlineUserCount:n0}";
            clientCountLabel.Text = $"{info.OnlineClientCount:n0}";
            subtitleQuotaLabel.Text = $"{info.DownloadQuota.Remaining:n0} (of {info.DownloadQuota.Limit:n0})";
            responseTimeLabel.Text = $"{info.ResponseTime.TotalSeconds:0.000}s";
            serverTimeLabel.Text = $"{info.ServerTime:0.000}s";
        }

        private void OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void versionLabel_Click(object sender, System.EventArgs e)
        {

        }
    }
}
