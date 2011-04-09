using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace RegexExplorer {

    public abstract class LangBase : DefaultMsgs {
        public static string DEFAULT_FOLDER_NAME = "Lang";
        public static string DEFAULT_LANGUAGE_NAME = "English";
        public static string RUSSIAN_LANGUAGE_NAME = "Russian";
        public static string RUSSIAN_LANGUAGE_SHORT_NAME = "Rus";
        public static string DEFAULT_FILE_NAME = GetFileNameByLanguageName(DEFAULT_LANGUAGE_NAME);
        protected static readonly string LANG_PAIR_TYPE_NAME = "lp";

        protected static Hashtable _dict = new Hashtable();
        protected static Hashtable _revertDict = new Hashtable();
        protected static bool _restoreMode = false;

        protected static Lang _languageInstance = null;

        protected static bool _addNewCaptionsToResource = false;
        protected static bool _addTextBoxContent = false;
        protected static bool _addListControlContent = false;
        protected static bool _addListViewContent = false;
        protected static bool _addStatusBarContent = false;
        protected static bool _addDomainUpDownContent = false;

        #region Active class part

        public LangBase() : base() {
            _fileName = DEFAULT_FILE_NAME;
            _folderName = DEFAULT_FOLDER_NAME;
            ClearLangPairs();
            _restoreMode = false;
        }

        public static bool IsDefault {
            get { return string.Compare(CurrentLanguageName, DEFAULT_LANGUAGE_NAME, true) == 0; }
        }

        public static Lang Res {
            get {
                if (_languageInstance == null)
                    Activate();
                return _languageInstance;
            }
        }

        public static Lang Activate(Lang defaultInstance) {
            try {
                _languageInstance = defaultInstance;
                string languageName = PreferencesBase.Res.LastLanguageName;
                if (languageName.Length > 0)
                    return LoadLanguage(languageName);
                return Activate();
            }
            catch (StoredObjectException ex) {
                Messenger.ShowError(ex);
            }
            catch (Exception ex) {
                Messenger.ShowError(ex);
            }
            return null;
        }

        public static Lang Activate() {
            return Activate(DEFAULT_LANGUAGE_NAME);
        }

        public static Lang Activate(string languageName) {
            if (_languageInstance != null && string.Compare(CurrentLanguageName, languageName, true) == 0)
                return _languageInstance;
            _languageInstance = new Msgs();
            return LoadLanguage(languageName);
        }

        public static void Close() {
            if (AddNewCaptionsToResource)
                Res.Save();
        }

        private static Lang LoadLanguage(string languageName) {
            string fileName = GetFileNameByLanguageName(languageName);
            ClearLangPairs();
            _languageInstance.Load(fileName);
            _languageInstance.FileName = fileName;

            return _languageInstance;
        }

        private static string GetFileNameByLanguageName(string languageName) {
            return languageName + STORED_OBJECTS_FILE_EXTENSION;
        }

        private static Hashtable Dict {
            get { return _dict; }
        }

        private static Hashtable RevertDict {
            get { return _revertDict; }
        }

        [XmlIgnore()]
        public static Hashtable SourceDict {
            get { return _restoreMode ? _revertDict : _dict; }
        }

        public static string GetActualTextFor(string originText) {
            string text = originText.Trim();
            AddOriginalTextIfNotExists(text);
            string actualText = (string) SourceDict[text];
            return (actualText != null) ? actualText : string.Empty;
        }

        private static void AddOriginalTextIfNotExists(string originText) {
            bool containsActualTextForOriginText = ContainsActualTextFor(originText);
            bool isInRestoreMode = Res.IsInRestoreMode;
            if (!isInRestoreMode && !containsActualTextForOriginText)
                SetActualTextFor(originText, originText);
        }

        public static bool ContainsActualTextFor(string originText) {
            return Dict.Contains(originText);
        }

        private bool IsInRestoreMode {
            get { return SourceDict == RevertDict; }
        }

        public static void SetActualTextFor(string originText, string actualText) {
            string origin = originText.Trim();
            string actual = actualText.Trim();
            if (origin.Length == 0 || actual.Length == 0)
                return;
            AddUpdateDictLangPairFor(origin, actual);
            AddUpdateRevertDictLangPairFor(actual, origin);
        }

        private static void AddUpdateDictLangPairFor(string origin, string actual) {
            AddUpdateLangPairFor(Dict, origin, actual);
        }

        private static void AddUpdateRevertDictLangPairFor(string origin, string actual) {
            AddUpdateLangPairFor(RevertDict, origin, actual);
        }

        private static void AddUpdateLangPairFor(Hashtable dict, string originText, string actualText) {
            dict[originText] = actualText;
        }

        public static void ClearLangPairs() {
            _dict = new Hashtable();
            _revertDict = new Hashtable();
        }

        #endregion

        #region Change UI language

        public static void ApplayLanguageFor(Form form) {
            ApplayLanguageFor(form, CurrentLanguageName);
        }

        private static void ApplayLanguageFor(Form form, string languageName) {
            SetNormalMode();
            Activate(languageName);
            ChangeFormLanguageFor(form);
        }

        public static void ChangeLanguageFor(Form form, string languageName) {
            string fileName = GetFileNameByLanguageName(languageName);
            if (CurrentFileNameIsEqual(fileName))
                return;
            if (!LanguageFileExists(fileName))
                throw new LanguageException(Res.File_with_language_resource_not_found,
                                            FilePathFor(fileName));
            form.SuspendLayout();
            RestoreDefaultLanguageFor(form);
            ApplayLanguageFor(form, languageName);
            form.Refresh();
            form.ResumeLayout();
        }

        private static void ChangeFormLanguageFor(Form form) {
            ControlText(form);
            if (form.Menu != null)
                CheckControlMenuItemsTexts(form.Menu.MenuItems);
            CheckControlContextMenu(form);
            CheckControlsTexts(form);
            Res.Save();
        }

        private static bool LanguageFileExists(string fileName) {
            return new FileInfo(FilePathFor(fileName)).Exists;
        }

        public static string FilePathFor(string fileName) {
            return Path.Combine(Res.FolderName, fileName);
        }

        public static string LanguageFilePathFor(string languageName) {
            return FilePathFor(GetFileNameByLanguageName(languageName));
        }

        public static bool CurrentFileNameIsEqual(FileInfo fileInfo) {
            return CurrentFileNameIsEqual((string) fileInfo.Name);
        }

        public static bool CurrentFileNameIsEqual(string fileName) {
            return string.Compare(fileName.Trim(), Res.FileName, true) == 0;
        }

        private static void RestoreDefaultLanguageFor(Form form) {
            SetRestoreMode();
            ChangeFormLanguageFor(form);
            SetNormalMode();
        }

        private static void CheckControlsTexts(Control sourceControl) {
            foreach (Control control in sourceControl.Controls) {
                ControlText(control);
                CheckControlsTexts(control);
                CheckControlContextMenu(control);
            }
        }

        private static void CheckControlContextMenu(Control control) {
            if (control.ContextMenu != null)
                CheckControlMenuItemsTexts(control.ContextMenu.MenuItems);
        }

        private static void CheckControlMenuItemsTexts(Menu.MenuItemCollection menuItemCollection) {
            foreach (MenuItem menuItem in menuItemCollection) {
                MenuItemText(menuItem);
                CheckControlMenuItemsTexts(menuItem.MenuItems);
            }
        }

        private static void MenuItemText(MenuItem menuItem) {
            menuItem.Text = GetActualTextFor(menuItem.Text);
        }

        private static void ControlText(Control control) {
            control.Text = GetActualTextFor(control.Text);
        }

        public static void SetRestoreMode() {
            _restoreMode = true;
        }

        public static void SetNormalMode() {
            _restoreMode = false;
        }

        public static string ExtractLanguageNameFrom(FileInfo fileInfo) {
            return ExtractLanguageNameFrom(fileInfo.Name.Trim());
        }

        public static string ExtractLanguageNameFrom(string fileName) {
            return GetFileNameWOExtension(fileName.Trim());
        }

        #endregion

        public static string CurrentLanguageName {
            get { return ExtractLanguageNameFrom(Res.FileName); }
        }

        public static string CurrentLanguageShortName {
            get {
                string currentLanguageName = CurrentLanguageName.ToLower();
                if(currentLanguageName == RUSSIAN_LANGUAGE_NAME.ToLower())
                    return RUSSIAN_LANGUAGE_SHORT_NAME;
                return string.Empty;
            }
        }
        public static string FullCurrentFilePath() {
            return Path.GetFullPath(FilePathFor(Res.FileName));
        }

        public static bool CheckNewTextEntriesBy(IDictionary textEntries) {
            IList newTextEntriesList = ExtractNewCaptionsIn(textEntries);
            foreach (string text in newTextEntriesList)
                AddUpdateDictLangPairFor(text, text);
            return newTextEntriesList.Count > 0;
        }

        private static IList ExtractNewCaptionsIn(IDictionary textEntries) {
            IList newTextEntriesList = new ArrayList();
            foreach (string text in textEntries.Keys) {
                if (!Dict.Contains(text))
                    newTextEntriesList.Add(text);
            }
            return newTextEntriesList;
        }

        #region Add language resources

        [XmlIgnore()]
        public static bool AddNewCaptionsToResource {
            get { return _addNewCaptionsToResource; }
            set { _addNewCaptionsToResource = value; }
        }

        [XmlIgnore()]
        public static bool AddTextBoxContent {
            get { return _addTextBoxContent; }
            set { _addTextBoxContent = value; }
        }

        [XmlIgnore()]
        public static bool AddListControlContent {
            get { return _addListControlContent; }
            set { _addListControlContent = value; }
        }

        [XmlIgnore()]
        public static bool AddListViewContent {
            get { return _addListViewContent; }
            set { _addListViewContent = value; }
        }

        [XmlIgnore()]
        public static bool AddStatusBarContent {
            get { return _addStatusBarContent; }
            set { _addStatusBarContent = value; }
        }

        [XmlIgnore()]
        public static bool AddDomainUpDownContent {
            get { return _addDomainUpDownContent; }
            set { _addDomainUpDownContent = value; }
        }

        #endregion

        protected override IList SerializationLines {
            get {
                IList list = base.SerializationLines;
                foreach (DictionaryEntry entry in _dict) {
                    if (entry.Key is string && entry.Key != null && entry.Value is string && entry.Value != null)
                        AddStringSafeSerializedPropertyObject(list, entry);
                }
                return list;
            }
        }

        protected override string GetCheckedTypeNameBy(string typeName) {
            if (typeName.ToLower() == LANG_PAIR_TYPE_NAME)
                return LANG_PAIR_TYPE_NAME;
            return base.GetCheckedTypeNameBy(typeName);
        }

        protected override bool AddStringSafeSerializedPropertyObject(IList serializeList, object obj) {
            if (base.AddStringSafeSerializedPropertyObject(serializeList, obj))
                return true;
            if (!(obj is DictionaryEntry))
                return false;
            DictionaryEntry entry = (DictionaryEntry) obj;
            serializeList.Add(BuildStringSafeSerializedFor(LANG_PAIR_TYPE_NAME, entry.Key, entry.Value));
            return true;
        }

        protected override bool AddObjectFromLine(StringCollection elementsList, string typeName) {
            if (base.AddObjectFromLine(elementsList, typeName))
                return true;
            if (AddLangPairFromLine(elementsList, typeName))
                return true;
            return false;
        }

        private static bool AddLangPairFromLine(StringCollection elementsList, string typeName) {
            if (typeName.ToLower() != LANG_PAIR_TYPE_NAME
                || elementsList.Count != 2)
                return false;
            string originText = elementsList[0];
            string actualText = elementsList[1];
            if (originText == null || actualText == null)
                return false;
            AddUpdateDictLangPairFor(originText, actualText);
            AddUpdateRevertDictLangPairFor(actualText, originText);
            return true;
        }

    }
}