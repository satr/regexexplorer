using System.ComponentModel;
using System.Windows.Forms;

namespace RegexExplorer.ToolBarControls {
  public class EditToolBarControl : UserControl {
    public event EditionEventHandler onCopy;
    public event EditionEventHandler onCut;
    public event EditionEventHandler onPaste;

    private ImageList imageList;
    private ToolBar toolBar;
    private ToolBarButton tbtnCopy;
    private ToolBarButton tbtnCut;
    private ToolBarButton tbtnPaste;
    private ToolBarButton tbSeparator;
    private IContainer components;

    public EditToolBarControl() {
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (EditToolBarControl));
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.toolBar = new System.Windows.Forms.ToolBar();
      this.tbtnCopy = new System.Windows.Forms.ToolBarButton();
      this.tbtnCut = new System.Windows.Forms.ToolBarButton();
      this.tbtnPaste = new System.Windows.Forms.ToolBarButton();
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
        this.tbtnCopy,
        this.tbtnCut,
        this.tbtnPaste,
        this.tbSeparator
      });
      this.toolBar.DropDownArrows = true;
      this.toolBar.ImageList = this.imageList;
      this.toolBar.Location = new System.Drawing.Point(0, 0);
      this.toolBar.Name = "toolBar";
      this.toolBar.ShowToolTips = true;
      this.toolBar.Size = new System.Drawing.Size(88, 30);
      this.toolBar.TabIndex = 0;
      this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
      // 
      // tbtnCopy
      // 
      this.tbtnCopy.ImageIndex = 0;
      this.tbtnCopy.Tag = "Copy";
      this.tbtnCopy.ToolTipText = "Copy";
      // 
      // tbtnCut
      // 
      this.tbtnCut.ImageIndex = 1;
      this.tbtnCut.Tag = "Cut";
      this.tbtnCut.ToolTipText = "Cut";
      // 
      // tbtnPaste
      // 
      this.tbtnPaste.ImageIndex = 2;
      this.tbtnPaste.Tag = "Paste";
      this.tbtnPaste.ToolTipText = "Paste";
      // 
      // tbSeparator
      // 
      this.tbSeparator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
      // 
      // EditToolBarControl
      // 
      this.Controls.Add(this.toolBar);
      this.Name = "EditToolBarControl";
      this.Size = new System.Drawing.Size(88, 32);
      this.ResumeLayout(false);

    }

    #endregion

    private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
      string tag = (e.Button.Tag as string);
      if (tag == null)
        return;
      switch (tag.ToLower()){
        case "copy":
          if (onCopy != null)
            onCopy();
          break;
        case "cut":
          if (onCut != null)
            onCut();
          break;
        case "paste":
          if (onPaste != null)
            onPaste();
          break;
      }
    }
  }
}