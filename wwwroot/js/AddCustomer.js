// form load
$(function () {
    //GetAllCustomers();
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