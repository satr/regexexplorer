using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace RegexExplorer {
    /// <summary>
    /// Summary description for QuickListForm.
    /// </summary>
    public class QuickListForm : Form {
        public event RegexPatternEventHandler OnSelectPattern;
        public event RegexExplorerEventHandler OnShow;
        public event RegexExplorerEventHandler OnHide;
        private ListView listView;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private Container components = null;

        public ListView ListControl {
            get { return listView; }
        }
        public RegexPattern SelectedRegexPattern {
            get {
                if (ListControl.SelectedItems.Count == 0)
                    return null;
                return (RegexPattern) ListControl.SelectedItems[0].Tag;
            }
        }

        public QuickListForm() : this(false) {
        }

        public QuickListForm(bool showTitle) {
            InitializeComponent();
            Activated += new EventHandler(QuickListForm_Activated);
            listView.LostFocus += new EventHandler(listBox_LostFocus);
            KeyUp += new KeyEventHandler(QuickListForm_KeyUp);
            listView.KeyUp += new KeyEventHandler(QuickListForm_KeyUp);
            listView.KeyPress += new KeyPressEventHandler(listView_KeyPress);
            listView.Click += new EventHandler(listView_Click);
            listView.DoubleClick += new EventHandler(listView_Click);
            this.Closing += new CancelEventHandler(QuickListForm_Closing);
            ControlBox = showTitle;
            FormBorderStyle = showTitle ? FormBorderStyle.FixedToolWindow : FormBorderStyle.None;
            StartPosition = showTitle ? FormStartPosition.CenterParent : FormStartPosition.Manual;
        }
        
        // <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.listView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.FullRowSelect = true;
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.MultiSelect = false;
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(292, 300);
            this.listView.TabIndex = 0;
            this.listView.TabStop = false;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // QuickListForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 300);
            this.Controls.Add(this.listView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QuickListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private void QuickListForm_Activated(object sender, EventArgs e) {
            listView.Focus();
            if(OnShow != null)
                OnShow();
        }

        private void listBox_LostFocus(object sender, EventArgs e) {
            HideForm();
        }

        private void HideForm() {
            Hide();
            if(OnHide != null)
                OnHide();
        }

        private void QuickListForm_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Escape)
                return;
            e.Handled = true;
            HideForm();
        }

        public void SetDataList(ArrayList patternsList, bool showDescription) {
            listView.SuspendLayout();
            listView.Columns.Clear();
            ColumnHeader valueColumnHeader = new ColumnHeader();
            listView.Columns.Add(valueColumnHeader);
            if (!showDescription) {
                valueColumnHeader.Width = Width - 20;
            }
            else {
                ColumnHeader descriptionColumnHeader = new ColumnHeader();
                listView.Columns.Add(descriptionColumnHeader);
                valueColumnHeader.Width = 50;
                descriptionColumnHeader.Width = Width - descriptionColumnHeader.Width - 20;
            }
            listView.Items.Clear();
            foreach (RegexPattern regexPattern in patternsList) {
                ListViewItem listViewItem = new ListViewItem(regexPattern.Value);
                if (showDescription)
                    listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem(listViewItem, regexPattern.Description));
                listViewItem.Tag = regexPattern;
                listView.Items.Add(listViewItem);
            }
            if (listView.Items.Count > 0)
                listView.Items[0].Selected = true;
            listView.ResumeLayout();
        }

        private void QuickListForm_Closing(object sender, CancelEventArgs e) {
            Hide();
            e.Cancel = true;
        }

        private void listView_Click(object sender, System.EventArgs e) {
            FireOnSelectPattern();
        }

        private void FireOnSelectPattern() {
            RegexPattern regexPattern = SelectedRegexPattern;
            if(regexPattern != null && OnSelectPattern != null)
                OnSelectPattern(regexPattern);
        }

        private void listView_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char) 13)
                return;
            e.Handled = true;
            FireOnSelectPattern();
        }

        private void QuickListForm_Deactivate(object sender, EventArgs e) {
            HideForm();
        }
    }
}