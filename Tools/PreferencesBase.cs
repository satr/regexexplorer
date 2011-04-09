using System.Xml.Serialization;

namespace RegexExplorer {
    public class PreferencesBase : StoredObject {
        protected static PreferencesBase _instance;
        protected int _version = 1;
        protected bool _toolBars = false;
        protected bool _confimOnExit = true;
        protected bool _confimOnDeletion = true;
        protected bool _advancedPreferences = false;
        protected string _lastLanguageName = LangBase.DEFAULT_LANGUAGE_NAME;

        public PreferencesBase() {
            InitFileNameBy("Preferences");
        }

        public static PreferencesBase Res {
            get {
                if (_instance == null)
                    new SafeCommonToolsException("Preferences are not initialized");
                return _instance;
            }
            set { _instance = value; }
        }

        public static void Close() {
            Res.Save();
        }

        public int Version {
            get { return GetIntValue(1, _version); }
            set { SetIntValue(1, value); }
        }
        public bool ToolBars {
            get { return GetBoolValue(2, _toolBars); }
            set { SetBoolValue(2, value); }
        }
        public bool ConfimOnExit {
            get { return GetBoolValue(3, _confimOnExit); }
            set { SetBoolValue(3, value); }
        }
        public bool ConfimOnDeletion {
            get { return GetBoolValue(4, _confimOnDeletion); }
            set { SetBoolValue(4, value); }
        }
        public bool AdvancedPreferences {
            get { return GetBoolValue(5, _advancedPreferences); }
            set { SetBoolValue(5, value); }
        }
        public string LastLanguageName {
            get { return GetStringValueTrim(6, _lastLanguageName); }
            set { SetStringValue(6, value); }
        }

        [XmlIgnore()]
        public bool AddNewCaptionsToResource {
            get { return LangBase.AddNewCaptionsToResource; }
            set { LangBase.AddNewCaptionsToResource = value; }
        }
    }
}