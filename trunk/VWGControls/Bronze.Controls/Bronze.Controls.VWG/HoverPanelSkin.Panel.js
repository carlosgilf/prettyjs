function HoverPanel_Init(strGuid) {
    var objImage=Web_GetElementByDataId(strGuid);
    $(objImage).bind("mouseenter", function () {
        var objNode = Data_GetNode(strGuid);
        if (objNode) {
            //debugger;
            var layer = $(objImage);
            if (!objImage.tempStyle) {
                objImage.tempStyle = layer.attr("style");
            }
            var strOverImage = Xml_GetAttribute(objNode, "HoverImage");
            var strOverColor = Xml_GetAttribute(objNode, "HoverColor");
            var imgLayout = Xml_GetAttribute(objNode, "Attr.BackgroundImageLayout");

            var strBgImage = Xml_GetAttribute(objNode, "Attr.BackgroundImage");

            layer.css("background-color", strOverColor);
            if (strOverImage && strOverImage!="") {
                layer.css("background-image", "url(" + strOverImage + ")");
            }
            if (strBgImage == null || strBgImage == "") {
                if (imgLayout * 1 == 2) {
                    layer.css("background-repeat", "no-repeat");
                    layer.css("background-position", "center center");
                }
                else if (imgLayout * 1 == 0) {
                    layer.css("background-repeat", "no-repeat");
                    layer.css("background-position", "top left");
                }
            }

            var overScript = Xml_GetAttribute(objNode, "OverScript");
            if (overScript) {
                eval(overScript)
            }
        }
    });
    $(objImage).bind("mouseleave", function () {
        var objNode = Data_GetNode(strGuid);
        if (objImage.tempStyle) {
            $(objImage).attr("style", objImage.tempStyle);
        }
        var leaveScript = Xml_GetAttribute(objNode, "LeaveScript");
        if (leaveScript) {
            eval(leaveScript);
        }
    });
}

function HoverPanel_RunLeaveScript(strGuid) {
    var objNode = Data_GetNode(strGuid);
    var leaveScript = Xml_GetAttribute(objNode, "LeaveScript");
    if (leaveScript) {
        eval(leaveScript);
    }
};


function vwg_showMenu(id,option,animate){
    var _option={duration:500,animate:'dropDown'};
    if(isNumber(option)) {
        _option.duration=option;
    }
    if (animate) {
        _option.animate=animate;
    }

    var obj=$(Web_GetElementByDataId(id));

    var delayTimer=obj.attr('delayTimer');
    window.clearInterval(delayTimer);
    if(obj.attr('showed')!='1'){
        obj.attr('showed',1);
        obj.find('.HoverPanelHidden').removeClass('HoverPanelHidden');
        obj[_option.animate](_option.duration);
    }
};

function vwg_hideMenu(id,option,animate){
    var _option={duration:500,animate:'dropUp'};
    if(isNumber(option)) {
        _option.duration=option;
    }
    if (animate) {
        _option.animate=animate;
    }
    var obj=$(Web_GetElementByDataId(id));

    var delayTimer=obj.attr('delayTimer');
    window.clearInterval(delayTimer);
    delayTimer= setInterval(function(){
        window.clearInterval(delayTimer);
        obj[_option.animate](_option.duration);
    },200);
    obj.attr('delayTimer',delayTimer);
};

function isNumber(n) {
	return !isNaN(parseFloat(n)) && isFinite(n);
};

(function($){
	$.fn.dropDown = function(arg,callback){
		var cfg={duration:500,callback:null};
		if(isNumber(arg)) cfg.duration=arg
		else cfg = $.extend(cfg, arg);
        if (callback) {
            cfg.callback=callback;
        }
		
        var obj=$(this);
        obj.css('display','block').children().css('top',-obj.height()).
        stop().animate({top : 0},{
            queue : false,
            duration : cfg.duration,
            easing : cfg.easing || '',
            complete : function(){
                if(cfg.callback)cfg.callback();
            }
        });
	};

	$.fn.dropUp = function(arg,callback){
		var cfg={duration:500,callback:null};
		if(isNumber(arg)) cfg.duration=arg
		else cfg = $.extend(cfg, arg);
        if (callback) {
            cfg.callback=callback;
        }
		var obj=$(this);
	    obj.css('display','block').children().stop().animate({
            top:0-obj.height()
        },
        {
            queue : false,
            duration : cfg.duration,
            easing : cfg.easing || '',
            complete : function(){
                obj.css('display','none');
                obj.attr('showed',0);
                if(cfg.callback)cfg.callback();
            }
        });
	};

	

})(jQuery);
