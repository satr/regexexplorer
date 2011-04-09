using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RegexExplorer;

namespace RegexExplorer.Controls {
    public class RegexPatternControl : UserControl, IValueControl {
        #region Controls

        private Container components = null;
        private Panel pnlRegexPattern;
        private Panel pnlRegexPatternTitle;
        private Label lblRegexPattern;
        private Panel panel2;
        private Button btnShowHistory;
        private TextBox txtRegexPattern;
        private Panel pnlResult;
        private TextBox txtResult;
        private Panel panel6;
        private Panel pnlDescription;
        private TextBox txtDescription;
        private Panel pnlDescriptionTitle;
        private Label lblDescription;
        private Panel panel5;
        private Panel pnlResultTitle;
        private Label lblCaptionsResult;

        #endregion


        private RegexPattern _value = null;
        private QuickListForm _quickHistoryListForm = new QuickListForm();
        private QuickListForm _quickRegexPatternsTipsListForm = new QuickListForm(true);
        public event RegexExplorerEventHandler OnPressEnter;
        public event RegexExplorerEventHandler OnChanged;
        public event RegexExplorerGetHistoryListEventHandler OnGetHistory;
        new public event RegexExplorerEventHandler OnResize;

        public RegexPatternControl() {
            InitializeComponent();
            ResizeAll();
            BindRegexPatternOnArrowDown();
            txtRegexPattern.KeyPress += new KeyPressEventHandler(txtRegexPattern_KeyPress);
            BindEventsFor(txtRegexPattern);
            BindEventsFor(txtResult);
            BindEventsFor(txtDescription);
            InitQuickHistoryList();
            InitRegexPatternsTipsList();
        }

        private void InitRegexPatternsTipsList() {
            _quickRegexPatternsTipsListForm = new QuickListForm(true);
            _quickRegexPatternsTipsListForm.OnSelectPattern += new RegexPatternEventHandler(QuickRegexPatternsTipsListForm_OnSelectPattern);
            _quickRegexPatternsTipsListForm.OnShow += new RegexExplorerEventHandler(UnBindRegexPatternOnArrowUp); 
            _quickRegexPatternsTipsListForm.OnHide += new RegexExplorerEventHandler(BindRegexPatternOnArrowUp);
        }

        private void InitQuickHistoryList() {
            _quickHistoryListForm = new QuickListForm();
            _quickHistoryListForm.OnSelectPattern += new RegexPatternEventHandler(_quickHistoryListForm_OnSelectPattern);
            _quickHistoryListForm.OnShow += new RegexExplorerEventHandler(UnBindRegexPatternOnArrowDown); 
            _quickHistoryListForm.OnHide += new RegexExplorerEventHandler(BindRegexPatternOnArrowDown);
        }

        private void BindRegexPatternOnArrowDown() {
            txtRegexPattern.KeyDown += new KeyEventHandler(txtRegexPattern_KeyDown);
        }

        private void UnBindRegexPatternOnArrowDown() {
            txtRegexPattern.KeyDown -= new KeyEventHandler(txtRegexPattern_KeyDown);
        }

        private void BindRegexPatternOnArrowUp() {
            txtRegexPattern.KeyDown += new KeyEventHandler(txtRegexPattern_KeyDown);
        }

        private void UnBindRegexPatternOnArrowUp() {
            txtRegexPattern.KeyDown -= new KeyEventHandler(txtRegexPattern_KeyDown);
        }

        private void BindEventsFor(TextBox textBox) {
            textBox.Validated += new EventHandler(Value_Validated);
            textBox.LostFocus += new EventHandler(Value_Validated);
        }

        [Browsable(false)]
        public object Value {
            get {
                if (_value == null)
                    _value = new RegexPattern();
                _value.Value = txtRegexPattern.Text;
                _value.Result = txtResult.Text;
                _value.Description = txtDescription.Text;
                return _value;
            }
            set {
                _value = ((value as RegexPattern) == null) ? new RegexPattern() : (RegexPattern) value;
                txtRegexPattern.Text = _value.Value;
                txtResult.Text = _value.Result;
                txtDescription.Text = _value.Description;
            }
        }

        [Browsable(false)]
        public bool IsChanged {
            get {
                return (_value.Value != txtRegexPattern.Text
                        || _value.Result != txtResult.Text
                        || _value.Description != txtDescription.Text);
            }
        }

        public bool IsEmpty {
            get { return (txtRegexPattern.Text.Length == 0); }
        }

        public bool ReadOnlyResult {
            get { return txtResult.ReadOnly; }
            set { txtResult.TabStop = !(txtResult.ReadOnly = value); }
        }

        public bool ReadOnlyDescription {
            get { return txtDescription.ReadOnly; }
            set { txtDescription.TabStop = !(txtDescription.ReadOnly = value); }
        }

        public bool ReadOnlyRegexPattern {
            get { return txtRegexPattern.ReadOnly; }
            set {
                btnShowHistory.Visible = !value;
                txtRegexPattern.TabStop = !(txtRegexPattern.ReadOnly = value);
            }
        }

        public bool ResultIsVisible {
            get { return pnlResult.Visible; }
            set {
                pnlResult.Visible = value;
                ResizeAll();
            }
        }

        public bool DescriptionIsVisible {
            get { return pnlDescription.Visible; }
            set {
                pnlDescription.Visible = value;
                ResizeAll();
            }
        }

        public bool IsFavorite {
            get {
                if (_value == null)
                    return false;
                return _value.IsFavorite;
            }
        }

        public TextBox ActiveField {
            get {
                if (txtRegexPattern.Focused)
                    return txtRegexPattern;
                if (txtResult.Focused)
                    return txtResult;
                if (txtDescription.Focused)
                    return txtDescription;
                return new TextBox();
            }
        }

        public Font RegexPatternFont {
            get { return txtRegexPattern.Font; }
            set {
                if (value == null)
                    return;
                txtRegexPattern.Font = value;
                ResizeAll();
            }
        }

        private void ResizeAll() {
            pnlRegexPattern.Height = txtRegexPattern.Height + pnlRegexPatternTitle.Height;
            pnlResult.Height = txtResult.Height + pnlResultTitle.Height;
            pnlDescription.Height = txtDescription.Height + pnlRegexPatternTitle.Height;
            Height = pnlRegexPattern.Height
                     + (ResultIsVisible ? pnlResult.Height : 0)
                     + (DescriptionIsVisible ? pnlDescription.Height : 0);
            if (OnResize != null)
                OnResize();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) if (components != null) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            this.pnlRegexPattern = new System.Windows.Forms.Panel();
            this.txtRegexPattern = new System.Windows.Forms.TextBox();
            this.btnShowHistory = new System.Windows.Forms.Button();
            this.pnlRegexPatternTitle = new System.Windows.Forms.Panel();
            this.lblRegexPattern = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.pnlResultTitle = new System.Windows.Forms.Panel();
            this.lblCaptionsResult = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlDescription = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.pnlDescriptionTitle = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pnlRegexPattern.SuspendLayout();
            this.pnlRegexPatternTitle.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.pnlResultTitle.SuspendLayout();
            this.pnlDescription.SuspendLayout();
            this.pnlDescriptionTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRegexPattern
            // 
            this.pnlRegexPattern.Controls.Add(this.txtRegexPattern);
            this.pnlRegexPattern.Controls.Add(this.btnShowHistory);
            this.pnlRegexPattern.Controls.Add(this.pnlRegexPatternTitle);
            this.pnlRegexPattern.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRegexPattern.Location = new System.Drawing.Point(0, 0);
            this.pnlRegexPattern.Name = "pnlRegexPattern";
            this.pnlRegexPattern.Size = new System.Drawing.Size(616, 40);
            this.pnlRegexPattern.TabIndex = 13;
            // 
            // txtRegexPattern
            // 
            this.txtRegexPattern.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRegexPattern.Location = new System.Drawing.Point(0, 16);
            this.txtRegexPattern.Name = "txtRegexPattern";
            this.txtRegexPattern.ReadOnly = true;
            this.txtRegexPattern.Size = new System.Drawing.Size(592, 20);
            this.txtRegexPattern.TabIndex = 9;
            this.txtRegexPattern.TabStop = false;
            this.txtRegexPattern.Text = "";
            // 
            // btnShowHistory
            // 
            this.btnShowHistory.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnShowHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShowHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.btnShowHistory.Location = new System.Drawing.Point(592, 16);
            this.btnShowHistory.Name = "btnShowHistory";
            this.btnShowHistory.Size = new System.Drawing.Size(24, 24);
            this.btnShowHistory.TabIndex = 8;
            this.btnShowHistory.TabStop = false;
            this.btnShowHistory.Text = "V";
            this.btnShowHistory.Click += new System.EventHandler(this.btnShowHistory_Click);
            // 
            // pnlRegexPatternTitle
            // 
            this.pnlRegexPatternTitle.Controls.Add(this.lblRegexPattern);
            this.pnlRegexPatternTitle.Controls.Add(this.panel2);
            this.pnlRegexPatternTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRegexPatternTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlRegexPatternTitle.Name = "pnlRegexPatternTitle";
            this.pnlRegexPatternTitle.Size = new System.Drawing.Size(616, 16);
            this.pnlRegexPatternTitle.TabIndex = 0;
            // 
            // lblRegexPattern
            // 
            this.lblRegexPattern.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRegexPattern.Location = new System.Drawing.Point(8, 0);
            this.lblRegexPattern.Name = "lblRegexPattern";
            this.lblRegexPattern.Size = new System.Drawing.Size(608, 16);
            this.lblRegexPattern.TabIndex = 1;
            this.lblRegexPattern.Text = "Regex pattern";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(8, 16);
            this.panel2.TabIndex = 0;
            // 
            // pnlResult
            // 
            this.pnlResult.Controls.Add(this.txtResult);
            this.pnlResult.Controls.Add(this.pnlResultTitle);
            this.pnlResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResult.Location = new System.Drawing.Point(0, 40);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(616, 40);
            this.pnlResult.TabIndex = 17;
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(0, 16);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(616, 20);
            this.txtResult.TabIndex = 7;
            this.txtResult.TabStop = false;
            this.txtResult.Text = "";
            // 
            // pnlResultTitle
            // 
            this.pnlResultTitle.Controls.Add(this.lblCaptionsResult);
            this.pnlResultTitle.Controls.Add(this.panel6);
            this.pnlResultTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlResultTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlResultTitle.Name = "pnlResultTitle";
            this.pnlResultTitle.Size = new System.Drawing.Size(616, 16);
            this.pnlResultTitle.TabIndex = 0;
            // 
            // lblCaptionsResult
            // 
            this.lblCaptionsResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCaptionsResult.Location = new System.Drawing.Point(8, 0);
            this.lblCaptionsResult.Name = "lblCaptionsResult";
            this.lblCaptionsResult.Size = new System.Drawing.Size(608, 16);
            this.lblCaptionsResult.TabIndex = 1;
            this.lblCaptionsResult.Text = "Captions result pattern";
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(8, 16);
            this.panel6.TabIndex = 0;
            // 
            // pnlDescription
            // 
            this.pnlDescription.Controls.Add(this.txtDescription);
            this.pnlDescription.Controls.Add(this.pnlDescriptionTitle);
            this.pnlDescription.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescription.Location = new System.Drawing.Point(0, 80);
            this.pnlDescription.Name = "pnlDescription";
            this.pnlDescription.Size = new System.Drawing.Size(616, 40);
            this.pnlDescription.TabIndex = 18;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescription.Location = new System.Drawing.Point(0, 16);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(616, 20);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.TabStop = false;
            this.txtDescription.Text = "";
            // 
            // pnlDescriptionTitle
            // 
            this.pnlDescriptionTitle.Controls.Add(this.lblDescription);
            this.pnlDescriptionTitle.Controls.Add(this.panel5);
            this.pnlDescriptionTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDescriptionTitle.Location = new System.Drawing.Point(0, 0);
            this.pnlDescriptionTitle.Name = "pnlDescriptionTitle";
            this.pnlDescriptionTitle.Size = new System.Drawing.Size(616, 16);
            this.pnlDescriptionTitle.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescription.Location = new System.Drawing.Point(8, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(608, 16);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "Description";
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(8, 16);
            this.panel5.TabIndex = 0;
            // 
            // RegexPatternControl
            // 
            this.Controls.Add(this.pnlDescription);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.pnlRegexPattern);
            this.Name = "RegexPatternControl";
            this.Size = new System.Drawing.Size(616, 120);
            this.pnlRegexPattern.ResumeLayout(false);
            this.pnlRegexPatternTitle.ResumeLayout(false);
            this.pnlResult.ResumeLayout(false);
            this.pnlResultTitle.ResumeLayout(false);
            this.pnlDescription.ResumeLayout(false);
            this.pnlDescriptionTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void txtRegexPattern_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char) 13)
                return;
            e.Handled = true;
            if (OnPressEnter != null)
                OnPressEnter();
            Changed();
        }

        public void Clear() {
            Value = null;
        }

        private void Value_Validated(object sender, EventArgs e) {
            Changed();
        }

        private void Changed() {
            if (OnChanged != null)
                OnChanged();
        }

        private void btnShowHistory_Click(object sender, EventArgs e) {
            ShowHistoryList();
        }

        private void ShowHistoryList() {
            if (OnGetHistory == null)
                return;
            ArrayList historyList = new ArrayList();
            OnGetHistory(historyList);
            if (historyList.Count == 0)
                return;
            ShowQuickListFor(historyList, _quickHistoryListForm, false);
        }

        public void ShowRegexPatternsTipsList() {
            _quickRegexPatternsTipsListForm.Text = Msgs.Res.InsertPatternSymbols;
            ShowQuickListFor(RegexPatternsTipsList.Activate().Items, _quickRegexPatternsTipsListForm, true);
        }

        private void ShowQuickListFor(ArrayList patternsList, QuickListForm quickListForm, bool showDescription) {
            Control form = txtRegexPattern.TopLevelControl;
            Point location = form.Location;
            Control parent = txtRegexPattern.Parent;
            int x = txtRegexPattern.Location.X + (form.Bounds.Width - form.ClientRectangle.Width) / 2 ;
            int y = txtRegexPattern.Location.Y + (form.Bounds.Height - form.ClientRectangle.Height) / 2;
            while(parent != form) {
                x += parent.Location.X;
                y += parent.Location.Y;
                parent = parent.Parent;
            }
            location.X = location.X + x;
            location.Y = location.Y + y + 23 + txtRegexPattern.Height;
            quickListForm.Location = location;
            quickListForm.Width = txtRegexPattern.Width;
            quickListForm.SetDataList(patternsList, showDescription);
            quickListForm.Show();
        }

        private void CheckQuickListSelection(QuickListForm quickListForm, RegexPattern regexPattern, bool replacePattern) {
            quickListForm.Hide();
            if(replacePattern) {
                Value = regexPattern;
                if(txtRegexPattern.Text.Length == 0)
                    return;
                txtRegexPattern.Select(txtRegexPattern.Text.Length - 1, 0);
            }
            else {
                EditionHelper.Insert(txtRegexPattern, regexPattern.Value);
                RegexPatternEx regexPatternEx = regexPattern as RegexPatternEx;
                if(regexPatternEx == null || regexPatternEx.ShiftCursorLeft == 0)
                    return;
                txtRegexPattern.Select(txtRegexPattern.SelectionStart - regexPatternEx.ShiftCursorLeft, regexPatternEx.SelectionLength);
            }
        }

        private void txtRegexPattern_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Down) {
                e.Handled = true;
                ShowHistoryList();
                return;
            }
            else if (e.KeyCode == Keys.Up) {
                e.Handled = true;
                ShowRegexPatternsTipsList();
                return;
            }
        }

        public void InitHelpProvider(MainController mainController) {
            mainController.SetHelpProviderFor(txtResult, "Captions");
        }

        private void QuickRegexPatternsTipsListForm_OnSelectPattern(RegexPattern regexPattern) {
            CheckQuickListSelection(_quickRegexPatternsTipsListForm, regexPattern, false);        
        }

        private void _quickHistoryListForm_OnSelectPattern(RegexPattern regexPattern) {
            CheckQuickListSelection(_quickHistoryListForm, regexPattern, true);
        }
    }
}