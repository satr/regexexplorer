using RegexExplorer;

namespace LicenseHelper {
    public class Msg : Lang {
        #region Messages

        public string Save_license_key_files = "Error saving of the license key files. Error description: \r\n{0}";
        public string Keys_list_is_empty = "Keys list is empty";
        public string A_key_file_error = "A key file error";
        public string Invalid_file_format_Its_expected_two_lines_a_key_and_his_hash =
            "Invalid file format. It's expected two lines: a key and his hash.";
        public string Clipboard_not_contains_a_valid_key = "Clipboard not contains a valid key";
        public string Error_reading_license_key_file = "Error reading of the lecense key file: {0}";

        #endregion

        new public static Msg Res {
            get { return (Msg) LangBase.Res; }
        }
    }
}