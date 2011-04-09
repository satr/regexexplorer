namespace RegexExplorer {
    public interface IRegexPatternActions {
        void AddToFavorites(RegexPattern pattern);
        RegexPattern GetFromFavorites();
    }
}