// form load
$(function () {
    // load dropdowns
    $.ajax({
        type: 'get',
        url: '/BackOps/GetCompaniesDDL',
        dataType: 'json',
        success: function (response) {
            $('#Company').empty();
            $('#Company').append('<option value="">-Choose One-</option>');
            $.each(response, function (index, item) {
                $('#Company').append('<option value="' + item.text + '">' + item.value + '</option>');
            });
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
});

// save functionality
$("#btnSaveCustomer").on("click", function () {
    displayStatus("Saving customer information", "info");
    // TODO call controller to save
});


// edit master item
function EditCustomer(id) {
    displayStatus("Open separate page for customer information in edit mode", "info");
    window.location.href = "/Customers/EditCustomer/" + id;
}

// cancel
function CancelOperation() {
    // clear form
    window.location.href = "/Customers";
}