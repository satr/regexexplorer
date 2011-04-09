using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using LicenseHelper;
using RegexExplorer.Controls;
using RegexExplorer;

namespace RegexExplorer {
    public class OpenFileForm : Form {
        private readonly MainController _mainController;

        #region Controls

        private Container components = null;
        private TabControl tabControl;
        private TabPage tabHistory;
        private ListView lvRecentFiles;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private Splitter splitter2;
        private MatchesFileItemControl matchesFileItemControl;
        private Splitter splitter1;
        private Panel panel1;
        private Button btnOpen;
        private Button btnBrowse;
        private Button btnCancel;
        private Button btnRemove;
        private Button btnClearAll;

        #endregion

        private OpenFileProcessForm _openFileProcessForm;
        private MatchesRecentFilesList _recentItemsList = null;
        private FileInfo _fileInfo;
        private RegexExplorer.UnregisteredInfoControl Label10;
        private StoredItemsController _controller;

        public enum ActiveList {
            Favorites,
            History,
        }

        public OpenFileForm(MainController mainController, ActiveList activeList) {
            _mainController = mainController;
            _recentItemsList = MatchesFilesList.Activate();
            InitializeComponent();

            InitController();
            InitControls();

            SelectTabBy(activeList);
            GuiObjectsCollection.ApplyActualLanguageFor(this);
            Bind();
            DisplayLicState();
        }

        private void DisplayLicState() {
            if ( /*<KeyKeyGeneratorCheck3>*/ LicenseController.IsRegistered /*</KeyKeyGeneratorCheck3>*/)
                Label10.HideIn(this);
        }

        private void Bind() {
            btnBrowse.Click += new EventHandler(Browse_Click);
            Label10.OnRegister += new RegexExplorerEventHandler(Label10_OnRegister);
        }

        private void SelectTabBy(ActiveList activeList) {
            if (activeList == ActiveList.History)
                _controller.FocusTab(tabHistory, Preferences.Res.ShowAllRegexPatternsTabs);
        }

        private void InitControls() {
            btnCancel.DialogResult = DialogResult.Cancel;
            this.AcceptButton = btnOpen;
            this.CancelButton = btnCancel;
        }

        private void InitController() {
            _controller = new StoredItemsController(tabControl, btnOpen, btnRemove, btnClearAll);
            _controller.InitTabControlFor(tabHistory, lvRecentFiles, _recentItemsList, new HistoryFilesListController());
            _controller.OnOpenItem += new RegexExplorerObjectEventHandler(Controller_OnOpenItem);
            _controller.OnSelectItem += new RegexExplorerObjectEventHandler(Controller_OnSelectItem);
            _controller.OnClearItem += new RegexExplorerEventHandler(matchesFileItemControl.Clear);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(OpenFileForm));
            this.Label10 = new RegexExplorer.UnregisteredInfoControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.lvRecentFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.matchesFileItemControl = new RegexExplorer.MatchesFileItemControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.Color.Yellow;
            this.Label10.Comment = "In the unregistered copy only 5 files are available in the lists.";
            this.Label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label10.Location = new System.Drawing.Point(0, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(736, 80);
            this.Label10.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabHistory);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 80);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(466, 326);
            this.tabControl.TabIndex = 8;
            this.tabControl.TabStop = false;
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.lvRecentFiles);
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(458, 300);
            this.tabHistory.TabIndex = 1;
            this.tabHistory.Text = "Recent";
            // 
            // lvRecentFiles
            // 
            this.lvRecentFiles.AllowColumnReorder = true;
            this.lvRecentFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                            this.columnHeader1,
                                                                                            this.columnHeader2});
            this.lvRecentFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRecentFiles.FullRowSelect = true;
            this.lvRecentFiles.GridLines = true;
            this.lvRecentFiles.Location = new System.Drawing.Point(0, 0);
            this.lvRecentFiles.MultiSelect = false;
            this.lvRecentFiles.Name = "lvRecentFiles";
            this.lvRecentFiles.Size = new System.Drawing.Size(458, 300);
            this.lvRecentFiles.TabIndex = 0;
            this.lvRecentFiles.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "File name";
            this.columnHeader1.Width = 280;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Loaded on";
            this.columnHeader2.Width = 151;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(466, 80);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 326);
            this.splitter2.TabIndex = 12;
            this.splitter2.TabStop = false;
            // 
            // matchesFileItemControl
            // 
            this.matchesFileItemControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.matchesFileItemControl.Location = new System.Drawing.Point(469, 80);
            this.matchesFileItemControl.Name = "matchesFileItemControl";
            this.matchesFileItemControl.Size = new System.Drawing.Size(264, 326);
            this.matchesFileItemControl.TabIndex = 11;
            this.matchesFileItemControl.TabStop = false;
            this.matchesFileItemControl.TitleText = "";
            this.matchesFileItemControl.Value = null;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(733, 80);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 326);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnClearAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 406);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(736, 40);
            this.panel1.TabIndex = 9;
            // 
            // btnOpen
            // 
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOpen.Location = new System.Drawing.Point(8, 8);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(64, 24);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBrowse.Location = new System.Drawing.Point(80, 8);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(64, 24);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(152, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemove.Location = new System.Drawing.Point(312, 8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(64, 24);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Remove";
            // 
            // btnClearAll
            // 
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClearAll.Location = new System.Drawing.Point(384, 8);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(80, 24);
            this.btnClearAll.TabIndex = 4;
            this.btnClearAll.Text = "Clear all";
            // 
            // OpenFileForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(736, 446);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.matchesFileItemControl);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Label10);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OpenFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open file";
            this.tabControl.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public void BrowseFiles() {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.RestoreDirectory = true;
            _controller.SetInitialOpenFileFolderFor(fileDialog, Preferences.Res.InitialListFolder);
            if (fileDialog.ShowDialog() != DialogResult.OK) return;
            MatchesFileItem fileItem = null;
            try {
                fileItem = new MatchesFileItem(fileDialog.FileName);
            }
            catch (RegexExplorerException ex) {
                Messenger.ShowError(MsgsBase.Res.Error_ocurred_while_open_a_file_N_Error_ex, ex, fileDialog.FileName);
            }
            catch (Exception ex) {
                Messenger.ShowError(MsgsBase.Res.Undefined_error_ex, ex);
            }
            _controller.AddToItemsListFor(fileItem, _recentItemsList, Preferences.Res.MaxRecentFilesQuantity);
            LoadTextFromFile(fileItem);
        }

        public void ClearLoadedText() {
            if (_openFileProcessForm == null)
                return;
            _openFileProcessForm.ClearLoadedText();
        }

        public string LoadedFileName() {
            if (_openFileProcessForm == null)
                return string.Empty;
            return _fileInfo.FullName;
        }

        public string LoadedText {
            get { return StrBuff.ToString(); }
        }

        private void Controller_OnSelectItem(object item) {
            matchesFileItemControl.Value = item;
        }

        private void Controller_OnOpenItem(object item) {
            LoadTextFromFile((MatchesFileItem) item);
        }

        private void Browse_Click(object sender, EventArgs e) {
            BrowseFiles();
        }

        private void LoadTextFromFile(MatchesFileItem item) {
            _fileInfo = new FileInfo(item.FullName);
            if (!_fileInfo.Exists) {
                Messenger.ShowError(MsgsBase.Res.FileNotExists);
                return;
            }

            StoreInitialOpenFileFolderFor(_fileInfo);
            _openFileProcessForm = new OpenFileProcessForm(_fileInfo.FullName);
            if (_fileInfo.Length > Preferences.Res.MinLengthOfFileToShowLoadingForm)
                _openFileProcessForm.ShowDialog();
            else
                _openFileProcessForm.load();
            if (_openFileProcessForm.DialogResult != DialogResult.OK)
                return;
            item.LastLoadedOn = DateTime.Now;
            this.DialogResult = _openFileProcessForm.DialogResult;
            Close();
        }

        private void StoreInitialOpenFileFolderFor(FileInfo fileInfo) {
            Preferences.Res.InitialOpenFileFolder = fileInfo.DirectoryName;
            Preferences.Res.Save();
        }

        private StringBuilder StrBuff {
            get { return (_openFileProcessForm != null) ? _openFileProcessForm.StrBuff : new StringBuilder(0); }
        }

        private void Label10_OnRegister() {
            _mainController.Register(this);
        }
    }
}