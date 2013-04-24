﻿//## jqyery plugins
(function ($) {
	$.fn.getCursorPosition = function() {
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

		var items = JSON.parse(code);

		var obj = $(img).parent();
		obj.VWG_Id = id;
		obj.displayFormat = displayFormat;
		if (validExp) {
		    obj.validExp = new RegExp(validExp);
		    obj.validExpMsg = validExpMsg;
		}
		

		obj.addClass("divtxt").attr('vwgeditable', 1).attr('vwgfocuselement', 1);

		obj.mousedown(function (ev) { ev.stopPropagation(); });
		obj.click(function (e) {
		    e.stopPropagation();

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

		    var boxWidth = $.browser.msie ? 15 : 80;

		    var placeHolder = $("<div class='one placeholder' style='width:" + boxWidth + "px;'><input vwgfocuselement='1' vwgeditable='1' type='input' tabindex='1' autocomplete='off'><b unselectable='on'>&nbsp</b></div>");
		    if (lastEl) {
		        var uid = $(lastEl).attr("uid");
		        if (uid == $('.placeholder').attr("uid")) {
		            $('.placeholder input').focus();
		            return;
		        }
		        $('.placeholder').remove();
		        placeHolder.insertAfter(lastEl);
		    }
		    else if (firstY_ele) {
		        $('.placeholder').remove();
		        placeHolder.insertBefore(firstY_ele);
		    }
		    else if ($(".divtxt .one").length == 0) {
		        $('.placeholder').remove();
		        placeHolder.appendTo(obj);
		        $('.placeholder').attr('uid','');
		    }

		    $('.placeholder').mousedown(function (ev) { ev.stopPropagation(); })
				.click(function (ev) { ev.stopPropagation(); $(".divtxt .select").removeClass("select"); });

		    $('.placeholder input').focus().autoGrowInput({
		        comfortZone: 10,
		        minWidth: boxWidth,
		        maxWidth: 260,
		        callback: function (w) { $('.placeholder').width(w); }
		    }).keydown(function (ev) {
		        if (ev.keyCode == 37) {
		            var pos = $(this).getCursorPosition();
		            //alert(pos);
		        }
		    })
			.blur(function (eve) {
			    var inputText = $(this).val();
			    if ($.trim(inputText).length > 0) {
			        selector_addItem(obj, { Text: inputText, Id: inputText }, false, lastEl);
			        $('.placeholder').remove();
			    }
			});
		});

		selector_addBindKey(obj);
		for (var i = 0; i < items.length; i++) {
			var item = items[i];
			selector_addItem(obj, item, false);
		}
	}
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

    var isValid = true;
    if (obj.validExp) {
        var testStr = value+"";
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
        var itemHtml = "<div class='" + className + "' txt='" + text + "' val='" + value + "' uid='" + uid + "' title='" + title + "'>" + displayText + "<a href='javascript:;' class='addr_del' name='del'></a></div>";
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
	obj.find(".one").not(".error").not(".placeholder").each(function (i, val) {
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
