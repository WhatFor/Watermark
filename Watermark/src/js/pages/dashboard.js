$('#step1next').on('click', function () {
    $('#step1').hide();
    $('#step2').show();
});

var onTutorialComplete = function () {
    $('#step1').remove();
    $('#step2').remove();
}