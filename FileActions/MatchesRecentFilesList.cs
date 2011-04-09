namespace RegexExplorer {
    public class MatchesRecentFilesList : MatchesFilesList {
        public MatchesRecentFilesList() {
            InitFileNameBy("MatchesRecentFilesList");
        }

        public override int MaxItemsQuantity {
            get { return Preferences.Res.MaxRecentFilesQuantity; }
        }

    }
}