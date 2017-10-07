// JavaScript source code
$("#btnSearch").click(function () {
    var zip = $("#weatherZip")
    $.ajax({
        type: "GET",
        url: "http://api.openweathermap.org/data/2.5/weather?zip=" + $("#weatherZip").val() + "&appid=1fe3e92d1a4a622cdd05ce7bd1a92dd3",
        success: function (getWeatherByZip) {
            alert("Success");
            $("#temp").val(getWeatherByZip.main.temp);
            $("#humidity").val(getWeatherByZip.main.humidity);
            $("#name").val(getWeatherByZip.name);         
            $("#clouds").val(getWeatherByZip.clouds.all);
            $("#imageTmp").attr("src" , 'http://openweathermap.org/img/w/' + getWeatherByZip.weather[0].icon + '.png');
            
        },
        error: function () {
            alert("FAILURE!");
        }
    });
});