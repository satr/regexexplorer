using System.Collections.Specialized;
using RegexExplorer;

namespace RegexExplorer {
    public class PredefinedRegexPatternsList : StoredRegexPatternsList {
        private static PredefinedRegexPatternsList _instance = null;

        public PredefinedRegexPatternsList() {
            InitFileNameBy("PredefinedRegexPatternsList");
            _items.Add(
                new RegexPattern(
                    @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$",
                    Msgs.Res.A_US_ZIP_code_5_or_9_digits_long));
            _items.Add(new RegexPattern(@"^\d{3}-\d{2}-\d{4}$", Msgs.Res.A_US_Social_Security_Number));
            _items.Add(new RegexPattern(@"^[A-Za-z0-9]+((_+|(\.|\-){1})[A-Za-z0-9]+)*@[A-Za-z0-9]+((_+|(\.|\-){1})[A-Za-z0-9]+)*\.[A-Za-z]{2,6}$", Msgs.Res.An_email_address));
            _items.Add(
                new RegexPattern(
                    @"[a-zA-Z`-\.\s]{1,50}", Msgs.Res.A_regular_name_not_longer_then_50_chars_valid_for_SQL_expression));
            _items.Add(new RegexPattern(@"^\D?(\d{3})\D?\D?(\d{3})\D?(\d{4})$", Msgs.Res.A_US_phone_number));
            _items.Add(
                new RegexPattern(
                    @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&%\$#\=~])*$",
                    "URL"));
            _items.Add(
                new RegexPattern(
                    @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20}$",
                    Msgs.Res.A_strong_password_Must_be_between__cut
                    ));
            _items.Add(new RegexPattern(@"href\s*=\s*(?:""(?<1>[^""]*)""|(?<1>\S+))", Msgs.Res.Scanning_for_href_s_matches));
            _items.Add(new RegexPattern(@"(^|[^d\.]+)\d{1,3}(\.\d{1,3}){3}([^d\.]+|$)", Msgs.Res.Check_of_IP_address));
            _items.Add(new RegexPattern(@"<strong[^\>]*>((?!\<strong\>.*\</strong\>).*?)</strong>", Msgs.Res.Capturing_inner_text_from_xml_html_tag));
        }

        public override int MaxItemsQuantity {
            get { return UNLIMITED_LIST_LENGTH_VALUE; }
        }

        public static void ReActivate() {
            _instance = null;
            Activate();
        }
        
        public static PredefinedRegexPatternsList Activate() {
            if (_instance == null) {
                _instance = new PredefinedRegexPatternsList();
            }
            return _instance;
        }

        public override StoredObject AddOrUpdate(object key, object item) {
            return this;
        }

        public override StoredObject AddOrUpdate(object item) {
            return this;
        }

        public override StoredObject Add(object item) {
            return this;
        }

        public override bool ReadOnly {
            get { return true; }
        }

        protected override bool AddCustomObjectFromLine(StringCollection elementsList, string typeName) {
            return false;
        }
    }
}