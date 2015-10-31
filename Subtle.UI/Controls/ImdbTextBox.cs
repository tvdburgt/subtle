using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Subtle.UI.Controls
{
    public class ImdbTextBox : TextBox
    {
        // ReSharper disable once InconsistentNaming
        private const int WM_PASTE = 0x0302;

        private static readonly Regex ImdbRegex = new Regex(@"tt(\d{7})");

        /// <summary>
        /// Handles paste event and tries to extract IMDb ID.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg != WM_PASTE)
            {
                base.WndProc(ref m);
                return;
            }

            var match = ImdbRegex.Match(Clipboard.GetText());
            if (match.Success)
            {
                Text = match.Groups[1].Value;
            }
        }
    }
}