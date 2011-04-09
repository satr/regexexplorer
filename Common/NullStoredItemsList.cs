using System.Collections.Specialized;
using RegexExplorer;

namespace RegexExplorer {
    public class NullStoredItemsList : StoredItemsList {
        public NullStoredItemsList() {
            InitFileNameBy("NullStoredItemsList");
        }

        public override StoredObject AddOrUpdate(object item) {
            return this;
        }

        public override int MaxItemsQuantity {
            get { return 0; }
        }

        protected override bool AddCustomObjectFromLine(StringCollection elementsList, string typeName) {
            return false;
        }
    }
}