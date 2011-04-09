using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexExplorer {
    public abstract class StoredObject {
        #region Value getters

        protected string GetStringValueTrim(int valueId, string initValue) {
            return GetStringValue(valueId, initValue).Trim();
        }

        protected string GetStringValue(int valueId, string initValue) {
            return (string) GetCheckedValueFor(valueId, typeof (string),
                                               (initValue == null) ? string.Empty : initValue,
                                               string.Empty);
        }

        protected int GetIntValue(int valueId, int initValue) {
            return (int) GetCheckedValueFor(valueId, typeof (int), initValue, 0);
        }

        protected decimal GetDecimalValue(int valueId, decimal initValue) {
            return (decimal) GetCheckedValueFor(valueId, typeof (decimal), initValue, 0);
        }

        protected bool GetBoolValue(int valueId, bool initValue) {
            return (bool) GetCheckedValueFor(valueId, typeof (bool), initValue, false);
        }

        protected DateTime GetDateTimeValue(int valueId, DateTime initValue) {
            return (DateTime) GetCheckedValueFor(valueId, typeof (DateTime), initValue, new DateTime());
        }

        protected object GetCheckedValueFor(int valueId, Type type, object initValue, object defaultValue) {
            if (!_properties.Contains(valueId) || _properties[valueId] == null || _properties[valueId].GetType() != type
                )
                SetValue(valueId, initValue);
            return _properties[valueId];
        }

        #endregion

        #region Value setters

        protected void SetValue(int valueId, object value) {
            _properties[valueId] = value;
        }

        protected void SetStringValue(int valueId, object value) {
            SetCheckedValueFor(valueId, value, typeof (string), string.Empty);
        }

        protected void SetIntValue(int valueId, object value) {
            SetCheckedValueFor(valueId, value, typeof (int), 0);
        }

        protected void SetDecimalValue(int valueId, object value) {
            SetCheckedValueFor(valueId, value, typeof (decimal), 0);
        }

        protected void SetBoolValue(int valueId, object value) {
            SetCheckedValueFor(valueId, value, typeof (bool), false);
        }

        protected void SetDateTimeValue(int valueId, object value) {
            SetCheckedValueFor(valueId, value, typeof (DateTime), new DateTime());
        }

        protected void SetCheckedValueFor(int valueId, object value, Type type, object defaultValue) {
            _properties[valueId] = (value == null || value.GetType() != type) ? defaultValue : value;
        }

        #endregion  

        #region Fields and constants

        public static readonly string STORED_OBJECTS_FILE_EXTENSION = ".lst";
        public static readonly string ELEMENTS_LINE_START_IDENTIFIER = "<###>";
        protected static readonly string ELEMENTS_LINE_FORMAT =
            string.Format(@"{0}[\w\d\S \t]+", ELEMENTS_LINE_START_IDENTIFIER);
        public static readonly string ELEMENTS_SPLITTER = "<##>";
        protected static readonly string ELEMENTS_SPLITTER_PATTERN = string.Format("[^{0}]*", ELEMENTS_SPLITTER);
        protected static readonly RegexOptions ELEMENTS_REGEX_OPTION_PATTERN = RegexOptions.Multiline
                                                                               | RegexOptions.IgnoreCase;
        private static Regex REGEX_INT = new Regex(@"^[\d+]{1,5}$");
        private static Regex REGEX_DECIMAL = new Regex(@"^\d+(\.\d+)*$");
        protected static readonly string STRING_TYPE_NAME = "string";
        protected static readonly string INT_TYPE_NAME = "int";
        protected static readonly string BOOL_TYPE_NAME = "bool";
        protected static readonly string DATE_TIME_TYPE_NAME = "datetime";
        protected static readonly string DECIMAL_TIME_TYPE_NAME = "decimal";
        protected static readonly string LIST_TYPE_NAME = "list";
        protected string _fileName;
        protected string _folderName =
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
        protected IDictionary _properties = new Hashtable();

        #endregion

        protected delegate int CollectionStringEventDelegate(string line);

        protected delegate bool StringEventDelegate(string line);

        public StoredObject() {
            InitFileNameBy("StoredObjectUndefined");
        }

        protected void InitFileNameBy(string fileNameWOExtension) {
            _fileName = string.Format("{0}{1}", fileNameWOExtension, STORED_OBJECTS_FILE_EXTENSION);
        }

        public void Save() {
            CreateForderIfNotExists(_folderName);
            using (StreamWriter sw = new StreamWriter(GetFullFilePath(_fileName), false, Encoding.Unicode)) {
                foreach (string line in SerializationLines)
                    sw.WriteLine(line);
            }
        }

        public StoredObject Load() {
            return Load(FileName);
        }

        public static string GetFileNameWOExtension(string fileName) {
            return new Regex(string.Format("{0}$", STORED_OBJECTS_FILE_EXTENSION)).Replace(fileName, string.Empty);
        }

        public string GetFileNameWOExtension() {
            return GetFileNameWOExtension(FileName);
        }

        public StoredObject Load(string fileName) {
            string fullFilePath = GetFullFilePath(fileName);
            if (!new FileInfo(fullFilePath).Exists)
                Save(fileName);
            ClearProperties();
            using (StreamReader reader = new StreamReader(fullFilePath, Encoding.Unicode)) {
                StringCollection stringCollection = new ParserTextToStrings().Split(reader.ReadToEnd(),
                                                                                    ELEMENTS_LINE_START_IDENTIFIER,
                                                                                    ELEMENTS_REGEX_OPTION_PATTERN);
//                ListLoader listLoader = new ListLoader();
                foreach (string line in stringCollection) {
                    StringCollection elementsList = GetElementsFrom(line, ELEMENTS_SPLITTER);
                    string typeName = ExtractObjectTypeNameFrom(elementsList);
//                    if(typeName.Equals(LIST_TYPE_NAME)){
//                        listLoader.StartLoadingListFor(ExtractExpectedListCountFrom(elementsList));
//                        continue;
//                    }
//                    if(listLoader.IsLoadingList) {
//                        
//                    }
//                        
                    AddObjectFromLine(elementsList, typeName);
                }
            }
            return this;
        }

        private void Save(string fileName) {
            _fileName = fileName;
            Save();
        }

        protected void ClearProperties() {
            _properties = new Hashtable();
        }

        public StringCollection GetElementsFrom(string line, string pattern) {
            StringCollection stringCollection = new ParserTextToStrings().Split(line, pattern);
            return stringCollection;
        }

        public string FileName {
            get { return _fileName; }
            set { _fileName = value; }
        }

        public virtual string FolderName {
            get { return _folderName; }
            set { _folderName = value; }
        }

        private string GetFullFilePath(string fileName) {
            return Path.Combine(_folderName, fileName);
        }

        private void CreateForderIfNotExists(string folderName) {
            DirectoryInfo folder = new DirectoryInfo(folderName);
            if (!folder.Exists)
                folder.Create();
        }

        private int ExtractExpectedListCountFrom(StringCollection elementsList) {
            if (elementsList.Count < 2)
                return 0;
            string expectedListCountText = elementsList[0];
            if (!REGEX_INT.IsMatch(expectedListCountText))
                return 0;
            elementsList.RemoveAt(0);
            return int.Parse(expectedListCountText);
        }

        private string ExtractObjectTypeNameFrom(StringCollection elementsList) {
            if (elementsList.Count <= 1)
                return null;
            string typeName = elementsList[0];
            elementsList.RemoveAt(0);
            return GetCheckedTypeNameBy(typeName);
        }

        private bool AddKnownTypesObjectFromLine(string typeName, int id, string text) {
            typeName = typeName.ToLower();
            if (typeName == STRING_TYPE_NAME)
                SetStringValue(id, text);
            else if (typeName == INT_TYPE_NAME)
                SetIntValue(id, GetIntFrom(text));
            else if (typeName == BOOL_TYPE_NAME)
                SetBoolValue(id, GetBoolFrom(text));
            else if (typeName == DATE_TIME_TYPE_NAME)
                SetDateTimeValue(id, GetDateTimeFrom(text));
            else if (typeName == DECIMAL_TIME_TYPE_NAME)
                SetDecimalValue(id, GetDecimalFrom(text));
            else
                return false;
            return true;
        }

        private bool GetBoolFrom(string text) {
            try {
                return Convert.ToBoolean(text);
            }
            catch {
                return false;
            }
        }

        private static int GetIntFrom(string text) {
            return REGEX_INT.IsMatch(text) ? Int32.Parse(text) : 0;
        }

        private static decimal GetDecimalFrom(string text) {
            return REGEX_DECIMAL.IsMatch(text) ? decimal.Parse(text) : 0;
        }

        private DateTime GetDateTimeFrom(string text) {
            try {
                return Convert.ToDateTime(text);
            }
            catch {
                return DateTime.Now.Date;
            }
        }

        protected int PropertiesCount {
            get { return _properties.Count; }
        }

        protected virtual string GetCheckedTypeNameBy(string typeName) {
            if (string.Compare(typeName, STRING_TYPE_NAME, true) == 0)
                return STRING_TYPE_NAME;
            if (string.Compare(typeName, INT_TYPE_NAME, true) == 0)
                return INT_TYPE_NAME;
            if (string.Compare(typeName, BOOL_TYPE_NAME, true) == 0)
                return BOOL_TYPE_NAME;
            if (string.Compare(typeName, DATE_TIME_TYPE_NAME, true) == 0)
                return DATE_TIME_TYPE_NAME;
            if (string.Compare(typeName, DECIMAL_TIME_TYPE_NAME, true) == 0)
                return DECIMAL_TIME_TYPE_NAME;
            if (string.Compare(typeName, LIST_TYPE_NAME, true) == 0)
                return LIST_TYPE_NAME;
            return typeName;
        }

        protected virtual string GetTypeNameFor(object obj) {
            if (obj is int)
                return INT_TYPE_NAME;
            if (obj is decimal)
                return DECIMAL_TIME_TYPE_NAME;
            if (obj is DateTime)
                return DATE_TIME_TYPE_NAME;
            if (obj is string)
                return STRING_TYPE_NAME;
            if (obj is bool)
                return BOOL_TYPE_NAME;
            if (obj is IList)
                return LIST_TYPE_NAME;
            return obj.GetType().ToString();
        }

        protected virtual IList SerializationLines {
            get {
                IList list = new ArrayList(_properties.Count);
                foreach (DictionaryEntry entry in _properties)
                    AddStringSafeSerializedPropertyObject(list, entry);
                return list;
            }
        }

        protected virtual bool AddStringSafeSerializedPropertyObject(IList serializeList, object obj) {
            if (!(obj is DictionaryEntry))
                return false;
            object valueId = ((DictionaryEntry) obj).Key;
            object value = ((DictionaryEntry) obj).Value;
            if (!(valueId is int)
                || !(value is string
                     || value is int
                     || value is bool
                     || value is DateTime
                     || value is decimal))
                return false;
            serializeList.Add(BuildStringSafeSerializedFor(GetTypeNameFor(value), valueId, value));
            return true;
        }

        protected string BuildStringSafeSerializedFor(string typeName, params object[] args) {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{0}{1}{2}",
                                       ELEMENTS_LINE_START_IDENTIFIER,
                                       ELEMENTS_SPLITTER,
                                       typeName);
            foreach (object obj in args)
                stringBuilder.AppendFormat("{0}{1}", ELEMENTS_SPLITTER, obj);
            return stringBuilder.ToString();
        }

        protected virtual bool AddObjectFromLine(StringCollection elementsList, string typeName) {
            if (elementsList.Count < 2)
                return false;
            int index = GetIntFrom(elementsList[0]);
            if (index == 0)
                return false;
            return AddKnownTypesObjectFromLine(typeName, index, elementsList[1]);
        }

        #region Nested classes

        protected class ParserTextToStrings {
            private StringEventDelegate _addStringDelegate;
            private CollectionStringEventDelegate _collectionStringDelegate;

            public ParserTextToStrings() {
            }

            public ParserTextToStrings(StringEventDelegate addStringDelegate) {
                _addStringDelegate = addStringDelegate;
            }

            public ParserTextToStrings(CollectionStringEventDelegate collectionStringDelegate) {
                _collectionStringDelegate = collectionStringDelegate;
            }

            public StringCollection Parse(string text, string pattern) {
                return Parse(text, pattern, RegexOptions.None);
            }

            public StringCollection Parse(string text, string pattern, RegexOptions regexOptions) {
                StringCollection elementsList = new StringCollection();
                MatchCollection matchCollection =
                    new Regex(pattern, regexOptions).Matches(text);
                foreach (Match match in matchCollection) {
                    string line = match.Value.Trim();
                    if (line != null && line.Trim().Length > 0) {
                        elementsList.Add(line);
                        AddString(line);
                    }
                }
                return elementsList;
            }

            public StringCollection Split(string text, string pattern) {
                return Split(text, pattern, RegexOptions.None, false);
            }
            
            public StringCollection Split(string text, string pattern, RegexOptions regexOptions) {
                return Split(text, pattern, regexOptions, true);
            }
            
            public StringCollection Split(string text, string pattern, RegexOptions regexOptions, bool ignoreEmptyStrings) {
                StringCollection elementsList = new StringCollection();
                foreach (string line in new Regex(pattern, regexOptions).Split(text)) {
                    string trimLine = line.Trim();
                    if (line != null && trimLine.Length > 0) {
                        elementsList.Add(trimLine);
                        AddString(trimLine);
                    }
                }
                return elementsList;
            }

            private void AddString(string line) {
                if (_addStringDelegate != null)
                    _addStringDelegate(line);
                if (_collectionStringDelegate != null)
                    _collectionStringDelegate(line);
            }

        }

        private class ListLoader {
            private Stack _listStack = new Stack();

            public bool AddObject(object obj) {
                if (!IsLoadingList)
                    return false;
                CurrentListPair.AddObject(obj);
                return true;
            }

            private ListPair CurrentListPair {
                get { return IsLoadingList ? ((ListPair) _listStack.Peek()) : new ListPair(); }
            }

            public bool IsLoadingList {
                get { return _listStack.Count > 0; }
            }

            public void StartLoadingListFor(int expectedListCount) {
                if (expectedListCount <= 0)
                    return;
                if (IsLoadingList)
                    _listStack.Push(new ListPair(expectedListCount));
            }

            private class ListPair {
                private ArrayList _list;
                private int _counter = 0;

                public ListPair() {
                    _list = new ArrayList();
                }

                public ListPair(int counter) : this() {
                    _counter = counter;
                }

                public bool AddObject(object obj) {
                    if (IsCompleted)
                        return false;
                    _list.Add(obj);
                    _counter--;
                    return true;
                }

                public ArrayList List {
                    get { return _list; }
                }
                private bool IsCompleted {
                    get { return _counter > 0; }
                }
            }
        }

        #endregion

        public void Dispose() {
            Save();
        }
    }
}