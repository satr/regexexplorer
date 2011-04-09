namespace RegexExplorer {
    public class FavoriteRegexPatternsList : StoredRegexPatternsList {
        public FavoriteRegexPatternsList() {
            InitFileNameBy("FavoriteRegexPatternsList");
        }

        public static FavoriteRegexPatternsList Activate() {
            return (FavoriteRegexPatternsList) new FavoriteRegexPatternsList().Load();
        }

        public override int MaxItemsQuantity {
            get { return Preferences.Res.MaxRegexPatternFavoritesLength; }
        }
    }
}