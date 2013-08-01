(function ($) {
    $.fn.wrapEllipsis = function (height) {
        var p = $(this);
        if (!height) {
            height = p.parent().height();
        }
        while ($(p).outerHeight() > height) {
            $(p).text(function (index, text) {
                return text.substring(0, text.length - 4) + '...';
            });
        }
    };
})(jQuery);

function conactStyle(style1, style2) {
    if (!/;$/.test(style1)) {
        style1 += ";";
    }
    return style1 + style2;
}

function JrtLabel_Init(controlId, sender) {
    var control = Web_GetElementByDataId(controlId);
    var objNode = Data_GetNode(controlId);
    var $ctl = $(control);
    var $inner = $ctl.children("div:first");
    var autoEllipsis = Xml_GetAttribute(objNode, "Attr.AutoEllipsis");
    var radius = Xml_GetAttribute(objNode, "Radius");


    if (autoEllipsis == "1") {
        var labelHeight = $ctl.height();
        var $span = $ctl.find(".Common-Unselectable");
        $span.wrapEllipsis(labelHeight);
    }
    

    var linearGradient = Xml_GetAttribute(objNode, "Linear");
    var innerStyle = '';
    if (radius) {
        innerStyle = conactStyle(innerStyle, radius);
    }

    if (linearGradient) {
        innerStyle = conactStyle(innerStyle, linearGradient);
    }

    if (innerStyle && innerStyle != "") {
        $inner.addClass("SupperPanel-Radius");
        $inner.attr("style", conactStyle($inner.attr("style"), innerStyle));
    }
}



function JrtLabel_MouseOver(strGuid, objImage) {
    var objNode = Data_GetNode(strGuid);
    if (objNode) {
        var $ctl = $(objImage);
        var label = $ctl.find(".Common-Unselectable");
        if (!objImage.tempStyle) {
            objImage.tempStyle = label.attr("style");
        }

        if (!objImage.tempInnerStyle) {
            objImage.tempInnerStyle = $ctl.attr("style");
        }
        
        var strOverImage = Xml_GetAttribute(objNode, "HoverImage");
        var strOverForeColor = Xml_GetAttribute(objNode, "HoverFore");
        var strOverFont = Xml_GetAttribute(objNode, "HoverFont");

        var hoverBgColor = Xml_GetAttribute(objNode, "HoverBgColor");

        if (strOverImage && strOverImage != "") {
            objImage.childNodes[0].style.backgroundImage = "url(" + strOverImage + ")";
        }

        label.css("color", strOverForeColor);
        if (strOverFont && strOverFont != "") {
            label.css("font", strOverFont);
        }
        $ctl.css("background-color", hoverBgColor);

        var hoverLinearGradient = Xml_GetAttribute(objNode, "HoverLinear");
        var innerStyle = '';

        if (hoverLinearGradient) {
            innerStyle = conactStyle(innerStyle, hoverLinearGradient);
        }

        if (innerStyle && innerStyle != "") {
            $ctl.attr("style", conactStyle($ctl.attr("style"), innerStyle));
        }
    }
}

function JrtLabel_MouseLeave(strGuid, objImage) {
    var objNode = Data_GetNode(strGuid);
    var strOverImage = Xml_GetAttribute(objNode, "Attr.Image");
    var strBackColor = Xml_GetAttribute(objNode, "Attr.Background");
    var linearGradient = Xml_GetAttribute(objNode, "Linear");

    if (strOverImage && strOverImage != "") {
        objImage.childNodes[0].style.backgroundImage = "url(" + strOverImage + ")";
    }

    var $ctl = $(objImage);
    var label = $ctl.find(".Common-Unselectable");
//    $ctl.css("background-color", strBackColor || "");

    if (objImage.tempStyle != null) {
        label.attr("style", objImage.tempStyle);
    }    
    
    if (objImage.tempInnerStyle != null) {
        $ctl.attr("style", objImage.tempInnerStyle);
    }

//    var linearGradient = Xml_GetAttribute(objNode, "Linear");
//    var innerStyle = '';

//    if (linearGradient) {
//        innerStyle = conactStyle(innerStyle, linearGradient);
//    }

//    if (innerStyle && innerStyle != "") {
//        $ctl.attr("style", conactStyle($ctl.attr("style"), innerStyle));
//    }

}