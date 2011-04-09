using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RegexExplorer.Controls {
    public class MatchesTargetControl : UserControl {
        private TabControl tabControlMatchesSource;
        private TabPage tabText;
        private TitledTextField targetTextMatchesField;
        private TabPage tabFile;
        private MatchesFileItemControl matchesFileItemControl;
        private Container components = null;

        public MatchesTargetControl() {
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

        private void InitializeComponent() {
            this.tabControlMatchesSource = new TabControl();
            this.tabText = new TabPage();
            this.targetTextMatchesField = new TitledTextField();
            this.tabFile = new TabPage();
            this.matchesFileItemControl = new MatchesFileItemControl();
            this.tabControlMatchesSource.SuspendLayout();
            this.tabText.SuspendLayout();
            this.tabFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlMatchesSource
            // 
            this.tabControlMatchesSource.Controls.Add(this.tabText);
            this.tabControlMatchesSource.Controls.Add(this.tabFile);
            this.tabControlMatchesSource.Dock = DockStyle.Fill;
            this.tabControlMatchesSource.Location = new Point(0, 0);
            this.tabControlMatchesSource.Name = "tabControlMatchesSource";
            this.tabControlMatchesSource.SelectedIndex = 0;
            this.tabControlMatchesSource.Size = new Size(272, 224);
            this.tabControlMatchesSource.TabIndex = 4;
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.targetTextMatchesField);
            this.tabText.Location = new Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Size = new Size(264, 198);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "Target text";
            this.tabText.ToolTipText = "Check matches in text";
            // 
            // targetTextMatchesField
            // 
            this.targetTextMatchesField.Dock = DockStyle.Fill;
            this.targetTextMatchesField.Location = new Point(0, 0);
            this.targetTextMatchesField.Multiline = true;
            this.targetTextMatchesField.Name = "targetTextMatchesField";
            this.targetTextMatchesField.ReadOnly = false;
            this.targetTextMatchesField.Size = new Size(264, 198);
            this.targetTextMatchesField.TabIndex = 2;
            this.targetTextMatchesField.TitleText = "";
            // 
            // tabFile
            // 
            this.tabFile.Controls.Add(this.matchesFileItemControl);
            this.tabFile.Location = new Point(4, 22);
            this.tabFile.Name = "tabFile";
            this.tabFile.Size = new Size(264, 198);
            this.tabFile.TabIndex = 1;
            this.tabFile.Text = "Target file";
            this.tabFile.ToolTipText = "Check matches in file";
            this.tabFile.Visible = false;
            // 
            // matchesFileItemControl
            // 
            this.matchesFileItemControl.Dock = DockStyle.Fill;
            this.matchesFileItemControl.Location = new Point(0, 0);
            this.matchesFileItemControl.Name = "matchesFileItemControl";
            this.matchesFileItemControl.Size = new Size(264, 198);
            this.matchesFileItemControl.TabIndex = 2;
            this.matchesFileItemControl.TitleText = "";
            // 
            // MatchesTargetControl
            // 
            this.Controls.Add(this.tabControlMatchesSource);
            this.Name = "MatchesTargetControl";
            this.Size = new Size(272, 224);
            this.tabControlMatchesSource.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabFile.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        public TitledTextField TargetTextMatchesField {
            get { return targetTextMatchesField; }
        }

        public MatchesFileItemControl MatchesFileItemControl {
            get { return matchesFileItemControl; }
        }

        public bool FileItemIsEnabled {
            set {
                if (value) {
                    if (tabControlMatchesSource.TabPages.Count == 1)
                        tabControlMatchesSource.TabPages.Add(tabFile);
                    return;
                }
                if (tabControlMatchesSource.TabPages.Count == 2)
                    tabControlMatchesSource.TabPages.Remove(tabFile);
            }
        }
    }
}