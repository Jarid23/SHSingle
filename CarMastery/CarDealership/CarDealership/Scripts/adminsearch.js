$(document).ready(function () {
    $('#searchresults').hide();
    $('#detailsarea').hide();
});

function search() {
    var searchkey = $('#searchkey').val();
    var yearmin = $('#minyear').val();
    var yearmax = $('#maxyear').val();
    var pricemin = $('#minprice').val();
    var pricemax = $('#maxprice').val();

    $.ajax({
        url: 'http://localhost:50319/cars/both' + searchkey + '/' + yearmin + '/' + yearmax + '/' + pricemin + '/' + pricemax,
        type: 'GET',
        success: function (cars) {
            var output = "";
            var i = 0;

            for (i; i < cars.length; i++) {
                output += '<div class="col-xs-3">' + cars[i].CarYear + ' ' + cars[i].Model.CarMake.MakeType + ' ' + cars[i].Model.ModelType + '</div>'
                output += '<div class ="col-xs-9"><table style="width:100%"><tr><th></th><th></th><th></th></tr>'
                output += '<tr><td>Body Style: ' + cars[i].Model.ModelStyle.StyleType + '</td><td>Interior: ' + cars[i].Interior + '</td><td>Price: $' + cars[i].Price + '</td></tr>'
                output += '<tr><td>Trans : '
                if (cars[i].IsManual) {
                    output += 'Manual'
                } else {
                    output += 'Automatic'
                }
                output += '</td><td>Mileage: '
                if (cars[i].IsNew) {
                    output += 'New'
                } else {
                    output += cars[i].Mileage;
                }
                output += '</td><td>MSRP: $' + cars[i].MSRP + '</td></tr>'
                output += '</tr><td>Color: ' + cars[i].Exterior + '</td><td>VIN: ' + cars[i].VIN + '</td><td>'
                output += '<button type = "button" class="btn btn-default" onclick="Details(' + cars[i].CarId + ')">Details</button></td></tr>'
                output += '</table></div>'
            }
            $('#carsarea').html(output);
            $('#searchresults').show();
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}