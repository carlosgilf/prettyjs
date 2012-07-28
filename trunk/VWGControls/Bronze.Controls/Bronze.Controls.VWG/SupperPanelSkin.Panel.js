function SupperPanel_Init(id,img) {
    if(!img.loaded) {
        img.loaded=true;
        var control=Web_GetElementByDataId(id);
        var objNode=Data_GetNode(id);
        var layer1=$(control).children("div:first");
        var radius=Xml_GetAttribute(objNode,"Radius");
        if(radius) {
            var newStyle=layer1.attr("style")+";"+radius
            layer1.attr("style",newStyle);
        }
    }
}