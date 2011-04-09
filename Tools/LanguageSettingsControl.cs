using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RegexExplorer {
    public class LanguageSettingsControl : UserControl {
        private GroupBox gbAddContent;
        private CheckBox cbListView;
        private CheckBox cbStatusBar;
        private CheckBox cbListControl;
        private CheckBox cbDomainUpDown;
        private CheckBox cbTextBox;
        private CheckBox cbAddNewCaptionsToResources;
        private Container components = null;

        public LanguageSettingsControl() {
            InitializeComponent();
            GetLang();
            InitAddLanguageContentControls();
            cbAddNewCaptionsToResources.CheckedChanged += new EventHandler(cbAddNewCaptionsToResources_CheckedChanged);
        }

        [Browsable(false)]
        public bool AddNewCaptionsToResources {
            set { cbAddNewCaptionsToResources.Checked = value; }
            get { return cbAddNewCaptionsToResources.Checked; }
        }

        private void cbAddNewCaptionsToResources_CheckedChanged(object sender, EventArgs e) {
            if (cbAddNewCaptionsToResources.Checked)
                LangBase.Res.Save();
            InitAddLanguageContentControls();
        }

        private void InitAddLanguageContentControls() {
            cbTextBox.Enabled =
                cbListControl.Enabled =
                cbListView.Enabled = cbStatusBar.Enabled = cbDomainUpDown.Enabled = cbAddNewCaptionsToResources.Checked;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void SetLang() {
            LangBase.AddNewCaptionsToResource = cbAddNewCaptionsToResources.Checked;
            LangBase.AddTextBoxContent = cbTextBox.Checked;
            LangBase.AddListControlContent = cbListControl.Checked;
            LangBase.AddListViewContent = cbListView.Checked;
            LangBase.AddStatusBarContent = cbStatusBar.Checked;
            LangBase.AddDomainUpDownContent = cbDomainUpDown.Checked;
        }

        public void GetLang() {
            cbAddNewCaptionsToResources.Checked = LangBase.AddNewCaptionsToResource;
            cbTextBox.Checked = LangBase.AddTextBoxContent;
            cbListControl.Checked = LangBase.AddListControlContent;
            cbListView.Checked = LangBase.AddListViewContent;
            cbStatusBar.Checked = LangBase.AddStatusBarContent;
            cbDomainUpDown.Checked = LangBase.AddDomainUpDownContent;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gbAddContent = new GroupBox();
            this.cbListView = new CheckBox();
            this.cbStatusBar = new CheckBox();
            this.cbListControl = new CheckBox();
            this.cbDomainUpDown = new CheckBox();
            this.cbTextBox = new CheckBox();
            this.cbAddNewCaptionsToResources = new CheckBox();
            this.gbAddContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbAddContent
            // 
            this.gbAddContent.Controls.Add(this.cbListView);
            this.gbAddContent.Controls.Add(this.cbStatusBar);
            this.gbAddContent.Controls.Add(this.cbListControl);
            this.gbAddContent.Controls.Add(this.cbDomainUpDown);
            this.gbAddContent.Controls.Add(this.cbTextBox);
            this.gbAddContent.FlatStyle = FlatStyle.System;
            this.gbAddContent.Location = new Point(0, 40);
            this.gbAddContent.Name = "gbAddContent";
            this.gbAddContent.Size = new Size(248, 144);
            this.gbAddContent.TabIndex = 7;
            this.gbAddContent.TabStop = false;
            this.gbAddContent.Text = "Add content from controls";
            // 
            // cbListView
            // 
            this.cbListView.FlatStyle = FlatStyle.System;
            this.cbListView.Location = new Point(8, 64);
            this.cbListView.Name = "cbListView";
            this.cbListView.Size = new Size(232, 24);
            this.cbListView.TabIndex = 1;
            this.cbListView.Text = "ListView";
            // 
            // cbStatusBar
            // 
            this.cbStatusBar.FlatStyle = FlatStyle.System;
            this.cbStatusBar.Location = new Point(8, 88);
            this.cbStatusBar.Name = "cbStatusBar";
            this.cbStatusBar.Size = new Size(232, 24);
            this.cbStatusBar.TabIndex = 2;
            this.cbStatusBar.Text = "StatusBar";
            // 
            // cbListControl
            // 
            this.cbListControl.FlatStyle = FlatStyle.System;
            this.cbListControl.Location = new Point(8, 40);
            this.cbListControl.Name = "cbListControl";
            this.cbListControl.Size = new Size(232, 24);
            this.cbListControl.TabIndex = 0;
            this.cbListControl.Text = "ListControl (ListBox, ComboBox, etc.)";
            // 
            // cbDomainUpDown
            // 
            this.cbDomainUpDown.FlatStyle = FlatStyle.System;
            this.cbDomainUpDown.Location = new Point(8, 112);
            this.cbDomainUpDown.Name = "cbDomainUpDown";
            this.cbDomainUpDown.Size = new Size(232, 24);
            this.cbDomainUpDown.TabIndex = 2;
            this.cbDomainUpDown.Text = "DomainUpDown";
            // 
            // cbTextBox
            // 
            this.cbTextBox.FlatStyle = FlatStyle.System;
            this.cbTextBox.Location = new Point(8, 16);
            this.cbTextBox.Name = "cbTextBox";
            this.cbTextBox.Size = new Size(232, 24);
            this.cbTextBox.TabIndex = 0;
            this.cbTextBox.Text = "TextBox";
            // 
            // cbAddNewCaptionsToResources
            // 
            this.cbAddNewCaptionsToResources.CheckAlign = ContentAlignment.TopLeft;
            this.cbAddNewCaptionsToResources.FlatStyle = FlatStyle.System;
            this.cbAddNewCaptionsToResources.Location = new Point(8, 0);
            this.cbAddNewCaptionsToResources.Name = "cbAddNewCaptionsToResources";
            this.cbAddNewCaptionsToResources.Size = new Size(232, 32);
            this.cbAddNewCaptionsToResources.TabIndex = 6;
            this.cbAddNewCaptionsToResources.Text = "Add new GUI captions to the language resources";
            this.cbAddNewCaptionsToResources.TextAlign = ContentAlignment.TopLeft;
            // 
            // LanguageSettingsControl
            // 
            this.Controls.Add(this.gbAddContent);
            this.Controls.Add(this.cbAddNewCaptionsToResources);
            this.Name = "LanguageSettingsControl";
            this.Size = new Size(248, 184);
            this.gbAddContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}