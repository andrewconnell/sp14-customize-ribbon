using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace WebPartRibbonContextualTab.RibbonizedWebPart {
  [ToolboxItemAttribute(false)]
  public class RibbonizedWebPart : WebPart {
    private string POSTBACK_EVENT = "RibbonizedWebPartPostback";

    protected override void CreateChildControls() {
      this.Controls.Add(new LiteralControl("<em>Ribbonized Web Part contents go here</em>"));

      // handle postback from ribbon 
      HandleRibbonPostback();
    }

    protected override void OnPreRender(EventArgs e) {
      LoadAndActivateRibbonContextualTab();

      base.OnPreRender(e);
    }

    /// <summary>
    /// Activates the ribbon tab.
    /// </summary>
    private void LoadAndActivateRibbonContextualTab() {
      SPRibbon ribbon = SPRibbon.GetCurrent(this.Page);
      // make sure ribbon exists
      if (ribbon != null) {
        // load dependencies if not already don the page
        ScriptLink.RegisterScriptAfterUI(this.Page, "SP.Ribbon.js", false, true);

        // load & activate contextual tab
        ribbon.MakeTabAvailable("Ribbon.PropertyChangerTab");
        ribbon.MakeContextualGroupInitiallyVisible("Ribbon.WebPartContextualTabGroup", string.Empty);
      }
    }

    private void HandleRibbonPostback() {
      if (this.Page.Request["__EVENTTARGET"] == POSTBACK_EVENT) {
        this.Controls.Add(new LiteralControl("<p>Responding to postback event from ribbon.</p>"));
      }
    }
  }
}
