function SupperPanel_Init(id, img) {
    if (!img.loaded) {
        img.loaded = true;
        var control = Web_GetElementByDataId(id);
        var objNode = Data_GetNode(id);
        var layer1 = $(control).children("div:first");

        //must found the div who have the class attribute
        if (!layer1.attr("class")) {
            layer1=layer1.children("div:first");
        }
        var radius = Xml_GetAttribute(objNode, "Radius");
        var boxShadow = Xml_GetAttribute(objNode, "BoxShadow");
        if (radius) {
            var newStyle = layer1.attr("style") + ";" + radius
            layer1.attr("style", newStyle);
        }

        var opacity = Xml_GetAttribute(objNode, "Attr.Opacity");
        if (opacity) {
            var _style = layer1.attr("style");
            if (!/;$/.test(_style)) {
                _style += ";";
            }
            var newStyle = _style + opacity
            layer1.attr("style", newStyle);
        }

        if (boxShadow) {
            $(control).addClass("SupperPanel-Radius");
            var newStyle = $(control).attr("style") + ";" + boxShadow + ";" + radius || "";
            $(control).attr("style", newStyle);
        }
    }
}