using System;
using System.Collections;
using System.Collections.Specialized;
using RegexExplorer;

namespace RegexExplorer {
    public abstract class MatchesFilesList : StoredItemsList {
        private static string MATCHESFILEITEM_TYPE_NAME = "mfi";

        public static MatchesRecentFilesList Activate() {
            StoredObject list = new MatchesRecentFilesList().Load();
            if (null == list)
                throw new MatchesFilesException(MsgsBase.Res.The_matches_files_list_is_not_initialized);
            return (MatchesRecentFilesList) list;
        }

        protected override bool AddStringSafeSerializedPropertyObject(IList serializeList, object obj) {
            if (base.AddStringSafeSerializedPropertyObject(serializeList, obj))
                return true;
            if (!(obj is MatchesFileItem))
                return false;
            MatchesFileItem matchesFileItem = (MatchesFileItem) obj;
            serializeList.Add(BuildStringSafeSerializedFor(MATCHESFILEITEM_TYPE_NAME,
                                                           matchesFileItem.FullName,
                                                           matchesFileItem.Description,
                                                           matchesFileItem.LastSize,
                                                           matchesFileItem.LastUpdatedOn,
                                                           matchesFileItem.LastLoadedOn));
            return true;
        }

        protected override bool AddCustomObjectFromLine(StringCollection elementsList, string typeName) {
            if (!CheckElementsAreMatchFor(elementsList, typeName, MATCHESFILEITEM_TYPE_NAME, 5))
                return false;
            try {
                AddMatchesFileItem(elementsList);
            }
            catch (Exception ex) {
                Console.Write(ex);
            }
            return true;
        }

        private void AddMatchesFileItem(StringCollection elementsList) {
            MatchesFileItem item = new MatchesFileItem();
            item.FullName = elementsList[0];
            item.Description = elementsList[1];
            item.LastSize = Int64.Parse(elementsList[2]);
            item.LastUpdatedOn = DateTime.Parse(elementsList[3]);
            item.LastLoadedOn = DateTime.Parse(elementsList[4]);
            Items.Add(item);
        }
    }
}