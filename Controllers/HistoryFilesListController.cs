using System.Windows.Forms;

namespace RegexExplorer {
    public class HistoryFilesListController : IItemsListController {
        public ListViewItem ListViewItemFor(object item) {
            MatchesFileItem fileItem = (MatchesFileItem) item;
            ListViewItem viewItem = new ListViewItem(fileItem.FullName);
            viewItem.SubItems.Add(fileItem.CheckedLastLoadedOn);
            viewItem.Tag = fileItem;
            return viewItem;
        }
    }
}