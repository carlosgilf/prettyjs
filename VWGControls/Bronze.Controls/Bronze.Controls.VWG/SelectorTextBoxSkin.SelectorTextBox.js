//## jqyery plugins

(function ($) {
    $.fn.getCursorPosition = function () {
        var input = this.get(0);
        if (!input) return; // No (input) element found
        if ('selectionStart' in input) {
            // Standard-compliant browsers
            return input.selectionStart;
        } else if (document.selection) {
            // IE
            input.focus();
            var sel = document.selection.createRange();
            var selLen = document.selection.createRange().text.length;
            sel.moveStart('character', -input.value.length);
            return sel.text.length - selLen;
        }
    };

    $.fn.outerHTML = function (s) {
        return s
        ? this.before(s).remove()
        : jQuery("<p>").append(this.eq(0).clone()).html();
    };

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
//#end

function selector_Init(id, img) {
    if (!img.loaded) {
        img.loaded = true;
        var control = Web_GetElementByDataId(id);
        var objNode = Data_GetNode(id);
        var code = Xml_GetAttribute(objNode, "Attr.Code");
        var displayFormat = Xml_GetAttribute(objNode, "Attr.Format");

        var validExp = Xml_GetAttribute(objNode, "Attr.ValueValidationExpression");
        var validExpMsg = Xml_GetAttribute(objNode, "Attr.InValidateMessage");
        var canEdit = Xml_GetAttribute(objNode, "Attr.LabelEdit") == "1";
        var splitStr = Xml_GetAttribute(objNode, "SplitStr");
        if (splitStr) {
            splitStr = splitStr.replace(/\r?\n/g, "\r\n");
        }

        var onRemoveScript = Xml_GetAttribute(objNode, "OnRemove"); ;


        var clientInputDisplayFormat = Xml_GetAttribute(objNode, "ClientInputDisplayFormat");

        var items = JSON.parse(code);

        var obj = $(img).parent();
        obj.splitChar = splitStr;
        obj.clientInputDisplayFormat = clientInputDisplayFormat;
        obj.VWG_Id = id;
        obj.displayFormat = displayFormat;
        obj.canEdit = canEdit;
        if (onRemoveScript) {
            obj.onRemove = onRemoveScript;
        }


        if (validExp) {
            obj.validExp = new RegExp(validExp);
            obj.validExpMsg = validExpMsg;
        }


        obj.addClass("divtxt").attr('vwgeditable', 1).attr('vwgfocuselement', 1);

        obj.mousedown(function (event) {
            event.stopPropagation();
            if (event.keyCode == 8) {
                event.preventDefault();
            }
        });
        obj.click(function (e) {
            e.stopPropagation();

            if (!canEdit) {
                return;
            }
            if (e.srcElement.type == "text") {
                e.srcElement.focus();
                return;
            }
            var x = e.clientX; var y = e.clientY;
            var lastEl = null;
            var firstY_ele = null;
            //找到鼠标点击点的上个对应的item
            obj.find(".one").each(function (i, val) {
                var offset = $(val).offset();
                if (y >= offset.top && y <= offset.top + 20) {
                    if (offset.left < x) {
                        lastEl = val;
                    }
                    if (firstY_ele == null) {
                        firstY_ele = val;
                    }
                }
            });

            $(".divtxt .select").removeClass("select");
            if (lastEl) {
                insertPlaceHoler(obj, lastEl, "after");
            }
            else if (firstY_ele) {
                insertPlaceHoler(obj, firstY_ele, "before");
            }
            else {
                insertPlaceHoler(obj);
            }
        });

        selector_addBindKey(obj);
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            selector_addItem(obj, item, false);
        }
    }
}


function insertPlaceHoler(obj, element, action) {
    var boxWidth = $.browser.msie ? 8 : 80;

    var placeHolder = $("<div class='one placeholder' style='width:" + boxWidth + "px;'><input vwgfocuselement='1' vwgeditable='1' type='input' tabindex='1' autocomplete='off'><b unselectable='on'>&nbsp</b></div>");

    if (element == null) {
        var last = $(".divtxt .one").last();
        if (last.length > 0) {
            if (last.attr('class') == 'one placeholder') {
                $('.placeholder input').focus();
                return;
            }
            else {
                element = last
                action = "after";
            }
        }
    }

    if (element) {
        if (action == 'after') {

            var prevEle = $('.placeholder').prev();
            if (prevEle.length > 0 && prevEle[0] == element) {
                $('.placeholder input').focus();
                //alert(11);
                return;
            }
            removePlaceHolder()
            placeHolder.insertAfter(element);
        }
        else if (action == 'before') {
            removePlaceHolder()
            var preElement = $(element).prev();
            var uid = null;
            if (preElement) {
                var uid = $(preElement).attr("uid");
            }
            placeHolder.insertBefore(element);
        }
    }
    else {
        removePlaceHolder()
        placeHolder.appendTo(obj);
    }

    $('.placeholder').mousedown(function (ev) {
        ev.stopPropagation();
    }).click(function (ev) {
        ev.stopPropagation();
        $(".divtxt .select").removeClass("select");
    });


    $('.placeholder input').focus().autoGrowInput({
        comfortZone: 12,
        minWidth: boxWidth,
        maxWidth: 260,
        callback: function (w) {
            $('.placeholder').width(w);
        }
    }).keydown(function (ev) {
        if (ev.keyCode == 37) {
            //处理Left导航
            var pos = $(this).getCursorPosition();
            if (pos == 0) {
                var item = $('.placeholder').prev();
                if (item.length > 0) {
                    item.insertAfter($('.placeholder').attr('move', 1));
                    setTimeout(function () { $('.placeholder input').focus() }, 100);
                }
            }
        }
        else if (ev.keyCode == 39) {
            //处理Right导航
            var pos = $(this).getCursorPosition();
            if (pos == $(this).val().length) {
                var item = $('.placeholder').next();
                if (item.length > 0) {
                    $('.placeholder').attr('move', 1).insertAfter(item);
                    setTimeout(function () { $('.placeholder input').focus() }, 100);
                }
            }
        }
        else if (ev.keyCode == 8) {
            //处理退格键
            var pos = $(this).getCursorPosition();
            if (pos == 0) {
                ev.preventDefault();
                var prev = $('.placeholder').prev();
                var done = selector_removeItem(obj, prev, true);
            }
        }
        else if (ev.keyCode == 46) {
            //处理删除键
            var pos = $(this).getCursorPosition();
            if (pos == $(this).val().length) {
                var next = $('.placeholder').next();
                selector_removeItem(obj, next, true);
            }
        }

    })
     .keypress(function (event) {
         if (obj.splitChar == null) {
             return;
         }
         var pressChar = String.fromCharCode(event.which);
         if (obj.splitChar.indexOf(pressChar) >= 0) {
             var inputText = $(this).val();
             if ($.trim(inputText).length > 0) {
                 var item = selector_addItem(obj, { FromClient: true, Text: inputText, Value: inputText, Id: inputText }, false, element);
                 event.preventDefault();
                 if (item && item.length > 0) {
                     removePlaceHolder()
                     insertPlaceHoler(obj, item, "after");
                 }
             }
         }
     })
    .blur(function (eve) {
        eve.stopPropagation();
        var inputText = $(this).val();
        var input = $(this);

        if ($('.placeholder').attr('move') == 1) {
            $('.placeholder').attr('move', 0);
            $('.placeholder input').focus();
            return;
        }

        if ($.trim(inputText).length > 0) {
            var item = selector_addItem(obj, { FromClient: true, Text: inputText, Value: inputText, Id: inputText }, false, element);
            if (item && item.length > 0) {
                removePlaceHolder();
            }
        }

        setTimeout(function () {
            //TODO 处理点击divtxt的情况
            //            var target = eve.explicitOriginalTarget || document.activeElement;
            //            if ($(target).attr('class') == 'divtxt') {
            //                input.focus();
            //                return;
            //            }



        }, 1);



    });

    setTimeout(function () { $('.placeholder input').focus() }, 150);

}

function removePlaceHolder() {
    $('.placeholder').remove();
}

//用于外部js调用
function selector_removeText(mstrControlId, itemId) {
    var control = Web_GetElementByDataId(mstrControlId);
    var divtxt = $(control).find('.divtxt');
    //var item = { Id: itemId };
    selector_removeItem(divtxt, itemId, true);
}

function selector_addText(mstrControlId, item, isInit) {
    var control = Web_GetElementByDataId(mstrControlId);
    var divtxt = $(control).find('.divtxt');
    var item = selector_addItem(divtxt, item, isInit);
}

function selector_addTexts(mstrControlId, items, isInit) {
    var control = Web_GetElementByDataId(mstrControlId);
    var divtxt = $(control).find('.divtxt');

    for (var i = 0; i < items.length; i++) {
        selector_addItem(divtxt, items[i], isInit);
    }
}

function selector_addItem(obj, item, isInit, insertAfterEle) {
    isInit = isInit || false;

    var value = item.Value == null ? "" : item.Value;
    var uid = (item.Id == null ? "" : item.Id);
    var title = item.Tooltip || "";
    text = item.Text || "";
    var displayText = text;
    var displayFormat = obj.displayFormat;
    if (item.FromClient) {
        displayFormat = obj.clientInputDisplayFormat;
    }


    //判断insertAfterEle对象是否存在dom中
    if ($(insertAfterEle).parent().length == 0)
        insertAfterEle = null;

    if (displayFormat) {
        displayText = displayFormat.replace("{Text}", text);
        displayText = displayText.replace("{Value}", value);
        displayText = displayText.replace("{Id}", uid);
        displayText = displayText.replace("{Title}", title);
    }

    var isValid = true;
    if (obj.validExp) {
        var testStr = value + "";
        if (!testStr) {
            testStr = uid;
        }

        var matches = obj.validExp.exec(testStr);
        isValid = (matches != null && testStr == matches[0]);
        if (!isValid) {
            title = obj.validExpMsg;
        }
    }

    var isFind = false;
    obj.find(".one").each(function (i, val) {
        if ($(val).attr("uid") == uid)
            isFind = true;
    });
    if (!isFind) {
        var className = "one";
        if (!isValid) {
            className = className + " error";
        }
        var itemHtml = "<div class='" + className + "' client='" + (item.FromClient ? 1 : 0) + "' txt='" + text + "' val='" + value + "' uid='" + uid + "' title='" + title + "'>" + displayText + "<a href='javascript:;' class='addr_del' name='del'></a></div>";
        if (insertAfterEle) {
            $(itemHtml).insertAfter(insertAfterEle);
        }
        else {
            obj.append(itemHtml);
        }
        selector_bindItemEvent(obj, uid);
        if (!isInit) {
            selector_raiseEvent(obj, item, false);
        }
        return $(".divtxt .one[uid='" + uid + "']");
    }
};

var selector_raiseEvent = function (obj, item, isRemove) {
    var mstrControlId = obj.VWG_Id;
    //debugger;
    isRemove = (isRemove == true ? "1" : "0");
    // Create event
    var objEvent = Events_CreateEvent(mstrControlId, "ItemsChanged", null, true);

    var items = [];
    obj.find(".one").not(".error").not(".placeholder").each(function (i, val) {
        var v = $(val).attr("val");
        var text = $(val).attr("txt");
        var id = $(val).attr("uid");
        var title = $(val).attr("title");
        var fromClient = $(val).attr("client");
        var serverObject = { Id: id, Text: text, Value: v, Tooltip: title };
        if (fromClient == "1") {
            serverObject.FromClient = true;
        }
        items.push(serverObject);
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
    $(document).bind('keydown', function (event) {
        switch (event.keyCode) {
            case 8:
                {
                    var done = selector_removeItem(obj);
                    if (done) {
                        event.preventDefault();
                        return false;
                    }
                }
                break;
            case 46:
                {
                    var done = selector_removeItem(obj);
                    if (done) {
                        event.preventDefault();
                        return false;
                    }
                }
                break;
        }
    });

}




function selector_removeItem(obj, item, doNotInsertPlaceHoldler) {
    var curr = null;
    if (item instanceof jQuery) {
        if (item.length == 0) {
            return;
        }
        curr = item;
    }
    else if (item) {
        curr = obj.find(".one[uid='" + item + "'] ");
    }
    else {
        curr = obj.find(".select");
    }

    if (curr.html() != null) {
        var uid = curr.attr("uid");
        var prev = curr.prev();
        curr.remove();
        if (obj.canEdit) {
            if (!doNotInsertPlaceHoldler) {
                if (prev.length > 0) {
                    insertPlaceHoler(obj, prev, "after");
                }
            }
        }

        if (obj.onRemove) {
            var realGlobal = {};
            realGlobal.Id = uid;
            realGlobal.Text = curr.attr("txt");
            realGlobal.Value = curr.attr("val");

            //改变上下文eval
            (new Function("with(this) { " + obj.onRemove + "}")).call(realGlobal);
        }
        selector_raiseEvent(obj, { Id: uid }, true);
        return true;
    }
    return false;
}


