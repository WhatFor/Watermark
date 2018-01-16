// Logic to control the display/ hide of all form elements that use the mouseover-popup to display descriptions of the element

$(document).ready(function () {

    $('.hover-desc-label').hover(

        function () {

            let id = $(this).attr("Id");

            $(".hover-desc-popup[data-for=" + id + "]").show();

        }, function () {

            let id = $(this).attr("Id");

            $(".hover-desc-popup[data-for=" + id + "]").hide();
        }
    );
});