// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    let timeout;

    function updatePriceToSlider(minValue) {
        $("#priceToSlider").slider("option", "min", minValue);
    }

    // Initialize price from slider
    $("#priceFromSlider").slider({
        range: "min",
        value: parseInt($("#priceFrom").val()) || 0,
        min: 0,
        max: 50000,
        step: 100,
        slide: function (event, ui) {
            $("#priceFrom").val(ui.value);
            $("#priceFromLabel").text('От: ' + ui.value + 'лв.');
            $("#priceToSlider").slider("option", "min", ui.value);
            clearTimeout(timeout);
            timeout = setTimeout(function () {
                updatePriceToSlider(ui.value);
            }, 1000);
          
        }
      
    });

    // Initialize price to slider
    $("#priceToSlider").slider({
        range: "min",
        value: 10000000,
        min: parseInt($("#priceFrom").val()) || 0,
        max: 1000000,
        step: 100,
        slide: function (event, ui) {
            $("#priceTo").val(ui.value);
            $("#priceToLabel").text('До: ' + ui.value + 'лв.');
        }
    });
    
});
