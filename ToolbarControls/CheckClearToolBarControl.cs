using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace RegexExplorer.ToolBarControls {
    public class CheckClearToolBarControl : UserControl {
        public event CheckClearEventHandler onClear;

        private ImageList imageList;
        private ToolBar toolBar;
        private ToolBarButton tbtnClear;
        private ToolBarButton tbSeparator;
        private IContainer components;

        public CheckClearToolBarControl() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new Container();
            ResourceManager resources = new ResourceManager(typeof (CheckClearToolBarControl));
            this.imageList = new ImageList(this.components);
            this.toolBar = new ToolBar();
            this.tbtnClear = new ToolBarButton();
            this.tbSeparator = new ToolBarButton();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageSize = new Size(19, 18);
            this.imageList.ImageStream = ((ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = Color.Transparent;
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new ToolBarButton[] {
                                                                  this.tbtnClear,
                                                                  this.tbSeparator
                                                              });
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageList;
            this.toolBar.Location = new Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new Size(32, 30);
            this.toolBar.TabIndex = 0;
            this.toolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbtnClear
            // 
            this.tbtnClear.ImageIndex = 1;
            this.tbtnClear.Tag = "Clear";
            this.tbtnClear.ToolTipText = "Clear";
            // 
            // tbSeparator
            // 
            this.tbSeparator.Style = ToolBarButtonStyle.Separator;
            // 
            // CheckClearToolBarControl
            // 
            this.Controls.Add(this.toolBar);
            this.Name = "CheckClearToolBarControl";
            this.Size = new Size(32, 32);
            this.ResumeLayout(false);
        }

        #endregion

        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            string tag = (e.Button.Tag as string);
            if (tag == null)
                return;
            switch (tag.ToLower()) {
                case "clear":
                    if (onClear != null)
                        onClear();
                    break;
            }
        }
    }
}