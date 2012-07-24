/// <reference path="/Resources/Shared/jquery/jquery-ui.js" />

$(function () {

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
            url: "/DesktopModules/DigitalLifeBooks/API/Edit.ashx/SaveChild",
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
        url: "/DesktopModules/DigitalLifeBooks/API/Edit.ashx/AssociatedPartyAction",
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