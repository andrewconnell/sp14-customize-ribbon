using System;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace MSDN.SharePoint.Samples.ApplyDocumentPrefix {
  public class PageComponentScriptLoader : WebControl {
    /// <summary>
    /// Load page component.
    /// </summary>
    protected override void OnPreRender(EventArgs e) {
      SPRibbon ribbon = SPRibbon.GetCurrent(this.Page);

      // make sure ribbon exists & current list is a document library (otherwise no need for extra JS load)
      if (ribbon != null && SPContext.Current.List is SPDocumentLibrary) {
        // load dependencies if not already don the page
        ScriptLink.RegisterScriptAfterUI(this.Page, "SP.Ribbon.js", false, true);

        // load page component
        ScriptLink.RegisterScriptAfterUI(this.Page, "ApplyDocumentPrefixRibbon/ApplyDocumentPrefix.UI.js", false, true);
      }

      base.OnPreRender(e);
    }
  }
}