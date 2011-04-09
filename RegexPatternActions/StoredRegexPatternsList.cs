using System.Collections;
using System.Collections.Specialized;
using RegexExplorer;

namespace RegexExplorer {
    public abstract class StoredRegexPatternsList : StoredItemsList {
        private static string REGEXPATTERN_TYPE_NAME = "regexpattern";

        #region Serialisation

        protected override bool AddStringSafeSerializedPropertyObject(IList serializeList, object obj) {
            if (base.AddStringSafeSerializedPropertyObject(serializeList, obj))
                return true;
            if (!(obj is RegexPattern))
                return false;
            RegexPattern regexPattern = (RegexPattern) obj;
            serializeList.Add(
                BuildStringSafeSerializedFor(REGEXPATTERN_TYPE_NAME, regexPattern.Value, regexPattern.Description, regexPattern.Result));
            return true;
        }

        protected override bool AddCustomObjectFromLine(StringCollection elementsList, string typeName) {
            if (CheckElementsAreMatchFor(elementsList, typeName, REGEXPATTERN_TYPE_NAME, 2))
                Items.Add(new RegexPattern(elementsList[0], elementsList[1]));
            else if (CheckElementsAreMatchFor(elementsList, typeName, REGEXPATTERN_TYPE_NAME, 3))
                Items.Add(new RegexPattern(elementsList[0], elementsList[1], elementsList[2]));
            else 
                return false;
            return true;
        }

        #endregion
    }
}