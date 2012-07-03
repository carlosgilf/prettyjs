
function HoverPanel_Init(strGuid) {
//    var e = window.event || evt;
//    if (window.event) {
//        e.cancelBubble = true;
//    } else {
//        e.stopPropagation();
//    }
    var objImage=document.getElementById('VWG_'+strGuid);
    $(objImage).bind("mouseenter", function () {
        var objNode = Data_GetNode(strGuid);
        if (objNode) {
            //debugger;
            var layer = $(objImage);
            if (!objImage.tempStyle) {
                objImage.tempStyle = layer.attr("style");
            }
            var strOverImage = Xml_GetAttribute(objNode, "HoverImage");
            var strOverColor = Xml_GetAttribute(objNode, "HoverColor");
            var imgLayout = Xml_GetAttribute(objNode, "Attr.BackgroundImageLayout");

            var strBgImage = Xml_GetAttribute(objNode, "Attr.BackgroundImage");

            layer.css("background-color", strOverColor);
            layer.css("background-image", "url(" + strOverImage + ")");
            if (strBgImage == null || strBgImage == "") {
                if (imgLayout * 1 == 2) {
                    layer.css("background-repeat", "no-repeat");
                    layer.css("background-position", "center center");
                }
                else if (imgLayout * 1 == 0) {
                    layer.css("background-repeat", "no-repeat");
                    layer.css("background-position", "top left");
                }
            }

            var overScript = Xml_GetAttribute(objNode, "OverScript");
            if (overScript) {
                eval(overScript)
            }
        }
    });
    $(objImage).bind("mouseleave", function () {
        var objNode = Data_GetNode(strGuid);
        if (objImage.tempStyle) {
            $(objImage).attr("style", objImage.tempStyle);
        }
        var leaveScript = Xml_GetAttribute(objNode, "LeaveScript");
        if (leaveScript) {
            eval(leaveScript);
        }
    });
}




function HoverPanel_MouseOver(objImage, evt, strGuid) {
    var e = window.event || evt;
    if (window.event) {
        e.cancelBubble = true;
    } else {
        e.stopPropagation();
    }

    var objNode = Data_GetNode(strGuid);
    if (objNode) {
        //debugger;
        var layer = $(objImage);
        if (!objImage.tempStyle) {
            objImage.tempStyle = layer.attr("style");
        }
        var strOverImage = Xml_GetAttribute(objNode, "HoverImage");
        var strOverColor = Xml_GetAttribute(objNode, "HoverColor");
        var imgLayout = Xml_GetAttribute(objNode, "Attr.BackgroundImageLayout");

        var strBgImage = Xml_GetAttribute(objNode, "Attr.BackgroundImage");

        layer.css("background-color", strOverColor);
        layer.css("background-image", "url(" + strOverImage + ")");
        if (strBgImage == null || strBgImage == "") {
            if (imgLayout * 1 == 2) {
                layer.css("background-repeat", "no-repeat");
                layer.css("background-position", "center center");
            }
            else if (imgLayout * 1 == 0) {
                layer.css("background-repeat", "no-repeat");
                layer.css("background-position", "top left");
            }
        }

        var overScript = Xml_GetAttribute(objNode, "OverScript");
        if (overScript) {
            eval(overScript);
        }

    }
};

function HoverPanel_MouseLeave(objImage, evt, strGuid) {
    var e = window.event || evt;
    if (window.event) {
        e.cancelBubble = true;
    } else {
        e.stopPropagation();
    }

    var objNode = Data_GetNode(strGuid);
    if (objImage.tempStyle) {
        $(objImage).attr("style", objImage.tempStyle);
    }
    HoverPanel_RunLeaveScript(strGuid);
};

function HoverPanel_RunLeaveScript(strGuid) {
    var objNode = Data_GetNode(strGuid);
    var leaveScript = Xml_GetAttribute(objNode, "LeaveScript");
    if (leaveScript) {
        eval(leaveScript);
    }
};

