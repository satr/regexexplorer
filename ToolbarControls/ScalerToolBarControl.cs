using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace RegexExplorer.ToolBarControls {
    public class ScalerToolBarControl : UserControl {
        public event ScaleUpDownEventHandler onScaleUp;
        public event ScaleUpDownEventHandler onScaleDown;

        private ToolBar toolBar;
        private ImageList imageList;
        private ToolBarButton tbtnScaleUp;
        private ToolBarButton tbtnScaleDown;
        private IContainer components;

        public ScalerToolBarControl() {
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

        #region Component Designer generated code

        private void InitializeComponent() {
            this.components = new Container();
            ResourceManager resources = new ResourceManager(typeof (ScalerToolBarControl));
            this.toolBar = new ToolBar();
            this.tbtnScaleUp = new ToolBarButton();
            this.tbtnScaleDown = new ToolBarButton();
            this.imageList = new ImageList(this.components);
            this.SuspendLayout();
            // 
            // toolBar
            // 
            this.toolBar.Buttons.AddRange(new ToolBarButton[] {
                                                                  this.tbtnScaleUp,
                                                                  this.tbtnScaleDown
                                                              });
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.imageList;
            this.toolBar.Location = new Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new Size(56, 30);
            this.toolBar.TabIndex = 0;
            this.toolBar.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // tbtnScaleUp
            // 
            this.tbtnScaleUp.ImageIndex = 0;
            this.tbtnScaleUp.Tag = "ScaleUp";
            this.tbtnScaleUp.ToolTipText = "Scale up";
            // 
            // tbtnScaleDown
            // 
            this.tbtnScaleDown.ImageIndex = 1;
            this.tbtnScaleDown.Tag = "ScaleDown";
            this.tbtnScaleDown.ToolTipText = "Scale down";
            // 
            // imageList
            // 
            this.imageList.ImageSize = new Size(19, 18);
            this.imageList.ImageStream = ((ImageListStreamer) (resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = Color.Transparent;
            // 
            // ScalerToolBarControl
            // 
            this.Controls.Add(this.toolBar);
            this.Name = "ScalerToolBarControl";
            this.Size = new Size(56, 32);
            this.ResumeLayout(false);
        }

        #endregion

        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
            string tag = (e.Button.Tag as string);
            if (tag == null)
                return;
            switch (tag.ToLower()) {
                case "scaleup":
                    if (onScaleUp != null)
                        onScaleUp();
                    break;
                case "scaledown":
                    if (onScaleDown != null)
                        onScaleDown();
                    break;
            }
        }
    }
}