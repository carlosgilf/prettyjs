

/// <method name="Layout_PerformLayoutAsynch">
/// <summary>
/// This method performs layout to an unknown element type.
/// </summary>
/// <param name="objElement">The element to perform layout on.</param>
/// <param name="intTimeOut">The required timeout.</param>
function Layout_PerformLayoutAsynch(objElement,intTimeOut)
{
    // Replace empty timeout in default 50 mili-seconds.
    if(intTimeOut==null)
    {
        intTimeOut = 50;
    }
    
    // Perform layout with timeout.	
    Aux_InvokeCallbackDelegateWithDelay(new Aux_CallbackDelegate(Layout_PerformLayout,objElement),intTimeOut);
}
/// </method>

/// <method name="Layout_ContainerResized">
/// <summary>
/// This method performs layout after a container had been resized
/// </summary>
/// <param name="objContainer">The container that has been resized.</param>
function Layout_ContainerResized(objContainer) {
    if ($.browser.msie) {
        //jrt hack IE crash when press F11
        var onResize = function () {
            //The method which alter some css properties triggers 
            //window.resize again and it ends in an infinite loop
            Layout_PerformContainerLayout(objContainer);
        }
        var resizeTimeout=objContainer.getAttribute("rto");
        
        window.clearTimeout(resizeTimeout);
        resizeTimeout = window.setTimeout(onResize, 50);
        objContainer.setAttribute("rto", resizeTimeout);

    }
    else {
        Layout_PerformContainerLayout(objContainer);
    }
}
/// </method>

function Layout_IsAnchoring(strAnchoring,strValue)
{
    return strAnchoring.indexOf(strValue)>-1;
}

function Layout_GetTopPadding(objContainer)
{
    return Layout_ParseInt(objContainer.style.paddingTop);
}

function Layout_GetBottomPadding(objContainer)
{
    return Layout_ParseInt(objContainer.style.paddingBottom);
}


function Layout_GetLeftPadding(objContainer)
{
    return Layout_ParseInt(objContainer.style.paddingLeft);
}


function Layout_GetRightPadding(objContainer)
{
    return Layout_ParseInt(objContainer.style.paddingRight);
}

function Layout_GetLeft(objControl)
{
    return Layout_ParseInt(Web_GetAttribute(objControl,"vwgleft"));
}

function Layout_GetRight(objControl)
{
    return Layout_ParseInt(Web_GetAttribute(objControl,"vwgright"));
}

function Layout_GetTop(objControl)
{
    return Layout_ParseInt(Web_GetAttribute(objControl,"vwgtop"));
}

function Layout_GetBottom(objControl)
{
    return Layout_ParseInt(Web_GetAttribute(objControl,"vwgbottom"));
}

function Layout_ParseInt(strNumber)
{
    var intNumber = parseInt(strNumber);
    if(isNaN(intNumber))
    {
        return 0;
    }
    return intNumber;
}

function Layout_GetVisiblity(objControl)
{
    return Web_GetAttribute(objControl,"vwgvisible")=="1";
}

function Layout_SetVisiblity(objControl,blnVisible)
{
    objControl.style.display = blnVisible ? "block" : "none";
}

function Layout_GetLayoutType(objElement)
{
    return Web_GetAttribute(objElement,"vwgtype");
}


function Layout_IsContainer(objElement)
{
    // Get element type.
    var strElementType = Web_GetAttribute(objElement,"vwgtype", true);
    
    // Check element type.
    return (strElementType=="container" || strElementType=="subcontainer");
}

function Layout_IsNode(objElement)
{
    return objElement.nodeType==1;
};