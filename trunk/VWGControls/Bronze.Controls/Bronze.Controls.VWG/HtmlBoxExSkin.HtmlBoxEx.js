var me = this;
$(function () {
//    if ($.browser.mozilla || $.browser.webkit) {
//        $("body")[0].onselectstart = null;
//        me.Web_OnSelectStart = null;
//    }
//    else {
        me.Web_OnSelectStart = function (objEvent, objWindow) {
            // Get selection source element
            var objSource = Web_GetEventSource(objEvent);
            if (objSource) {
                if (Web_IsAttribute(objSource, "vwgeditable", "1", true)) {
                    // return if element supports selection
                    return true;
                }
                else {
                    // get parent element
                    var objParent = Web_GetVwgElement(objSource);

                    if (objParent != null) {
                        if (Web_IsAttribute(objParent, "vwgeditable", "1", true)) {
                            //return if parent supports selection
                            return true;
                        }
                        else {
                            strGuid = objParent.id.replace("VWG_", "");
                            var objNode = Data_GetNode(strGuid);
                            var canSelect = Xml_IsAttribute(objNode, "SEL", "1");
                            if (canSelect) {
                                return true;
                            }
                        }
                    }
                }
            }

            // disable default behavior
            Web_EventCancelBubble(objEvent);
        }
//    }
});


