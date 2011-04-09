using System;
using System.Collections;
using RegexExplorer;

namespace RegexExplorer {
    public class HistoryRegexPatternsList : StoredRegexPatternsList {
        private static HistoryRegexPatternsList _instance = null;

        public HistoryRegexPatternsList() {
            InitFileNameBy("HistoryRegexPatternsList");
        }

        public static HistoryRegexPatternsList Activate() {
            if (_instance == null) {
                _instance = (HistoryRegexPatternsList) new HistoryRegexPatternsList().Load();
            }
            return _instance;
        }

        public override int MaxItemsQuantity {
            get { return Preferences.Res.MaxRegexPatternHistoryLength; }
        }

        public override StoredObject Add(object item) {
            if (Preferences.Res.ReplaceDoublicatedPatternsInHistory)
                AddOrUpdate(item);
            else
                base.Add(item);
            Sort(new HistoryRegexPatternComparer());
            return this;
        }

        private class HistoryRegexPatternComparer : IComparer {
            public int Compare(object x, object y) {
                return (-1)*DateTime.Compare(((RegexPattern) x).CreatedOn, ((RegexPattern) y).CreatedOn);
            }
        }
    }
}