function ScheduleBox_DoubleClick(strGuid, objWindow, objEvent) {
    Events_DoubleClick(strGuid, true);
}

function ScheduleBox_Click(strGuid, objWindow, objEvent) {
    Web_EventCancelBubble(objEvent);
}

//jrt added item click event
function ScheduleBox_RowClick(objEvent, strGuid, ele, displayMode) {
    var time = null;
    if (displayMode == "wA" || displayMode == "wB") {
        var rowIdx = $(ele).index();
        var currentRow = $(ele).parent();
        if (displayMode == "wB") {
            rowIdx += 3;
        }

        var cols = $(ele).closest('table').find("> tbody > tr:first >td");
        var col = cols.get(rowIdx);
        var day = $(col).text();
        var re = /\(.+\)/i;
        day = day.replace(re, "").replace(/\s+/g, "");
        if (((day.length - day.replace(new RegExp("/", "g"), '').length)) == 1) {
            day = new Date().getFullYear() + "年" + day.replace("/", "月") + "日";
        }
        var timeIndex = currentRow.index() - 1;
        var clock = Math.floor(timeIndex / 2);
        var isAm = timeIndex % 2 == 0;
        time = day + " " + clock + ":" + (isAm ? "00" : "30");
    }
    else {
        var day = $(ele).attr("vwg_day");
        var month = $(ele).closest('table').attr("vwg_month");
        time = month + day + "日";
    }

    // jrt 2014-5-30 Added RowItemClick event
    var objEvent = Events_CreateEvent(strGuid, "RowItemClick", true);
    if (Data_IsCriticalEvent(strGuid, mcntEventCheckedChangeId)) {
        Events_SetEventAttribute(objEvent, "time", time);
        Events_RaiseEvents();
    }

}