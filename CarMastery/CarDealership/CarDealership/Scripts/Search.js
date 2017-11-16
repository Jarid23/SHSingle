$(document).ready(function () {
    $('#searchresults').hide();
    $('#detailsarea').hide();
});

function newcarsearch() {
    $('#searchresults').show();
    search('new');
}

function usedcarsearch() {
    $('#searchresults').show();
    search('used');
}

function search(type) {
    var searchkey = $('#searchkey').val();
    var yearmin = $('#minyear').val();
    var yearmax = $('#maxyear').val();
    var pricemin = $('#minprice').val();
    var pricemax = $('#maxprice').val();
    $.ajax({
        url: 'http://localhost:50319/cars/' + type + '/' + searchkey + '/' + yearmin + '/' + yearmax + '/' + pricemin + '/' + pricemax,
        type: 'GET',
        success: function (cars) {
            var output = "";
            var i = 0;

            for (i; i < cars.length; i++){
                output += '<div class="col-xs-3">' + cars[i].CarYear + ' ' + cars[i].CarModel.CarMake.MakeType + ' ' + cars[i].CarModel.ModelType + '</div>'
                output += '<div class="col-xs-9"><table style="width:100%"><tr><th></th><th></th><th></th></tr>'
                output += '<tr><td>Body Style: ' + cars[i].CarModel.ModelStyle.StyleType + '</td><td>Interior: ' + cars[i].Interior + '</td><td>Price: $' + cars[i].Price + '</td></tr>'
                output += '<tr><td> Trans: '
                if (cars[i].IsManual) {
                    output += 'Manual'
                }
                else {
                    output += 'Automatic'
                }
                output += '</td><td>Mileage: '
                if (cars[i].IsNew) {
                    output += 'New'
                }
                else {
                    output += cars[i].Mileage;
                }
                output += '</td><td>MSRP : $' + cars[i].MSRP + '</td></tr>'
                output += '<tr><td>Color : ' + cars[i].Exterior + '</td><td>VIN: ' + cars[i].VIN + '</td><td>'
                output += '<button type="button" class="btn btn-default" onclick="Details(' + cars[i].CarId + ')">Details</button></td></tr>'
                output += '</table></div>'
            }
            $('#carsarea').hmtl(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}

function Details(id) {
    $('#searcharea').hide();
    $('#searchresults').hide();
    $('#title').hide();
    $('#detailsarea').show();
    $.ajax({
        url: 'http://localhost:50319/car/' + id,
        type: 'GET',
        success: function (car) {
            var output = "";
            var i = 0;

            output += '<div class="col-xs-3">' + car.CarYear + ' ' + car.CarModel.CarMake.MakeType + ' ' + car.CarModel.ModelType + '</div>'
            output += '<div class="col-xs-9"><table style="width:100%"><tr><th></th><th></th><th></th></tr>'
            output += '<tr><td>Body Style: ' + car.CarModel.ModelStyle.StyleType + '</td><td>Interior: ' + car.Interior + '</td><td>Price: $' + car.Price + '</td></tr>'
            output += '<tr><td> Trans: '
            if (cars.IsManual) {
                output += 'Manual'
            }
            else {
                output += 'Automatic'
            }
            output += '</td><td>Mileage: '
            if (cars.IsNew) {
                output += 'New'
            }
            else {
                output += car.Mileage;
            }
            output += '</td><td>MSRP : $' + car.MSRP + '</td></tr>'
            output += '<tr><td>Color : ' + cars.Exterior + '</td><td>VIN: ' + cars.VIN + '</td><td>'
            output += '</td></tr>'
            output += '</table></div>'
            output += '<div class="col-xs-3" style="text-align:right;">Details:</div>'
            output += '<div class="col-xs-9">' + car.CarModel.Description + '</div>'
            if (car.Sold == null) {
                output += '<div class="col-xs-12" style="text-align:right;"><button type ="button" class="btn btn-default" onlcick="ContactUs(' + car.VIN + ')">Contact Us</button></div>'
            } else {
                output += '<div class=col-xs-12" style="text-align:right;">Sold</div>'
            }
            $('#details').hmtl(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}

function ContactUs(vin) {

}