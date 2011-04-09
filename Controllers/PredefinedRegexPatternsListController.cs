using System.Windows.Forms;

namespace RegexExplorer {
    public class PredefinedRegexPatternsListController : IItemsListController {
        public ListViewItem ListViewItemFor(object item) {
            RegexPattern regexPattern = (RegexPattern) item;
            ListViewItem viewItem = new ListViewItem(regexPattern.Value);
            viewItem.SubItems.Add(regexPattern.Description);
            viewItem.Tag = regexPattern;
            return viewItem;
        }
    }
}