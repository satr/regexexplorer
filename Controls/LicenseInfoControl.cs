using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RegexExplorer.Controls {
    public class LicenseInfoControl : UserControl {
        private Label label1;
        private Container components = null;

        private string _orderUrl = "code.google.com/p/regexexplorer";
        private Label label2;
        private Label label3;
        private System.Windows.Forms.Panel Label5;
        private System.Windows.Forms.LinkLabel Label6;
        private System.Windows.Forms.LinkLabel Label7;
        private System.Windows.Forms.Panel Label8;
        private System.Windows.Forms.TextBox Label9;
        private string _langUrlParams = string.Empty;

        public event RegexExplorerEventHandler OnEnterKey;

        public LicenseInfoControl() {
            InitializeComponent();
        }

        public bool IsRegistered {
            set {
                Label5.Visible = value;
                Label8.Visible = !value;
            }
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
            this.Label5 = new System.Windows.Forms.Panel();
            this.Label9 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Panel();
            this.Label7 = new System.Windows.Forms.LinkLabel();
            this.Label6 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.Label5.SuspendLayout();
            this.Label8.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label5
            // 
            this.Label5.Controls.Add(this.Label9);
            this.Label5.Controls.Add(this.label3);
            this.Label5.Controls.Add(this.label2);
            this.Label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label5.Location = new System.Drawing.Point(0, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(328, 48);
            this.Label5.TabIndex = 0;
            // 
            // Label9
            // 
            this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label9.Location = new System.Drawing.Point(0, 32);
            this.Label9.Name = "Label9";
            this.Label9.ReadOnly = true;
            this.Label9.Size = new System.Drawing.Size(328, 13);
            this.Label9.TabIndex = 3;
            this.Label9.Text = "";
            this.Label9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(328, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "License code";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(328, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Registered version";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label8
            // 
            this.Label8.Controls.Add(this.Label7);
            this.Label8.Controls.Add(this.Label6);
            this.Label8.Controls.Add(this.label1);
            this.Label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label8.Location = new System.Drawing.Point(0, 48);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(328, 48);
            this.Label8.TabIndex = 1;
            // 
            // Label7
            // 
            this.Label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label7.Location = new System.Drawing.Point(0, 32);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(328, 16);
            this.Label7.TabIndex = 2;
            this.Label7.TabStop = true;
            this.Label7.Text = "Enter the key got earlier...";
            this.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label7.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEnterKey_LinkClicked);
            // 
            // Label6
            // 
            this.Label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label6.Location = new System.Drawing.Point(0, 16);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(328, 16);
            this.Label6.TabIndex = 1;
            this.Label6.TabStop = true;
            this.Label6.Text = "Order online now...";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label6.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOrderOnline_LinkClicked);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Unregistered version";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LicenseInfoControl
            // 
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label5);
            this.Name = "LicenseInfoControl";
            this.Size = new System.Drawing.Size(328, 96);
            this.Label5.ResumeLayout(false);
            this.Label8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void lnkOrderOnline_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string orderUrl = _orderUrl;
            if(_langUrlParams.Length > 0)
                orderUrl += _langUrlParams + "/";
            Process.Start(orderUrl);
        }

        private void lnkEnterKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (OnEnterKey != null)
                OnEnterKey();
        }

        public string OrderUrl {
            get { return _orderUrl; }
            set { _orderUrl = value; }
        }

        public string LangUrlParams {
            get { return _langUrlParams; }
            set { _langUrlParams = value; }
        }

        public string LicenseKey {
            set { Label9.Text = value; }
        }
    }
}