using System.Windows.Forms;

namespace RegexExplorer {
    public interface IItemsListController {
        ListViewItem ListViewItemFor(object item);
    }
}