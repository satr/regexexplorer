using System.ComponentModel;
using System.Windows.Forms;

namespace RegexExplorer.ToolBarControls {
  public class ListToolBarControl : UserControl {
    public event EditionEventHandler onPasteList;
    public event EditionEventHandler onAppendList;

    #region Controls

    private ToolBar toolBar;
    private ImageList imageList;
    private ToolBarButton tbtnPasteList;
    private ToolBarButton tbtnSeparator;
    private ToolBarButton tbtnAppendList;
    private IContainer components;

    #endregion

    public ListToolBarControl() {
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
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof (ListToolBarControl));
      this.toolBar = new System.Windows.Forms.ToolBar();
      this.tbtnPasteList = new System.Windows.Forms.ToolBarButton();
      this.tbtnSeparator = new System.Windows.Forms.ToolBarButton();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.tbtnAppendList = new System.Windows.Forms.ToolBarButton();
      this.SuspendLayout();
      // 
      // toolBar
      // 
      this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[]{
        this.tbtnPasteList,
        this.tbtnAppendList,
        this.tbtnSeparator
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
      // tbtnPasteList
      // 
      this.tbtnPasteList.ImageIndex = 0;
      this.tbtnPasteList.Tag = "PasteList";
      this.tbtnPasteList.ToolTipText = "Paste list";
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
      // tbtnAppendList
      // 
      this.tbtnAppendList.ImageIndex = 1;
      this.tbtnAppendList.Tag = "AppendList";
      this.tbtnAppendList.ToolTipText = "Append list";
      // 
      // ListToolBarControl
      // 
      this.Controls.Add(this.toolBar);
      this.Name = "ListToolBarControl";
      this.Size = new System.Drawing.Size(64, 32);
      this.ResumeLayout(false);

    }

    #endregion

    private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e) {
      string tag = (e.Button.Tag as string);
      if (tag == null)
        return;
      switch (tag.ToLower()){
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