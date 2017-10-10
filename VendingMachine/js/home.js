$(document).ready(function () {


    $("#addDollar").on("click", function () {
        var currentVal = $('#total').val();
        if (currentVal == "") {
            $('#total').val((1.00).toFixed(2));
        }
        else {
            $('#total').val((parseFloat(currentVal) + 1.00).toFixed(2));
        }
        $("#total").add();
    })
    $("#addQuarter").on("click", function () {
        var currentVal = $('#total').val();
        if (currentVal == "") {
            $('#total').val((.25).toFixed(2));
        }
        else {
            $('#total').val((parseFloat(currentVal) + .25).toFixed(2));
        }
        $("#total").add();
    })
    $("#addDime").on("click", function () {
        var currentVal = $('#total').val();
        if (currentVal == "") {
            $('#total').val((.1).toFixed(2));
        }
        else {
            $('#total').val((parseFloat(currentVal) + .1).toFixed(2));
        }
        $("#total").add();
    })
    $("#addNickel").on("click", function () {
        var currentVal = $('#total').val();
        if (currentVal == "") {
            $('#total').val((.05).toFixed(2));
        }
        else {
            $('#total').val((parseFloat(currentVal) + .05).toFixed(2));
        }
        $("#total").add();
    })
});

$.ajax({
    type: "GET",
    url: "localhost:8080/items",
    success: function (itemArray) {
        var itemsDiv = $("#allItems");

        $.each(itemArray, function (index, item) {
            var itemInfo = "<p>";

            itemInfo += "Id:" + item.id + "<br />";
            itemInfo += "Name" + item.name + "<br />";
            itemInfo += "Price:" + item.price + "<br />";
            itemInfo += "Quantity" + item.quantity + "<br />";
            itemInfo += "</p>";
            itemInfo += "<hr />";

            itemsDiv.append(itemInfo);
        });
    },
    error: function () {
        alert("FAILURE");
    }
});

