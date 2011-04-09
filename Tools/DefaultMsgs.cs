using System;

namespace RegexExplorer {
    public abstract class DefaultMsgs : StoredObject {
        #region General messages

        private string _testMessage = "Test message";
        private string _help_file_in_folder_N_for_the_language_L_not_found =
            "Help file in the folder {0} for the language {1} not found";
        private string _error_ocurred_while_open_a_file_N_Error_ex =
            "Error ocurred while open a file {1}. \r\nError: \r\n{0}";
        private string _error_The_caller_does_not_have_the_required_permission_ex =
            "Error: The caller does not have the required permission.\r\n{0}";
        private string _error_Path_is_readonly_or_is_a_directory_ex =
            "Error: Path is read-only or is a directory.\r\n{0}";
        private string _error_The_specified_path_is_invalid_or_unmapped_drive_ex =
            "Error: The specified path is invalid, or unmapped drive. \r\n{0}";
        private string _error_The_file_N_is_not_found = "Error: The file \"{0}\" is not found";
        private string _file_IO_error_ex = "File IO error: \r\n{0}";
        private string _error_Out_of_memory_ex = "Error: Out of memory \r\n{0}";
        private string _undefined_error_ex = "Undefined error: \r\n{0}";
        private string _do_you_really_want_to_exit_and_lose_all_changes =
            "Do you really want to exit and lose all changes?";
        private string _file_is_invalid = "File is invalid";
        private string _file_N_is_not_exist = "File {0} is not exist";
        private string _fileNotExists = "File not exists";
        private string _errorWhileChangeGuiLanguage = "Error occured while user interface language was being changed."
                                                      + "\r\n\r\nError description:{0}";
        private string _file_is_not_found = "File is not found";
        private string _file_with_language_resource_not_found = "File \"{0}\" with language resource was not found";
        private string _errorWhileStoreObject = "Error occurred while the file \"{1}\" was being saved."
                                                + "\r\n\r\nError description:{0}";
        private string _errorWhileRestoreObject = "Error occured while the file \"{1}\" was being loaded."
                                                  + "\r\n\r\nCurrent file has been copied to \"{2}\""
                                                  + "\r\n(and replaced by default file)."
                                                  + "\r\n\r\nError description:{0}";
        private string _ERROR_n = "ERROR: {0}";
        private string _do_you_really_want_to_exit = "Do you really want to exit?";
        private string _confirmation = "Confirmation";
        private string _warning = "Warning";
        private string _error = "Error";
        private string _info = "Info";
        private string _exit = "Exit";

        public string TestMessage {
            get { return GetStringValue(1, _testMessage); }
            set { SetStringValue(1, value); }
        }
        public string Help_file_in_folder_N_for_the_language_L_not_found {
            get { return GetStringValue(2, _help_file_in_folder_N_for_the_language_L_not_found); }
            set { SetStringValue(2, value); }
        }
        public string Error_ocurred_while_open_a_file_N_Error_ex {
            get { return GetStringValue(3, _error_ocurred_while_open_a_file_N_Error_ex); }
            set { SetStringValue(3, value); }
        }
        public string Error_The_caller_does_not_have_the_required_permission_ex {
            get { return GetStringValue(4, _error_The_caller_does_not_have_the_required_permission_ex); }
            set { SetStringValue(4, value); }
        }
        public string Error_Path_is_readonly_or_is_a_directory_ex {
            get { return GetStringValue(5, _error_Path_is_readonly_or_is_a_directory_ex); }
            set { SetStringValue(5, value); }
        }
        public string Error_The_specified_path_is_invalid_or_unmapped_drive_ex {
            get { return GetStringValue(6, _error_The_specified_path_is_invalid_or_unmapped_drive_ex); }
            set { SetStringValue(6, value); }
        }
        public string Error_The_file_N_is_not_found {
            get { return GetStringValue(7, _error_The_file_N_is_not_found); }
            set { SetStringValue(7, value); }
        }
        public string File_IO_error_ex {
            get { return GetStringValue(8, _file_IO_error_ex); }
            set { SetStringValue(8, value); }
        }
        public string Error_Out_of_memory_ex {
            get { return GetStringValue(9, _error_Out_of_memory_ex); }
            set { SetStringValue(9, value); }
        }
        public string Undefined_error_ex {
            get { return GetStringValue(10, _undefined_error_ex); }
            set { SetStringValue(10, value); }
        }
        public string Do_you_really_want_to_exit_and_lose_all_changes {
            get { return GetStringValue(11, _do_you_really_want_to_exit_and_lose_all_changes); }
            set { SetStringValue(11, value); }
        }
        public string File_is_invalid {
            get { return GetStringValue(12, _file_is_invalid); }
            set { SetStringValue(12, value); }
        }
        public string File_N_is_not_exist {
            get { return GetStringValue(13, _file_N_is_not_exist); }
            set { SetStringValue(13, value); }
        }
        public string FileNotExists {
            get { return GetStringValue(14, _fileNotExists); }
            set { SetStringValue(14, value); }
        }
        public string ErrorWhileChangeGuiLanguage {
            get { return GetStringValue(15, _errorWhileChangeGuiLanguage); }
            set { SetStringValue(15, value); }
        }
        public string File_is_not_found {
            get { return GetStringValue(16, _file_is_not_found); }
            set { SetStringValue(16, value); }
        }
        public string File_with_language_resource_not_found {
            get { return GetStringValue(17, _file_with_language_resource_not_found); }
            set { SetStringValue(17, value); }
        }
        public string ErrorWhileStoreObject {
            get { return GetStringValue(18, _errorWhileStoreObject); }
            set { SetStringValue(18, value); }
        }
        public string ErrorWhileRestoreObject {
            get { return GetStringValue(19, _errorWhileRestoreObject); }
            set { SetStringValue(19, value); }
        }
        public string ERROR_n {
            get { return GetStringValue(20, _ERROR_n); }
            set { SetStringValue(20, value); }
        }
        public string Do_you_really_want_to_exit {
            get { return GetStringValue(21, _do_you_really_want_to_exit); }
            set { SetStringValue(21, value); }
        }
        public string Confirmation {
            get { return GetStringValue(22, _confirmation); }
            set { SetStringValue(22, value); }
        }
        public string Warning {
            get { return GetStringValue(23, _warning); }
            set { SetStringValue(23, value); }
        }
        public string Error {
            get { return GetStringValue(24, _error); }
            set { SetStringValue(24, value); }
        }
        public string Info {
            get { return GetStringValue(25, _info); }
            set { SetStringValue(25, value); }
        }
        public string Exit {
            get { return GetStringValue(26, _exit); }
            set { SetStringValue(26, value); }
        }

        #endregion

        public DefaultMsgs() {
            InitFileNameBy("DefaultMsgs");
            InitProps();
        }

        private void InitProps() {
            Help_file_in_folder_N_for_the_language_L_not_found = Help_file_in_folder_N_for_the_language_L_not_found;
            Error_ocurred_while_open_a_file_N_Error_ex = Error_ocurred_while_open_a_file_N_Error_ex;
            Error_The_caller_does_not_have_the_required_permission_ex = Error_The_caller_does_not_have_the_required_permission_ex;
            Error_Path_is_readonly_or_is_a_directory_ex = Error_Path_is_readonly_or_is_a_directory_ex;
            Error_The_specified_path_is_invalid_or_unmapped_drive_ex = Error_The_specified_path_is_invalid_or_unmapped_drive_ex;
            Error_The_file_N_is_not_found = Error_The_file_N_is_not_found;
            File_IO_error_ex = File_IO_error_ex;
            Error_Out_of_memory_ex = Error_Out_of_memory_ex;
            Undefined_error_ex = Undefined_error_ex;
            Do_you_really_want_to_exit_and_lose_all_changes = Do_you_really_want_to_exit_and_lose_all_changes;
            File_is_invalid = File_is_invalid;
            File_N_is_not_exist = File_N_is_not_exist;
            FileNotExists = FileNotExists;
            ErrorWhileChangeGuiLanguage = ErrorWhileChangeGuiLanguage;
            File_is_not_found = File_is_not_found;
            File_with_language_resource_not_found = File_with_language_resource_not_found;
            ErrorWhileStoreObject = ErrorWhileStoreObject;
            ErrorWhileRestoreObject = ErrorWhileRestoreObject;
            ERROR_n = ERROR_n;
            Do_you_really_want_to_exit = Do_you_really_want_to_exit;
            Confirmation = Confirmation;
            Warning = Warning;
            Error = Error;
            Info = Info;
            Exit = Exit;
        }
    }
}