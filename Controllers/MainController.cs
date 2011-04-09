using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LicenseHelper;
using RegexExplorer;

namespace RegexExplorer.Controls {
    public class MainController : BaseController {
        private object _actualController;
        private HelpProvider _helpProvider;

        public MainController(HelpProvider helpProvider, Bitmap image): base(image) {
            _helpProvider = helpProvider;
            Register(Preferences.Res.LicenseKey);
        }

        public object ActualController {
            get { return _actualController; }
            set { _actualController = value; }
        }

        public bool ActualControllerIsILoadList() {
            return _actualController != null && (_actualController as ILoadList) != null;
        }

        public bool ActualControllerIsISaveList() {
            return _actualController != null && (_actualController as ISaveList) != null;
        }

        public bool ActualControllerIsIEdit() {
            return _actualController != null && (_actualController as IEdit) != null;
        }

        public bool ActualControllerIsIOpenFile() {
            return _actualController != null && (_actualController as IOpenFile) != null;
        }

        public bool ActualControllerIsICheckClearEdit() {
            return _actualController != null && (_actualController as ICheckClearEdit) != null;
        }

        private bool ActualControllerIsIShowSelectedItems() {
            return _actualController != null && (_actualController as IShowSelectedItems) != null;
        }

        public void SaveList() {
            if (ActualControllerIsISaveList())
                ((ISaveList) _actualController).SaveList();
        }

        public void Copy() {
            if (ActualControllerIsIEdit())
                ((IEdit) _actualController).Copy();
        }

        public void Paste() {
            if (ActualControllerIsIEdit())
                ((IEdit) _actualController).Paste();
        }

        public void PasteList() {
            if (ActualControllerIsILoadList())
                ((ILoadList) _actualController).PasteList();
        }

        public void AppendList() {
            if (ActualControllerIsILoadList())
                ((ILoadList) _actualController).AppendList();
        }

        public void Cut() {
            if (ActualControllerIsIEdit())
                ((IEdit) _actualController).Cut();
        }

        public void OpenFile() {
            if (ActualControllerIsIOpenFile())
                ((IOpenFile) _actualController).OpenFile();
        }

        public void Clear() {
            if (ActualControllerIsICheckClearEdit())
                ((ICheckClearEdit) _actualController).Clear();
        }

        public void LoadList() {
            if (ActualControllerIsILoadList())
                ((ILoadList) _actualController).LoadList();
        }

        public void ShowSelectedItems() {
            if (ActualControllerIsIShowSelectedItems())
                ((IShowSelectedItems) _actualController).ShowSelectedItems();
        }

        public void ShowAllItems() {
            if (ActualControllerIsIShowSelectedItems())
                ((IShowSelectedItems) _actualController).ShowAllItems();
        }

        public void Check() {
            if (ActualControllerIsICheckClearEdit())
                ((ICheckClearEdit) _actualController).Check();
        }

        public void PasteSpecial() {
            SpecialSymbolsForm specialSymbolsForm = new SpecialSymbolsForm(this);
            SetHelpProviderFor(specialSymbolsForm, "Symbols");
            DialogResult result = specialSymbolsForm.ShowDialog();
            if (result != DialogResult.OK)
                return;
            string backupString = EditionHelper.paste();
            string symbol = specialSymbolsForm.specialSymbol;
            Clipboard.SetDataObject(Regex.Unescape(symbol));
            Paste();
            EditionHelper.copy(backupString);
        }

        public void SetHelpProviderFor(Control control, string keyword) {
            if (_helpProvider == null)
                return;
            _helpProvider.SetHelpNavigator(control, HelpNavigator.KeywordIndex);
            _helpProvider.SetHelpKeyword(control, keyword);
        }

        public void Register(Form sourceForm) {
            sourceForm.Hide();
            Register();
            sourceForm.Close();
        }

        public void Register() {
            GotKeyHandle handle = new GotKeyHandle(GotKey);
            OnGotKey += handle;
            try {
                RegisterOverForm();
            }
            catch (Exception ex) {
                Messenger.ShowError(MsgsBase.Res.Error_registering_N, ex);
            }
            finally {
                OnGotKey -= handle;
            }
        }

        private void GotKey(string key) {
            Preferences.Res.LicenseKey = key;
            Preferences.Res.Save();
            if ( /*<KeyKeyGeneratorCheck1>*/IsRegistered /*</KeyKeyGeneratorCheck1>*/)
                Messenger.ShowInfo(MsgsBase.Res.Successfully_registered_on_the_key_N, MsgsBase.Res.Registration, key);
            else
                Messenger.ShowInfo(MsgsBase.Res.Failed_registration_on_the_key_N, MsgsBase.Res.Registration, key);
        }

        public void CopyUniqueSymbols() {
            if (ActualControllerIsISaveList())
                ((ISaveList) _actualController).CopyUniqueSymbols();
        }

        public HelpProvider GetHelpProvider() {
            return _helpProvider;
        }
    }
}