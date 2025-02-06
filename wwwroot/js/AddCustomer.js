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
            $.each(response, function (index, item) {
                $('#BillToAddressCountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
                $('#ShipToAddressCountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
                $('#DocsSendToAddressCountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
                $('#BrokerAddressCountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
                $('#NotifyPartyAddressCountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
                $('#BankAddressCountryCode').append('<option value="' + item.text + '">' + item.value + '</option>');
            });
        },
        error: function (xhr) {
            displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
        }
    });
    // consignee type
    //$.ajax({
    //    type: 'get',
    //    url: '/BackOps/GetSelectedMasterDDL',
    //    data: { masterName: "CONSIGNEETYPE" },
    //    dataType: 'json',
    //    success: function (response) {
    //        $('#UltimateConsgineeTypeId').empty();
    //        $('#UltimateConsgineeTypeId').append('<option value="">-Choose One-</option>');
    //        $.each(response, function (index, item) {
    //            $('#UltimateConsgineeTypeId').append('<option value="' + item.value + '">' + item.text + '</option>');
    //        });
    //    },
    //    error: function (xhr) {
    //        displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
    //    }
    //});
    // payment terms
    //$.ajax({
    //    type: 'get',
    //    url: '/BackOps/GetSelectedMasterDDL',
    //    data: { masterName: "PAYMENTTERM" },
    //    dataType: 'json',
    //    success: function (response) {
    //        $('#PaymentTermId').empty();
    //        $('#PaymentTermId').append('<option value="">-Choose One-</option>');
    //        $.each(response, function (index, item) {
    //            $('#PaymentTermId').append('<option value="' + item.value + '">' + item.text + '</option>');
    //        });
    //    },
    //    error: function (xhr) {
    //        displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
    //    }
    //});
    // incoterms
    //$.ajax({
    //    type: 'get',
    //    url: '/BackOps/GetSelectedMasterDDL',
    //    data: { masterName: "INCOTERM" },
    //    dataType: 'json',
    //    success: function (response) {
    //        $('#Incoterm2020Id').empty();
    //        $('#Incoterm2020Id').append('<option value="">-Choose One-</option>');
    //        $.each(response, function (index, item) {
    //            $('#Incoterm2020Id').append('<option value="' + item.value + '">' + item.text + '</option>');
    //        });
    //    },
    //    error: function (xhr) {
    //        displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
    //    }
    //});
    // paperworks
    //$.ajax({
    //    type: 'get',
    //    url: '/BackOps/GetSelectedMasterDDL',
    //    data: { masterName: "PAPERWORK" },
    //    dataType: 'json',
    //    success: function (response) {
    //        $('#Incoterm2020Id').empty();
    //        $('#Incoterm2020Id').append('<option value="">-Choose One-</option>');
    //        $.each(response, function (index, item) {
    //            $('#Incoterm2020Id').append('<option value="' + item.value + '">' + item.text + '</option>');
    //        });
    //    },
    //    error: function (xhr) {
    //        displayStatus("Unable to read the data. Status: " + xhr.status + " Message: " + xhr.statusText + " " + xhr.responseText, "error");
    //    }
    //});
});

// company change event
$("#Customer_Company_Name").on("change", function () {
    $("#Customer_CompanyCode").val($(this).find("option:selected").val());
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