using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using RegexExplorer.OtherForms;

namespace RegexExplorer.Controls {
    public class MatchesResultControl : UserControl {
        public event CaptionModeEventHandler OnCaptionMode;
        #region Controls

        private TabControl tabControl;
        private TabPage tabMatches;
        private GroupBox gbMatches;
        private ListBox lbMatches;
        private TabPage tabCaptions;
        private ComboBox cbGroups;
        private GroupBox gbCaptions;
        private ListView lvCaptions;
        private Container components = null;

        #endregion

        public MatchesResultControl() {
            InitializeComponent();
            Bind();
        }

        private void Bind() {
            lbMatches.DoubleClick += new EventHandler(lbMatches_DoubleClick);
            lvCaptions.DoubleClick += new EventHandler(lvCaptions_DoubleClick);
            lvCaptions.ColumnClick += new ColumnClickEventHandler(lvCaptions_ColumnClick);
            tabControl.SelectedIndexChanged += new EventHandler(tabControl_SelectedIndexChanged);
        }

        private void UnBind() {
            lbMatches.DoubleClick -= new EventHandler(lbMatches_DoubleClick);
            lvCaptions.DoubleClick -= new EventHandler(lvCaptions_DoubleClick);
            lvCaptions.ColumnClick -= new ColumnClickEventHandler(lvCaptions_ColumnClick);
            tabControl.SelectedIndexChanged -= new EventHandler(tabControl_SelectedIndexChanged);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    UnBind();
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMatches = new System.Windows.Forms.TabPage();
            this.gbMatches = new System.Windows.Forms.GroupBox();
            this.lbMatches = new System.Windows.Forms.ListBox();
            this.tabCaptions = new System.Windows.Forms.TabPage();
            this.gbCaptions = new System.Windows.Forms.GroupBox();
            this.lvCaptions = new System.Windows.Forms.ListView();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.tabMatches.SuspendLayout();
            this.gbMatches.SuspendLayout();
            this.tabCaptions.SuspendLayout();
            this.gbCaptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMatches);
            this.tabControl.Controls.Add(this.tabCaptions);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(288, 264);
            this.tabControl.TabIndex = 0;
            // 
            // tabMatches
            // 
            this.tabMatches.Controls.Add(this.gbMatches);
            this.tabMatches.Location = new System.Drawing.Point(4, 22);
            this.tabMatches.Name = "tabMatches";
            this.tabMatches.Size = new System.Drawing.Size(280, 238);
            this.tabMatches.TabIndex = 0;
            this.tabMatches.Text = "Matches";
            // 
            // gbMatches
            // 
            this.gbMatches.Controls.Add(this.lbMatches);
            this.gbMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMatches.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbMatches.Location = new System.Drawing.Point(0, 0);
            this.gbMatches.Name = "gbMatches";
            this.gbMatches.Size = new System.Drawing.Size(280, 238);
            this.gbMatches.TabIndex = 1;
            this.gbMatches.TabStop = false;
            // 
            // lbMatches
            // 
            this.lbMatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMatches.HorizontalScrollbar = true;
            this.lbMatches.Location = new System.Drawing.Point(3, 16);
            this.lbMatches.Name = "lbMatches";
            this.lbMatches.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbMatches.Size = new System.Drawing.Size(274, 212);
            this.lbMatches.TabIndex = 1;
            this.lbMatches.TabStop = false;
            // 
            // tabCaptions
            // 
            this.tabCaptions.Controls.Add(this.gbCaptions);
            this.tabCaptions.Controls.Add(this.cbGroups);
            this.tabCaptions.Location = new System.Drawing.Point(4, 22);
            this.tabCaptions.Name = "tabCaptions";
            this.tabCaptions.Size = new System.Drawing.Size(280, 238);
            this.tabCaptions.TabIndex = 1;
            this.tabCaptions.Text = "Captions";
            // 
            // gbCaptions
            // 
            this.gbCaptions.Controls.Add(this.lvCaptions);
            this.gbCaptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCaptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbCaptions.Location = new System.Drawing.Point(0, 21);
            this.gbCaptions.Name = "gbCaptions";
            this.gbCaptions.Size = new System.Drawing.Size(280, 217);
            this.gbCaptions.TabIndex = 2;
            this.gbCaptions.TabStop = false;
            // 
            // lvCaptions
            // 
            this.lvCaptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCaptions.FullRowSelect = true;
            this.lvCaptions.GridLines = true;
            this.lvCaptions.Location = new System.Drawing.Point(3, 16);
            this.lvCaptions.Name = "lvCaptions";
            this.lvCaptions.Size = new System.Drawing.Size(274, 198);
            this.lvCaptions.TabIndex = 0;
            this.lvCaptions.View = System.Windows.Forms.View.Details;
            // 
            // cbGroups
            // 
            this.cbGroups.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGroups.Location = new System.Drawing.Point(0, 0);
            this.cbGroups.Name = "cbGroups";
            this.cbGroups.Size = new System.Drawing.Size(280, 21);
            this.cbGroups.TabIndex = 0;
            // 
            // MatchesResultControl
            // 
            this.Controls.Add(this.tabControl);
            this.Name = "MatchesResultControl";
            this.Size = new System.Drawing.Size(288, 264);
            this.tabControl.ResumeLayout(false);
            this.tabMatches.ResumeLayout(false);
            this.gbMatches.ResumeLayout(false);
            this.tabCaptions.ResumeLayout(false);
            this.gbCaptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private void lbMatches_DoubleClick(object sender, EventArgs e) {
            ShowSelectedMatchesItems();
        }

        public void ShowSelectedMatchesItems() {
            ShowSelectedMatchesItems(true);
        }

        public void ShowSelectedMatchesItems(bool selectedOnly) {
            IList itemsToShow = selectedOnly? new ArrayList(lbMatches.SelectedItems): new ArrayList(lbMatches.Items);
            if (0 == itemsToShow.Count)
                return;
            ShowItemsTextFor(itemsToShow);
        }

        public void ShowSelectedCaptionsItems() {
            ShowSelectedCaptionsItems(true);
        }

        public void ShowSelectedCaptionsItems(bool selectedOnly) {
            IList itemsToSelect = selectedOnly? new ArrayList(lvCaptions.SelectedItems): new ArrayList(lvCaptions.Items);
            if (0 == itemsToSelect.Count)
                return;
            ShowCaptionItemsTextFor(itemsToSelect);
        }

        public bool MatchesTabIsActive {
            get { return tabControl.SelectedIndex == 0; }
        }

        public ListBox LbMatches {
            get { return lbMatches; }
        }

        public ComboBox LbGroups {
            get { return cbGroups; }
        }

        public ListView LvCaptions {
            get { return lvCaptions; }
        }

        private void ShowItemsTextFor(IList items) {
            StringBuilder itemsText = new StringBuilder();
            foreach (object item in items) {
                itemsText.Append(item.ToString());
                itemsText.Append(Environment.NewLine);
                itemsText.Append(">>");
                itemsText.Append(Environment.NewLine);
            }
            TextFieldForm textFieldForm = new TextFieldForm(itemsText);
            textFieldForm.ShowDialog();
        }

        private void ShowCaptionItemsTextFor(IList items) {
            StringBuilder itemsText = new StringBuilder();
            foreach (ListViewItem item in items) {
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                    itemsText.AppendFormat("{0};", subItem.Text);
                itemsText.Append(Environment.NewLine);
            }
            TextFieldForm textFieldForm = new TextFieldForm(itemsText);
            textFieldForm.ShowDialog();
        }

        private void lvCaptions_ColumnClick(object sender, ColumnClickEventArgs e) {
            lvCaptions.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }

        private void lvCaptions_DoubleClick(object sender, EventArgs e) {
            ShowSelectedCaptionsItems();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e) {
            if(OnCaptionMode != null)
                OnCaptionMode(IsCaptionsMode);
        }

        public bool IsCaptionsMode {
            get { return tabControl.SelectedTab == tabCaptions; }
        }

        public void InitHelpProvider(MainController mainController) {
            mainController.SetHelpProviderFor(tabMatches, "Matches");
            mainController.SetHelpProviderFor(tabCaptions, "Captions");
        }
    }
}