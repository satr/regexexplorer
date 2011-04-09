using System;

namespace RegexExplorer {
    public class RegexExplorerException : Exception {
        public RegexExplorerException(string message) : base(message) {
        }

        public RegexExplorerException(string format, params object[] args) : base(string.Format(format, args)) {
        }
    }

    public class MatchesFilesException : RegexExplorerException {
        public MatchesFilesException(string message) : base(message) {
        }

        public MatchesFilesException(string format, params object[] args) : base(format, args) {
        }
    }

    public class PatternCategoryException : RegexExplorerException {
        public PatternCategoryException(string message) : base(message) {
        }

        public PatternCategoryException(string format, params object[] args) : base(format, args) {
        }
    }
}