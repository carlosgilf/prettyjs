
function Jcrop_Initialize(mstrControlId, objImg, objWindow) {
    if ($(objImg).attr("isLoaded") == "1") {
        return;
    }
    $(objImg).attr("isLoaded", "1");
    var mobjSelection = { x: 0, y: 0, w: 0, h: 0 };
    var Jcrop_Select = function (selection) {
        selection = selection || { x: 0, y: 0, w: 0, h: 0 };
        if ((mobjSelection.w == selection.w && selection.w == 0) || mobjSelection.h == selection.h && selection.h == 0) {
            mobjSelection = selection;
        } else {
            mobjSelection = selection;
            Jcrop_RaiseEvent();
        }
    };

    var Jcrop_Change = function (sel) {
        sel = sel || { x: 0, y: 0, w: 0, h: 0 };
        if (sel.w == sel.h && sel.w == 0 && (mobjSelection.w != 0 || mobjSelection.h != 0)) {
            mobjSelection = sel;
            Jcrop_RaiseEvent();
        }
    };

    var Jcrop_RaiseEvent = function () {
        // Create event
        var objEvent = Events_CreateEvent(mstrControlId, "ValueChange", null, true);

        // Set event values attribuet
        Events_SetEventAttribute(objEvent, "X", mobjSelection.x);
        Events_SetEventAttribute(objEvent, "Y", mobjSelection.y);
        Events_SetEventAttribute(objEvent, "W", mobjSelection.w);
        Events_SetEventAttribute(objEvent, "H", mobjSelection.h);

        if (Data_IsCriticalEvent(mstrControlId, mcntEventSelectionChangeId)) {
            // Raise event if critical
            Events_RaiseEvents();
        }
    };

    var option = {
        onSelect: Jcrop_Select,
        onChange: Jcrop_Change
    };
    var selection = Data_GetAttribute(mstrControlId, "Attr.SelectedImage");
    if (selection) {
        try {
            mobjSelection = eval("(" + selection + ")");
            if (mobjSelection.w != 0 && mobjSelection.h != 0) {
                option.setSelect = [mobjSelection.x, mobjSelection.y, mobjSelection.x + mobjSelection.w, mobjSelection.y + mobjSelection.h];
            }
        }
        catch (e) { }
    }
    var bgOpacity = Data_GetAttribute(mstrControlId, "bgOpacity");
    var bgColor = Data_GetAttribute(mstrControlId, "bgColor");
    var aspectRatio = Data_GetAttribute(mstrControlId, "aspectRatio");

    if (bgOpacity) {
        option.bgOpacity = bgOpacity * 1.0;
    }
    if (bgColor) {
        option.bgColor = bgColor;
    }
    if (aspectRatio) {
        option.aspectRatio = aspectRatio * 1.0;
    }
    $(objImg).Jcrop(option);
}