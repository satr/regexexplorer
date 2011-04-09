using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using LicenseHelper;
using RegexExplorer.Controls;
using RegexExplorer.ToolBarControls;
using RegexExplorer;

namespace RegexExplorer {
    public class MainForm : Form {
        #region Controls

        private MainMenu mainMenu;
        private MenuItem miFile;
        private MenuItem miExit;
        private MenuItem miHelp;
        private MenuItem miAbout;
        private ImageList toolBarImageList;
        private StatusBar statusBar;
        private StatusBarPanel sbpMessagePanel;
        private MenuItem miRegexOptions;
        private MenuItem miToolBars;
        private MenuItem miHighlightResultsInList;
        private IContainer components;
        private StatusBarController _statusBarController;
        private Panel toolBarRegexPanel;
        private CheckClearToolBarControl regexToolBarControl;
        private EditToolBarControl regexEditToolBarControl;
        private MenuItem miView;
        private MenuItem miPreferences;
        private HelpProvider helpProvider;
        private MenuItem miHelpIntro;
        private TabControl mainTab;
        private TabPage tabIsMatch;
        private Panel toolBarIsMatchPanel;
        private Panel panel1;
        private EditToolBarControl editIsMatchToolBarControl;
        private CheckClearToolBarControl checkClearIsMatchToolBarControl;
        private TabPage tabMatches;
        private TabPage tabCheckByList;
        private EditableListControl targetTextsListControl;
        private CheckResultControl checkResultCheckByListControl;
        private Panel toolBarCheckByListPanel;
        private ListToolBarControl listCheckByListToolBarControl;
        private EditToolBarControl editCheckByListToolBarControl;
        private CheckClearToolBarControl checkClearCheckByListToolBarControl;
        private RegexControl regexControl;
        private RegexOptionsControl regexOptionsControl;
        private ScalerToolBarControl scalerToolBarControl;
        private MenuItem menuItem2;
        private MenuItem miScalePatternUp;
        private MenuItem miScalePatternDown;
        private MenuItem miEdit;
        private MenuItem miCopy;
        private MenuItem miPaste;
        private MenuItem miPasteList;
        private MenuItem miAppendList;
        private MenuItem miFileListActionsSeparator;
        private MenuItem miLoadList;
        private MenuItem miSaveList;
        private MenuItem miListActionsSeparator;
        private MenuItem miCut;
        private MenuItem menuItem3;
        private MenuItem miCopyPat;
        private MenuItem miPastePat;
        private MenuItem miCutPat;
        private MenuItem miClearPat;
        private MenuItem miClear;
        private CheckResultControl checkResultIsMatchControl;
        private TitledTextField targetTextIsMatchField;
        private CheckResultControl checkResultMatchesControl;
        private CheckClearToolBarControl checkClearMatchesToolBarControl;
        private EditToolBarControl editMatchesToolBarControl;
        private Panel toolBarMatchesPanel;
        private FileToolBarControl fileToolBarControl;
        private MenuItem miPasteSpecial;
        private MenuItem miFileActionsSeparator;
        private MenuItem miOpenFile;
        private MenuItem miPreferencesSeparator;
        private MenuItem miCheck;
        private MenuItem miAction;
        private MenuItem miShowSelectedItemsSep;
        private MenuItem miShowSelectedItems;
        private MenuItem miAddPatternToFavoriteSep;
        private MenuItem miAddPatternToFavorites;
        private MenuItem miOpenRegexPattern;
        private MenuItem miRegexPatternHistory;
        private MenuItem miRegexPatternAddFieldsSep;
        private MenuItem miRegexPatternDescription;
        private MenuItem miUpdatePatternInFavorites;
        private MenuItem miModes;
        private MenuItem miIsMatch;
        private MenuItem miMatches;
        private MenuItem miCheckByList;
        private MenuItem miPredefinedPatterns;
        private MenuItem miLanguage;
        private MenuItem miLangEnglish;
        private MenuItem miLangRussian;
        private MatchesTargetControl matchesTargetControl;
        private Splitter splitter1;
        private MatchesResultControl matchesResultControl;
        public event RegexExplorerObjectEventHandler OnPreferencesUpdated;
        private MainController _mainController;
        private MenuItem miSepHelp;
        private MenuItem miSepRegister;
        private MenuItem miRegister;
        private HelpHolder _helpHolder;
        private MenuItem miCopyUniqueSymbols;
        private MenuItem miEditTextSpecialActionsSeparator;
        private PictureBox Label2;
        private MenuItem miCaptionsResultPattern;

        #endregion

        private MenuItem miShowAllItems;
        private MenuItem menuItem1;
        private MenuItem miInsertSymbolOfPattern;

        private bool log = false;

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MainMenu();
            this.miFile = new System.Windows.Forms.MenuItem();
            this.miOpenFile = new System.Windows.Forms.MenuItem();
            this.miFileActionsSeparator = new System.Windows.Forms.MenuItem();
            this.miLoadList = new System.Windows.Forms.MenuItem();
            this.miSaveList = new System.Windows.Forms.MenuItem();
            this.miFileListActionsSeparator = new System.Windows.Forms.MenuItem();
            this.miPreferences = new System.Windows.Forms.MenuItem();
            this.miPreferencesSeparator = new System.Windows.Forms.MenuItem();
            this.miExit = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.miCopyPat = new System.Windows.Forms.MenuItem();
            this.miPastePat = new System.Windows.Forms.MenuItem();
            this.miCutPat = new System.Windows.Forms.MenuItem();
            this.miClearPat = new System.Windows.Forms.MenuItem();
            this.miAddPatternToFavoriteSep = new System.Windows.Forms.MenuItem();
            this.miAddPatternToFavorites = new System.Windows.Forms.MenuItem();
            this.miUpdatePatternInFavorites = new System.Windows.Forms.MenuItem();
            this.miOpenRegexPattern = new System.Windows.Forms.MenuItem();
            this.miRegexPatternAddFieldsSep = new System.Windows.Forms.MenuItem();
            this.miCaptionsResultPattern = new System.Windows.Forms.MenuItem();
            this.miRegexPatternDescription = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miPredefinedPatterns = new System.Windows.Forms.MenuItem();
            this.miRegexPatternHistory = new System.Windows.Forms.MenuItem();
            this.miInsertSymbolOfPattern = new System.Windows.Forms.MenuItem();
            this.miEdit = new System.Windows.Forms.MenuItem();
            this.miCopy = new System.Windows.Forms.MenuItem();
            this.miPaste = new System.Windows.Forms.MenuItem();
            this.miCut = new System.Windows.Forms.MenuItem();
            this.miClear = new System.Windows.Forms.MenuItem();
            this.miEditTextSpecialActionsSeparator = new System.Windows.Forms.MenuItem();
            this.miCopyUniqueSymbols = new System.Windows.Forms.MenuItem();
            this.miPasteSpecial = new System.Windows.Forms.MenuItem();
            this.miListActionsSeparator = new System.Windows.Forms.MenuItem();
            this.miPasteList = new System.Windows.Forms.MenuItem();
            this.miAppendList = new System.Windows.Forms.MenuItem();
            this.miView = new System.Windows.Forms.MenuItem();
            this.miToolBars = new System.Windows.Forms.MenuItem();
            this.miRegexOptions = new System.Windows.Forms.MenuItem();
            this.miHighlightResultsInList = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miScalePatternUp = new System.Windows.Forms.MenuItem();
            this.miScalePatternDown = new System.Windows.Forms.MenuItem();
            this.miAction = new System.Windows.Forms.MenuItem();
            this.miCheck = new System.Windows.Forms.MenuItem();
            this.miShowSelectedItemsSep = new System.Windows.Forms.MenuItem();
            this.miShowSelectedItems = new System.Windows.Forms.MenuItem();
            this.miShowAllItems = new System.Windows.Forms.MenuItem();
            this.miModes = new System.Windows.Forms.MenuItem();
            this.miIsMatch = new System.Windows.Forms.MenuItem();
            this.miMatches = new System.Windows.Forms.MenuItem();
            this.miCheckByList = new System.Windows.Forms.MenuItem();
            this.miLanguage = new System.Windows.Forms.MenuItem();
            this.miLangEnglish = new System.Windows.Forms.MenuItem();
            this.miLangRussian = new System.Windows.Forms.MenuItem();
            this.miHelp = new System.Windows.Forms.MenuItem();
            this.miHelpIntro = new System.Windows.Forms.MenuItem();
            this.miSepHelp = new System.Windows.Forms.MenuItem();
            this.miRegister = new System.Windows.Forms.MenuItem();
            this.miSepRegister = new System.Windows.Forms.MenuItem();
            this.miAbout = new System.Windows.Forms.MenuItem();
            this.toolBarImageList = new System.Windows.Forms.ImageList(this.components);
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.sbpMessagePanel = new System.Windows.Forms.StatusBarPanel();
            this.toolBarRegexPanel = new System.Windows.Forms.Panel();
            this.scalerToolBarControl = new RegexExplorer.ToolBarControls.ScalerToolBarControl();
            this.regexEditToolBarControl = new RegexExplorer.ToolBarControls.EditToolBarControl();
            this.regexToolBarControl = new RegexExplorer.ToolBarControls.CheckClearToolBarControl();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.tabIsMatch = new System.Windows.Forms.TabPage();
            this.targetTextIsMatchField = new RegexExplorer.TitledTextField();
            this.checkResultIsMatchControl = new RegexExplorer.CheckResultControl();
            this.toolBarIsMatchPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editIsMatchToolBarControl = new RegexExplorer.ToolBarControls.EditToolBarControl();
            this.checkClearIsMatchToolBarControl = new RegexExplorer.ToolBarControls.CheckClearToolBarControl();
            this.Label2 = new System.Windows.Forms.PictureBox();
            this.tabMatches = new System.Windows.Forms.TabPage();
            this.matchesResultControl = new RegexExplorer.Controls.MatchesResultControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.matchesTargetControl = new RegexExplorer.Controls.MatchesTargetControl();
            this.checkResultMatchesControl = new RegexExplorer.CheckResultControl();
            this.toolBarMatchesPanel = new System.Windows.Forms.Panel();
            this.fileToolBarControl = new RegexExplorer.ToolBarControls.FileToolBarControl();
            this.editMatchesToolBarControl = new RegexExplorer.ToolBarControls.EditToolBarControl();
            this.checkClearMatchesToolBarControl = new RegexExplorer.ToolBarControls.CheckClearToolBarControl();
            this.tabCheckByList = new System.Windows.Forms.TabPage();
            this.targetTextsListControl = new RegexExplorer.EditableListControl();
            this.checkResultCheckByListControl = new RegexExplorer.CheckResultControl();
            this.toolBarCheckByListPanel = new System.Windows.Forms.Panel();
            this.listCheckByListToolBarControl = new RegexExplorer.ToolBarControls.ListToolBarControl();
            this.editCheckByListToolBarControl = new RegexExplorer.ToolBarControls.EditToolBarControl();
            this.checkClearCheckByListToolBarControl = new RegexExplorer.ToolBarControls.CheckClearToolBarControl();
            this.regexOptionsControl = new RegexExplorer.Controls.RegexOptionsControl();
            this.regexControl = new RegexExplorer.RegexControl();
            this.mainTab = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.sbpMessagePanel)).BeginInit();
            this.toolBarRegexPanel.SuspendLayout();
            this.tabIsMatch.SuspendLayout();
            this.toolBarIsMatchPanel.SuspendLayout();
            this.tabMatches.SuspendLayout();
            this.toolBarMatchesPanel.SuspendLayout();
            this.tabCheckByList.SuspendLayout();
            this.toolBarCheckByListPanel.SuspendLayout();
            this.mainTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.miFile,
                                                                                     this.menuItem3,
                                                                                     this.miEdit,
                                                                                     this.miView,
                                                                                     this.miAction,
                                                                                     this.miModes,
                                                                                     this.miLanguage,
                                                                                     this.miHelp});
            // 
            // miFile
            // 
            this.miFile.Index = 0;
            this.miFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                   this.miOpenFile,
                                                                                   this.miFileActionsSeparator,
                                                                                   this.miLoadList,
                                                                                   this.miSaveList,
                                                                                   this.miFileListActionsSeparator,
                                                                                   this.miPreferences,
                                                                                   this.miPreferencesSeparator,
                                                                                   this.miExit});
            this.miFile.Text = "File";
            // 
            // miOpenFile
            // 
            this.miOpenFile.Index = 0;
            this.miOpenFile.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.miOpenFile.Text = "Open file";
            this.miOpenFile.Click += new System.EventHandler(this.miOpenFile_Click);
            // 
            // miFileActionsSeparator
            // 
            this.miFileActionsSeparator.Index = 1;
            this.miFileActionsSeparator.Text = "-";
            // 
            // miLoadList
            // 
            this.miLoadList.Index = 2;
            this.miLoadList.Shortcut = System.Windows.Forms.Shortcut.CtrlL;
            this.miLoadList.Text = "Load list";
            this.miLoadList.Click += new System.EventHandler(this.miLoadList_Click);
            // 
            // miSaveList
            // 
            this.miSaveList.Index = 3;
            this.miSaveList.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.miSaveList.Text = "Save list";
            this.miSaveList.Click += new System.EventHandler(this.miSaveList_Click);
            // 
            // miFileListActionsSeparator
            // 
            this.miFileListActionsSeparator.Index = 4;
            this.miFileListActionsSeparator.Text = "-";
            // 
            // miPreferences
            // 
            this.miPreferences.Index = 5;
            this.miPreferences.Shortcut = System.Windows.Forms.Shortcut.F10;
            this.miPreferences.Text = "Preferences";
            this.miPreferences.Click += new System.EventHandler(this.miPreferences_Click);
            // 
            // miPreferencesSeparator
            // 
            this.miPreferencesSeparator.Index = 6;
            this.miPreferencesSeparator.Text = "-";
            // 
            // miExit
            // 
            this.miExit.Index = 7;
            this.miExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.miExit.Text = "Exit";
            this.miExit.Click += new System.EventHandler(this.miExit_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                      this.miCopyPat,
                                                                                      this.miPastePat,
                                                                                      this.miCutPat,
                                                                                      this.miClearPat,
                                                                                      this.miAddPatternToFavoriteSep,
                                                                                      this.miAddPatternToFavorites,
                                                                                      this.miUpdatePatternInFavorites,
                                                                                      this.miOpenRegexPattern,
                                                                                      this.miRegexPatternAddFieldsSep,
                                                                                      this.miCaptionsResultPattern,
                                                                                      this.miRegexPatternDescription,
                                                                                      this.menuItem1,
                                                                                      this.miPredefinedPatterns,
                                                                                      this.miRegexPatternHistory,
                                                                                      this.miInsertSymbolOfPattern});
            this.menuItem3.Text = "Edit pattern";
            // 
            // miCopyPat
            // 
            this.miCopyPat.Index = 0;
            this.miCopyPat.Text = "Copy   Ctrl+C";
            this.miCopyPat.Click += new System.EventHandler(this.miCopyPat_Click);
            // 
            // miPastePat
            // 
            this.miPastePat.Index = 1;
            this.miPastePat.Text = "Paste   Ctrl+V";
            this.miPastePat.Click += new System.EventHandler(this.miPastePat_Click);
            // 
            // miCutPat
            // 
            this.miCutPat.Index = 2;
            this.miCutPat.Text = "Cut     Ctrl+X";
            this.miCutPat.Click += new System.EventHandler(this.miCutPat_Click);
            // 
            // miClearPat
            // 
            this.miClearPat.Index = 3;
            this.miClearPat.Text = "Clear";
            this.miClearPat.Click += new System.EventHandler(this.miClearPat_Click);
            // 
            // miAddPatternToFavoriteSep
            // 
            this.miAddPatternToFavoriteSep.Index = 4;
            this.miAddPatternToFavoriteSep.Text = "-";
            // 
            // miAddPatternToFavorites
            // 
            this.miAddPatternToFavorites.Index = 5;
            this.miAddPatternToFavorites.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.miAddPatternToFavorites.Text = "Add pattern to favorites";
            this.miAddPatternToFavorites.Click += new System.EventHandler(this.miAddPatternToFavorites_Click);
            // 
            // miUpdatePatternInFavorites
            // 
            this.miUpdatePatternInFavorites.Index = 6;
            this.miUpdatePatternInFavorites.Shortcut = System.Windows.Forms.Shortcut.CtrlU;
            this.miUpdatePatternInFavorites.Text = "Update favorite pattern";
            this.miUpdatePatternInFavorites.Click += new System.EventHandler(this.miUpdatePatternInFavorites_Click);
            // 
            // miOpenRegexPattern
            // 
            this.miOpenRegexPattern.Index = 7;
            this.miOpenRegexPattern.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.miOpenRegexPattern.Text = "Open favorite pattern";
            this.miOpenRegexPattern.Click += new System.EventHandler(this.miOpenRegexPattern_Click);
            // 
            // miRegexPatternAddFieldsSep
            // 
            this.miRegexPatternAddFieldsSep.Index = 8;
            this.miRegexPatternAddFieldsSep.Text = "-";
            // 
            // miCaptionsResultPattern
            // 
            this.miCaptionsResultPattern.Index = 9;
            this.miCaptionsResultPattern.ShowShortcut = false;
            this.miCaptionsResultPattern.Text = "Captions result pattern";
            this.miCaptionsResultPattern.Click += new System.EventHandler(this.miCaptionsResultPattern_Click);
            // 
            // miRegexPatternDescription
            // 
            this.miRegexPatternDescription.Index = 10;
            this.miRegexPatternDescription.ShowShortcut = false;
            this.miRegexPatternDescription.Text = "Display description";
            this.miRegexPatternDescription.Click += new System.EventHandler(this.miRegexPatternDescription_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 11;
            this.menuItem1.Text = "-";
            // 
            // miPredefinedPatterns
            // 
            this.miPredefinedPatterns.Index = 12;
            this.miPredefinedPatterns.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.miPredefinedPatterns.Text = "Predefined patterns";
            this.miPredefinedPatterns.Click += new System.EventHandler(this.miPredefinedPatterns_Click);
            // 
            // miRegexPatternHistory
            // 
            this.miRegexPatternHistory.Index = 13;
            this.miRegexPatternHistory.Shortcut = System.Windows.Forms.Shortcut.CtrlH;
            this.miRegexPatternHistory.Text = "History of patterns";
            this.miRegexPatternHistory.Click += new System.EventHandler(this.miRegeexPatternHistory_Click);
            // 
            // miInsertSymbolOfPattern
            // 
            this.miInsertSymbolOfPattern.Index = 14;
            this.miInsertSymbolOfPattern.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.miInsertSymbolOfPattern.Text = "Insert symbols of pattern";
            this.miInsertSymbolOfPattern.Click += new System.EventHandler(this.miInsertSymbolOfPattern_Click);
            // 
            // miEdit
            // 
            this.miEdit.Index = 2;
            this.miEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                   this.miCopy,
                                                                                   this.miPaste,
                                                                                   this.miCut,
                                                                                   this.miClear,
                                                                                   this.miEditTextSpecialActionsSeparator,
                                                                                   this.miCopyUniqueSymbols,
                                                                                   this.miPasteSpecial,
                                                                                   this.miListActionsSeparator,
                                                                                   this.miPasteList,
                                                                                   this.miAppendList});
            this.miEdit.Text = "Edit text";
            // 
            // miCopy
            // 
            this.miCopy.Index = 0;
            this.miCopy.Text = "Copy   Ctrl+C";
            this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
            // 
            // miPaste
            // 
            this.miPaste.Index = 1;
            this.miPaste.Text = "Paste   Ctrl+V";
            this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
            // 
            // miCut
            // 
            this.miCut.Index = 2;
            this.miCut.Text = "Cut   Ctrl+X";
            this.miCut.Click += new System.EventHandler(this.miCut_Click);
            // 
            // miClear
            // 
            this.miClear.Index = 3;
            this.miClear.Text = "Clear";
            this.miClear.Click += new System.EventHandler(this.miClear_Click);
            // 
            // miEditTextSpecialActionsSeparator
            // 
            this.miEditTextSpecialActionsSeparator.Index = 4;
            this.miEditTextSpecialActionsSeparator.Text = "-";
            // 
            // miCopyUniqueSymbols
            // 
            this.miCopyUniqueSymbols.Index = 5;
            this.miCopyUniqueSymbols.Text = "Copy unique symbols";
            this.miCopyUniqueSymbols.Click += new System.EventHandler(this.miCopyUniqueSymbols_Click);
            // 
            // miPasteSpecial
            // 
            this.miPasteSpecial.Index = 6;
            this.miPasteSpecial.Text = "Paste special";
            this.miPasteSpecial.Click += new System.EventHandler(this.miPasteSpecial_Click);
            // 
            // miListActionsSeparator
            // 
            this.miListActionsSeparator.Index = 7;
            this.miListActionsSeparator.Text = "-";
            // 
            // miPasteList
            // 
            this.miPasteList.Index = 8;
            this.miPasteList.Text = "Paste list";
            this.miPasteList.Click += new System.EventHandler(this.miPasteList_Click);
            // 
            // miAppendList
            // 
            this.miAppendList.Index = 9;
            this.miAppendList.Text = "Append list";
            this.miAppendList.Click += new System.EventHandler(this.miAppendList_Click);
            // 
            // miView
            // 
            this.miView.Index = 3;
            this.miView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                   this.miToolBars,
                                                                                   this.miRegexOptions,
                                                                                   this.miHighlightResultsInList,
                                                                                   this.menuItem2,
                                                                                   this.miScalePatternUp,
                                                                                   this.miScalePatternDown});
            this.miView.Text = "View";
            // 
            // miToolBars
            // 
            this.miToolBars.Index = 0;
            this.miToolBars.RadioCheck = true;
            this.miToolBars.Text = "ToolBars";
            this.miToolBars.Click += new System.EventHandler(this.miToolBars_Click);
            // 
            // miRegexOptions
            // 
            this.miRegexOptions.Index = 1;
            this.miRegexOptions.RadioCheck = true;
            this.miRegexOptions.Text = "Regex options";
            this.miRegexOptions.Click += new System.EventHandler(this.miRegexOptions_Click);
            // 
            // miHighlightResultsInList
            // 
            this.miHighlightResultsInList.Index = 2;
            this.miHighlightResultsInList.RadioCheck = true;
            this.miHighlightResultsInList.Text = "Color results in list";
            this.miHighlightResultsInList.Click += new System.EventHandler(this.miResultWithColors_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 3;
            this.menuItem2.Text = "-";
            // 
            // miScalePatternUp
            // 
            this.miScalePatternUp.Index = 4;
            this.miScalePatternUp.Shortcut = System.Windows.Forms.Shortcut.F12;
            this.miScalePatternUp.Text = "Scale pattern up";
            this.miScalePatternUp.Click += new System.EventHandler(this.miScalePatternUp_Click);
            // 
            // miScalePatternDown
            // 
            this.miScalePatternDown.Index = 5;
            this.miScalePatternDown.Shortcut = System.Windows.Forms.Shortcut.F11;
            this.miScalePatternDown.Text = "Scale pattern down";
            this.miScalePatternDown.Click += new System.EventHandler(this.miScalePatternDown_Click);
            // 
            // miAction
            // 
            this.miAction.Index = 4;
            this.miAction.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.miCheck,
                                                                                     this.miShowSelectedItemsSep,
                                                                                     this.miShowSelectedItems,
                                                                                     this.miShowAllItems});
            this.miAction.Text = "Action";
            // 
            // miCheck
            // 
            this.miCheck.Index = 0;
            this.miCheck.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.miCheck.Text = "Check";
            this.miCheck.Click += new System.EventHandler(this.miCheck_Click);
            // 
            // miShowSelectedItemsSep
            // 
            this.miShowSelectedItemsSep.Index = 1;
            this.miShowSelectedItemsSep.Text = "-";
            // 
            // miShowSelectedItems
            // 
            this.miShowSelectedItems.Index = 2;
            this.miShowSelectedItems.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.miShowSelectedItems.Text = "Show selected items";
            this.miShowSelectedItems.Click += new System.EventHandler(this.miShowSelectedItems_Click);
            // 
            // miShowAllItems
            // 
            this.miShowAllItems.Index = 3;
            this.miShowAllItems.Shortcut = System.Windows.Forms.Shortcut.CtrlF3;
            this.miShowAllItems.Text = "Show all items";
            this.miShowAllItems.Click += new System.EventHandler(this.miShowAllItems_Click);
            // 
            // miModes
            // 
            this.miModes.Index = 5;
            this.miModes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                    this.miIsMatch,
                                                                                    this.miMatches,
                                                                                    this.miCheckByList});
            this.miModes.Text = "Modes";
            // 
            // miIsMatch
            // 
            this.miIsMatch.Index = 0;
            this.miIsMatch.Text = "Is match";
            this.miIsMatch.Click += new System.EventHandler(this.miIsMatch_Click);
            // 
            // miMatches
            // 
            this.miMatches.Index = 1;
            this.miMatches.Text = "Matches/Captions";
            this.miMatches.Click += new System.EventHandler(this.miMatches_Click);
            // 
            // miCheckByList
            // 
            this.miCheckByList.Index = 2;
            this.miCheckByList.Text = "Check by list";
            this.miCheckByList.Click += new System.EventHandler(this.miCheckByList_Click);
            // 
            // miLanguage
            // 
            this.miLanguage.Index = 6;
            this.miLanguage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                       this.miLangEnglish,
                                                                                       this.miLangRussian});
            this.miLanguage.ShowShortcut = false;
            this.miLanguage.Text = "Language";
            // 
            // miLangEnglish
            // 
            this.miLangEnglish.Index = 0;
            this.miLangEnglish.ShowShortcut = false;
            this.miLangEnglish.Text = "English";
            this.miLangEnglish.Click += new System.EventHandler(this.miLangEnglish_Click);
            // 
            // miLangRussian
            // 
            this.miLangRussian.Index = 1;
            this.miLangRussian.Text = "Russian";
            this.miLangRussian.Click += new System.EventHandler(this.miLangRussian_Click);
            // 
            // miHelp
            // 
            this.miHelp.Index = 7;
            this.miHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                   this.miHelpIntro,
                                                                                   this.miSepHelp,
                                                                                   this.miRegister,
                                                                                   this.miSepRegister,
                                                                                   this.miAbout});
            this.miHelp.Text = "Help";
            // 
            // miHelpIntro
            // 
            this.miHelpIntro.Index = 0;
            this.miHelpIntro.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.miHelpIntro.Text = "Help";
            this.miHelpIntro.Click += new System.EventHandler(this.miHelpIntro_Click);
            // 
            // miSepHelp
            // 
            this.miSepHelp.Index = 1;
            this.miSepHelp.Text = "-";
            // 
            // miRegister
            // 
            this.miRegister.Index = 2;
            this.miRegister.Shortcut = System.Windows.Forms.Shortcut.F8;
            this.miRegister.Text = "Register";
            this.miRegister.Click += new System.EventHandler(this.miRegister_Click);
            // 
            // miSepRegister
            // 
            this.miSepRegister.Index = 3;
            this.miSepRegister.Text = "-";
            // 
            // miAbout
            // 
            this.miAbout.Index = 4;
            this.miAbout.Text = "About";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // toolBarImageList
            // 
            this.toolBarImageList.ImageSize = new System.Drawing.Size(19, 18);
            this.toolBarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolBarImageList.ImageStream")));
            this.toolBarImageList.TransparentColor = System.Drawing.Color.Gray;
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 435);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
                                                                                         this.sbpMessagePanel});
            this.statusBar.Size = new System.Drawing.Size(584, 22);
            this.statusBar.TabIndex = 5;
            // 
            // toolBarRegexPanel
            // 
            this.toolBarRegexPanel.Controls.Add(this.scalerToolBarControl);
            this.toolBarRegexPanel.Controls.Add(this.regexEditToolBarControl);
            this.toolBarRegexPanel.Controls.Add(this.regexToolBarControl);
            this.toolBarRegexPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarRegexPanel.Location = new System.Drawing.Point(0, 0);
            this.toolBarRegexPanel.Name = "toolBarRegexPanel";
            this.toolBarRegexPanel.Size = new System.Drawing.Size(584, 32);
            this.toolBarRegexPanel.TabIndex = 7;
            // 
            // scalerToolBarControl
            // 
            this.scalerToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.scalerToolBarControl.Location = new System.Drawing.Point(120, 0);
            this.scalerToolBarControl.Name = "scalerToolBarControl";
            this.scalerToolBarControl.Size = new System.Drawing.Size(56, 32);
            this.scalerToolBarControl.TabIndex = 3;
            this.scalerToolBarControl.TabStop = false;
            // 
            // regexEditToolBarControl
            // 
            this.regexEditToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.regexEditToolBarControl.Location = new System.Drawing.Point(32, 0);
            this.regexEditToolBarControl.Name = "regexEditToolBarControl";
            this.regexEditToolBarControl.pasteSpecialVisible = false;
            this.regexEditToolBarControl.Size = new System.Drawing.Size(88, 32);
            this.regexEditToolBarControl.TabIndex = 2;
            this.regexEditToolBarControl.TabStop = false;
            // 
            // regexToolBarControl
            // 
            this.regexToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.regexToolBarControl.Location = new System.Drawing.Point(0, 0);
            this.regexToolBarControl.Name = "regexToolBarControl";
            this.regexToolBarControl.Size = new System.Drawing.Size(32, 32);
            this.regexToolBarControl.TabIndex = 1;
            this.regexToolBarControl.TabStop = false;
            // 
            // tabIsMatch
            // 
            this.tabIsMatch.Controls.Add(this.targetTextIsMatchField);
            this.tabIsMatch.Controls.Add(this.checkResultIsMatchControl);
            this.tabIsMatch.Controls.Add(this.toolBarIsMatchPanel);
            this.tabIsMatch.Controls.Add(this.Label2);
            this.helpProvider.SetHelpKeyword(this.tabIsMatch, "IsMatch");
            this.helpProvider.SetHelpNavigator(this.tabIsMatch, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.helpProvider.SetHelpString(this.tabIsMatch, "");
            this.tabIsMatch.Location = new System.Drawing.Point(4, 22);
            this.tabIsMatch.Name = "tabIsMatch";
            this.helpProvider.SetShowHelp(this.tabIsMatch, true);
            this.tabIsMatch.Size = new System.Drawing.Size(576, 241);
            this.tabIsMatch.TabIndex = 0;
            this.tabIsMatch.Text = "Is match";
            // 
            // targetTextIsMatchField
            // 
            this.targetTextIsMatchField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetTextIsMatchField.Location = new System.Drawing.Point(0, 68);
            this.targetTextIsMatchField.Multiline = true;
            this.targetTextIsMatchField.Name = "targetTextIsMatchField";
            this.targetTextIsMatchField.ReadOnly = false;
            this.targetTextIsMatchField.Size = new System.Drawing.Size(576, 173);
            this.targetTextIsMatchField.TabIndex = 9;
            this.targetTextIsMatchField.TitleText = "Target text";
            // 
            // checkResultIsMatchControl
            // 
            this.checkResultIsMatchControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkResultIsMatchControl.Location = new System.Drawing.Point(0, 32);
            this.checkResultIsMatchControl.Name = "checkResultIsMatchControl";
            this.checkResultIsMatchControl.ResultText = "";
            this.checkResultIsMatchControl.ResultTitle = "Result";
            this.checkResultIsMatchControl.Size = new System.Drawing.Size(576, 36);
            this.checkResultIsMatchControl.TabIndex = 8;
            this.checkResultIsMatchControl.TabStop = false;
            // 
            // toolBarIsMatchPanel
            // 
            this.toolBarIsMatchPanel.Controls.Add(this.panel1);
            this.toolBarIsMatchPanel.Controls.Add(this.editIsMatchToolBarControl);
            this.toolBarIsMatchPanel.Controls.Add(this.checkClearIsMatchToolBarControl);
            this.toolBarIsMatchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarIsMatchPanel.Location = new System.Drawing.Point(0, 0);
            this.toolBarIsMatchPanel.Name = "toolBarIsMatchPanel";
            this.toolBarIsMatchPanel.Size = new System.Drawing.Size(576, 32);
            this.toolBarIsMatchPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(192, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 32);
            this.panel1.TabIndex = 2;
            // 
            // editIsMatchToolBarControl
            // 
            this.editIsMatchToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.editIsMatchToolBarControl.Location = new System.Drawing.Point(32, 0);
            this.editIsMatchToolBarControl.Name = "editIsMatchToolBarControl";
            this.editIsMatchToolBarControl.pasteSpecialVisible = true;
            this.editIsMatchToolBarControl.Size = new System.Drawing.Size(120, 32);
            this.editIsMatchToolBarControl.TabIndex = 1;
            this.editIsMatchToolBarControl.TabStop = false;
            // 
            // checkClearIsMatchToolBarControl
            // 
            this.checkClearIsMatchToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkClearIsMatchToolBarControl.Location = new System.Drawing.Point(0, 0);
            this.checkClearIsMatchToolBarControl.Name = "checkClearIsMatchToolBarControl";
            this.checkClearIsMatchToolBarControl.Size = new System.Drawing.Size(32, 32);
            this.checkClearIsMatchToolBarControl.TabIndex = 0;
            this.checkClearIsMatchToolBarControl.TabStop = false;
            // 
            // Label2
            // 
            this.Label2.Image = ((System.Drawing.Image)(resources.GetObject("Label2.Image")));
            this.Label2.Location = new System.Drawing.Point(504, 112);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(24, 24);
            this.Label2.TabIndex = 3;
            this.Label2.TabStop = false;
            this.Label2.Visible = false;
            // 
            // tabMatches
            // 
            this.tabMatches.Controls.Add(this.matchesResultControl);
            this.tabMatches.Controls.Add(this.splitter1);
            this.tabMatches.Controls.Add(this.matchesTargetControl);
            this.tabMatches.Controls.Add(this.checkResultMatchesControl);
            this.tabMatches.Controls.Add(this.toolBarMatchesPanel);
            this.helpProvider.SetHelpKeyword(this.tabMatches, "Matches");
            this.helpProvider.SetHelpNavigator(this.tabMatches, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.helpProvider.SetHelpString(this.tabMatches, "");
            this.tabMatches.Location = new System.Drawing.Point(4, 22);
            this.tabMatches.Name = "tabMatches";
            this.helpProvider.SetShowHelp(this.tabMatches, true);
            this.tabMatches.Size = new System.Drawing.Size(576, 241);
            this.tabMatches.TabIndex = 2;
            this.tabMatches.Text = "Matches/Captions";
            this.tabMatches.Visible = false;
            // 
            // matchesResultControl
            // 
            this.matchesResultControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.matchesResultControl.Location = new System.Drawing.Point(275, 69);
            this.matchesResultControl.Name = "matchesResultControl";
            this.matchesResultControl.Size = new System.Drawing.Size(301, 172);
            this.matchesResultControl.TabIndex = 25;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(272, 69);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 172);
            this.splitter1.TabIndex = 24;
            this.splitter1.TabStop = false;
            // 
            // matchesTargetControl
            // 
            this.matchesTargetControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.matchesTargetControl.Location = new System.Drawing.Point(0, 69);
            this.matchesTargetControl.Name = "matchesTargetControl";
            this.matchesTargetControl.Size = new System.Drawing.Size(272, 172);
            this.matchesTargetControl.TabIndex = 23;
            // 
            // checkResultMatchesControl
            // 
            this.checkResultMatchesControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkResultMatchesControl.Location = new System.Drawing.Point(0, 32);
            this.checkResultMatchesControl.Name = "checkResultMatchesControl";
            this.checkResultMatchesControl.ResultText = "";
            this.checkResultMatchesControl.ResultTitle = "Result";
            this.checkResultMatchesControl.Size = new System.Drawing.Size(576, 37);
            this.checkResultMatchesControl.TabIndex = 15;
            this.checkResultMatchesControl.TabStop = false;
            // 
            // toolBarMatchesPanel
            // 
            this.toolBarMatchesPanel.Controls.Add(this.fileToolBarControl);
            this.toolBarMatchesPanel.Controls.Add(this.editMatchesToolBarControl);
            this.toolBarMatchesPanel.Controls.Add(this.checkClearMatchesToolBarControl);
            this.toolBarMatchesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarMatchesPanel.Location = new System.Drawing.Point(0, 0);
            this.toolBarMatchesPanel.Name = "toolBarMatchesPanel";
            this.toolBarMatchesPanel.Size = new System.Drawing.Size(576, 32);
            this.toolBarMatchesPanel.TabIndex = 14;
            // 
            // fileToolBarControl
            // 
            this.fileToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.fileToolBarControl.Location = new System.Drawing.Point(148, 0);
            this.fileToolBarControl.Name = "fileToolBarControl";
            this.fileToolBarControl.OpenFileVisible = true;
            this.fileToolBarControl.SaveFileVisible = false;
            this.fileToolBarControl.Size = new System.Drawing.Size(40, 32);
            this.fileToolBarControl.TabIndex = 3;
            // 
            // editMatchesToolBarControl
            // 
            this.editMatchesToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.editMatchesToolBarControl.Location = new System.Drawing.Point(32, 0);
            this.editMatchesToolBarControl.Name = "editMatchesToolBarControl";
            this.editMatchesToolBarControl.pasteSpecialVisible = true;
            this.editMatchesToolBarControl.Size = new System.Drawing.Size(116, 32);
            this.editMatchesToolBarControl.TabIndex = 2;
            this.editMatchesToolBarControl.TabStop = false;
            // 
            // checkClearMatchesToolBarControl
            // 
            this.checkClearMatchesToolBarControl.AccessibleDescription = "";
            this.checkClearMatchesToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkClearMatchesToolBarControl.Location = new System.Drawing.Point(0, 0);
            this.checkClearMatchesToolBarControl.Name = "checkClearMatchesToolBarControl";
            this.checkClearMatchesToolBarControl.Size = new System.Drawing.Size(32, 32);
            this.checkClearMatchesToolBarControl.TabIndex = 1;
            this.checkClearMatchesToolBarControl.TabStop = false;
            // 
            // tabCheckByList
            // 
            this.tabCheckByList.Controls.Add(this.targetTextsListControl);
            this.tabCheckByList.Controls.Add(this.checkResultCheckByListControl);
            this.tabCheckByList.Controls.Add(this.toolBarCheckByListPanel);
            this.helpProvider.SetHelpKeyword(this.tabCheckByList, "CheckByList");
            this.helpProvider.SetHelpNavigator(this.tabCheckByList, System.Windows.Forms.HelpNavigator.KeywordIndex);
            this.helpProvider.SetHelpString(this.tabCheckByList, "");
            this.tabCheckByList.Location = new System.Drawing.Point(4, 22);
            this.tabCheckByList.Name = "tabCheckByList";
            this.helpProvider.SetShowHelp(this.tabCheckByList, true);
            this.tabCheckByList.Size = new System.Drawing.Size(576, 241);
            this.tabCheckByList.TabIndex = 1;
            this.tabCheckByList.Text = "Check by list";
            this.tabCheckByList.Visible = false;
            // 
            // targetTextsListControl
            // 
            this.targetTextsListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.targetTextsListControl.keepTextAfterAddition = false;
            this.targetTextsListControl.Location = new System.Drawing.Point(0, 64);
            this.targetTextsListControl.Name = "targetTextsListControl";
            this.targetTextsListControl.Size = new System.Drawing.Size(576, 177);
            this.targetTextsListControl.TabIndex = 28;
            // 
            // checkResultCheckByListControl
            // 
            this.checkResultCheckByListControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkResultCheckByListControl.Location = new System.Drawing.Point(0, 32);
            this.checkResultCheckByListControl.Name = "checkResultCheckByListControl";
            this.checkResultCheckByListControl.ResultText = "";
            this.checkResultCheckByListControl.ResultTitle = "Result";
            this.checkResultCheckByListControl.Size = new System.Drawing.Size(576, 32);
            this.checkResultCheckByListControl.TabIndex = 24;
            this.checkResultCheckByListControl.TabStop = false;
            // 
            // toolBarCheckByListPanel
            // 
            this.toolBarCheckByListPanel.Controls.Add(this.listCheckByListToolBarControl);
            this.toolBarCheckByListPanel.Controls.Add(this.editCheckByListToolBarControl);
            this.toolBarCheckByListPanel.Controls.Add(this.checkClearCheckByListToolBarControl);
            this.toolBarCheckByListPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolBarCheckByListPanel.Location = new System.Drawing.Point(0, 0);
            this.toolBarCheckByListPanel.Name = "toolBarCheckByListPanel";
            this.toolBarCheckByListPanel.Size = new System.Drawing.Size(576, 32);
            this.toolBarCheckByListPanel.TabIndex = 0;
            // 
            // listCheckByListToolBarControl
            // 
            this.listCheckByListToolBarControl.appendListVisible = true;
            this.listCheckByListToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.listCheckByListToolBarControl.loadListVisible = true;
            this.listCheckByListToolBarControl.Location = new System.Drawing.Point(180, 0);
            this.listCheckByListToolBarControl.Name = "listCheckByListToolBarControl";
            this.listCheckByListToolBarControl.pasteListVisible = true;
            this.listCheckByListToolBarControl.saveListVisible = true;
            this.listCheckByListToolBarControl.Size = new System.Drawing.Size(120, 32);
            this.listCheckByListToolBarControl.TabIndex = 6;
            this.listCheckByListToolBarControl.TabStop = false;
            // 
            // editCheckByListToolBarControl
            // 
            this.editCheckByListToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.editCheckByListToolBarControl.Location = new System.Drawing.Point(32, 0);
            this.editCheckByListToolBarControl.Name = "editCheckByListToolBarControl";
            this.editCheckByListToolBarControl.pasteSpecialVisible = true;
            this.editCheckByListToolBarControl.Size = new System.Drawing.Size(148, 32);
            this.editCheckByListToolBarControl.TabIndex = 5;
            this.editCheckByListToolBarControl.TabStop = false;
            // 
            // checkClearCheckByListToolBarControl
            // 
            this.checkClearCheckByListToolBarControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkClearCheckByListToolBarControl.Location = new System.Drawing.Point(0, 0);
            this.checkClearCheckByListToolBarControl.Name = "checkClearCheckByListToolBarControl";
            this.checkClearCheckByListToolBarControl.Size = new System.Drawing.Size(32, 32);
            this.checkClearCheckByListToolBarControl.TabIndex = 4;
            this.checkClearCheckByListToolBarControl.TabStop = false;
            // 
            // regexOptionsControl
            // 
            this.regexOptionsControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.regexOptionsControl.Location = new System.Drawing.Point(0, 104);
            this.regexOptionsControl.Name = "regexOptionsControl";
            this.regexOptionsControl.Size = new System.Drawing.Size(584, 64);
            this.regexOptionsControl.TabIndex = 18;
            this.regexOptionsControl.TabStop = false;
            // 
            // regexControl
            // 
            this.regexControl.CurrentScaleIndex = 0;
            this.regexControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.regexControl.Location = new System.Drawing.Point(0, 32);
            this.regexControl.Name = "regexControl";
            this.regexControl.ReadOnlyRegexMatchCaptionsResult = true;
            this.regexControl.RegexPatternsDescriptionIsVisible = true;
            this.regexControl.RegexPatternsResultIsVisible = true;
            this.regexControl.Size = new System.Drawing.Size(584, 72);
            this.regexControl.TabIndex = 17;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.tabIsMatch);
            this.mainTab.Controls.Add(this.tabMatches);
            this.mainTab.Controls.Add(this.tabCheckByList);
            this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTab.Location = new System.Drawing.Point(0, 168);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(584, 267);
            this.mainTab.TabIndex = 19;
            this.mainTab.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(584, 457);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.regexOptionsControl);
            this.Controls.Add(this.regexControl);
            this.Controls.Add(this.toolBarRegexPanel);
            this.Controls.Add(this.statusBar);
            this.HelpButton = true;
            this.helpProvider.SetHelpKeyword(this, "1001");
            this.helpProvider.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.helpProvider.SetHelpString(this, "");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.helpProvider.SetShowHelp(this, true);
            this.Text = "Regex Explorer";
            ((System.ComponentModel.ISupportInitialize)(this.sbpMessagePanel)).EndInit();
            this.toolBarRegexPanel.ResumeLayout(false);
            this.tabIsMatch.ResumeLayout(false);
            this.toolBarIsMatchPanel.ResumeLayout(false);
            this.tabMatches.ResumeLayout(false);
            this.toolBarMatchesPanel.ResumeLayout(false);
            this.tabCheckByList.ResumeLayout(false);
            this.toolBarCheckByListPanel.ResumeLayout(false);
            this.mainTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        [STAThread]
        private static void Main() {
            try {
                Application.EnableVisualStyles();
                Application.DoEvents();
                SplashForm splashForm = new SplashForm();
                splashForm.Show();
                splashForm.Refresh();
                MainForm mainForm = new MainForm(splashForm);
                Application.Run(mainForm);
            }
            catch (Exception ex) {
                Messenger.ShowError(ex);
            }
        }

        public MainForm(SplashForm splashForm) {
            InitializeComponent();
            InitPreferences();
            ActivateLanguage();
            GuiObjectsCollection.ApplyActualLanguageFor(this);
            InitHelpProviderFor(helpProvider, this, "Intro");
            InitLinks();
            InitCheckedMenuItemsBy(Preferences.Res);
            InitControllers(Preferences.Res);
            BindEventsToControls();
            BindEventsToMenuItems();
            InitDinamicMenuItems();
            SetActualController();
            SetHelpProviderToControls();
            splashForm.Close();
            Visible = true;
            InitControls(Preferences.Res);
            InitModesTabPagesBy(Preferences.Res);
            DisplayLicState();
        }

        private void InitLinks() {
            string wwwURL = "code.google.com/p/regexexplorer/";
            string orderURL = wwwURL + "Order/";
            string currentLanguageShortName = LangBase.CurrentLanguageShortName;
            if (currentLanguageShortName.Length > 0) {
                wwwURL += currentLanguageShortName + "/";
                orderURL += currentLanguageShortName + "/";
            }
            LicenseHelperForm.OrderURL = orderURL;
            AboutForm.wwwURL = wwwURL;
            AboutForm.OrderURL = orderURL;
        }

        private void WriteLog(string msg) {
            if (!log)
                return;
            EventLog.WriteEntry("Application", msg);
        }

        private void DisplayLicState() {
            Text = MsgsBase.Res.RegexExplorer;
            if (! /*<KeyKeyGeneratorCheck1>*/LicenseController.IsRegistered /*</KeyKeyGeneratorCheck1>*/)
                Text += " " + MsgsBase.Res.Unregistered_press_F8_to_register_your_copy;
        }

        private void ActivateLanguage() {
            try {
                LangBase.Activate(new Msgs());
                string languageName = GetInitLanguageIfExists();
                if (languageName != null) {
                    LangBase.Activate(languageName);
                    PreferencesBase.Res.LastLanguageName = LangBase.CurrentLanguageName;
                    PreferencesBase.Res.Save();
                }
            }
            catch (StoredObjectException ex) {
                Messenger.ShowError(ex);
            }
            catch (Exception ex) {
                Messenger.ShowError(ex);
            }
        }

        private string GetInitLanguageIfExists() {
            string line = null;
            string initLanguageFileName = "InitLanguage.txt";
            FileInfo fileInfo = new FileInfo(initLanguageFileName);
            if (!fileInfo.Exists)
                return null;
            try {
                using (TextReader reader = new StreamReader(initLanguageFileName))
                    line = reader.ReadLine();
            }
            finally {
                try {
                    using (StreamWriter sw = fileInfo.CreateText())
                        sw.Close();
                }
                catch {
                }
            }
            if (line == null)
                return line;
            if (Regex.IsMatch(line, Lang.RUSSIAN_LANGUAGE_NAME, RegexOptions.IgnoreCase))
                line = Lang.RUSSIAN_LANGUAGE_NAME;
            else if (Regex.IsMatch(line, Lang.DEFAULT_LANGUAGE_NAME, RegexOptions.IgnoreCase))
                line = Lang.DEFAULT_LANGUAGE_NAME;
            return line;
        }

        private void BindEventsToMenuItems() {
            foreach (MenuItem item in mainMenu.MenuItems) {
                item.Popup += new EventHandler(MenuItem_Popup);
            }
        }

        private void InitPreferences() {
            Preferences.Init();
            if (Preferences.Res == null) {
                Messenger.ShowError("Preferences are not defined - application will be closed.");
                Close();
            }
            if (! /*<KeyKeyGeneratorCheck2>*/ LicenseController.IsRegistered /*</KeyKeyGeneratorCheck2>*/) {
                Preferences.Res.MaxRecentFilesQuantity = 5;
                Preferences.Res.MaxRegexPatternFavoritesLength = 10;
            }
        }

        private void InitHelpProviderFor(HelpProvider helpProv, Control defaultControl, string defaultKeyword) {
            _helpHolder = new HelpHolder(helpProv, defaultControl, defaultKeyword);
            InitHelpProvider();
        }

        private void InitHelpProvider() {
            _helpHolder.InitHelpProvider();
        }

        private void SetHelpProviderToControls() {
            _mainController.SetHelpProviderFor(tabIsMatch, "IsMatch");
            _mainController.SetHelpProviderFor(tabMatches, "Matches");
            _mainController.SetHelpProviderFor(tabCheckByList, "CheckByList");
            _mainController.SetHelpProviderFor(regexControl, "Symbols");
            regexControl.InitHelpProvider(_mainController);
        }

        private void InitControls(Preferences prefs) {
            regexControl.Preferences = prefs;
            regexControl.RegexOptionsHolder = regexOptionsControl.regexOptionsHolder;
        }

        private void InitModesTabPagesBy(Preferences prefs) {
            InitModesTabPagesBy((RegexWorkModes) prefs.LastActiveModeAsInt);
        }

        private void InitModesTabPagesBy(RegexWorkModes activeMode) {
            TabPage lastActiveTabPage = GetLastActiveModesTabPageBy(activeMode);
            if (!Preferences.Res.ShowAllModesTabs) {
                InitModesTabPagesFor(lastActiveTabPage);
                ChangeActualController();
                RestoreModesMenuItem();
            }
            else {
                InitModesTabPagesFor(tabIsMatch, tabMatches, tabCheckByList);
                RemoveModesMenuItem();
            }
            mainTab.SelectedTab = lastActiveTabPage;
            InitModesMenuItemsBy(activeMode);
        }

        private void RestoreModesMenuItem() {
            if (mainMenu.MenuItems.Contains(miModes))
                return;
            RemoveFromMainMenuIfExists(miHelp);
            AddToMainMenu(miModes);
            AddToMainMenu(miHelp);
        }

        private void AddToMainMenu(MenuItem menuItem) {
            mainMenu.MenuItems.Add(menuItem);
        }

        private void RemoveModesMenuItem() {
            RemoveFromMainMenuIfExists(miModes);
        }

        private void RemoveFromMainMenuIfExists(MenuItem menuItem) {
            if (mainMenu.MenuItems.Contains(menuItem))
                mainMenu.MenuItems.Remove(menuItem);
        }

        private void InitModesMenuItemsBy(RegexWorkModes activeMode) {
            miMatches.Checked = (activeMode == RegexWorkModes.Matches);
            miCheckByList.Checked = (activeMode == RegexWorkModes.CheckByList);
            miIsMatch.Checked = (activeMode == RegexWorkModes.IsMatch);
        }

        private void InitModesTabPagesFor(params TabPage[] pages) {
            try {
                mainTab.SelectedIndexChanged -= new EventHandler(MainTab_SelectedIndexChanged);
            }
            catch {
            }
            mainTab.SuspendLayout();
            mainTab.TabPages.Clear();
            foreach (TabPage page in pages)
                mainTab.TabPages.Add(page);
            mainTab.ResumeLayout();
            mainTab.SelectedIndexChanged += new EventHandler(MainTab_SelectedIndexChanged);
        }

        private TabPage GetLastActiveModesTabPageBy(RegexWorkModes mode) {
            if (mode == RegexWorkModes.Matches)
                return tabMatches;
            if (mode == RegexWorkModes.CheckByList)
                return tabCheckByList;
            return tabIsMatch;
        }

        private void BindEventsToControls() {
            regexToolBarControl.onClear += new CheckClearEventHandler(regexControl.Clear);
            regexEditToolBarControl.onCopy += new EditionEventHandler(regexControl.Copy);
            regexEditToolBarControl.onCut += new EditionEventHandler(regexControl.Cut);
            regexEditToolBarControl.onPaste += new EditionEventHandler(regexControl.Paste);
            regexControl.OnCheck += new CheckClearEventHandler(_mainController.Check);
            regexControl.OnScale += new ScaleEventHandler(regexControl_onScale);
            regexControl.OnFavoriteItemChanged += new RegexExplorerEventHandler(UpdateFavoriteRegexPatternsMenuItems);
            scalerToolBarControl.onScaleUp += new ScaleUpDownEventHandler(regexControl.ScaleUp);
            scalerToolBarControl.onScaleDown += new ScaleUpDownEventHandler(regexControl.ScaleDown);
            editIsMatchToolBarControl.onPasteSpecial += new EditionEventHandler(_mainController.PasteSpecial);
            editMatchesToolBarControl.onPasteSpecial += new EditionEventHandler(_mainController.PasteSpecial);
            editCheckByListToolBarControl.onPasteSpecial += new EditionEventHandler(_mainController.PasteSpecial);
            editCheckByListToolBarControl.onCopyUniqueSymbols +=
                new EditionEventHandler(_mainController.CopyUniqueSymbols);
            OnPreferencesUpdated += new RegexExplorerObjectEventHandler(MainForm_OnPreferencesUpdated);
            Closing += new CancelEventHandler(MainForm_Closing);
            _mainController.OnGotKey += new GotKeyHandle(mainFormController_OnGotKey);
        }

        private void InitCheckedMenuItemsBy(Preferences prefs) {
            RegexBarsVisible = miRegexOptions.Checked = prefs.RegexOptions;
            ToolBarsVisible = miToolBars.Checked = prefs.ToolBars;
            miHighlightResultsInList.Checked = prefs.HighlightResultsInList;
            miRegexPatternDescription.Checked = prefs.RegexPatternsDescriptionIsVisible;
            miCaptionsResultPattern.Checked = prefs.RegexPatternsResultIsVisible;
        }

        private void InitControllers(Preferences prefs) {
            _mainController = new MainController(helpProvider, (Bitmap) Label2.Image);
            _statusBarController = new StatusBarController(statusBar);
            tabIsMatch.Tag = new IsMatchController(_statusBarController, regexControl,
                                                   checkResultIsMatchControl,
                                                   targetTextIsMatchField,
                                                   checkClearIsMatchToolBarControl,
                                                   editIsMatchToolBarControl);
            tabMatches.Tag = new MatchesController(_mainController, _statusBarController, regexControl,
                                                   checkResultMatchesControl,
                                                   matchesTargetControl,
                                                   matchesResultControl,
                                                   checkClearMatchesToolBarControl,
                                                   editMatchesToolBarControl,
                                                   fileToolBarControl);
            tabCheckByList.Tag = new CheckByListController(prefs, _statusBarController, regexControl,
                                                           checkResultCheckByListControl,
                                                           targetTextsListControl,
                                                           checkClearCheckByListToolBarControl,
                                                           editCheckByListToolBarControl,
                                                           listCheckByListToolBarControl);
        }

        private bool ToolBarsVisible {
            set {
                toolBarRegexPanel.Visible
                    = toolBarIsMatchPanel.Visible
                      = toolBarMatchesPanel.Visible
                        = toolBarCheckByListPanel.Visible = value;
            }
        }

        private bool RegexBarsVisible {
            set { regexOptionsControl.Visible = value; }
        }

        private void regexControl_onScale(int scaleIndex) {
            Preferences.Res.ScaleIndex = scaleIndex;
            Preferences.Res.Save();
        }

        private void MainTab_SelectedIndexChanged(object sender, EventArgs e) {
            ChangeActualController();
        }

        private void ChangeActualController() {
            SetActualController();
            StoreLastActiveModesTabPageIndex();
            InitDinamicMenuItems();
        }

        private void SetActualController() {
            if (mainTab.SelectedTab == null)
                return;
            object actualController = mainTab.SelectedTab.Tag;
            if (actualController == null)
                return;
            _mainController.ActualController = actualController;
            regexControl.ReadOnlyRegexMatchCaptionsResult =
                ((RegexControllerBase) actualController).ReadOnlyRegexMatchCaptionsResult;
        }

        private void StoreLastActiveModesTabPageIndex() {
            RegexWorkModes actualMode = ((RegexControllerBase) _mainController.ActualController).RegexWorkMode;
            Preferences.Res.LastActiveModeAsInt = (int) actualMode;
            InitModesMenuItemsBy(actualMode);
        }

        private void InitDinamicMenuItems() {
            object controller = _mainController.ActualController;
            miAppendList.Visible = miPasteList.Visible = miLoadList.Visible = ((controller as ILoadList) != null);
            miCopyUniqueSymbols.Visible = miSaveList.Visible = ((controller as ISaveList) != null);
            miListActionsSeparator.Visible = (miAppendList.Visible || miPasteList.Visible);
            miFileListActionsSeparator.Visible = (miLoadList.Visible || miSaveList.Visible);
            miOpenFile.Visible = ((controller as IOpenFile) != null);
            miFileActionsSeparator.Visible = miOpenFile.Visible;
            miShowSelectedItems.Visible =
                miShowAllItems.Visible = miShowSelectedItemsSep.Visible = ((controller as IShowSelectedItems) != null);
            miSepRegister.Visible =
                miRegister.Visible =
                !( /*<KeyKeyGeneratorCheck1>*/LicenseController.IsRegistered /*</KeyKeyGeneratorCheck1>*/);
            UpdateFavoriteRegexPatternsMenuItems();
        }

        private void UpdateFavoriteRegexPatternsMenuItems() {
            miAddPatternToFavorites.Enabled = !regexControl.PatternIsFavorite ||
                                              (regexControl.PatternIsFavorite && regexControl.PatternIsChanged);
            miUpdatePatternInFavorites.Enabled = (regexControl.PatternIsFavorite && regexControl.PatternIsChanged);
        }

        private void miExit_Click(object sender, EventArgs e) {
            Close();
        }

        private bool Exit() {
            if (Preferences.Res.ConfimOnExit && !Messenger.Confirmed(MsgsBase.Res.Do_you_really_want_to_exit))
                return false;
            LangBase.Close();
            PreferencesBase.Close();
            HistoryRegexPatternsList.Activate().Save();
            return true;
        }

        private void miAbout_Click(object sender, EventArgs e) {
            new AboutForm(_mainController).ShowDialog();
        }

        private void miRegexOptions_Click(object sender, EventArgs e) {
            RegexBarsVisible =
                ((MenuItem) sender).Checked = Preferences.Res.RegexOptions = !Preferences.Res.RegexOptions;
            Preferences.Res.Save();
        }

        private void miToolBars_Click(object sender, EventArgs e) {
            ToolBarsVisible = ((MenuItem) sender).Checked = Preferences.Res.ToolBars = !Preferences.Res.ToolBars;
            Preferences.Res.Save();
        }

        private void miResultWithColors_Click(object sender, EventArgs e) {
            ((MenuItem) sender).Checked =
                Preferences.Res.HighlightResultsInList = !Preferences.Res.HighlightResultsInList;
            Preferences.Res.Save();
        }

        private void miPreferences_Click(object sender, EventArgs e) {
            using (PreferencesForm preferencesForm = new PreferencesForm(_mainController)) {
                try {
                    _mainController.SetHelpProviderFor(preferencesForm, "Preferences");
                    if (preferencesForm.ShowDialog() != DialogResult.OK)
                        return;
                    preferencesForm.ApplayTo(Preferences.Res);
                    if (OnPreferencesUpdated != null)
                        OnPreferencesUpdated(Preferences.Res);
                }
                finally {
                    helpProvider.ResetShowHelp(preferencesForm);
                }
            }
            Preferences.Res.Save();
        }

        private void miHelpIntro_Click(object sender, EventArgs e) {
            _helpHolder.ShowHelp();
        }

        private void miScalePatternUp_Click(object sender, EventArgs e) {
            regexControl.ScaleUp();
        }

        private void miScalePatternDown_Click(object sender, EventArgs e) {
            regexControl.ScaleDown();
        }

        private void miSaveList_Click(object sender, EventArgs e) {
            _mainController.SaveList();
        }

        private void miCopy_Click(object sender, EventArgs e) {
            _mainController.Copy();
        }

        private void miPaste_Click(object sender, EventArgs e) {
            _mainController.Paste();
        }

        private void miPasteList_Click(object sender, EventArgs e) {
            _mainController.PasteList();
        }

        private void miAppendList_Click(object sender, EventArgs e) {
            _mainController.AppendList();
        }

        private void miCut_Click(object sender, EventArgs e) {
            _mainController.Cut();
        }

        private void miOpenFile_Click(object sender, EventArgs e) {
            _mainController.OpenFile();
        }

        private void miClear_Click(object sender, EventArgs e) {
            _mainController.Clear();
        }

        private void miLoadList_Click(object sender, EventArgs e) {
            _mainController.LoadList();
        }

        private void miCopyPat_Click(object sender, EventArgs e) {
            regexControl.Copy();
        }

        private void miPastePat_Click(object sender, EventArgs e) {
            regexControl.Paste();
        }

        private void miCutPat_Click(object sender, EventArgs e) {
            regexControl.Cut();
        }

        private void miClearPat_Click(object sender, EventArgs e) {
            regexControl.Clear();
        }

        private void miCheck_Click(object sender, EventArgs e) {
            regexControl.Check();
        }

        private void miCopyUniqueSymbols_Click(object sender, EventArgs e) {
            _mainController.CopyUniqueSymbols();
        }

        private void miPasteSpecial_Click(object sender, EventArgs e) {
            _mainController.PasteSpecial();
        }

        private void miShowSelectedItems_Click(object sender, EventArgs e) {
            _mainController.ShowSelectedItems();
        }

        private void miShowAllItems_Click(object sender, EventArgs e) {
            _mainController.ShowAllItems();
        }

        private void miAddPatternToFavorites_Click(object sender, EventArgs e) {
            regexControl.AddPatternToFavorites();
        }

        private void miOpenRegexPattern_Click(object sender, EventArgs e) {
            regexControl.OpenRegexPattern(_mainController);
        }

        private void miRegeexPatternHistory_Click(object sender, EventArgs e) {
            regexControl.OpenHistory(_mainController);
        }

        private void miRegexPatternDescription_Click(object sender, EventArgs e) {
            Preferences.Res.RegexPatternsDescriptionIsVisible = regexControl.RegexPatternsDescriptionIsVisible
                                                                = miRegexPatternDescription.Checked
                                                                  = !miRegexPatternDescription.Checked;
            Preferences.Res.Save();
        }

        private void miUpdatePatternInFavorites_Click(object sender, EventArgs e) {
            regexControl.UpdateFavoritePattern();
        }

        private void MenuItem_Popup(object sender, EventArgs e) {
            InitDinamicMenuItems();
        }

        private void MainForm_OnPreferencesUpdated(object item) {
            InitModesTabPagesBy((Preferences) item);
        }

        private void miIsMatch_Click(object sender, EventArgs e) {
            InitModesTabPagesBy(RegexWorkModes.IsMatch);
        }

        private void miMatches_Click(object sender, EventArgs e) {
            InitModesTabPagesBy(RegexWorkModes.Matches);
        }

        private void miCheckByList_Click(object sender, EventArgs e) {
            InitModesTabPagesBy(RegexWorkModes.CheckByList);
        }

        private void miPredefinedPatterns_Click(object sender, EventArgs e) {
            regexControl.OpenPredefined(_mainController);
        }

        private void miLangEnglish_Click(object sender, EventArgs e) {
            ChangeLanguageTo(LangBase.DEFAULT_LANGUAGE_NAME);
        }

        private void ChangeLanguageTo(string languageName) {
            try {
                GuiObjectsCollection.ChangeLanguageTo(languageName, this);
                InitHelpProvider();
                InitLinks();
                DisplayLicState();
            }
            catch (StoredObjectException ex) {
                Messenger.ShowError(ex.Message);
                LangBase.Activate();
            }
        }

        private void miLangRussian_Click(object sender, EventArgs e) {
            ChangeLanguageTo("Russian");
        }

        private void MainForm_Closing(object sender, CancelEventArgs e) {
            if (!Exit())
                e.Cancel = true;
        }

        private void miRegister_Click(object sender, EventArgs e) {
            _mainController.Register();
        }

        private void mainFormController_OnGotKey(string key) {
            DisplayLicState();
        }

        private void miCaptionsResultPattern_Click(object sender, EventArgs e) {
            bool visible = miCaptionsResultPattern.Checked = !miCaptionsResultPattern.Checked;
            Preferences.Res.RegexPatternsResultIsVisible = visible;
            regexControl.RegexPatternsResultIsVisible = visible;
            Preferences.Res.Save();
        }

        private void miInsertSymbolOfPattern_Click(object sender, EventArgs e) {
            regexControl.InsertSymbolOfPattern();
        }
    }
}