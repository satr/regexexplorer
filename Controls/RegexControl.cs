using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RegexExplorer.Controls;
using RegexExplorer;

namespace RegexExplorer {
    public class RegexControl : UserControl, ICheckClearEdit, IRegexPatternActions, IValueControl {
        #region Controls

        private Container components = null;
        private Button btnCheck;

        #endregion

        private Scaler _scaler;
        private RegexOptionsHolder _regexOptionsHolder = new RegexOptionsHolder();
        private RegexPatternControl regexPatternControl;
        private RegexPattern _loadedFavoritePattern;
        private Preferences _prefs = new Preferences();

        public event CheckClearEventHandler OnCheck;
        public event ScaleEventHandler OnScale;
        public event RegexExplorerEventHandler OnFavoriteItemChanged;

        public RegexControl() {
            InitializeComponent();
            ResizeAll();
            _scaler = new Scaler(regexPatternControl.RegexPatternFont);
            regexPatternControl.OnResize += new RegexExplorerEventHandler(ResizeAll);
            regexPatternControl.OnPressEnter += new RegexExplorerEventHandler(Check);
            regexPatternControl.OnChanged += new RegexExplorerEventHandler(regexPatternControl_OnChanged);
            regexPatternControl.OnGetHistory +=
                new RegexExplorerGetHistoryListEventHandler(regexPatternControl_OnGetHistory);
            btnCheck.Click += new EventHandler(btnCheck_Click);
        }

        public Regex RegexInstance {
            get { return new Regex(CurrentPattern.Value, _regexOptionsHolder.Value); }
        }

        public Preferences Preferences {
            set {
                _prefs = value;
                RegexPatternsDescriptionIsVisible = _prefs.RegexPatternsDescriptionIsVisible;
                RegexPatternsResultIsVisible = _prefs.RegexPatternsResultIsVisible;
                CurrentScaleIndex = _prefs.ScaleIndex;
            }
        }

        public RegexOptionsHolder RegexOptionsHolder {
            get { return _regexOptionsHolder; }
            set { _regexOptionsHolder = value; }
        }

        public RegexPattern CurrentPattern {
            get { return (RegexPattern) regexPatternControl.Value; }
        }

        public void StorePattern() {
            if (PatternIsEmpty())
                return;
            AddPatternToList(HistoryRegexPatternsList.Activate(), true, true);
        }

        public void AddOrReplayPatternInFavorites() {
            AddOrReplayPatternInFavorites(false);
        }

        public void AddPatternToFavorites() {
            AddOrReplayPatternInFavorites(true);
        }

        private void AddOrReplayPatternInFavorites(bool forceAddition) {
            if (PatternIsEmpty())
                return;
            FavoriteRegexPatternsList patternsList = FavoriteRegexPatternsList.Activate();
            CurrentPattern.IsFavorite = true;
            AddPatternToList(patternsList, false, forceAddition);
            patternsList.Save();
            FavoriteItemChanged();
        }

        private bool PatternIsEmpty() {
            return regexPatternControl.IsEmpty;
        }

        private void AddPatternToList(StoredRegexPatternsList patternsList, bool updateCreationDate, bool forceAddition) {
            RegexPattern clonedCurrentPattern = (RegexPattern) CurrentPattern.Clone();
            if (updateCreationDate)
                clonedCurrentPattern.CreatedOn = DateTime.Now;
            if (forceAddition) {
                patternsList.Add(clonedCurrentPattern);
                InitLoadedFavoritePatternFor(clonedCurrentPattern);
                return;
            }
            object keyRegexPattern = (_loadedFavoritePattern != null) ? _loadedFavoritePattern : clonedCurrentPattern;
            patternsList.AddOrUpdate(keyRegexPattern, clonedCurrentPattern);
            InitLoadedFavoritePatternFor(clonedCurrentPattern);
        }

        private void InitLoadedFavoritePatternFor(object pattern) {
            _loadedFavoritePattern = ((pattern == null) ? null : (RegexPattern) ((RegexPattern) pattern).Clone());
        }

        public void UpdateFavoritePattern() {
            if (!PatternIsChanged)
                return;
            AddOrReplayPatternInFavorites();
        }

        public bool PatternIsChanged {
            get { return regexPatternControl.IsChanged; }
        }

        public bool PatternIsFavorite {
            get { return regexPatternControl.IsFavorite; }
        }

        protected override void Dispose(bool disposing) {
            if (disposing)
                if (components != null)
                    components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            this.btnCheck = new System.Windows.Forms.Button();
            this.regexPatternControl = new RegexExplorer.Controls.RegexPatternControl();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCheck.Location = new System.Drawing.Point(0, 0);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(64, 112);
            this.btnCheck.TabIndex = 37;
            this.btnCheck.TabStop = false;
            this.btnCheck.Text = "Check";
            // 
            // regexPatternControl
            // 
            this.regexPatternControl.DescriptionIsVisible = true;
            this.regexPatternControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.regexPatternControl.Location = new System.Drawing.Point(64, 0);
            this.regexPatternControl.Name = "regexPatternControl";
            this.regexPatternControl.ReadOnlyDescription = false;
            this.regexPatternControl.ReadOnlyRegexPattern = false;
            this.regexPatternControl.ReadOnlyResult = true;
            this.regexPatternControl.RegexPatternFont =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular,
                                        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
            this.regexPatternControl.ResultIsVisible = true;
            this.regexPatternControl.Size = new System.Drawing.Size(584, 112);
            this.regexPatternControl.TabIndex = 40;
            // 
            // RegexControl
            // 
            this.Controls.Add(this.regexPatternControl);
            this.Controls.Add(this.btnCheck);
            this.Name = "RegexControl";
            this.Size = new System.Drawing.Size(648, 112);
            this.ResumeLayout(false);
        }

        #endregion

        public void Check() {
            if (OnCheck != null)
                OnCheck();
        }

        public void Clear() {
            regexPatternControl.Clear();
        }

        public void Copy() {
            EditionHelper.copy(regexPatternControl.ActiveField.Text,
                               SelectionStart,
                               SelectionLength);
        }

        public void Cut() {
            int selectionStart = SelectionStart;
            regexPatternControl.ActiveField.Text =
                EditionHelper.cut(regexPatternControl.ActiveField.Text,
                                  SelectionStart,
                                  SelectionLength);
            SelectionStart = selectionStart;
            SelectionLength = 0;
        }

        private int SelectionStart {
            get { return GetPositiveValueFor(regexPatternControl.ActiveField.SelectionStart); }
            set { regexPatternControl.ActiveField.SelectionStart = GetPositiveValueFor(value); }
        }

        private int SelectionLength {
            get { return GetPositiveValueFor(regexPatternControl.ActiveField.SelectionLength); }
            set { regexPatternControl.ActiveField.SelectionLength = GetPositiveValueFor(value); }
        }

        private int GetPositiveValueFor(int value) {
            return value < 0 ? 0 : value;
        }

        public void Paste() {
            int rightPos = regexPatternControl.ActiveField.Text.Length - (SelectionLength + SelectionLength);
            regexPatternControl.ActiveField.Text =
                EditionHelper.paste(regexPatternControl.ActiveField.Text,
                                    SelectionStart,
                                    SelectionLength);
            SelectionStart = regexPatternControl.ActiveField.Text.Length - rightPos;
        }

        private void ResizeAll() {
            Height = btnCheck.Height = regexPatternControl.Height;
            Refresh();
        }

        public void ScaleDown() {
            ScaleFor(_scaler.prevFont, _scaler.currentScaleIndex);
        }

        public void ScaleUp() {
            ScaleFor(_scaler.nextFont, _scaler.currentScaleIndex);
        }

        private void ScaleFor(Font newFont, int initIndex) {
            regexPatternControl.RegexPatternFont = newFont;
            if (initIndex != _scaler.currentScaleIndex && OnScale != null)
                OnScale(_scaler.currentScaleIndex);
        }

        public int CurrentScaleIndex {
            get { return _scaler.currentScaleIndex; }
            set {
                _scaler.currentScaleIndex = value;
                regexPatternControl.RegexPatternFont = _scaler.currentFont;
            }
        }

        #region IRegexPatternActions members

        public void AddToFavorites(RegexPattern pattern) {
            throw new NotImplementedException();
        }

        public RegexPattern GetFromFavorites() {
            throw new NotImplementedException();
        }

        #endregion

        private void btnCheck_Click(object sender, EventArgs e) {
            Check();
        }

        [Browsable(false)]
        public object Value {
            get { return regexPatternControl.Value; }
            set { regexPatternControl.Value = ((value as RegexPattern) == null) ? new RegexPattern() : value; }
        }

        public void OpenRegexPattern(MainController mainController) {
            RegexPattern nextLoadedPattern =
                OpenRegexPatternBy(mainController, StoredRegexPatternsForm.ActiveList.Favorites);
            if (nextLoadedPattern == null)
                return;
            InitLoadedFavoritePatternFor(nextLoadedPattern);
        }

        private RegexPattern OpenRegexPatternBy(MainController mainController,
                                                StoredRegexPatternsForm.ActiveList activeList) {
            StoredRegexPatternsForm form = new StoredRegexPatternsForm(mainController, activeList);
            if (form.ShowDialog() != DialogResult.OK)
                return null;
            RegexPattern pattern = form.LoadedRegexPattern;
            pattern.IsFavorite = true;
            Value = pattern;
            return pattern;
        }

        public bool RegexPatternsDescriptionIsVisible {
            get { return regexPatternControl.DescriptionIsVisible; }
            set {
                regexPatternControl.DescriptionIsVisible = value;
                ResizeAll();
            }
        }

        public bool RegexPatternsResultIsVisible {
            get { return regexPatternControl.ResultIsVisible; }
            set {
                regexPatternControl.ResultIsVisible = value;
                ResizeAll();
            }
        }

        public bool ReadOnlyRegexMatchCaptionsResult {
            get { return regexPatternControl.ReadOnlyResult; }
            set { regexPatternControl.ReadOnlyResult = value; }
        }

        public void OpenHistory(MainController mainController) {
            OpenRegexPatternBy(mainController, StoredRegexPatternsForm.ActiveList.History);
            InitLoadedFavoritePatternFor(null);
        }

        private void regexPatternControl_OnChanged() {
            if (regexPatternControl.IsFavorite)
                FavoriteItemChanged();
        }

        private void FavoriteItemChanged() {
            if (OnFavoriteItemChanged != null)
                OnFavoriteItemChanged();
        }

        public void OpenPredefined(MainController mainController) {
            OpenRegexPatternBy(mainController, StoredRegexPatternsForm.ActiveList.Predefined);
            InitLoadedFavoritePatternFor(null);
        }

        private void regexPatternControl_OnGetHistory(ArrayList list) {
            list.AddRange(HistoryRegexPatternsList.Activate().Items);
        }

        public void InitHelpProvider(MainController mainController) {
            regexPatternControl.InitHelpProvider(mainController);
        }

        public void InsertSymbolOfPattern() {
            regexPatternControl.ShowRegexPatternsTipsList();
        }
    }
}