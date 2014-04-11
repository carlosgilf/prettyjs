function selector_initOther(id, img) {
   
        img.loaded = true;
        var control = Web_GetElementByDataId(id);
        var obj = $(img).parent();
        obj.addClass("slectorList");
 
}
