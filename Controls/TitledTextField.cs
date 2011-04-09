using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RegexExplorer {
    public class TitledTextField : UserControl, IEdit {
        public event CheckClearEventHandler OnCheck;
        new public event EditionEventHandler OnGotFocus;

        private GroupBox groupBox;
        private RichTextBox txtTextField;

        private Container components = null;

        public TitledTextField() {
            InitializeComponent();
            txtTextField.GotFocus += new EventHandler(TextField_GotFocus);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        [Browsable(true)]
        public string TitleText {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }

        [Browsable(true)]
        new public string Text {
            get { return txtTextField.Text; }
            set { txtTextField.Text = value; }
        }

        [Browsable(true)]
        public bool Multiline {
            get { return txtTextField.Multiline; }
            set { txtTextField.Multiline = value; }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox = new GroupBox();
            this.txtTextField = new RichTextBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.txtTextField);
            this.groupBox.Dock = DockStyle.Fill;
            this.groupBox.FlatStyle = FlatStyle.System;
            this.groupBox.Location = new Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new Size(384, 40);
            this.groupBox.TabIndex = 11;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Target text";
            // 
            // txtTextField
            // 
            this.txtTextField.Dock = DockStyle.Fill;
            this.txtTextField.Location = new Point(3, 16);
            this.txtTextField.Name = "txtTextField";
            this.txtTextField.Size = new Size(378, 21);
            this.txtTextField.TabIndex = 0;
            this.txtTextField.TabStop = false;
            this.txtTextField.Text = "";
            // 
            // TitledTextField
            // 
            this.Controls.Add(this.groupBox);
            this.Name = "TitledTextField";
            this.Size = new Size(384, 40);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void TextField_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char) 13)
                return;
            e.Handled = true;
            if (OnCheck != null)
                OnCheck();
        }

        new public void Focus() {
            txtTextField.Focus();
        }

        public int SelectionLength {
            get { return txtTextField.SelectionLength; }
        }

        public int SelectionStart {
            get { return txtTextField.SelectionStart; }
        }

        public void Copy() {
            txtTextField.Copy();
        }

        public void Cut() {
            txtTextField.Cut();
        }

        public void Paste() {
            txtTextField.Paste();
        }

        private void TextField_GotFocus(object sender, EventArgs e) {
            if (OnGotFocus != null)
                OnGotFocus();
        }

        public bool ReadOnly {
            get { return txtTextField.ReadOnly; }
            set { txtTextField.ReadOnly = value; }
        }
    }
}