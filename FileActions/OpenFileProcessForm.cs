using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Security;
using System.Text;
using System.Windows.Forms;
using RegexExplorer;

namespace RegexExplorer {
    public class OpenFileProcessForm : Form {
        private enum CurrentState {
            InProcces,
            Accepted,
            Canceled,
            Paused,
        }

        #region Constants

        private static bool BEGIN_FROM_START = true;

        #endregion

        #region Controls

        private ProgressBar progressBar;
        private Button btnCancel;
        private Label label1;
        private TextBox txtFileName;
        private Label label2;
        private Label label3;
        private TextBox txtFileSize;
        private TextBox txtLoaded;
        private StringBuilder _strBuff = new StringBuilder();
        private IContainer components;
        private FileInfo _fileInfo;
        private Button btnOk;
        private Button btnContinue;
        private Button btnStop;
        private Timer startLoadingTimer;

        #endregion

        #region Fields

        private static int DEFAULT_BUFFER_SIZE = 4096;
        private StreamReader _file;
        private CurrentState _currentState = CurrentState.Paused;
        private char[] _buff = new char[DEFAULT_BUFFER_SIZE];
        private int _length;
        private int _loadedValue;
        private long _size = 0;
        private bool _initialized = false;
        private long _loaded = 0;
        private decimal _step = 0;

        #endregion

        public OpenFileProcessForm(string fileName) : this(fileName, BEGIN_FROM_START) {
        }

        //private while do not be decided to load from end of a file
        private OpenFileProcessForm(string fileName, bool beginFromStart) {
            InitializeComponent();
            btnOk.DialogResult = DialogResult.OK;
            btnCancel.DialogResult = DialogResult.Cancel;
            this.Activated += new EventHandler(OpenFileForm_Activated);
            _fileInfo = new FileInfo(fileName);
            if (!_fileInfo.Exists)
                return;
            _size = _fileInfo.Length;
            _step = _size/100.0m;
            txtFileName.Text = _fileInfo.FullName;
            txtFileSize.Text = (_size/1000).ToString("f3");
            _length = _buff.Length;
            _loaded = (beginFromStart) ? 0 : _size;
            GuiObjectsCollection.ApplyActualLanguageFor(this);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    this.Activated -= new EventHandler(OpenFileForm_Activated);
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
            this.components = new Container();
            ResourceManager resources = new ResourceManager(typeof (OpenFileProcessForm));
            this.progressBar = new ProgressBar();
            this.btnCancel = new Button();
            this.label1 = new Label();
            this.txtFileName = new TextBox();
            this.txtFileSize = new TextBox();
            this.label2 = new Label();
            this.txtLoaded = new TextBox();
            this.label3 = new Label();
            this.btnOk = new Button();
            this.btnContinue = new Button();
            this.btnStop = new Button();
            this.startLoadingTimer = new Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new Point(8, 80);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(408, 23);
            this.progressBar.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.FlatStyle = FlatStyle.System;
            this.btnCancel.Location = new Point(296, 112);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(64, 24);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new Point(-8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new Size(64, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "File name";
            this.label1.TextAlign = ContentAlignment.TopRight;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new Point(64, 8);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new Size(352, 20);
            this.txtFileName.TabIndex = 0;
            this.txtFileName.TabStop = false;
            this.txtFileName.Text = "";
            // 
            // txtFileSize
            // 
            this.txtFileSize.Location = new Point(160, 32);
            this.txtFileSize.Name = "txtFileSize";
            this.txtFileSize.ReadOnly = true;
            this.txtFileSize.Size = new Size(184, 20);
            this.txtFileSize.TabIndex = 1;
            this.txtFileSize.TabStop = false;
            this.txtFileSize.Text = "";
            this.txtFileSize.TextAlign = HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Location = new Point(8, 32);
            this.label2.Name = "label2";
            this.label2.Size = new Size(144, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "File size (k)";
            this.label2.TextAlign = ContentAlignment.TopRight;
            // 
            // txtLoaded
            // 
            this.txtLoaded.Location = new Point(160, 56);
            this.txtLoaded.Name = "txtLoaded";
            this.txtLoaded.ReadOnly = true;
            this.txtLoaded.Size = new Size(184, 20);
            this.txtLoaded.TabIndex = 2;
            this.txtLoaded.TabStop = false;
            this.txtLoaded.Text = "";
            this.txtLoaded.TextAlign = HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new Size(144, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loaded (k)";
            this.label3.TextAlign = ContentAlignment.TopRight;
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = FlatStyle.System;
            this.btnOk.Location = new Point(64, 112);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(64, 24);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Accept";
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.FlatStyle = FlatStyle.System;
            this.btnContinue.Location = new Point(216, 112);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new Size(72, 24);
            this.btnContinue.TabIndex = 6;
            this.btnContinue.Text = "Continue";
            this.btnContinue.Click += new EventHandler(this.btnContinue_Click);
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = FlatStyle.System;
            this.btnStop.Location = new Point(136, 112);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new Size(72, 24);
            this.btnStop.TabIndex = 5;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new EventHandler(this.btnStop_Click);
            // 
            // startLoadingTimer
            // 
            this.startLoadingTimer.Tick += new EventHandler(this.startLoadingTimer_Tick);
            // 
            // OpenFileProcessForm
            // 
            this.AcceptButton = this.btnStop;
            this.AutoScaleBaseSize = new Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new Size(424, 142);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtFileSize);
            this.Controls.Add(this.txtLoaded);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnStop);
            this.Icon = ((Icon) (resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpenFileProcessForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "File is being loaded. Please wait...";
            this.Closing += new CancelEventHandler(this.OpenFileForm_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private void LoadFile() {
            initButtonsForProcess();
            _currentState = CurrentState.InProcces;
            int readBytes = DEFAULT_BUFFER_SIZE;
            try {
                while (_file.Peek() >= 0 && readBytes >= DEFAULT_BUFFER_SIZE) {
                    readBytes = _file.Read(_buff, 0, DEFAULT_BUFFER_SIZE);
                    if (readBytes < DEFAULT_BUFFER_SIZE)
                        _strBuff.Append(_buff, 0, readBytes);
                    else
                        _strBuff.Append(_buff);
                    Application.DoEvents();
                    if (!isInProcces())
                        break;
                    _loaded += readBytes;
                    _loadedValue = Convert.ToInt32(_loaded/_step);
                    _loadedValue = (_loadedValue > progressBar.Maximum) ? progressBar.Maximum : _loadedValue;
                    progressBar.Value = _loadedValue;
                    txtLoaded.Text = (_loaded/1000).ToString("f3");
                    Refresh();
                }
            }
            catch (IOException ex) {
                setCancelled();
                Messenger.ShowError(MsgsBase.Res.File_IO_error_ex, ex);
            }
            catch (OutOfMemoryException ex) {
                setCancelled();
                Messenger.ShowError(MsgsBase.Res.Error_Out_of_memory_ex, ex);
            }
            catch (Exception ex) {
                setCancelled();
                Messenger.ShowError(MsgsBase.Res.Undefined_error_ex, ex);
            }
            finally {
                if (_file != null)
                    _file.Close();
            }
            initButtonsForPause();
            if (_currentState == CurrentState.Canceled) {
                this.DialogResult = DialogResult.Cancel;
                _strBuff = new StringBuilder(0);
                Close();
                return;
            }
            else if (_currentState == CurrentState.Accepted || isInProcces()) {
                this.DialogResult = DialogResult.OK;
                Close();
                return;
            }
        }

        private bool isInProcces() {
            return _currentState == CurrentState.InProcces;
        }

        private void setCancelled() {
            _currentState = CurrentState.Canceled;
        }

        private void initButtonsForProcess() {
            initButtonsFor(true);
        }

        private void initButtonsForPause() {
            initButtonsFor(false);
        }

        private void initButtonsFor(bool inProcess) {
            btnOk.Enabled = btnContinue.Enabled = !inProcess;
            btnStop.Enabled = inProcess;
        }

        public StringBuilder StrBuff {
            get { return _strBuff; }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            setCancelled();
        }

        private void OpenFileForm_Closing(object sender, CancelEventArgs e) {
            _currentState = CurrentState.Canceled;
            e.Cancel = false;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            _currentState = CurrentState.Accepted;
        }

        private void btnStop_Click(object sender, EventArgs e) {
            _currentState = CurrentState.Paused;
        }

        private void btnContinue_Click(object sender, EventArgs e) {
            load();
        }

        private void OpenFileForm_Activated(object sender, EventArgs e) {
            if (_initialized)
                return;
            startLoadingTimer.Enabled = _initialized = true;
        }

        private void startLoadingTimer_Tick(object sender, EventArgs e) {
            startLoadingTimer.Enabled = false;
            load();
            return;
        }

        public void load() {
            if (!openFile())
                return;
            LoadFile();
        }

        private bool openFile() {
            bool isSuccess = true;
            try {
                _file = _fileInfo.OpenText();
            }
            catch (FileNotFoundException ex) {
                ex = ex;
                Messenger.ShowError(MsgsBase.Res.Error_The_file_N_is_not_found, _fileInfo.FullName);
            }
            catch (DirectoryNotFoundException ex) {
                Messenger.ShowError(MsgsBase.Res.Error_The_specified_path_is_invalid_or_unmapped_drive_ex, ex);
            }
            catch (UnauthorizedAccessException ex) {
                Messenger.ShowError(MsgsBase.Res.Error_Path_is_readonly_or_is_a_directory_ex, ex);
            }
            catch (SecurityException ex) {
                Messenger.ShowError(MsgsBase.Res.Error_The_caller_does_not_have_the_required_permission_ex, ex);
            }
            catch (Exception ex) {
                Messenger.ShowError(MsgsBase.Res.Undefined_error_ex, ex);
            }
            finally {
                if (!isSuccess && _file != null)
                    _file.Close();
            }
            return isSuccess;
        }

        public void ClearLoadedText() {
            _strBuff = new StringBuilder(0);
        }
    }
}