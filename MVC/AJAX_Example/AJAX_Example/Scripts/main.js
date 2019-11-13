

$("#request").click(function () {
    var n = $("#count").val();
    var uri = "/this/is/an/inclass/example/gimme/RandomNumbers?id=" + n;
    $.ajax({
        type:"GET",
        dataType:"json",
        url: uri,
        success: displayData,
        error: errorOnAjax
    });
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/Earthquakes",
        success: displayEarthquakes,
        error: errorOnAjax
    });
});

function errorOnAjax() {
    console.log("ERROR in ajax request.");
}

function displayData(data) {
    console.log(data);
    $('#message').text(data["message"]);
    $('#num').text(data.num);
    $('#numbers').text(data["numbers"]);
    var trace = {
        x: data.numbers1,
        y: data.numbers,
        mode: 'lines',
        type: 'scatter'
    };
    var plotData = [trace];
    var layout = {};
    Plotly.newPlot('theplot', plotData, layout);
}

function displayEarthquakes(data) {
    for (var i = 0; i < data.length; ++i) {
        $('#earthquakes').append($('<li>' + data[i] + '</li>'));
    }
}