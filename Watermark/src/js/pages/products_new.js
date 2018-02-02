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

// Drag and drop file uploader
$(document).ready(function () {
    initDragAndDrop();
});

var initDragAndDrop = function () {

    // Prevent default window drag + drop
    window.addEventListener("dragover", function (e) {
        e = e || event;
        e.preventDefault();
    }, false);
    window.addEventListener("drop", function (e) {
        e = e || event;
        e.preventDefault();
    }, false);

    var droppedFiles = false;
    var form = $('#drag-drop-files');
    
    form
        .on('drag dragstart dragend dragover dragenter dragleave drop', function (e) {
            e.preventDefault();
            e.stopPropagation();
        })
        .on('dragover dragenter', function () {
            form.addClass('is-dragover');
        })
        .on('dragleave dragend drop', function () {
            form.removeClass('is-dragover');
        })
        .on('drop', function (e) {
            droppedFiles = e.originalEvent.dataTransfer.files;
            insertNewImage();
        });

    var insertNewImage = function () {

        if (droppedFiles) {

            // Get image index
            var indexes = [];
            $('.image-upload-preview').each(function () {
                var $this = $(this);
                indexes.push($this.data("image-index"));
            });
            var beginningIndex = 0;
            if (indexes.length > 0)
            {
                beginningIndex = Math.max(...indexes) + 1;
            }


            $.each(droppedFiles, function (i, file) {

                i = i + beginningIndex;

                // Create form for image
                $('#product-media-list').append(`
                    <div style="display:none;" data-image-form-index=`+ i +` class="media-row">

                        <input hidden class="input-group" type="number" name="Product.ProductMedia[`+ i +`].Order"/>
                        <input hidden class="input-group" type="checkbox" name="Product.ProductMedia[`+ i +`].PrimaryMedia"/>
                        <input hidden class="input-group" type="number" name="Product.ProductMedia[`+ i +`].MediaType"/>
                        <input hidden class="input-group" type="file" name="Product.ProductMedia[`+ i +`].MediaContent"/>

                        <div class="input-group col-md-6">
                            <label class="input-group-addon" asp-for="Product.ProductMedia[`+ i + `].Hide">Hide?</label>
                            <div class="switch-container">
                                <label class="switch switch-default switch-pill switch-primary switch-margin-top">
                                    <input asp-for="Product.ProductMedia[`+ i +`].Hide" type="checkbox" class="switch-input hide-toggle-button" checked="">
                                    <span class="switch-label"></span>
                                    <span class="switch-handle"></span>
                                </label>
                            </div>
                        </div>

                        <div class="input-group col-md-12">
                            <label class="input-group-addon">Description</label>
                            <input class="form-control" type="text" name="Product.ProductMedia[`+ i +`].MediaDescription"/>
                        </div>


                    </div>`
                );


                $('p#no-media-alert').remove();


                var reader = new FileReader();
                reader.addEventListener("load", function () {

                    // Create image object
                    $('#drag-drop-files').before(`
                        <div data-image-index=`+ i +` class="image-upload-preview">
                            <img class="preview-image" src=`+ reader.result +`></img>
                        </div>`
                    );

                    // Assign Order to images
                    assignImageIndex();

                    // Assign content to input
                    //$('input[name="Product.ProductMedia[' + i + '].MediaContent"').val(reader.result);   // TODO FIX

                    // Register on-click listener
                    $('.image-upload-preview').on('click', function () {

                        $('.image-upload-preview').removeClass('active');
                        $(this).addClass('active');

                        var imageIndex = $(this).data("image-index");

                        $(".media-row").css("display", "none");
                        $(".media-row[data-image-form-index=" + imageIndex + "]").css("display", "block");

                    });

                    // Register toggle hide listener
                    $('.hide-toggle-button').on('click', function () {

                        var index = $(this).parent('div').data("image-form-index");

                        if ($(this).is(":checked"))
                        {
                            $(".image-upload-preview[data-image-index=" + index + "]").children(".preview-image").addClass("hidden");
                        }
                        else
                        {
                            $(".image-upload-preview[data-image-index=" + index + "]").children(".preview-image").removeClass('hidden');
                        }
                    });

                    // Register 'sortable'
                    var container = document.getElementById("draggable-images-container");
                    Sortable.create(container, {
                        animation: 150,
                        draggable: ".image-upload-preview",
                        onEnd: function (evt) {
                            assignImageIndex();
                        }
                    });

                }, false);

                reader.readAsDataURL(file);
            });
        }
    }

    var assignImageIndex = function () {

        $('.image-index-badge').remove();

        var images = $('.image-upload-preview');
        $.each(images, function (i, image) {

            i = i + 1;

            if (i == 1)
            {
                image.insertAdjacentHTML("beforeend", "<span class=\"badge badge-success image-index-badge\">" + i + "</span>");
            }
            else
            {
                image.insertAdjacentHTML("beforeend", "<span class=\"badge badge-secondary image-index-badge\">" + i + "</span>");
            }
        });

    };
};