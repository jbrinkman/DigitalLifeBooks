/// <reference path="/Resources/Shared/jquery/jquery-ui.js" />

$(function () {
    GetChildren();
    getAllChildElements();

    $("#txtEventDate").datepicker();

    $('#btnGo').click(function () {
        getAllChildElements();
    });

    $('#selEvent').change(function () {
        setHiddenEventId();
    });


    $('#btnCreateNewEvent').click(function () {
        if (isNullOrEmptyString(getHiddenChildId())) {
            alert("Must first select a child.");
            return;
        }

        var eventTitle = document.getElementById('txtNewEventName').value;
        var eventDescription = document.getElementById('txtEventDescription').value;
        var eventDate = document.getElementById('txtEventDate').value;

        if (isNullOrEmptyString(eventTitle) ||
            isNullOrEmptyString(eventDescription) ||
            isNullOrEmptyString(eventDate)) {
            alert("Event title, description, and date are required.");
            return;
        }

        var parms = { ChildId: getHiddenChildId(),
            EventTitle: document.getElementById('txtNewEventName').value,
            EventDescription: document.getElementById('txtEventDescription').value,
            EventDate: document.getElementById('txtEventDate').value
        };
        jQuery.ajax({
            type: "POST",
            url: "/DesktopModules/DigitalLifeBooks/API/Edit.ashx/InsertEvent",
            async: false,
            data: parms,
            dataType: "text",
            success: function (response) {
                document.getElementById('txtNewEventName').value = "";
                document.getElementById('txtEventDescription').value = "";
                document.getElementById('txtEventDate').value = "";
                GetChildContent();
                GetEvents();

            },
            error: function (httpRequest, textStatus, errorThrown) {
                determineError("Error: Failed to retrieve child.");
            }
        });
    });


});

function GetChildren() {
    $("#selChildren option").remove();
    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/DigitalLifeBooks/API/Edit.ashx/GetChildren",
        async: false,
        data: {},
        dataType: "json",
        success: function (response) {
            if (response == "") {
                determineError("Error: Failed to retrieve child.");
                return false;
            }

            $.each(response, function (index, item) {
                var option = document.createElement("option");
                option.text = item.Text;
                option.value = item.Value;
                var selectList = document.getElementById('selChildren');
                selectList.options[selectList.options.length] = option;
                if (item.Selected == true) {
                    $('#selChildren').selectedIndex = index;
                }
            });
            return true;
        },
        error: function (httpRequest, textStatus, errorThrown) {
            determineError("Error: There are no children to retrieve.");
        }

    });

}

function GetChildContent() {
    if (isNullOrEmptyString(getHiddenChildId())) {
        alert("Must first select a child.");
        return;
    }
    var parms = { ChildId: getHiddenChildId() };
    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/DigitalLifeBooks/API/Edit.ashx/GetChildContent",
        async: false,
        data: parms,
        dataType: "text",
        success: function (response) {
            $('#divChildContent').html(response);
        },
        error: function (httpRequest, textStatus, errorThrown) {
            determineError("Error: Failed to retrieve child.");
        }

    });

}

function GetEvents() {
    $("#selEvent option").remove();
    
    if (isNullOrEmptyString(getHiddenChildId())) {
        alert("Must first select a child.");
        return;
    }
    

    var parms = { ChildId: getHiddenChildId() };
    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/DigitalLifeBooks/API/Edit.ashx/GetEvents",
        async: false,
        data: parms,
        dataType: "json",
        success: function (response) {
            $.each(response, function (index, item) {
                var option = document.createElement("option");
                option.text = item.Text;
                option.value = item.Value;
                var selectList = $('select#selEvent');
                selectList.append(option);

                if (item.Selected == true) {
                    selectList.selectedIndex = index;
                }
            });
        },
        error: function (httpRequest, textStatus, errorThrown) {
            determineError("Error: Failed to retrieve child.");
        }
    });

}


function GetChildData() {
    var parms = { ChildId: getHiddenChildId(),
                 mid: $('input[id$="hidMid"]').val(),
                 tabId: $('input[id$="hidTabId"]').val(),
                 pageAction: 'Redirect' };
                 jQuery.ajax({
                     type: "POST",
                     url: "/DesktopModules/DigitalLifeBooks/API/Edit.ashx/GetChildData",
                     async: false,
                     data: parms,
                     dataType: "json",
                     success: function (response) {
                         $('#lblChildName').text(response[0].ChildName);
                         $('#lblBirthDate').text(response[0].DOB);
                         $('#lblCity').text(response[0].City);
                         $('#lblState').text(response[0].State);
                         $('#lnkEditChild').attr('href', response[0].Url);
                     },
                     error: function (httpRequest, textStatus, errorThrown) {
                         determineError("Error: " + errorThrown);
                     }

                 });

}

function determineError(response) {
    var errIndex = response.lastIndexOf("Error", 0);
    if (errIndex >= 0 && errIndex < 6) {
        alert(response);
        return false;
    }
}

function ViewContent(link){
   alert("Pretend We Got Content");
}


function getHiddenEventId() {
    return $('input[id$="hiddenSelectedEventId"]').val();
}

function setHiddenEventId() {
    var selectList = document.getElementById('selEvent');
    $('input[id$="hiddenSelectedEventId"]').val(selectList[selectList.selectedIndex].value);
}


function getHiddenChildId() {
    return $('input[id$="hidSelectedChildId"]').val();
}

function setHiddenChildIdFromSelectedList() {
    var selectList = document.getElementById('selChildren');
    $('input[id$="hidSelectedChildId"]').val(selectList[selectList.selectedIndex].value);
}

function isNullOrEmptyString(txt) {
    return (txt == null || txt.trim() == '')
}

function getAllChildElements() {
    setHiddenChildIdFromSelectedList();
    if (isNullOrEmptyString(getHiddenChildId())) { return; }
    GetChildData();
    GetChildContent();
    GetEvents();
}

