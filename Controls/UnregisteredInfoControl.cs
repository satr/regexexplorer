using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RegexExplorer {
    public class UnregisteredInfoControl : UserControl {
        #region Controls

        private Label label1;
        private Panel panel1;
        private LinkLabel linkLabel1;
        private Label lblComment;
        private Label label2;
        private Container components = null;

        #endregion

        public event RegexExplorerEventHandler OnRegister;

        public UnregisteredInfoControl() {
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
            this.label1 = new Label();
            this.panel1 = new Panel();
            this.label2 = new Label();
            this.linkLabel1 = new LinkLabel();
            this.lblComment = new Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = Color.Yellow;
            this.label1.Dock = DockStyle.Top;
            this.label1.Font =
                new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((Byte) (204)));
            this.label1.ForeColor = Color.Red;
            this.label1.Location = new Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(280, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unregistered...";
            // 
            // panel1
            // 
            this.panel1.BackColor = Color.Yellow;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(0, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(280, 32);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = Color.Yellow;
            this.label2.Dock = DockStyle.Top;
            this.label2.FlatStyle = FlatStyle.System;
            this.label2.Font =
                new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((Byte) (204)));
            this.label2.ForeColor = Color.Blue;
            this.label2.Location = new Point(55, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(225, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "to know how to register this copy.";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = Color.Yellow;
            this.linkLabel1.Dock = DockStyle.Left;
            this.linkLabel1.Location = new Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new Size(55, 16);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here";
            this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lblComment
            // 
            this.lblComment.BackColor = Color.Yellow;
            this.lblComment.Dock = DockStyle.Fill;
            this.lblComment.Font =
                new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((Byte) (204)));
            this.lblComment.ForeColor = SystemColors.ControlText;
            this.lblComment.Location = new Point(0, 48);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new Size(280, 32);
            this.lblComment.TabIndex = 4;
            this.lblComment.Text = "Unregistered copy comment";
            // 
            // UnregisteredInfoControl
            // 
            this.BackColor = Color.Yellow;
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "UnregisteredInfoControl";
            this.Size = new Size(280, 80);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (OnRegister != null)
                OnRegister();
        }

        public string Comment {
            get { return lblComment.Text; }
            set { lblComment.Text = value; }
        }

        public void HideIn(Form parentForm) {
            parentForm.Height -= this.Height;
            this.Visible = false;
        }

    }
}