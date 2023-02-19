




$(document).ready(function myFunction() {
    $("#product_id").DataTable();
});



$("#add_product_id").on("click", function () {
    var $option = $(this);
    window.location = $option.attr("data-url");
});


$(document).on("click", "#update_product_id", function () {
    var $option = $(this);
    window.location = $option.attr("data-url");
});



$(document).on("click", "#add_product", function () {
    var $option = $(this);
    var name_product_id = $("#name_product_id").val();
    var desc_product_id = $("#desc_product_id").val();
    if (name_product_id == '' | desc_product_id == '') {
        Swal.fire("Favor completar todos los campos!", "Presione ok para cerrar", "info");
    } else {
        $.post("Create", { name: name_product_id, Description: desc_product_id }, function (data) {

            Swal.fire({
                title: data.message,
                text: "Presione ok para cerrar",
                icon: "success"
            }).then(function () {
                window.location.href = "Index";
            });

        });
    }

});

$(document).on("click", "#update_product", function () {

    var $option = $(this);
    console.log("Here");
    var name_product_id = $("#name_product_id").val();
    var desc_product_id = $("#desc_product_id").val();


    $.post($option.attr("data-url"), { name: name_product_id, Description: desc_product_id }, function (data) {
        Swal.fire({
            title: data.message,
            text: "Presione ok para cerrar!",
            icon: "success"
        }).then(function () {
            window.location = data.url;
        });
    });
});


$(document).on("click", "#remove_product_id", function () {
    var $option = $(this);
    console.log($option.attr("data-url"));
    Swal.fire({
        title: 'Esta seguro que desea eliminar?',
        text: "No se podrán revertir los cambios",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, deseo eliminar!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.post($option.attr("data-url"), function (data) {
                debugger
                Swal.fire({
                    title: data.message,
                    text: "Presione ok para cerrar",
                    icon: "success"
                }).then(function () {
                    window.location.reload();
                });

            });
        }
        else {
            Swal.fire(
                "Se ha cancelado la operación",
                "Presione ok para cerrar.",
                "info"
            );
        }
    })
});
















