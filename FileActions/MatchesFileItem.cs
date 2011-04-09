using System;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

namespace RegexExplorer {
    public class MatchesFileItem : ICloneable {
        private static readonly string FILE_NOT_EXISTS_MSG = MsgsBase.Res.File_is_not_found;
        private static string EMPTY_MSG = "";

        private string _fullName = string.Empty;
        private string _description = "-";
        private IList _patterns = new ArrayList();
        private DateTime _lastUpdatedOn = DateTime.Now;
        private long _lastSize = 0;
        private DateTime _lastLoadedOn = DateTime.Now;
        private bool _isInFavorites = true;
        private bool _isExists = false;

        public MatchesFileItem() : this(string.Empty) {
        }

        public MatchesFileItem(string fullName) {
            if (null == fullName)
                return;
            _fullName = fullName.Trim();
            if (!FileNameIsValid())
                return;
            FileInfo fileInfo = new FileInfo(fullName);
            _isExists = fileInfo.Exists;
            if (!_isExists)
                return;
            _lastSize = fileInfo.Length;
            _lastUpdatedOn = fileInfo.LastWriteTime;
        }

        public string FullName {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Description {
            get {
                return _description == null || _description.Length == 0? "-": _description;
            }
            set { _description = value; }
        }

        public IList Patterns {
            get { return _patterns; }
            set { _patterns = value; }
        }

        public DateTime LastUpdatedOn {
            get { return _lastUpdatedOn; }
            set { _lastUpdatedOn = value; }
        }

        public string LastSizeInKBytes {
            get { return SizeToStringInKBytes(_lastSize); }
        }

        private string SizeToStringInKBytes(long size) {
            if (!FileNameIsValid())
                return EMPTY_MSG;
            return string.Format("{0:f3} k", size/1000m);
        }

        public long LastSize {
            get { return _lastSize; }
            set { _lastSize = value; }
        }

        public DateTime LastLoadedOn {
            get { return _lastLoadedOn; }
            set { _lastLoadedOn = value; }
        }

        [XmlIgnore]
        public string ActualLastUpdatedOn {
            get {
                if (!FileNameIsValid())
                    return EMPTY_MSG;
                if (!FileIsValid())
                    return FILE_NOT_EXISTS_MSG;
                return CurrentFileInfo().LastWriteTime.ToString();
            }
        }

        [XmlIgnore]
        public string ActualSizeInKBytes {
            get {
                if (!FileNameIsValid())
                    return EMPTY_MSG;
                if (!FileIsValid())
                    return FILE_NOT_EXISTS_MSG;
                return SizeToStringInKBytes(CurrentFileInfo().Length);
            }
        }

        [XmlIgnore]
        public string CheckedLastLoadedOn {
            get {
                if (!FileNameIsValid())
                    return EMPTY_MSG;
                if (!FileIsValid())
                    return FILE_NOT_EXISTS_MSG;
                return LastLoadedOn.ToString();
            }
        }

        private FileInfo CurrentFileInfo() {
            return new FileInfo(_fullName);
        }

        private bool FileIsValid() {
            return FileNameIsValid() && CurrentFileInfo().Exists;
        }

        private bool FileNameIsValid() {
            return _fullName != null && _fullName.Length > 0;
        }

        public void AddPattern(string pattern) {
            if (!_patterns.Contains(pattern))
                _patterns.Add(pattern);
        }

        [XmlIgnore]
        public bool IsInFavorites {
            get { return _isInFavorites; }
            set { _isInFavorites = value; }
        }

        public override string ToString() {
            return _fullName;
        }

        public override bool Equals(object obj) {
            if (obj == null || obj.GetType() != GetType())
                return false;
            return FullName == ((MatchesFileItem) obj).FullName;
        }

        public override int GetHashCode() {
            return ToString().GetHashCode();
        }

        public static bool operator ==(MatchesFileItem item1, MatchesFileItem item2) {
            if (!object.Equals(item1, null))
                return item1.Equals(item2);
            else if (!object.Equals(item2, null))
                return item2.Equals(item1);
            return true;
        }

        public static bool operator !=(MatchesFileItem item1, MatchesFileItem item2) {
            return !(item1 == item2);
        }

        public object Clone() {
            return MemberwiseClone();
        }
    }
}