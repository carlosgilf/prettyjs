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
						newWidth = (testerWidth + o.comfortZone) >= minWidth ? (testerWidth + o.comfortZone) : minWidth,
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

function copyFileds(toObj, fromObj) {
    for (var i in fromObj) {
        toObj[i] = fromObj[i];
    }
    return toObj;
}

Array.prototype.remove = function (item) {
    var idx = this.indexOf(item);
    if (idx != -1) {
        this.splice(idx, 1);
    }
}
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

        var onRemoveScript = Xml_GetAttribute(objNode, "OnRemove");
        var onChangedScript = Xml_GetAttribute(objNode, "OnChanged");
        var clientInputDisplayFormat = Xml_GetAttribute(objNode, "ClientInputDisplayFormat");

        var items = JSON.parse(code);
        var initData = {};
        initData.splitChar = splitStr;
        initData.clientInputDisplayFormat = clientInputDisplayFormat;
        initData.VWG_Id = id;
        initData.displayFormat = displayFormat;
        initData.canEdit = canEdit;
        initData.items = [];
        if (onRemoveScript) {
            initData.onRemove = onRemoveScript;
        }
        if (onChangedScript) {
            initData.onChanged = onChangedScript;
        }

        if (validExp) {
            initData.validExp = new RegExp(validExp);
            initData.validExpMsg = validExpMsg;
        }

        window["selector_" + id] = initData;

        var obj = $(img).parent();
        copyFileds(obj, initData);


        obj.addClass("divtxt").attr('vwgeditable', 1).attr('vwgfocuselement', 1);
        selector_bindItemEvent(obj);

        obj.mousedown(function (event) {
            event.stopPropagation();
            if (event.keyCode == 8) {
                event.preventDefault();
            }
        });

        obj.scroll(function () {
            //isScrolledIntoView();
        });

        obj.click(function (e) {
            e.stopPropagation();
            if (e.target != this) {
                if (e.target.tagName.toLowerCase() == "td" || e.target.tagName.toLowerCase() == "table") {

                }
                else {
                    return;
                }
            }
            if (!canEdit) {
                return;
            }

            obj.find('.EmptyMsg').css("display", "none");
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
        selector_addItems(obj, items, true);
        selector_fireOnChanged(obj);
    }
}

//用于外部js调用
function selector_getItemCount(mstrControlId) {
    try {
        var initData = window["selector_" + mstrControlId];
        if (initData) {
            return initData.items.length;
        }
    } catch (e) {

    }
    return 0;
    //    var control = Web_GetElementByDataId(mstrControlId);
    //    var texts = obj.find(".one").not(".error").not(".placeholder");
    //    return texts.length;
}

function selector_removeText(mstrControlId, itemId) {
    var initData = window["selector_" + mstrControlId];
    if (initData) {
        var control = Web_GetElementByDataId(mstrControlId);
        var divtxt = $(control).find('.divtxt');
        copyFileds(divtxt, initData);
        selector_removeItem(divtxt, itemId, true);
    }
}

//批量删除
function selector_removeTexts(mstrControlId, arrayItemIds, isCallOnRemove) {
    var initData = window["selector_" + mstrControlId];
    if (initData) {
        var control = Web_GetElementByDataId(mstrControlId);
        var divtxt = $(control).find('.divtxt');
        copyFileds(divtxt, initData);
        selector_removeItems(divtxt, arrayItemIds, isCallOnRemove);
    }
}

function selector_clean(mstrControlId) {
    var initData = window["selector_" + mstrControlId];
    if (initData) {
        var control = Web_GetElementByDataId(mstrControlId);
        var divtxt = $(control).find('.divtxt');
        var emptyMsg = divtxt.find('.EmptyMsg').clone();
        divtxt.empty();
        divtxt.append(emptyMsg);
        initData.items = [];
    }
}

function selector_addText(mstrControlId, item, isInit) {
    var initData = window["selector_" + mstrControlId];
    if (initData) {
        var control = Web_GetElementByDataId(mstrControlId);
        var divtxt = $(control).find('.divtxt');
        copyFileds(divtxt, initData);
        var item = selector_addItem(divtxt, item, isInit);
    }
}

//批量添加
function selector_addTexts(mstrControlId, items, isInit) {
    var initData = window["selector_" + mstrControlId];
    if (initData) {
        var control = Web_GetElementByDataId(mstrControlId);
        var divtxt = $(control).find('.divtxt');
        copyFileds(divtxt, initData);
        selector_addItems(divtxt, items, isInit);
    }
}

function selector_saveOtherInfo(obj, info) {
    var mstrControlId = obj.VWG_Id;
    // Create event
    var objEvent = Events_CreateEvent(mstrControlId, "SaveOtherInfo", null, true);
    Events_SetEventAttribute(objEvent, "info", info);
    if (Data_IsCriticalEvent(mstrControlId, mcntEventSelectionChangeId)) {
        // Raise event if critical
        Events_RaiseEvents();
    }
}

function selector_addItems(obj, items, isInit) {
    var htmls = "";
    for (var i = 0; i < items.length; i++) {
        var itemHtm = selector_addItem(obj, items[i], true, null, true);
        if (itemHtm) {
            htmls += itemHtm;
        }
    }
    obj.append(htmls);
    if (!isInit) {
        selector_raiseEvent(obj, null, false);
    }
}

function selector_addItem(obj, item, isInit, insertAfterEle, isBatch) {
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
    if (insertAfterEle && $(insertAfterEle).parent().length == 0)
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
    var initData = window["selector_" + obj.VWG_Id];
    if (initData) {
        if (initData.items && initData.items._indexOf(uid) > -1) {
            isFind = true;
        }
    }

    if (!isFind) {
        initData.items.push(item);
        var className = "one";
        if (!isValid) {
            className = className + " error";
        }
        var itemHtml = "<div class='" + className + "' client='" + (item.FromClient ? 1 : 0) + "' txt='" + text + "' val='" + value + "' uid='" + uid + "' title='" + title + "'><span class='tagText'>" + displayText + "</span><a href='javascript:;' class='selector_close'><span class='text-icon'>×</span></a><a href='javascript:;' class='selctor_focus'></a></div>";

        if (isBatch == true) {
            return itemHtml;
        }
        else {
            if (insertAfterEle) {
                $(itemHtml).insertAfter(insertAfterEle);
            }
            else {
                obj.append(itemHtml);
            }
            if (!isInit) {
                selector_raiseEvent(obj, item, false);
            }
            return obj.find(".one[uid='" + uid + "']");
        }
    }
};

function selector_removeItem(obj, item, doNotInsertPlaceHoldler) {
    var curr = null;
    var uid = null;
    if (item instanceof jQuery) {
        if (item.length == 0) {
            return;
        }
        curr = item;
    }
    else if (item) {
        curr = obj.find(".one[uid='" + item + "'] ");
        uid = item;
    }
    else {
        curr = obj.find(".select");
    }

    if (curr.html() != null) {
        if (!uid) {
            uid = curr.attr("uid");
        }
        var initData = window["selector_" + obj.VWG_Id];
        if (initData) {
            initData.items._remove(uid);
        }
        obj.items = initData.items;
        var realGlobal = {};
        if (obj.onRemove) {
            realGlobal.Id = uid;
            realGlobal.Text = curr.attr("txt");
            realGlobal.Value = curr.attr("val");
        }

        if (obj.canEdit) {
            if (!doNotInsertPlaceHoldler) {
                var prev = curr.prev();
                if (prev.length > 0) {
                    insertPlaceHoler(obj, prev, "after");
                }
            }
        }
        curr.remove();
        if (obj.onRemove) {
            realGlobal.Items = initData.items;
            realGlobal.context = obj;
            //改变上下文eval
            (new Function("with(this) { " + obj.onRemove + "}")).call(realGlobal);
        }
        selector_raiseEvent(obj);
        return true;
    }
    return false;
}

//批量删除
function selector_removeItems(obj, arrayItemIds, isCallOnRemove) {
    var initData = window["selector_" + obj.VWG_Id];
    if (!initData) {
        return;
    }
    var items = obj.find(".one");
    for (var i = 0; i < items.length; i++) {
        var item = items[i];
        var curr = $(item);
        var uid = curr.attr("uid");
        if (arrayItemIds.indexOf(uid) >= 0) {
            var realGlobal = {};
            if (isCallOnRemove && obj.onRemove) {
                realGlobal.Id = uid;
                realGlobal.Text = curr.attr("txt");
                realGlobal.Value = curr.attr("val");
            }
            curr.remove();
            initData.items._remove(uid);
            obj.items = initData.items;
            if (isCallOnRemove && obj.onRemove) {
                realGlobal.Items = initData.items;
                realGlobal.context = obj;
                //改变上下文eval
                (new Function("with(this) { " + obj.onRemove + "}")).call(realGlobal);
            }
        }
    }
    selector_raiseEvent(obj);
}

var selector_raiseEvent = function (obj) {
    var items = [];
    var actualTexts = obj.find(".one").not(".placeholder");
    if (actualTexts.length > 0) {
        obj.find('.EmptyMsg').css("display", "none");
    }
    else {
        obj.find('.EmptyMsg').css("display", "block");
    }

    var texts = actualTexts.not(".error");

    for (var i = 0; i < texts.length; i++) {
        var item = texts[i];
        var vl = item.getAttribute("val");
        var text = item.getAttribute("txt");
        var id = item.getAttribute("uid");
        var title = item.getAttribute("title");
        var fromClient = item.getAttribute("client");
        var serverObject = { Id: id, Text: text, Value: vl };
        if (title && title != "") {
            serverObject.Tooltip = title;
        }
        if (fromClient == "1") {
            serverObject.FromClient = true;
        }
        items.push(serverObject);
    }

    var json = JSON.stringify(items);
    var compressed = LZString.compressToBase64(json);
    
    var mstrControlId = obj.VWG_Id;
    // Create event
    var objEvent = Events_CreateEvent(mstrControlId, "ItemsChanged", null, true);
    Events_SetEventAttribute(objEvent, "items", compressed);
    if (Data_IsCriticalEvent(mstrControlId, mcntEventSelectionChangeId)) {
        // Raise event if critical
        Events_RaiseEvents();
    }

    selector_fireOnChanged(obj);

};

function selector_fireOnChanged(obj) {
    //执行onChanged事件
    if (obj.onChanged) {
        var realGlobal = {};
        realGlobal.Id = obj.VWG_Id;
        realGlobal.Items = obj.items;
        realGlobal.context = obj;
        //改变上下文eval
        (new Function("with(this) { " + obj.onChanged + "}")).call(realGlobal);
    }
}

function selector_bindItemEvent(obj, uid) {
    obj.delegate(".one:not('.placeholder')", "hover click dblclick", function (event) {
        if (event.type === 'mouseover') {
            $(this).not(".select").not(".in").addClass("over");
        }
        else if (event.type === 'mouseout') {
            $(this).removeClass("over");
        }
        else if (event.type === "click") {
            event.stopPropagation();
            $(this).find(".selctor_focus").focus();
            obj.find(".select").removeClass("select");
            $(this).not(".in").removeClass("over").addClass("select");
        }
        else if (event.type === "dblclick") {
            event.stopPropagation();
            selector_removeItem(obj);
            return false;
        }
        return false;
    });

    obj.delegate(".one .selctor_focus", "blur", function () {
        $(".divtxt .select").removeClass("select");
        $(this).not(".in").removeClass("over").addClass("select");
    });


    obj.delegate(".one .selector_close", "click", function () {
        var item = $(this).parent();
        selector_removeItem(obj, item, true);
    });
}

function insertPlaceHoler(obj, element, action) {
    var boxWidth = $.browser.msie ? 4 : 80;

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
        comfortZone: 10,
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

function isScrolledIntoView($elem, $contanier) {
    var docViewTop = $contanier.scrollTop();
    var docViewBottom = docViewTop + $contanier.height();

    var elemTop = $elem.offset().top;
    var elemBottom = elemTop + $elem.height();

    return ((elemBottom <= docViewBottom) && (elemTop >= docViewTop));
}


Array.prototype._indexOf = function (id, prop) {
    for (var i = 0; i < this.length; i++) {
        var item = this[i];

        if (prop) {
            if (item[prop] == id)
                return i;
        }
        else {
            if (item.Id == id)
                return i;
        }
    }
    return -1;
}

Array.prototype._remove = function (id, prop) {
    for (var i = 0; i < this.length; i++) {
        var item = this[i];

        if (prop) {
            if (item[prop] == id)
                this.splice(i, 1);
        }
        else {
            if (item.Id == id)
                this.splice(i, 1);
        }
    }
    return -1;
}
