﻿// form load
$(function () {
    GetAllPaymentTerms();
});

// get all consignee types
function GetAllPaymentTerms() {
    $.ajax({
        type: 'get',
        url: '/Masters/GetAllPaymentTerms',
        dataType: 'json',
        success: function (response) {
            gridApi.setGridOption("rowData", response);
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// show popup
$("#btnAddPaymentTerm").on("click", function () {
    $("#Save").css('display', 'block');
    $("#Update").css('display', 'none');
    $("#PaymentTermModal").modal("show");
    $("#modalTitle").text("Add PaymentTerm");
});

// add consignee type
function AddPaymentTerm() {
    // do validation
    let result = Validate();
    if (!result) {
        return false;
    }
    // get form data
    let formData = new Object();
    formData.id = $("#Id").val();
    formData.name = "PAYMENTTERM";
    formData.key = $("#Key").val();
    formData.value = $("#Value").val();
    formData.sequence = $("#Sequence").val();
    formData.notes = $("#Notes").val();
    formData.createdBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";

    $.ajax({
        type: 'post',
        url: '/Masters/AddPaymentTerm',
        data: formData,
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert("Unable to save " + formData.name);
            } else {
                HideModal();
                GetAllPaymentTerms();
                displayStatus(response, "success");
            }
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// edit master item
function EditPaymentTerm(id) {
    //
    $.ajax({
        url: '/Masters/EditPaymentTerm?id=' + id,
        type: 'get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            if (response == null || response == undefined) {
                displayStatus("Unable to read the data", "info");
            } else if (response.length == 0) {
                displayStatus("Data not available for Id: " + id, "info");
            } else {
                $("#PaymentTermModal").modal("show");
                $("#modalTitle").text('Update Product');
                $("#Save").css('display', 'none');
                $("#Update").css('display', 'block');
                //
                $("#Id").val(response.id);
                $("#Name").val(response.name);
                $("#Key").val(response.key);
                $("#Value").val(response.value);
                $("#Sequence").val(response.sequence);
                $("#Notes").val(response.notes);
                $("#CreatedBy").val(response.createdBy);
            }
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// update PaymentTerm type
function UpdatePaymentTerm() {
    // without changing id & name update the record
    // get form data
    let result = Validate();
    if (!result) {
        return false;
    }
    // get form data
    let formData = new Object();
    formData.id = $("#Id").val();
    formData.name = $("#Name").val();
    formData.key = $("#Key").val();
    formData.value = $("#Value").val();
    formData.sequence = $("#Sequence").val();
    formData.notes = $("#Notes").val();
    formData.createdBy = $("#CreatedBy").val();
    formData.modifiedBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";
    // set url
    let URL = '/Masters/UpdatePaymentTerm';
    //
    $.ajax({
        type: 'post',
        url: URL,
        data: formData,
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                alert("Unable to update " + formData.key);
            } else {
                HideModal();
                GetAllPaymentTerms();
                displayStatus(response, "success");
            }
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// suspend PaymentTerm type
function SuspendPaymentTerm(id) {
    // without changing id & name suspend the record
    //
    $("<div title='Action Confirmation'>Are you sure to do this?</div>").dialog({
        open: function () {
            $(this).closest(".ui-dialog")
                .find(".ui-dialog-titlebar-close")
                .removeClass("ui-dialog-titlebar-close")
                .html("<span class='ui-button-icon-primary ui-icon ui-icon-closethick'></span>");
        },
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,
        buttons: {
            "Yes, Do this!": function () {
                $.ajax({
                    type: 'get',
                    url: '/Masters/SuspendPaymentTerm?id=' + id,
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response == null || response == undefined) {
                            displayStatus("Unable to read the data", "error");
                        } else if (response.length == 0) {
                            displayStatus("Data not available for Id: " + id, "error");
                        } else {
                            GetAllPaymentTerms();
                            //$("<div title='Success'>" + response + "</div>").dialog();
                            displayStatus(response, "success");
                        }
                    },
                    error: function (xhr) {
                        displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
                    }
                });
                $(this).dialog("close");
            },
            Cancel: function () {
                $(this).dialog("close");
            }
        }
    });
}

// clear modal
function ClearModal() {
    $("#Key").val('');
    $("#Key").css('border-color', 'lightgrey');
    $("#Value").val('');
    $("#Value").css('border-color', 'lightgrey');
    $("#Sequence").val('');
    $("#Sequence").css('border-color', 'lightgrey');
    $("#Notes").val('');
    $("#Notes").css('border-color', 'lightgrey');
}

// hide modal
function HideModal() {
    ClearModal();
    $("#PaymentTermModal").modal("hide");
}

// validation
function Validate() {
    let isValid = true;

    if ($("#Key").val().trim() == "") {
        $("#Key").css('border-color', 'red');
        isValid = false;
    } else {
        $("#Key").css('border-color', 'lightgrey');
    }

    if ($("#Value").val().trim() == "") {
        $("#Value").css('border-color', 'red');
        isValid = false;
    } else {
        $("#Value").css('border-color', 'lightgrey');
    }

    if ($("#Sequence").val().trim() == "") {
        $("#Sequence").css('border-color', 'red');
        isValid = false;
    } else {
        $("#Sequence").css('border-color', 'lightgrey');
    }

    if ($("#Notes").val().trim() == "") {
        $("#Notes").css('border-color', 'red');
        isValid = false;
    } else {
        $("#Notes").css('border-color', 'lightgrey');
    }

    return isValid;
}

$("#Key").on("change", function () {
    Validate();
});
$("#Value").on("change", function () {
    Validate();
});
$("#Sequence").on("change", function () {
    Validate();
});
$("#Notes").on("change", function () {
    Validate();
});

