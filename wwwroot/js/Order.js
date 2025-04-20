// form load
$(function () {
    // load dropdowns

    // company
    $.ajax({
        type: 'get',
        url: '/BackOps/GetCompaniesDDL',
        dataType: 'json',
        success: function (response) {
            $('#CompanyName').empty();
            $('#CompanyName').append('<option value="">-Choose One-</option>');
            $.each(response, function (index, item) {
                $('#CompanyName').append('<option value="' + item.text + '">' + item.value + '</option>');
            });

            // set selected value
            if ($('#Customer_CompanyCode').val() > 0)
                $('#CompanyName').val($('#Customer_CompanyCode').val());
            else
                $('#CompanyName').val('');
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
    // country
    $.ajax({
        type: 'get',
        url: '/BackOps/GetCountriesDDL',
        dataType: 'json',
        success: function (response) {
            // add default -Choose One- option
            $('#BillToAddressCountryCode').empty();
            $('#BillToAddressCountryCode').append('<option value="">-Choose One-</option>');
            $('#ShipToAddressCountryCode').empty();
            $('#ShipToAddressCountryCode').append('<option value="">-Choose One-</option>');
            $('#DocsSendToAddressCountryCode').empty();
            $('#DocsSendToAddressCountryCode').append('<option value="">-Choose One-</option>');
            $('#BrokerAddressCountryCode').empty();
            $('#BrokerAddressCountryCode').append('<option value="">-Choose One-</option>');
            $('#NotifyPartyAddressCountryCode').empty();
            $('#NotifyPartyAddressCountryCode').append('<option value="">-Choose One-</option>');
            $('#BankAddressCountryCode').empty();
            $('#BankAddressCountryCode').append('<option value="">-Choose One-</option>');
            // append full country code list
            $.each(response, function (index, item) {
                //$('#BillToAddressCountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
                $('#BillToAddressCountryCode').append($('<option>', { value: item.text, text: item.value }));
                $('#ShipToAddressCountryCode').append($('<option>', { value: item.text, text: item.value }));
                $('#DocsSendToAddressCountryCode').append($('<option>', { value: item.text, text: item.value }));
                $('#BrokerAddressCountryCode').append($('<option>', { value: item.text, text: item.value }));
                $('#NotifyPartyAddressCountryCode').append($('<option>', { value: item.text, text: item.value }));
                $('#BankAddressCountryCode').append($('<option>', { value: item.text, text: item.value }));
            });
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });

    // few checks
    if ($('#Customer_CompanyCode').val() > 0) {
        // edit mode: set selected value
        $('#BillToAddressCountryCode').val($('#Customer_BillToAddress_CountryCode').val());
        $('#ShipToAddressCountryCode').val($('#Customer_ShipToAddress_CountryCode').val());
    }
});

// bill to no change event

// ship to no change event

// add product button click
$("#btnAddProduct").on("click", function (e) {
    $('#addProductModal').modal('show');
});

// Handle product form submission
$('#productForm').on('submit', function (e) {
    e.preventDefault();

    // Get form data
    const formData = Object.fromEntries(new FormData(e.target).entries());

    // Add to grid
    const newItem = {
        id: Date.now(), // Temporary ID
        destinationPort: formData.destinationPort,
        product: formData.product,
        quantity: parseInt(formData.quantity),
        bagToteSize: parseFloat(formData.bagToteSize),
        noOfBagsTotes: parseInt(formData.noOfBagsTotes),
        fCA: parseFloat(formData.fCA),
        fright: parseFloat(formData.fright),
        insurance: parseFloat(formData.insurance),
        commission: parseFloat(formData.commission),
        floorPalletCharge: parseFloat(formData.floorPalletCharge || 0)
    };

    gridApi.applyTransaction({ add: [newItem] });

    // Clear form and hide modal
    e.target.reset();
    $('#addProductModal').modal('hide');
});

// save functionality
$("#btnSaveOrder").on("click", function (e) {
    e.preventDefault(); // Prevent the default form submission

    const orderId = $("#Order_Id").val();
    const url = orderId === "0" ? '/Orders/SaveOrder' : '/Orders/UpdateOrder';

    displayStatus("Saving order information", "info");
    let formData = $("form").serialize(); // Serialize the form data

    // send the data via ajax
    $.ajax({
        type: 'POST',
        url: url,
        data: formData,
        success: function (response) {
            if (response.success) {
                displayStatus("Customer saved successfully", "success");
                window.location.href = "/Customers/Index"; // Redirect to the customer list page
            } else {
                displayStatus("Failed to save customer: " + response.message, "error");
            }
        },
        error: function (xhr) {
            displayStatus("Unable to save the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
});

// edit customer 
function EditCustomer(id) {
    displayStatus("Open separate page for customer information in edit mode", "info");
    window.location.href = "/Customers/EditCustomer/" + id;
}

// calculate no of bags
//$("#bagToteSize").on("change", function (e) {
//    $("#quantity").val();
//});

$('input[name="quantity"], input[name="bagToteSize"]').on('input', function () {
    const quantity = parseFloat($('input[name="quantity"]').val()) || 0;
    const bagToteSize = parseFloat($('input[name="bagToteSize"]').val()) || 0;

    if (bagToteSize > 0) {
        const calculatedValue = Math.ceil(quantity / bagToteSize);
        $('input[name="noOfBagsTotes"]').val(calculatedValue);
    } else {
        $('input[name="noOfBagsTotes"]').val('');
    }
});
//$("#bagToteSize").on("change", function (e) { });
