using System;

namespace LicenseHelper {
    public class LicenseKeyFileEventArgs : EventArgs {
        private bool _acceptFile = true;
        private string _comment = string.Empty;

        public bool AcceptFile {
            get { return _acceptFile; }
            set { _acceptFile = value; }
        }

        public string Comment {
            get { return _comment; }
            set { _comment = value; }
        }

        public void RefuseAcceptance(string format, params object[] args) {
            RefuseAcceptance(string.Format(format, args));
        }

        public void RefuseAcceptance(string comment) {
            _acceptFile = false;
            _comment = comment;
        }
    }
}