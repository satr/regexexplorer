using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using RegexExplorer;

namespace RegexExplorer {
    public class StoredItemsController {
        private static int UNDEFINED_INDEX = -1;
        private readonly TabControl _tabControl;
        private readonly Button _btnOpen;
        private readonly Button _btnRemove;
        private readonly Button _btnClearAll;
        public event RegexExplorerObjectEventHandler OnSelectItem;
        public event RegexExplorerObjectEventHandler OnOpenItem;
        public event RegexExplorerEventHandler OnClearItem;

        public StoredItemsController(TabControl tabControl, Button btnOpen, Button btnRemove, Button btnClearAll) {
            _tabControl = tabControl;
            _btnOpen = btnOpen;
            _btnRemove = btnRemove;
            _btnClearAll = btnClearAll;
            _btnOpen.Click += new EventHandler(btnOpen_Click);
            _btnRemove.Click += new EventHandler(btnRemove_Click);
            _btnClearAll.Click += new EventHandler(btnClearAll_Click);
            InitLoadButton();
        }

        private void btnClearAll_Click(object sender, EventArgs e) {
            if (!Messenger.Confirmed(MsgsBase.Res.Do_you_really_want_to_clear_the_list))
                return;
            ClearActualItemsList();
            ClearActualItemsListControl();
        }

        private void ClearActualItemsListControl() {
            ActualItemsListControl().SuspendLayout();
            ActualItemsListControl().Items.Clear();
            ActualItemsListControl().ResumeLayout();
        }

        private void ClearActualItemsList() {
            ActualItemsList().Items.Clear();
            ActualItemsList().Save();
            InitLoadButton();
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            RemoveAllSelectedItems();
        }

        protected virtual void RemoveAllSelectedItems() {
            if (ActualItemsList().ReadOnly)
                return;
            if (!ThereAreSelectedItems())
                return;
            if (!Messenger.Confirmed(MsgsBase.Res.Remove_information_about_this_item))
                return;
            RemoveSelectedItemsFromItemsList();
            InitLoadButton();
        }

        private void RemoveSelectedItemsFromItemsList() {
            ListView actualListControl = ActualItemsListControl();
            StoredItemsList storedItemsList = ActualItemsList();
            if (actualListControl.SelectedItems.Count == 0)
                return;
            ListViewItem nextSelectedItem = GetNextItemToSelect(actualListControl);
            RemoveSelectedItemsFor(actualListControl, storedItemsList);
            storedItemsList.Save();
            SelectNextItem(actualListControl, nextSelectedItem);
        }

        private int GetLastSelectedIndex(ListView actualListControl) {
            return actualListControl.Items.IndexOf(GetLastItemOf(actualListControl.SelectedItems));
        }

        private ListViewItem GetLastItemOf(IList list) {
            if (list.Count > 0)
                return (ListViewItem) list[list.Count - 1];
            return new ListViewItem();
        }

        private void SelectNextItem(ListView actualListControl, ListViewItem nextSelectedItem) {
            if (actualListControl.Items.Count == 0) {
                ClearItemControl();
                return;
            }
            if (nextSelectedItem == null)
                nextSelectedItem = actualListControl.Items[actualListControl.Items.Count - 1];
            nextSelectedItem.Selected = true;
        }

        private ListViewItem GetNextItemToSelect(ListView actualListControl) {
            int lastSelectedIndex = GetLastSelectedIndex(actualListControl);
            int maxIndex = actualListControl.Items.Count - 1;
            if (lastSelectedIndex == UNDEFINED_INDEX || lastSelectedIndex == maxIndex)
                return null;
            return actualListControl.Items[++lastSelectedIndex];
        }

        private void RemoveSelectedItemsFor(ListView actualListControl, StoredItemsList storedItemsList) {
            ArrayList itemsToRemove = new ArrayList(actualListControl.SelectedItems);
            actualListControl.SuspendLayout();
            foreach (ListViewItem item in itemsToRemove) {
                storedItemsList.Items.Remove(item.Tag);
                actualListControl.Items.Remove(item);
            }
            actualListControl.ResumeLayout();
        }

        private void ClearItemControl() {
            if (OnClearItem != null)
                OnClearItem();
        }

        private void btnOpen_Click(object sender, EventArgs e) {
            OpenSelectedItem();
        }

        private void OpenSelectedItem() {
            InitLoadButton();
            if (ThereAreSelectedItems() && OnOpenItem != null)
                OnOpenItem(FirstSelectedItem());
        }

        public void InitTabControlFor(TabPage itemsListTabPage, ListView itemsListControl,
                                      StoredItemsList itemsList, IItemsListController itemsListController) {
            PopulateListFor(itemsListControl, itemsList, itemsListController);
            itemsListTabPage.Tag = itemsListControl;
            itemsListControl.SelectedIndexChanged += new EventHandler(ListItem_Selected);
            itemsListControl.DoubleClick += new EventHandler(ListItem_DoubleClick);
            itemsListControl.KeyUp += new KeyEventHandler(itemsListControl_KeyUp);
            itemsListControl.Tag = itemsList;
        }

        private void ListItem_DoubleClick(object sender, EventArgs e) {
            OpenSelectedItem();
        }

        private void ListItem_Selected(object sender, EventArgs e) {
            InitLoadButton();
            if (ThereAreSelectedItems() && OnSelectItem != null)
                OnSelectItem(FirstSelectedItem());
        }

        private void PopulateListFor(ListView listView, StoredItemsList itemsList,
                                     IItemsListController itemsListController) {
            if (itemsList == null)
                return;
            foreach (object item in itemsList.Items)
                listView.Items.Add(itemsListController.ListViewItemFor(item));
        }

        private ListView ActualItemsListControl() {
            object listView = _tabControl.SelectedTab.Tag;
            if (listView == null)
                return new ListView();
            return (ListView) listView;
        }

        private StoredItemsList ActualItemsList() {
            object tag = ActualItemsListControl().Tag;
            if ((tag as StoredItemsList) == null)
                return new NullStoredItemsList();
            return (StoredItemsList) tag;
        }

        private void InitLoadButton() {
            _btnClearAll.Enabled = _btnRemove.Enabled = (ThereAreSelectedItems() && !ActualItemsList().ReadOnly);
            _btnOpen.Enabled = SelectedOnlyOneItem();
        }

        private bool SelectedOnlyOneItem() {
            return ThereAreSelectedItems() && (ActualItemsListControl().SelectedItems.Count == 1);
        }

        private bool ThereAreItemsInList() {
            return ActualItemsListControl().Items.Count > 0;
        }

        private bool ThereAreSelectedItems() {
            return ThereAreItemsInList() && FirstSelectedItem() != null;
        }

        private object FirstSelectedItem() {
            if (ActualItemsListControl() == null)
                return null;
            ListView.SelectedListViewItemCollection selectedItems = ActualItemsListControl().SelectedItems;
            return (ThereAreItemsInList() && selectedItems.Count > 0 ? selectedItems[0].Tag : null);
        }

        public void AddToItemsListFor(object item, StoredItemsList itemsList, int maxItemsQuantity) {
            ArrayList list = itemsList.Items;
            if (list.Contains(item))
                list.Remove(item);
            while (list.Count >= maxItemsQuantity && list.Count > 0)
                list.RemoveAt(list.Count - 1);
            list.Insert(0, item);
            itemsList.Save();
        }

        public void SetInitialOpenFileFolderFor(FileDialog fileDialog, string initialListFolder) {
            if (initialListFolder != null
                && initialListFolder.Length > 0
                && new DirectoryInfo(initialListFolder).Exists)
                fileDialog.InitialDirectory = initialListFolder;
        }

        private void itemsListControl_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.Delete)
                return;
            RemoveAllSelectedItems();
        }

        public void FocusTab(TabPage tabPage, bool showAllTabs) {
            if (!showAllTabs) {
                _tabControl.TabPages.Clear();
                _tabControl.TabPages.Add(tabPage);
            }
            _tabControl.SelectedIndex = _tabControl.TabPages.IndexOf(tabPage);
        }
    }
}