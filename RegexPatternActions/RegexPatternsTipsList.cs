using System.Collections.Specialized;
using RegexExplorer;

namespace RegexExplorer {
    public class RegexPatternsTipsList : StoredRegexPatternsList {
        private static RegexPatternsTipsList _instance = null;

        public RegexPatternsTipsList() {
            InitFileNameBy("RegexPatternExsTipsList");
            _items.Add(new RegexPatternEx(@"?", Msgs.Res.NoneOrAnySingleCharacter));
            _items.Add(new RegexPatternEx(@".", Msgs.Res.AnySingleCharacter));
            _items.Add(new RegexPatternEx(@"*", Msgs.Res.ZeroOrMore));
            _items.Add(new RegexPatternEx(@"+", Msgs.Res.OneOrMore));
            _items.Add(new RegexPatternEx(@"\A", Msgs.Res.BeginningOfTextOptionMultilineIsIgnored));
            _items.Add(new RegexPatternEx(@"^", Msgs.Res.BeginningOfLine));
            _items.Add(new RegexPatternEx(@"$", Msgs.Res.EndOfLine));
            _items.Add(new RegexPatternEx(@"[]", Msgs.Res.AnyOneCharacterInTheSet, 1));
            _items.Add(new RegexPatternEx(@"[^]", Msgs.Res.AnyOneCharacterNotInTheSet, 1));
            _items.Add(new RegexPatternEx(@"\w", Msgs.Res.AlphabeticalCharacterOrDigitOrUnderLine));
            _items.Add(new RegexPatternEx(@"\W", Msgs.Res.NotAlphabeticalCharacterOrDigitOrUnderLine));
            _items.Add(new RegexPatternEx(@"\d", Msgs.Res.AnyDigit));
            _items.Add(new RegexPatternEx(@"\D", Msgs.Res.NotDigit));
            _items.Add(new RegexPatternEx(@"\s", Msgs.Res.SingleSpace));
            _items.Add(new RegexPatternEx(@"\S", Msgs.Res.NotSpace));
            _items.Add(new RegexPatternEx(@"[\b]", Msgs.Res.Backspace));
            _items.Add(new RegexPatternEx(@"\b", Msgs.Res.BorderOfWord));
            _items.Add(new RegexPatternEx(@"\B", Msgs.Res.NotBorderOfWord));
            _items.Add(new RegexPatternEx(@"{n}", Msgs.Res.PreviouseSymbolIsMatchPrecisely_n_times, 2, 1));
            _items.Add(new RegexPatternEx(@"{n,}", Msgs.Res.PreviouseSymbolIsMatchAtLeast_n_times, 3, 1));
            _items.Add(new RegexPatternEx(@"{n,m}", Msgs.Res.PreviouseSymbolIsMatchAtLeast_n_andMaximum_m_times, 4, 3));
            _items.Add(new RegexPatternEx(@"\", Msgs.Res.EscapeSpecialCharacter));
            _items.Add(new RegexPatternEx(@"|", Msgs.Res.Or));
            _items.Add(new RegexPatternEx(@"()", Msgs.Res.Group));
            _items.Add(new RegexPatternEx(@"(?<n>)", Msgs.Res.Caption_n, 3, 1));
            _items.Add(new RegexPatternEx(@"\f", Msgs.Res.FormFeed));
            _items.Add(new RegexPatternEx(@"\n", Msgs.Res.LineFeed));
            _items.Add(new RegexPatternEx(@"\r", Msgs.Res.ReturnOfCarriage));
            _items.Add(new RegexPatternEx(@"\t", Msgs.Res.Tabulation));
            _items.Add(new RegexPatternEx(@"\cX", Msgs.Res.SymbolLikeControlX, 1, 1));
            _items.Add(new RegexPatternEx(@"\oOctal", Msgs.Res.a8bitEscapeValue, 5, 5));
            _items.Add(new RegexPatternEx(@"\xHex", Msgs.Res.a16bitEscapeValue, 3, 3));
        }

        public override int MaxItemsQuantity {
            get { return UNLIMITED_LIST_LENGTH_VALUE; }
        }

        public static void ReActivate() {
            _instance = null;
            Activate();
        }
        
        public static RegexPatternsTipsList Activate() {
            if (_instance == null) {
                _instance = new RegexPatternsTipsList();
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