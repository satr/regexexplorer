using System.Collections;
using RegexExplorer;

namespace RegexExplorer {
    public class RegexPatternCategory : StoredObject {
        private SortedList _categories = new SortedList(new RegexPatternCategoryComparer());
        private IList _patterns = new ArrayList();
        private string _name = string.Empty;

        public RegexPatternCategory() {
            InitFileNameBy("RegexPatternCategory");
        }

        public SortedList Categories {
            get { return _categories; }
            set { _categories = value; }
        }

        public IList Patterns {
            get { return _patterns; }
            set { _patterns = value; }
        }

        public string Name {
            get { return _name; }
            set { _name = value; }
        }

        public void AddCategory(RegexPatternCategory category) {
            if (_categories.Contains(category))
                throw new PatternCategoryException("The pattern category {0} already exists", category.Name);
            _categories.Add(category.Name, category);
        }

        public void AddPattern(RegexPattern pattern) {
            if (_patterns.Contains(pattern))
                throw new PatternCategoryException("This Regex pattern already exists");
            _patterns.Add(pattern);
        }

        #region Overrides

        public override string ToString() {
            return Name;
        }

        public override bool Equals(object obj) {
            if (obj == null || obj.GetType() != GetType())
                return false;
            return 0 == string.Compare(Name, ((RegexPatternCategory) obj).Name);
        }

        public override int GetHashCode() {
            return Name.GetHashCode();
        }

        #endregion

        private class RegexPatternCategoryComparer : IComparer {
            #region IComparer Members

            public int Compare(object x, object y) {
                if (null != x && null != y)
                    return string.Compare(x.ToString(), y.ToString());
                else if (null == x && null == y)
                    return 0;
                return 1;
            }

            #endregion
        }
    }
}