using CommonTools;

namespace RegexExplorer {
    public class Msg : Lang {
        #region Messages

        public string RegexExplorer = "RegexExplorer";
        public string Unregistered_press_F8_to_register_your_copy =
            " UNREGISTERED... Press F8 to know how to buy and register this copy.";
        public string Registration = "Registration";
        public string Failed_registration_on_the_key_N = "Failed registration on the key: {0}";
        public string Successfully_registered_on_the_key_N = "Successfully registered on the key: {0}";
        public string Error_registering_N = "Error registering: {0}";
        public string Save_license_key_files = "Error saving of the license key files. Error description: \r\n{0}";
        public string The_matches_files_list_is_not_initialized = "The matches files list is not initialized";
        public string Pattern_is_empty = "Pattern is empty";
        public string N_chars_are_loaded_from_the_file_M = "{0} chars are loaded from the file \"{1}\". "
                                                           +
                                                           "Use then \"Clear\" to make a \"Target text\" field enabled.";
        public string N_match_es = "{0} match(es)";
        public string Performed_N_lines_from_M = "{0} {1} lines (from {2})";

        public string Pasted = "Pasted";
        public string Appended = "Appended";
        public string No_matches = "No matches";
        public string Do_you_want_to_clear_all_existed_target_lines = "Do you want to clear all existed target lines?";
        public string Remove_information_about_this_item = "Remove information about this item?";
        public string Do_you_really_want_to_clear_the_list = "Do you really want to clear the list?";
        public string N_match_es_from_M_lines = "{0} match(es) (from {1} lines)";
        public string MATCH = "MATCH";
        public string Fault = "Fault";

        #endregion

        public override StoredObject CreateDefault() {
            return new Msg();
        }

        new public static Msg Res {
            get { return (Msg) Lang.Res; }
        }
    }
}