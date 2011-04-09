using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using KeyProvider;
using RegexExplorer;
using RegexExplorer;

namespace LicenseHelper {
    public class LicenseHelperForm : Form {
        private static string _orderURL = string.Empty;
        public static string OrderURL {
            set { _orderURL = value; }
        }
        private IContainer components;

        #region Controls


        #endregion

        public enum LicenseKeySources {
            AsText,
            AsFile,
        }

        private ToolTip toolTip;
        private Label label2;
        private Panel panel1;
        private System.Windows.Forms.Panel Label18;
        private System.Windows.Forms.GroupBox gbGroup2;
        private System.Windows.Forms.Button Label11;
        private System.Windows.Forms.ImageList Label5;
        private System.Windows.Forms.Button Label10;
        private System.Windows.Forms.TextBox Label12;
        private System.Windows.Forms.RadioButton Label14;
        private System.Windows.Forms.RadioButton Label15;
        private System.Windows.Forms.TextBox Label9;
        private System.Windows.Forms.Label Label16;
        private System.Windows.Forms.GroupBox bgGroup;
        private System.Windows.Forms.LinkLabel Label17;
        private System.Windows.Forms.Label Label4;
        private System.Windows.Forms.Panel Label8;
        private System.Windows.Forms.Button Label7;
        private System.Windows.Forms.Button Label6;
        private System.Windows.Forms.Panel Label20;
        private System.Windows.Forms.OpenFileDialog Label19;
        private System.Windows.Forms.Panel Label23;
        private bool _useInnerKeyFileChecker = false;

        public event OpenLicenseKeyFileHandle SelectFile;

        public LicenseHelperForm(bool useInnerKeyFileChecker) : this() {
            _useInnerKeyFileChecker = useInnerKeyFileChecker;
        }

        public LicenseHelperForm() {
            InitializeComponent();
            Label11.Click += new EventHandler(Label11_Click);
            Label10.Click += new EventHandler(Label10_Click);
            Label14.CheckedChanged += new EventHandler(CheckedChanged);
            Label15.CheckedChanged += new EventHandler(CheckedChanged);
            GuiObjectsCollection.ApplyActualLanguageFor(this, toolTip);
            this.AcceptButton = Label7;
            this.CancelButton = Label6;
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(LicenseHelperForm));
            this.Label18 = new System.Windows.Forms.Panel();
            this.gbGroup2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label11 = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.ImageList(this.components);
            this.Label10 = new System.Windows.Forms.Button();
            this.Label12 = new System.Windows.Forms.TextBox();
            this.Label14 = new System.Windows.Forms.RadioButton();
            this.Label15 = new System.Windows.Forms.RadioButton();
            this.Label9 = new System.Windows.Forms.TextBox();
            this.Label16 = new System.Windows.Forms.Label();
            this.Label23 = new System.Windows.Forms.Panel();
            this.bgGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.LinkLabel();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Panel();
            this.Label7 = new System.Windows.Forms.Button();
            this.Label6 = new System.Windows.Forms.Button();
            this.Label20 = new System.Windows.Forms.Panel();
            this.Label19 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.Label18.SuspendLayout();
            this.gbGroup2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.bgGroup.SuspendLayout();
            this.Label8.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label18
            // 
            this.Label18.Controls.Add(this.gbGroup2);
            this.Label18.Controls.Add(this.Label23);
            this.Label18.Controls.Add(this.bgGroup);
            this.Label18.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label18.Location = new System.Drawing.Point(0, 0);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(376, 296);
            this.Label18.TabIndex = 0;
            // 
            // gbGroup2
            // 
            this.gbGroup2.Controls.Add(this.panel1);
            this.gbGroup2.Controls.Add(this.Label16);
            this.gbGroup2.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbGroup2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbGroup2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.gbGroup2.Location = new System.Drawing.Point(0, 120);
            this.gbGroup2.Name = "gbGroup2";
            this.gbGroup2.Size = new System.Drawing.Size(376, 168);
            this.gbGroup2.TabIndex = 8;
            this.gbGroup2.TabStop = false;
            this.gbGroup2.Text = "Step 2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Label11);
            this.panel1.Controls.Add(this.Label10);
            this.panel1.Controls.Add(this.Label12);
            this.panel1.Controls.Add(this.Label14);
            this.panel1.Controls.Add(this.Label15);
            this.panel1.Controls.Add(this.Label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 109);
            this.panel1.TabIndex = 12;
            // 
            // Label11
            // 
            this.Label11.ImageIndex = 0;
            this.Label11.ImageList = this.Label5;
            this.Label11.Location = new System.Drawing.Point(296, 24);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(24, 23);
            this.Label11.TabIndex = 8;
            this.toolTip.SetToolTip(this.Label11, "Paste license key");
            // 
            // Label5
            // 
            this.Label5.ImageSize = new System.Drawing.Size(19, 18);
            this.Label5.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Label5.ImageStream")));
            this.Label5.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Label10
            // 
            this.Label10.ImageIndex = 1;
            this.Label10.ImageList = this.Label5;
            this.Label10.Location = new System.Drawing.Point(296, 80);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(24, 23);
            this.Label10.TabIndex = 11;
            this.toolTip.SetToolTip(this.Label10, "Browse license key file");
            // 
            // Label12
            // 
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.Label12.Location = new System.Drawing.Point(64, 24);
            this.Label12.MaxLength = 40;
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(224, 20);
            this.Label12.TabIndex = 7;
            this.Label12.Text = "";
            // 
            // Label14
            // 
            this.Label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.Label14.Location = new System.Drawing.Point(48, 56);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(272, 24);
            this.Label14.TabIndex = 9;
            this.Label14.TabStop = true;
            this.Label14.Text = "Choose a license key file";
            // 
            // Label15
            // 
            this.Label15.Checked = true;
            this.Label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.Label15.Location = new System.Drawing.Point(48, 0);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(272, 24);
            this.Label15.TabIndex = 6;
            this.Label15.TabStop = true;
            this.Label15.Text = "Enter a license key as a text";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.Label9.Location = new System.Drawing.Point(64, 80);
            this.Label9.MaxLength = 39;
            this.Label9.Name = "Label9";
            this.Label9.ReadOnly = true;
            this.Label9.Size = new System.Drawing.Size(224, 20);
            this.Label9.TabIndex = 10;
            this.Label9.Text = "";
            // 
            // Label16
            // 
            this.Label16.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.Label16.Location = new System.Drawing.Point(3, 16);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(370, 40);
            this.Label16.TabIndex = 0;
            this.Label16.Text = "Please enter or paste a license key into field above or choose a file with a lice" +
                "nse key";
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label23
            // 
            this.Label23.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label23.Location = new System.Drawing.Point(0, 104);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(376, 16);
            this.Label23.TabIndex = 7;
            // 
            // bgGroup
            // 
            this.bgGroup.Controls.Add(this.label2);
            this.bgGroup.Controls.Add(this.Label17);
            this.bgGroup.Controls.Add(this.Label4);
            this.bgGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.bgGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.bgGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.bgGroup.Location = new System.Drawing.Point(0, 0);
            this.bgGroup.Name = "bgGroup";
            this.bgGroup.Size = new System.Drawing.Size(376, 104);
            this.bgGroup.TabIndex = 6;
            this.bgGroup.TabStop = false;
            this.bgGroup.Text = "Step 1";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(370, 40);
            this.label2.TabIndex = 9;
            this.label2.Text = "You ought to have an available Internet connection. By the links above you well b" +
                "e provided of the order form.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label17
            // 
            this.Label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.Label17.Location = new System.Drawing.Point(3, 48);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(370, 16);
            this.Label17.TabIndex = 3;
            this.Label17.TabStop = true;
            this.Label17.Text = "ORDER ONLINE NOW...";
            this.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Label17.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOrderOnline_LinkClicked);
            // 
            // Label4
            // 
            this.Label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.Label4.Location = new System.Drawing.Point(3, 16);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(370, 32);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "To register this copy of the product you can follow the link below (just click on" +
                " the link):";
            this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label8
            // 
            this.Label8.Controls.Add(this.Label7);
            this.Label8.Controls.Add(this.Label6);
            this.Label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label8.Location = new System.Drawing.Point(0, 296);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(376, 40);
            this.Label8.TabIndex = 1;
            // 
            // Label7
            // 
            this.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label7.Location = new System.Drawing.Point(120, 8);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(64, 23);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Accept";
            this.Label7.Click += new System.EventHandler(this.Label7_Click);
            // 
            // Label6
            // 
            this.Label6.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Location = new System.Drawing.Point(192, 8);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(64, 23);
            this.Label6.TabIndex = 1;
            this.Label6.Text = "Cancel";
            this.Label6.Click += new System.EventHandler(this.Label6_Click);
            // 
            // Label20
            // 
            this.Label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label20.Location = new System.Drawing.Point(0, 336);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(376, 0);
            this.Label20.TabIndex = 3;
            // 
            // Label19
            // 
            this.Label19.RestoreDirectory = true;
            // 
            // LicenseHelperForm
            // 
            this.AcceptButton = this.Label7;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.Label6;
            this.ClientSize = new System.Drawing.Size(376, 334);
            this.Controls.Add(this.Label20);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label18);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LicenseHelperForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register of the product copy";
            this.Label18.ResumeLayout(false);
            this.gbGroup2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.bgGroup.ResumeLayout(false);
            this.Label8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void Label10_Click(object sender, EventArgs e) {
            Label14.Checked = true;
            if (Label19.ShowDialog() != DialogResult.OK)
                return;
            LicenseKeyFileEventArgs args = new LicenseKeyFileEventArgs();
            args.AcceptFile = true;
            string fileName = Label19.FileName;
            if (SelectFile != null)
                SelectFile(fileName, args);
            else
                InnerSelectFile(fileName, args);
            if (!args.AcceptFile) {
                Messenger.ShowError("{0}:\r\n{1}", Msgs.Res.A_key_file_error, args.Comment);
                return;
            }
            Label9.Text = fileName;
            KeyFromFile keyFromFile = new KeyFromFile(fileName);
            if (keyFromFile.KeyHashPairAreMatch)
                Label12.Text = keyFromFile.Key;
        }

        private void CheckedChanged(object sender, EventArgs e) {
            Label12.ReadOnly = Label14.Checked;
        }

        public LicenseKeySources LicenseKeySource {
            get { return Label15.Checked ? LicenseKeySources.AsText : LicenseKeySources.AsFile; }
            set {
                Label15.Checked = (value == LicenseKeySources.AsText);
                Label14.Checked = (value == LicenseKeySources.AsFile);
            }
        }

        public string Value {
            get {
                string value = (LicenseKeySource == LicenseKeySources.AsFile)
                                   ? Label9.Text : Label12.Text;
                return value.Trim();
            }
        }

        public string Key {
            get { return Label12.Text; }
            set { Label12.Text = value; }
        }

        public string LicenseKeyFileName {
            get { return Label9.Text; }
            set { Label9.Text = value; }
        }

        public bool UseInnerKeyFileChecker {
            get { return _useInnerKeyFileChecker; }
            set { _useInnerKeyFileChecker = value; }
        }

        private void InnerSelectFile(string fileName, LicenseKeyFileEventArgs args) {
            if (!UseInnerKeyFileChecker)
                return;

            if (!new FileInfo(fileName).Exists) {
                args.RefuseAcceptance(Msgs.Res.File_N_is_not_exist, fileName);
                return;
            }

            KeyFromFile keyFromFile = new KeyFromFile(fileName);
            if (!keyFromFile.KeyHashPairAreValid) {
                args.RefuseAcceptance(Msgs.Res.Invalid_file_format_Its_expected_two_lines_a_key_and_his_hash);
                return;
            }

            if (!keyFromFile.KeyHashPairAreMatch) {
                args.RefuseAcceptance(Msgs.Res.File_is_invalid);
                return;
            }
            args.AcceptFile = true;
        }

        private void Label7_Click(object sender, EventArgs e) {
            if (Value.Length == 0 || Key.Length == 0)
                return;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Label6_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private class KeyFromFile {
            private string _key, _hash;

            public KeyFromFile(string fileName) {
                try {
                    using (StreamReader reader = new StreamReader(fileName)) {
                        if (((_key = reader.ReadLine()) != null))
                            _hash = reader.ReadLine();
                    }
                }
                catch (Exception ex) {
                    Messenger.LogError(Msgs.Res.Error_reading_license_key_file, ex);
                }
            }

            public string Key {
                get { return _key; }
            }

            public bool KeyHashPairAreValid {
                get { return !((_key == null) || (_hash == null) || (_key.Length != 32) || (_hash.Length != 32)); }
            }

            public bool KeyHashPairAreMatch {
                get { return KeyHashPairAreValid && (new KeyPair(_key).IsValidFor(_hash)); }
            }
        }

        public bool AcceptKey() {
            return (ShowDialog() == DialogResult.OK);
        }

        private void Label11_Click(object sender, EventArgs e) {
            Label15.Checked = true;
            string paste = EditionHelper.paste();
            if (KeyPair.IsValidKey(paste))
                Label12.Text = paste;
            else
                Messenger.ShowWarning(Msgs.Res.Clipboard_not_contains_a_valid_key);
        }

        private void lnkOrderOnline_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (null != _orderURL && _orderURL.StartsWith("www"))
                Process.Start(_orderURL);
        }
    }
}