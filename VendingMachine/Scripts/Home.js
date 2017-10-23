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

$('#purchaseButton').click(function () {
    makePurchase();
});
$('.itemClass').click(function () {
    makePurchaseMessage();
});

function makePurchase() {

    var newID = $('#itemsID').val();

    var itemsPrice = $('.priceClass');
    var moneyDeposited = $('#totalForItem').val();



    if (isNaN(moneyDeposited) || isNaN(newID) || moneyDeposited == "" || moneyDeposited == 0 || newID == "") {
        $('#purchaseMessage').val('Invalid choice ');
    }
    else {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:8080/money/' + moneyDeposited + '/item/' + newID,
            success: function (data) {

                var quarters = (data.quarters) * .25;
                var dimes = (data.dimes) * .10;
                var nickels = (data.nickels) * .05;
                var pennies = (data.pennies) * .01;
                $('#itemBox').val((quarters + dimes + nickels + pennies).toFixed(2));
                $('#purchaseMessage').val("Thank You!");
                var changeBack = '<p>' + 'Quarters:' + data.quarters + '</p>';
                changeBack += '<p>' + 'Dimes:' + data.dimes + '</p>';
                changeBack += '<p>' + 'Nickels:' + data.nickels + '</p>';
                $('#itemChange').html(changeBack);
                loadTheItems();
                $("#totalForItem").val(0);
            },

            error: function (request, status, error) {
                var errors = JSON.parse(request.responseText);
                $('#purchaseMessage').val(errors.message);
            }
        });
    }
};