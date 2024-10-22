// form load
$(function () {
    GetAllCompanies();
});

// get all companies
function GetAllCompanies() {
    $.ajax({
        type: 'get',
        url: '/Settings/GetAllCompanies',
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
$("#btnAddCompany").on("click", function () {
    $("#Save").css('display', 'block');
    $("#Update").css('display', 'none');
    $("#CompanyModal").modal("show");
    $("#modalTitle").text("Add Company");
    $.ajax({
        type: 'get',
        url: '/BackOps/GetCountriesDDL',
        dataType: 'json',
        success: function (response) {
            $('#CountryCode').empty();
            $('#CountryCode').append('<option value="">-Choose One-</option>');
            $.each(response, function (index, item) {
                $('#CountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
            });
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
});

// add company
function AddCompany() {
    // do validation
    let result = Validate();
    if (!result) {
        return false;
    }
    // get form data
    let formData = new Object();
    formData.code = $("#Code").val();
    formData.name = $("#Name").val();
    formData.addressLine1 = $("#AddressLine1").val();
    formData.addressLine2 = $("#AddressLine2").val();
    formData.city = $("#City").val();
    formData.state = $("#State").val();
    formData.countryCode = $("#CountryCode").val();
    formData.zip = $("#Zip").val();
    formData.phone = $("#Phone").val();
    formData.fax = $("#Fax").val();
    formData.email = $("#Email").val();
    formData.logo = $("#Logo").val();
    formData.createdBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";

    $.ajax({
        type: 'post',
        url: '/Settings/AddCompany',
        data: formData,
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                displayStatus("Unable to save " + formData.name, "error");
            } else {
                HideModal();
                GetAllCompanies();
                displayStatus(response, "success");
            }
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// edit company
function EditCompany(id) {
    // get country codes
    $.ajax({
        type: 'get',
        url: '/BackOps/GetCountriesDDL',
        dataType: 'json',
        success: function (response) {
            $('#CountryCode').empty();
            $('#CountryCode').append('<option value="">-Choose One-</option>');
            $.each(response, function (index, item) {
                $('#CountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
            });
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
    // get company
    $.ajax({
        url: '/Settings/EditCompany?id=' + id,
        type: 'get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            if (response == null || response == undefined) {
                displayStatus("Unable to read the data", "error");
            } else if (response.length == 0) {
                displayStatus("Data not available for Id: " + id, "error");
            } else {
                $("#CompanyModal ").modal("show");
                $("#modalTitle").text('Update Company');
                $("#Save").css('display', 'none');
                $("#Update").css('display', 'block');
                //
                $("#Code").val(response.code);
                $("#Name").val(response.name);
                $("#AddressLine1").val(response.addressLine1);
                $("#AddressLine2").val(response.addressLine2);
                $("#City").val(response.city);
                $("#State").val(response.state);
                $("#CountryCode").find('option[value="' + response.countryCode + '"]').attr('selected', 'selected');
                $("#Zip").val(response.zip);
                $("#Phone").val(response.phone);
                $("#Fax").val(response.fax);
                $("#Email").val(response.email);
                $("#Logo").val(response.logo);
                $("#CreatedBy").val(response.createdBy);
            }
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// update company
function UpdateCompany() {
    // without changing id & name update the record
    // validate
    let result = Validate();
    if (!result) {
        return false;
    }
    // get form data
    let formData = new Object();
    formData.code = $("#Code").val();
    formData.name = $("#Name").val();
    formData.addressLine1 = $("#AddressLine1").val();
    formData.addressLine2 = $("#AddressLine2").val();
    formData.city = $("#City").val();
    formData.state = $("#State").val();
    formData.countryCode = $("#CountryCode").val();
    formData.zip = $("#Zip").val();
    formData.phone = $("#Phone").val();
    formData.fax = $("#Fax").val();
    formData.email = $("#Email").val();
    formData.logo = $("#Logo").val();
    formData.createdBy = "murali.kunapareddy@bhjgroup.onmicrosoft.com";
    // set url
    let URL = '/Settings/UpdateCompany';
    //
    $.ajax({
        type: 'post',
        url: URL,
        data: formData,
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                displayStatus("Unable to update " + formData.code + ", " + formData.name, "error");
            } else {
                HideModal();
                GetAllCompanies();
                displayStatus(response, "success");
            }
        },
        error: function (xhr) {
            alert("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText);
        }
    });
}

// suspend consignee type
function SuspendCompany(id) {
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
                    url: '/Settings/SuspendCompany?id=' + id,
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response == null || response == undefined) {
                            displayStatus("Unable to read the data", "error");
                        } else if (response.length == 0) {
                            displayStatus("Data not available for Id: " + id, "error");
                        } else {
                            GetAllCompanies();
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
    $("#Code").val('');
    $("#Code").css('border-color', 'lightgrey');
    $("#Name").val('');
    $("#Name").css('border-color', 'lightgrey');
    $("#AddressLine1").val('');
    $("#AddressLine1").css('border-color', 'lightgrey');
    $("#City").val('');
    $("#City").css('border-color', 'lightgrey');
    $("#State").val('');
    $("#State").css('border-color', 'lightgrey');
    $("#CountryCode").val('');
    $("#CountryCode").css('border-color', 'lightgrey');
    $("#Phone").val('');
    $("#Phone").css('border-color', 'lightgrey');
    $("#Save").css('display', 'none');
    $("#Update").css('display', 'block');
}

// hide modal
function HideModal() {
    ClearModal();
    $("#CompanyModal").modal("hide");
}

// validation
function Validate() {
    let isValid = true;

    if ($("#Code").val().trim() == "") {
        $("#Code").css('border-color', 'red');
        isValid = false;
    } else {
        $("#Code").css('border-color', 'lightgrey');
    }

    if ($("#Name").val().trim() == "") {
        $("#Name").css('border-color', 'red');
        isValid = false;
    } else {
        $("#Name").css('border-color', 'lightgrey');
    }

    if ($("#AddressLine1").val().trim() == "") {
        $("#AddressLine1").css('border-color', 'red');
        isValid = false;
    } else {
        $("#AddressLine1").css('border-color', 'lightgrey');
    }

    if ($("#City").val().trim() == "") {
        $("#City").css('border-color', 'red');
        isValid = false;
    } else {
        $("#City").css('border-color', 'lightgrey');
    }

    if ($("#State").val().trim() == "") {
        $("#State").css('border-color', 'red');
        isValid = false;
    } else {
        $("#State").css('border-color', 'lightgrey');
    }

    if ($("#CountryCode").val().trim() == "") {
        $("#CountryCode").css('border-color', 'red');
        isValid = false;
    } else {
        $("#CountryCode").css('border-color', 'lightgrey');
    }

    if ($("#Phone").val().trim() == "") {
        $("#Phone").css('border-color', 'red');
        isValid = false;
    } else {
        $("#Phone").css('border-color', 'lightgrey');
    }

    return isValid;
}

$("#Code").on("change", function () {
    Validate();
});
$("#Name").on("change", function () {
    Validate();
});
$("#AddressLine1").on("change", function () {
    Validate();
});
$("#City").on("change", function () {
    Validate();
});
$("#State").on("change", function () {
    Validate();
});
$("#CountryCode").on("change", function () {
    Validate();
});
$("#Phone").on("change", function () {
    Validate();
});




// Custom Button Component
class MasterButtonComponent {
    eGui;
    eSpan;
    eventListener;

    init() {
        this.eGui = document.createElement('div');
        let eSpan = document.createElement('span');
        eSpan.className = "lni lni-pencil px-2";
        this.eventListener = () => alert('Edit Launched');
        eSpan.addEventListener('click', this.eventListener);
        this.eGui.appendChild(eSpan);
        this.eGui.text = "&nbsp;";
        eSpan = document.createElement('span');
        eSpan.className = "lni lni-lock px-2";
        this.eventListener = () => alert('Lock Launched');
        eSpan.addEventListener('click', this.eventListener);
        this.eGui.appendChild(eSpan);
    }

    getGui() {
        return this.eGui;
    }

    refresh() {
        return true;
    }

    destroy() {
        if (this.eButton) {
            this.eButton.removeEventListener('click', this.eventListener);
        }
    }
}