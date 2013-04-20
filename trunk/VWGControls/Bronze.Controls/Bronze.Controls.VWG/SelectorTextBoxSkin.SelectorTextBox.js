function selector_Init(id, img) {
    if (!img.loaded) {
        img.loaded = true;
        var control = Web_GetElementByDataId(id);
        var objNode = Data_GetNode(id);
        var code = Xml_GetAttribute(objNode, "Attr.Code");
        var items = JSON.parse(code);
        //var obj = $(control);

        var obj = $(img).parent();
        obj.VWG_Id = id;
        obj.addClass("divtxt");
        selector_addBindKey(obj);
        selector_bindItemEvent();
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            selector_addItem(obj, item, false);
        }

    }
}


function selector_addItem(obj, item, isInit) {
    isInit = isInit || false;
    var text = item.Text || "";
    var value = item.Value == null ? "" : item.Value;
    var uid = (item.Id == null ? "" : item.Id);
    var title = item.Tooltip || "";

    var isFind = false;
    obj.find(".one").each(function (i, val) {
        if ($(val).attr("uid") == uid)
            isFind = true;
    });
    if (!isFind) {
        obj.append("<div class=\"one\" val=\"" + value + "\" uid=\"" + uid + "\" title=\"" + title + "\"><b>" + text + "</b>" + "</div>");
        selector_bindItemEvent(obj, uid);
        if (isInit) {
            selector_raiseEvent(obj.VWG_Id, item, false);
        }
    }
};

var selector_raiseEvent = function (obj, item, isRemove) {
    var mstrControlId = obj.VWG_Id;
    //debugger;
    isRemove = (isRemove == true ? "1" : "0");
    // Create event
    var objEvent = Events_CreateEvent(mstrControlId, "ItemsChanged", null, true);

    var items = [];
    obj.find(".one").each(function (i, val) {
        var v = $(val).attr("val");
        var text = $(val).text();
        var id = $(val).attr("uid");
        var title = $(val).attr("title");
        items.push({ Id: id, Text: text, Value: v, Tooltip: title });
    });

    // Set event values attribuet
    //    Events_SetEventAttribute(objEvent, "ItemId", item.Id);
    //    Events_SetEventAttribute(objEvent, "Text", item.Text);
    //    Events_SetEventAttribute(objEvent, "Value", item.Value);
    //    Events_SetEventAttribute(objEvent, "Tooltip", item.Tooltip);
    //    Events_SetEventAttribute(objEvent, "IsRemove", isRemove);

    var json = JSON.stringify(items);
    Events_SetEventAttribute(objEvent, "items", json);

    if (Data_IsCriticalEvent(mstrControlId, mcntEventSelectionChangeId)) {
        // Raise event if critical
        Events_RaiseEvents();
    }
};



function selector_bindItemEvent(obj, uid) {
    $(".divtxt .one[uid='" + uid + "']").
        hover
        (
            function (e) {
                $(this).not(".select").not(".in").addClass("over")
            },
            function () { $(this).removeClass("over") }
        ).
        click(
            function (a) {
                a.stopPropagation();
                $(".divtxt .select").removeClass("select");
                $(this).not(".in").removeClass("over").addClass("select");
                addBind(obj)
            }
        ).
        dblclick(function (b) {
            b.stopPropagation();
            selector_removeItem(obj);
        });
}



function selector_addBindKey(obj) {
    $(document).bind('keydown', function (a) {
        switch (a.keyCode) {
            case 8:
                {
                    return selector_removeItem(obj);
                }
                break;
            case 46:
                {
                    return selector_removeItem(obj);
                }
                break;
        }
    })
}

function selector_removeItem(obj) {
    var curr = obj.find(".select");
    if (curr.html() != null) {
        var uid = curr.attr("uid");
        curr.remove();
        selector_raiseEvent(obj, { Id: uid }, true);
        return false;
    }
}
