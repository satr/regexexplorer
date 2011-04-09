using System.Windows.Forms;

namespace RegexExplorer {
    public class StatusBarController {
        private static StatusBar _statusBar;

        public StatusBarController(StatusBar statusBar) {
            _statusBar = statusBar;
        }

        public void ShowMessage(string message) {
            if (_statusBar == null)
                return;
            _statusBar.Text = message;
        }

        public void ShowMessage(string formattedMessage, params object[] args) {
            ShowMessage(string.Format(formattedMessage, args));
        }

        public void ClearMessage() {
            ShowMessage(string.Empty);
        }
    }
}