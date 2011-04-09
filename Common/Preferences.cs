using RegexExplorer;

namespace RegexExplorer {
    public class Preferences : PreferencesBase {
        protected static readonly int MIN_LENGTH_OF_FILE_TO_SHOW_LOADING_FORM = 100000;
        protected static readonly int MAX_RECENT_FILES_QUANTITY = 20;
        protected static readonly int MAX_REGEX_PATTERN_HISTORY_LENGTH = 50;
        protected static readonly int MAX_REGEX_PATTERN_FAVORITES_LENGTH = 0;

        #region Properties

        protected bool _regexOptions = false;
        protected bool _highlightResultsInList = false;
        protected bool _keepTextAfterAddition = false;
        protected int _scaleRateIndex = 0;
        protected string _initialListFolder;
        protected string _initialOpenFileFolder;
        protected decimal _minLengthOfFileToShowLoadingForm = MIN_LENGTH_OF_FILE_TO_SHOW_LOADING_FORM;
        protected int _maxRecentFilesQuantity = MAX_RECENT_FILES_QUANTITY;
        protected int _maxRegexPatternFavoritesLength = MAX_REGEX_PATTERN_FAVORITES_LENGTH;
        protected int _maxRegexPatternHistoryLength = MAX_REGEX_PATTERN_HISTORY_LENGTH;
        protected bool _showOpenFileDialog = true;
        protected bool _regexPatternsResultIsVisible = false;
        protected bool _regexPatternsDescriptionIsVisible = false;
        protected bool _replaceDoublicatedPatternsInHistory = false;
        protected bool _showAllRegexPatternsTabs = false;
        protected bool _showAllMatchesFileItemsTabs = false;
        protected bool _showAllModesTabs = false;
        protected int _lastActiveModeAsInt = 0;
        protected string _lastLanguageFileName = LangBase.DEFAULT_FILE_NAME;
        protected string _licenseKey = string.Empty;

        public bool ReplaceDoublicatedPatternsInHistory {
            get { return GetBoolValue(100, _replaceDoublicatedPatternsInHistory); }
            set { SetBoolValue(100, value); }
        }

        public bool ShowAllRegexPatternsTabs {
            get { return GetBoolValue(101, _showAllRegexPatternsTabs); }
            set { SetBoolValue(101, value); }
        }

        public bool ShowAllMatchesFileItemsTabs {
            get { return GetBoolValue(102, _showAllMatchesFileItemsTabs); }
            set { SetBoolValue(102, value); }
        }

        public decimal MinLengthOfFileToShowLoadingForm {
            get { return GetDecimalValue(103, _minLengthOfFileToShowLoadingForm); }
            set { SetDecimalValue(103, value); }
        }

        public bool RegexOptions {
            get { return GetBoolValue(104, _regexOptions); }
            set { SetBoolValue(104, value); }
        }

        public bool HighlightResultsInList {
            get { return GetBoolValue(105, _highlightResultsInList); }
            set { SetBoolValue(105, value); }
        }

        public bool KeepTextAfterAddition {
            get { return GetBoolValue(106, _keepTextAfterAddition); }
            set { SetBoolValue(106, value); }
        }

        public int ScaleIndex {
            get { return GetIntValue(107, _scaleRateIndex); }
            set { SetIntValue(107, value); }
        }

        public string InitialListFolder {
            get { return GetStringValueTrim(108, _initialListFolder); }
            set { SetStringValue(108, value); }
        }

        public string InitialOpenFileFolder {
            get { return GetStringValueTrim(109, _initialOpenFileFolder); }
            set { SetStringValue(109, value); }
        }

        public bool ShowOpenFileDialog {
            get { return GetBoolValue(110, _showOpenFileDialog); }
            set { SetBoolValue(110, value); }
        }

        public int MaxRecentFilesQuantity {
            get { return GetIntValue(111, _maxRecentFilesQuantity); }
            set { SetIntValue(111, value); }
        }

        public bool RegexPatternsDescriptionIsVisible {
            get { return GetBoolValue(112, _regexPatternsDescriptionIsVisible); }
            set { SetBoolValue(112, value); }
        }

        public int MaxRegexPatternHistoryLength {
            get { return GetIntValue(113, _maxRegexPatternHistoryLength); }
            set { SetIntValue(113, value); }
        }

        public int MaxRegexPatternFavoritesLength {
            get { return GetIntValue(114, _maxRegexPatternFavoritesLength); }
            set { SetIntValue(114, value); }
        }

        public bool ShowAllModesTabs {
            get { return GetBoolValue(115, _showAllModesTabs); }
            set { SetBoolValue(115, value); }
        }

        public int LastActiveModeAsInt {
            get { return GetIntValue(116, _lastActiveModeAsInt); }
            set { SetIntValue(116, value); }
        }

        public string LastLanguageFileName {
            get { return GetStringValueTrim(117, _lastLanguageFileName); }
            set { SetStringValue(117, value); }
        }

        public string LicenseKey {
            get { return GetStringValueTrim(118, _licenseKey); }
            set { SetStringValue(118, value); }
        }

        public bool RegexPatternsResultIsVisible {
            get { return GetBoolValue(119, _regexPatternsResultIsVisible); }
            set { SetBoolValue(119, value); }
        }

        #endregion

        public static void Init() {
            Res = (Preferences) new Preferences().Load();
        }

        new public static Preferences Res {
            get {
                if (_instance == null)
                    Init();
                if (_instance == null)
                    new SafeCommonToolsException("Preferences are not initialized");
                return (Preferences) _instance;
            }
            set { _instance = value; }
        }
    }
}