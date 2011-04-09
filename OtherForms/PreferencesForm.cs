using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using LicenseHelper;
using RegexExplorer.Controls;
using RegexExplorer;

namespace RegexExplorer {
    public class PreferencesForm : Form {
        private readonly MainController _mainController;

        #region Controls

        private Button btnSave;
        private Button btnCancel;
        private Panel pnlSaveCancelButtons;
        private TabControl tabControl;
        private TabPage tabMain;
        private CheckBox cbAdvancedPreferences;
        private GroupBox gbConfirmations;
        private CheckBox cbConfirmOnDeletion;
        private CheckBox cbConfirmOnExit;
        private GroupBox gbView;
        private CheckBox cbRegexOptions;
        private CheckBox cbHighlightResultsInList;
        private CheckBox cbToolBars;
        private TabPage tabAdvanced;
        private CheckBox cbShowAllModesTabs;
        private GroupBox gbOpenRegexPatternDialog;
        private CheckBox cbReplaceDuplicatesInHistory;
        private NumericUpDown numMaxRegexPatternHistory;
        private CheckBox cbShowAllTabPagesInRegexPatternsDialog;
        private GroupBox gbOpenFileDialog;
        private NumericUpDown numMaxRecentFiles;
        private CheckBox cbShowOpenFileDialog;
        private TabPage tabLanguage;
        private GroupBox gbAddContent;
        private CheckBox cbListView;
        private CheckBox cbStatusBar;
        private CheckBox cbListControl;
        private CheckBox cbDomainUpDown;
        private CheckBox cbTextBox;
        private CheckBox cbAddNewCaptionsToResources;
        private Label lblRecentFiles;
        private NumericUpDown numMaxRegexPatternFavorites;
        private Label lblPatternsInHistory;
        private Label lblPatternsInFavorites;
        private RegexExplorer.UnregisteredInfoControl Label7;

        private Container components = null;

        #endregion

        public PreferencesForm(MainController mainController) {
            _mainController = mainController;
            InitializeComponent();
            InitFor(Preferences.Res);
            InitControls();
            GuiObjectsCollection.ApplyActualLanguageFor(this);
            InitAdvancedTabs();
            Bind();
            DisplayLicState();
        }

        private void DisplayLicState() {
            bool isReg = /*<KeyKeyGeneratorCheck1>*/ LicenseController.IsRegistered /*</KeyKeyGeneratorCheck1>*/;
            numMaxRecentFiles.ReadOnly = numMaxRegexPatternHistory.ReadOnly = !isReg;
                cbShowAllTabPagesInRegexPatternsDialog.Enabled
                  = cbShowOpenFileDialog.Enabled
                    = lblPatternsInHistory.Enabled
                      = lblPatternsInFavorites.Enabled
                        = lblRecentFiles.Enabled
                          = numMaxRecentFiles.Enabled
                            = numMaxRegexPatternHistory.Enabled
                              = numMaxRegexPatternFavorites.Enabled
                                = isReg;

            if (isReg)
                Label7.HideIn(this);
        }

        private void InitControls() {
            btnSave.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            InitAddLanguageContentControls();
        }

        private void Bind() {
            cbAdvancedPreferences.Click += new EventHandler(cbAdvancedPreferences_Click);
            cbAddNewCaptionsToResources.CheckedChanged += new EventHandler(cbAddNewCaptionsToResources_CheckedChanged);
            Label7.OnRegister += new RegexExplorerEventHandler(Label7_OnRegister);
        }

        private void InitFor(Preferences prefs) {
            cbToolBars.Checked = prefs.ToolBars;
            cbRegexOptions.Checked = prefs.RegexOptions;
            cbHighlightResultsInList.Checked = prefs.HighlightResultsInList;
            cbShowOpenFileDialog.Checked = prefs.ShowOpenFileDialog;
            cbConfirmOnExit.Checked = prefs.ConfimOnExit;
            cbConfirmOnDeletion.Checked = prefs.ConfimOnDeletion;
            numMaxRecentFiles.Value = prefs.MaxRecentFilesQuantity;
            numMaxRegexPatternHistory.Value = prefs.MaxRegexPatternHistoryLength;
            numMaxRegexPatternFavorites.Value = prefs.MaxRegexPatternFavoritesLength;
            cbAdvancedPreferences.Checked = prefs.AdvancedPreferences;
            cbReplaceDuplicatesInHistory.Checked = prefs.ReplaceDoublicatedPatternsInHistory;
            cbShowAllTabPagesInRegexPatternsDialog.Checked = prefs.ShowAllRegexPatternsTabs;
            cbShowAllModesTabs.Checked = prefs.ShowAllModesTabs;
            cbAddNewCaptionsToResources.Checked = prefs.AddNewCaptionsToResource;
            cbTextBox.Checked = LangBase.AddTextBoxContent;
            cbListControl.Checked = LangBase.AddListControlContent;
            cbListView.Checked = LangBase.AddListViewContent;
            cbStatusBar.Checked = LangBase.AddStatusBarContent;
            cbDomainUpDown.Checked = LangBase.AddDomainUpDownContent;
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void ApplayTo(Preferences prefs) {
            prefs.ToolBars = cbToolBars.Checked;
            prefs.RegexOptions = cbRegexOptions.Checked;
            prefs.HighlightResultsInList = cbHighlightResultsInList.Checked;
            prefs.ShowOpenFileDialog = cbShowOpenFileDialog.Checked;
            prefs.ConfimOnExit = cbConfirmOnExit.Checked;
            prefs.ConfimOnDeletion = cbConfirmOnDeletion.Checked;
            prefs.MaxRecentFilesQuantity = (int) numMaxRecentFiles.Value;
            prefs.MaxRegexPatternHistoryLength = (int) numMaxRegexPatternHistory.Value;
            prefs.MaxRegexPatternFavoritesLength = (int) numMaxRegexPatternFavorites.Value;
            prefs.AdvancedPreferences = cbAdvancedPreferences.Checked;
            prefs.ReplaceDoublicatedPatternsInHistory = cbReplaceDuplicatesInHistory.Checked;
            prefs.ShowAllRegexPatternsTabs = cbShowAllTabPagesInRegexPatternsDialog.Checked;
            prefs.ShowAllModesTabs = cbShowAllModesTabs.Checked;
            LangBase.AddNewCaptionsToResource = cbAddNewCaptionsToResources.Checked;
            LangBase.AddTextBoxContent = cbTextBox.Checked;
            LangBase.AddListControlContent = cbListControl.Checked;
            LangBase.AddListViewContent = cbListView.Checked;
            LangBase.AddStatusBarContent = cbStatusBar.Checked;
            LangBase.AddDomainUpDownContent = cbDomainUpDown.Checked;
            prefs.Save();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(PreferencesForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlSaveCancelButtons = new System.Windows.Forms.Panel();
            this.Label7 = new RegexExplorer.UnregisteredInfoControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.cbAdvancedPreferences = new System.Windows.Forms.CheckBox();
            this.gbConfirmations = new System.Windows.Forms.GroupBox();
            this.cbConfirmOnDeletion = new System.Windows.Forms.CheckBox();
            this.cbConfirmOnExit = new System.Windows.Forms.CheckBox();
            this.gbView = new System.Windows.Forms.GroupBox();
            this.cbRegexOptions = new System.Windows.Forms.CheckBox();
            this.cbHighlightResultsInList = new System.Windows.Forms.CheckBox();
            this.cbToolBars = new System.Windows.Forms.CheckBox();
            this.tabAdvanced = new System.Windows.Forms.TabPage();
            this.cbShowAllModesTabs = new System.Windows.Forms.CheckBox();
            this.gbOpenRegexPatternDialog = new System.Windows.Forms.GroupBox();
            this.cbReplaceDuplicatesInHistory = new System.Windows.Forms.CheckBox();
            this.numMaxRegexPatternHistory = new System.Windows.Forms.NumericUpDown();
            this.cbShowAllTabPagesInRegexPatternsDialog = new System.Windows.Forms.CheckBox();
            this.lblPatternsInHistory = new System.Windows.Forms.Label();
            this.lblPatternsInFavorites = new System.Windows.Forms.Label();
            this.numMaxRegexPatternFavorites = new System.Windows.Forms.NumericUpDown();
            this.gbOpenFileDialog = new System.Windows.Forms.GroupBox();
            this.numMaxRecentFiles = new System.Windows.Forms.NumericUpDown();
            this.cbShowOpenFileDialog = new System.Windows.Forms.CheckBox();
            this.lblRecentFiles = new System.Windows.Forms.Label();
            this.tabLanguage = new System.Windows.Forms.TabPage();
            this.gbAddContent = new System.Windows.Forms.GroupBox();
            this.cbListView = new System.Windows.Forms.CheckBox();
            this.cbStatusBar = new System.Windows.Forms.CheckBox();
            this.cbListControl = new System.Windows.Forms.CheckBox();
            this.cbDomainUpDown = new System.Windows.Forms.CheckBox();
            this.cbTextBox = new System.Windows.Forms.CheckBox();
            this.cbAddNewCaptionsToResources = new System.Windows.Forms.CheckBox();
            this.pnlSaveCancelButtons.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.gbConfirmations.SuspendLayout();
            this.gbView.SuspendLayout();
            this.tabAdvanced.SuspendLayout();
            this.gbOpenRegexPatternDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRegexPatternHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRegexPatternFavorites)).BeginInit();
            this.gbOpenFileDialog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRecentFiles)).BeginInit();
            this.tabLanguage.SuspendLayout();
            this.gbAddContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(8, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 24);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
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
            // pnlSaveCancelButtons
            // 
            this.pnlSaveCancelButtons.Controls.Add(this.btnSave);
            this.pnlSaveCancelButtons.Controls.Add(this.btnCancel);
            this.pnlSaveCancelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSaveCancelButtons.Location = new System.Drawing.Point(0, 374);
            this.pnlSaveCancelButtons.Name = "pnlSaveCancelButtons";
            this.pnlSaveCancelButtons.Size = new System.Drawing.Size(256, 40);
            this.pnlSaveCancelButtons.TabIndex = 1;
            // 
            // Label7
            // 
            this.Label7.BackColor = System.Drawing.Color.Yellow;
            this.Label7.Comment = "In the registered copy advanced futures are available.";
            this.Label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.Label7.Location = new System.Drawing.Point(0, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(256, 80);
            this.Label7.TabIndex = 2;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabAdvanced);
            this.tabControl.Controls.Add(this.tabLanguage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 80);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(256, 280);
            this.tabControl.TabIndex = 3;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.cbAdvancedPreferences);
            this.tabMain.Controls.Add(this.gbConfirmations);
            this.tabMain.Controls.Add(this.gbView);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(248, 254);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            // 
            // cbAdvancedPreferences
            // 
            this.cbAdvancedPreferences.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbAdvancedPreferences.Location = new System.Drawing.Point(8, 224);
            this.cbAdvancedPreferences.Name = "cbAdvancedPreferences";
            this.cbAdvancedPreferences.Size = new System.Drawing.Size(232, 24);
            this.cbAdvancedPreferences.TabIndex = 2;
            this.cbAdvancedPreferences.Text = "Advanced preferences";
            // 
            // gbConfirmations
            // 
            this.gbConfirmations.Controls.Add(this.cbConfirmOnDeletion);
            this.gbConfirmations.Controls.Add(this.cbConfirmOnExit);
            this.gbConfirmations.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbConfirmations.Location = new System.Drawing.Point(0, 104);
            this.gbConfirmations.Name = "gbConfirmations";
            this.gbConfirmations.Size = new System.Drawing.Size(248, 72);
            this.gbConfirmations.TabIndex = 1;
            this.gbConfirmations.TabStop = false;
            this.gbConfirmations.Text = "Confirmations";
            // 
            // cbConfirmOnDeletion
            // 
            this.cbConfirmOnDeletion.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbConfirmOnDeletion.Location = new System.Drawing.Point(8, 16);
            this.cbConfirmOnDeletion.Name = "cbConfirmOnDeletion";
            this.cbConfirmOnDeletion.Size = new System.Drawing.Size(232, 24);
            this.cbConfirmOnDeletion.TabIndex = 0;
            this.cbConfirmOnDeletion.Text = "Confirm on deletion";
            // 
            // cbConfirmOnExit
            // 
            this.cbConfirmOnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbConfirmOnExit.Location = new System.Drawing.Point(8, 40);
            this.cbConfirmOnExit.Name = "cbConfirmOnExit";
            this.cbConfirmOnExit.Size = new System.Drawing.Size(232, 24);
            this.cbConfirmOnExit.TabIndex = 1;
            this.cbConfirmOnExit.Text = "Confirm on exit";
            // 
            // gbView
            // 
            this.gbView.Controls.Add(this.cbRegexOptions);
            this.gbView.Controls.Add(this.cbHighlightResultsInList);
            this.gbView.Controls.Add(this.cbToolBars);
            this.gbView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbView.Location = new System.Drawing.Point(0, 0);
            this.gbView.Name = "gbView";
            this.gbView.Size = new System.Drawing.Size(248, 96);
            this.gbView.TabIndex = 0;
            this.gbView.TabStop = false;
            this.gbView.Text = "View";
            // 
            // cbRegexOptions
            // 
            this.cbRegexOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbRegexOptions.Location = new System.Drawing.Point(8, 40);
            this.cbRegexOptions.Name = "cbRegexOptions";
            this.cbRegexOptions.Size = new System.Drawing.Size(232, 24);
            this.cbRegexOptions.TabIndex = 1;
            this.cbRegexOptions.Text = "Regex options";
            // 
            // cbHighlightResultsInList
            // 
            this.cbHighlightResultsInList.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbHighlightResultsInList.Location = new System.Drawing.Point(8, 64);
            this.cbHighlightResultsInList.Name = "cbHighlightResultsInList";
            this.cbHighlightResultsInList.Size = new System.Drawing.Size(232, 24);
            this.cbHighlightResultsInList.TabIndex = 2;
            this.cbHighlightResultsInList.Text = "Colors in target list";
            // 
            // cbToolBars
            // 
            this.cbToolBars.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbToolBars.Location = new System.Drawing.Point(8, 16);
            this.cbToolBars.Name = "cbToolBars";
            this.cbToolBars.Size = new System.Drawing.Size(232, 24);
            this.cbToolBars.TabIndex = 0;
            this.cbToolBars.Text = "Toolbars";
            // 
            // tabAdvanced
            // 
            this.tabAdvanced.Controls.Add(this.cbShowAllModesTabs);
            this.tabAdvanced.Controls.Add(this.gbOpenRegexPatternDialog);
            this.tabAdvanced.Controls.Add(this.gbOpenFileDialog);
            this.tabAdvanced.Location = new System.Drawing.Point(4, 22);
            this.tabAdvanced.Name = "tabAdvanced";
            this.tabAdvanced.Size = new System.Drawing.Size(248, 254);
            this.tabAdvanced.TabIndex = 1;
            this.tabAdvanced.Text = "Advanced";
            this.tabAdvanced.Visible = false;
            // 
            // cbShowAllModesTabs
            // 
            this.cbShowAllModesTabs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbShowAllModesTabs.Location = new System.Drawing.Point(8, 228);
            this.cbShowAllModesTabs.Name = "cbShowAllModesTabs";
            this.cbShowAllModesTabs.Size = new System.Drawing.Size(232, 16);
            this.cbShowAllModesTabs.TabIndex = 2;
            this.cbShowAllModesTabs.Text = "Show all modes tab pages";
            // 
            // gbOpenRegexPatternDialog
            // 
            this.gbOpenRegexPatternDialog.Controls.Add(this.cbReplaceDuplicatesInHistory);
            this.gbOpenRegexPatternDialog.Controls.Add(this.numMaxRegexPatternHistory);
            this.gbOpenRegexPatternDialog.Controls.Add(this.cbShowAllTabPagesInRegexPatternsDialog);
            this.gbOpenRegexPatternDialog.Controls.Add(this.lblPatternsInHistory);
            this.gbOpenRegexPatternDialog.Controls.Add(this.lblPatternsInFavorites);
            this.gbOpenRegexPatternDialog.Controls.Add(this.numMaxRegexPatternFavorites);
            this.gbOpenRegexPatternDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbOpenRegexPatternDialog.Location = new System.Drawing.Point(0, 80);
            this.gbOpenRegexPatternDialog.Name = "gbOpenRegexPatternDialog";
            this.gbOpenRegexPatternDialog.Size = new System.Drawing.Size(248, 128);
            this.gbOpenRegexPatternDialog.TabIndex = 1;
            this.gbOpenRegexPatternDialog.TabStop = false;
            this.gbOpenRegexPatternDialog.Text = "Open regex pattern dialog";
            // 
            // cbReplaceDuplicatesInHistory
            // 
            this.cbReplaceDuplicatesInHistory.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbReplaceDuplicatesInHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.cbReplaceDuplicatesInHistory.Location = new System.Drawing.Point(8, 48);
            this.cbReplaceDuplicatesInHistory.Name = "cbReplaceDuplicatesInHistory";
            this.cbReplaceDuplicatesInHistory.Size = new System.Drawing.Size(232, 16);
            this.cbReplaceDuplicatesInHistory.TabIndex = 1;
            this.cbReplaceDuplicatesInHistory.Text = "Replace duplicates in history";
            // 
            // numMaxRegexPatternHistory
            // 
            this.numMaxRegexPatternHistory.Location = new System.Drawing.Point(8, 72);
            this.numMaxRegexPatternHistory.Maximum = new System.Decimal(new int[] {
                                                                                      50,
                                                                                      0,
                                                                                      0,
                                                                                      0});
            this.numMaxRegexPatternHistory.Name = "numMaxRegexPatternHistory";
            this.numMaxRegexPatternHistory.ReadOnly = true;
            this.numMaxRegexPatternHistory.Size = new System.Drawing.Size(40, 20);
            this.numMaxRegexPatternHistory.TabIndex = 2;
            // 
            // cbShowAllTabPagesInRegexPatternsDialog
            // 
            this.cbShowAllTabPagesInRegexPatternsDialog.Enabled = false;
            this.cbShowAllTabPagesInRegexPatternsDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbShowAllTabPagesInRegexPatternsDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.cbShowAllTabPagesInRegexPatternsDialog.Location = new System.Drawing.Point(8, 24);
            this.cbShowAllTabPagesInRegexPatternsDialog.Name = "cbShowAllTabPagesInRegexPatternsDialog";
            this.cbShowAllTabPagesInRegexPatternsDialog.Size = new System.Drawing.Size(232, 16);
            this.cbShowAllTabPagesInRegexPatternsDialog.TabIndex = 0;
            this.cbShowAllTabPagesInRegexPatternsDialog.Text = "Show all tab pages";
            // 
            // lblPatternsInHistory
            // 
            this.lblPatternsInHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.lblPatternsInHistory.Location = new System.Drawing.Point(48, 72);
            this.lblPatternsInHistory.Name = "lblPatternsInHistory";
            this.lblPatternsInHistory.Size = new System.Drawing.Size(192, 16);
            this.lblPatternsInHistory.TabIndex = 3;
            this.lblPatternsInHistory.Text = "patterns in history";
            this.lblPatternsInHistory.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblPatternsInFavorites
            // 
            this.lblPatternsInFavorites.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.lblPatternsInFavorites.Location = new System.Drawing.Point(48, 104);
            this.lblPatternsInFavorites.Name = "lblPatternsInFavorites";
            this.lblPatternsInFavorites.Size = new System.Drawing.Size(192, 16);
            this.lblPatternsInFavorites.TabIndex = 3;
            this.lblPatternsInFavorites.Text = "patterns in favorites";
            this.lblPatternsInFavorites.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // numMaxRegexPatternFavorites
            // 
            this.numMaxRegexPatternFavorites.Location = new System.Drawing.Point(8, 104);
            this.numMaxRegexPatternFavorites.Maximum = new System.Decimal(new int[] {
                                                                                        50,
                                                                                        0,
                                                                                        0,
                                                                                        0});
            this.numMaxRegexPatternFavorites.Name = "numMaxRegexPatternFavorites";
            this.numMaxRegexPatternFavorites.ReadOnly = true;
            this.numMaxRegexPatternFavorites.Size = new System.Drawing.Size(40, 20);
            this.numMaxRegexPatternFavorites.TabIndex = 2;
            // 
            // gbOpenFileDialog
            // 
            this.gbOpenFileDialog.Controls.Add(this.numMaxRecentFiles);
            this.gbOpenFileDialog.Controls.Add(this.cbShowOpenFileDialog);
            this.gbOpenFileDialog.Controls.Add(this.lblRecentFiles);
            this.gbOpenFileDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbOpenFileDialog.Location = new System.Drawing.Point(0, 0);
            this.gbOpenFileDialog.Name = "gbOpenFileDialog";
            this.gbOpenFileDialog.Size = new System.Drawing.Size(248, 72);
            this.gbOpenFileDialog.TabIndex = 0;
            this.gbOpenFileDialog.TabStop = false;
            this.gbOpenFileDialog.Text = "Open file dialog";
            // 
            // numMaxRecentFiles
            // 
            this.numMaxRecentFiles.Location = new System.Drawing.Point(8, 40);
            this.numMaxRecentFiles.Maximum = new System.Decimal(new int[] {
                                                                              20,
                                                                              0,
                                                                              0,
                                                                              0});
            this.numMaxRecentFiles.Name = "numMaxRecentFiles";
            this.numMaxRecentFiles.ReadOnly = true;
            this.numMaxRecentFiles.Size = new System.Drawing.Size(40, 20);
            this.numMaxRecentFiles.TabIndex = 1;
            // 
            // cbShowOpenFileDialog
            // 
            this.cbShowOpenFileDialog.Enabled = false;
            this.cbShowOpenFileDialog.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbShowOpenFileDialog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.cbShowOpenFileDialog.Location = new System.Drawing.Point(8, 16);
            this.cbShowOpenFileDialog.Name = "cbShowOpenFileDialog";
            this.cbShowOpenFileDialog.Size = new System.Drawing.Size(232, 24);
            this.cbShowOpenFileDialog.TabIndex = 0;
            this.cbShowOpenFileDialog.Text = "Show open file dialog";
            // 
            // lblRecentFiles
            // 
            this.lblRecentFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));
            this.lblRecentFiles.Location = new System.Drawing.Point(48, 40);
            this.lblRecentFiles.Name = "lblRecentFiles";
            this.lblRecentFiles.Size = new System.Drawing.Size(192, 16);
            this.lblRecentFiles.TabIndex = 3;
            this.lblRecentFiles.Text = "recent files";
            this.lblRecentFiles.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tabLanguage
            // 
            this.tabLanguage.Controls.Add(this.gbAddContent);
            this.tabLanguage.Controls.Add(this.cbAddNewCaptionsToResources);
            this.tabLanguage.Location = new System.Drawing.Point(4, 22);
            this.tabLanguage.Name = "tabLanguage";
            this.tabLanguage.Size = new System.Drawing.Size(248, 254);
            this.tabLanguage.TabIndex = 2;
            this.tabLanguage.Text = "Language";
            this.tabLanguage.Visible = false;
            // 
            // gbAddContent
            // 
            this.gbAddContent.Controls.Add(this.cbListView);
            this.gbAddContent.Controls.Add(this.cbStatusBar);
            this.gbAddContent.Controls.Add(this.cbListControl);
            this.gbAddContent.Controls.Add(this.cbDomainUpDown);
            this.gbAddContent.Controls.Add(this.cbTextBox);
            this.gbAddContent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbAddContent.Location = new System.Drawing.Point(0, 48);
            this.gbAddContent.Name = "gbAddContent";
            this.gbAddContent.Size = new System.Drawing.Size(248, 144);
            this.gbAddContent.TabIndex = 5;
            this.gbAddContent.TabStop = false;
            this.gbAddContent.Text = "Add content from controls";
            this.gbAddContent.Visible = false;
            // 
            // cbListView
            // 
            this.cbListView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbListView.Location = new System.Drawing.Point(8, 64);
            this.cbListView.Name = "cbListView";
            this.cbListView.Size = new System.Drawing.Size(232, 24);
            this.cbListView.TabIndex = 1;
            this.cbListView.Text = "ListView";
            // 
            // cbStatusBar
            // 
            this.cbStatusBar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbStatusBar.Location = new System.Drawing.Point(8, 88);
            this.cbStatusBar.Name = "cbStatusBar";
            this.cbStatusBar.Size = new System.Drawing.Size(232, 24);
            this.cbStatusBar.TabIndex = 2;
            this.cbStatusBar.Text = "StatusBar";
            // 
            // cbListControl
            // 
            this.cbListControl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbListControl.Location = new System.Drawing.Point(8, 40);
            this.cbListControl.Name = "cbListControl";
            this.cbListControl.Size = new System.Drawing.Size(232, 24);
            this.cbListControl.TabIndex = 0;
            this.cbListControl.Text = "ListControl (ListBox, ComboBox, etc.)";
            // 
            // cbDomainUpDown
            // 
            this.cbDomainUpDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbDomainUpDown.Location = new System.Drawing.Point(8, 112);
            this.cbDomainUpDown.Name = "cbDomainUpDown";
            this.cbDomainUpDown.Size = new System.Drawing.Size(232, 24);
            this.cbDomainUpDown.TabIndex = 2;
            this.cbDomainUpDown.Text = "DomainUpDown";
            // 
            // cbTextBox
            // 
            this.cbTextBox.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbTextBox.Location = new System.Drawing.Point(8, 16);
            this.cbTextBox.Name = "cbTextBox";
            this.cbTextBox.Size = new System.Drawing.Size(232, 24);
            this.cbTextBox.TabIndex = 0;
            this.cbTextBox.Text = "TextBox";
            // 
            // cbAddNewCaptionsToResources
            // 
            this.cbAddNewCaptionsToResources.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cbAddNewCaptionsToResources.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbAddNewCaptionsToResources.Location = new System.Drawing.Point(8, 8);
            this.cbAddNewCaptionsToResources.Name = "cbAddNewCaptionsToResources";
            this.cbAddNewCaptionsToResources.Size = new System.Drawing.Size(232, 32);
            this.cbAddNewCaptionsToResources.TabIndex = 4;
            this.cbAddNewCaptionsToResources.Text = "Add new GUI captions to the language resources";
            this.cbAddNewCaptionsToResources.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // PreferencesForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(256, 414);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.pnlSaveCancelButtons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PreferencesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.pnlSaveCancelButtons.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.gbConfirmations.ResumeLayout(false);
            this.gbView.ResumeLayout(false);
            this.tabAdvanced.ResumeLayout(false);
            this.gbOpenRegexPatternDialog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRegexPatternHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRegexPatternFavorites)).EndInit();
            this.gbOpenFileDialog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMaxRecentFiles)).EndInit();
            this.tabLanguage.ResumeLayout(false);
            this.gbAddContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        new private void Refresh() {
            numMaxRecentFiles.Enabled = cbShowOpenFileDialog.Checked;
        }

        private void cbAdvancedPreferences_Click(object sender, EventArgs e) {
            InitAdvancedTabs();
        }

        private void InitAdvancedTabs() {
            if (cbAdvancedPreferences.Checked)
                AddAdvancedTabs();
            else
                RemoveAdvancedTabs();
        }

        private void RemoveAdvancedTabs() {
            RemoveAdvancedTabFor(tabAdvanced);
            RemoveAdvancedTabFor(tabLanguage);
        }

        private void RemoveAdvancedTabFor(TabPage tabPage) {
            if (tabControl.TabPages.Contains(tabPage))
                tabControl.TabPages.Remove(tabPage);
        }

        private void AddAdvancedTabs() {
            AddAdvancedTabFor(tabAdvanced);
            AddAdvancedTabFor(tabLanguage);
        }

        private void AddAdvancedTabFor(TabPage tabPage) {
            if (!tabControl.TabPages.Contains(tabPage))
                tabControl.TabPages.Add(tabPage);
        }

        private void cbAddNewCaptionsToResources_CheckedChanged(object sender, EventArgs e) {
            if (cbAddNewCaptionsToResources.Checked)
                LangBase.Res.Save();
            InitAddLanguageContentControls();
        }

        private void InitAddLanguageContentControls() {
            cbTextBox.Enabled =
                cbListControl.Enabled =
                cbListView.Enabled = cbStatusBar.Enabled = cbDomainUpDown.Enabled = cbAddNewCaptionsToResources.Checked;
        }

        private void Label7_OnRegister() {
            _mainController.Register(this);
        }
    }
}