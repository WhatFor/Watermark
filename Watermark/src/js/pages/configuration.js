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