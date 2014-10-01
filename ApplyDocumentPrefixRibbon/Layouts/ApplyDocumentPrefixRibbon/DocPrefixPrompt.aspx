<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=14.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocPrefixPrompt.aspx.cs" Inherits="MSDN.SharePoint.Samples.ApplyDocumentPrefix.DocPrefixPrompt" DynamicMasterPageFile="~masterurl/default.master" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormSection" Src="~/_controltemplates/InputFormSection.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="InputFormControl" src="~/_controltemplates/InputFormControl.ascx" %>
<%@ Register TagPrefix="wssuc" TagName="ButtonSection" Src="~/_controltemplates/ButtonSection.ascx" %>

<asp:Content ID="Main" ContentPlaceHolderID="PlaceHolderMain" runat="server">
  <table border="0" cellspacing="0" cellpadding="0" width="100%">
    <tr>
      <td>
        <wssuc:InputFormSection runat="server" 
                                Title="Selected Documents" 
                                Description="The following documents have been selected to have the specified prefix added to their titles.">
          <Template_InputFormControls>
			      <tr>
			        <td>
			          <asp:DataList ID="SelectedDocumentsDataList" runat="server" RepeatColumns="2" CellPadding="2" CellSpacing="5">
                  <ItemTemplate><li><%# DataBinder.Eval(Container.DataItem, "File.Name").ToString()%></li></ItemTemplate>
                </asp:DataList>
			        </td>
			      </tr>
		      </Template_InputFormControls>
        </wssuc:InputFormSection>

        <wssuc:InputFormSection runat="server" 
                                Title="Document Prefix" 
                                Description="Prefix to add to the selected document titles.">
          <Template_InputFormControls>
            <wssuc:InputFormControl LabelText="Prefix to add to the selected documents:" runat="server">
              <Template_control>
                <asp:TextBox ID="DocumentPrefixTextBox" runat="server" />
              </Template_control>
            </wssuc:InputFormControl>
		      </Template_InputFormControls>
        </wssuc:InputFormSection>

        <wssuc:ButtonSection runat="server" ShowStandardCancelButton="FALSE" TopButtons="TRUE">
          <Template_Buttons>
            <asp:Button ID="SetPrefixButton" class="ms-ButtonHeightWidth" runat="server" Text="Set Prefix" OnClick="OnClickSetPrefixButton" />
            <asp:Button ID="CancelButton" class="ms-ButtonHeightWidth" runat="server" Text="Cancel" OnClientClick="SP.UI.ModalDialog.commonModalDialogClose(SP.UI.DialogResult.cancel,'Assignment of prefix cancelled.'); return false;" />
          </Template_Buttons>
        </wssuc:ButtonSection>
      </td>
    </tr>
  </table></asp:Content>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PlaceHolderPageTitle" runat="server">
Application Page
</asp:Content>

<asp:Content ID="PageTitleInTitleArea" ContentPlaceHolderID="PlaceHolderPageTitleInTitleArea" runat="server" >
My Application Page
</asp:Content>
