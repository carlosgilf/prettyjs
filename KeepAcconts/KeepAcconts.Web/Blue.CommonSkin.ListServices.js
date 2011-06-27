/// <method name="List_Select">
/// <summary>
/// Generic Select function for ListBox, ListView, etc.
/// </summary>
function List_Select(strGuid,strSelectedItemID,intSelectionMode,blnUseIndexes,blnSelectIcon,objWindow,blnShiftKey,blnCtrlKey,blnSuspendRaiseEvents,intKeyCode)
{
    // In None selection mode - exit function.
    if(intSelectionMode==2)
    {
        return;
    }
    
    // Control is pressed or MultiSimple selection mode.
    blnCtrlKey = blnCtrlKey || intSelectionMode==1;

	// Get radio button node
	var objNode = Data_GetNode(strGuid);
	if(objNode)
	{
		// Variables declerations
		var arrSelected		      = [];
		var objItems		      = null;		
		var objItem			      = null;
		var objStruct             = null;
		var intSelectedIndex      = 0;
        var intLastSelectedIndex  = Xml_GetAttribute(objNode,"LSI");
        var intFirstSelectedIndex = Xml_GetAttribute(objNode,"FSI");//get the first selected row
        var strCurrentId;
	    
        var blnSelectionChanged   = false;
		
	    if(blnUseIndexes)
	    {
	        //Indexes control
		    objItems = Data_GetChildNodes(objNode);
		    intSelectedIndex = parseInt(strSelectedItemID);
		    strSelectedItemID = List_GetElementIdByIndex(strGuid,strSelectedItemID);	    
	    }
	    else
	    {
	        //Rows control
		    objItems = Xml_SelectNodes("Tags.Row",objNode);
		    
		    //Get the columns count
            var intColumnCount = Xml_SelectNodes("Tags.Column",objNode).length;
		    
		    //Get the first selected item 
		    var objSelectedNode = Xml_SelectSingleNode("Tags.Row[@Attr.Id='" + strSelectedItemID + "']",objNode);

		    //Get the position of the current node
		    intSelectedIndex = Xml_GetPositionByTagName(objSelectedNode)
	    }

	    // Loop all child items
	    for(var i=0;i<objItems.length;i++)
	    {
		    // Get item
		    objItem = objItems[i];
		    
		    if(blnUseIndexes)
		    {
			    // Get current item id from index
			    strCurrentId = List_GetElementIdByIndex(strGuid,i);
		    }
		    else
		    {
			    // Get current item id from id
			    strCurrentId = Xml_GetAttribute(objItem,"Attr.Id");
		    }

		    // Shift key is pressed.
		    if(blnShiftKey && intSelectionMode==0)
		    {
		        objStruct = List_HandleShiftSelection(objNode,objItem, objWindow, arrSelected, intFirstSelectedIndex, intLastSelectedIndex, intKeyCode, intSelectedIndex,strCurrentId,blnSelectIcon,i);
		    }
		    // Shift key is not pressed.
		    else
		    {	
		        objStruct = List_HandleSingleSelection(objNode,objItem, objWindow,arrSelected, intSelectedIndex,strCurrentId,blnSelectIcon,strSelectedItemID,intSelectionMode,blnCtrlKey,i);
		    }
            
            //update the arrSelected array
            arrSelected = objStruct.SelectedArray;

            //If the selected row has been changed
		    if(objStruct.SelectionChanged)
		    {
		        //save that a selection change has been made
		        blnSelectionChanged = true;
		    }            
	    }
		
		// Create event and raise if critical
		// Check if selection has been changed
		if (arrSelected.length>0 && blnSelectionChanged)
		{
		    List_CreateSelectionChangeEvent(strGuid, objNode, intSelectedIndex, arrSelected, blnCtrlKey, blnSuspendRaiseEvents);

		    //jrt:call checked event
		    var objEvent = Events_CreateEvent(strGuid, "CheckedChange", true);
		    Events_SetEventAttribute(objEvent, "Indexes", String(arrSelected));
		    if (Data_IsCriticalEvent(strGuid, mcntEventCheckedChangeId)) {
		        Events_RaiseEvents();
		    }
		    //end
	    }
	}
}
/// </method>


/// <method name="List_Click">
/// <summary>
/// determines the KeyCode and call List_Select
/// </summary>
function List_Click(strGuid,strSelectedItemID,intSelectionMode,blnUseIndexes,blnSelectIcon,objWindow,blnShiftKey,blnCtrlKey,blnSuspendRaiseEvents)
{
	var intKeyCode = 0;
    var intSelectedIndex =0;

   
	// Get data node
	var objNode = Data_GetNode(strGuid);
	if(objNode)
	{

        //get the last selected row
        var intLastSelected  = parseInt(Xml_GetAttribute(objNode,"LSI"),10);

        //get the first selected row
        var intFirstSelected = parseInt(Xml_GetAttribute(objNode,"FSI"),10);

        if(blnUseIndexes)
	    {
	        //Indexes control
		    intSelectedIndex = parseInt(strSelectedItemID);
	    }
	    else
	    {
	       	//Get the columns count
            var intColumnCount = Xml_SelectNodes("Tags.Column",objNode).length
		    
		    //Get the first selected item 
		    var objSelectedNode = Xml_SelectSingleNode("Tags.Row[@Attr.Id='" + strSelectedItemID + "']",objNode);
		    
		    //Get the position of the current node
		    intSelectedIndex = Xml_GetPositionByTagName(objSelectedNode)

	    }
	    
        
        //If the selection direction was from up to down AND the new selected value is in the same direction
        if(intLastSelected > intFirstSelected && intSelectedIndex > intFirstSelected)
        {
            //If the new selected value is under the last one
            if(intSelectedIndex > intLastSelected )
            {
                intKeyCode = mcntDownKey;
            }
            else
            {
                intKeyCode = mcntUpKey;
            }
        }   
        //If the selection direction was from up to down AND the new selected value is in the opposite direction
        else if(intLastSelected > intFirstSelected && intSelectedIndex < intFirstSelected)
        {
            intKeyCode = mcntUpKey;
        }
        
        //If the selection direction was from down to up AND the new selected value is in the opposite direction
        else if(intFirstSelected > intLastSelected && intSelectedIndex > intFirstSelected)
        {
            intKeyCode = mcntDownKey;
        }
        //If the selection direction was from down to up AND the new selected value is in the same direction
        else if(intFirstSelected > intLastSelected && intSelectedIndex < intFirstSelected)
        {
            //If the new selected value is under the last one and above the first one
            if(intSelectedIndex > intLastSelected )
            {
                intKeyCode = mcntDownKey;
            }
            else
            {
                intKeyCode = mcntUpKey;
            }
        }
    }

    List_Select(strGuid,strSelectedItemID,intSelectionMode,blnUseIndexes,blnSelectIcon,objWindow,blnShiftKey,blnCtrlKey,blnSuspendRaiseEvents,intKeyCode);
}
/// </method>


/// <method name="List_HandleSingleSelection">
/// <summary>
/// Handle the selection of an item with the mouse or with key navigation(with or without pressing the cuntrol)
/// </summary>
function List_HandleSingleSelection(objNode,objItem, objWindow,arrSelected, intSelectedIndex,strCurrentId,blnSelectIcon,strSelectedItemID,intSelectionMode,blnCtrlKey,intCurrentIndex ) 
{
    var objElement		     = null;
    var blnSelectionChanged  = false;	
    
    //Set the first selected index
    Xml_SetAttribute(objNode, "FSI", intSelectedIndex);			
     
    // If not current index
    if(strCurrentId!=strSelectedItemID)
    {
        // Deslect if needed
        if(Xml_GetAttribute(objItem,"Attr.Selected")=="1")
        {
	        if(!blnCtrlKey|| (intSelectionMode!=0 && intSelectionMode!=1))
	        {
	            // Deselect the current item.
	            blnSelectionChanged = List_SetRowSelection("0",objItem, objElement,objWindow,blnSelectIcon,blnSelectionChanged,strCurrentId);
	        }
	        else
	        {
		        arrSelected[arrSelected.length]=intCurrentIndex;
	        }
        }
    }
    else
    {
        // Deslect if needed
        if(Xml_GetAttribute(objItem,"Attr.Selected")=="1")
        {
	        if(blnCtrlKey && (intSelectionMode==0 || intSelectionMode==1))
	        {
	            // Deselect the current item.
	            blnSelectionChanged = List_SetRowSelection("0",objItem, objElement,objWindow,blnSelectIcon,blnSelectionChanged,strCurrentId);
	        }
	        else
	        {
		        arrSelected[arrSelected.length]=intCurrentIndex;
	        }
        }
        else
        {
            // Select the current item.
            blnSelectionChanged = List_SetRowSelection("1",objItem, objElement,objWindow,blnSelectIcon,blnSelectionChanged,strCurrentId);
	        arrSelected[arrSelected.length]=intCurrentIndex;
        }
    }
    
    return {SelectedArray:arrSelected,SelectionChanged:blnSelectionChanged};
}
/// </method>

/// <method name="List_HandleShiftSelection">
/// <summary>
/// Handle the selection of an item with the mouse or with key navigation(while pressing the shift key)
/// </summary>
function List_HandleShiftSelection(objNode,objItem, objWindow, arrSelected, intFirstSelectedIndex, intLastSelectedIndex, intKeyCode, intSelectedIndex,strCurrentId,blnSelectIcon,intCurrentIndex)
{
    var objElement		     = null;
	var intShiftSelectFrom   = -1;
	var intShiftSelectTo     = -1;
    var blnSelectionChanged  = false;	
    
       
    // Check that the selected item is not the first selected one.
    if(intLastSelectedIndex)
    {
        // Initialize the shift selection indexes.
        if(intShiftSelectFrom == -1 && intShiftSelectTo == -1)
        {
            switch(intKeyCode)
            {
                case mcntUpKey:
                case mcntPageUpKey: 
                case mcntHomeKey:     
                case mcntLeftKey:
                    //If the selection direction is from down to up 
                    //the intShiftSelectFrom should be bigger than intShiftSelectTo
                    intShiftSelectFrom  = (intSelectedIndex>intLastSelectedIndex?intSelectedIndex:intFirstSelectedIndex);
                    intShiftSelectTo    = (intSelectedIndex<intLastSelectedIndex?intSelectedIndex:intLastSelectedIndex);
                    break;   

                    //case mcntRightKey:
                    //case mcntDownKey:
                    //case mcntPageDownKey: 
                    //case mcntEndKey:     
                    //also handle the mouse click with shift 
                default:
                    //If the selection direction is from up to down
                    //the intShiftSelectFrom should be smaller than intShiftSelectTo
                    intShiftSelectFrom  = (intSelectedIndex<intLastSelectedIndex?intSelectedIndex:intFirstSelectedIndex);                    
                    intShiftSelectTo    = (intSelectedIndex>intLastSelectedIndex?intSelectedIndex:intLastSelectedIndex);
                    break; 
            }  
        }
        
        // Get web element.
        objElement = Web_GetWebElement(Web_GetWebId(strCurrentId),objWindow);
        
        //If the selection direction is down
        if(intShiftSelectFrom < intShiftSelectTo)
        {
            if(intCurrentIndex <= intShiftSelectTo && intCurrentIndex >= intShiftSelectFrom)
            {
                // Select the current item.  	
                blnSelectionChanged = List_SetRowSelection("1", objItem, objElement, objWindow, blnSelectIcon,blnSelectionChanged);

                // Add current index to the selected indexes array.
                arrSelected[arrSelected.length]=intCurrentIndex;
            }
            else
            {
                // Deselect the current item.  	
            	blnSelectionChanged = List_SetRowSelection("0", objItem, objElement, objWindow, blnSelectIcon,blnSelectionChanged,null);
            }
        }
        else
        //If the selection direction is up
        {
            if(intCurrentIndex >= intShiftSelectTo && intCurrentIndex <= intShiftSelectFrom)
            {
                // Select the current item.
                blnSelectionChanged = List_SetRowSelection("1", objItem, objElement, objWindow, blnSelectIcon,blnSelectionChanged,null);

                // Add current index to the selected indexes array.
                arrSelected[arrSelected.length]=intCurrentIndex;
            }
            else
            {
                // Deselect the current item.
               	blnSelectionChanged = List_SetRowSelection("0", objItem, objElement, objWindow, blnSelectIcon,blnSelectionChanged,null);
            }
        }
    }

    return {SelectedArray:arrSelected,SelectionChanged:blnSelectionChanged};
}
/// </method>

/// <method name="List_CreateSelectionChangeEvent">
/// <summary>
/// Create and raise the SelectionChange event
/// </summary>
function List_CreateSelectionChangeEvent(strGuid, objNode, intSelectedIndex ,arrSelected, blnCtrlKey,blnSuspendRaiseEvents)
{
    var objVwgEvent = Events_CreateEvent(strGuid,"SelectionChange",null,true);
    Events_SetEventAttribute(objVwgEvent,"Indexes",String(arrSelected));
    if(blnCtrlKey)
    {
        Events_SetEventAttribute(objVwgEvent,"Incremental","1");
    }
	
	//If critical event
    if(!blnSuspendRaiseEvents && Data_IsCriticalEvent(strGuid,mcntEventSelectionChangeId)) 
    {
		Events_RaiseEvents();
    }
	
	// Save the last selected index member.
    Xml_SetAttribute(objNode, "LSI", intSelectedIndex);
}
/// </method>

/// <method name="List_SetRowSelection">
/// <summary>
/// Set the selected rows and the unselected rows
/// </summary>
function List_SetRowSelection(strSelectionValue,objItem, objElement, objWindow, blnSelectIcon, blnSelectionChanged, strCurrentId)
{
    //Save the items' selected attribute
    var objSelectedAttr =  Xml_GetAttribute(objItem,"Attr.Selected");
    
    //If the value(selected attribute) has been changed
    if (objSelectedAttr != strSelectionValue || objElement == null)
    {
        // Select/Unselect the current item.
        Xml_SetAttribute(objItem,"Attr.Selected",strSelectionValue);
        
        //When come from a single selection the strCurrentId and objElement are null
        if(strCurrentId != null)
        {
            //set the objElement cause it's null
            objElement = Web_GetWebElement(Web_GetWebId(strCurrentId),objWindow);
        }

        //jrt:Do checked all
        var iid = strCurrentId;
        if (!iid) {
            iid = Xml_GetAttribute(objItem, "Id");
        }
        var objCheckImage = Web_GetElementById("LVI_CB_" + iid, objWindow);
        if (objCheckImage) {
            var blnChecked = (strSelectionValue == "1");
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
        }
        //end jrt
        
        //If Unselect
        if(strSelectionValue == "0")
        {
            Web_SetUnselectedElement(objElement,objWindow);
		    if(blnSelectIcon) List_SetUnselectedIcon(objElement);
		    
		    //Check (objSelectedAttr != null) to make sure that we won't Scroll Into View when unselecting
		    //an items that have't been selected
		    //Check to make sure that we in shift unselection(strCurrentId == null)
		    if(objSelectedAttr != null && strCurrentId == null)
		    {
		        //when unselecting a selected item that is not visible to us
		        Web_ScrollIntoView(objElement);
		    }
		}
		else
		{                       
            Web_SetSelectedElement(objElement,objWindow);
            if(blnSelectIcon) 
            {
                List_SetSelectedIcon(objElement);
            }
            Web_ScrollIntoView(objElement);
        }
        
        return true;
    }
    return blnSelectionChanged;
}
/// </method>

/// <method name="List_KeyDown">
/// Handles keypad navigation 
/// <summary>
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objItems"></param>
/// <param name="objSelectedItems"></param>
/// <param name="objNode"></param>
/// <param name="objWindow"></param>
/// <param name="objEvent"></param>
/// <param name="intSelectionMode"></param>
/// <param name="intKeyCode"></param>
/// <param name="strView"></param>
/// <param name="blnUseIndexes"></param>
/// <returns>undefined</returns>
function List_KeyDown(strGuid,objItems,objSelectedItems,objNode,objWindow,objEvent,intSelectionMode,intKeyCode,strView,blnUseIndexes,blnSuspendRaiseEvents)
{
    if (objItems)
    {
        var intIndex = 0;
        var intCurrentKeyCode = intKeyCode;
        
        //Check is the shift key is pressed
        if(!Web_IsControl(objEvent))
        {
            //Get the selected items number
            var intSelectedRowsNumber  = objSelectedItems.length;

            //Get the columns count
            var intColumnCount = Xml_SelectNodes("Tags.Column",objNode).length;
            
            //Get the first item that has been selected without pressing the shift key(mouse click or regular key navigation)
            var intFirstSelectedIndex =parseInt(Xml_GetAttribute(objNode,"FSI"));
            
            //Get the last item that has been selected
            var intLastSelectedIndex = parseInt(Xml_GetAttribute(objNode,"LSI"));
            
            //If there are already selected rows and the selection direction was from up to down
            //get the LAST selected  row
            if(intSelectedRowsNumber > 1 && intLastSelectedIndex > intFirstSelectedIndex )
            {
                intCurrentKeyCode = mcntDownKey;
            }                
            //If there are already selected rows and the selection direction was from down to up 
            //get the FIRST selected  row
            else if(intSelectedRowsNumber > 1 && intFirstSelectedIndex > intLastSelectedIndex)
            {
                intCurrentKeyCode = mcntUpKey;
            }
            
            //The intCurrentKeyCode datermains the serch direction of the search
            //if the intCurrentKeyCode is mcntDownKey the serch is from down to up and the 
            //result will be the last selected row
            var objSelectedNode;
            if(intCurrentKeyCode == mcntUpKey)
            {
                //Get the first selected node
                objSelectedNode  = objSelectedItems[0];
            }
            else
            {
                //Get the last selected node
                objSelectedNode  = objSelectedItems[intSelectedRowsNumber-1];
            }
                        
            //Get the position of the current node
		    intIndex = Xml_GetPositionByTagName(objSelectedNode)
            
            //Get the position of the next\prev node(dependes on the intKeyCode)
            intIndex = List_GetIndexOfNextNode(strGuid,objItems,intKeyCode,intIndex,strView);

            // boundary checking
            if( intIndex >= objItems.length )
            {
                //If we reached the last item or over it
                intIndex = objItems.length-1;
                
                //If the last item is selected and we press the Down/End/PageDown key - exit the sub
                if(intLastSelectedIndex == objItems.length-1)
                {
                    return;
                }
            }
            else if( intIndex < 0 )
            {
                //set the index of the first item. 
                intIndex = 0;
                
                //If the first item is selected and we press the Up/Home/PageUp key - exit the sub
                if(intFirstSelectedIndex == 0)
                {
                    return;
                }
            }	            
            
            // If not using indexes - get index out of id.
            if(!blnUseIndexes)
            {
                intIndex = Web_GetAttribute(objItems[intIndex],"Attr.Id");
	        }

            List_Select(strGuid,intIndex,intSelectionMode,blnUseIndexes,true,objWindow,Web_IsShift(objEvent),Web_IsControl(objEvent),blnSuspendRaiseEvents,intKeyCode);
        }
    }
}
/// </method>

/// <method name="ListView_GetIndexOfNextNode">
/// <summary>
/// Determine the index of the node to navigate to 
/// based on View and navigation key
/// </summary>
/// <param name="strGuid"></param>
/// <param name="objItems"></param>
/// <param name="intKeyCode"></param>
/// <param name="">intIndex</param>
/// <returns>index of the node to navigate to</returns>
function List_GetIndexOfNextNode(strGuid,objItems,intKeyCode,intIndex,strView)
{
    var intPageSize = 10;
    
    //If End key
    if (intKeyCode == mcntEndKey)
    {         
        //get the last index                   
        intIndex=objItems.length-1; 
    }
    else if (intKeyCode == mcntHomeKey)    
    {
        //get the first index                   
        intIndex=0; 
    }
    else
    {
	    switch(strView)
	    {
	        case "Details":
	        case "List":
                switch(intKeyCode)
	            {
	                case mcntUpKey:
	                    //Decrease the index by 1 
	                    intIndex--; 
	                    break;         
	                case mcntDownKey:
	                    //Increase the index by 1
	                    intIndex++; 
	                    break;        
    	            
	                case mcntPageDownKey:
	                    //Increase the index by 10 
	                    intIndex += intPageSize;
	                    break;
	                
	                case mcntPageUpKey:  
	                    //Decrease the index by 10
	                    intIndex -= intPageSize ;
	                    break;
	            }
	            break;
            case "LargeIcon":
            case "SmallIcon":
                switch(intKeyCode)
                {
                    case mcntRightKey:
	                    intIndex++; 
                        break;
                    case mcntLeftKey:
	                    intIndex--; 
                        break;
                }
                break;
	    }
	}
	return intIndex;
}   
/// </method>

/// <method name="List_Checked">
/// <summary>
///
/// </summary>
function List_Checked(strGuid,strItemGuid,blnIndexes,objCheckImage,objWindow,blnSuspendEvents)
{
	// Get radio button node
	var objNode = Data_GetNode(strGuid);
	if(objNode)
	{
		// set checked flag
		var blnChecked = false;
		var strTagName;
	    var strId;
	    var intCriticalEventCheck;
	    
	    //get parameters values according to blnIndexes
	    if(blnIndexes)
	    {
	        strTagName = "Tags.Option";
	        strId = "Idx";
	        intCriticalEventCheck = mcntEventValueChangeId;
	    }
	    else
	    {
	        strTagName ="Tags.Row";
	        strId = "Id";
	        intCriticalEventCheck = mcntEventCheckedChangeId;
	    }
		
		// check current image state
		if(objCheckImage.src.indexOf("1.gif")>-1)
		{
			// turn check box off
			objCheckImage.src = objCheckImage.src.replace("1.gif","0.gif");
		}
		else
		{
			// turn check box on
			blnChecked = true;
			objCheckImage.src = objCheckImage.src.replace("0.gif","1.gif");
		}
		
		
		// loop variables
		var objChildNodes	= Xml_GetEnumerable(Xml_SelectNodes(strTagName,objNode));
		var objChild		= null;
		var intChild		= 0;
		
		// checked indexes array
		var arrChecked		= [];
		
		// Loop all children
		while(objChild = objChildNodes.nextNode())
		{
			// if current index change
			if(Xml_GetAttribute(objChild,strId)==strItemGuid)
			{
				Xml_SetAttribute(objChild,"Attr.Checked",blnChecked?"1":"0");
			}
			
			if(Xml_IsAttribute(objChild,"Attr.Checked","1"))
			{
				arrChecked[arrChecked.length]=intChild;
			}
			intChild++;
		}
		
	
		// Create event and raise if critical
		var objEvent = Events_CreateEvent(strGuid,"CheckedChange",true);
		Events_SetEventAttribute(objEvent,"Indexes",String(arrChecked));
		if(!blnSuspendEvents && Data_IsCriticalEvent(strGuid,intCriticalEventCheck)) 
		{
		    Events_RaiseEvents();
		}
	}
}
/// </method>

function List_NavigateHome(strGuid)
{
	List_NavigateTo(strGuid,"Home");
}

function List_NavigateBack(strGuid)
{
	List_NavigateTo(strGuid,"Back");
}


function List_NavigateNext(strGuid)
{
	List_NavigateTo(strGuid,"Next");
}

function List_NavigateEnd(strGuid)
{	
	List_NavigateTo(strGuid,"End");
}

function List_NavigateTo(strGuid,strValue)
{
	var objEvent = Events_CreateEvent(strGuid,"Navigate",true);
	Events_SetEventAttribute(objEvent,"To",strValue);
	Events_RaiseEvents();
}

function List_SetSelectedIcon(objElement)
{
	var objImage = Web_GetContextElementById(objElement,"VWGE_SelectIcon");
	if(objImage)
	{
		if(objImage.src.indexOf("0.gif")>0)
		{
			objImage.src = objImage.src.replace("0.gif","1.gif");
		}
	}
}

function List_SetUnselectedIcon(objElement)
{
	var objImage = Web_GetContextElementById(objElement,"VWGE_SelectIcon");
	if(objImage)
	{
		if(objImage.src.indexOf("1.gif")>0)
		{
			objImage.src = objImage.src.replace("1.gif","0.gif");
		}
	}
}

/// <method name="List_GetElementIdByIndex">
/// <summary>
///
/// </summary>
/// <param name="strDataID">The current component guid.</param>
/// <param name="intIndex">The component item index.</param>
function List_GetElementIdByIndex(strDataID,intIndex)
{
    return Web_GetWebId(strDataID+"_"+intIndex,true);
}
/// </method>
