using System;

namespace RegexExplorer {
    public class LanguageException : SafeCommonToolsException {
        public LanguageException(string message) : base(message) {
        }

        public LanguageException(string format, params object[] args) : base(format, args) {
        }

        public LanguageException(string format, Exception innerException, params object[] args)
            : base(format, innerException, args) {
        }
    }

    public class StoredObjectException : SafeCommonToolsException {
        public StoredObjectException(string message) : base(message) {
        }

        public StoredObjectException(string format, params object[] args) : base(format, args) {
        }

        public StoredObjectException(string format, Exception innerException, params object[] args)
            : base(format, innerException, args) {
        }
    }

    public class SafeCommonToolsException : Exception {
        public SafeCommonToolsException(string message) : base(message) {
        }

        public SafeCommonToolsException(string format, params object[] args) : base(string.Format(format, args)) {
        }

        public SafeCommonToolsException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, CombinedParamsFor(innerException, args))) {
        }

        private static object[] CombinedParamsFor(Exception innerException, object[] args) {
            object[] newArgs = new object[args.Length + 1];
            args.CopyTo(newArgs, 1);
            newArgs[0] = Messenger.InnerDescriptionMessagesFor(innerException);
            return newArgs;
        }

    }

    public class PreferencesException : Exception {
        public PreferencesException(string message) : base(message) {
        }

        public PreferencesException(string format, params object[] args) : base(string.Format(format, args)) {
        }
    }
}