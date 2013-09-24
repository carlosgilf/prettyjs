
var Events = {};

/// <parameters>
/// <summary>
/// Global parameters
/// </summary>
/// <param name="Buffer">Used to store the data state of the gui.</param>
var mobjEventBuffer	= null;
var mobjEventProcesser = null;
var mblnDebugEvents	= false;
var mblnEventFired = false;
var mblnPendingRaiseEvents = false;
var mblnEventAborted = false;
var mobjEventsCallbackDelegate = null;
/// </parameters>

var mintKeepConnectedHandle = 0;
var mintScheduleRaiseEventHandle = 0;
var mintLoadingHandle = 0;
var mobjLoadingWindow = window;
var mblnLoadingIsActive = false;
var mstrLoadingMessage	= "";
var mstrLoadingSource	= null;

var mobjEventsOnSubmit = null;
var mblnEventsOnSubmitCalling = false;

//jrt
var mintRequestTimeoutHandle = 0;
//jrt default request timeout (number of seconds)
var mintRequestTimeoutDefaultValue = 100;

/// <method name="Events_AttachOnSubmit">
/// <summary>
/// Adds an submit event handler function.
/// </summary>
/// <param name="strCaller">The id of the caller.</param>
/// <param name="fncCallback">The call back function to be called.</param>
function Events_AttachOnSubmit(strCaller,fncCallback)
{
    // create delegate
    var objCurrentDelegate = {objPrev:mobjEventsOnSubmit,objNext:null,fncCallback:fncCallback,strCaller:strCaller};
    
    // If there is a leading delegate
    if(mobjEventsOnSubmit)
    {
        mobjEventsOnSubmit.objNext = objCurrentDelegate;
    }
    
    // set current leading delegate
    mobjEventsOnSubmit = objCurrentDelegate;
}
/// </method>

/// <method name="Events_EventExists">
/// <summary>
/// Checks the event queue to see if a particular event, 
/// for a particular source (and member if any) has been queued
/// </summary>
/// <param name="strType">the event type</param>
/// <param name="strSourceId">the source id</param>
/// <param name="strMemberId">the member id, if any</param>
function Events_EventExists(strType,strSourceId, strMemberId)
{
    var objEvent = null;
    
    // confirm event queue not null
    if(mobjEventBuffer)
    {
        // build XPath expression to search the event queue
        
        // add event type
		var strCondition = "@Attr.Type='"+strType+"'";
		
		// add source Id
		strCondition+=" and @Attr.Source='"+strSourceId+"'";
		
		// add member id, if any		    
	    if(strMemberId!="")
	    {
	        strCondition+=" and @Attr.Member='"+strMemberId+"'";
	    }
	    
	    // select the node answering the criteria in the XPath expression		
        objEvent = Xml_SelectSingleNode("Tags.Event["+strCondition+"]",mobjEventBuffer);
    }
    
    // if objEvent was found, return true, otherwise, return false
    return (objEvent != null);
}
/// </method>

function Events_DetachOnSubmit(strCaller)
{
    // Get last registered delegates
    var objCurrentCallback = mobjEventsOnSubmit;
    
    // Loop all registered delegates
    while(objCurrentCallback)
    {
        try
        {
            // If found delegate to be removed
            if(objCurrentCallback.strCaller==strCaller)
            {
                // Get delegate prev and next delegates
                var objPrev = objCurrentCallback.objPrev;
                var objNext = objCurrentCallback.objNext;
                
                // If there is a previous delegate
                if(objPrev)
                {
                    // Set the next delegate of the previous delegate to the 
                    // next of the removed delegate
                    objPrev.objNext = objNext;
                }
                // If there is a next delegate
                if(objNext)
                {
                    // Set the previous delegate of the next delegate to the 
                    // previous of the removed delegate
                    objNext.objPrev = objPrev;
                }
                // If removed delegate is the leading delegate
                if(mobjEventsOnSubmit==objCurrentCallback)
                {
                    // If has next delegate
                    if(objNext)
                    {
                        // Set next delegate as leading delegate
                        mobjEventsOnSubmit = objNext;
                    }
                    // If has previous delegate 
                    else if(objPrev)
                    {
                        // set previous delegate as leading delagate
                        mobjEventsOnSubmit = objPrev;
                    }
                    else
                    {
                        // Clear leading delegate (no other delegates)
                        mobjEventsOnSubmit = null;
                    }
                }
                break;
            }
        }
        catch(e)
        {
        }
        
        // Loop to the previous delegate
        objCurrentCallback = objCurrentCallback.objPrev;
    }
}

function Events_RaiseOnSubmit()
{
    mblnEventsOnSubmitCalling = true;
    var objCurrentCallback = mobjEventsOnSubmit;
    
    try
    {
        // Loop all delegates
        while(objCurrentCallback)
        {
            try
            {
                // If found callback
                if(objCurrentCallback.fncCallback)
                {
                    // Call the callback function
                    objCurrentCallback.fncCallback(objCurrentCallback.strCaller);
                }
            }
            catch(e)
            {
            }
            
            // move cursor to previous delegate
            objCurrentCallback = objCurrentCallback.objPrev;
        }
        
    }
    catch(e)
    {
    }
    mblnEventsOnSubmitCalling = false;
}

/// <method name="Events_ScheduleRaiseConnected">
/// <summary>
/// Schedule raises connected event.
/// </summary>
/// <param name="intInterval"></param>
/// <param name="blnIsTimer"></param>
function Events_ScheduleRaiseConnected(intTimer)
{
	// clear previous interval 
	Web_ClearTimeout(mintKeepConnectedHandle);
	
	// If timer is defined
	if(intTimer)
	{
	    // Set next timer request
	    mintKeepConnectedHandle = Web_SetTimeout("mobjApp.Events_RaiseConnected(true)",intTimer);
	}
	else
	{
	    // Set next keep connected request
	    mintKeepConnectedHandle = Web_SetTimeout("mobjApp.Events_RaiseConnected(false)",mcntKeepConnectedInterval);
	}
}
/// </method>
	
/// <method name="Events_RaiseConnected">
/// <summary>
/// Raises a connected event.
/// </summary>
/// <param name="blnIsTimer"></param>
function Events_RaiseConnected(blnIsTimer)
{
	Events_CreateEvent(mstrWindowGuid,blnIsTimer?"Timer":"KeepConnected");
	Events_RaiseEvents();
}
/// </method>

/// <method name="Events_DeleteEvent">
/// <summary>
/// Removes an event from the event queue.
/// </summary>
/// <param name="strType">The type of the event to be removed.</param>
function Events_DeleteEvent(strType)
{
	// if there is no event buffer
	if(mobjEventBuffer!=null)
	{
		var objLastEvent = mobjEventBuffer.lastChild;
		if(objLastEvent)
		{
			if(objLastEvent.getAttribute("Attr.Type")==strType)
			{
				// Remove previous event
				objLastEvent.parentNode.removeChild(objLastEvent);
			}
		}
	}
}
/// </method>

/// <method name="Events_IsProcessing">
/// <summary>
/// Checks if in processing mode
/// </summary>
function Events_IsProcessing()
{
    // If there is an active XMLHTTP
    return mobjEventProcesser!=null;
}
/// </method>

/// <method name="Events_StopProcessing">
/// <summary>
/// Stops current processing
/// </summary>
function Events_StopProcessing()
{
    // If there is an active XMLHTTP
    if(mobjEventProcesser!=null)
    {
        // Set aborted to true
        mblnEventAborted = true;
        
        // Abort request
        try{mobjEventProcesser.abort();}catch(e){}        
        
        // Release aborted state
        mblnEventAborted = false;
    }
}
/// </method>

/// <method name="Events_CreateEvent">
/// <summary>
/// Creates a new application server event.
/// </summary>
/// <param name="strSource">The ID of the event source.</param>
/// <param name="strType">The type of the event to be created.</param>
/// <param name="strTarget">The target ID.</param>
/// <param name="blnUnique">Indicates whether an event should be unique</param>
/// <param name="blnTypeOnlyUnique">Indicates whether an event should be unique by type only</param>
function Events_CreateEvent(strSource,strType,strTarget,blnUnique,blnTypeOnlyUnique)
{
	// if there is no event buffer
	if(mobjEventBuffer==null)
	{
		// create new event buffer element
		mobjEventBuffer = mobjDataDomObject.createElement("Tags.Events");
		
		// attach event buffer to data object
		mobjDataDomObject.documentElement.appendChild(mobjEventBuffer);
	}
	
	// get the event guid
	var strGuid = String(strSource).replace("VWG_","");
	var strMember = "";
	if(strGuid.indexOf("_")>0)
	{
	    var arrGuid = strGuid.split("_");
	    strGuid = arrGuid[0];
	    strMember = arrGuid[1];
	}
	
	// if event should be unique
	if(blnUnique)
	{
		// Create unique condition
		var strCondition = "@Attr.Type='"+strType+"'";
		
		// If is type unique event
		if(!blnTypeOnlyUnique) 
		{
		    strCondition+=" and @Attr.Source='"+strGuid+"'";
		    
		    if(strMember!="")
		    {
		        strCondition+=" and @Attr.Member='"+strMember+"'";
		    }
		}
		
		// Search for previous event
		var objOldNode =  Xml_SelectSingleNode("Tags.Event["+strCondition+"]",mobjEventBuffer);
		if(objOldNode)
		{
			// Remove previous event
			objOldNode.parentNode.removeChild(objOldNode);
		}
	}
	
	// create new event element
	var objEventElement = mobjDataDomObject.createElement("Tags.Event");
	
	// set metadata attributes
	Events_SetEventAttribute(objEventElement,"Attr.Source",strGuid);
	Events_SetEventAttribute(objEventElement,"Attr.Type",strType);
	if(strMember!="") Events_SetEventAttribute(objEventElement,"Attr.Member",strMember);
	
	// Set the loading source
	mstrLoadingSource = strGuid;
	
	// add target if sent
	if(strTarget) Events_SetEventAttribute(objEventElement,"Attr.Target",strTarget);


	
	    
	// If is on submit delegate calling 
	if(mblnEventsOnSubmitCalling)
	{
	    // get the current last child
	    var objLastChild = mobjEventBuffer.lastChild;
	    
	    if(objLastChild)
	    {
	        mobjEventBuffer.insertBefore(objEventElement,objLastChild);
	    }
	    else
	    {
	        // add event to buffer
	        mobjEventBuffer.appendChild(objEventElement);
	    }
	}
	else
	{
	    // add event to buffer
	    mobjEventBuffer.appendChild(objEventElement);
	}
		
	// return the created event
	return objEventElement;
}
/// </method>

/// <method name="Events_SetEventAttribute">
/// <summary>
/// Sets an event object attribute.
/// </summary>
/// <param name="objEvent">The event object to set attribute.</param>
/// <param name="strName">The attribute name.</param>
/// <param name="strValue">The attribute value.</param>
/// <param name="blnIsElement">Indicated an attribute/element mode.</param>
function Events_SetEventAttribute(objEvent,strName,strValue,blnIsElement)
{
	// If valid event object
	if(objEvent)
	{
		// if is attribute
		if(!blnIsElement)
		{
			// Set event attribute
			objEvent.setAttribute(String(strName),String(strValue));
		}
		else
		{
			// create new event element
			var objElement = mobjDataDomObject.createElement(String(strName));
			
			// Set event element text
			objElement.text = String(strValue);
			
			// Add event element
			objEvent.appendChild(objElement);
		}
	}
}
/// </method>

/// <method name="Events_UnloadWindow">
/// <summary>
/// Handles the window unload event.
/// </summary>
/// <param name="objWindow">The browser window object.</param>
function Events_UnloadWindow(objWindow)
{
	if(mobjLoadingWindow==objWindow)
	{
		// Clear previous time out
		Web_ClearTimeout(mintLoadingHandle,mobjLoadingWindow);
		mobjLoadingWindow = null;
	}
}
/// </method>

/// <method name="Events_GetLoading">
/// <summary>
/// Gets the loading message.
/// </summary>
/// <param name="strSource">The source ID.</param>
function Events_GetLoading(strSource)
{
    if(!Aux_IsNullOrEmpty(strSource))
    {
        var objSourceNode = Data_GetNode(strSource);
        if(objSourceNode)
        {
	        return Xml_GetAttribute(objSourceNode,"Attr.LoadingMessage","");
	    }
	}
	
	return "";
}
/// </method>

/// <method name="Events_GetAjaxRequstTimeout">
/// <summary>
/// Gets the ajax request timeout seconds.
/// jrt added method at 2013-9-23
/// </summary>
/// <param name="strSource">The source ID.</param>
function Events_GetAjaxRequstTimeout(strSource) {
    if (!Aux_IsNullOrEmpty(strSource)) {
        var objSourceNode = Data_GetNode(strSource);
        if (objSourceNode) {
            try {
                var ajax_timeout = Xml_GetAttribute(objSourceNode, "XhrTM", null);
                if (ajax_timeout) {
                    var result = ajax_timeout * 1;
                    if (result >= 0) {
                        return result;
                    }
                }
            } catch (e) {
               
            }
        }
    }
    return -1;
}

/// <method name="Events_ScheduleLoading">
/// <summary>
/// Sets timeout for displaying loading message.
/// </summary>
/// <param name="intTimerMask">The delay time for displaying mask.</param>
/// <param name="intTimerLoading">The delay time for displaying the loading message. </param>
/// <param name="strSource">The source ID.</param>
function Events_ScheduleLoading(intTimerMask,intTimerLoading,strSource)
{
    // Do not execute method if in delegate calling
	if(mblnEventsOnSubmitCalling) return;
	
	if(mobjLoadingWindow)
	{
		// Clear previous time out
		try
		{
		    Web_ClearTimeout(mintLoadingHandle,mobjLoadingWindow);
		}
		catch(e){}
	}
				
	// Set loading window
	mobjLoadingWindow = Web_GetActiveWindow();

    // Try getting a loading message for current source.
    mstrLoadingMessage = Events_GetLoading(strSource);
    
    // Get message element
    var objElement = Web_GetWebElement("VWG_LoadingMessageBox",mobjLoadingWindow);
    if(objElement)
    {
        Web_SetInnerText(objElement,mstrLoadingMessage,1);
    }

	// Loading screen is potential active
	mblnLoadingIsActive = false;
	
	if(!Aux_IsNullOrEmpty(intTimerMask))
	{
	    // Start hourglass count down
	    mintLoadingHandle = Web_SetTimeout("mobjApp.Events_ShowMask("+intTimerLoading+")",intTimerMask);
	}
	else
	{
		// Show mask immediately
	    Events_ShowMask(intTimerLoading);
	}
	
}
/// </method>

/// <method name="Events_ShowMask">
/// <summary>
/// Dislpays the loading mask.
/// </summary>
/// <param name="intTimerLoading">The delay time to display the loading message.</param>
function Events_ShowMask(intTimerLoading)
{
	if(!mblnLoadingIsActive)
	{
	    // Clear the loading handle
		Web_ClearTimeout(mintLoadingHandle,mobjLoadingWindow);
		
        // Hide loading message
		Events_ChangeLoading(window,true,true,false);
        
        if(!Aux_IsNullOrEmpty(intTimerLoading))
        {
            // Start hourglass count down
		    mintLoadingHandle = Web_SetTimeout("mobjApp.Events_ShowLoading()",intTimerLoading, mobjLoadingWindow);
		}
		else
		{
			// Show loading immediately
		    Events_ShowLoading();
		}
		
        // Indicated that loading is active
		mblnLoadingIsActive = true;
	}
}
/// </method>

/// <method name="Events_ShowLoading">
/// <summary>
/// Dislpays the loading message.
/// </summary>
function Events_ShowLoading()
{
    // Clear the loading handle
	Web_ClearTimeout(mintLoadingHandle,mobjLoadingWindow);
	
    // Shows the loading message
	Events_ChangeLoading(window,true,true,true);
}
/// </method>

/// <method name="Events_ChangeLoading">
/// <summary>
/// Changes loading message and mask status.
/// </summary>
/// <param name="objWindow">The browser window object.</param>
/// <param name="blnIsModal">The flag indicating if in modal mode.</param>
/// <param name="blnShowMask">The flag indicating if to show loading mask.</param>
/// <param name="blnShowLoading">The flag indicating if to show loading message.</param>
function Events_ChangeLoading(objWindow,blnIsModal,blnShowMask,blnShowLoading)
{
	var blnHasModal = false;
	
	// Get indication if active window
	var blnIsActiveWindow = Web_IsActiveWindow(objWindow);
	
	// If has owned windows
	if(objWindow.mobjOwnedWindows)
	{
	    // Loop all owned windows
		for(var strGuid in objWindow.mobjOwnedWindows)
		{
		    // Get current sub window
			var objSubWindow = objWindow.mobjOwnedWindows[strGuid];
			if(objSubWindow)
			{
			    // Check if is modal
			    var blnIsSubModal = objSubWindow.mblnIsModeless==false;
			    blnHasModal = blnHasModal || Events_ChangeLoading(objSubWindow,blnIsSubModal,blnShowMask,blnShowLoading);
			}
		}
	}
	
	// If not modaless and does not have a modal dialog
	if(!blnHasModal || !blnShowMask)
	{
		var objLoadingScreen = Web_GetElementById("VWG_LoadingScreen",objWindow);
		if(objLoadingScreen)
		{
		    // Hide / show the loading screen element.
			objLoadingScreen.style.display=blnShowMask?'block':'none';
			
			// Check whether active source element has a loading message.
			var blnHasLoadingMessage=!Aux_IsNullOrEmpty(mstrLoadingMessage);
			
			// Get active loading box.
			var objLoadingBox = Web_GetElementById(blnHasLoadingMessage?"VWG_LoadingMessageBox":"VWG_LoadingAnimationBox",objWindow);
	        if(objLoadingBox)
	        {
	            // Define a display value - as for active loading box and active browser.
	            var strDisplay = "block";
	            
	            // In case of a loading box - check browser type.
	            if(blnHasLoadingMessage)
	            {
	                if(!mcntIsIE)
	                {
	                    strDisplay = "inline";
	                }
	                else
	                {
	                    strDisplay = "inline-block";
	                }
	            }
	            
		        // Hide / show the loading box element.
		        objLoadingBox.style.display = (blnShowMask && blnShowLoading && blnIsActiveWindow)?strDisplay:"none";
	        }
		}
	}
	
	return blnIsModal || blnHasModal;
}
/// </method>

/// <method name="Events_HideLoading">
/// <summary>
/// Hides the loading message.
/// </summary>
function Events_HideLoading()
{
	if(mobjLoadingWindow)
	{
		try{Web_ClearTimeout(mintLoadingHandle,mobjLoadingWindow)}catch(e){};
	}
	
	if(mblnLoadingIsActive)
	{
		Events_ChangeLoading(window,true,false,false);
		mblnLoadingIsActive = false;
	}
}
/// </method>

/// <method name="Events_ScheduleRaiseEvents">
/// <summary>
/// Sends the event buffer to the application server.
/// </summary>
/// <param name="intDelay">The delay time to use for raising events.</param>
function Events_ScheduleRaiseEvents(intDelay)
{
    // Do not execute method if in delegate calling
	if(mblnEventsOnSubmitCalling) return;
	
	try
	{
	    mintScheduleRaiseEventHandle = Web_SetInterval("mobjApp.Events_RaiseEvents()",intDelay);	    	
    }
	catch(e)
	{
		mintScheduleRaiseEventHandle = Web_SetInterval("mobjApp.Events_RaiseEvents()",intDelay,window);
	}
}
/// </method>

/// <method name="Events_ClearScheduleRaiseEvents">
/// <summary>
/// Clears the Schedule Event Raising. 
/// </summary>
function Events_ClearScheduleRaiseEvents()
{
    // Do not execute method if in delegate calling
	if(mblnEventsOnSubmitCalling) return;
	
	try
	{
	    Web_ClearInterval(mintScheduleRaiseEventHandle);	   
	}
	catch(e)
	{
		Web_ClearInterval(mintScheduleRaiseEventHandle,window);
	}
}

/// </method>


/// <method name="Events_RaiseEventsAndTerminate">
/// <summary>
/// Sends the event buffer to the application server and terminates the application.
/// </summary>
function Events_RaiseEventsAndTerminate()
{
    Events_RaiseEvents(null, true);
}
/// </method>

/// <method name="Events_RaiseEvents">
/// <summary>
/// Sends the event buffer to the application server.
/// </summary>
/// <param name="objCallbackDelegate">An Aux_CallbackDelegate which will be called at the end of the events processing.</param>
/// <param name="blnTerminate">The boolean indicating if appliclication should be terminated.</param>
/// <param name="blnSynchronicLoadingMask">Show the loading screen immediately.</param>
function Events_RaiseEvents(objCallbackDelegate,blnTerminate,blnSynchronicLoadingMask)
{
    // Do not execute method if in delegate calling
	if(mblnEventsOnSubmitCalling) return;
	
	Events_ClearScheduleRaiseEvents();
	
	// if there is an event buffer
	if(mobjEventBuffer!=null)
	{
		// Store callback delegate
        mobjEventsCallbackDelegate = objCallbackDelegate;

        // Raise on submit events
        try
        {
            Events_RaiseOnSubmit();
        }
        catch(e){}
        
		try
		{
		    // Get the active window
		    var objActiveWindow = Web_GetActiveWindow();
		    
		    // If active window is valid and has dialog services
			if(objActiveWindow!=null && objActiveWindow.Events_RaiseDialogEvents!=null)
			{				
				objActiveWindow.Events_RaiseDialogEvents(blnTerminate);
			}
			else
			{
			    // Call the main window instance
				Events_ExecuteRaiseEvents(blnTerminate,null,blnSynchronicLoadingMask);
			}
		}
		catch(e)
		{
		    // Call the main window instance if failed to execute on dialog
			Events_ExecuteRaiseEvents(blnTerminate,null,blnSynchronicLoadingMask);
		}
	}
}
/// </method>

var mblnEventsFiredThroughPipeline = false;


/// <method name="Events_RaiseEventsThroughPipeline">
/// <summary>
/// Gets the event buffer for sending through alternative pipeline
/// </summary>
function Events_RaiseEventsThroughPipeline()
{
    Events_CreateEvent(mstrWindowGuid,"KeepConnected");
        
    var strEvents = "";
    
    if(mobjEventBuffer!=null)
    {
	    // remove the current event buffer
	    var objBody = mobjEventBuffer.parentNode.removeChild(mobjEventBuffer);
		
		// Get last render value out of meta data.
        var strEventID = Data_GetAttribute("/","Attr.LastRender");
        
        // Set last render value on the events buffer.
	    Xml_SetAttribute(objBody,"Attr.LastRender",strEventID);	
	    
	    // get the events buffer body
	    strEvents = Xml_GetOuterXML(objBody);
	    
	    // clear event buffer reference
	    mobjEventBuffer = null;
    }   
    
    // Set timer for opening lodaing message
	Events_ScheduleLoading(30,500,mstrLoadingSource);
	
	// Remove fire mode
    mblnEventFired = true;
    
    // Set events fired from form flag
    mblnEventsFiredThroughPipeline = true;
    
    // End form response validation
    Events_StartFormResponseValidation();
    
    // return the events string
    return strEvents;
}
/// </method>

/// <method name="Events_RaiseEventsThroughForm">
/// <summary>
/// Sends the event buffer to the application server using a form field.
/// </summary>
function Events_RaiseEventsThroughForm(objDocument)
{
    var objPipeline = objDocument.getElementById("vwg_pipeline");
    if(objPipeline!=null)
    {
        objPipeline.value = Events_RaiseEventsThroughPipeline();
    }
}
/// </method>

/// <method name="Events_RaiseEventsThroughXmlHttp">
/// <summary>
/// Sends the event buffer to the application server using a xml http header.
/// </summary>
function Events_RaiseEventsThroughXmlHttp(objXmlHttp)
{
    objXmlHttp.setRequestHeader("vwg_pipeline", Events_RaiseEventsThroughPipeline());
}
/// </method>


/// <method name="Events_HandlesResponseFromXmlHttp">
/// <summary>
/// Handles the server response message that returned from a form xmlhttp communication.
/// </summary>
function Events_HandlesResponseFromXmlHttp(objXmlHttp)
{
    Events_HandlesResponseFromPipeline(objXmlHttp.getResponseHeader("vwg_pipeline"));
}
/// </method>

/// <method name="Events_HandlesResponseFromForm">
/// <summary>
/// Handles the server response message that returned from a form submition.
/// </summary>
function Events_HandlesResponseFromForm(objDocument)
{
    var strResponse = null;
    
    // Get the pipeline field
    var objPipeline = objDocument.getElementById("vwg_pipeline");
    if(objPipeline!=null)
    {
        // Get the pipeline response
        strResponse = objPipeline.value;
        
        // Clean the pipeline field								
        objPipeline.value = "";
    }
    
    // Handle the response
    Events_HandlesResponseFromPipeline(strResponse);
}
/// </method>

/// <method name="Events_HandlesResponseFromForm">
/// <summary>
/// Handles the server response message that returned from a form submition.
/// </summary>
function Events_HandlesResponseFromPipeline(strResponse)
{
    // If events was raised through a form field
    if(mblnEventsFiredThroughPipeline)
    {
        // End form response validation
        Events_EndFormResponseValidation();
        
        // Switch form events submition to false
        mblnEventsFiredThroughPipeline = false;
        
        // Remove fire mode
	    mblnEventFired = false;
		
	    // Hide hourglass
	    Events_HideLoading();
	    
        // If the pipeline field has a valud
        if(strResponse)
        {                   					
            // get current date
	        var objStartedAt = new Date();
	        var intContentLength = 0;
	        var intPostLength = 0;
	        
	        // Get response as a xmldom
	        var objResponse = Xml_CreateElementFromXml(strResponse);    
	    
            // call the callback function.
			Events_HandleResponse(objResponse,objStartedAt,intContentLength,intPostLength);
        }
    }
}
/// </method>



var mintEventsFiredThroughFormValidationHandle = 0;

/// <method name="Events_StartFormResponseValidation">
/// <summary>
/// Provides a mechanism to recover from form response error
/// </summary>
function Events_StartFormResponseValidation()
{    
    mintEventsFiredThroughFormValidationHandle = Web_SetTimeout("Events_DoFormResponseTimeout()",4000);
}
/// </method>

/// <method name="Events_EndFormResponseValidation">
/// <summary>
/// Disables the mechanism to recover from form response error when it is not needed any more
/// </summary>
function Events_EndFormResponseValidation()
{
    Web_ClearTimeout(mintEventsFiredThroughFormValidationHandle);
}
/// </method>

/// <method name="Events_DoFormResponseTimeout">
/// <summary>
/// Handles form response timeout
/// </summary>
function Events_DoFormResponseTimeout()
{
    // End form response validation
    Events_EndFormResponseValidation();
    
    // Switch form events submition to false
    mblnEventsFiredThroughPipeline = false;
    
    // Remove fire mode
    mblnEventFired = false;
	
    // Hide hourglass
    Events_HideLoading();
}
/// </method>

/// <method name="Events_ExecuteRaiseEvents">
/// <summary>
/// Sends the event buffer to the application server.
/// </summary>
/// <param name="blnTerminate">A flag indicating if application termination is required.</param>
/// <param name="objXmlHTTP">The events xml http object.</param>
/// <param name="blnSynchronicLoadingMask">Show the loading screen immediately.</param>
function Events_ExecuteRaiseEvents(blnTerminate, objXmlHTTP,blnSynchronicLoadingMask)
{
	// if there is an event buffer
	if(!mblnEventFired)
	{
	    if(mobjEventBuffer!=null)
	    {
		    Trace_Time("Events","RaiseEvents");
    		
		    // load url
		    var strUrl = mstrBaseURL+"Content."+mstrBasePage+".wgx?vwginstance="+mstrPageInstance;
    		
		    // remove the current event buffer
		    var objBody = mobjEventBuffer.parentNode.removeChild(mobjEventBuffer);
    		
		    // Add trace data if needed
		    Trace_Flush(objBody);
    		
    		// Get last render value out of meta data.
            var strEventID = Data_GetAttribute("/","Attr.LastRender");
            
            // Set last render value on the events buffer.
		    Xml_SetAttribute(objBody,"Attr.LastRender",strEventID);	
		    
		    // get the events buffer body
		    var strBody = Xml_GetOuterXML(objBody);
		    
		    // In case of opera browser - remove namespace decleration.
		    if(mcntIsOpera)
		    {
		        strBody = strBody.replace("xmlns=\"http://www.gizmox.com/webgui\"", "");
		    }
    		
		    // Calculate post length
		    var intPostLength = (String(strBody).length*2/1024).toFixed(2);
    						
		    // clear event buffer reference
		    mobjEventBuffer = null;
    		
		    // Show the sent string if needed
		    if(mblnDebugEvents) 
		    {
		        Debug_LogEvent("Events","Request",strBody, null, objBody);
		    }
    		
		    // set http method
		    var strMethod	= "POST";
    		
		    // create HTTP object
		    if(objXmlHTTP==null) objXmlHTTP = Xml_CreateXmlHttp();
    		
		    // get current date
		    var objStartedAt = new Date();

		    // Set timer(if needed) for opening lodaing message
		    Events_ScheduleLoading(blnSynchronicLoadingMask?null:30, 500, mstrLoadingSource);

		    // define http definitions
		    objXmlHTTP.open(strMethod, strUrl, blnTerminate?false:true);
    		
		    // Store current http handler
		    mobjEventProcesser = objXmlHTTP;

		    // If not in ignore results mode
		    if(!blnTerminate)
		    {
			    // set callback function
			    objXmlHTTP.onreadystatechange = function()
			    {
			        // if response is ready
			        if (objXmlHTTP.readyState == 4) 
			        {
			            // Release XMLHTTP (Important to release soon to indicate processing done)
			            mobjEventProcesser = null;

			            // Remove fire mode
			            mblnEventFired = false;

			            // Hide hourglass
			            Events_HideLoading();

			            //jrt
			            Web_ClearTimeout(mintRequestTimeoutHandle);
			            
			            // Check if current request status is offline.
                        if (!Web_IsOfflineRequestStatus(objXmlHTTP))
			            {		        					
				            // get response xml body
				            var objXmldoc = objXmlHTTP.responseXML;
				            if(objXmldoc)
				            {
					            // get error object
					            var objError = objXmldoc.parseError;
        						
					            // get the error code
					            var intErrot = objError?objError.errorCode:0;
        						
					            // check node error
					            if (intErrot == 0)
					            {
						            // response object 
						            var objResponse = null;
        							
						            // if response ok
						            if(objResponse = objXmldoc.documentElement)
						            {
							            // get content length (causes an exception in chrome)
							            var intContentLength = 0; //objXmlHTTP.getResponseHeader("CONTENT-LENGTH");
        								
							            // call the callback function.
							            Events_HandleResponse(objResponse, objStartedAt, intContentLength, intPostLength);

						            }
						            else
						            {
						                // If not request aborted
						                if(!mblnEventAborted)
				                        {   
							                // Open error window and display content
				                            Events_ShowErrorPage(objXmlHTTP.responseText);
							            }
						            }
					            }

					            // release xmlhttp object
					            objXmlHTTP = null;
				            }
				            else
				            {	
				                // If not request aborted
				                if(!mblnEventAborted)
				                {
					                // Open error window and display content
					                Events_ShowErrorPage(objXmlHTTP.responseText);
					            }
				            }
        					
				            // Force aborted reseting
				            mblnEventAborted = false;
    					    
                            // Check if a re-raise events is neccesary.
                            if(mblnPendingRaiseEvents)
                            {
						        mblnPendingRaiseEvents = false;
                                Events_RaiseEvents();
                            }
                        }
			        }				  
			    };
		    }
    		
		    // Remove fire mode
            mblnEventFired = true;
            
            // Check if request should contain content type header.
            if(mblnAppendRequestContentTypeHeader)
            {
                // Set xml request header
                objXmlHTTP.setRequestHeader("Content-Type", "text/xml");
            }

            //jrt
            try {
                var mstrRequestTimeoutSeconds = Events_GetAjaxRequstTimeout(mstrLoadingSource);
                if (mstrRequestTimeoutSeconds < 0) {
                    mstrRequestTimeoutSeconds = mintRequestTimeoutDefaultValue;
                }
                mintRequestTimeoutHandle = Web_SetTimeout("mobjApp.Events_StopProcessing()", mstrRequestTimeoutSeconds * 1000);

            } catch (e) {}
        
		    // send the http request
		    objXmlHTTP.send(strBody);
	    }
	}
	else
	{
	    // Flag that re-raise events is neccesary.
	    mblnPendingRaiseEvents = true;
	}
}
/// </method>

/// <method name="Events_ShowErrorPage">
/// <summary>
/// Opens an error page and displays the server response message.
/// </summary>
/// <param name="strResponseText">The server response text.</param>
function Events_ShowErrorPage(strResponseText) 
{
    if (!Aux_IsNullOrEmpty(strResponseText))
    {
        // Try to open a new window
        var objWindow = open("", "webgui", "", true);
        if(objWindow)
        {
            // Open error window and display content
            var objDocument = objWindow.document;
            objDocument.open("text/html", "replace");
            objDocument.write(String(strResponseText).replace("ASP.NET", "WebGUI"));
            objDocument.close();
        }
    }
}
/// </method>


/// <method name="Events_HandleResponse">
/// <summary>
/// Handles the server response message.
/// </summary>
/// <param name="objResponse">The server response object.</param>
/// <param name="objStartedAt">The handling starting time.</param>
/// <param name="intContentLength">The response content size.</param>
/// <param name="intPostLength">The length of the request body.</param>
function Events_HandleResponse(objResponse,objStartedAt,intContentLength,intPostLength)
{
	// if there is a response
	if(objResponse)
	{
		// debug view response
		if(mblnDebugEvents)
		{
		    Debug_LogEvent("Events","Response",Xml_GetOuterXML(objResponse), ((new Date())-objStartedAt) + "ms", objResponse);
		}
		
		// Check if running in IE with none inline windows.
		if(mcntIsIE && !mblnInlineWindows)
		{
		    // Get active window.
		    var objActiveWindow = Web_GetActiveWindow();
		    
		    // Validate active window.
		    if(objActiveWindow && objActiveWindow!=mobjApp)
		    {
		        // Get active window id.
	            var strActiveWindowId = objActiveWindow.mstrWindowGuid;
	            if(!Aux_IsNullOrEmpty(strActiveWindowId))
                {
                    // Search if window still exists in response
			        var objForm = Xml_SelectSingleNode("/"+"/WG:Tags.Form[@Id='"+Data_GetDataId(strActiveWindowId)+"']",objResponse);
			        if(objForm==null)
			        {
		                // Generate a new response element through main window.
	                    objResponse = Xml_CreateElementFromXml(objResponse.xml);
			        }
                }
		    }
		}
		
		// Get the last render value and store it in the data behind
		var strLastRender = objResponse.getAttribute("Attr.LastRender");
		
		// If ther is a valid last render value
		if(!Aux_IsNullOrEmpty(strLastRender))
		{
		    // update last render
		    Data_SetAttribute("/","Attr.LastRender",strLastRender);
		}
		
		// Get the current window element
		var objMainFormNode = Xml_SelectSingleNode("/WG:Tags.Response/WG:Tags.Form", objResponse);
		
		// If there is a valid main form node
		if(objMainFormNode)
		{
			// Write to trace
			Trace_Time("Events","HandlesResponse");
			
			// close windows not appearing in response
			if(Forms_ProcessClosed(objResponse))
			{
				// Write to trace
				Trace_Write("Process closed windows.");
				
				// Write to trace
				Trace_Write("Open links.");
				
				// Preserve handled response.
				Forms_HandleResponse.HandledResponse=objResponse;
				
				// Process the current window
				Forms_ProcessForm(window, objMainFormNode, Forms_GetWindowById(Xml_GetAttribute(objMainFormNode,"Attr.Id","")));
				
				// Handle response.
				Forms_HandleResponse();
				
				// Write to trace
				Trace_Write("Process all forms.");
			}
		}
		else
		{
		    // Handle refresh or close response
			Events_HandleTerminationResponse(objResponse);
		}
	}
}
/// </method>

/// <method name="Events_HandleTerminationResponse">
/// <summary>
/// Handles the server close or refresh message.
/// </summary>
/// <param name="objResponse">The server response object.</param>
function Events_HandleTerminationResponse(objResponse)
{
    // If server required refreshing
	if(objResponse.tagName=="WG:Tags.Refresh")
	{
		Web_Refresh(true);
	}
	else
	{
		// Terminate 
		Events_OnTerminate(objResponse);
	}
}
/// </method>

/// <method name="Events_InvokeCallback">
/// <summary>
/// 
/// </summary>
function Events_InvokeCallback()
{
    // If there is a callback delegate
    if(mobjEventsCallbackDelegate!=null)
    {
        Aux_InvokeCallbackDelegate(mobjEventsCallbackDelegate);

        // Clean the delegate
        mobjEventsCallbackDelegate = null;
    }
}
/// </method>

/// <method name="Events_HandleTimers">
/// <summary>
/// Handles server timers.
/// </summary>
/// <param name="objResponse">The server response object.</param>
function Events_HandleTimers(objResponse)
{
	// Check for a valid next invokation timer
	var strTimer = Xml_GetAttribute(objResponse,"Attr.Timer");
	if(!Aux_IsNullOrEmpty(strTimer) && !isNaN(strTimer))
	{
		// Schedule timer connected event
		Events_ScheduleRaiseConnected(Aux_ParseInt(strTimer));
	}
	else
	{
        // Schedule keep connected event
		Events_ScheduleRaiseConnected();
	}
}
/// </method>

/// <method name="Events_OnTerminate">
/// <summary>
/// Terminates the application.
/// </summary>
/// <param name="objResponse">The server response object.</param>
function Events_OnTerminate(objResponse)
{
	// Get application redirect to 
	var strRedirectTo = Xml_GetAttribute(objResponse,"RedirectToUrl");
	
    // If redirect to was found
    if(!Aux_IsNullOrEmpty(strRedirectTo))
    {
        // Close all open windows.
        Forms_CloseAll(true);
        
        // Flag that server is closing main window.
        Events_SetServerClosed(window);
        
        // Set main window location.
        Web_SetMainWindowLocation(strRedirectTo);
    }
    else
    {
        // Get application refferer 
	    var strRefferer = Xml_GetAttribute(objResponse,"Refferer");
	
	    // If refferer was found
	    if(!Aux_IsNullOrEmpty(strRefferer))
        {
		    // Create a form
		    var objForm = document.createElement("FORM");

		    // Attach form to body
		    document.body.appendChild(objForm);
    		
		    // Set form attributes
		    objForm.action = strRefferer;
		    objForm.method = "POST";
		    objForm.target = "_self";
    		
		    // Create hidden test
		    var objRet = document.createElement("INPUT");
		    objRet.type="hidden";
		    objRet.value="1";
		    objRet.name = "test";
		    objRet.id = "test";
		    objForm.appendChild(objRet);
    		
		    // Loop all application results
		    var objResults = Xml_GetEnumerable(Xml_SelectNodes("/WG:Tags.Response/WG:Tags.Row",objResponse));
		    if(objResults.length>0)
		    {
			    var objResult = null;
			    while(objResult = objResults.nextNode())
			    {
				    // Create result as hidden input control
				    var objRet = document.createElement("INPUT");
				    objRet.type="hidden";
				    objRet.value= objResult.getAttribute("Attr.Value");
				    objRet.name = objResult.getAttribute("Attr.Name");
				    objRet.id = objResult.getAttribute("Attr.Name");
				    objForm.appendChild(objRet);
			    }
		    }
    		
		    // Close all open windows.
            Forms_CloseAll(true);
            
            // Flag that server is closing main window.
            Events_SetServerClosed(window);
    		
		    // Submit form
		    objForm.submit();
	    }
	    else
	    {
		    // Clean the document
		    document.body.style.display="none";
		    document.body.innerHTML="";

		    // Close all forms
		    Forms_CloseAll(true);
    		
		    // Close main window
		    try{window.opener = window}catch(e){};
		    Events_SetServerClosed(window);
		    window.close();
	    }
	}
}
/// </method>

/// <method name="Events_IsServerClosed">
/// <summary>
/// Checks if a window object has been closed by the server.
/// </summary>
/// <param name="objWindow">The browser window object.</param>
function Events_IsServerClosed(objWindow)
{
	return objWindow.mblnServerClosed == true;
}
/// </method>

function Events_SetServerClosed(objWindow)
{
	objWindow.mblnServerClosed = true;
}

///+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
/// Event raising
///+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

function Events_FireEvent(strId,strEvent,blnRaise)
{
	var objEvent = Events_CreateEvent(strId,strEvent);
	if(blnRaise) Events_RaiseEvents();
}

/// <method name="Events_Click">
/// <summary>
/// Raises a click event.
/// </summary>
/// <param name="strId">The event source ID</param>
/// <param name="blnRaise">A flag indicating if to raise event.  </param>
/// <param name="blnUnique">A flag indicating if to maintain event uniqueness.</param>
function Events_Click(strId,blnRaise,blnUnique,intPosX, intPosY, blnIsRightClick)
{
    intPosX = intPosX?intPosX:0;
    intPosY = intPosY?intPosY:0;
        
	var objEvent = Events_CreateEvent(strId,"Click",null,blnUnique);
	Events_SetEventAttribute(objEvent,"BTN",blnIsRightClick ? "R" : "L");
	Events_SetEventAttribute(objEvent,"X",intPosX);
    Events_SetEventAttribute(objEvent,"Y",intPosY);
	if(blnRaise) Events_RaiseEvents();
}
/// </method>


/// <method name="Events_DoubleClick">
/// <summary>
/// Raises a double click event.
/// </summary>
/// <param name="strId">The source ID.</param>
/// <param name="blnRaise">A flag indicating if to raise event. </param>
function Events_DoubleClick(strId,blnRaise,intPosX, intPosY)
{
    intPosX = intPosX?intPosX:0;
    intPosY = intPosY?intPosY:0;
    
	var objEvent = Events_CreateEvent(strId,"DoubleClick");
	Events_SetEventAttribute(objEvent,"X",intPosX);
    Events_SetEventAttribute(objEvent,"Y",intPosY);
	if(blnRaise) Events_RaiseEvents();
}
/// </method>

/// <method name="Events_KeyDown">
/// <summary>
/// Raises a key down event.
/// </summary>
/// <param name="strGuid">The source ID.</param>
/// <param name="objDOMEvent">The browser event object.</param>
function Events_KeyDown(strGuid,objDOMEvent)
{
    // Create a key down event.
	var objEvent = Events_CreateEvent(strGuid,"KeyDown");
	
	// Set key down event attributes.
	Events_SetEventKeyAttributes(objEvent,objDOMEvent);
	
	// Return event.
	return objEvent;
}
/// </method>

/// <method name="Events_SetEventKeyAttributes">
/// <summary>
/// Adds keyboard related attributes to the server event.
/// </summary>
/// <param name="objEvent">The server event object.</param>
/// <param name="objDOMEvent">The browser event object.</param>
function Events_SetEventKeyAttributes(objEvent,objDOMEvent)
{
    // Set key code value.
    Events_SetEventAttribute(objEvent,"Attr.KeyCode",Web_GetEventKeyCode(objDOMEvent));
    
    // Set Alt key value.
	if(Web_IsAlt(objDOMEvent)) 
	{
	    Events_SetEventAttribute(objEvent,"Attr.AltKey","1");
	}
	
    // Set Control key value.	
	if(Web_IsControl(objDOMEvent)) 
	{
	    Events_SetEventAttribute(objEvent,"Attr.ControlKey","1");
	}
	
    // Set Shift key value.	
	if(Web_IsShift(objDOMEvent)) 
	{
	    Events_SetEventAttribute(objEvent,"Attr.ShiftKey","1");
	}
}
/// </method>

/// <method name="Events_GotFocus">
/// <summary>
/// Raises a got focus event.
/// </summary>
/// <param name="strId">The source ID.</param>
/// <param name="blnRaise">A flag indicating if to raise event.</param>
function Events_GotFocus(strId)
{
	var objEvent = Events_CreateEvent(strId,"GotFocus",null,true,true);
}
/// </method>

/// <method name="Events_LostFocus">
/// <summary>
/// Raises a lost focus event.
/// </summary>
/// <param name="strId">The source ID.</param>
function Events_LostFocus(strId)
{
	var objEvent = Events_CreateEvent(strId,"LostFocus",null,true,true);
}
/// </method>

/// <method name="Events_ValueChange">
/// <summary>
/// Raises value changed.
/// </summary>
/// <param name="strId">The source ID.</param>
/// <param name="strValue">The event change value.</param>
/// <param name="blnRaise">A flag indicating if to raise event.</param>
function Events_ValueChange(strId,strValue,blnRaise)
{
	var objEvent = Events_CreateEvent(strId,"ValueChange",null,true);
	Events_SetEventAttribute(objEvent,"Value",strValue);
	if(blnRaise) Events_RaiseEvents();
}
/// </method>

/// <method name="Events_CreateTraceableEvent">
/// <summary>
/// Creates a new application server event.
/// </summary>
/// <param name="objWindow">The browser window to set active.</param>
/// <param name="objEvent">The event object to set attribute.</param>
/// <param name="strSource">The ID of the event source.</param>
/// <param name="strType">The type of the event to be created.</param>
/// <param name="strTarget">The target ID.</param>
/// <param name="blnUnique">Indicates whether an event should be unique</param>
/// <param name="blnTypeOnlyUnique">Indicates whether an event should be unique by type only</param>
function Events_CreateTraceableEvent(objWindow,objEvent,strSource,strType,strTarget,blnUnique,blnTypeOnlyUnique)
{   
    // Get source element.
    var objSourceElement = Web_GetElementByDataId(Data_GetDataId(strSource));
    if(objSourceElement)
    {
        // Try getting the vwg_BeforeCreateEventHandler attribute.
        var strBeforeCreateEventHandler = Web_GetAttribute(objSourceElement,"vwg_BeforeCreateEventHandler",true);
        if(!Aux_IsNullOrEmpty(strBeforeCreateEventHandler))
        {
            // Get handler function.
            var fncBeforeCreateEventHandler = Remoting_GetMethod(strBeforeCreateEventHandler);
	        if(fncBeforeCreateEventHandler)
	        {
	            // Create an arguments array.
                var arrArguments = [objWindow,objEvent,strSource,strType,strTarget];
                
                // Invoke function with arguments.
                Aux_InvokeMethod(fncBeforeCreateEventHandler,arrArguments);
	        }            
        }
    }

    // Create a VWG event.
    var objVwgEvent = Events_CreateEvent(strSource,strType,strTarget,blnUnique,blnTypeOnlyUnique);
    
    if(objSourceElement)
    {
        // Try getting the vwg_AfterCreateEventHandler attribute.
        var strAfterCreateEventHandler = Web_GetAttribute(objSourceElement,"vwg_AfterCreateEventHandler",true);
        if(!Aux_IsNullOrEmpty(strAfterCreateEventHandler))
        {
            // Get handler function.
            var fncAfterCreateEventHandler = Remoting_GetMethod(strAfterCreateEventHandler);
	        if(fncAfterCreateEventHandler)
	        {
	            // Create an arguments array.
                var arrArguments = [objWindow,objEvent,strSource,strType,strTarget];
                
                // Invoke function with arguments.
                Aux_InvokeMethod(fncAfterCreateEventHandler,arrArguments);
	        }            
        }
    }
    
    // Return event.
    return objVwgEvent;
}
/// </method>

/// <method name="Events_FormActivated">
/// <summary>
/// Raises the activated event.
/// </summary>
/// <param name="strFormDataId">The form data ID.</param>
function Events_FormActivated(strFormDataId)
{
    Events_CreateEvent(strFormDataId,"Activated",null,true);
}
/// </method>

/// <method name="Events_TextSelectionChanged">
/// <summary>
/// Checks in the input control selected text position
/// and create an event
/// </summary>
/// <param name="strGuid">TextBox guid.</param>
/// <param name="objInput">The input control value</param>
function Events_TextSelectionChanged(strGuid ,objInput) 
{
    var intStart=0;
    var intEnd=0;

    //Get the start and end position
    var objRange = Web_GetSelectionRange(objInput);
    if(objRange)
	{
		 intStart =  objRange.Start;
		 intEnd   =  objRange.End;
	}

    // Create event
    var objSelectionChangedEvent = Events_CreateEvent(strGuid,"SelectionChanged",null,true);
	
    // Set event text attribuet
    Events_SetEventAttribute(objSelectionChangedEvent,"Attr.SelectionStart",intStart);
    Events_SetEventAttribute(objSelectionChangedEvent,"Attr.SelectionLength",intEnd-intStart);
    
    // Update the client meta data.
    Data_SetTextSelectionData(strGuid,intStart,intEnd-intStart);
}
/// </method>