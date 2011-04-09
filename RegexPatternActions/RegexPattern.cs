using System;
using System.ComponentModel;
using System.Xml;
using System.Xml.Serialization;
using RegexExplorer;

namespace RegexExplorer {
    public class RegexPattern : ICloneable {
        private static string EMPTY_DESCRIPTION = "Not defined";
        private string _value = string.Empty;
        private string _result = string.Empty;
        private string _description = EMPTY_DESCRIPTION;
        private DateTime _createdOn = DateTime.Now;
        private bool _isFavorite = false;

        public RegexPattern() : this(string.Empty) {}

        public RegexPattern(string value) : this(value, string.Empty) {}

        public RegexPattern(string value, string description): this(value, description, string.Empty) {}

        public RegexPattern(string value, string description, string result) {
            Value = value;
            Description = description;
            Result = result;
        }

        [Browsable(false)]
        public string SafeValue {
            get { return XmlConvert.EncodeName(Value); }
            set {
                try {
                    Value = XmlConvert.DecodeName(NotEmptyString(value));
                }
                catch (Exception ex) {
                    Messenger.LogError(ex);
                }
            }
        }

        [Browsable(true)]
        [XmlIgnore]
        public string Value {
            get { return _value; }
            set { _value = NotEmptyString(value); }
        }

        private static string NotEmptyString(string value, string defaultString) {
           return (value == null || value.Trim().Length == 0) ? defaultString : value.Trim();
        }
        private static string NotEmptyString(string value) {
           return NotEmptyString(value, string.Empty);
        }

        [Browsable(true)]
        public string Result {
            get { return _result; }
            set { _result = NotEmptyString(value); }
        }

        [Browsable(true)]
        public string Description {
            get { return _description; }
            set { _description = NotEmptyString(value, EMPTY_DESCRIPTION); }
        }

        [Browsable(true)]
        public DateTime CreatedOn {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        public override string ToString() {
            return Value;
        }

        public override bool Equals(object obj) {
            if (obj == null || obj.GetType() != GetType())
                return false;
            return string.Compare(SafeValue, ((RegexPattern) obj).SafeValue, false) == 0;
        }

        public override int GetHashCode() {
            return SafeValue.GetHashCode();
        }

        public object Clone() {
            return MemberwiseClone();
        }

        public bool IsFavorite {
            get { return _isFavorite; }
            set { _isFavorite = value; }
        }
    }
}