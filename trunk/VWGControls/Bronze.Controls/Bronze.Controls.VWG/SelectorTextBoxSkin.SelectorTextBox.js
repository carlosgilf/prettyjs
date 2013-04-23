(function ($) {

    $.fn.autoGrowInput = function (o) {

        o = $.extend({
            maxWidth: 1000,
            minWidth: 0,
            comfortZone: 70,
            callback: null
        }, o);

        this.filter('input:text').each(function () {

            var minWidth = o.minWidth || $(this).width(),
                val = '',
                input = $(this),
                testSubject = $('<tester/>').css({
                    position: 'absolute',
                    top: -9999,
                    left: -9999,
                    width: 'auto',
                    fontSize: input.css('fontSize'),
                    fontFamily: input.css('fontFamily'),
                    fontWeight: input.css('fontWeight'),
                    letterSpacing: input.css('letterSpacing'),
                    whiteSpace: 'nowrap'
                }),
                check = function () {

                    if (val === (val = input.val())) { return; }

                    // Enter new content into testSubject
                    var escaped = val.replace(/&/g, '&amp;').replace(/\s/g, '&nbsp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
                    testSubject.html(escaped);

                    // Calculate new width + whether to change
                    var testerWidth = testSubject.width(),
                        newWidth = (testerWidth + o.comfortZone) >= minWidth ? testerWidth + o.comfortZone : minWidth,
                        currentWidth = input.width(),
                        isValidWidthChange = (newWidth < currentWidth && newWidth >= minWidth)
                                             || (newWidth > minWidth && newWidth < o.maxWidth);

                    // Animate width
                    if (isValidWidthChange) {
                        input.width(newWidth);
                    }
                    if (o.callback) {
                        o.callback(input.width());
                    }
                };

            testSubject.insertAfter(input);

            $(this).bind('keyup keydown blur update', check);

        });

        return this;

    };

})(jQuery);


function selector_Init(id, img) {
    if (!img.loaded) {
        img.loaded = true;
        var control = Web_GetElementByDataId(id);
        var objNode = Data_GetNode(id);
        var code = Xml_GetAttribute(objNode, "Attr.Code");
        var displayFormat = Xml_GetAttribute(objNode, "Attr.Format");
        var items = JSON.parse(code);

        var obj = $(img).parent();
        obj.VWG_Id = id;
        obj.displayFormat = displayFormat;

        obj.addClass("divtxt").attr('vwgeditable', 1).attr('vwgfocuselement', 1);

        obj.mousedown(function (ev) { ev.stopPropagation(); });
        obj.click(function (e) {
            e.stopPropagation();

            var lastEl = findPrevItem(obj,e);
            if (lastEl) {
                $(".divtxt .select").removeClass("select");

                var uid = $(lastEl).attr("uid");
                if (uid == $('.placeholder').attr("uid")) {
                    $('.placeholder input').focus();
                    return;
                }
                $('.placeholder').remove();

                var boxWidth = $.browser.msie ? 15 : 80;


                $("<div uid='" + uid + "' class='one placeholder' style='width:" + boxWidth + "px;'><input vwgfocuselement='1' vwgeditable='1' type='input' tabindex='1' autocomplete='off'><b unselectable='on'>&nbsp</b></div>")
                    .insertAfter(lastEl);
                $('.placeholder').mousedown(function (ev) { ev.stopPropagation(); })
                    .click(function (ev) { ev.stopPropagation(); $(".divtxt .select").removeClass("select"); });

                $('.placeholder input').focus().autoGrowInput({
                    comfortZone: 10,
                    minWidth: boxWidth,
                    maxWidth: 260,
                    callback: function (w) { $('.placeholder').width(w); }
                })
                .blur(function (eve) {
                    var inputText = $(this).val();
                    if ($.trim(inputText).length > 0) {
                        selector_addItem(obj, { Text: inputText, Id: inputText }, false, lastEl);
                        $('.placeholder').remove();
                    }
                });

            }
        });

        

        selector_addBindKey(obj);
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            selector_addItem(obj, item, false);
        }
    }
}

//找到鼠标点击点的上个对应的项目
function findPrevItem(obj,e) {
    if (e.srcElement.type == "text" ) {
        e.srcElement.focus();
        return;
    }
    var x = e.clientX; var y = e.clientY;
    var lastEl = null;
    var lastY_ele = null;
    obj.find(".one").each(function (i, val) {
        var offset = $(val).offset();
        if (y >= offset.top && y <= offset.top + 20) {
            if (offset.left < x) {
                lastEl = val;
            }
            lastY_ele = val;
        }
    });

    if (!lastEl) {
        lastEl = lastY_ele;
    }
//    if (!lastEl) {
//        lastEl = obj.find(".one").not(".placeholder").last();
//    }

    return lastEl;
}

//用于外部js调用
function selector_addText(mstrControlId, item, isInit) {
    var control = Web_GetElementByDataId(id);
    var divtxt = $(control).find('.divtxt');
    selector_addItem(divtxt, item, isInit);
}

var isFirstItem = true;
function selector_addItem(obj, item, isInit, insertAfterEle) {
    isInit = isInit || false;
    
    var value = item.Value == null ? "" : item.Value;
    var uid = (item.Id == null ? "" : item.Id);
    var title = item.Tooltip || "";
    text = item.Text || "";
    var displayText = text;
    var displayFormat = obj.displayFormat;
    
    if (displayFormat) {
        displayText = displayFormat.replace("{Text}", text);
        displayText = displayText.replace("{Value}", value);
        displayText = displayText.replace("{Id}", uid);
        displayText = displayText.replace("{Title}", title);
    }

    var isFind = false;
    obj.find(".one").each(function (i, val) {
        if ($(val).attr("uid") == uid)
            isFind = true;
    });
    if (!isFind) {
        var itemHtml = "<div class='one' txt='" + text + "' val='" + value + "' uid='" + uid + "' title='" + title + "'>" + displayText + "<a href='javascript:;' class='addr_del' name='del'></a></div>";
        if (insertAfterEle) {
            $(itemHtml).insertAfter(insertAfterEle);
        }
        else {
            obj.append(itemHtml);
        }
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
        var text = $(val).attr("txt");
        var id = $(val).attr("uid");
        var title = $(val).attr("title");
        items.push({ Id: id, Text: text, Value: v, Tooltip: title });
    });

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
                $(this).not(".select").not(".in").addClass("over");
            },
            function () { $(this).removeClass("over"); }
        ).
        click(
            function (a) {
                a.stopPropagation();
                $(".divtxt .select").removeClass("select");
                $(this).not(".in").removeClass("over").addClass("select");
                $(".divtxt .select .addr_del").focus();
            }
        ).
        dblclick(function (b) {
            b.stopPropagation();
            selector_removeItem(obj);
        });


        $(".divtxt .one[uid='" + uid + "'] .addr_del").blur(function () {
            $(".divtxt .select").removeClass("select");
            $(this).not(".in").removeClass("over").addClass("select");
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
