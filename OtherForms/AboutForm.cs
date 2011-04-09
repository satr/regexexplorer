using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LicenseHelper;
using RegexExplorer.Controls;
using RegexExplorer;

namespace RegexExplorer {
    public class AboutForm : Form {
        private static string _wwwURL = string.Empty;
        private static string _orderURL = string.Empty;
        public static string OrderURL {
            set { _orderURL = value; }
        }
        public static string wwwURL {
            set { _wwwURL = value; }
        }
        private readonly MainController _mainController;

        #region Controls

        private Panel panel1;
        private Label label1;
        private Label label2;

        #endregion
        private RegexExplorer.Controls.LicenseInfoControl Label4;
        private System.Windows.Forms.PictureBox Label7;
        private System.Windows.Forms.Panel Label8;
        private System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Button Label11;
        private System.Windows.Forms.LinkLabel Label12;
        private System.Windows.Forms.Panel Label14;

        private Container components = null;

        public AboutForm(MainController mainController) {
            _mainController = mainController;
            InitializeComponent();
            Label10.Text = "Copyright \u00A9 2005-2011, http://code.google.com/p/regexexplorer";
            Label9.Text = string.Format(Label9.Text, GetProductVersion());
            Label12.Links[0].LinkData = "code.google.com/p/regexexplorer";
            SetOrderLanguageUrlParams();
            Label4.IsRegistered = /*<KeyKeyGeneratorCheck1>*/ LicenseController.IsRegistered
                /*</KeyKeyGeneratorCheck1>*/;
            Label4.LicenseKey = Preferences.Res.LicenseKey;
            Label4.OnEnterKey += new RegexExplorerEventHandler(Label4_OnEnterKey);
            GuiObjectsCollection.ApplyActualLanguageFor(this);
            this.AcceptButton = Label11;
            this.CancelButton = Label11;
        }

        private static string GetProductVersion() {
            return Regex.Matches(Application.ProductVersion, @"[\d+]{1,}\.[\d+]{1,}\.[\d+]{1,}")[0].ToString();
        }

        private void SetOrderLanguageUrlParams() {
            Label4.OrderUrl = _orderURL;
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
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(AboutForm));
            this.Label8 = new System.Windows.Forms.Panel();
            this.Label7 = new System.Windows.Forms.PictureBox();
            this.Label14 = new System.Windows.Forms.Panel();
            this.Label4 = new RegexExplorer.Controls.LicenseInfoControl();
            this.Label11 = new System.Windows.Forms.Button();
            this.Label12 = new System.Windows.Forms.LinkLabel();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Label8.SuspendLayout();
            this.Label14.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label8
            // 
            this.Label8.Controls.Add(this.Label7);
            this.Label8.Dock = System.Windows.Forms.DockStyle.Left;
            this.Label8.Location = new System.Drawing.Point(0, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(88, 214);
            this.Label8.TabIndex = 1;
            // 
            // Label7
            // 
            this.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label7.Image = ((System.Drawing.Image)(resources.GetObject("Label7.Image")));
            this.Label7.Location = new System.Drawing.Point(7, 5);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(72, 72);
            this.Label7.TabIndex = 1;
            this.Label7.TabStop = false;
            // 
            // Label14
            // 
            this.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label14.Controls.Add(this.Label4);
            this.Label14.Controls.Add(this.Label11);
            this.Label14.Controls.Add(this.Label12);
            this.Label14.Controls.Add(this.Label10);
            this.Label14.Controls.Add(this.Label9);
            this.Label14.Controls.Add(this.panel1);
            this.Label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label14.Location = new System.Drawing.Point(88, 0);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(328, 214);
            this.Label14.TabIndex = 2;
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label4.LangUrlParams = "";
            this.Label4.Location = new System.Drawing.Point(0, 128);
            this.Label4.Name = "Label4";
            this.Label4.OrderUrl = "code.google.com/p/regexexplorer";
            this.Label4.Size = new System.Drawing.Size(324, 48);
            this.Label4.TabIndex = 6;
            this.Label4.TabStop = false;
            // 
            // Label11
            // 
            this.Label11.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label11.Location = new System.Drawing.Point(128, 184);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(64, 24);
            this.Label11.TabIndex = 5;
            this.Label11.Text = "Ok";
            // 
            // Label12
            // 
            this.Label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label12.Location = new System.Drawing.Point(0, 104);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(324, 24);
            this.Label12.TabIndex = 3;
            this.Label12.TabStop = true;
            this.Label12.Text = "code.google.com/p/regexexplorer/";
            this.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label12.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel1_LinkClicked);
            // 
            // Label10
            // 
            this.Label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label10.Location = new System.Drawing.Point(0, 80);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(324, 24);
            this.Label10.TabIndex = 2;
            this.Label10.Text = "Copyright 2005-2006, RegexExplorer.com";
            this.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label9
            // 
            this.Label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label9.Location = new System.Drawing.Point(0, 56);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(324, 24);
            this.Label9.TabIndex = 1;
            this.Label9.Text = "Version {0}";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 56);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(152, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 40);
            this.label2.TabIndex = 2;
            this.label2.Text = "Explorer";
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(32, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "Regex";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AboutForm
            // 
            this.AcceptButton = this.Label11;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.Label11;
            this.ClientSize = new System.Drawing.Size(416, 214);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Label8.ResumeLayout(false);
            this.Label14.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (null != _wwwURL && _orderURL.StartsWith("code"))
                Process.Start(string.Format("http://{0}",_wwwURL));
        }

        private void Label4_OnEnterKey() {
            _mainController.Register(this);
        }
    }
}