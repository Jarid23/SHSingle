$(document).ready(function () {
    loadsale();
})

function loadsale() {
    var id = ('#CarId').val();
    $.ajax({
        url: 'http://localhost:50319/car' + id,
        type: 'GET',
        success: function (car) {
            var output = "";
            var i = 0;

            output += '<div class="col-xs-3">' + car.CarYear + ' ' + car.CarModel.CarMake.MakeType + ' ' + car.CarModel.ModelType + '</div>'
            output += '<div class="col-xs-9"><table style="width:100%"><tr><th></th><th></th><th></th></tr>'
            output += '<tr><td>Body Style: ' + car.CarModel.ModelStyle.StyleType + '</td><td>Interior: ' + car.Interior + '</td><td>Price: $' + car.Price + '</td></tr>'
            output += '<tr><td>Trans: '
            if (car.IsManual) {
                output += 'Manual'
            } else {
                output += 'Automatic'
            }
            output += '</td><td>Mileage: '
            if (car.IsNew) {
                output += 'New'
            } else {
                output += car.Mileage;
            }
            output += '</td><td>MSRP: $' + car.MSRP + '</td></tr>'
            output += '<tr><td>Color: ' + car.Exterior + '</td><td>VIN: ' + car.VIN + '</td><td>'
            output += '</td></tr>'
            output += '</table></div>'
            output += '<div class="col-xs-3" style="text-align:right;">Details:</div>'
            output += '<div class="col-xs-9">' + car.CarModel.Description + '</div>'
            $('#cararea').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}
