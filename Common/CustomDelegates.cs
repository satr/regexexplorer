using System.Collections;
using System.Drawing;

namespace RegexExplorer {
    public delegate void EditionEventHandler();

    public delegate void CheckClearEventHandler();

    public delegate void ScaleEventHandler(int scaleRateIndex);

    public delegate void ScaleUpDownEventHandler();

    public delegate void OpenFileEventHandler();

    public delegate void ShowMessageEventHandler(string msg);

    public delegate void MatchesFileItemEventHandler(MatchesFileItem matchesFileItem);

    public delegate void RegexPatternEventHandler(RegexPattern regexPattern);

    public delegate void RegexExplorerObjectEventHandler(object item);

    public delegate void RegexExplorerEventHandler();
    
    public delegate void RegexExplorerGetHistoryListEventHandler(ArrayList list);

    public delegate void CaptionModeEventHandler(bool isActive);
}