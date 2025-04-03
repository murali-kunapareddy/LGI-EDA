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
            if ($('#Customer_CompanyCode').val()>0)
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

// company change event
$("#CompanyName").on("change", function () {
    $("#Customer_CompanyCode").val($(this).find("option:selected").val());
});

// save functionality
$("#btnSaveCustomer").on("click", function (e) {
    e.preventDefault(); // Prevent the default form submission

    const customerId = $("#Customer_Id").val();
    const url = customerId === "0" ? '/Customers/SaveCustomer' : '/Customers/UpdateCustomer';

    displayStatus("Saving customer information", "info");
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
