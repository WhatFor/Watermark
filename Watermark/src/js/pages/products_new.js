// Logic for AJAX form submission.
let results = $('#results');
 
var onBegin = function () {
    results.html("<h3>Loading...</h3>");
};
 
var onComplete = function(){
    results.html("");
};
 
var onSuccess = function (context) {
    results.html("<p>Complete!</p>")
};
 
var onFailed = function (context) {
    results.html("<p>Failed...</p>")
    alert("Failed");
}; 

// Start
$(document).ready(function () {
    datePickerInit();
    specialPriceInit();
    clearLabelInit();
});

// Setup logic for datepickers
var datePickerInit = function () {
    $("#datepicker-from").datepicker();
    $("#datepicker-to").datepicker();
};

// Logic to collapse / expand the Special Price panel
var specialPriceInit = function () {
    $('#special-price-display-body').hide();

    $('#special-price-display').change(function () {
        $('#special-price-display-body').slideToggle("fast");
    });
};

// Logic to control the 'clear field label' -- TODO Move to tag helper
var clearLabelInit = function () {
    $('label[data-for="datepicker-from"]').on('click', function () {
        $('#datepicker-from').val('');
    });

    $('label[data-for="datepicker-to"]').on('click', function () {
        $('#datepicker-to').val('');
    });
};