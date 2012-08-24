/// <reference path="/Resources/Shared/jquery/jquery-ui.js" />

$(function () {

    GetStates();
    GetParties();
    GetRelationships();
    prepopulateChildData();
    GetAssociations();

    $('#btnSave').click(function () {
        var sacwisno = document.getElementById('txtSacwisNo').value;
        var firstName = document.getElementById('txtFirstName').value;
        var middleInitial = document.getElementById('txtMiddleInitial').value;
        var lastName = document.getElementById('txtLastName').value;
        var birthDate = document.getElementById('txtBirthDate').value;
        var city = document.getElementById('txtCity').value;
        var state = document.getElementById('selState')[document.getElementById('selState').selectedIndex].value;
        var ReferingAgency = document.getElementById('txtReferingAgency').value;

        var jsonRequest = { ChildId: sacwisno,
            FirstName: firstName,
            MiddleInitial: middleInitial,
            LastName: lastName,
            BirthDate: birthDate,
            City: city,
            State: state,
            ReferingAgency: ReferingAgency
        };

        jQuery.ajax({
            type: "POST",
            url: "/DesktopModules/Child/API/Edit.ashx/SaveChild",
            async: false,
            data: jsonRequest,
            dataType: "text",
            success: function (response) {
                determineError(response);
            },
            error: function (httpRequest, textStatus, errorThrown) {
                alert(textStatus + " " + errorThrown);
                determineError("Error: Save failed.");
            }
        });
        return false;
    });
    $('#btnAddAssociation').click(function () {
        associatedPartyAction("Add", $('#selAssociatedParties').val(), $('#selRelationship').val())
    });
    $("#txtBirthDate").datepicker();

});

function associatedPartyAction(action, associatedParrtyId, relationship) {
    var sacwisno = document.getElementById('txtSacwisNo').value;

    var jsonRequest = { ChildId: sacwisno,
        SelectedPartyId: associatedParrtyId,
        Action: action,
        Relationship: relationship
    };
    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/Child/API/Edit.ashx/AssociatedPartyAction",
        async: false,
        data: jsonRequest,
        dataType: "text",
        success: function (response) {
            $('#lstAssociatedParties').html(response);

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


function GetParties() {
    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/Child/API/Edit.ashx/GetParties",
        async: false,
        data: {},
        dataType: "json",
        success: function (response) {
            $.each(response, function (index, item) {
                var option = document.createElement("option");
                option.text = item.Text;
                option.value = item.Value;
                var selectList = document.getElementById('selAssociatedParties');
                selectList.options[selectList.options.length] = option;
                if (item.Selected == true) {
                    $('#selAssociatedParties').selectedIndex = index;
                }
            });
            return true;
        },
        error: function (httpRequest, textStatus, errorThrown) {
            // do something

            return false;
        }

    });
}


function GetRelationships() {
    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/Child/API/Edit.ashx/GetRelationships",
        async: false,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (index, item) {
                var option = document.createElement("option");
                option.text = item.Text;
                option.value = item.Value;
                var selectList = document.getElementById('selRelationship');
                selectList.options[selectList.options.length] = option;
                if (item.Selected == true) {
                    $('#selRelationship').selectedIndex = index;
                }
            });
            return true;
        },
        error: function (httpRequest, textStatus, errorThrown) {
            // do something

            return false;
        }

    });
}


function GetAssociations() {
    parms = { ChildId: document.getElementById('txtSacwisNo').value };
    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/Child/API/Edit.ashx/GetAssociations",
        async: false,
        data: parms,
        dataType: "text",
        success: function (response) {
            $('#lstAssociatedParties').html(response);
            return true;
        },
        error: function (httpRequest, textStatus, errorThrown) {
            return false;
        }

    });
}

function prepopulateChildData() {
    if ($('input[id$="hidPassedInChild"]').val() == "" || $('input[id$="hidPassedInChild"]').val() == null) return;

    var parms = { ChildId: $('input[id$="hidPassedInChild"]').val(),
        mid: '',
        tabId: '',
        pageAction: 'Populate'
    };


    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/Child/API/Edit.ashx/GetChildData",
        async: false,
        data: parms,
        dataType: "json",
        success: function (response) {
            $('#txtSacwisNo').val($('input[id$="hidPassedInChild"]').val());
            $('#txtFirstName').val(response[0].FirstName);
            $('#txtLastName').val(response[0].LastName);
            $('#txtMiddleInitial').val(response[0].MiddleInitial);
            $('#txtBirthDate').val(response[0].DOB);
            $('#txtCity').val(response[0].City);
            $('#txtReferingAgency').val(response[0].ReferingAgency);

            $.each(document.getElementById('selState').options, function (index, item) {
                if (item.value == response[0].State) {
                    item.selected = true;
                }
            });
        },
        error: function (httpRequest, textStatus, errorThrown) {
            determineError("Error: " + errorThrown);
        }

    });

}

function GetStates() {
    jQuery.ajax({
        type: "POST",
        url: "/DesktopModules/Child/API/Edit.ashx/GetStates",
        async: false,
        data: {},
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $.each(response, function (index, item) {
                var option = document.createElement("option");
                option.text = item.Text;
                option.value = item.Value;
                var selectList = document.getElementById('selState');
                selectList.options[selectList.options.length] = option;
                if (item.Selected == true) {
                    $('#selState').selectedIndex = index;
                }
            });
            return true;
        },
        error: function (httpRequest, textStatus, errorThrown) {
            // do something
            alert(errorThrown);
            return false;
        }

    });
}