using System.ComponentModel;
using System.Windows.Forms;
using LicenseHelper;
using RegexExplorer.Controls;
using RegexExplorer;

namespace RegexExplorer {
    public class StoredRegexPatternsForm : Form {
        #region Controls

        private Container components = null;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private TabControl tabControl;
        private TabPage tabFavorites;
        private ListView lvRecentPatterns;
        private TabPage tabHistory;
        private ListView lvHistory;
        private TabPage tabPredefined;
        private ListView lvPredefined;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Panel panel1;
        private Button btnOpen;
        private Button btnCancel;
        private Button btnRemove;
        private Button btnClearAll;
        private RegexPatternControl regexPatternControl;

        #endregion

        private RegexPattern _loadedRegexPattern = new RegexPattern();
        private StoredItemsController _controller;
        private FavoriteRegexPatternsList _favoriteItemsList = null;
        private HistoryRegexPatternsList _historyItemsList = null;
        private PredefinedRegexPatternsList _predefinedItemsList = null;
        private UnregisteredInfoControl Label19;
        private MainController _mainController;

        public enum ActiveList {
            Favorites,
            History,
            Predefined,
        }

        public StoredRegexPatternsForm(MainController mainController, ActiveList activeList) {
            _mainController = mainController;
            _favoriteItemsList = FavoriteRegexPatternsList.Activate();
            _historyItemsList = HistoryRegexPatternsList.Activate();
            _predefinedItemsList = PredefinedRegexPatternsList.Activate();

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
                Label19.HideIn(this);
        }

        private void Bind() {
            Label19.OnRegister += new RegexExplorerEventHandler(Label19_OnRegister);
        }

        private void SelectTabBy(ActiveList activeList) {
            if (activeList == ActiveList.Favorites)
                _controller.FocusTab(tabFavorites, Preferences.Res.ShowAllRegexPatternsTabs);
            else if (activeList == ActiveList.History)
                _controller.FocusTab(tabHistory, Preferences.Res.ShowAllRegexPatternsTabs);
            else if (activeList == ActiveList.Predefined)
                _controller.FocusTab(tabPredefined, Preferences.Res.ShowAllRegexPatternsTabs);
        }

        private void InitControls() {
            btnOpen.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            this.AcceptButton = btnOpen;
            this.CancelButton = btnCancel;
        }

        private void InitController() {
            _controller = new StoredItemsController(tabControl, btnOpen, btnRemove, btnClearAll);
            _controller.InitTabControlFor(tabFavorites, lvRecentPatterns, _favoriteItemsList,
                                          new FavoriteRegexPatternsListController());
            _controller.InitTabControlFor(tabHistory, lvHistory, _historyItemsList,
                                          new HistoryRegexPatternsListController());
            _controller.InitTabControlFor(tabPredefined, lvPredefined, _predefinedItemsList,
                                          new PredefinedRegexPatternsListController());
            _controller.OnOpenItem += new RegexExplorerObjectEventHandler(Controller_OnOpenItem);
            _controller.OnSelectItem += new RegexExplorerObjectEventHandler(Controller_OnSelectItem);
            _controller.OnClearItem += new RegexExplorerEventHandler(regexPatternControl.Clear);
        }

        private void Controller_OnSelectItem(object item) {
            regexPatternControl.Value = item;
        }

        private void Controller_OnOpenItem(object item) {
            _loadedRegexPattern = (RegexPattern) item;
            Close(DialogResult.OK);
        }

        private void Close(DialogResult result) {
            DialogResult = result;
            Close();
        }

        public RegexPattern LoadedRegexPattern {
            get { return _loadedRegexPattern; }
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Resources.ResourceManager resources =
                new System.Resources.ResourceManager(typeof (StoredRegexPatternsForm));
            this.Label19 = new RegexExplorer.UnregisteredInfoControl();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFavorites = new System.Windows.Forms.TabPage();
            this.lvRecentPatterns = new System.Windows.Forms.ListView();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.tabPredefined = new System.Windows.Forms.TabPage();
            this.lvPredefined = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.regexPatternControl = new RegexExplorer.Controls.RegexPatternControl();
            this.tabControl.SuspendLayout();
            this.tabFavorites.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.tabPredefined.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label19
            // 
            this.Label19.BackColor = System.Drawing.Color.Yellow;
            this.Label19.Comment = "In the unregistered copy only 5 patterns are available in the lists.";
            this.Label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label19.Location = new System.Drawing.Point(0, 0);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(608, 80);
            this.Label19.TabIndex = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Regex pattern";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Description";
            this.columnHeader3.Width = 260;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFavorites);
            this.tabControl.Controls.Add(this.tabHistory);
            this.tabControl.Controls.Add(this.tabPredefined);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 80);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(608, 230);
            this.tabControl.TabIndex = 3;
            this.tabControl.TabStop = false;
            // 
            // tabFavorites
            // 
            this.tabFavorites.Controls.Add(this.lvRecentPatterns);
            this.tabFavorites.Location = new System.Drawing.Point(4, 22);
            this.tabFavorites.Name = "tabFavorites";
            this.tabFavorites.Size = new System.Drawing.Size(600, 204);
            this.tabFavorites.TabIndex = 1;
            this.tabFavorites.Text = "Favorites";
            // 
            // lvRecentPatterns
            // 
            this.lvRecentPatterns.AllowColumnReorder = true;
            this.lvRecentPatterns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                               this.columnHeader1,
                                                                                               this.columnHeader3
                                                                                           });
            this.lvRecentPatterns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRecentPatterns.FullRowSelect = true;
            this.lvRecentPatterns.GridLines = true;
            this.lvRecentPatterns.HideSelection = false;
            this.lvRecentPatterns.Location = new System.Drawing.Point(0, 0);
            this.lvRecentPatterns.Name = "lvRecentPatterns";
            this.lvRecentPatterns.Size = new System.Drawing.Size(600, 204);
            this.lvRecentPatterns.TabIndex = 0;
            this.lvRecentPatterns.View = System.Windows.Forms.View.Details;
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.lvHistory);
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Size = new System.Drawing.Size(600, 244);
            this.tabHistory.TabIndex = 2;
            this.tabHistory.Text = "History";
            this.tabHistory.Visible = false;
            // 
            // lvHistory
            // 
            this.lvHistory.AllowColumnReorder = true;
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                        this.columnHeader2,
                                                                                        this.columnHeader5,
                                                                                        this.columnHeader4
                                                                                    });
            this.lvHistory.Cursor = System.Windows.Forms.Cursors.Default;
            this.lvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(0, 0);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(600, 244);
            this.lvHistory.TabIndex = 0;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Regex pattern";
            this.columnHeader2.Width = 352;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Created on";
            this.columnHeader5.Width = 116;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 105;
            // 
            // tabPredefined
            // 
            this.tabPredefined.Controls.Add(this.lvPredefined);
            this.tabPredefined.Location = new System.Drawing.Point(4, 22);
            this.tabPredefined.Name = "tabPredefined";
            this.tabPredefined.Size = new System.Drawing.Size(600, 244);
            this.tabPredefined.TabIndex = 3;
            this.tabPredefined.Text = "Predefined";
            this.tabPredefined.Visible = false;
            // 
            // lvPredefined
            // 
            this.lvPredefined.AllowColumnReorder = true;
            this.lvPredefined.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                           this.columnHeader6,
                                                                                           this.columnHeader7
                                                                                       });
            this.lvPredefined.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPredefined.FullRowSelect = true;
            this.lvPredefined.GridLines = true;
            this.lvPredefined.HideSelection = false;
            this.lvPredefined.Location = new System.Drawing.Point(0, 0);
            this.lvPredefined.Name = "lvPredefined";
            this.lvPredefined.Size = new System.Drawing.Size(600, 244);
            this.lvPredefined.TabIndex = 0;
            this.lvPredefined.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Regex pattern";
            this.columnHeader6.Width = 300;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Description";
            this.columnHeader7.Width = 260;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.btnClearAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 310);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(608, 40);
            this.panel1.TabIndex = 4;
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
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(80, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemove.Location = new System.Drawing.Point(448, 8);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(64, 24);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove";
            // 
            // btnClearAll
            // 
            this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClearAll.Location = new System.Drawing.Point(520, 8);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(80, 24);
            this.btnClearAll.TabIndex = 3;
            this.btnClearAll.Text = "Clear all";
            // 
            // regexPatternControl
            // 
            this.regexPatternControl.DescriptionIsVisible = true;
            this.regexPatternControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.regexPatternControl.Location = new System.Drawing.Point(0, 350);
            this.regexPatternControl.Name = "regexPatternControl";
            this.regexPatternControl.ReadOnlyDescription = true;
            this.regexPatternControl.ReadOnlyRegexPattern = true;
            this.regexPatternControl.ReadOnlyResult = true;
            this.regexPatternControl.RegexPatternFont =
                new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular,
                                        System.Drawing.GraphicsUnit.Point, ((System.Byte) (204)));
            this.regexPatternControl.ResultIsVisible = true;
            this.regexPatternControl.Size = new System.Drawing.Size(608, 112);
            this.regexPatternControl.TabIndex = 5;
            this.regexPatternControl.TabStop = false;
            // 
            // StoredRegexPatternsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(608, 462);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.regexPatternControl);
            this.Controls.Add(this.Label19);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "StoredRegexPatternsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Regex patterns";
            this.tabControl.ResumeLayout(false);
            this.tabFavorites.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            this.tabPredefined.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private void Label19_OnRegister() {
            _mainController.Register(this);
        }
    }
}