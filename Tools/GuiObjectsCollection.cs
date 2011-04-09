using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RegexExplorer {
    public class GuiObjectsCollection : IDisposable {
        private static bool ADD_TEXT_PROPERTY_CONTENT = true;
        private static bool CONTROL_HAS_NOT_BEEN_ADDED = false;
        private static bool CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED = true;
        private static bool APPLAY_LANGUAGE = true;

        #region Fields

        private IList _forms;
        private IList _controls;
        private IList _toolTips;
        private IList _menuItems;
        private IList _listControls;
        private IList _domainUpDown;
        private IList _tabControls;
        private IList _tabPages;
        private IList _listViews;
        private IList _textBoxes;
        private IList _toolBars;
        private IList _statusBars;
        private IDictionary _textEntries;
        private Form _mainForm;

        #endregion

        private readonly Regex _textRegex = new Regex(@"[A-Za-z]", RegexOptions.IgnoreCase);

        public static void ApplyActualLanguageFor(Form form, params ToolTip[] toolTips) {
            using (GuiObjectsCollection guiObjectsCollection = new GuiObjectsCollection(form, toolTips))
                guiObjectsCollection.ApplyActualLanguage();
        }

        private GuiObjectsCollection(Form form, params ToolTip[] toolTips) : this(APPLAY_LANGUAGE, form, toolTips) {
        }

        private GuiObjectsCollection(bool applayLanguage, Form form, params ToolTip[] toolTips) {
            _mainForm = form;
            Init();
            try {
                AddFormFor(form, toolTips);
                if (applayLanguage)
                    ApplyActualLanguage();
            }
            catch (Exception ex) {
                Init();
                throw new LanguageException(LangBase.Res.ErrorWhileChangeGuiLanguage, ex);
            }
        }

        #region IDisposable members

        public void Dispose() {
            Init();
        }

        public void Close() {
            Dispose();
        }

        #endregion

        protected virtual bool AddObject(object obj) {
            if (obj is Splitter)
                return CONTROL_HAS_NOT_BEEN_ADDED;
            if (obj is StatusBar)
                return AddStatusBarFor(obj);
            if (obj is TabControl)
                return AddTabControlFor(obj);
            if (obj is ListView)
                return AddListViewFor(obj);
            if (obj is ListControl)
                return AddListControlFor(obj);
            if (obj is DomainUpDown)
                return AddDomainUpDownControlFor(obj);
            if (obj is TextBoxBase)
                return AddTextBoxBaseControlFor(obj);
            if (obj is ToolBar)
                return AddToolBarFor(obj);
            if (obj is Control)
                return AddControlFor(_controls, obj);
            return CONTROL_HAS_NOT_BEEN_ADDED;
        }

        private bool AddTextBoxBaseControlFor(object obj) {
            if (!AddControlFor(_textBoxes, obj, LangBase.AddTextBoxContent))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private bool AddToolBarFor(object obj) {
            if (!AddControlFor(_toolBars, obj))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            ToolBar toolBar = (ToolBar) obj;
            foreach (ToolBarButton button in toolBar.Buttons) {
                AddTextEntryFor(button.ToolTipText);
                AddTextEntryFor(button.Text);
            }
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private bool AddDomainUpDownControlFor(object obj) {
            if (!AddControlFor(_domainUpDown, obj, LangBase.AddDomainUpDownContent))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            if (LangBase.AddDomainUpDownContent) {
                DomainUpDown domainUpDown = (DomainUpDown) obj;
                foreach (object item in domainUpDown.Items) {
                    if (item != null)
                        AddTextEntryFor(item.ToString());
                }
            }
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private bool AddListViewFor(object obj) {
            if (!AddControlFor(_listViews, obj))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            ListView listView = (ListView) obj;
            foreach (ColumnHeader columnHeader in listView.Columns)
                AddTextEntryFor(columnHeader.Text);
            if (LangBase.AddListViewContent) {
                foreach (ListViewItem.ListViewSubItem subItem in ListViewSubitemsFor(listView))
                    AddTextEntryFor(subItem.Text);
            }
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private bool AddListControlFor(object obj) {
            if (!AddControlFor(_listControls, obj, LangBase.AddListControlContent))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            if (LangBase.AddListControlContent) {
                ListControl listControl = (ListControl) obj;
                IList items = ListControlItemsFor(listControl);
                if (items != null) {
                    foreach (object itemText in items) {
                        if (itemText != null)
                            AddTextEntryFor(itemText.ToString());
                    }
                }
            }
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private bool AddTabControlFor(object obj) {
            if (!AddControlFor(_tabControls, obj))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            TabControl tabControl = (TabControl) obj;
            foreach (TabPage tabPage in tabControl.TabPages) {
                AddControlFor(_tabPages, tabPage);
                AddTextEntryFor(tabPage.ToolTipText);
            }
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private bool AddStatusBarFor(object obj) {
            if (!AddControlFor(_statusBars, obj, LangBase.AddStatusBarContent))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            StatusBar statusBar = (StatusBar) obj;
            foreach (StatusBarPanel statusBarPanel in statusBar.Panels) {
                if (LangBase.AddStatusBarContent)
                    AddTextEntryFor(statusBarPanel.Text);
                AddTextEntryFor(statusBarPanel.ToolTipText);
            }
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private void AddTextEntryFor(string text) {
            if (text == null)
                return;
            text = text.Trim();
            if (_textRegex.IsMatch(text))
                _textEntries[text] = text;
        }

        private bool AddMainMenuFor(object obj) {
            return AddMenuItemFor(_menuItems, ((MainMenu) obj).MenuItems);
        }

        private void AddContextMenuFor(ContextMenu contextMenu) {
            AddMenuItemFor(_menuItems, contextMenu.MenuItems);
        }

        private bool AddMenuItemFor(IList list, IList menuItems) {
            bool result = CONTROL_HAS_NOT_BEEN_ADDED;
            foreach (MenuItem menuItem in menuItems) {
                AddTextEntryFor(menuItem.Text);
                if (AddObjectFor(list, menuItem))
                    result = CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
                if (AddMenuItemFor(list, menuItem.MenuItems))
                    result = CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
            }
            return result;
        }

        private bool AddObjectFor(IList list, object obj) {
            if (list.Contains(obj))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            list.Add(obj);
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private bool AddFormFor(Form form, params ToolTip[] toolTips) {
            foreach (ToolTip toolTip in toolTips)
                AddObjectFor(_toolTips, toolTip);
            if (!AddControlFor(_forms, form))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            if (form.Menu != null)
                AddMainMenuFor(form.Menu);
            AddControlsFor(form.Controls);
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private void AddControlsFor(IList list) {
            foreach (object obj in list)
                AddObject(obj);
        }

        private bool AddControlFor(IList list, object obj) {
            return AddControlFor(list, obj, ADD_TEXT_PROPERTY_CONTENT);
        }

        private bool AddControlFor(IList list, object obj, bool addTextPropertyContent) {
            if (!AddObjectFor(list, obj))
                return CONTROL_HAS_NOT_BEEN_ADDED;
            Control control = (Control) obj;
            if (addTextPropertyContent)
                AddTextEntryFor(control.Text);
            AddTextEntryByToolTipsFor(control);
            if (control.ContextMenu != null)
                AddContextMenuFor(control.ContextMenu);
            AddControlsFor(control.Controls);
            return CONTROL_HAS_BEEN_SUCCESSFULLY_ADDED;
        }

        private void AddTextEntryByToolTipsFor(Control control) {
            foreach (ToolTip toolTip in _toolTips)
                AddTextEntryFor(toolTip.GetToolTip(control));
        }

        private void Init() {
            _forms = new ArrayList();
            _controls = new ArrayList();
            _toolTips = new ArrayList();
            _menuItems = new ArrayList();
            _listControls = new ArrayList();
            _domainUpDown = new ArrayList();
            _tabControls = new ArrayList();
            _tabPages = new ArrayList();
            _listViews = new ArrayList();
            _textBoxes = new ArrayList();
            _toolBars = new ArrayList();
            _statusBars = new ArrayList();
            _textEntries = new Hashtable();
        }

        private void ApplyTextEntries(IDictionary textEntries) {
            if (textEntries == null)
                return;
            _textEntries = textEntries;
            _mainForm.SuspendLayout();
            _mainForm.Text = GetAssociatedTextFor(_mainForm.Text);
            ApplyFormTextPropertyFor(_forms);
            ApplyTextPropertyFor(_controls);
            ApplyMenuItemTextPropertyFor(_menuItems);
            ApplyListControlsTextPropertyFor(_listControls);
            ApplyDomainUpDownTextPropertyFor(_domainUpDown);
            ApplyTextPropertyFor(_tabControls);
            ApplyTabPagesTextPropertyFor(_tabPages);
            ApplyListViewsTextPropertyFor(_listViews);
            ApplyTextBoxBaseTextPropertyFor(_textBoxes);
            ApplyToolBarsTextPropertyFor(_toolBars);
            ApplyStatusBarsTextPropertyFor(_statusBars);
            _mainForm.ResumeLayout(false);
        }

        private void ApplyTextBoxBaseTextPropertyFor(IList list) {
            foreach (TextBoxBase textBoxBase in list) {
                ChangeToolTipsFor(textBoxBase);
                if (LangBase.AddTextBoxContent)
                    textBoxBase.Text = GetAssociatedTextFor(textBoxBase.Text);
            }
        }

        private string GetAssociatedTextFor(string text) {
            if (!_textEntries.Contains(text))
                return text;
            return (string) _textEntries[text];
        }

        private void ChangeToolTipsFor(Control control) {
            foreach (ToolTip toolTip in _toolTips) {
                string toolTipText = toolTip.GetToolTip(control);
                if (toolTipText.Length > 0)
                    toolTip.SetToolTip(control, GetAssociatedTextFor(toolTipText));
            }
        }

        private void ApplyToolBarsTextPropertyFor(IList list) {
            foreach (ToolBar toolBar in list) {
                foreach (ToolBarButton button in toolBar.Buttons) {
                    button.ToolTipText = GetAssociatedTextFor(button.ToolTipText);
                    button.Text = GetAssociatedTextFor(button.Text);
                }
            }
        }

        private void ApplyListViewsTextPropertyFor(IList list) {
            foreach (ListView listView in list) {
                ChangeToolTipsFor(listView);
                foreach (ColumnHeader columnHeader in listView.Columns)
                    columnHeader.Text = GetAssociatedTextFor(columnHeader.Text);
                if (LangBase.AddListViewContent) {
                    foreach (ListViewItem.ListViewSubItem subItem in ListViewSubitemsFor(listView))
                        subItem.Text = GetAssociatedTextFor(subItem.Text);
                }
            }
        }

        private void ApplyStatusBarsTextPropertyFor(IList list) {
            foreach (StatusBar statusBar in list) {
                ChangeToolTipsFor(statusBar);
                foreach (StatusBarPanel statusBarPanel in statusBar.Panels) {
                    statusBarPanel.ToolTipText = GetAssociatedTextFor(statusBarPanel.ToolTipText);
                    if (LangBase.AddListViewContent)
                        statusBarPanel.Text = GetAssociatedTextFor(statusBarPanel.Text);
                }
            }
        }

        private IList ListViewSubitemsFor(ListView listView) {
            IList subItems;
            subItems = new ArrayList(listView.Items.Count*listView.Columns.Count);
            foreach (ListViewItem item in listView.Items) {
                foreach (ListViewItem.ListViewSubItem listViewSubItem in item.SubItems)
                    subItems.Add(listViewSubItem);
            }
            return subItems;
        }

        private void ApplyDomainUpDownTextPropertyFor(IList list) {
            foreach (DomainUpDown domainUpDown in list) {
                domainUpDown.Text = GetAssociatedTextFor(domainUpDown.Text);
                ChangeToolTipsFor(domainUpDown);
                if (LangBase.AddDomainUpDownContent) {
                    for (int i = 0; i < domainUpDown.Items.Count; i++)
                        domainUpDown.Items[i] = GetAssociatedTextFor((string) domainUpDown.Items[i]);
                }
            }
        }

        private void ApplyTabPagesTextPropertyFor(IList list) {
            ApplyTextPropertyFor(list);
            foreach (TabPage tabPage in list) {
                tabPage.ToolTipText = GetAssociatedTextFor(tabPage.ToolTipText);
                ChangeToolTipsFor(tabPage);
            }
        }

        private void ApplyListControlsTextPropertyFor(IList list) {
            foreach (ListControl listControl in list) {
                listControl.Text = GetAssociatedTextFor(listControl.Text);
                ChangeToolTipsFor(listControl);
                if (LangBase.AddListControlContent) {
                    IList items = ListControlItemsFor(listControl);
                    if (items != null)
                        for (int i = 0; i < items.Count; i++) {
                            if (items[i] != null)
                                items[i] = GetAssociatedTextFor((string) (items[i].ToString()));
                        }
                }
            }
        }

        private static IList ListControlItemsFor(ListControl listControl) {
            if (listControl is ListBox)
                return ((ListBox) listControl).Items;
            else if (listControl is CheckedListBox)
                return ((CheckedListBox) listControl).Items;
            else if (listControl is ComboBox)
                return ((ComboBox) listControl).Items;
            return null;
        }

        private void ApplyFormTextPropertyFor(IList list) {
            foreach (Form form in list) {
                form.Text = GetAssociatedTextFor(form.Text);
                ChangeToolTipsFor(form);
            }
        }

        private void ApplyMenuItemTextPropertyFor(IList list) {
            foreach (MenuItem menuItem in list) {
                menuItem.Text = GetAssociatedTextFor(menuItem.Text);
            }
        }

        private void ApplyTextPropertyFor(IList list) {
            foreach (Control control in list) {
                control.Text = GetAssociatedTextFor(control.Text);
                ChangeToolTipsFor(control);
            }
        }

        private void ApplyActualLanguage() {
            try {
                if (LangBase.AddNewCaptionsToResource)
                    UpdateLanguageTextEntries();
                ApplyTextEntries(LangBase.SourceDict);
            }
            catch (Exception ex) {
                Init();
                throw new LanguageException(LangBase.Res.ErrorWhileChangeGuiLanguage, ex);
            }
        }

        private void UpdateLanguageTextEntries() {
            if (LangBase.CheckNewTextEntriesBy(_textEntries))
                LangBase.Res.Save();
        }

        public static void ChangeLanguageTo(string languageName, Form form, params ToolTip[] toolTips) {
            if (string.Compare(LangBase.CurrentLanguageName, languageName, true) == 0)
                return;
            if (!LangBase.IsDefault) {
                using (GuiObjectsCollection guiObjectsCollection = new GuiObjectsCollection(false, form, toolTips)) {
                    guiObjectsCollection.RestoreDefaultLanguage();
                }
            }
            using (GuiObjectsCollection guiObjectsCollection = new GuiObjectsCollection(false, form, toolTips)) {
                LangBase.Activate(languageName);
                guiObjectsCollection.ApplyActualLanguage();
            }
            PredefinedRegexPatternsList.ReActivate();
            RegexPatternsTipsList.ReActivate();
            PreferencesBase.Res.LastLanguageName = languageName;
        }

        private void RestoreDefaultLanguage() {
            LangBase.SetRestoreMode();
            ApplyTextEntries(LangBase.SourceDict);
            LangBase.SetNormalMode();
        }
    }
}