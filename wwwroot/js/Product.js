// form load
$(function () {
    GetAllProducts();
});

// get all consignee types
function GetAllProducts() {
    $.ajax({
        type: 'get',
        url: '/Masters/GetAllProducts',
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
$("#btnAddProduct").on("click", function () {
    $("#Save").css('display', 'block');
    $("#Update").css('display', 'none');
    $("#ProductModal").modal("show");
    $("#modalTitle").text("Add Product");
    //
    $.ajax({
        type: 'get',
        url: '/BackOps/GetCompaniesDDL',
        dataType: 'json',
        success: function (response) {
            $('#CompanyCode').empty();
            $('#CompanyCode').append('<option value="">-Choose One-</option>');
            $.each(response, function (index, item) {
                $('#CompanyCode').append('<option value="' + item.text + '">' + item.value + '</option>');
            });
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
});

// add consignee type
function AddProduct() {
    // do validation
    let result = Validate();
    if (!result) {
        return false;
    }
    // get form data
    let formData = new Object();
    formData.id = $("#Id").val();
    formData.code = $("#Code").val();
    formData.name = $("#Name").val();
    formData.companyCode = parseInt($("#CompanyCode").val());
    formData.createdBy = "murali.kunapareddy@vendor.lgiglobal.com";

    $.ajax({
        type: 'post',
        url: '/Masters/AddProduct',
        data: formData,
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                displayStatus("Unable to save " + formData.name, "error");
            } else {
                HideModal();
                GetAllProducts();
                displayStatus(response, "success");
            }
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// edit master item
function EditProduct(id) {
    // load ddl companies to company(code)
    $.ajax({
        type: 'get',
        url: '/BackOps/GetCompaniesDDL',
        dataType: 'json',
        success: function (response) {
            $('#CompanyCode').empty();
            $('#CompanyCode').append('<option value="">-Choose One-</option>');
            $.each(response, function (index, item) {
                $('#CompanyCode').append('<option value="' + item.text + '">' + item.value + '</option>');
            });
        },
        error: function (xhr) {
            alert("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText);
        }
    });
    //
    $.ajax({
        url: '/Masters/EditProduct?id=' + id,
        type: 'get',
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (response) {
            if (response == null || response == undefined) {
                displayStatus("Unable to read the data", "info");
            } else if (response.length == 0) {
                displayStatus("Data not available for Id: " + id, "info");
            } else {
                $("#ProductModal").modal("show");
                $("#modalTitle").text('Update Product');
                $("#Save").css('display', 'none');
                $("#Update").css('display', 'block');
                //
                $("#Id").val(response.id);
                $("#Code").val(response.code);
                $("#Name").val(response.name);
                $("#CompanyCode").val(response.companyCode);
                $("#CreatedBy").val(response.createdBy);
            }
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// update Product type
function UpdateProduct() {
    // without changing id & name update the record
    // get form data
    let result = Validate();
    if (!result) {
        return false;
    }
    // get form data
    let formData = new Object();
    formData.id = $("#Id").val();
    formData.code = $("#Code").val();
    formData.name = $("#Name").val();
    formData.companyCode = $("#CompanyCode").val();
    formData.createdBy = $("#CreatedBy").val();
    formData.modifiedBy = "murali.kunapareddy@vendor.lgiglobal.com";
    // set url
    let URL = '/Masters/UpdateProduct';
    //
    $.ajax({
        type: 'post',
        url: URL,
        data: formData,
        success: function (response) {
            if (response == null || response == undefined || response.length == 0) {
                displayStatus("Unable to read the data", "error");
            } else {
                HideModal();
                GetAllProducts();
                displayStatus(response, "success");
            }
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// suspend consignee type
function SuspendProduct(id) {
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
                    url: '/Masters/SuspendProduct?id=' + id,
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response == null || response == undefined) {
                            displayStatus("Unable to read the data", "error");
                        } else if (response.length == 0) {
                            displayStatus("Data not available for Id: " + id, "error");
                        } else {
                            GetAllProducts();
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
    $("#CompanyCode").val('');
    $("#CompanyCode").css('border-color', 'lightgrey');
}

// hide modal
function HideModal() {
    ClearModal();
    $("#ProductModal").modal("hide");
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

    if ($("#CompanyCode").val().trim() == "") {
        $("#CompanyCode").css('border-color', 'red');
        isValid = false;
    } else {
        $("#CompanyCode").css('border-color', 'lightgrey');
    }

    return isValid;
}

$("#Code").on("change", function () {
    Validate();
});
$("#Name").on("change", function () {
    Validate();
});
$("#CompanyCode").on("change", function () {
    Validate();
});



