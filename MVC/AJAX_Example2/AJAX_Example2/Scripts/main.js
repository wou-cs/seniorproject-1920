
$('#request').click(function () {
    var count = $('#count').val();
    var source = '/Home/Gimme?id=' + count;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: source,
        success: displayNumbers,
        error: errorOnAjax
    });
    var city = $('#city').val();
    console.log(city);
    $.ajax({
        type: 'GET',
        dataType: 'json',
        url: '/Home/AirQuality?city=' + city,
        success: plotAirQuality,
        error: errorOnAjax
    });
});

function errorOnAjax() {
    console.log('Error on AJAX return');
}

function displayNumbers(data) {
    console.log(data);
    $('#message').text(data.message);
    $('#num').text(data["num"]);
    $('#numbers').text(data.numbers);
}

function plotAirQuality(data) {
    var trace = {
        //x: data.x,
        x: data.xdate,
        y: data.y,
        mode: 'lines',
        type: 'scatter'
    };
    console.log(data.xdate);
    var plotData = [trace];
    var layout = {};
    Plotly.newPlot('theplot', plotData, layout);
}