using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using RegexExplorer.ToolBarControls;
using RegexExplorer;

namespace RegexExplorer.OtherForms {
    public class TextFieldForm : Form {
        private Panel pnlToolBars;
        private Panel pnlButtons;
        private RichTextBox txtField;
        private Button btnClose;
        private EditToolBarControl editToolBarControl;

        private Container components = null;

        public TextFieldForm(string text) : this() {
            txtField.Text = text;
        }

        public TextFieldForm(StringBuilder stringBuilder) : this() {
            txtField.Text = stringBuilder.ToString();
        }

        public TextFieldForm() {
            InitializeComponent();
            editToolBarControl.onCopy += new EditionEventHandler(txtField.Copy);
            editToolBarControl.onCut += new EditionEventHandler(txtField.Cut);
            editToolBarControl.onPaste += new EditionEventHandler(txtField.Paste);
            GuiObjectsCollection.ApplyActualLanguageFor(this);
            this.AcceptButton = btnClose;
            this.CancelButton = btnClose;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            ResourceManager resources = new ResourceManager(typeof (TextFieldForm));
            this.pnlToolBars = new Panel();
            this.editToolBarControl = new EditToolBarControl();
            this.pnlButtons = new Panel();
            this.btnClose = new Button();
            this.txtField = new RichTextBox();
            this.pnlToolBars.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlToolBars
            // 
            this.pnlToolBars.Controls.Add(this.editToolBarControl);
            this.pnlToolBars.Dock = DockStyle.Top;
            this.pnlToolBars.Location = new Point(0, 0);
            this.pnlToolBars.Name = "pnlToolBars";
            this.pnlToolBars.Size = new Size(608, 32);
            this.pnlToolBars.TabIndex = 0;
            // 
            // editToolBarControl
            // 
            this.editToolBarControl.Dock = DockStyle.Left;
            this.editToolBarControl.Location = new Point(0, 0);
            this.editToolBarControl.Name = "editToolBarControl";
            this.editToolBarControl.pasteSpecialVisible = false;
            this.editToolBarControl.Size = new Size(88, 32);
            this.editToolBarControl.TabIndex = 3;
            this.editToolBarControl.TabStop = false;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnClose);
            this.pnlButtons.Dock = DockStyle.Bottom;
            this.pnlButtons.Location = new Point(0, 302);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new Size(608, 40);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = DialogResult.Cancel;
            this.btnClose.FlatStyle = FlatStyle.System;
            this.btnClose.Location = new Point(8, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(64, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            // 
            // txtField
            // 
            this.txtField.DetectUrls = false;
            this.txtField.Dock = DockStyle.Fill;
            this.txtField.Location = new Point(0, 32);
            this.txtField.Name = "txtField";
            this.txtField.Size = new Size(608, 270);
            this.txtField.TabIndex = 2;
            this.txtField.TabStop = false;
            this.txtField.Text = "";
            this.txtField.WordWrap = false;
            // 
            // TextFieldForm
            // 
            this.AutoScaleBaseSize = new Size(5, 13);
            this.CancelButton = this.btnClose;
            this.ClientSize = new Size(608, 342);
            this.Controls.Add(this.txtField);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlToolBars);
            this.Icon = ((Icon) (resources.GetObject("$this.Icon")));
            this.Name = "TextFieldForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Text";
            this.pnlToolBars.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}