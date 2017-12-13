var num = 5;
var set = 0;
var cap = 0;

$(document).ready(function () {
});

$('#clearSearch').click(function () {
    $('#searchTerm').val("");
    $('#searchCategory').val("");
    //set = 0;
    //loadData();
    //updateArea();
})

function search() {
    var para = $('#searchTerm').val();
    var type = $('#searchCategory').val();
    if (para[0] == '#') {
        para = para.substring(1);
    }
    $('.next').hide();
    $.ajax({
        url: 'http://localhost:53579/sightings/' + type + '/' + para,
        type: 'GET',
        success: function (sightings) {
            alert(JSON.stringify(sightings));

            var output = '<table class="table table-bordered table-striped"><thead><tr><th>Hero Name</th><th>Location Name</th><th>LocationDescription</th><th>Location Address</th><th>Longitude Coordinate</th><th>Latitude Coordinate</th><th>Date</th></tr></thead><tbody>';
            var i = 0;

            for (i; i < sightings.length; i++) {
                if (sightings[i].Ispublished) {
                    var heroname = '';
                    $.each(sightings[i].SightingHeroes, function (index, hero) {
                        heroname += hero.HeroName + ',';
                    })
                    heroname = heroname.substring(0, heroname.length - 1);
                        output += '<div class="col-md-12">'
                        output += '<td>' + heroname + '</td>'
                        output += '<td>' + sightings[i].SightingLocation.LocationName + ' ' + '</td>'
                        output += '<td>' + sightings[i].SightingLocation.LocationDescription + ' ' + '</td>'
                        output += '<td>' + sightings[i].SightingLocation.LocationAddress + ' ' + '</td>'
                        output += '<td>' + sightings[i].SightingLocation.LongitudeCoordinate + ' ' + '</td>'
                        output += '<td>' + sightings[i].SightingLocation.LatitudeCoordinate + ' ' + '</td>'
                        //output += '<td>' + sightings[i].SightingLocation + '</td></div>'
                        output += '<td>' + sightings[i].Date.slice(0, 10) + '</td></tr></div>'
                    
                    
                }
            }
            $('#SightingsArea').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {
        }
    })
}


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
