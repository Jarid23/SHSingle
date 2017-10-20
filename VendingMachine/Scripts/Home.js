$(document).ready(function () {
    LoadMachine();
});



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


function LoadMachine() {
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function (itemArray) {
            var itemsDiv = $("#allItems");

            $.each(itemArray, function (index, item) {
                var itemInfo = "<div class='col-xs-4' onClick='Vend(" +  item.id  + ")'>";

                itemInfo += "Id:" + item.id + "<br />";
                itemInfo += "Name" + item.name + "<br />";
                itemInfo += "Price:" + item.price + "<br />";
                itemInfo += "Quantity" + item.quantity + "<br />";
                itemInfo += "</div>";

                itemsDiv.append(itemInfo);
            });
        },
        error: function () {
            alert("FAILURE");
        }
    })
}

function Vend(id) {
    $('#item').val(id);
}

function VendItem(amount, id) {
    $.ajax({
        type: "GET",
        url: "http://localhost:8080/money/" + amount + "/item/" + id ,
        success: function (item) {
            //just returns change ?
           
            var quarters = (item.quarters)*.25
            var dimes = (item.dimes)*.10
            var nickels = (item.nickels)*.05
            var pennies = (item.pennies)*.01
            $('#change').val((quarters+dimes+nickels+pennies).toFixed(2));
        });
},
error: function () {
    alert("Insufficient funds");
}
error: function () {
    alert("Out of Inventory");
}

})
}