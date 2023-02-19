



$(document).ready(function myFunction() {
    $("#order_list").DataTable();
});

$(document).on("click", "#add_order", function () {
    var $option = $(this);
    window.location = $option.attr("data-url");
});

$(document).on("click", "#add_order_id", function () {
    var $option = $(this);
    var client_id = $("#client_id").val();
    var product_id = $("#product_id").val();
    if (client_id == '' | product_id == '') {
        Swal.fire("Favor seleccione para agregar una nueva orden", "Presione ok para cerrar", "info");
    } else {
        $.post($option.attr("data-url"), { IdProduct: product_id, IdClient: client_id }, function () {
            Swal.fire({
                title: "Se ha agregado con exito",
                text: "Presione ok para cerrar",
                icon: "success"
            }).then(function () {
                window.location.reload();
            });
        });
    }


});


