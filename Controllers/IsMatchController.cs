using System;
using RegexExplorer.ToolBarControls;

namespace RegexExplorer {
    public class IsMatchController : RegexControllerBase {
        public IsMatchController(StatusBarController statusBarController, RegexControl regexControl,
                                 CheckResultControl resultControl, TitledTextField targetTextField,
                                 CheckClearToolBarControl checkClearToolBarControl,
                                 EditToolBarControl editToolBarControl)
            : base(statusBarController, regexControl, resultControl, targetTextField, checkClearToolBarControl,
                   editToolBarControl) {
        }

        public override void Check() {
            ShowWaitCursor();
            base.Check();
            try {
                if (CurrentPatternIsMatchTo(_targetTextField.Text))
                    ShowPositiveResult(MsgsBase.Res.MATCH);
                else
                    ShowNegativeResult(MsgsBase.Res.Fault);
            }
            catch (Exception ex) {
                ShowNegativeResult(MsgsBase.Res.Error);
                ShowComment(MsgsBase.Res.ERROR_n, ex.Message);
            }
            ShowDefaultCursor();
        }

        public override RegexWorkModes RegexWorkMode {
            get { return RegexWorkModes.IsMatch; }
        }
    }
}