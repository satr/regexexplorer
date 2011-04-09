using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RegexExplorer.ToolBarControls;
using RegexExplorer;

namespace RegexExplorer {
    public class CheckByListController : RegexControllerBase, ILoadList, ISaveList {
        private EditableListControl _targetTestsList;
        private readonly Preferences _prefs;
        private readonly ListToolBarControl _listToolBarControl;

        public CheckByListController(Preferences prefs, StatusBarController statusBarController,
                                     RegexControl regexControl,
                                     CheckResultControl resultControl, EditableListControl targetTextsList,
                                     CheckClearToolBarControl checkClearToolBarControl,
                                     EditToolBarControl editToolBarControl,
                                     ListToolBarControl listToolBarControl)
            : base(statusBarController, regexControl, resultControl, checkClearToolBarControl, editToolBarControl) {
            _targetTestsList = targetTextsList;
            _prefs = prefs;
            _targetTestsList.keepTextAfterAddition = _prefs.KeepTextAfterAddition;
            _listToolBarControl = listToolBarControl;
            ListViewItem listViewItem = new ListViewItem();
            _resultColor.defaultBackColor = listViewItem.BackColor;
            _resultColor.defaultForeColor = listViewItem.ForeColor;
            _targetTestsList.onShowMessage += new ShowMessageEventHandler(TargetTestsList_onShowMessage);
            _listToolBarControl.onPasteList += new EditionEventHandler(PasteList);
            _listToolBarControl.onAppendList += new EditionEventHandler(AppendList);
            _listToolBarControl.onLoadList += new EditionEventHandler(LoadList);
            _listToolBarControl.onSaveList += new EditionEventHandler(SaveList);
            _targetTestsList.onKeepTextAfterAdditionFlagChanged +=
                new EditionEventHandler(TargetTestsList_onKeepTextAfterAdditionFlagChanged);
        }

        public override void Clear() {
            base.Clear();
            _targetTestsList.clear();
        }

        public override void Check() {
            ShowWaitCursor();
            base.Check();
            int matchesCount = 0;
            IList targetTextLines = _targetTestsList.items;
            for (int index = 0; index < targetTextLines.Count; index++) {
                try {
                    if (CurrentPatternIsMatchTo((string) targetTextLines[index])) {
                        ShowPositiveResultFor(index, MsgsBase.Res.MATCH);
                        matchesCount++;
                    }
                    else
                        ShowNegativeResultFor(index, MsgsBase.Res.Fault);
                }
                catch (Exception ex) {
                    ShowNegativeResultFor(index, MsgsBase.Res.Error);
                    ShowComment(MsgsBase.Res.ERROR_n, ex.Message);
                }
            }
            if (matchesCount > 0)
                base.ShowPositiveResult(
                    string.Format(MsgsBase.Res.N_match_es_from_M_lines, matchesCount, targetTextLines.Count));
            else
                base.ShowNegativeResult(MsgsBase.Res.No_matches);
            ShowDefaultCursor();
        }

        private void ShowNegativeResultFor(int index, string msg) {
            ShowResultFor(index, msg, false);
        }

        private void ShowPositiveResultFor(int index, string msg) {
            ShowResultFor(index, msg, true);
        }

        private void ShowResultFor(int index, string msg, bool isPositive) {
            _targetTestsList.setResultTextFor(index, msg);
            HighlightResultsFor(index, isPositive);
        }

        private void HighlightResultsFor(int index, bool isPositive) {
            _targetTestsList.setResultBackColorFor(index, BackColorBy(isPositive));
            _targetTestsList.setResultForeColorFor(index, ForeColorBy(isPositive));
        }

        protected override Color BackColorBy(bool isPositive) {
            if (_prefs.HighlightResultsInList)
                return base.BackColorBy(isPositive);
            return _resultColor.defaultBackColor;
        }

        protected override Color ForeColorBy(bool isPositive) {
            if (_prefs.HighlightResultsInList)
                return base.ForeColorBy(isPositive);
            return _resultColor.defaultForeColor;
        }

        public void PasteList() {
            PasteListFor(false);
        }

        public void AppendList() {
            PasteListFor(true);
        }

        private void PasteListFor(bool append) {
            string text = EditionHelper.paste();
            if (text == null)
                return;
            string[] list = new Regex(Environment.NewLine).Split(text);
            int acceptedItemsCount = _targetTestsList.initListFor(list, append);
            string actionDescription = append ? MsgsBase.Res.Appended : MsgsBase.Res.Pasted;
            StatusBar.ShowMessage(MsgsBase.Res.Performed_N_lines_from_M, actionDescription, acceptedItemsCount,
                                  list.Length);
        }

        public override void Copy() {
            StatusBar.ClearMessage();
            _targetTestsList.copy();
        }

        public override void Cut() {
            StatusBar.ClearMessage();
            _targetTestsList.cut();
        }

        public override void Paste() {
            StatusBar.ClearMessage();
            _targetTestsList.paste();
        }

        public bool HighlightResults {
            get { return _prefs.HighlightResultsInList; }
        }

        private void TargetTestsList_onKeepTextAfterAdditionFlagChanged() {
            _prefs.KeepTextAfterAddition = _targetTestsList.keepTextAfterAddition;
            _prefs.Save();
        }

        private void TargetTestsList_onShowMessage(string msg) {
            _statusBarController.ShowMessage(msg);
        }

        public void LoadList() {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            SetInitialListFolderFor(fileDialog);
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            ArrayList lines = LoadListFromFile(fileDialog.FileName);
            _targetTestsList.initListFor((string[]) lines.ToArray(typeof (string)), false);
        }

        private ArrayList LoadListFromFile(string fileName) {
            FileInfo fileInfo = new FileInfo(fileName);
            StoreInitialListFolderFor(fileInfo);
            ArrayList lines = new ArrayList();
            using (StreamReader file = fileInfo.OpenText()) {
                string text = "";
                while ((text = file.ReadLine()) != null)
                    lines.Add(text);
            }
            return lines;
        }

        private void StoreInitialListFolderFor(FileInfo fileInfo) {
            _prefs.InitialListFolder = fileInfo.DirectoryName;
            _prefs.Save();
        }

        private void SetInitialListFolderFor(FileDialog fileDialog) {
            if (_prefs.InitialListFolder != null
                && _prefs.InitialListFolder.Length > 0
                && new DirectoryInfo(_prefs.InitialListFolder).Exists)
                fileDialog.InitialDirectory = _prefs.InitialListFolder;
        }

        public void SaveList() {
            if (_targetTestsList.items.Count == 0) {
                ShowComment("List is empty");
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.RestoreDirectory = true;
            SetInitialListFolderFor(fileDialog);
            if (fileDialog.ShowDialog() != DialogResult.OK)
                return;
            SaveListIntoFile(fileDialog.FileName);
        }

        private void SaveListIntoFile(string fileName) {
            FileInfo fileInfo = new FileInfo(fileName);
            StoreInitialListFolderFor(fileInfo);
            using (StreamWriter file = fileInfo.CreateText()) {
                foreach (string item in _targetTestsList.items)
                    file.WriteLine(item);
            }
        }

        public void CopyUniqueSymbols() {
            ShowWaitCursor();
            StringBuilder builder = new StringBuilder();
            try {
                ArrayList symbols = new ArrayList();
                foreach (string item in _targetTestsList.items) {
                    foreach (char c in item.ToCharArray()) {
                        if(symbols.Contains(c))
                            continue;
                        symbols.Add(c);
                    }
                }
                symbols.Sort();
                foreach (char c in symbols)
                    builder.Append(c);
                EditionHelper.copy(builder.ToString());
            }
            finally {
                ShowDefaultCursor();
            }
            Messenger.ShowInfo(Msgs.Res.N_symbols_are_copied, builder.Length);
        }

        public override RegexWorkModes RegexWorkMode {
            get { return RegexWorkModes.CheckByList; }
        }
    }
}