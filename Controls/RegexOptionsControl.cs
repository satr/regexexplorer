using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegexExplorer.Controls {
    public class RegexOptionsControl : UserControl {
        #region Controls

        private GroupBox groupBoxRegexOptions;
        private CheckBox cbECMAScript;
        private CheckBox cbCultureInvariant;
        private CheckBox cbCompiled;
        private CheckBox cbExplicitCapture;
        private CheckBox cbRightToLeft;
        private CheckBox cbSingleline;
        private CheckBox cbMultiline;
        private CheckBox cbIgnorePatternWhitespace;
        private CheckBox cbIgnoreCase;

        #endregion

        private bool _singleline = false;
        private bool _multiline = false;
        private bool _ignoreCase = false;
        private bool _compiled = false;
        private RegexOptionsHolder _holder = new RegexOptionsHolder();

        private Container components = null;

        public RegexOptionsControl() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBoxRegexOptions = new GroupBox();
            this.cbECMAScript = new CheckBox();
            this.cbCultureInvariant = new CheckBox();
            this.cbCompiled = new CheckBox();
            this.cbExplicitCapture = new CheckBox();
            this.cbRightToLeft = new CheckBox();
            this.cbSingleline = new CheckBox();
            this.cbMultiline = new CheckBox();
            this.cbIgnorePatternWhitespace = new CheckBox();
            this.cbIgnoreCase = new CheckBox();
            this.groupBoxRegexOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRegexOptions
            // 
            this.groupBoxRegexOptions.Controls.Add(this.cbECMAScript);
            this.groupBoxRegexOptions.Controls.Add(this.cbCultureInvariant);
            this.groupBoxRegexOptions.Controls.Add(this.cbCompiled);
            this.groupBoxRegexOptions.Controls.Add(this.cbExplicitCapture);
            this.groupBoxRegexOptions.Controls.Add(this.cbRightToLeft);
            this.groupBoxRegexOptions.Controls.Add(this.cbSingleline);
            this.groupBoxRegexOptions.Controls.Add(this.cbMultiline);
            this.groupBoxRegexOptions.Controls.Add(this.cbIgnorePatternWhitespace);
            this.groupBoxRegexOptions.Controls.Add(this.cbIgnoreCase);
            this.groupBoxRegexOptions.Dock = DockStyle.Top;
            this.groupBoxRegexOptions.FlatStyle = FlatStyle.System;
            this.groupBoxRegexOptions.Location = new Point(0, 0);
            this.groupBoxRegexOptions.Name = "groupBoxRegexOptions";
            this.groupBoxRegexOptions.Size = new Size(576, 64);
            this.groupBoxRegexOptions.TabIndex = 29;
            this.groupBoxRegexOptions.TabStop = false;
            this.groupBoxRegexOptions.Text = "Regex options";
            this.groupBoxRegexOptions.Enter += new EventHandler(this.groupBoxRegexOptions_Enter);
            // 
            // cbECMAScript
            // 
            this.cbECMAScript.FlatStyle = FlatStyle.System;
            this.cbECMAScript.Location = new Point(392, 16);
            this.cbECMAScript.Name = "cbECMAScript";
            this.cbECMAScript.Size = new Size(80, 16);
            this.cbECMAScript.TabIndex = 13;
            this.cbECMAScript.TabStop = false;
            this.cbECMAScript.Text = "ECMAScript";
            // 
            // cbCultureInvariant
            // 
            this.cbCultureInvariant.FlatStyle = FlatStyle.System;
            this.cbCultureInvariant.Location = new Point(296, 32);
            this.cbCultureInvariant.Name = "cbCultureInvariant";
            this.cbCultureInvariant.Size = new Size(104, 16);
            this.cbCultureInvariant.TabIndex = 13;
            this.cbCultureInvariant.TabStop = false;
            this.cbCultureInvariant.Text = "CultureInvariant";
            // 
            // cbCompiled
            // 
            this.cbCompiled.FlatStyle = FlatStyle.System;
            this.cbCompiled.Location = new Point(296, 16);
            this.cbCompiled.Name = "cbCompiled";
            this.cbCompiled.Size = new Size(104, 16);
            this.cbCompiled.TabIndex = 13;
            this.cbCompiled.TabStop = false;
            this.cbCompiled.Text = "Compiled";
            this.cbCompiled.CheckedChanged += new EventHandler(this.cbCompiled_CheckedChanged);
            // 
            // cbExplicitCapture
            // 
            this.cbExplicitCapture.FlatStyle = FlatStyle.System;
            this.cbExplicitCapture.Location = new Point(200, 16);
            this.cbExplicitCapture.Name = "cbExplicitCapture";
            this.cbExplicitCapture.Size = new Size(104, 16);
            this.cbExplicitCapture.TabIndex = 13;
            this.cbExplicitCapture.TabStop = false;
            this.cbExplicitCapture.Text = "ExplicitCapture";
            // 
            // cbRightToLeft
            // 
            this.cbRightToLeft.FlatStyle = FlatStyle.System;
            this.cbRightToLeft.Location = new Point(200, 32);
            this.cbRightToLeft.Name = "cbRightToLeft";
            this.cbRightToLeft.Size = new Size(104, 16);
            this.cbRightToLeft.TabIndex = 13;
            this.cbRightToLeft.TabStop = false;
            this.cbRightToLeft.Text = "RightToLeft";
            // 
            // cbSingleline
            // 
            this.cbSingleline.FlatStyle = FlatStyle.System;
            this.cbSingleline.Location = new Point(112, 16);
            this.cbSingleline.Name = "cbSingleline";
            this.cbSingleline.Size = new Size(104, 16);
            this.cbSingleline.TabIndex = 13;
            this.cbSingleline.TabStop = false;
            this.cbSingleline.Text = "Singleline";
            this.cbSingleline.CheckedChanged += new EventHandler(this.cbSingleline_CheckedChanged);
            // 
            // cbMultiline
            // 
            this.cbMultiline.FlatStyle = FlatStyle.System;
            this.cbMultiline.Location = new Point(112, 32);
            this.cbMultiline.Name = "cbMultiline";
            this.cbMultiline.Size = new Size(104, 16);
            this.cbMultiline.TabIndex = 13;
            this.cbMultiline.TabStop = false;
            this.cbMultiline.Text = "Multiline";
            this.cbMultiline.CheckedChanged += new EventHandler(this.cbMultiline_CheckedChanged);
            // 
            // cbIgnorePatternWhitespace
            // 
            this.cbIgnorePatternWhitespace.FlatStyle = FlatStyle.System;
            this.cbIgnorePatternWhitespace.Location = new Point(8, 32);
            this.cbIgnorePatternWhitespace.Name = "cbIgnorePatternWhitespace";
            this.cbIgnorePatternWhitespace.Size = new Size(112, 30);
            this.cbIgnorePatternWhitespace.TabIndex = 13;
            this.cbIgnorePatternWhitespace.TabStop = false;
            this.cbIgnorePatternWhitespace.Text = "Ignore Pattern Whitespace";
            this.cbIgnorePatternWhitespace.TextAlign = ContentAlignment.TopLeft;
            // 
            // cbIgnoreCase
            // 
            this.cbIgnoreCase.FlatStyle = FlatStyle.System;
            this.cbIgnoreCase.Location = new Point(8, 16);
            this.cbIgnoreCase.Name = "cbIgnoreCase";
            this.cbIgnoreCase.Size = new Size(104, 16);
            this.cbIgnoreCase.TabIndex = 13;
            this.cbIgnoreCase.TabStop = false;
            this.cbIgnoreCase.Text = "IgnoreCase";
            this.cbIgnoreCase.CheckedChanged += new EventHandler(this.cbIgnoreCase_CheckedChanged);
            // 
            // RegexOptionsControl
            // 
            this.Controls.Add(this.groupBoxRegexOptions);
            this.Name = "RegexOptionsControl";
            this.Size = new Size(576, 64);
            this.groupBoxRegexOptions.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        [Browsable(false)]
        public RegexOptionsHolder regexOptionsHolder {
            get { return _holder; }
        }

        private void refreshHolder() {
            if (cbCompiled.Checked)
                _holder.Value |= RegexOptions.Compiled;
            if (cbCultureInvariant.Checked)
                _holder.Value |= RegexOptions.CultureInvariant;
            if (cbExplicitCapture.Checked)
                _holder.Value |= RegexOptions.ExplicitCapture;
            if (cbECMAScript.Checked)
                _holder.Value |= RegexOptions.ECMAScript;
            if (cbIgnoreCase.Checked)
                _holder.Value |= RegexOptions.IgnoreCase;
            if (cbIgnorePatternWhitespace.Checked)
                _holder.Value |= RegexOptions.IgnorePatternWhitespace;
            if (cbMultiline.Checked)
                _holder.Value |= RegexOptions.Multiline;
            if (cbRightToLeft.Checked)
                _holder.Value |= RegexOptions.RightToLeft;
            if (cbSingleline.Checked)
                _holder.Value |= RegexOptions.Singleline;
        }

        private void checkECMAScript() {
            bool isAvailable = _multiline || _ignoreCase || _compiled;
            if (!isAvailable)
                cbECMAScript.Checked = false;
            cbECMAScript.Enabled = isAvailable;
        }

        private void cbMultiline_CheckedChanged(object sender, EventArgs e) {
            _multiline = ((CheckBox) sender).Checked;
            checkECMAScript();
            if (_multiline)
                cbSingleline.Checked = false;
            refreshHolder();
        }

        private void cbIgnoreCase_CheckedChanged(object sender, EventArgs e) {
            _ignoreCase = ((CheckBox) sender).Checked;
            checkECMAScript();
            refreshHolder();
        }

        private void cbCompiled_CheckedChanged(object sender, EventArgs e) {
            _compiled = ((CheckBox) sender).Checked;
            checkECMAScript();
            refreshHolder();
        }

        private void cbSingleline_CheckedChanged(object sender, EventArgs e) {
            _singleline = ((CheckBox) sender).Checked;
            if (_singleline)
                cbMultiline.Checked = false;
            refreshHolder();
        }

        private void groupBoxRegexOptions_Enter(object sender, EventArgs e) {
        }
    }
}