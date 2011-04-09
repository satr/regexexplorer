using System.ComponentModel;
using System.Windows.Forms;

namespace RegexExplorer.ToolBarControls {
  public class CheckClearToolBarControl : UserControl {
    public event CheckClearEventHandler onCheck;
    public event CheckClearEventHandler onClear;

    private ImageList imageList;
    private ToolBar toolBar;
    private ToolBarButton tbtnCheck;
    private ToolBarButton tbtnClear;
    private ToolBarButton tbSeparator;
    private IContainer components;

    public CheckClearToolBarControl() {
      InitializeComponent();
    }

    protected override void Dispose(bool disposing) {
      if (disposing){
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
      this.components = new System.ComponentModel.Container();
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (CheckClearToolBarControl));
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.toolBar = new System.Windows.Forms.ToolBar();
      this.tbtnCheck = new System.Windows.Forms.ToolBarButton();
      this.tbtnClear = new System.Windows.Forms.ToolBarButton();
      this.tbSeparator = new System.Windows.Forms.ToolBarButton();
      this.SuspendLayout();
      // 
      // imageList
      // 
      this.imageList.ImageSize = new System.Drawing.Size(19, 18);
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      // 
      // toolBar
      // 
      this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[]{
        this.tbtnCheck,
        this.tbtnClear,
        this.tbSeparator
      });
      this.toolBar.DropDownArrows = true;
      this.toolBar.ImageList = this.imageList;
      this.toolBar.Location = new System.Drawing.Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.ShowToolTips = true;
      this.toolBar.Size = new System.Drawing.Size(64, 30);
      this.toolBar.TabIndex = 0;
      this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
      // 
      // tbtnCheck
      // 
      this.tbtnCheck.ImageIndex = 0;
      this.tbtnCheck.Tag = "Check";
      this.tbtnCheck.ToolTipText = "Check";
      // 
      // tbtnClear
      // 
      this.tbtnClear.ImageIndex = 1;
      this.tbtnClear.Tag = "Clear";
      this.tbtnClear.ToolTipText = "Clear";
      // 
      // tbSeparator
      // 
      this.tbSeparator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
      // 
      // CheckClearToolBarControl
      // 
      this.Controls.Add(this.toolBar);
      this.Name = "CheckClearToolBarControl";
      this.Size = new System.Drawing.Size(64, 32);
      this.ResumeLayout(false);

    }

    #endregion

    private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
      string tag = (e.Button.Tag as string);
      if (tag == null)
        return;
      switch (tag.ToLower()){
        case "check":
          if (onCheck != null)
            onCheck();
          break;
        case "clear":
          if (onClear != null)
            onClear();
          break;
      }
    }
  }
}