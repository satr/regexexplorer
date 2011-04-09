using System.Collections;
using System.Collections.Specialized;

namespace RegexExplorer {
    public abstract class StoredItemsList : StoredObject {
        public static int UNLIMITED_LIST_LENGTH_VALUE = 0;

        protected ArrayList _items = new ArrayList();

        public virtual StoredObject AddOrUpdate(object key, object item) {
            if (UpdateFor(key, item))
                return this;
            AddBase(item);
            return this;
        }

        public virtual StoredObject AddOrUpdate(object item) {
            return AddOrUpdate(item, item);
        }

        private bool UpdateFor(object key, object item) {
            if (!_items.Contains(key))
                return false;
            _items[_items.IndexOf(key)] = item;
            return true;
        }

        public virtual StoredObject Add(object item) {
            return AddBase(item);
        }

        protected StoredObject AddBase(object item) {
            while (MaxItemsQuantity > UNLIMITED_LIST_LENGTH_VALUE
                   && _items.Count >= MaxItemsQuantity
                   && _items.Count > 0)
                _items.RemoveAt(_items.Count - 1);
            _items.Insert(0, item);
            return this;
        }

        public virtual ArrayList Items {
            get { return _items; }
            set { _items = value; }
        }

        protected void Sort(IComparer comparer) {
            _items.Sort(comparer);
        }

        public virtual int MaxItemsQuantity {
            get { return UNLIMITED_LIST_LENGTH_VALUE; }
        }

        public virtual bool ReadOnly {
            get { return false; }
        }

        protected override IList SerializationLines {
            get {
                IList list = base.SerializationLines;
                foreach (object obj in _items) {
                    if (obj != null)
                        AddStringSafeSerializedPropertyObject(list, obj);
                }
                return list;
            }
        }

        protected override bool AddObjectFromLine(StringCollection elementsList, string typeName) {
            if (base.AddObjectFromLine(elementsList, typeName))
                return true;
            if (AddCustomObjectFromLine(elementsList, typeName))
                return true;
            return false;
        }

        protected bool CheckElementsAreMatchFor(StringCollection elementsList, string typeName, string customTypeName,
                                                int expectedElementsCount) {
            if (typeName.ToLower() != customTypeName
                || elementsList.Count != expectedElementsCount)
                return false;
            for (int i = 0; i < expectedElementsCount; i++) {
                if (elementsList[i] == null)
                    return false;
            }
            return true;
        }

        protected abstract bool AddCustomObjectFromLine(StringCollection elementsList, string typeName);
    }
}