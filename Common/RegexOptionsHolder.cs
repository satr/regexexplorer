using System.Text.RegularExpressions;

namespace RegexExplorer {
    public class RegexOptionsHolder {
        private RegexOptions _value = RegexOptions.None;

        public RegexOptions Value {
            get { return _value; }
            set { _value = value; }
        }
    }
}