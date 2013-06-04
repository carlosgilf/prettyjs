(function ($) {
    $.fn.wrapEllipsis = function (height) {
        var p = $(this);
        if (!height) {
            height = p.parent().height();
        }
        while ($(p).outerHeight() > height) {
            $(p).text(function (index, text) {
                return text.substring(0, text.length - 4) + '...';
            });
        }
    };
})(jQuery);



function JrtLabel_Init(controlId, sender) {
    var control = Web_GetElementByDataId(controlId);
    var $ctl = $(control);
    var labelHeight = $ctl.height();
    var $span = $ctl.find(".Common-Unselectable");
    $span.wrapEllipsis(labelHeight);
}