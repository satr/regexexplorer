using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RegexExplorer {
    public class MatchesFileItemControl : UserControl, IValueControl {
        public event MatchesFileItemEventHandler OnAddFileToFavorites;
        public event MatchesFileItemEventHandler OnAddRegexPatternToFavorites;

        #region Controls

        private Container components = null;
        private GroupBox groupBox;
        private Label lblFileStateMessage;
        private Panel panelFileItemProperties;
        private Panel panel2;
        private LinkLabel linkLabelAddThisFileToFavorites;
        private Panel panelAddToFavorites;
        private Panel panelFileName;
        private Label label1;
        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private Label label2;
        private Panel panel5;
        private Panel panel6;
        private Label label3;
        private Label label4;
        private Panel panel7;
        private Panel panel8;
        private Label label5;
        private Panel panel9;
        private Panel panel10;
        private Label label6;
        private Panel panel11;
        private Panel panel12;
        private Label label7;
        private TextBox txtFullName;
        private TextBox txtActualSize;
        private TextBox txtActualLastUpdated;
        private TextBox txtDescription;
        private TextBox txtLastSize;
        private TextBox txtLastLoadedOn;
        private MatchesFileItem _matchesFileItem;

        #endregion

        public MatchesFileItemControl() {
            InitializeComponent();
            Enabled = true;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) if (components != null) components.Dispose();
            base.Dispose(disposing);
        }

        [Browsable(false)]
        public object Value {
            get { return _matchesFileItem; }
            set {
                _matchesFileItem = ((value as MatchesFileItem) == null)
                                       ? new MatchesFileItem() : (MatchesFileItem) value;
                txtFullName.Text = _matchesFileItem.FullName;
                txtActualSize.Text = _matchesFileItem.ActualSizeInKBytes;
                txtActualLastUpdated.Text = _matchesFileItem.ActualLastUpdatedOn;
                txtDescription.Text = _matchesFileItem.Description;
                txtLastLoadedOn.Text = _matchesFileItem.CheckedLastLoadedOn;
                txtLastSize.Text = _matchesFileItem.LastSizeInKBytes;
                panelAddToFavorites.Visible = !_matchesFileItem.IsInFavorites;
            }
        }

        public void Clear() {
            Value = null;
        }

        public string TitleText {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            this.groupBox = new GroupBox();
            this.panelFileItemProperties = new Panel();
            this.panelFileName = new Panel();
            this.label1 = new Label();
            this.panelAddToFavorites = new Panel();
            this.linkLabelAddThisFileToFavorites = new LinkLabel();
            this.panel2 = new Panel();
            this.lblFileStateMessage = new Label();
            this.panel1 = new Panel();
            this.txtFullName = new TextBox();
            this.panel3 = new Panel();
            this.txtActualSize = new TextBox();
            this.panel4 = new Panel();
            this.label2 = new Label();
            this.panel5 = new Panel();
            this.txtActualLastUpdated = new TextBox();
            this.panel6 = new Panel();
            this.label3 = new Label();
            this.label4 = new Label();
            this.panel7 = new Panel();
            this.txtDescription = new TextBox();
            this.panel8 = new Panel();
            this.label5 = new Label();
            this.panel9 = new Panel();
            this.txtLastSize = new TextBox();
            this.panel10 = new Panel();
            this.label6 = new Label();
            this.panel11 = new Panel();
            this.txtLastLoadedOn = new TextBox();
            this.panel12 = new Panel();
            this.label7 = new Label();
            this.groupBox.SuspendLayout();
            this.panelFileItemProperties.SuspendLayout();
            this.panelFileName.SuspendLayout();
            this.panelAddToFavorites.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.panelFileItemProperties);
            this.groupBox.Controls.Add(this.lblFileStateMessage);
            this.groupBox.Dock = DockStyle.Fill;
            this.groupBox.FlatStyle = FlatStyle.System;
            this.groupBox.Location = new Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new Size(456, 208);
            this.groupBox.TabIndex = 1;
            this.groupBox.TabStop = false;
            // 
            // panelFileItemProperties
            // 
            this.panelFileItemProperties.Controls.Add(this.panel11);
            this.panelFileItemProperties.Controls.Add(this.panel9);
            this.panelFileItemProperties.Controls.Add(this.panel7);
            this.panelFileItemProperties.Controls.Add(this.panel5);
            this.panelFileItemProperties.Controls.Add(this.panel3);
            this.panelFileItemProperties.Controls.Add(this.panelFileName);
            this.panelFileItemProperties.Controls.Add(this.panelAddToFavorites);
            this.panelFileItemProperties.Dock = DockStyle.Fill;
            this.panelFileItemProperties.Location = new Point(3, 32);
            this.panelFileItemProperties.Name = "panelFileItemProperties";
            this.panelFileItemProperties.Size = new Size(450, 173);
            this.panelFileItemProperties.TabIndex = 1;
            // 
            // panelFileName
            // 
            this.panelFileName.Controls.Add(this.txtFullName);
            this.panelFileName.Controls.Add(this.panel1);
            this.panelFileName.Controls.Add(this.label1);
            this.panelFileName.Dock = DockStyle.Top;
            this.panelFileName.Location = new Point(0, 24);
            this.panelFileName.Name = "panelFileName";
            this.panelFileName.Size = new Size(450, 24);
            this.panelFileName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Dock = DockStyle.Left;
            this.label1.Location = new Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(72, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Full name";
            this.label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panelAddToFavorites
            // 
            this.panelAddToFavorites.Controls.Add(this.linkLabelAddThisFileToFavorites);
            this.panelAddToFavorites.Controls.Add(this.panel2);
            this.panelAddToFavorites.Dock = DockStyle.Top;
            this.panelAddToFavorites.Location = new Point(0, 0);
            this.panelAddToFavorites.Name = "panelAddToFavorites";
            this.panelAddToFavorites.Size = new Size(450, 24);
            this.panelAddToFavorites.TabIndex = 4;
            this.panelAddToFavorites.Visible = false;
            // 
            // linkLabelAddThisFileToFavorites
            // 
            this.linkLabelAddThisFileToFavorites.Dock = DockStyle.Left;
            this.linkLabelAddThisFileToFavorites.FlatStyle = FlatStyle.System;
            this.linkLabelAddThisFileToFavorites.Location = new Point(80, 0);
            this.linkLabelAddThisFileToFavorites.Name = "linkLabelAddThisFileToFavorites";
            this.linkLabelAddThisFileToFavorites.Size = new Size(160, 24);
            this.linkLabelAddThisFileToFavorites.TabIndex = 9;
            this.linkLabelAddThisFileToFavorites.TabStop = true;
            this.linkLabelAddThisFileToFavorites.Text = "add to favorites";
            this.linkLabelAddThisFileToFavorites.TextAlign = ContentAlignment.MiddleLeft;
            this.linkLabelAddThisFileToFavorites.LinkClicked +=
                new LinkLabelLinkClickedEventHandler(this.LinkLabelAddThisFileToFavorites_LinkClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = DockStyle.Left;
            this.panel2.Location = new Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(80, 24);
            this.panel2.TabIndex = 0;
            // 
            // lblFileStateMessage
            // 
            this.lblFileStateMessage.Dock = DockStyle.Top;
            this.lblFileStateMessage.Font =
                new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((Byte) (204)));
            this.lblFileStateMessage.Location = new Point(3, 16);
            this.lblFileStateMessage.Name = "lblFileStateMessage";
            this.lblFileStateMessage.Size = new Size(450, 16);
            this.lblFileStateMessage.TabIndex = 0;
            this.lblFileStateMessage.Text = "File state message";
            this.lblFileStateMessage.TextAlign = ContentAlignment.MiddleCenter;
            this.lblFileStateMessage.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Dock = DockStyle.Left;
            this.panel1.Location = new Point(72, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(8, 24);
            this.panel1.TabIndex = 4;
            // 
            // txtFullName
            // 
            this.txtFullName.Dock = DockStyle.Fill;
            this.txtFullName.Location = new Point(80, 0);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.Size = new Size(370, 20);
            this.txtFullName.TabIndex = 6;
            this.txtFullName.TabStop = false;
            this.txtFullName.Text = "";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtActualSize);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(450, 24);
            this.panel3.TabIndex = 9;
            // 
            // txtActualSize
            // 
            this.txtActualSize.Dock = DockStyle.Fill;
            this.txtActualSize.Location = new Point(80, 0);
            this.txtActualSize.Name = "txtActualSize";
            this.txtActualSize.ReadOnly = true;
            this.txtActualSize.Size = new Size(370, 20);
            this.txtActualSize.TabIndex = 6;
            this.txtActualSize.TabStop = false;
            this.txtActualSize.Text = "";
            // 
            // panel4
            // 
            this.panel4.Dock = DockStyle.Left;
            this.panel4.Location = new Point(72, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(8, 24);
            this.panel4.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Dock = DockStyle.Left;
            this.label2.Location = new Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(72, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Size";
            this.label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtActualLastUpdated);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = DockStyle.Top;
            this.panel5.Location = new Point(0, 72);
            this.panel5.Name = "panel5";
            this.panel5.Size = new Size(450, 24);
            this.panel5.TabIndex = 10;
            // 
            // txtActualLastUpdated
            // 
            this.txtActualLastUpdated.Dock = DockStyle.Fill;
            this.txtActualLastUpdated.Location = new Point(80, 0);
            this.txtActualLastUpdated.Name = "txtActualLastUpdated";
            this.txtActualLastUpdated.ReadOnly = true;
            this.txtActualLastUpdated.Size = new Size(370, 20);
            this.txtActualLastUpdated.TabIndex = 6;
            this.txtActualLastUpdated.TabStop = false;
            this.txtActualLastUpdated.Text = "";
            // 
            // panel6
            // 
            this.panel6.Dock = DockStyle.Left;
            this.panel6.Location = new Point(72, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new Size(8, 24);
            this.panel6.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Dock = DockStyle.Left;
            this.label3.Location = new Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(72, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Last updated";
            this.label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Dock = DockStyle.Left;
            this.label4.Font =
                new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((Byte) (204)));
            this.label4.Location = new Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(72, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "File:";
            this.label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtDescription);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Dock = DockStyle.Top;
            this.panel7.Location = new Point(0, 96);
            this.panel7.Name = "panel7";
            this.panel7.Size = new Size(450, 24);
            this.panel7.TabIndex = 11;
            // 
            // txtDescription
            // 
            this.txtDescription.Dock = DockStyle.Fill;
            this.txtDescription.Location = new Point(80, 0);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new Size(370, 20);
            this.txtDescription.TabIndex = 6;
            this.txtDescription.TabStop = false;
            this.txtDescription.Text = "";
            // 
            // panel8
            // 
            this.panel8.Dock = DockStyle.Left;
            this.panel8.Location = new Point(72, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new Size(8, 24);
            this.panel8.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Dock = DockStyle.Left;
            this.label5.Location = new Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new Size(72, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Description";
            this.label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.txtLastSize);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Controls.Add(this.label6);
            this.panel9.Dock = DockStyle.Top;
            this.panel9.Location = new Point(0, 120);
            this.panel9.Name = "panel9";
            this.panel9.Size = new Size(450, 24);
            this.panel9.TabIndex = 12;
            // 
            // txtLastSize
            // 
            this.txtLastSize.Dock = DockStyle.Fill;
            this.txtLastSize.Location = new Point(80, 0);
            this.txtLastSize.Name = "txtLastSize";
            this.txtLastSize.ReadOnly = true;
            this.txtLastSize.Size = new Size(370, 20);
            this.txtLastSize.TabIndex = 6;
            this.txtLastSize.TabStop = false;
            this.txtLastSize.Text = "";
            // 
            // panel10
            // 
            this.panel10.Dock = DockStyle.Left;
            this.panel10.Location = new Point(72, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new Size(8, 24);
            this.panel10.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Dock = DockStyle.Left;
            this.label6.Location = new Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new Size(72, 24);
            this.label6.TabIndex = 0;
            this.label6.Text = "Last size";
            this.label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtLastLoadedOn);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Controls.Add(this.label7);
            this.panel11.Dock = DockStyle.Top;
            this.panel11.Location = new Point(0, 144);
            this.panel11.Name = "panel11";
            this.panel11.Size = new Size(450, 24);
            this.panel11.TabIndex = 13;
            // 
            // txtLastLoadedOn
            // 
            this.txtLastLoadedOn.Dock = DockStyle.Fill;
            this.txtLastLoadedOn.Location = new Point(80, 0);
            this.txtLastLoadedOn.Name = "txtLastLoadedOn";
            this.txtLastLoadedOn.ReadOnly = true;
            this.txtLastLoadedOn.Size = new Size(370, 20);
            this.txtLastLoadedOn.TabIndex = 6;
            this.txtLastLoadedOn.TabStop = false;
            this.txtLastLoadedOn.Text = "";
            // 
            // panel12
            // 
            this.panel12.Dock = DockStyle.Left;
            this.panel12.Location = new Point(72, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new Size(8, 24);
            this.panel12.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Dock = DockStyle.Left;
            this.label7.Location = new Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new Size(72, 24);
            this.label7.TabIndex = 0;
            this.label7.Text = "Last loaded";
            this.label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MatchesFileItemControl
            // 
            this.Controls.Add(this.groupBox);
            this.Name = "MatchesFileItemControl";
            this.Size = new Size(456, 208);
            this.groupBox.ResumeLayout(false);
            this.panelFileItemProperties.ResumeLayout(false);
            this.panelFileName.ResumeLayout(false);
            this.panelAddToFavorites.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void LinkLabelAddThisFileToFavorites_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (OnAddFileToFavorites != null && _matchesFileItem != null)
                OnAddFileToFavorites(_matchesFileItem);
            _matchesFileItem.IsInFavorites = true;
        }

        new public bool Enabled {
            get { return panelFileItemProperties.Visible; }
            set {
                if (!value)
                    Value = null;
                panelFileItemProperties.Visible = value;
                lblFileStateMessage.Visible = !value;
            }
        }

        public bool FileIsLoaded {
            get { return _matchesFileItem != null; }
        }

        public bool FileIsInFavorites {
            get { return (FileIsLoaded && _matchesFileItem.IsInFavorites); }
        }
    }
}