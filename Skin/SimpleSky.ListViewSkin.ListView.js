/// <parameters>
/// <summary>
/// Global parameters
/// </summary>
var mobjListViewObjectRect = null;
var mobjListViewObject1 = null;
var mobjListViewObject2 = null;
var mstrListViewDataId = null;
/// </parameters>

/// <page name="ListView.js">
/// <summary>
/// This script is used as a shared list view script.
/// </summary>

/// <method name="ListView_Select">
/// <summary>
/// Calls ListServices List_Select method which
/// selects element based on strId
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strId"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <returns>undefined</returns>
function ListView_Click(strGuid, strId, objWindow, objEvent) {
    // Get the pressed key
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // Executig selection of list item
    ListView_Select(strGuid, strId, objWindow, Web_IsShift(objEvent), Web_IsControl(objEvent), true);

    // If click and doubleclick are not critical and the selected index change event is critical - raise events.
    if (Data_IsCriticalEvent(strGuid, mcntEventSelectionChangeId)) {
        // Handles the click event and forces raise (this 'overload' cancels the click bubble.
        Web_OnClick(objEvent, objWindow, true);
    }
}
/// </method>

/// <method name="ListView_SelectAsync">
/// <summary>
/// Calls ListServices List_Select method which
/// selects element based on strId
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strId"></param>
/// <param name="objWindow"></param>
/// <param name="blnShiftKey"></param>
/// <param name="blnCtrlKey"></param>
/// <returns>undefined</returns>
function ListView_Select(strGuid, strId, objWindow, blnShiftKey, blnCtrlKey, blnSuspendRaiseEvents, intKeyCode) {
    // Exit on disabled control
    if (Data_IsDisabled(strGuid)) return;

    // Get the multiselect attribute.
    var objNode = Data_GetNode(strGuid);
    var blnMultiple = Xml_IsAttribute(objNode, "Attr.Multiple", "1");

    List_Click(strGuid, strId, (blnMultiple ? 0 : 3), false, false, objWindow, blnShiftKey, blnCtrlKey, blnSuspendRaiseEvents);
}
/// </method>

/// <method name="ListView_IsClickable">
/// <summary>
/// 
/// </summary>
function ListView_IsClickableColumn(strGuid) {
    var blnIsClickableColumn = false;

    // Get data node
    var objColumnNode = Data_GetNode(Data_GetDataId(strGuid));

    if (objColumnNode && objColumnNode.parentNode) {
        blnIsClickableColumn = (Xml_GetAttribute(objColumnNode.parentNode, "Attr.HeaderStyle") == "2");
    }

    // Check header style.
    return blnIsClickableColumn;
}
/// </method>


/// <method name="ListViewHeaderClick">
/// Sorts ListView by the ColumnHeader clicked
/// <summary>
/// Handler list view header click
/// </summary>
/// <param name="objListViewColumn"></param>
/// <param name="">strGuid</param>
/// <returns>undefined</returns>
function ListView_HeaderClick(objListViewColumn, strGuid) {
    // Exit on disabled or none clickable control.
    if (Data_IsDisabled(strGuid) || !ListView_IsClickableColumn(strGuid)) return;

    var objEvent = Events_CreateEvent(objListViewColumn.id, "Sort");
    Events_RaiseEvents();
}
/// </method>


/// <method name="ListView_KeyDown">
/// Handles keypad navigation 
/// Supports List, Details, LargeIcon and SmallIcon views
/// <summary>
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <returns>undefined</returns>
function ListView_KeyDown(strGuid, objWindow, objEvent) {
    // Exit on disabled control
    if (Data_IsDisabled(strGuid)) return;

    // Get the pressed key
    var intKeyCode = Web_GetEventKeyCode(objEvent);

    // handle navigation keys
    if (Web_IsNavigationKey(intKeyCode)) {
        // Get ListView node
        var objNode = Data_GetNode(strGuid);

        if (objNode) {
            // get data row nodes
            var objItems = Xml_SelectNodes("Tags.Row", objNode);

            // Get selected items.
            var objSelectedItems = Xml_SelectNodes("Tags.Row[@Attr.Selected='1']", objNode);

            // Get the selection mode
            var intSelectionMode = (Xml_IsAttribute(objNode, "Attr.Multiple", "1") ? 0 : 3);

            //first false - blnUseIndexes(is it ListBox)
            //second false - blnSuspendRaiseEvents
            List_KeyDown(strGuid, objItems, objSelectedItems, objNode, objWindow, objEvent, intSelectionMode, intKeyCode, Xml_GetAttribute(objNode, "Attr.View", "Details"), false, false);
        }

        // Cancel defailt scrolling functionality.
        Web_EventCancelBubble(objEvent);
    }
}
/// </method>

/// <method name="ListView_RaiseChangeColumnWidthEvent">
/// <summary>
///
/// </summary>
/// <param name="objRect"></param>
/// <returns>undefined</returns>
function ListView_RaiseChangeColumnWidthEvent(objRect) {
    if (mblnIsRTL) {
        if (mobjListViewObjectRect.right <= (objRect.right + 15)) {
            mobjListViewObjectRect.left = mobjListViewObjectRect.right - 15;
        }
        else {
            mobjListViewObjectRect.left = objRect.right;
        }
    }
    else {
        if (mobjListViewObjectRect.left >= (objRect.left - 15)) {
            mobjListViewObjectRect.right = mobjListViewObjectRect.left + 15;
        }
        else {
            mobjListViewObjectRect.right = objRect.left;
        }
    }

    var intWidth = mobjListViewObjectRect.right - mobjListViewObjectRect.left;

    with (mobjListViewObject1.style) {
        width = intWidth;
    }

    with (mobjListViewObject2.style) {
        width = intWidth;
    }

    // Get the active column guid.
    var strColumnGuid = String(mobjListViewObject1.id).replace("COL1_", "");

    var objEvent = Events_CreateEvent(strColumnGuid, "ChangeColumnWidth");
    Events_SetEventAttribute(objEvent, "Width", intWidth);

    // Set the column's data new width.
    Xml_SetAttribute(Data_GetNode(strColumnGuid), "Attr.Width", intWidth);

    var objListView = Web_GetVwgElement(mobjListViewObject1);

    if (objListView) {
        var strListViewId = Web_GetId(objListView);
        strListViewId = String(strListViewId).replace("VWG_", "");

        if (Data_IsCriticalEvent(strListViewId, mcntEventChangeColumnWidth)) {
            Events_RaiseEvents();
        }
    }
}
/// </method>

/// <method name="ListView_DoubleClick">
/// <summary>
///
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strItemGuid"></param>
/// <param name="objCheckImage"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <param name="blnScheduleCheck"></param>
/// <returns>undefined</returns>
function ListView_DoubleClick(strGuid, strItemGuid, objWindow, objEvent) {
    // Get checkbox image element.
    var objCheckImage = Web_GetElementById("LVI_CB_" + strItemGuid, objWindow);

    if (objCheckImage) {
        // Executig check change
        List_Checked(strGuid, strItemGuid, false, objCheckImage, objWindow, Data_IsCriticalEvent(strItemGuid, mcntEventDoubleClickId));
    }

    // If click and doubleclick are not critical and the cehck change event is critical - raise events.
    if (Data_IsCriticalEvent(strGuid, mcntEventCheckedChangeId)) {
        // Handles the double click event and forces raise (this 'overload' cancels the click bubble.
        Web_OnDblClick(objEvent, objWindow, true);
    }
}
/// </method>

/// <method name="ListView_CheckBoxClick">
/// <summary>
///
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strItemGuid"></param>
/// <param name="objCheckImage"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <param name="blnScheduleCheck"></param>
/// <returns>undefined</returns>
function ListView_CheckBoxClick(strGuid, strItemGuid, objWindow, objEvent) {
    // Get checkbox image element.
    var objCheckImage = Web_GetElementById("LVI_CB_" + strItemGuid, objWindow);

    if (objCheckImage) {
        // Executig check change
        List_Checked(strGuid, strItemGuid, false, objCheckImage, objWindow, true);

        //debugger;
        //jrt
        ListView_Select(strGuid, strItemGuid, objWindow, false, true, false);
    }

    // If click and doubleclick are not critical and the checked change event is critical - raise events.
    if (Data_IsCriticalEvent(strGuid, mcntEventCheckedChangeId)) {
        // Handles the click event and forces raise (this 'overload' cancels the click bubble.
        Web_OnClick(objEvent, objWindow, true);
    }
}
/// </method>

/// <method name="ListView_RightClick">
/// <summary>
/// Calls ListServices List_Select method which
/// selects element based on strId on right click
/// </summary>
/// <param name="strGuid"></param>
/// <param name="strId"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <returns>undefined</returns>
function ListView_RightClick(strGuid, strId, objWindow, objEvent) {
    // Check if selection on right click is enabled.
    if (Data_IsAttribute(strGuid, "Attr.SelectOnRightClick", "1")) {
        // Executig selection of list item
        ListView_Select(strGuid, strId, objWindow, Web_IsShift(objEvent), Web_IsControl(objEvent), Data_IsCriticalEvent(strId, mcntEventRightClickId));
    }
}

/// </method>

/// <method name="ListView_OrderColumn">
/// <summary>
///	Handles listview column oredering.
/// </summary>
/// <param name="strGuid">The id of the listview</param>
/// <param name="strColumn">The id of the listview column</param>
/// <param name="objWindow">The owner window of this listview</param>
/// <param name="objEvent">The event object</param>
function ListView_OrderColumn(strListGuid, strColumnId, objWindow, objEvent) {
    // Validate received parameters.
    if (objWindow &&
        strListGuid && strListGuid != "" &&
        strColumnId && strColumnId != "") {
        // Get listview node
        var objListElementNode = Data_GetNode(strListGuid);

        // Check if user is allowed ordering columns.
        if (!objListElementNode || !Xml_IsAttribute(objListElementNode, "Attr.AllowUserToOrderColumns", "1")) {
            return;
        }

        // Get column header element.
        var objDraggedElement = Web_GetElementById("VWG_" + strColumnId, objWindow);

        if (objDraggedElement) {
            // Get list element
            var objListElement = objWindow.$$(Web_GetWebId(strListGuid));

            if (objListElement) {
                // Store global variables
                ListView_OrderColumn.ListGuid = strListGuid;
                ListView_OrderColumn.ColumnId = strColumnId;
                ListView_OrderColumn.ActiveWindow = objWindow;

                // Get dragged element rect
                var objDraggedElementRect = Web_GetRect(objDraggedElement);

                // Get list rect
                var objListElementRect = Web_GetRect(objListElement);

                // Update the limitating rectangle width.
                objListElementRect.right -= (objDraggedElementRect.right - objDraggedElementRect.left);

                // Show dragging rect
                Drag_RegisterDragElement(objDraggedElement, mcntDragMoveHorz, objWindow, objEvent, ListView_OrderColumnEnd, null, objListElementRect, null, ListView_OrderColumnMove, 30);
            }
        }
    }
}
/// </method>


/// <method name="ListView_OrderColumnMove">
/// <summary>
///	Handles the actual column ordering
/// </summary>
function ListView_OrderColumnMove() {
    // Restore global variables.
    var strListGuid = ListView_OrderColumn.ListGuid;
    var strColumnId = ListView_OrderColumn.ColumnId;
    var objWindow = ListView_OrderColumn.ActiveWindow;

    // Validate drag window, drag subject, and drag subject's rectangle.
    if (objWindow && mobjDragRect &&
        !Aux_IsNullOrEmpty(strListGuid) && !Aux_IsNullOrEmpty(strColumnId)) {
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetElementById("VWG_" + strColumnId, objWindow);

        var objListElement = objWindow.$$(Web_GetWebId(strListGuid));

        // Validate the subject VWG element.
        if (objVwgDragSubject) {
            // Define x an y position.
            var intX = mobjDragRect.left - 1;
            var intY = mobjDragRect.top;

            // Get element according to x and y position.
            var objDraggedOverElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);

            // Check that the source element is not the VWG_DraggedOverFloatingElement.
            if (objDraggedOverElement && Web_GetId(objDraggedOverElement) != "VWG_DraggedOverFloatingElement") {
                // Removes the DropTargetElement - if exists.
                Drag_RemoveDropTargetElement();

                // Get the VWG dragged over element.
                var objVwgDraggedOverElement = Web_GetVwgElement(objDraggedOverElement, true);

                // Validate the VWG dragged over element.
                if (objVwgDraggedOverElement &&
                    Web_IsAttribute(objVwgDraggedOverElement, "vwgdragable", "1", true) &&
                    Web_GetId(objVwgDraggedOverElement) != "VWG_DragHtmlIndicatorBox") {
                    // Get the dragged over element rectangle.
                    var objVwgDraggedOverElementRect = Web_GetRect(objVwgDraggedOverElement);

                    // Validate the dragged over element rectangle.
                    if (objVwgDraggedOverElementRect) {
                        // Create a new DIV element.
                        var objDraggedOverFloatingElement = mobjDragWindow.document.createElement("DIV");

                        var objDraggedOverContainerElement = Drag_GetDraggedOverContainer();
                        if (objDraggedOverContainerElement) {
                            // Add floating element to its container.
                            objDraggedOverContainerElement.appendChild(objDraggedOverFloatingElement);

                            // Update the dragged over floating element id.
                            objDraggedOverFloatingElement.id = "VWG_DraggedOverFloatingElement";

                            // Set the dragged over floating element position to absolute.
                            objDraggedOverFloatingElement.style.position = "absolute";

                            objDraggedOverFloatingElement.style.backgroundColor = "black";

                            // Set element's height and top.
                            objDraggedOverFloatingElement.style.height = (objVwgDraggedOverElementRect.bottom - objVwgDraggedOverElementRect.top);
                            objDraggedOverFloatingElement.style.top = objVwgDraggedOverElementRect.top;

                            // Set element's width and left. 
                            objDraggedOverFloatingElement.style.width = 3;
                            objDraggedOverFloatingElement.style.left = objVwgDraggedOverElementRect.right - 3;
                        }
                    }
                }
            }
        }
    }
}
/// </method>

/// <method name="ListView_OrderColumnEnd">
/// <summary>
///	Handles the actual column ordering
/// </summary>
/// <param name="objRect">The new rectangle</param>
/// <param name="objRectOld">The original rectangle</param>
function ListView_OrderColumnEnd(objRect, objRectOld) {
    // Restore global variables.
    var strListGuid = ListView_OrderColumn.ListGuid;
    var strColumnId = ListView_OrderColumn.ColumnId;
    var objWindow = ListView_OrderColumn.ActiveWindow;

    // Removes the DropTargetElement - if exists.
    Drag_RemoveDropTargetElement();

    // Validate drag window, drag subject, and drag subject's rectangle.
    if (objWindow && mobjDragRect &&
        !Aux_IsNullOrEmpty(strListGuid) && !Aux_IsNullOrEmpty(strColumnId)) {
        // Get the subject VWG element.
        var objVwgDragSubject = Web_GetElementById("VWG_" + strColumnId, objWindow);

        // Validate the subject VWG element.
        if (objVwgDragSubject) {
            // Define x an y position.
            var intX = mobjDragRect.left;
            var intY = mobjDragRect.top;

            // Get element according to x and y position.
            var objDraggedOverElement = Web_GetElementFromPoint(mobjDragWindow, intX, intY);

            // Check that the source element is valid.
            if (objDraggedOverElement) {
                // Get the VWG dragged over element.
                var objVwgDraggedOverElement = Web_GetVwgElement(objDraggedOverElement, true);

                // Validate the VWG dragged over element.
                if (objVwgDraggedOverElement &&
                    Web_IsAttribute(objVwgDraggedOverElement, "vwgdragable", "1", true) &&
                    Web_GetId(objVwgDraggedOverElement) != "VWG_DragHtmlIndicatorBox") {
                    // Define a dragged column id.
                    var strDraggedColumnId = strColumnId;

                    // Get target column id.
                    var strTargetColumnId = Web_GetId(objVwgDraggedOverElement);

                    // Validate target column id.
                    if (strTargetColumnId.indexOf("VWG_") != -1) {
                        // Fix target column id.
                        strTargetColumnId = strTargetColumnId.substring(strTargetColumnId.indexOf("VWG_") + 4);
                    }

                    // Validate both column id's and check that they are not equal.
                    if (strDraggedColumnId && strDraggedColumnId != "" &&
                        strTargetColumnId && strTargetColumnId != "" &&
                        strDraggedColumnId != strTargetColumnId) {
                        // Create the columns reorder event
                        var objEvent = Events_CreateEvent(strListGuid, "ColumnsReorder", null, true);

                        // Set column id's as attributes.
                        Events_SetEventAttribute(objEvent, "Attr.DraggedColumn", strDraggedColumnId);
                        Events_SetEventAttribute(objEvent, "Attr.TargetColumn", strTargetColumnId);

                        // Raise events.
                        Events_RaiseEvents();
                    }
                }
            }
        }
    }
}
/// </method>


/// <method name="ListViewResizeChange">
/// <summary>
///
/// </summary>
/// <param name=""></param>
function ListView_ResizeChange(objRect) {
    // Raise change column width event.
    ListView_RaiseChangeColumnWidthEvent(objRect);

    // Validate list id.
    if (!Aux_IsNullOrEmpty(mstrListViewDataId)) {
        // Get list's window.
        var objWindow = Forms_GetWindowByDataId(mstrListViewDataId);
        if (objWindow) {
            // Redraw the list view.
            Controls_RedrawControlById(objWindow, mstrListViewDataId);
        }
    }
}
/// </method>

/// <method name="ListViewResize">
/// <summary>
///
/// </summary>
/// <param name=""></param>
/// <param name=""></param>
function ListView_Resize(objTd, objWindow, objEvent) {
    mobjListViewObject1 = Web_GetWebElement("COL1_" + Web_GetAttribute(objTd, "colid"), objWindow);
    mobjListViewObject2 = Web_GetWebElement("COL2_" + Web_GetAttribute(objTd, "colid"), objWindow);
    mobjListViewObjectRect = Web_GetRect(objTd.previousSibling);
    mstrListViewDataId = String(Web_GetId(objTd)).replace("HEADER_", "");

    Drag_ShowDragElement(Web_GetRect(objTd), mcntDragMoveHorz, objWindow, ListView_ResizeChange);

    // Cancel events
    Web_EventCancelBubble(objEvent);
}
/// </method>


//jrt add check all method
function ListView_CheckAllClick(box, strGuid, objWindow) {
    //debugger
    var objNode = Data_GetNode(strGuid);
    var objCheckImage = Web_GetElementById("LVI_CB_ALL_" + strGuid, objWindow);
    if (objCheckImage) {

        // set checked flag
        var blnChecked = false;

        // check current image state
        if (objCheckImage.src.indexOf("1.gif") > -1) {
            // turn check box off
            objCheckImage.src = objCheckImage.src.replace("1.gif", "0.gif");
        }
        else {
            // turn check box on
            blnChecked = true;
            objCheckImage.src = objCheckImage.src.replace("0.gif", "1.gif");
        }

    }

    var strSelectionValue = blnChecked ? "1" : "0";
    objItems = Xml_SelectNodes("R", objNode);

    var intChild = 0;
    // checked indexes array
    var arrChecked = [];


    // Loop all child items
    for (var i = 0; i < objItems.length; i++) {
        // Get item
        objItem = objItems[i];
        var strCurrentId = Xml_GetAttribute(objItem, "Id");
        var blnSelectionChanged = false;

        //call select row,but has a scorll problem
        //blnSelectionChanged = List_SetRowSelection(strSelectionValue, objItem, null, objWindow, false, blnSelectionChanged, strCurrentId);

        // Select/Unselect the current item.
        Xml_SetAttribute(objItem, "Attr.Selected", strSelectionValue);

        //When come from a single selection the strCurrentId and objElement are null
        if (strCurrentId != null) {
            //set the objElement cause it's null
            objElement = Web_GetWebElement(Web_GetWebId(strCurrentId), objWindow);
        }

        //If Unselect
        if (strSelectionValue == "0") {
            Web_SetUnselectedElement(objElement, objWindow);
        }
        else {
            Web_SetSelectedElement(objElement, objWindow);
        }


        //Do checked all
        // Get checkbox image element.
        var objCheckImage = Web_GetElementById("LVI_CB_" + strCurrentId, objWindow);
        if (objCheckImage) {
            // Executig check change
            //List_Checked(strGuid, strCurrentId, false, objCheckImage, objWindow, true);


            // check current image state
            if (objCheckImage.src.indexOf("1.gif") > -1) {
                // turn check box off
                if (!blnChecked) {
                    objCheckImage.src = objCheckImage.src.replace("1.gif", "0.gif");
                }
            }
            else {
                if (blnChecked) {
                    objCheckImage.src = objCheckImage.src.replace("0.gif", "1.gif");
                }
            }

            Xml_SetAttribute(objItem, "C", blnChecked ? "1" : "0");
            if (Xml_IsAttribute(objItem, "C", "1")) {
                arrChecked[arrChecked.length] = intChild;
            }
            intChild++;
        }
    }

    //By jrt :fire selectchange event
    List_CreateSelectionChangeEvent(strGuid, objNode, 0, arrChecked, false, true);

    // Create event and raise if critical
    var objEvent = Events_CreateEvent(strGuid, "CheckedChange", true);
    Events_SetEventAttribute(objEvent, "Indexes", String(arrChecked));
    //        if (!blnSuspendEvents && Data_IsCriticalEvent(strGuid, intCriticalEventCheck)) {
    //            Events_RaiseEvents();
    //        }

    if (Data_IsCriticalEvent(strGuid, mcntEventCheckedChangeId)) {
        Events_RaiseEvents();
    }


}