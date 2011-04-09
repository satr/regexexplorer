using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace RegexExplorer.ToolBarControls {
    public class ListToolBarControl : UserControl {
        public event EditionEventHandler onPasteList;
        public event EditionEventHandler onAppendList;
        public event EditionEventHandler onLoadList;
        public event EditionEventHandler onSaveList;

        #region Controls

        private ToolBar toolBar;
        private ImageList imageList;
        private ToolBarButton tbtnPasteList;
        private ToolBarButton tbtnAppendList;
        private ToolBarButton tbtnSeparator2;
        private ToolBarButton tbtnSeparator1;
        private ToolBarButton tbtnLoadList;
        private ToolBarButton tbtnSaveList;
        private IContainer components;

        #endregion

        public ListToolBarControl() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        public bool pasteListVisible {
            get { return tbtnPasteList.Visible; }
            set { tbtnPasteList.Visible = value; }
        }

        public bool appendListVisible {
            get { return tbtnAppendList.Visible; }
            set { tbtnAppendList.Visible = value; }
        }

        public bool saveListVisible {
            get { return tbtnSaveList.Visible; }
            set { tbtnSaveList.Visible = value; }
        }

        public bool loadListVisible {
            get { return tbtnLoadList.Visible; }
            set { tbtnLoadList.Visible = value; }
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new Container();
            ResourceManager resources = new ResourceManager(typeof (ListToolBarControl));
            this.toolBar = new ToolBar();
            this.tbtnPasteList = new ToolBarButton();
            this.tbtnAppendList = new ToolBarButton();
            this.tbtnSeparator2 = new ToolBarButton();
            this.imageList = new ImageList(this.components);
            this.tbtnSeparator1 = new ToolBarButton();
            this.tbtnLoadList = new ToolBarButton();
            this.tbtnSaveList = new ToolBarButton();
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new ToolBarButton[] {
                                                                  this.tbtnLoadList,
                                                                  this.tbtnSaveList,
                                                                  this.tbtnSeparator1,
                                                                  this.tbtnPasteList,
                                                                  this.tbtnAppendList,
                                                                  this.tbtnSeparator2
                                                              });
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageList;
            this.toolBar.Location = new Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new Size(120, 30);
            this.toolBar.TabIndex = 0;
            this.toolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbtnPasteList
            // 
            this.tbtnPasteList.ImageIndex = 0;
            this.tbtnPasteList.Tag = "PasteList";
            this.tbtnPasteList.ToolTipText = "Paste list";
            // 
            // tbtnAppendList
            // 
            this.tbtnAppendList.ImageIndex = 1;
            this.tbtnAppendList.Tag = "AppendList";
            this.tbtnAppendList.ToolTipText = "Append list";
            // 
            // tbtnSeparator2
            // 
            this.tbtnSeparator2.Style = ToolBarButtonStyle.Separator;
            // 
            // imageList
            // 
            this.imageList.ImageSize = new Size(19, 18);
            this.imageList.ImageStream = ((ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = Color.Transparent;
            // 
            // tbtnSeparator1
            // 
            this.tbtnSeparator1.Style = ToolBarButtonStyle.Separator;
            // 
            // tbtnLoadList
            // 
            this.tbtnLoadList.ImageIndex = 2;
            this.tbtnLoadList.Tag = "LoadList";
            this.tbtnLoadList.ToolTipText = "Load list";
            // 
            // tbtnSaveList
            // 
            this.tbtnSaveList.ImageIndex = 3;
            this.tbtnSaveList.Tag = "SaveList";
            this.tbtnSaveList.ToolTipText = "Save list";
            // 
            // ListToolBarControl
            // 
            this.Controls.Add(this.toolBar);
            this.Name = "ListToolBarControl";
            this.Size = new Size(120, 32);
            this.ResumeLayout(false);
        }

        #endregion

        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            string tag = (e.Button.Tag as string);
            if (tag == null)
                return;
            switch (tag.ToLower()) {
                case "loadlist":
                    if (onLoadList != null)
                        onLoadList();
                    break;
                case "savelist":
                    if (onSaveList != null)
                        onSaveList();
                    break;
                case "pastelist":
                    if (onPasteList != null)
                        onPasteList();
                    break;
                case "appendlist":
                    if (onAppendList != null)
                        onAppendList();
                    break;
            }
        }
    }
}