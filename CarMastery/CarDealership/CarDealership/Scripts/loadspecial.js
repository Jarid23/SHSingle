$(document).ready(function () {
    loadspecials();
});

function loadspecials() {
    $.ajax({
        url: 'http://localhost:50319/specials',
        type: 'GET',
        success: function (specials) {
            var output = "";
            var i = 0;

            for (i; i < specials.length; i++) {
                output += '<div style="border: 1px solid black"><h3>' + specials[i].Title + '</h3>'
                output += '<p>' + specials[i].Description + '</p>'
                output += '<button class="btn btn-danger">Delete</button></div>'
            }
            $('#specialarea').html(output);
        },
        error: function (jqxhr, techstatus, errorthrow) {

        }
    })
}