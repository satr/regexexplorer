namespace RegexExplorer {
    public class RegexPatternEx : RegexPattern {
        private int _shiftCursorLeft = 0;
        private int _selectionLength = 0;

        public RegexPatternEx(string value, string description, int cursorPos, int selectionLength)
            : base(value, description) {
            _shiftCursorLeft = cursorPos;
            _selectionLength = selectionLength;
        }

        public RegexPatternEx(string value, string description, int shiftCursorRight) : base(value, description) {
            _shiftCursorLeft = shiftCursorRight;
        }

        public RegexPatternEx(string value, string description) : base(value, description) {
        }

        public int ShiftCursorLeft {
            get { return _shiftCursorLeft; }
        }

        public int SelectionLength {
            get { return _selectionLength; }
        }
    }
}