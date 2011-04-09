using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace RegexExplorer.ToolBarControls {
    public class FileToolBarControl : UserControl {
        #region Controls

        private ImageList imageList;
        private ToolBar toolBar;
        private ToolBarButton tbtnSaveFile;
        private ToolBarButton tbtnSeparator;
        private ToolBarButton tbtnOpenFile;
        private IContainer components;

        #endregion

        public event EditionEventHandler OnSaveFile;
        public event EditionEventHandler OnOpenFile;

        public FileToolBarControl() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public bool OpenFileVisible {
            get { return tbtnOpenFile.Visible; }
            set { tbtnOpenFile.Visible = value; }
        }

        public bool SaveFileVisible {
            get { return tbtnSaveFile.Visible; }
            set { tbtnSaveFile.Visible = value; }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FileToolBarControl));
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.tbtnOpenFile = new System.Windows.Forms.ToolBarButton();
            this.tbtnSaveFile = new System.Windows.Forms.ToolBarButton();
            this.tbtnSeparator = new System.Windows.Forms.ToolBarButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
                                                                                       this.tbtnOpenFile,
                                                                                       this.tbtnSaveFile,
                                                                                       this.tbtnSeparator});
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageList;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(56, 30);
            this.toolBar.TabIndex = 0;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbtnOpenFile
            // 
            this.tbtnOpenFile.ImageIndex = 0;
            this.tbtnOpenFile.Tag = "OpenFile";
            this.tbtnOpenFile.ToolTipText = "Open file";
            // 
            // tbtnSaveFile
            // 
            this.tbtnSaveFile.ImageIndex = 1;
            this.tbtnSaveFile.Tag = "SaveFile";
            this.tbtnSaveFile.ToolTipText = "Save file";
            // 
            // tbtnSeparator
            // 
            this.tbtnSeparator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(19, 18);
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // FileToolBarControl
            // 
            this.Controls.Add(this.toolBar);
            this.Name = "FileToolBarControl";
            this.Size = new System.Drawing.Size(56, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            string tag = (e.Button.Tag as string);
            if (tag == null)
                return;
            switch (tag.ToLower()) {
                case "savefile":
                    if (OnSaveFile != null)
                        OnSaveFile();
                    break;
                case "openfile":
                    if (OnOpenFile != null)
                        OnOpenFile();
                    break;
            }
        }
    }
}