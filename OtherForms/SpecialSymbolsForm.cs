using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using LicenseHelper;
using RegexExplorer.Controls;
using RegexExplorer;

namespace RegexExplorer {
    public class SpecialSymbolsForm : Form {
        private readonly MainController _mainController;

        #region Components

        private Container components = null;
        private GroupBox groupBox1;
        private Label label14;
        private Label label1;
        private Button button2;
        private Button button1;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button8;
        private Button button9;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnCancel;
        private GroupBox gbCustom;
        private Label label9;
        private TextBox txtCustomExpression;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Button btnEnter;
        private Panel pnlSpecialSymbols;
        private Panel pnlCustomExpressions;
        private Panel pnlCommand;

        #endregion
        private RegexExplorer.UnregisteredInfoControl Label35;

        private string _specialSymbol = "";

        public SpecialSymbolsForm(MainController mainController) {
            _mainController = mainController;
            InitializeComponent();
            GuiObjectsCollection.ApplyActualLanguageFor(this);
            InitControls();
            Bind();
            DisplayLicState();
        }

        private void InitControls() {
            this.AcceptButton = btnEnter;
            this.CancelButton = btnCancel;
        }

        private void DisplayLicState() {
            bool isReg = /*<KeyKeyGeneratorCheck3>*/ LicenseController.IsRegistered /*</KeyKeyGeneratorCheck3>*/;
            txtCustomExpression.Enabled = btnEnter.Enabled = isReg;
            if (isReg)
                Label35.HideIn(this);
        }

        private void Bind() {
            this.btnEnter.Click += new EventHandler(btnEnter_Click);
            this.txtCustomExpression.KeyPress += new KeyPressEventHandler(this.txtCustomExpression_KeyPress);
            this.button1.Click += new EventHandler(this.pasteSymbol);
            this.button2.Click += new EventHandler(this.pasteSymbol);
            this.button3.Click += new EventHandler(this.pasteSymbol);
            this.button4.Click += new EventHandler(this.pasteSymbol);
            this.button5.Click += new EventHandler(this.pasteSymbol);
            this.button6.Click += new EventHandler(this.pasteSymbol);
            this.button8.Click += new EventHandler(this.pasteSymbol);
            this.button9.Click += new EventHandler(this.pasteSymbol);
            Label35.OnRegister += new RegexExplorerEventHandler(Label35_OnRegister);
        }

        public string specialSymbol {
            get { return _specialSymbol; }
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

        private void InitializeComponent() {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(SpecialSymbolsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbCustom = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCustomExpression = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.Label35 = new RegexExplorer.UnregisteredInfoControl();
            this.pnlSpecialSymbols = new System.Windows.Forms.Panel();
            this.pnlCustomExpressions = new System.Windows.Forms.Panel();
            this.pnlCommand = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.gbCustom.SuspendLayout();
            this.pnlSpecialSymbols.SuspendLayout();
            this.pnlCustomExpressions.SuspendLayout();
            this.pnlCommand.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(528, 176);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Special symbols";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(496, 56);
            this.label14.TabIndex = 2;
            this.label14.Text = @"Note :  The escaped character \b is a special case. In a regular expression, \b denotes a word boundary (between \w and \W characters) except within a [] character class, where \b refers to the backspace character. In a replacement pattern, \b always denotes a backspace.";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(40, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Matches a bell (alarm) \\u0007";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.button2.Location = new System.Drawing.Point(8, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 24);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Text = "\\b ";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.button1.Location = new System.Drawing.Point(8, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(24, 24);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Text = "\\a ";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.button3.Location = new System.Drawing.Point(8, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(24, 24);
            this.button3.TabIndex = 0;
            this.button3.TabStop = false;
            this.button3.Text = "\\t ";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.button4.Location = new System.Drawing.Point(8, 88);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(24, 24);
            this.button4.TabIndex = 0;
            this.button4.TabStop = false;
            this.button4.Text = "\\n ";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.button5.Location = new System.Drawing.Point(256, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(24, 24);
            this.button5.TabIndex = 0;
            this.button5.TabStop = false;
            this.button5.Text = "\\r ";
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.button6.Location = new System.Drawing.Point(256, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(24, 24);
            this.button6.TabIndex = 0;
            this.button6.TabStop = false;
            this.button6.Text = "\\v ";
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.button8.Location = new System.Drawing.Point(256, 64);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(24, 24);
            this.button8.TabIndex = 0;
            this.button8.TabStop = false;
            this.button8.Text = "\\f ";
            // 
            // button9
            // 
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.button9.Location = new System.Drawing.Point(256, 88);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(24, 24);
            this.button9.TabIndex = 0;
            this.button9.TabStop = false;
            this.button9.Text = "\\e ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Matches a backspace \\u0008";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Matches a tab \\u0009";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Matches a new line \\u000A";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(288, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(216, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Matches a carriage return \\u000D";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(288, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(216, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Matches a form feed \\u000C";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(288, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(216, 24);
            this.label7.TabIndex = 1;
            this.label7.Text = "Matches a vertical tab \\u000B";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(288, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(216, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "Matches an escape \\u001B";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(24, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 24);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.TabStop = false;
            this.btnCancel.Text = "Cancel";
            // 
            // gbCustom
            // 
            this.gbCustom.Controls.Add(this.label9);
            this.gbCustom.Controls.Add(this.txtCustomExpression);
            this.gbCustom.Controls.Add(this.label10);
            this.gbCustom.Controls.Add(this.label11);
            this.gbCustom.Controls.Add(this.label12);
            this.gbCustom.Controls.Add(this.label13);
            this.gbCustom.Controls.Add(this.btnEnter);
            this.gbCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustom.Location = new System.Drawing.Point(0, 0);
            this.gbCustom.Name = "gbCustom";
            this.gbCustom.Size = new System.Drawing.Size(528, 224);
            this.gbCustom.TabIndex = 10;
            this.gbCustom.TabStop = false;
            this.gbCustom.Text = "Custom expression";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(496, 40);
            this.label9.TabIndex = 1;
            this.label9.Text = "\\040 - Matches an ASCII character as octal (up to three digits); numbers with no " +
                "leading zero are backreferences if they have only one digit or if they correspon" +
                "d to a capturing group number.";
            // 
            // txtCustomExpression
            // 
            this.txtCustomExpression.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.txtCustomExpression.Location = new System.Drawing.Point(8, 16);
            this.txtCustomExpression.Name = "txtCustomExpression";
            this.txtCustomExpression.Size = new System.Drawing.Size(424, 20);
            this.txtCustomExpression.TabIndex = 2;
            this.txtCustomExpression.TabStop = false;
            this.txtCustomExpression.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(496, 32);
            this.label10.TabIndex = 1;
            this.label10.Text = "\\x20 - Matches an ASCII character using hexadecimal representation (exactly two d" +
                "igits).";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 120);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(496, 24);
            this.label11.TabIndex = 1;
            this.label11.Text = "\\cC - Matches an ASCII control character; for example, \\cC is control-C.";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(8, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(496, 32);
            this.label12.TabIndex = 1;
            this.label12.Text = "\\u0020 - Matches a Unicode character using hexadecimal representation (exactly fo" +
                "ur digits).";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(496, 40);
            this.label13.TabIndex = 1;
            this.label13.Text = "\\ - When followed by a character that is not recognized as an escaped character, " +
                "matches that character. For example, \\* is the same as \\x2A";
            // 
            // btnEnter
            // 
            this.btnEnter.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.btnEnter.Location = new System.Drawing.Point(440, 16);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(64, 24);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.TabStop = false;
            this.btnEnter.Text = "Enter";
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Yellow;
            this.Label35.Comment = "In the registered copy custom expressions are available";
            this.Label35.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label35.Location = new System.Drawing.Point(0, 0);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(528, 80);
            this.Label35.TabIndex = 7;
            // 
            // pnlSpecialSymbols
            // 
            this.pnlSpecialSymbols.Controls.Add(this.groupBox1);
            this.pnlSpecialSymbols.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSpecialSymbols.Location = new System.Drawing.Point(0, 80);
            this.pnlSpecialSymbols.Name = "pnlSpecialSymbols";
            this.pnlSpecialSymbols.Size = new System.Drawing.Size(528, 176);
            this.pnlSpecialSymbols.TabIndex = 11;
            // 
            // pnlCustomExpressions
            // 
            this.pnlCustomExpressions.Controls.Add(this.gbCustom);
            this.pnlCustomExpressions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomExpressions.Location = new System.Drawing.Point(0, 256);
            this.pnlCustomExpressions.Name = "pnlCustomExpressions";
            this.pnlCustomExpressions.Size = new System.Drawing.Size(528, 224);
            this.pnlCustomExpressions.TabIndex = 12;
            // 
            // pnlCommand
            // 
            this.pnlCommand.Controls.Add(this.btnCancel);
            this.pnlCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCommand.Location = new System.Drawing.Point(0, 480);
            this.pnlCommand.Name = "pnlCommand";
            this.pnlCommand.Size = new System.Drawing.Size(528, 40);
            this.pnlCommand.TabIndex = 13;
            // 
            // SpecialSymbolsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(528, 518);
            this.Controls.Add(this.pnlCommand);
            this.Controls.Add(this.pnlCustomExpressions);
            this.Controls.Add(this.pnlSpecialSymbols);
            this.Controls.Add(this.Label35);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SpecialSymbolsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Paste special symbol";
            this.groupBox1.ResumeLayout(false);
            this.gbCustom.ResumeLayout(false);
            this.pnlSpecialSymbols.ResumeLayout(false);
            this.pnlCustomExpressions.ResumeLayout(false);
            this.pnlCommand.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void pasteSymbol(object sender, EventArgs e) {
            _specialSymbol = ((Button) sender).Text.Trim();
            CloseOk();
        }

        private void txtCustomExpression_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char) 13)
                return;
            e.Handled = true;
            enterCustomExpression();
        }

        private void enterCustomExpression() {
            string customExpression = txtCustomExpression.Text.Trim();
            if (customExpression.Length == 0)
                return;
            _specialSymbol = customExpression;
            CloseOk();
        }

        private void CloseOk() {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void btnEnter_Click(object sender, EventArgs e) {
            enterCustomExpression();
        }

        private void Label35_OnRegister() {
            _mainController.Register(this);
        }
    }
}