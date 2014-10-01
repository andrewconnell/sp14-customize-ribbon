// register the page component object
Type.registerNamespace('ApplyDocumentPrefix');

// helper methods to setup & init the page component
ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent = function ApplyDocumentPrefix_PageComponent() {
  ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.initializeBase(this);
}

ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.initialize = function () {
  ExecuteOrDelayUntilScriptLoaded(Function.createDelegate(null, ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.initializePageComponent), 'SP.Ribbon.js');
}

ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.initializePageComponent = function () {
  var ribbonPageManager = SP.Ribbon.PageManager.get_instance();
  if (ribbonPageManager !== null) {
    ribbonPageManager.addPageComponent(ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.instance);
  }
}

// page component object
ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.prototype = {

  init: function ApplyDocumentPrefix_PageComponento$init() {
    // array of commands that can be handled associated with handler methods
    this.handledCommands = new Object;
    this.handledCommands['ApplyDocumentPrefix.OnApplyDocPrefixPageComponent'] = this.onApplyDocPrefixPageComponent;

    // array of commands that can be handled associated with canHandler methods
    this.canHandledCommands = new Object;
    this.canHandledCommands['ApplyDocumentPrefix.OnApplyDocPrefixPageComponent'] = this.onApplyDocPrefixPageComponent_canExecute;

    // array of commands
    this.commandList = ['ApplyDocumentPrefix.OnApplyDocPrefixPageComponent'];
  },

  getFocusedCommands: function ApplyDocumentPrefixPageComponent_PageComponent$getFocusedCommands() {
    return [];
  },

  getGlobalCommands: function ApplyDocumentPrefixPageComponent_PageComponent$getGlobalCommands() {
    return this.commandList;
  },

  canHandleCommand: function ApplyDocumentPrefixPageComponent_PageComponent$canHandleCommand(commandID) {
    var canHandle = this.handledCommands[commandID];
    if (canHandle)
      return this.canHandledCommands[commandID]();
    else
      return false;
  },

  handleCommand: function ApplyDocumentPrefixPageComponent_PageComponent$handleCommand(commandID, properties, sequence) {
    return this.handledCommands[commandID](commandID, properties, sequence);
  },

  getId: function ApplyDocumentPrefixPageComponent_PageComponent$getId() {
    return "ApplyDocumentPrefixPageComponent";
  },

  onApplyDocPrefixPageComponent: function () {
    var selectedItems = SP.ListOperation.Selection.getSelectedItems();
    var selectedItemIds = '';
    var selectedItemIndex;
    for (selectedItemIndex in selectedItems) {
      selectedItemIds += '|' + selectedItems[selectedItemIndex].id;
    }

    var dialogOptions = {
      url: '/_layouts/ApplyDocumentPrefixRibbon/DocPrefixPrompt.aspx?selectedItems=' + selectedItemIds + '&ListId=' + SP.ListOperation.Selection.getSelectedList(),
      title: 'Set Document Prefix',
      allowMaximize: false,
      showClose: false,
      width: 500,
      height: 400,
      dialogReturnValueCallback: PageComponentCallback
    };

    SP.UI.ModalDialog.showModalDialog(dialogOptions);
  },

  onApplyDocPrefixPageComponent_canExecute: function () {
    var selectedItems = SP.ListOperation.Selection.getSelectedItems();
    var count = CountDictionary(selectedItems);
    return (count > 0);
  }
}

ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.registerClass('ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent', CUI.Page.PageComponent);
ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.instance = new ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent();
ApplyDocumentPrefix.ApplyDocumentPrefixPageComponent.initialize();
SP.SOD.notifyScriptLoadedAndExecuteWaitingJobs("ApplyDocumentPrefix.UI.js");

function PageComponentCallback(dialogResult, returnValue) {
  SP.UI.Notify.addNotification(returnValue);
  SP.UI.ModalDialog.RefreshPage(SP.UI.DialogResult.OK);
}