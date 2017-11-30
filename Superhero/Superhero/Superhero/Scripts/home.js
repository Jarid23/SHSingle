var num = 5;
var set = 0;
var cap = 0;

$(document).ready(function () {
});

function getNumber(number, sets) {
    $.ajax({
        url: 'http://localhost:53579/sightings/' + number + '/' + sets,
        type: 'GET',
        success: function (sightings) {
            var output = "";
            var i = 0;
         
            for (i; i < sightings.length; i++) {
                if (sightings[i].Ispublished) {                    
                    output += '<div class="col-xs-10 blogDiv"><div class="col-xs-3"><div class="titleDiv"><h4>'
                    output += sightings[i].Date + '</h4></div><h5>'
                    output += sightings[i].SightingHereos + '</h5><br />'
                    output += sightings[i].SightingLocation(0, 10) + '</div>'
                    output += '<div class="col-xs-9 innerDiv">'                    
                }
            }
            if (i < num - 1) {
                cap = 1;
            }
            $('#SightingsArea').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}
