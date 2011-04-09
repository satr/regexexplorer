using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RegexExplorer;

namespace RegexExplorer {
    public class EditableListControl : UserControl {
        #region Controls

        private GroupBox groupBox;
        private Panel panel1;
        private TextBox txtNewLineText;
        private Panel panel2;
        private Button btnAddNew;
        private Panel panel3;
        private ListView lvTargetTextsList;
        private TextBox txtLineEditBox;
        private ColumnHeader colResult;
        private ColumnHeader clTargetText;
        private Container components = null;
        private Panel panel4;
        private CheckBox cbKeepTextAfterAddition;

        #endregion

        public event EditionEventHandler onGotFocus;
        public event EditionEventHandler onKeepTextAfterAdditionFlagChanged;
        public event ShowMessageEventHandler onShowMessage;

        private static int RESULT_TEXT_COLUMN_INDEX = 0;
        private static int TARGET_TEXT_COLUMN_INDEX = 1;
        private ArrayList _list = new ArrayList();
        private Control _lastFocusedControl;

        private string _beforeEditionText = "";
        private Control _controlFocusedBeforeEdition;

        public EditableListControl() {
            InitializeComponent();
            _lastFocusedControl = _controlFocusedBeforeEdition = lvTargetTextsList;
            btnAddNew.Click += new EventHandler(addNewLine_Click);
            lvTargetTextsList.MouseUp += new MouseEventHandler(lbMatches_MouseUp);
            lvTargetTextsList.KeyUp += new KeyEventHandler(lvTargetTextsList_KeyUp);
            lvTargetTextsList.ColumnClick += new ColumnClickEventHandler(lvTargetTextsList_ColumnClick);
            txtNewLineText.GotFocus += new EventHandler(txtNewLineText_GotFocus);
            
        }

        protected void addTargetText() {
            string text = txtNewLineText.Text.Trim();
            if (text.Length == 0)
                return;
            lvTargetTextsList.BeginUpdate();
            bool isAdded = addItemFor(text);
            lvTargetTextsList.EndUpdate();
            if (!keepTextAfterAddition && isAdded)
                clearNewLineField();
            txtNewLineText.Focus();
        }

        private void clearNewLineField() {
            if (newLineFieldIsInFocus())
                txtNewLineText.Text = "";
        }

        private bool newLineFieldIsInFocus() {
            return _lastFocusedControl == txtNewLineText;
        }

        private bool addItemFor(string text) {
            if (_list.Contains(text)) {
                showMessage("Duplicated line");
                return false;
            }
            _list.Add(text);
            lvTargetTextsList.Items.Add(targetTextLineFor(text));
            clearMessage();
            return true;
        }

        private void clearMessage() {
            showMessage("");
        }

        private void showMessage(string msg) {
            if (onShowMessage != null)
                onShowMessage(msg);
        }

        private ListViewItem targetTextLineFor(string text) {
            ListViewItem item = new ListViewItem("");
            item.SubItems.Add(text);
            return item;
        }

        private void addNewLine_Click(object sender, EventArgs e) {
            addTargetText();
        }

        public void clear() {
            clearNewLineField();
            clearItemsFromList();
            clearEditableItemField();
        }

        private void clearEditableItemField() {
            if (!editableFieldIsInFocuse())
                return;
            txtLineEditBox.Text = "";
        }

        private bool editableFieldIsInFocuse() {
            return txtLineEditBox != null && _lastFocusedControl == txtLineEditBox;
        }

        private void clearItemsFromList() {
            if (!listIsInFocus() || !thereAreItemsInList())
                return;
            if (thereAreSelectedItemsInList())
                clearSelectedItems();
            else
                clearEntireList();
        }

        private bool listIsInFocus() {
            return _lastFocusedControl == lvTargetTextsList;
        }

        private bool thereAreItemsInList() {
            return lvTargetTextsList.Items.Count > 0;
        }

        private bool thereAreSelectedItemsInList() {
            return lvTargetTextsList.SelectedItems.Count > 0;
        }

        private void clearSelectedItems() {
            IList itemsToRemove = new ArrayList();
            foreach (ListViewItem item in lvTargetTextsList.SelectedItems)
                itemsToRemove.Add(item);
            foreach (ListViewItem item in itemsToRemove) {
                _list.Remove(item.SubItems[TARGET_TEXT_COLUMN_INDEX].Text);
                lvTargetTextsList.Items.Remove(item);
            }
        }

        private void clearEntireList() {
            if (!Messenger.Confirmed(MsgsBase.Res.Do_you_want_to_clear_all_existed_target_lines))
                return;
            _list.Clear();
            lvTargetTextsList.Items.Clear();
        }

        public IList items {
            get {
                IList list = new ArrayList(lvTargetTextsList.Items.Count);
                foreach (ListViewItem item in lvTargetTextsList.Items)
                    list.Add(item.SubItems[TARGET_TEXT_COLUMN_INDEX].Text);
                return list;
            }
        }

        private void lbMatches_MouseUp(object sender, MouseEventArgs e) {
            _lastFocusedControl = lvTargetTextsList;
            ListViewItem item = getItemAt(e.X, e.Y);
            if (item == null)
                return;
            if (targetTextIsUnder(e.X))
                editTextFor(item);
        }

        private ListViewItem getItemAt(int x, int y) {
            return lvTargetTextsList.GetItemAt(x, y);
        }

        private void editTextFor(ListViewItem item) {
            item.EnsureVisible();
            txtLineEditBox = new TextBox();
            int x = widthColumn(RESULT_TEXT_COLUMN_INDEX) + lvTargetTextsList.Bounds.X;
            int y = lvTargetTextsList.Bounds.Y + item.Bounds.Y;
            int width = lvTargetTextsList.Width - x;
            int height = item.Bounds.Height;
            txtLineEditBox.Bounds = new Rectangle(x, y, width, height);
            txtLineEditBox.Text = _beforeEditionText = itemText(item);
            txtLineEditBox.LostFocus += new EventHandler(editBox_LostFocus);
            txtLineEditBox.KeyDown += new KeyEventHandler(editBox_KeyDown);
            txtLineEditBox.Tag = item;
            lvTargetTextsList.Parent.Controls.Add(txtLineEditBox);
            txtLineEditBox.BringToFront();
            txtLineEditBox.SelectAll();
            txtLineEditBox.Focus();
            _controlFocusedBeforeEdition = _lastFocusedControl;
            _lastFocusedControl = txtLineEditBox;
        }

        private int widthColumn(int index) {
            return lvTargetTextsList.Columns[index].Width;
        }

        private bool targetTextIsUnder(int x) {
            return rightBorderOf(RESULT_TEXT_COLUMN_INDEX) < x;
        }

        private int rightBorderOf(int columnIndex) {
            return lvTargetTextsList.Columns[columnIndex].Width;
        }

        private void editBox_LostFocus(object sender, EventArgs e) {
            finishEdition(true);
            restoreLasFocusedControlBeforeEdition();
        }

        private void finishEdition(bool acceptChanges) {
            txtLineEditBox.LostFocus -= new EventHandler(editBox_LostFocus);
            txtLineEditBox.KeyDown -= new KeyEventHandler(editBox_KeyDown);
            ListViewItem item = (ListViewItem) txtLineEditBox.Tag;
            if (acceptChanges && txtLineEditBox.Text != _beforeEditionText) {
                lvTargetTextsList.BeginUpdate();
                item.SubItems[TARGET_TEXT_COLUMN_INDEX].Text = txtLineEditBox.Text;
                item.SubItems[RESULT_TEXT_COLUMN_INDEX].Text = "";
                lvTargetTextsList.EndUpdate();
            }
            lvTargetTextsList.Parent.Controls.Remove(txtLineEditBox);
            txtLineEditBox.Dispose();
        }

        private void editBox_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Enter:
                    acceptingEdition();
                    break;
                case Keys.Escape:
                    cancelEdition();
                    break;
                case Keys.Up:
                    int prevItemIndex = ((ListViewItem) txtLineEditBox.Tag).Index - 1;
                    if (prevItemIndex < 0)
                        return;
                    acceptingEdition();
                    editTextFor(lvTargetTextsList.Items[prevItemIndex]);
                    break;
                case Keys.Down:
                    int nextItemIndex = ((ListViewItem) txtLineEditBox.Tag).Index + 1;
                    if (nextItemIndex >= lvTargetTextsList.Items.Count)
                        return;
                    acceptingEdition();
                    editTextFor(lvTargetTextsList.Items[nextItemIndex]);
                    break;
                default:
                    return;
            }
            e.Handled = true;
        }

        private void acceptingEdition() {
            finishEdition(true);
            restoreLasFocusedControlBeforeEdition();
        }

        private void cancelEdition() {
            finishEdition(false);
            restoreLasFocusedControlBeforeEdition();
        }

        private Control restoreLasFocusedControlBeforeEdition() {
            return _lastFocusedControl = _controlFocusedBeforeEdition;
        }

        private string itemText(ListViewItem item) {
            return item.SubItems[TARGET_TEXT_COLUMN_INDEX].Text;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void setResultTextFor(int index, string text) {
            if (!indexIsValidFor(index))
                return;
            lvTargetTextsList.Items[index].SubItems[RESULT_TEXT_COLUMN_INDEX].Text = text;
        }

        public void setResultForeColorFor(int index, Color color) {
            if (!indexIsValidFor(index))
                return;
            lvTargetTextsList.BeginUpdate();
            lvTargetTextsList.Items[index].ForeColor = color;
            lvTargetTextsList.EndUpdate();
        }

        public void setResultBackColorFor(int index, Color color) {
            if (!indexIsValidFor(index))
                return;
            lvTargetTextsList.BeginUpdate();
            lvTargetTextsList.Items[index].BackColor = color;
            lvTargetTextsList.EndUpdate();
        }

        private bool indexIsValidFor(int index) {
            return index >= 0 && lvTargetTextsList.Items.Count > index;
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.groupBox = new GroupBox();
            this.lvTargetTextsList = new ListView();
            this.colResult = new ColumnHeader();
            this.clTargetText = new ColumnHeader();
            this.panel3 = new Panel();
            this.cbKeepTextAfterAddition = new CheckBox();
            this.panel4 = new Panel();
            this.panel1 = new Panel();
            this.txtNewLineText = new TextBox();
            this.panel2 = new Panel();
            this.btnAddNew = new Button();
            this.groupBox.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.lvTargetTextsList);
            this.groupBox.Controls.Add(this.panel3);
            this.groupBox.Controls.Add(this.panel1);
            this.groupBox.Dock = DockStyle.Fill;
            this.groupBox.FlatStyle = FlatStyle.System;
            this.groupBox.Location = new Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new Size(472, 304);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Target texts list";
            // 
            // lvTargetTextsList
            // 
            this.lvTargetTextsList.Columns.AddRange(new ColumnHeader[] {
                                                                           this.colResult,
                                                                           this.clTargetText
                                                                       });
            this.lvTargetTextsList.Dock = DockStyle.Fill;
            this.lvTargetTextsList.FullRowSelect = true;
            this.lvTargetTextsList.GridLines = true;
            this.lvTargetTextsList.HideSelection = false;
            this.lvTargetTextsList.Location = new Point(3, 56);
            this.lvTargetTextsList.Name = "lvTargetTextsList";
            this.lvTargetTextsList.Size = new Size(466, 245);
            this.lvTargetTextsList.TabIndex = 15;
            this.lvTargetTextsList.TabStop = false;
            this.lvTargetTextsList.View = View.Details;
            // 
            // colResult
            // 
            this.colResult.Text = "Result";
            this.colResult.Width = 80;
            // 
            // clTargetText
            // 
            this.clTargetText.Text = "Target text";
            this.clTargetText.Width = 1200;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbKeepTextAfterAddition);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = DockStyle.Top;
            this.panel3.Location = new Point(3, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(466, 16);
            this.panel3.TabIndex = 2;
            // 
            // cbKeepTextAfterAddition
            // 
            this.cbKeepTextAfterAddition.Dock = DockStyle.Fill;
            this.cbKeepTextAfterAddition.Location = new Point(80, 0);
            this.cbKeepTextAfterAddition.Name = "cbKeepTextAfterAddition";
            this.cbKeepTextAfterAddition.Size = new Size(386, 16);
            this.cbKeepTextAfterAddition.TabIndex = 1;
            this.cbKeepTextAfterAddition.TabStop = false;
            this.cbKeepTextAfterAddition.Text = "Keep target text after addition";
            this.cbKeepTextAfterAddition.CheckedChanged += new EventHandler(this.cbKeepTextAfterAddition_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Dock = DockStyle.Left;
            this.panel4.Location = new Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(80, 16);
            this.panel4.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNewLineText);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnAddNew);
            this.panel1.Dock = DockStyle.Top;
            this.panel1.Location = new Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(466, 24);
            this.panel1.TabIndex = 1;
            // 
            // txtNewLineText
            // 
            this.txtNewLineText.Dock = DockStyle.Fill;
            this.txtNewLineText.Location = new Point(80, 0);
            this.txtNewLineText.Name = "txtNewLineText";
            this.txtNewLineText.Size = new Size(386, 20);
            this.txtNewLineText.TabIndex = 2;
            this.txtNewLineText.Text = "";
            this.txtNewLineText.KeyPress += new KeyPressEventHandler(this.txtNewLineText_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Dock = DockStyle.Left;
            this.panel2.Location = new Point(72, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(8, 24);
            this.panel2.TabIndex = 1;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Dock = DockStyle.Left;
            this.btnAddNew.FlatStyle = FlatStyle.System;
            this.btnAddNew.Location = new Point(0, 0);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new Size(72, 24);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.TabStop = false;
            this.btnAddNew.Text = "Add";
            // 
            // EditableListControl
            // 
            this.Controls.Add(this.groupBox);
            this.Name = "EditableListControl";
            this.Size = new Size(472, 304);
            this.groupBox.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void txtNewLineText_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar != (char) 13)
                return;
            e.Handled = true;
            addTargetText();
        }

        [Browsable(true)]
        new public string Text {
            get { return groupBox.Text; }
            set { groupBox.Text = value; }
        }

        public int initListFor(string[] list, bool append) {
            if (txtLineEditBox != null && txtLineEditBox.Focused)
                acceptingEdition();
            lvTargetTextsList.BeginUpdate();
            if (!append)
                clearItemsFromList();
            IList currentItems = items;
            int initItemsCount = currentItems.Count;
            for (int i = 0; i < list.Length; i++) {
                string text = list[i].Trim();
                if (text.Length > 0 && !currentItems.Contains(text)) {
                    addItemFor(text);
                    currentItems.Add(text);
                }
            }
            lvTargetTextsList.EndUpdate();
            return currentItems.Count - initItemsCount;
        }

        public void copy() {
            activeTextBox.Copy();
        }

        public void cut() {
            activeTextBox.Cut();
        }

        public void paste() {
            activeTextBox.Paste();
        }

        private TextBox activeTextBox {
            get {
                if (txtNewLineText.Focused)
                    return txtNewLineText;
                if (txtLineEditBox != null && txtLineEditBox.Focused)
                    return txtLineEditBox;
                return new NullTextBox();
            }
        }

        public bool keepTextAfterAddition {
            set { cbKeepTextAfterAddition.Checked = value; }
            get { return cbKeepTextAfterAddition.Checked; }
        }

        private void txtNewLineText_GotFocus(object sender, EventArgs e) {
            _lastFocusedControl = txtNewLineText;
            if (onGotFocus != null)
                onGotFocus();
        }

        private void cbKeepTextAfterAddition_CheckedChanged(object sender, EventArgs e) {
            if (onKeepTextAfterAdditionFlagChanged != null)
                onKeepTextAfterAdditionFlagChanged();
        }

        private class NullTextBox : TextBox {
            public void copy() {
            }

            public void cut() {
            }

            public void paste() {
            }
        }

        private void lvTargetTextsList_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Delete)
                clearItemsFromList();
        }


        private void lvTargetTextsList_ColumnClick(object sender, ColumnClickEventArgs e) {
            lvTargetTextsList.ListViewItemSorter = new ListViewItemComparer(e.Column);
        }
    }
}