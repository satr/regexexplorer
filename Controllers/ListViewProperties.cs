using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace RegexExplorer {
    public class ListViewProperties {
        private IList _items = new ArrayList();
        private IList _columns = new ArrayList();

        public void AddColumn() {
            ColumnHeader columnHeader = new ColumnHeader();
            columnHeader.Text = string.Empty;
            _columns.Add(columnHeader);
        }

        public void AddColumns(int columnCount) {
            for (int i = 0; i < columnCount; i++)
                AddColumn();
        }

        public void AddItem(string value) {
            _items.Add(new ListViewItem(value));
        }

        public void AddItem(StringCollection values) {
            string[] captionValues;
            captionValues = new string[values.Count];
            values.CopyTo(captionValues, 0);
            _items.Add(new ListViewItem(captionValues));
        }

        public ColumnHeader[] GetColumnHeadersArray() {
            ColumnHeader[] columnHeaders = new ColumnHeader[_columns.Count];
            new ArrayList(_columns).CopyTo(columnHeaders);
            return columnHeaders;
        }

        public ListViewItem[] GetListViewItemsArray() {
            ListViewItem[] listViewItems = new ListViewItem[_items.Count];
            _items.CopyTo(listViewItems, 0);
            return listViewItems;
        }
    }
}