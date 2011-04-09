using System;

namespace RegexExplorer {
    public class Msgs : MsgsBase {
        #region Messages

        private string _RegexExplorer = "RegexExplorer";
        private string _Unregistered_press_F8_to_register_your_copy =
            " UNREGISTERED... Press F8 to know how to register this copy.";
        private string _Registration = "Registration";
        private string _Failed_registration_on_the_key_N = "Failed registration on the key: {0}";
        private string _Successfully_registered_on_the_key_N = "Successfully registered on the key: {0}";
        private string _Error_registering_N = "Error registering: {0}";
        private string _Save_license_key_files = "Error saving of the license key files. Error description: \r\n{0}";
        private string _The_matches_files_list_is_not_initialized = "The matches files list is not initialized";
        private string _Pattern_is_empty = "Pattern is empty";
        private string _N_chars_are_loaded_from_the_file_M = "{0} chars are loaded from the file \"{1}\". "
                                                             +
                                                             "Use then \"Clear\" to make a \"Target text\" field enabled.";
        private string _N_match_es = "{0} match(es)";
        private string _Performed_N_lines_from_M = "{0} {1} lines (from {2})";

        private string _Pasted = "Pasted";
        private string _Appended = "Appended";
        private string _No_matches = "No matches";
        private string _Do_you_want_to_clear_all_existed_target_lines = "Do you want to clear all existed target lines?";
        private string _Remove_information_about_this_item = "Remove information about this item?";
        private string _Do_you_really_want_to_clear_the_list = "Do you really want to clear the list?";
        private string _N_match_es_from_M_lines = "{0} match(es) (from {1} lines)";
        private string _MATCH = "MATCH";
        private string _Fault = "Fault";
        private string _N_symbols_are_copied = "{0} symbols are copied";
        private string _Keys_list_is_empty = "Keys list is empty";
        private string _A_key_file_error = "A key file error";
        private string _Invalid_file_format_Its_expected_two_lines_a_key_and_his_hash =
            "Invalid file format. It's expected two lines: a key and his hash.";
        private string _Clipboard_not_contains_a_valid_key = "Clipboard not contains a valid key";
        private string _Error_reading_license_key_file = "Error reading of the lecense key file: {0}";
        private string _There_are_matches = "There are matches.";
        private string _Group_No = "Group No.{0}";
        private string _Values_by_result_pattern = "Values by result pattern";
        private string _NoneOrAnySingleCharacter = "None or any single character";
        private string _AnySingleCharacter = "Any single character";
        private string _ZeroOrMore = "Zero or more";
        private string _OneOrMore = "One or more";
        private string _BeginningOfTextOptionMultilineIsIgnored = "Beginning of text option multiline is ignored";
        private string _BeginningOfLine = "Beginning of line";
        private string _EndOfLine = "End of line";
        private string _AnyOneCharacterInTheSet = "Any one character in the set";
        private string _AnyOneCharacterNotInTheSet = "Any one character not in the  set";
        private string _AlphabeticalCharacterOrDigitOrUnderLine = "Alphabetical character or digit or under line";
        private string _NotAlphabeticalCharacterOrDigitOrUnderLine = "Not alphabetical character or digit or under line";
        private string _AnyDigit = "Any digit";
        private string _NotDigit = "Not digit";
        private string _SingleSpace = "Single space";
        private string _NotSpace = "Not space";
        private string _Backspace = "Backspace";
        private string _BorderOfWord = "Border of word";
        private string _NotBorderOfWord = "Not border of word";
        private string _PreviouseSymbolIsMatchPrecisely_n_times = "Previouse symbol is match precisely n times";
        private string _PreviouseSymbolIsMatchAtLeast_n_times = "Previouse symbol is match at least n times";
        private string _PreviouseSymbolIsMatchAtLeast_n_andMaximum_m_times =
            "Previouse symbol is match at least n and maximum m times";
        private string _EscapeSpecialCharacter = "Escape special character";
        private string _Or = "Or";
        private string _Group = "Group";
        private string _Caption_n = "Caption n";
        private string _FormFeed = "Form feed";
        private string _LineFeed = "Line feed";
        private string _ReturnOfCarriage = "Return of carriage";
        private string _Tabulation = "Tabulation";
        private string _SymbolLikeControlX = "Symbol like Control+X";
        private string _8bitEscapeValue = "8 bit escape value";
        private string _16bitEscapeValue = "16 bit escape value";
        private string _InsertPatternSymbols = "Insert pattern symbols";
        private string _A_US_ZIP_code_5_or_9_digits_long = "A US ZIP code 5 or 9 digits long";
        private string _A_US_Social_Security_Number = "A US Social Security Number";
        private string _An_email_address = "An email address";
        private string _A_regular_name_not_longer_then_50_chars_valid_for_SQL_expression = "A regular name not longer then 50 chars valid for SQL expression";
        private string _A_US_phone_number = "A US phone number";
        private string _a_strong_password_Must_be_between__cut = "A strong password. Must be between 6 and 20 characters. Must contain a combination of uppercase, lowercase and numeric digits with no special characters";
        private string _Scanning_for_href_s_matches = "Scanning for href's matches";
        private string _Check_of_IP_address = "Check of IP address";
        private string _Capturing_inner_text_from_xml_html_tag = "Capturing inner text from xml or html tag (here from the tag 'strong')";

        public string RegexExplorer {
            get { return GetStringValue(100, _RegexExplorer); }
            set { SetStringValue(100, value); }
        }
        public string Unregistered_press_F8_to_register_your_copy {
            get { return GetStringValue(101, _Unregistered_press_F8_to_register_your_copy); }
            set { SetStringValue(101, value); }
        }
        public string Registration {
            get { return GetStringValue(102, _Registration); }
            set { SetStringValue(102, value); }
        }
        public string Failed_registration_on_the_key_N {
            get { return GetStringValue(103, _Failed_registration_on_the_key_N); }
            set { SetStringValue(103, value); }
        }
        public string Successfully_registered_on_the_key_N {
            get { return GetStringValue(104, _Successfully_registered_on_the_key_N); }
            set { SetStringValue(104, value); }
        }
        public string Error_registering_N {
            get { return GetStringValue(105, _Error_registering_N); }
            set { SetStringValue(105, value); }
        }
        public string Save_license_key_files {
            get { return GetStringValue(106, _Save_license_key_files); }
            set { SetStringValue(106, value); }
        }
        public string The_matches_files_list_is_not_initialized {
            get { return GetStringValue(107, _The_matches_files_list_is_not_initialized); }
            set { SetStringValue(107, value); }
        }
        public string Pattern_is_empty {
            get { return GetStringValue(108, _Pattern_is_empty); }
            set { SetStringValue(108, value); }
        }
        public string N_chars_are_loaded_from_the_file_M {
            get { return GetStringValue(109, _N_chars_are_loaded_from_the_file_M); }
            set { SetStringValue(109, value); }
        }
        public string N_match_es {
            get { return GetStringValue(110, _N_match_es); }
            set { SetStringValue(110, value); }
        }
        public string Performed_N_lines_from_M {
            get { return GetStringValue(111, _Performed_N_lines_from_M); }
            set { SetStringValue(111, value); }
        }
        public string Pasted {
            get { return GetStringValue(112, _Pasted); }
            set { SetStringValue(112, value); }
        }
        public string Appended {
            get { return GetStringValue(113, _Appended); }
            set { SetStringValue(113, value); }
        }
        public string No_matches {
            get { return GetStringValue(114, _No_matches); }
            set { SetStringValue(114, value); }
        }
        public string Do_you_want_to_clear_all_existed_target_lines {
            get { return GetStringValue(115, _Do_you_want_to_clear_all_existed_target_lines); }
            set { SetStringValue(115, value); }
        }
        public string Remove_information_about_this_item {
            get { return GetStringValue(116, _Remove_information_about_this_item); }
            set { SetStringValue(116, value); }
        }
        public string Do_you_really_want_to_clear_the_list {
            get { return GetStringValue(117, _Do_you_really_want_to_clear_the_list); }
            set { SetStringValue(117, value); }
        }
        public string N_match_es_from_M_lines {
            get { return GetStringValue(118, _N_match_es_from_M_lines); }
            set { SetStringValue(118, value); }
        }
        public string MATCH {
            get { return GetStringValue(119, _MATCH); }
            set { SetStringValue(119, value); }
        }
        public string Fault {
            get { return GetStringValue(120, _Fault); }
            set { SetStringValue(120, value); }
        }

        public string N_symbols_are_copied {
            get { return GetStringValue(121, _N_symbols_are_copied); }
            set { SetStringValue(121, value); }
        }

        public string Keys_list_is_empty {
            get { return GetStringValue(122, _Keys_list_is_empty); }
            set { SetStringValue(122, value); }
        }
        public string A_key_file_error {
            get { return GetStringValue(123, _A_key_file_error); }
            set { SetStringValue(123, value); }
        }
        public string Invalid_file_format_Its_expected_two_lines_a_key_and_his_hash {
            get { return GetStringValue(124, _Invalid_file_format_Its_expected_two_lines_a_key_and_his_hash); }
            set { SetStringValue(124, value); }
        }
        public string Clipboard_not_contains_a_valid_key {
            get { return GetStringValue(125, _Clipboard_not_contains_a_valid_key); }
            set { SetStringValue(125, value); }
        }
        public string Error_reading_license_key_file {
            get { return GetStringValue(126, _Error_reading_license_key_file); }
            set { SetStringValue(126, value); }
        }
        public string There_are_matches {
            get { return GetStringValue(127, _There_are_matches); }
            set { SetStringValue(127, value); }
        }

        public string Group_No {
            get { return GetStringValue(128, _Group_No); }
            set { SetStringValue(128, value); }
        }

        public string Values_by_result_pattern {
            get { return GetStringValue(129, _Values_by_result_pattern); }
            set { SetStringValue(129, value); }
        }

        public string NoneOrAnySingleCharacter {
            get { return GetStringValue(130, _NoneOrAnySingleCharacter); }
            set { SetStringValue(130, value); }
        }
        public string AnySingleCharacter {
            get { return GetStringValue(131, _AnySingleCharacter); }
            set { SetStringValue(131, value); }
        }
        public string ZeroOrMore {
            get { return GetStringValue(132, _ZeroOrMore); }
            set { SetStringValue(132, value); }
        }
        public string OneOrMore {
            get { return GetStringValue(133, _OneOrMore); }
            set { SetStringValue(133, value); }
        }
        public string BeginningOfTextOptionMultilineIsIgnored {
            get { return GetStringValue(134, _BeginningOfTextOptionMultilineIsIgnored); }
            set { SetStringValue(134, value); }
        }
        public string BeginningOfLine {
            get { return GetStringValue(135, _BeginningOfLine); }
            set { SetStringValue(135, value); }
        }
        public string EndOfLine {
            get { return GetStringValue(136, _EndOfLine); }
            set { SetStringValue(136, value); }
        }
        public string AnyOneCharacterInTheSet {
            get { return GetStringValue(137, _AnyOneCharacterInTheSet); }
            set { SetStringValue(137, value); }
        }
        public string AnyOneCharacterNotInTheSet {
            get { return GetStringValue(138, _AnyOneCharacterNotInTheSet); }
            set { SetStringValue(138, value); }
        }
        public string AlphabeticalCharacterOrDigitOrUnderLine {
            get { return GetStringValue(139, _AlphabeticalCharacterOrDigitOrUnderLine); }
            set { SetStringValue(139, value); }
        }
        public string NotAlphabeticalCharacterOrDigitOrUnderLine {
            get { return GetStringValue(140, _NotAlphabeticalCharacterOrDigitOrUnderLine); }
            set { SetStringValue(140, value); }
        }
        public string AnyDigit {
            get { return GetStringValue(141, _AnyDigit); }
            set { SetStringValue(141, value); }
        }
        public string NotDigit {
            get { return GetStringValue(142, _NotDigit); }
            set { SetStringValue(142, value); }
        }
        public string SingleSpace {
            get { return GetStringValue(143, _SingleSpace); }
            set { SetStringValue(143, value); }
        }
        public string NotSpace {
            get { return GetStringValue(144, _NotSpace); }
            set { SetStringValue(144, value); }
        }
        public string Backspace {
            get { return GetStringValue(145, _Backspace); }
            set { SetStringValue(145, value); }
        }
        public string BorderOfWord {
            get { return GetStringValue(146, _BorderOfWord); }
            set { SetStringValue(146, value); }
        }
        public string NotBorderOfWord {
            get { return GetStringValue(147, _NotBorderOfWord); }
            set { SetStringValue(147, value); }
        }
        public string PreviouseSymbolIsMatchPrecisely_n_times {
            get { return GetStringValue(148, _PreviouseSymbolIsMatchPrecisely_n_times); }
            set { SetStringValue(148, value); }
        }
        public string PreviouseSymbolIsMatchAtLeast_n_times {
            get { return GetStringValue(149, _PreviouseSymbolIsMatchAtLeast_n_times); }
            set { SetStringValue(149, value); }
        }
        public string PreviouseSymbolIsMatchAtLeast_n_andMaximum_m_times {
            get { return GetStringValue(150, _PreviouseSymbolIsMatchAtLeast_n_andMaximum_m_times); }
            set { SetStringValue(150, value); }
        }
        public string EscapeSpecialCharacter {
            get { return GetStringValue(151, _EscapeSpecialCharacter); }
            set { SetStringValue(151, value); }
        }
        public string Or {
            get { return GetStringValue(152, _Or); }
            set { SetStringValue(152, value); }
        }
        public string Group {
            get { return GetStringValue(153, _Group); }
            set { SetStringValue(153, value); }
        }
        public string Caption_n {
            get { return GetStringValue(154, _Caption_n); }
            set { SetStringValue(154, value); }
        }
        public string FormFeed {
            get { return GetStringValue(155, _FormFeed); }
            set { SetStringValue(155, value); }
        }
        public string LineFeed {
            get { return GetStringValue(156, _LineFeed); }
            set { SetStringValue(156, value); }
        }
        public string ReturnOfCarriage {
            get { return GetStringValue(157, _ReturnOfCarriage); }
            set { SetStringValue(157, value); }
        }
        public string Tabulation {
            get { return GetStringValue(158, _Tabulation); }
            set { SetStringValue(158, value); }
        }
        public string SymbolLikeControlX {
            get { return GetStringValue(159, _SymbolLikeControlX); }
            set { SetStringValue(159, value); }
        }
        public string a8bitEscapeValue {
            get { return GetStringValue(160, _8bitEscapeValue); }
            set { SetStringValue(160, value); }
        }
        public string a16bitEscapeValue {
            get { return GetStringValue(161, _16bitEscapeValue); }
            set { SetStringValue(161, value); }
        }
        public string InsertPatternSymbols {
            get { return GetStringValue(162, _InsertPatternSymbols); }
            set { SetStringValue(162, value); }
        }
        public string A_US_ZIP_code_5_or_9_digits_long {
            get { return GetStringValue(163, _A_US_ZIP_code_5_or_9_digits_long); }
            set { SetStringValue(163, value); }
        }
        public string A_US_Social_Security_Number {
            get { return GetStringValue(164, _A_US_Social_Security_Number); }
            set { SetStringValue(164, value); }
        }
        public string An_email_address {
            get { return GetStringValue(165, _An_email_address); }
            set { SetStringValue(165, value); }
        }
        public string A_regular_name_not_longer_then_50_chars_valid_for_SQL_expression {
            get { return GetStringValue(166, _A_regular_name_not_longer_then_50_chars_valid_for_SQL_expression); }
            set { SetStringValue(166, value); }
        }
        public string A_US_phone_number {
            get { return GetStringValue(167, _A_US_phone_number); }
            set { SetStringValue(167, value); }
        }
        public string A_strong_password_Must_be_between__cut {
            get { return GetStringValue(168, _a_strong_password_Must_be_between__cut); }
            set { SetStringValue(168, value); }
        }
        public string Scanning_for_href_s_matches {
            get { return GetStringValue(169, _Scanning_for_href_s_matches); }
            set { SetStringValue(169, value); }
        }
        public string Check_of_IP_address {
            get { return GetStringValue(170, _Check_of_IP_address); }
            set { SetStringValue(170, value); }
        }
        public string Capturing_inner_text_from_xml_html_tag {
            get { return GetStringValue(171, _Capturing_inner_text_from_xml_html_tag); }
            set { SetStringValue(171, value); }
        }

        #endregion

        public Msgs() : base() {
            InitProps();
        }

        private void InitProps() {
            object o;
            o = RegexExplorer;
            o = Unregistered_press_F8_to_register_your_copy;
            o = Registration;
            o = Failed_registration_on_the_key_N;
            o = Successfully_registered_on_the_key_N;
            o = Error_registering_N;
            o = Save_license_key_files;
            o = The_matches_files_list_is_not_initialized;
            o = Pattern_is_empty;
            o = N_chars_are_loaded_from_the_file_M;
            o = N_match_es;
            o = Performed_N_lines_from_M;
            o = Pasted;
            o = Appended;
            o = No_matches;
            o = Do_you_want_to_clear_all_existed_target_lines;
            o = Remove_information_about_this_item;
            o = Do_you_really_want_to_clear_the_list;
            o = N_match_es_from_M_lines;
            o = MATCH;
            o = Fault;
            o = N_symbols_are_copied;
            o = Keys_list_is_empty;
            o = A_key_file_error;
            o = Invalid_file_format_Its_expected_two_lines_a_key_and_his_hash;
            o = Clipboard_not_contains_a_valid_key;
            o = Error_reading_license_key_file;
            o = There_are_matches;
            o = Group_No;
            o = Values_by_result_pattern;
            o = NoneOrAnySingleCharacter;
            o = AnySingleCharacter;
            o = ZeroOrMore;
            o = OneOrMore;
            o = BeginningOfTextOptionMultilineIsIgnored;
            o = BeginningOfLine;
            o = EndOfLine;
            o = AnyOneCharacterInTheSet;
            o = AnyOneCharacterNotInTheSet;
            o = AlphabeticalCharacterOrDigitOrUnderLine;
            o = NotAlphabeticalCharacterOrDigitOrUnderLine;
            o = AnyDigit;
            o = NotDigit;
            o = SingleSpace;
            o = NotSpace;
            o = Backspace;
            o = BorderOfWord;
            o = NotBorderOfWord;
            o = PreviouseSymbolIsMatchPrecisely_n_times;
            o = PreviouseSymbolIsMatchAtLeast_n_times;
            o = PreviouseSymbolIsMatchAtLeast_n_andMaximum_m_times;
            o = EscapeSpecialCharacter;
            o = Or;
            o = Group;
            o = Caption_n;
            o = FormFeed;
            o = LineFeed;
            o = ReturnOfCarriage;
            o = Tabulation;
            o = SymbolLikeControlX;
            o = a8bitEscapeValue;
            o = a16bitEscapeValue;
            o = InsertPatternSymbols;
        }
    }
}