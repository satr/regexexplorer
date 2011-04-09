using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RegexExplorer {
    public class CheckResultControl : UserControl {
        public event ShowMessageEventHandler onShowMessage;

        private Panel panel1;
        private GroupBox groupBoxResult;
        private Label lblIsMatchResult;

        private Container components = null;

        public CheckResultControl() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.panel1 = new Panel();
            this.groupBoxResult = new GroupBox();
            this.lblIsMatchResult = new Label();
            this.panel1.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBoxResult);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(248, 32);
            this.panel1.TabIndex = 0;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.lblIsMatchResult);
            this.groupBoxResult.Dock = DockStyle.Fill;
            this.groupBoxResult.FlatStyle = FlatStyle.System;
            this.groupBoxResult.Location = new Point(0, 0);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new Size(248, 32);
            this.groupBoxResult.TabIndex = 15;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // lblIsMatchResult
            // 
            this.lblIsMatchResult.Dock = DockStyle.Fill;
            this.lblIsMatchResult.Font =
                new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((Byte) (204)));
            this.lblIsMatchResult.Location = new Point(3, 16);
            this.lblIsMatchResult.Name = "lblIsMatchResult";
            this.lblIsMatchResult.Size = new Size(242, 13);
            this.lblIsMatchResult.TabIndex = 14;
            this.lblIsMatchResult.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // CheckResultControl
            // 
            this.Controls.Add(this.panel1);
            this.Name = "CheckResultControl";
            this.Size = new Size(248, 32);
            this.panel1.ResumeLayout(false);
            this.groupBoxResult.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        [Browsable(true)]
        public string ResultTitle {
            get { return groupBoxResult.Text; }
            set { groupBoxResult.Text = value; }
        }

        [Browsable(true)]
        public string ResultText {
            get { return lblIsMatchResult.Text; }
            set { lblIsMatchResult.Text = value; }
        }

        [Browsable(true)]
        new public Color BackColor {
            get { return lblIsMatchResult.BackColor; }
            set { lblIsMatchResult.BackColor = value; }
        }

        [Browsable(true)]
        new public Color ForeColor {
            get { return lblIsMatchResult.ForeColor; }
            set { lblIsMatchResult.ForeColor = value; }
        }

        public void showComment(string text) {
            if (onShowMessage != null)
                onShowMessage(text);
        }
    }
}