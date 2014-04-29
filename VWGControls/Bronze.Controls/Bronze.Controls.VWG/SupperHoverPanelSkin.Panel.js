function SupperHoverPanel_Init(strGuid) {
    var objImage=Web_GetElementByDataId(strGuid);
    var objNode=Data_GetNode(strGuid);
    //    var layer1 = $(objImage).children("div:first");
    //    var radius = Xml_GetAttribute(objNode, "Radius");

    //    if(radius){
    //        var newStyle = layer1.attr("style") + ";" + radius
    //        layer1.attr("style", newStyle);
    //    }

    $(objImage).bind("mouseenter", function () {

        if (objNode) {
            //debugger;
            var layer = $(objImage).children("div:first");

            if (!objImage.tempStyle) {
                objImage.tempStyle = layer.attr("style");
            }
            var strOverImage = Xml_GetAttribute(objNode, "HoverImage");
            var strOverColor = Xml_GetAttribute(objNode, "HoverColor");
            var imgLayout = Xml_GetAttribute(objNode, "Attr.BackgroundImageLayout");
            var overScript = Xml_GetAttribute(objNode, "OverScript");

            var strBgImage = Xml_GetAttribute(objNode, "Attr.BackgroundImage");

            if (strOverColor && strOverColor != "") {
                layer.css("background-color", strOverColor);
            }

            if (strOverImage && strOverImage != "") {
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


            if (overScript) {
                eval(overScript);
            }
        }
    });
    $(objImage).bind("mouseleave",function () {
        var objNode=Data_GetNode(strGuid);
        var layer=$(objImage).children("div:first");
        if(objImage.tempStyle) {
            layer.attr("style",objImage.tempStyle);
        }
        var leaveScript=Xml_GetAttribute(objNode,"LeaveScript");
        if(leaveScript) {
            eval(leaveScript);
        }
    });
}

function HoverPanel_RunLeaveScript(strGuid) {
    var objNode=Data_GetNode(strGuid);
    var leaveScript=Xml_GetAttribute(objNode,"LeaveScript");
    if(leaveScript) {
        eval(leaveScript);
    }
};


function vwg_showMenu(id, option, animate, zIndex, relatedId) {
    zIndex = zIndex || 116;
    var _option={ duration: 500,animate: 'dropDown' };
    if(isNumber(option)) {
        _option.duration=option;
    }
    if(animate) {
        _option.animate=animate;
    }
     

    var obj=$(Web_GetElementByDataId(id));

    var last_relatedId = obj.attr('relatedId');
   
    var delayTimer = obj.attr('delayTimer');
    window.clearInterval(delayTimer);
    
    if(option.showManyTimes || obj.attr('showed')!='1') {
        obj.attr('showed', 1);
        if (relatedId) {
            obj.attr('relatedId', relatedId);
        }

        //确保该div显示
        obj.find('.SupperPanel-Hidden').removeClass('SupperPanel-Hidden');
        obj.find('.SupperPanel-VHidden').removeClass('SupperPanel-VHidden');
        obj.css('visibility', 'visible');
        $('[showed]').each(function () {
            if($(this).attr('id')!=obj.attr('id')) {
                $(this).css('z-index', zIndex);
            }
            obj.css('z-index', zIndex+1);
        });
        obj[_option.animate](_option);
    }
};

function vwg_hideMenu(id, option, animate, hideTimeout, onComplete) {
    var _option={ duration: 500,animate: 'dropUp',hideTimeout: 150 };
    if(isNumber(option)) {
        _option.duration=option;
    }
    if(animate) {
        _option.animate=animate;
    }
    if(hideTimeout) {
        _option.hideTimeout=hideTimeout;
    }
    option.showManyTimes=false;
    var obj=$(Web_GetElementByDataId(id));

    var delayTimer=obj.attr('delayTimer');
    window.clearInterval(delayTimer);

    delayTimer = setInterval(function () {
        window.clearInterval(delayTimer);
        obj.attr('showed', 0);
        obj[_option.animate](_option.duration, function () {
            if (onComplete) {
                try {
                    var relatedId = obj.attr('relatedId');
                    onComplete(relatedId);
                } catch (e) {
                }
            }
            obj.attr('showed', 0);
        });
    }, _option.hideTimeout);
    obj.attr('delayTimer',delayTimer);
};

function isNumber(n) {
    return !isNaN(parseFloat(n))&&isFinite(n);
};

(function ($) {
    $.fn.dropDown=function (arg,callback) {
        var cfg={ duration: 500,callback: null };
        if(isNumber(arg)) cfg.duration=arg
        else cfg=$.extend(cfg,arg);
        if(callback) {
            cfg.callback=callback;
        }

        var obj=$(this);

        //obj.children().css('top',-obj.height());
        obj.css('display','block').children().
        stop().css('top',-obj.height()).
        animate({ top: 0 },{
            queue: false,
            duration: cfg.duration,
            easing: cfg.easing||'',
            complete: function () {
                if(cfg.callback) cfg.callback();
            }
        });

    };

    $.fn.dropUp=function (arg,callback) {
        var cfg={ duration: 500,callback: null };
        if(isNumber(arg)) cfg.duration=arg;
        else cfg=$.extend(cfg,arg);
        if(callback) {
            cfg.callback=callback;
        }
        var obj=$(this);
        obj.css('display','block').children().stop().
        css('top',0).
        animate({
            top: 0-obj.height()
            ,opacity: 1
        },
        {
            queue: false,
            duration: cfg.duration,
            easing: cfg.easing||'',
            complete: function () {
                obj.css('display','none');
                if(cfg.callback) cfg.callback();
            }
        });
    };


     $.fn.showUp=function (arg,callback) {
        var cfg={ duration: 500,callback: null };
        if(isNumber(arg)) cfg.duration=arg
        else cfg=$.extend(cfg,arg);
        if(callback) {
            cfg.callback=callback;
        }

        var obj=$(this);

        //obj.children().css('top',-obj.height());
        obj.css('display','block').children().
        stop().css('top',obj.height()*2).
        animate({ top: 0 },{
            queue: false,
            duration: cfg.duration,
            easing: cfg.easing||'',
            complete: function () {
                if(cfg.callback) cfg.callback();
            }
        });

    };



    $.fn.bubbleUp=function (arg,callback) {
        var cfg={ duration: 500,callback: null };
        if(isNumber(arg)) cfg.duration=arg
        else cfg=$.extend(cfg,arg);
        if(callback) {
            cfg.callback=callback;
        }

        var obj=$(this);

        var oldBottom= obj.css("bottom");
        obj.css('display','block').stop().css('bottom', 0 -  obj.height()).
        animate({ bottom: oldBottom },{
            queue: false,
            duration: cfg.duration,
            easing: cfg.easing||'',
            complete: function () {
                if(cfg.callback) cfg.callback();
            }
        });
     };

})(jQuery);


/**
* jQuery Watch Plugin
*
* @author Darcy Clarke
*
* Copyright (c) 2013 Darcy Clarke
* Dual licensed under the MIT and GPL licenses.
*
* Usage:
* $('div').watch('width height', function(){
*   console.log(this.style.width, this.style.height);
* });
*/

(function ($) {

    /**
    * Watch Method
    *
    * @param (String) the name of the properties to watch
    * @param (Object) options to overide defaults (only 'throttle' right now)
    * @param (Function) callback function to be executed when attributes change
    *
    * @return (jQuery Object) returns the jQuery object for chainability
    */
    $.fn.watch = function (props, options, callback) {

        // Div element
        var div = document.createElement('div');

        // Check MutationObserver
        var MutationObserver = window.MutationObserver || window.WebKitMutationObserver || window.MozMutationObserver;

        // CustomEvent with fallback
        var CustomEvent = window.CustomEvent || function () { return arguments || {}; };

        /**
        * Checks Support for Event
        *
        * @param (String) the name of the event
        * @param (Element Object) the element to test support against
        *
        * @return {Boolean} returns result of test (true/false)
        */
        var isEventSupported = function (eventName, el) {
            eventName = 'on' + eventName;
            var supported = (eventName in el);
            if (!supported) {
                el.setAttribute(eventName, 'return;');
                supported = typeof el[eventName] == 'function';
            }
            return supported;
        };

        // Type check options
        if (typeof (options) == 'function') {
            callback = options;
            options = {};
        }

        // Type check callback
        if (typeof (callback) != 'function')
            callback = function () { };

        // Map options over defaults
        options = $.extend({}, { throttle: 10 }, options);

        /**
        * Checks if properties have changed
        *
        * @param (Element Object) the element to watch
        */
        var check = function ($el) {

            var that = this;

            $.each(this.watching, function () {

                // Setup
                var data = this;
                var changed = false;
                var temp;

                // Loop through properties
                for (var i = 0; i < data.props.length; i++) {
                    temp = $el[0].attributes[data.props[i]] || $el.css(data.props[i]);
                    if (data.vals[i] != temp) {
                        data.vals[i] = temp;
                        changed = true;
                        break;
                    }
                }

                // Run callback if property has changed
                if (changed && data.callback)
                    data.callback.call(that, new CustomEvent('AttrChange'));

            });

        };

        // Iterate over each element
        return this.each(function () {

            var that = this;
            var $el = $(this);
            var data = {
                props: props.split(' '),
                vals: [],
                changed: [],
                callback: callback
            };

            // Grab each properties initial value
            $.each(data.props, function (i) {
                data.vals[i] = $el[0].attributes[data.props[i]] || $el.css(data.props[i]);
                data.changed[i] = false;
            });

            // Set data
            if (!this.watching)
                this.watching = [];
            this.watching.push(data);

            // Choose method of watching and fallback
            if (MutationObserver) {
                var observer = new MutationObserver(function (mutations) {
                    mutations.forEach(function (mutation) {
                        callback.call(that, mutation);
                    });
                });
                observer.observe(this, { subtree: false, attributes: true });
            } else if (isEventSupported('DOMAttrModified', div)) {
                $el.on('DOMAttrModified', callback);
            } else if (isEventSupported('propertychange', div)) {
                $el.on('propertychange', callback);
            } else {
                setInterval(function () { check.call(that, $el); }, options.throttle);
            }
        });
    };

})(jQuery);
