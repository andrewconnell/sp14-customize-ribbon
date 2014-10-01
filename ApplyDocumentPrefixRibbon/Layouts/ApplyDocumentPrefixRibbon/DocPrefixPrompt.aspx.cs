using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace MSDN.SharePoint.Samples.ApplyDocumentPrefix {
  public partial class DocPrefixPrompt : LayoutsPageBase {
    List<SPListItem> _selectedListItems = new List<SPListItem>();

    protected override void OnLoad(EventArgs e) {
      // get all the selected documents
      SPList selectedDocumentLibrary = SPContext.Current.Web.Lists[new Guid(Request.QueryString["ListId"])];
      string[] selectedItems = Request.QueryString["selectedItems"].ToString().Split('|');

      for (int index = 1; index < selectedItems.Length; index++) {
        _selectedListItems.Add(selectedDocumentLibrary.GetItemById(int.Parse(selectedItems[index])));
      }

      // bind to the repeater
      SelectedDocumentsDataList.DataSource = _selectedListItems;
      SelectedDocumentsDataList.DataBind();
    }

    protected void OnClickSetPrefixButton(object sender, EventArgs e) {
      foreach (SPListItem listItem in _selectedListItems) {
        listItem["Name"] = DocumentPrefixTextBox.Text + " " + listItem.File.Name;
        listItem.Update();
      }

      CloseDialogOnSuccess();
    }
    private void CloseDialogOnSuccess() {
      ContentPlaceHolder pageHead = this.Master.FindControl("PlaceHolderAdditionalPageHead") as ContentPlaceHolder;
      if (pageHead != null)
        pageHead.Controls.Add(new LiteralControl("<script language='javascript'>ExecuteOrDelayUntilScriptLoaded(closeDialog,'sp.js');function closeDialog(){SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.OK, 'Prefix assigned to selected doc uments.');}</script>"));
    }
  }
}