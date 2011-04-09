using System.IO;
using System.Windows.Forms;

namespace RegexExplorer {
    public class HelpHolder {
        #region Constants

        private static string DEFAULT_HELP_FILE_FOLDER = "Help";
        private static string DEFAULT_HELP_FILE_EXT = "chm";

        #endregion

        #region Properties

        private HelpProvider _helpProvider;
        private Control _defaultControl;
        private string _defaultKeyword;
        private string _folderName = DEFAULT_HELP_FILE_FOLDER;
        private string _helpFileExt = DEFAULT_HELP_FILE_EXT;
        private string _filePath = null;

        #endregion

        public HelpHolder(HelpProvider helpProvider, Control defaultControl, string defaultKeyword) {
            _helpProvider = helpProvider;
            _defaultControl = defaultControl;
            _defaultKeyword = defaultKeyword;
        }

        public string FolderName {
            get { return _folderName; }
            set { _folderName = value; }
        }

        public string HelpFileExt {
            get { return _helpFileExt; }
            set { _helpFileExt = value; }
        }

        public void InitHelpProvider() {
            DirectoryInfo directoryInfo = new DirectoryInfo(_folderName);
            if (!directoryInfo.Exists)
                directoryInfo.Create();
            _filePath = null;
            string languageShortName = LangBase.CurrentLanguageShortName;
            if (InitHelpProviderFor(Path.Combine(directoryInfo.FullName, HelpFileName(languageShortName))))
                return;
            if (InitHelpProviderFor(Path.Combine(directoryInfo.FullName, HelpFileName(string.Empty))))
                return;
            Messenger.LogError(LangBase.Res.Help_file_in_folder_N_for_the_language_L_not_found, _folderName,
                               languageShortName);
            InitNullProvider();
        }

        private string HelpFileName(string languageShortName) {
            return string.Format("{0}Help.{1}", languageShortName, _helpFileExt);
        }

        private bool InitHelpProviderFor(string filePath) {
            if (!new FileInfo(filePath).Exists)
                return false;
            _filePath = filePath;
            InitNullProvider();
            _helpProvider.HelpNamespace = filePath;
            _helpProvider.SetHelpNavigator(_defaultControl, HelpNavigator.TableOfContents);
            _helpProvider.SetHelpKeyword(_defaultControl, _defaultKeyword);
            return true;
        }

        private void InitNullProvider() {
            if (_helpProvider != null)
                return;
            _helpProvider = new HelpProvider();
        }

        public void ShowHelp() {
            if (_filePath == null)
                return;
            Help.ShowHelp(_defaultControl, _filePath);
        }
    }
}