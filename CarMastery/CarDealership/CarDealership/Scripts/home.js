$(document).ready(function () {
    loadfeatured();
});

function loadfeatured() {
    $.ajax({
        url: 'http://localhost:50319/featured',
        type: 'GET',
        success: function (cars) {
            var output = "";
            var i = 0;

            for(i; i < cars.length; i++)
            {
                output += '<div style="text-align:center; border: 1px solid black" class="col-xs-3"><h4>' + cars[i].CarYear + ' ' + cars[i].CarModel.CarMake.MakeType + ' ' + cars[i].CarModel.ModelType
                output += '</h4><p>Price: $' + cars[i].Price + '</p></div>'
            }
            $('#featured').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow){
        }
    })
}