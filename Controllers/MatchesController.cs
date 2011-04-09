using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RegexExplorer.Controls;
using RegexExplorer.ToolBarControls;
using RegexExplorer;

namespace RegexExplorer {
    public class MatchesController : RegexControllerBase, IOpenFile, IShowSelectedItems {
        private enum LoadingSource {
            TextField,
            File,
        }

        private ListBox _matchesListControl;
        private readonly FileToolBarControl _fileToolBarControl;
        private readonly MatchesFileItemControl _matchesFileItemControl;
        private string _targetTextFromFile = string.Empty;
        private LoadingSource _loadingSource;
        private RegexControl _regexControl;
        private readonly MainController _mainController;
        private MatchesTargetControl _matchesTargetControl;
        private MatchesResultControl _matchesResultControl;
        private ComboBox _groupsListControl;
        private ListView _captionsListControl;
        private Hashtable _resultControlsList = new Hashtable();
        private StringCollection _groupTitlesList = new StringCollection();

        public MatchesController(MainController mainController, StatusBarController statusBarController,
                                 RegexControl regexControl, CheckResultControl resultControl,
                                 MatchesTargetControl matchesTargetControl,
                                 MatchesResultControl matchesResultControl,
                                 CheckClearToolBarControl checkClearToolBarControl,
                                 EditToolBarControl editToolBarControl,
                                 FileToolBarControl fileToolBarControl)
            : base(statusBarController, regexControl, resultControl, matchesTargetControl.TargetTextMatchesField,
                   checkClearToolBarControl, editToolBarControl) {
            _regexControl = regexControl;
            _mainController = mainController;
            _matchesListControl = matchesResultControl.LbMatches;
            _groupsListControl = matchesResultControl.LbGroups;
            _captionsListControl = matchesResultControl.LvCaptions;
            _matchesResultControl = matchesResultControl;
            _fileToolBarControl = fileToolBarControl;
            _matchesFileItemControl = matchesTargetControl.MatchesFileItemControl;
            _matchesTargetControl = matchesTargetControl;
            _fileToolBarControl.OnOpenFile += new EditionEventHandler(OpenFile);
            _matchesFileItemControl.OnAddFileToFavorites +=
                new MatchesFileItemEventHandler(MatchesFileItemControl_OnAddFileToFavorites);
            _matchesFileItemControl.OnAddRegexPatternToFavorites +=
                new MatchesFileItemEventHandler(MatchesFileItemControl_OnAddRegexPatternToFavorites);
            _matchesResultControl.OnCaptionMode += new CaptionModeEventHandler(MatchesResultControl_OnCaptionMode);
            _matchesResultControl.InitHelpProvider(_mainController);
            UnlockTargetTextField();
        }

        private void ShowResult(MatchCollection matches) {
            foreach (Match match in matches)
                _matchesListControl.Items.Add(match.Value);
            if (matches.Count > 0)
                ShowPositiveResult(string.Format(MsgsBase.Res.N_match_es, matches.Count));
            else
                ShowNegativeResult(MsgsBase.Res.No_matches);
        }

        public override void Check() {
            ShowWaitCursor();
            base.Check();
            try {
                if (_matchesResultControl.MatchesTabIsActive)
                    GetMatches();
                else
                    GetCaptures();
            }
            catch (Exception ex) {
                ShowNegativeResult(MsgsBase.Res.Error);
                ShowComment(MsgsBase.Res.ERROR_n, ex.Message);
            }
            ShowDefaultCursor();
        }

        private void GetCaptures() {
            _groupsListControl.Items.Clear();
            _captionsListControl.Items.Clear();
            Match m = CurrentRegex.Match(CheckTextField() ? _targetTextField.Text : _targetTextFromFile);
            StringCollection resultValues = new StringCollection();
            Hashtable groups = new Hashtable();
            GetCuptionsResult(m, groups, resultValues);
            _resultControlsList = new Hashtable();
            PrepareResultValuesFor(resultValues);
            PrepareGroupsResultFor(groups);
            ShowResult(groups, resultValues);
        }

        private void ShowResult(Hashtable groups, StringCollection resultValues) {
            _groupsListControl.SelectedIndexChanged -= new EventHandler(GroupsListControl_SelectedIndexChanged);
            if ((resultValues != null && resultValues.Count > 0) || groups.Count > 0)
                ShowPositiveResult(MsgsBase.Res.There_are_matches);
            else
                ShowNegativeResult(MsgsBase.Res.No_matches);
            if (_groupsListControl.Items.Count == 0)
                return;
            _groupsListControl.SelectedIndex = 0;
            CopyCaptionsData();
            _groupsListControl.SelectedIndexChanged += new EventHandler(GroupsListControl_SelectedIndexChanged);
        }

        private void CopyCaptionsData() {
            if (_groupsListControl.Items.Count == 0 || _groupsListControl.SelectedIndex < 0)
                return;
            string selectedGroupTitle = _groupsListControl.Text;
            if (!_resultControlsList.Contains(selectedGroupTitle))
                return;
            _captionsListControl.Items.Clear();
            _captionsListControl.Columns.Clear();
            ListViewProperties listViewProperties = (ListViewProperties) _resultControlsList[selectedGroupTitle];
            _captionsListControl.Columns.AddRange(listViewProperties.GetColumnHeadersArray());
            _captionsListControl.Items.AddRange(listViewProperties.GetListViewItemsArray());
        }

        private void GetCuptionsResult(Match m, Hashtable groups, StringCollection resultValues) {
            string captionResultPattern = _regexControl.CurrentPattern.Result;
            bool hasCaptionResultPattern = captionResultPattern != null && captionResultPattern.Length > 0;
            _groupTitlesList = new StringCollection();
            while (m.Success) {
                if (hasCaptionResultPattern)
                    resultValues.Add(m.Result(captionResultPattern));
                int i = 0;
                foreach (Group group in m.Groups) {
                    if (i == 0) {
                        i++;
                        continue;
                    }
                    string groupTitle = string.Format(MsgsBase.Res.Group_No, i++);
                    if (!groups.Contains(groupTitle))
                        groups.Add(groupTitle, new ArrayList());
                    if (!_groupTitlesList.Contains(groupTitle))
                        _groupTitlesList.Add(groupTitle);
                    IList captures = new StringCollection();
                    ((IList) groups[groupTitle]).Add(captures);
                    foreach (Capture c1 in group.Captures)
                        captures.Add(c1.Value);
                }
                m = m.NextMatch();
            }
        }

        private void PrepareResultValuesFor(StringCollection resultValues) {
            if (resultValues.Count == 0)
                return;
            ListViewProperties listViewProperties = CreateListViewPropertiesFor(MsgsBase.Res.Values_by_result_pattern);
            foreach (string resultValue in resultValues)
                listViewProperties.AddItem(resultValue);
        }

        private void PrepareGroupsResultFor(Hashtable groups) {
            foreach (string groupTitle in _groupTitlesList) {
                IList captionsList = (IList) groups[groupTitle];
                int columnsCount = ((IList) captionsList[0]).Count;
                ListViewProperties listViewProperties =
                    CreateListViewPropertiesFor(columnsCount, groupTitle);
                foreach (StringCollection captions in captionsList)
                    listViewProperties.AddItem(captions);
            }
        }

        private ListViewProperties CreateListViewPropertiesFor(string title) {
            return CreateListViewPropertiesFor(1, title);
        }

        private ListViewProperties CreateListViewPropertiesFor(int columnCount, string format, params object[] args) {
            string title = string.Format(format, args);
            ListViewProperties listViewProperties = new ListViewProperties();
            listViewProperties.AddColumns(columnCount);
            _resultControlsList[title] = listViewProperties;
            _groupsListControl.Items.Add(title);
            return listViewProperties;
        }

        private void GetMatches() {
            _matchesListControl.Items.Clear();
            MatchCollection matches =
                CurrentRegex.Matches(CheckTextField() ? _targetTextField.Text : _targetTextFromFile);
            ShowResult(matches);
        }

        private bool CheckTextField() {
            return _loadingSource == LoadingSource.TextField;
        }

        public void SaveFile() {
            // do nothing
        }

        public void OpenFile() {
            try {
                OpenFileForm openFileForm = new OpenFileForm(_mainController, OpenFileForm.ActiveList.History);
                if (Preferences.Res.ShowOpenFileDialog)
                    openFileForm.ShowDialog();
                else
                    openFileForm.BrowseFiles();
                if (openFileForm.DialogResult != DialogResult.OK) {
                    if (LoadingSource.TextField == _loadingSource)
                        UnlockTargetTextField();
                    return;
                }
                InitTextLoadedFromFile(openFileForm);
            }
            catch (MatchesFilesException ex) {
                Messenger.ShowError(ex.Message);
                UnlockTargetTextField();
                return;
            }
        }

        private void InitTextLoadedFromFile(OpenFileForm openFileForm) {
            ClearTargetText();
            _targetTextFromFile = openFileForm.LoadedText;
            openFileForm.ClearLoadedText();
            ShowLoadedFileInfo(openFileForm.LoadedFileName());
            _loadingSource = LoadingSource.File;
        }

//    private void AddFileToFavorites(FavoriteFilesForm filesForm) {
//      _matchesFilesList.addFile(createMatchesFileInfo(filesForm.fileInfo));
//      _matchesFilesList.save();
//    }
//
        private void UnlockTargetTextField() {
            InitTargetControlsBy(true);
        }

        private void LockTargetTextField() {
            InitTargetControlsBy(false);
        }

        private void InitTargetControlsBy(bool textFieldIsActive) {
            _targetTextField.ReadOnly = !textFieldIsActive;
            _matchesTargetControl.FileItemIsEnabled = !textFieldIsActive;
            _matchesFileItemControl.Enabled = !textFieldIsActive;
            _loadingSource = textFieldIsActive ? LoadingSource.TextField : LoadingSource.File;
        }

        private void ShowLoadedFileInfo(string fileName) {
            int LENGTH_TEXT_TO_SHOW = 32767;
            bool fileIsTooLongToBeDisplayed = _targetTextFromFile.Length > LENGTH_TEXT_TO_SHOW;
            _targetTextField.Text = fileIsTooLongToBeDisplayed
                                        ? _targetTextFromFile.Substring(0, LENGTH_TEXT_TO_SHOW)
                                        : _targetTextFromFile;
            LockTargetTextField();
            MatchesFileItem matchesFileItem = CreateMatchesFileItemFor(fileName);
            ShowComment(string.Format(MsgsBase.Res.N_chars_are_loaded_from_the_file_M,
                                      _targetTextFromFile.Length, matchesFileItem.FullName));
            _matchesFileItemControl.Value = matchesFileItem;
        }

        private MatchesFileItem CreateMatchesFileItemFor(string fileName) {
            return new MatchesFileItem(fileName);
        }

        private void ClearTargetText() {
            base.Clear();
            UnlockTargetTextField();
            if (_matchesResultControl.MatchesTabIsActive) {
                _matchesListControl.Items.Clear();
            }
            else {
                _groupsListControl.Items.Clear();
                _captionsListControl.Items.Clear();
            }
            _targetTextFromFile = string.Empty;
        }

        public override void Clear() {
            ClearTargetText();
            _targetTextField.ReadOnly = false;
        }

        private void MatchesFileItemControl_OnAddFileToFavorites(MatchesFileItem matchesFileItem) {
            StoreMatchesFileItemFor(matchesFileItem);
        }

        private void StoreMatchesFileItemFor(MatchesFileItem matchesFileItem) {
            MatchesFilesList.Activate()
                .AddOrUpdate(matchesFileItem)
                .Save();
        }

        private void MatchesFileItemControl_OnAddRegexPatternToFavorites(MatchesFileItem matchesFileItem) {
            matchesFileItem.Patterns.Add(_regexControl.CurrentPattern);
            StoreMatchesFileItemFor(matchesFileItem);
        }

        public bool TargetFileIsLoaded {
            get { return _matchesFileItemControl.FileIsLoaded; }
        }

        public bool TargetFileIsInFavorites {
            get { return _matchesFileItemControl.FileIsInFavorites; }
        }

        public void ShowSelectedItems() {
            ShowItemsBy(true);
        }

        public void ShowAllItems() {
            ShowItemsBy(false);
        }

        private void ShowItemsBy(bool showSelected) {
            if (_matchesResultControl.MatchesTabIsActive)
                _matchesResultControl.ShowSelectedMatchesItems(showSelected);
            else
                _matchesResultControl.ShowSelectedCaptionsItems(showSelected);
        }

        public override RegexWorkModes RegexWorkMode {
            get { return RegexWorkModes.Matches; }
        }

        private void MatchesResultControl_OnCaptionMode(bool isActive) {
            _regexControl.ReadOnlyRegexMatchCaptionsResult = !isActive;
        }

        public override bool ReadOnlyRegexMatchCaptionsResult {
            get { return !_matchesResultControl.IsCaptionsMode; }
        }

        private void GroupsListControl_SelectedIndexChanged(object sender, EventArgs e) {
            CopyCaptionsData();
        }
    }
}