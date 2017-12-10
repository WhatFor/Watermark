$(document).ready(function () {
    $.ajax({

        type: 'GET',

        url: 'Notifications/GetNotifications',
        dataType: 'json',
        data: { count: 5 },
        success: function (data) {
            var items = '';
            $.each(data, function (i, item) {

                var rows =
                    "<div class=\"dropdown-item\">" +
                    item.title +
                    " - " +
                    item.body +
                    "</div >";

                $('#dropdown-notifications').append(rows);
            });

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
    $('#notification-count').text("0");
    $('#dropdown-notifications').children('div').remove();
};