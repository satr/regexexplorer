using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using RegexExplorer.ToolBarControls;

namespace RegexExplorer {
    public enum RegexWorkModes : int {
        IsMatch = 0,
        Matches = 1,
        CheckByList = 2,
    }

    public abstract class RegexControllerBase : ICheckClearEdit {
        private readonly RegexControl _regexControl;
        protected readonly TitledTextField _targetTextField;
        protected readonly CheckResultControl _resultControl;
        protected ResultColors _resultColor = new ResultColors();
        private CheckClearToolBarControl _checkClearToolBarControl;
        private EditToolBarControl _editToolBarControl;
        protected StatusBarController _statusBarController;

        public RegexControllerBase(StatusBarController statusBarController, RegexControl regexControl,
                                   CheckResultControl resultControl, TitledTextField targetTextField,
                                   CheckClearToolBarControl checkClearToolBarControl,
                                   EditToolBarControl editToolBarControl)
            : this(statusBarController, regexControl, resultControl,
                   checkClearToolBarControl, editToolBarControl) {
            _targetTextField = targetTextField;
            resultControl.onShowMessage += new ShowMessageEventHandler(ShowComment);
        }

        public RegexControllerBase(StatusBarController statusBarController, RegexControl regexControl,
                                   CheckResultControl resultControl, CheckClearToolBarControl checkClearToolBarControl,
                                   EditToolBarControl editToolBarControl) {
            _regexControl = regexControl;
            _resultControl = resultControl;
            _checkClearToolBarControl = checkClearToolBarControl;
            _editToolBarControl = editToolBarControl;
            _resultColor.defaultBackColor = _resultControl.BackColor;
            _resultColor.defaultForeColor = _resultControl.ForeColor;
            _statusBarController = statusBarController;
            _checkClearToolBarControl.onClear += new CheckClearEventHandler(Clear);
            _editToolBarControl.onCopy += new EditionEventHandler(Copy);
            _editToolBarControl.onCut += new EditionEventHandler(Cut);
            _editToolBarControl.onPaste += new EditionEventHandler(Paste);
        }

        public abstract RegexWorkModes RegexWorkMode { get; }

        private void ShowResult(string msg, bool isPositive) {
            _resultControl.ResultText = msg;
            _resultControl.BackColor = BackColorBy(isPositive);
            _resultControl.ForeColor = ForeColorBy(isPositive);
        }

        protected virtual Color BackColorBy(bool isPositive) {
            return isPositive ? _resultColor.positiveBackColor : _resultColor.negativeBackColor;
        }

        protected virtual Color ForeColorBy(bool isPositive) {
            return isPositive ? _resultColor.positiveForeColor : _resultColor.negativeForeColor;
        }

        protected void ShowPositiveResult(string msg) {
            ShowResult(msg, true);
        }

        protected void ShowNegativeResult(string msg) {
            ShowResult(msg, false);
        }

        protected void ShowComment(string msg) {
            StatusBar.ShowMessage(msg);
        }

        protected void ShowComment(string msg, params object[] args) {
            StatusBar.ShowMessage(msg, args);
        }

        protected Regex CurrentRegex {
            get { return _regexControl.RegexInstance; }
        }

        public virtual void Check() {
            StatusBar.ClearMessage();
            _regexControl.StorePattern();
            ClearResult();
            ClearComments();
            if (_regexControl.CurrentPattern.Value.Length == 0)
                ShowComment(MsgsBase.Res.Pattern_is_empty);
        }

        protected void ClearResult() {
            _resultControl.BackColor = _resultColor.defaultBackColor;
            _resultControl.ForeColor = _resultColor.defaultForeColor;
            _resultControl.ResultText = "";
            _resultControl.Refresh();
        }

        protected void ClearComments() {
            _resultControl.showComment("");
        }

        public virtual void Clear() {
            StatusBar.ClearMessage();
            if (_targetTextField != null)
                _targetTextField.Text = string.Empty;
        }

        public virtual void Copy() {
            StatusBar.ClearMessage();
            if (_targetTextField == null)
                return;
            _targetTextField.Copy();
        }

        public virtual void Cut() {
            StatusBar.ClearMessage();
            if (_targetTextField == null)
                return;
            _targetTextField.Cut();
        }

        public virtual void Paste() {
            StatusBar.ClearMessage();
            if (_targetTextField == null)
                return;
            _targetTextField.Paste();
        }

        protected bool CurrentPatternIsMatchTo(string text) {
            bool match = false;
            try {
                match = CurrentRegex.IsMatch(text);
            }
            catch (Exception ex) {
                ShowNegativeResult(MsgsBase.Res.Error);
                ShowComment(MsgsBase.Res.ERROR_n, ex.Message);
                match = false;
            }
            return match;
        }

        protected StatusBarController StatusBar {
            get { return _statusBarController; }
        }

        public void ShowWaitCursor() {
            Cursor.Current = Cursors.WaitCursor;
        }

        public void ShowDefaultCursor() {
            Cursor.Current = Cursors.Default;
        }
        public virtual bool ReadOnlyRegexMatchCaptionsResult {
            get { return true; }
        }
    }
}