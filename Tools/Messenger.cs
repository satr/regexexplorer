using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace RegexExplorer {
    public class Messenger {
        private static string EVENT_LOG_NAME = "Application";
        private static EventLog _ev = null;

        static Messenger() {
            string productName = Application.ProductName;
            if (productName.Length == 0)
                productName = Assembly.GetExecutingAssembly().FullName;
            InitEventLog(productName);
        }

        public static void InitEventLog(string sourceName) {
            bool sourceExists = false;
            try{
                sourceExists = EventLog.SourceExists(sourceName);
                if (!sourceExists)
                    EventLog.CreateEventSource(new EventSourceCreationData(sourceName, EVENT_LOG_NAME));
                _ev = new EventLog(EVENT_LOG_NAME, sourceName);
            }
            catch{
            }
        }

        public static void ShowError(string formattedMessage, params object[] args) {
            LogError(formattedMessage, args);
            MessageBox.Show(string.Format(formattedMessage, args), LangBase.Res.Error, MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public static void ShowError(string formattedMessage, Exception exception, params object[] args) {
            object[] newArgs = new object[args.Length + 1];
            newArgs[0] = InnerDescriptionMessagesFor(exception);
            args.CopyTo(newArgs, 1);
            ShowError(formattedMessage, newArgs);
        }

        public static void ShowError(string formattedMessage, Exception exception) {
            ShowError(formattedMessage, InnerDescriptionMessagesFor(exception));
        }

        public static void ShowError(Exception exception) {
            string innerDescriptionMessages = InnerDescriptionMessagesFor(exception);
            ShowError(innerDescriptionMessages);
        }

        public static void ShowInfo(string formattedMessage, params object[] args) {
            ShowInfo(formattedMessage, LangBase.Res.Info, args);
        }

        public static void ShowInfo(string formattedMessage, string caption) {
            ShowInfo(formattedMessage, caption, new object[0]);
        }

        public static void ShowInfo(string formattedMessage, string caption, params object[] args) {
            MessageBox.Show(string.Format(formattedMessage, args), caption, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        public static void ShowWarning(string formattedMessage, params object[] args) {
            MessageBox.Show(string.Format(formattedMessage, args), LangBase.Res.Warning, MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
        }

        public static bool Confirmation(string formattedMessage, params object[] args) {
            return Confirmed(string.Format(formattedMessage, args));
        }

        public static bool Confirmed(string msg) {
            return
                MessageBox.Show(msg, LangBase.Res.Confirmation, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button1) == DialogResult.Yes;
        }

        public static void LogWarning(string formattedMessage, params object[] args) {
            WriteToEventLog(formattedMessage, EventLogEntryType.Warning, args);
        }

        public static void LogWarning(string message) {
            WriteToEventLog(message, EventLogEntryType.Warning);
        }

        public static void LogError(string formattedMessage, params object[] args) {
            WriteToEventLog(formattedMessage, EventLogEntryType.Error, args);
        }

        public static void LogError(string message) {
            WriteToEventLog(message, EventLogEntryType.Error);
        }

        public static void LogError(Exception exception) {
            LogError(InnerDescriptionMessagesFor(exception));
        }

        public static void LogError(string formattedMessage, Exception exception) {
            LogError(formattedMessage, InnerDescriptionMessagesFor(exception));
        }

        public static void LogInfo(string formattedMessage, params object[] args) {
            WriteToEventLog(formattedMessage, EventLogEntryType.Information, args);
        }

        public static void LogInfo(string message) {
            WriteToEventLog(message, EventLogEntryType.Information);
        }

        private static void WriteToEventLog(string format, EventLogEntryType logEntryType, params object[] args) {
            WriteToEventLog(string.Format(format, args), logEntryType);
        }

        private static void WriteToEventLog(string message, EventLogEntryType logEntryType) {
            if (_ev != null)
                _ev.WriteEntry(message, logEntryType);
        }

        public static string InnerDescriptionMessagesFor(Exception innerException) {
            string msg = string.Empty;
            Exception ex = innerException;
            while (ex != null) {
                msg += string.Format("{0}{1}", Environment.NewLine, ex.Message);
                ex = ex.InnerException;
            }
            return msg;
        }
    }
}