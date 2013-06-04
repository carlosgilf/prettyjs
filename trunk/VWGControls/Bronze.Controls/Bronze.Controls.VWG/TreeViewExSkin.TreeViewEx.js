/// <method name="TreeView_HandleEvent">
/// <summary>
/// 
/// </summary>
function TreeViewEx_HandleEvent(strGuid, strTreeViewGuid, strEvent, objWindow, objEvent) {
    // Get the event source
    var objSource = Web_GetEventSource(objEvent);

    // If there is a valid event source
    if (objSource) {
        // Get the source type
        var strSourceType = Web_GetAttribute(objSource, "vwgtype");

        // If is a key down event
        if (strEvent == "keydown") {
            TreeViewEx_KeyDown(strGuid, objWindow, objEvent);
        }
        else {
            // Check the source type
            switch (strSourceType) {
                case "label":
                case "text":
                case "icon":
                    switch (strEvent) {
                        case "mousedown":
                            //check if its right click
                            if (Web_IsRightClick(objEvent)) {
                                //get tree node XML
                                var objNode = Data_GetNode(strGuid);

                                //search SelectOnRightClick attribute all the node path to the tree view
                                objNode = Xml_SelectSingleNode("ancestor-or-self::*[@Attr.Id=" + strTreeViewGuid + "or @Attr.SelectOnRightClick!=''][1]", objNode);

                                //check if the current node have SelectOnRightClick
                                if (Xml_IsAttribute(objNode, "Attr.SelectOnRightClick", "1")) {
                                    TreeViewEx_DoNodeAction(strGuid, objWindow, false, objEvent);
                                }
                            }
                            break;

                        case "click":
                            TreeViewEx_DoNodeAction(strGuid, objWindow, false, objEvent);
                            break;
                    }
                    break;

                case "joint":
                    if (strEvent == "click") {
                        var strClickSourceId = strGuid;
                        var objClickSource = null;

                        // Check if not in winforms compatible mode (toggling should fire click on tree node).
                        if (!mblnWinFormsCompatible) {
                            strClickSourceId = strTreeViewGuid;

                            // Get treeview element
                            objClickSource = Web_GetElementByDataId(strClickSourceId, objWindow);
                        }

                        // Toggle tree node and if the toggle or the click are critical call Web_OnClick
                        if (TreeView_Toggle(strGuid, objWindow, objEvent, true) || Data_IsCriticalEvent(strClickSourceId, mcntEventClickId)) {
                            Web_OnClick(objEvent, objWindow, true, objClickSource);
                        }
                        else {
                            //cancel bubble
                            Web_EventCancelBubble(objEvent);
                        }
                    }
                    else if (strEvent == "dblclick") {
                        // Check if not in winforms compatible mode (toggling should fire Dblclick on tree node).
                        if (!mblnWinFormsCompatible) {
                            //check if the DoubleClick event is critical
                            if (Data_IsCriticalEvent(strTreeViewGuid, mcntEventDoubleClickId)) {
                                //fire DoubleClick with the TreeView as source
                                Web_OnDblClick(objEvent, objWindow, true, Web_GetElementByDataId(strTreeViewGuid, objWindow));
                            }
                            else {
                                //cancel bubble
                                Web_EventCancelBubble(objEvent);
                            }
                        }
                    }
                    break;

                case "checkbox":
                    if (strEvent == "click") {
                        TreeView_Checked(strGuid, objSource, objWindow);
                    }
                    break;
            }
        }
    }
}
/// </method>






/// <method name="TreeViewEx_DoNodeAction">
/// <summary>
/// Handles the node click / double click / keydown events
/// </summary>
function TreeViewEx_DoNodeAction(strCurrentNodeDataId, objWindow, blnIsKeyboard, objEvent) {
    // Exit on disabled control
    if (!Data_IsDisabled(strCurrentNodeDataId)) {
        // Get the node which is to be selected
        var objCurrentNode = Data_GetNode(strCurrentNodeDataId);
        if (objCurrentNode) {
            var nodeText = Xml_GetAttribute(objCurrentNode, "Attr.Text");
            if (nodeText == "" || nodeText == null) {
                return;
            }
            
            // Get tree view node
            var objTreeViewNode = TreeView_GetTreeViewFromNode(objCurrentNode);

            // Define an empty previous node data id.
            var strPreviousNodeDataId = "";

            // Get previously selected node.
            var objPreviousNode = Xml_SelectSingleNode("./" + "/TN[@Attr.Selected='1']", objTreeViewNode);
            if (objPreviousNode) {
                // Get previously selected node id
                strPreviousNodeDataId = Xml_GetAttribute(objPreviousNode, "Attr.Id", "");
            }

            // If node has been changed.
            if (strPreviousNodeDataId != strCurrentNodeDataId) {
                // Check if label editing is enabled.
                var blnLabelEditingEnabled = Xml_IsAttribute(objTreeViewNode, "Attr.LabelEdit", "1");

                // Validate previous node data id.
                if (!Aux_IsNullOrEmpty(strPreviousNodeDataId)) {
                    // Set previos node's selected attribute value.
                    Xml_SetAttribute(objPreviousNode, "Attr.Selected", "0");

                    // Apply a proper icon to the previos node element.
                    TreeView_ApplyIcon(objPreviousNode, objWindow);

                    // Get previously selected node element.
                    var objPreviousElement = Web_GetWebElement("VWGNODE_" + strPreviousNodeDataId, objWindow);
                    if (objPreviousElement) {
                        // Apply unselected style on previos node's element.
                        //Web_SetUnselectedElement(objPreviousElement, objWindow);

                        //jrt Add: select full line options
                        var isSelectFullLine = Xml_IsAttribute(objTreeViewNode, "selectFullLine", "1");
                        var preSelectElement = objPreviousElement;
                        if (isSelectFullLine) {
                            preSelectElement = Web_GetWebElement("VWGTXT_" + strPreviousNodeDataId, objWindow)
                        }
                        Web_SetUnselectedElement(preSelectElement, objWindow);
                        Web_SetUnselectedElement(objPreviousElement, objWindow);
                    }

                    if (blnLabelEditingEnabled) {
                        // Get previous label element.
                        var objPreviousLabelElement = Web_GetWebElement("VWGLE_" + strPreviousNodeDataId, objWindow);
                        if (objPreviousLabelElement) {
                            // Flag that previous label element is not editable.
                            Web_SetAttribute(objPreviousLabelElement, "vwglabeledit", "0");
                        }
                    }
                }

                // Set current node's selected attribute value.
                Xml_SetAttribute(objCurrentNode, "Attr.Selected", "1");

                // Apply a proper icon to the current node element.
                TreeView_ApplyIcon(objCurrentNode, objWindow);

                // Get current tree node
                var objCurrentElement = Web_GetWebElement("VWGNODE_" + strCurrentNodeDataId, objWindow);
                if (objCurrentElement) {
                    // Scroll iinto view.
                    Web_ScrollIntoView(objCurrentElement);

                    //jrt Add: select full line options
                    var isSelectFullLine = Xml_IsAttribute(objTreeViewNode, "selectFullLine", "1");
                    var currSelectElement = objCurrentElement;
                    if (isSelectFullLine) {
                        var currSelectElement = Web_GetWebElement("VWGTXT_" + strCurrentNodeDataId, objWindow)
                    }
                    Web_SetSelectedElement(currSelectElement, objWindow);
                }

                if (blnLabelEditingEnabled) {
                    // Get current label element.
                    var objCurrentLabelElement = Web_GetWebElement("VWGLE_" + strCurrentNodeDataId, objWindow);
                    if (objCurrentLabelElement) {
                        // Flag that current label element is editable asynchronicly so that current click won't start editing.
                        Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Web_SetAttribute, objCurrentLabelElement, "vwglabeledit", "1"), 10);
                    }
                }

                // Create a selection change event.
                var objActionEvent = Events_CreateEvent(strCurrentNodeDataId, "Selection", null, true, true);

                // Flag if keyboard source.
                if (blnIsKeyboard) {
                    Events_SetEventAttribute(objActionEvent, "Keyboard", "1");
                }

                // Check if selection change is critical.     
                if (Data_IsCriticalEvent(strCurrentNodeDataId, mcntEventSelectionChangeId)) {
                    if (blnIsKeyboard) {
                        // Add a key down event and raise events.
                        Web_OnKeyDown(objEvent, objWindow, true)
                    }
                    else {
                        if (Web_IsRightClick(objEvent)) {
                            // if Right Click is critical then the context menu right click will raise the event
                            if (!Data_IsCriticalEvent(strCurrentNodeDataId, mcntEventRightClickId)) {
                                // Add a right click event and raise events.
                                Web_OnRightClick(objEvent, objWindow, true);
                            }
                        }
                        else {
                            // Add a click event and raise events.
                            Web_OnClick(objEvent, objWindow, true);
                        }
                    }
                }
            }
        }
    }
}


/// <method name="TreeViewEx_KeyDown">
/// <summary>
/// Handles node keydown
/// </summary>
function TreeViewEx_KeyDown(strGuid, objWindow, objEvent) {
    // find selected node in treeview
    var objTreeViewNode = Data_GetNode(strGuid);
    var objNode = Xml_SelectSingleNode(".//Tags.TreeNode[@Attr.Selected='1']", objTreeViewNode);

    // Get key code
    var intKeyCode = Web_GetEventKeyCode(objEvent);
    if (!objNode || !intKeyCode) {
        return;
    }

    if (Web_IsNavigationKey(intKeyCode)) {
        var objCurrentNode = null;

        switch (intKeyCode) {
            case mcntLeftKey:
                objCurrentNode = TreeView_MoveLeft(objNode, objWindow, objEvent);
                break;
            case mcntUpKey:
                objCurrentNode = TreeView_MoveUp(objNode);
                break;
            case mcntRightKey:
                objCurrentNode = TreeView_MoveRight(objNode, objWindow, objEvent);
                break;
            case mcntDownKey:
                objCurrentNode = TreeView_MoveDown(objNode);
                break;
            case mcntEndKey:
                objCurrentNode = TreeView_MoveEnd(objTreeViewNode);
                break;
            case mcntHomeKey:
                objCurrentNode = TreeView_MoveHome(objTreeViewNode);
                break;
            case mcntPageUpKey:
                objCurrentNode = TreeView_PageUp(objNode);
                break;
            case mcntPageDownKey:
                objCurrentNode = TreeView_PageDown(objNode);
                break;
        }

        if (objCurrentNode) {
            TreeView_DoNodeAction(Xml_GetAttribute(objCurrentNode, "Attr.Id"), objWindow, true, objEvent);
        }

        // Cancel default scrolling functionality.
        Web_EventCancelBubble(objEvent, true, false);
    }
}
/// </method>