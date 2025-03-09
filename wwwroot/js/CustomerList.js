// form load
$(function () {
    GetAllCustomers();
});

// get all customers
function GetAllCustomers() {
    $.ajax({
        type: 'get',
        url: '/Customers/GetAllCustomers',
        dataType: 'json',
        success: function (response) {
            gridApi.setGridOption("rowData", response);
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
}

// redirect to customer add page
//$("#btnAddCustomer").on("click", function () {
//    //displayStatus("New page to be opened for new customer entry", "info");
//    window.location.href = "/Customers/AddCustomer";
//});


// edit master item
function EditCustomer(id) {
    //displayStatus("Open separate page for customer information in edit mode", "info");
    window.location.href = "/Customers/EditCustomer/"+id;
}

// suspend customer type
function SuspendCustomer(id) {
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
                    url: '/Customers/SuspendCustomer?id=' + id,
                    contentType: 'application/json;charset=utf-8',
                    dataType: 'json',
                    success: function (response) {
                        if (response == null || response == undefined) {
                            alert("Unable to read the data");
                        } else if (response.length == 0) {
                            alert("Data not available for Id: " + id);
                        } else {
                            GetAllCustomers();
                            $("<div title='Success'>" + response + "</div>").dialog();
                        }
                    },
                    error: function (xhr) {
                        alert("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText);
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