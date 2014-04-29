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
        var overable = Xml_GetAttribute(objNode, "Overable");
        if (overable != '0') {
            var $ctl = $(objImage);
            var label = $ctl.find(".Common-Unselectable");
            if (!objImage.tempStyle) {
                objImage.tempStyle = label.attr("style");
            }

            if (!objImage.tempInnerStyle) {
                objImage.tempInnerStyle = $ctl.attr("style");
            }

            var strOverBgImage = Xml_GetAttribute(objNode, "HoverBgImg");
            var strBgImage = Xml_GetAttribute(objNode, "Attr.BackgroundImage");
            var imgLayout = Xml_GetAttribute(objNode, "Attr.BackgroundImageLayout");

            var strOverImage = Xml_GetAttribute(objNode, "HoverImage");
            var strOverForeColor = Xml_GetAttribute(objNode, "HoverFore");
            var strOverFont = Xml_GetAttribute(objNode, "HoverFont");

            var hoverBgColor = Xml_GetAttribute(objNode, "HoverBgColor");

            if (strOverImage && strOverImage != "") {
                //objImage.childNodes[0].style.backgroundImage = "url(" + strOverImage + ")";
                var imgPostion = Xml_GetAttribute(objNode, "ImgPS");
                if (!imgPostion) {
                    objImage.childNodes[0].style.backgroundImage = "url(" + strOverImage + ")";
                }
                else {
                    $ctl.find(".label_icon").attr("src", strOverImage);
                }
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

            if (strOverBgImage && strOverBgImage != "") {
                $ctl.css("background-image", "url(" + strOverBgImage + ")");
            }
            if (strBgImage == null || strBgImage == "") {
                if (imgLayout * 1 == 2) {
                    $ctl.css("background-repeat", "no-repeat");
                    $ctl.css("background-position", "center center");
                }
                else if (imgLayout * 1 == 0) {
                    $ctl.css("background-repeat", "no-repeat");
                    $ctl.css("background-position", "top left");
                }
            }
        }
        var overScript = Xml_GetAttribute(objNode, "OverScript");
        if (overScript) {
            eval(overScript);
        }
    }
}

function JrtLabel_MouseLeave(strGuid, objImage) {
    var objNode = Data_GetNode(strGuid);
    var overable = Xml_GetAttribute(objNode, "Overable");
    if (overable != '0') {
        var strOverImage = Xml_GetAttribute(objNode, "Attr.Image");
        var linearGradient = Xml_GetAttribute(objNode, "Linear");
        var $ctl = $(objImage);
        if (strOverImage && strOverImage != "") {
            var imgPostion = Xml_GetAttribute(objNode, "ImgPS");
            if (!imgPostion) {
                objImage.childNodes[0].style.backgroundImage = "url(" + strOverImage + ")";
            }
            else {
                $ctl.find(".label_icon").attr("src", strOverImage);
            }
        }


        var label = $ctl.find(".Common-Unselectable");

        if (objImage.tempStyle != null) {
            label.attr("style", objImage.tempStyle);
        }

        if (objImage.tempInnerStyle != null) {
            $ctl.attr("style", objImage.tempInnerStyle);
        }
    }
    var leaveScript = Xml_GetAttribute(objNode, "LeaveScript");
    if (leaveScript) {
        eval(leaveScript);
    }
}