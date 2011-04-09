using System.Windows.Forms;

namespace RegexExplorer {
    public class EditionHelper {
        public static void copy(string text, int selectionStart, int selectionLength) {
            copy(text.Substring(selectionStart, selectionLength));
        }

        public static void copy(string text) {
            text = text.Trim();
            if (text.Length == 0)
                return;
            Clipboard.SetDataObject(text, true);
        }

        public static string cut(string text, int selectionStart, int selectionLength) {
            copy(text, selectionStart, selectionLength);
            return text.Remove(selectionStart, selectionLength);
        }

        public static string paste(string text, int selectionStart, int selectionLength) {
            bool selectionPresented = selectionStart >= 0 && selectionLength > 0;
            if (selectionPresented)
                text = text.Remove(selectionStart, selectionLength);
            return text.Insert(selectionStart, paste());
        }

        public static string paste() {
            IDataObject dataObject = Clipboard.GetDataObject();
            if (!dataObject.GetDataPresent(typeof (string)))
                return "";
            return (string) dataObject.GetData(typeof (string));
        }

        public static void Insert(TextBox textBox, string text) {
            int selectionStart = textBox.SelectionStart;
            string currentText = textBox.Text;
            if (textBox.SelectionLength > 0)
                currentText = currentText.Remove(selectionStart, textBox.SelectionLength);
            textBox.Text = currentText.Insert(selectionStart, text);
            textBox.SelectionStart = selectionStart + text.Length;
        }

    }
}