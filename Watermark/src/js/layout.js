$(document).ready(function () {
    $.ajax({

        type: 'GET',

        url: '/Admin/Notifications/GetNotifications',
        dataType: 'json',
        data: { count: 5 },
        success: function (data) {
            var items = '';

            if (data.length > 0) {
                $.each(data, function (i, item) {

                    var rows =
                        "<div class=\"dropdown-item\">" +
                        item.title +
                        " - " +
                        item.body +
                        "</div >";

                    $('#notification-count').addClass("badge-warning");
                    $('#notification-count').show();
                    $('#dropdown-notifications').append(rows);
                });
            }

            $('#notification-count').text(data.length);
        },
        error: function (ex) {
            var r = jQuery.parseJSON(response.responseText);
            alert("Message: " + r.Message);
            alert("StackTrace: " + r.StackTrace);
            alert("ExceptionType: " + r.ExceptionType);
        }
    });

    return false;
});

var onMarkAllRead = function () {
    $('#notification-count').hide();
    $('.dropdown-notification-container').removeClass("show");
    $('#dropdown-notifications').children('div').remove();
};