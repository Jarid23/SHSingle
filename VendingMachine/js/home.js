$(document).ready(function () {

    loadItems();

    itemTotals();

function loadItems() {

    $.ajax({
        type: "GET",
        url: "http://localhost:8080/items",
        success: function (itemArray) {
            $.each(itemArray, function (index, item) {

                var id = item.id;
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var populate = $('#item' + id);

                var innerText = '<h3 id="name' + id + '">' + name + '</h3>';
                innerText += '<p id="price' + id + '">' + '$' + price + '</p>';
                innerText += '<p id="quantity' + id + '">' + 'Quantity: ' + quantity + '</p>';
                innerText += '<p id ="id' + id + '">' + id + '</p>';
                populate.html(innerText);

            });
        },
        error: function () {
            $('#errorMessages')
            .append($('<li>')
            .attr({ class: 'list-group-item list-group-item-danger' })
            .text('Error calling web service'));
        }
    });
}

function makePurchase() {

    var newID = $('#itemsID').val();

    var itemsPrice = $('.priceClass');
    var moneyDeposited = $('#itemTotal').val();

    if (isNaN(moneyDeposited) || isNaN(newID) || moneyDeposited == "" || moneyDeposited == 0 || newID == "") {
        $('#purchaseBox').val('Invalid Choice');
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
                $('#purchaseBox').val("Thank You");
                var changeBack = '<p>' + 'Quarters:' + data.quarters + '</p>';
                changeBack += '<p>' + 'Dimes:' + data.dimes + '</p>';
                changeBack += '<p>' + 'Nickels:' + data.nickels + '</p>';
                $('#itemChange').html(changeBack);
                loadItems();
                $("#itemTotal").val(0);
            },

            error: function (request, status, error) {
                var errors = JSON.parse(request.responseText);
                $('#purchaseBox').val(errors.message);
            }
        });
    }
};

$('#dollarButton').click(function () {
    addDollar();
});
$('#quarterButton').click(function () {
    addQuarter();
});
$('#dimeButton').click(function () {
    addDime();
});
$('#nickelButton').click(function () {
    addNickel();
});
$('#purchaseButton').click(function () {
    makePurchase();
});
$('.itemClass').click(function () {
    makePurchaseMessage();
});
$('#makeChange').click(function () {
    makeChange();
});

});

function makeChange() {
    $('#itemChange').html('');
    $('#itemBox').val('');
    $('#itemTotal').val('');
    $('#purchaseBox').val('');
    $('#itemsCost').val('');
    $('#itemsID').val('');
};

function makePurchaseMessage() {
    var itemsPrice = $('.priceClass', this).text();
    var itemsQuantity = $('.quantityClass', this).text();
    var moneyDeposited = $('#itemTotal').val();
    var moneyString = (parseFloat(itemsPrice) - parseFloat(moneyDeposited)).toFixed(2);

    if (parseInt(itemsQuantity) <= 0) {
        $('#purchaseBox').val('sold out');
    }
    else if (parseFloat(itemsPrice) > parseFloat(moneyDeposited)) {
        $('#purchaseBox').val('Please insert' + '$' + moneyString);
    }
    else {
        $('#purchaseBox').val('Item ready to purchase');
    }
};

function addDollar() {
    var lastAmount = $("#itemTotal").val();
    var newAmount = Number(lastAmount) + 1.00;
    $("#itemTotal").val(newAmount.toFixed(2));
};
function addQuarter() {
    var lastAmount = $('#itemTotal').val();
    var newAmount = Number(lastAmount) + 0.25;
    $('#itemTotal').val(newAmount.toFixed(2));
};
function addDime() {
    var lastAmount = $('#itemTotal').val();
    var newAmount = Number(lastAmount) + 0.1;
    $('#itemTotal').val(newAmount.toFixed(2));
};
function addNickel() {
    var lastAmount = $('#itemTotal').val();
    var newAmount = Number(lastAmount) + 0.05;
    $('#itemTotal').val(newAmount.toFixed(2));
};

function itemTotals() {
    $('#item1').on('click', function () {
        var price = $(this).find('#price1').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id1').text();
        $('#itemsID').val(id);
    }),
    $('#item2').on('click', function () {
        var price = $(this).find('#price2').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id2').text();
        $('#itemsID').val(id);
    }),
    $('#item3').on('click', function () {
        var price = $(this).find('#price3').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id3').text();
        $('#itemsID').val(id);
    }),
    $('#item4').on('click', function () {
        var price = $(this).find('#price4').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id4').text();
        $('#itemsID').val(id);
    }),
    $('#item5').on('click', function () {
        var price = $(this).find('#price5').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id5').text();
        $('#itemsID').val(id);
    }),
    $('#item6').on('click', function () {
        var price = $(this).find('#price6').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id6').text();
        $('#itemsID').val(id);
    }),
    $('#item7').on('click', function () {
        var price = $(this).find('#price7').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id7').text();
        $('#itemsID').val(id);
    }),
    $('#item8').on('click', function () {
        var price = $(this).find('#price8').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id8').text();
        $('#itemsID').val(id);
    }),
    $('#item9').on('click', function () {
        var price = $(this).find('#price9').text();
        $('#itemsCost').val(price);
        var id = $(this).find('#id9').text();
        $('#itemsID').val(id);
    });
};

