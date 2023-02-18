
$(document).ready(function myFunction() {
    $('#table').DataTable();
});

$(document).on("click","#update_client", function () {
    var $option = $(this);

    var name_id = $("#name_id").val();
    var last_name_id = $("#last_name_id").val();
    var number_id = $("#number_id").val();

    if (name_id == '' | last_name_id == '' | number_id == '') {
        Swal.fire({
            title: "Favor completar todos los campos",
            text: "Presione ok para cerrar",
            icon: "info"
        });
    } else {
        $.post($option.attr("data-url"), { Name: name_id, LastName: last_name_id, Telephone: number_id }, function (data) {
            Swal.fire({
                title: data.message,
                text: "Presione Ok para cerrar!",
                icon: "success"

            }).then(function () {
                window.location = data.url;
            });
        });

    }
});


$(document).on("click", "#update_client_id", function () {
    var $option = $(this);
    window.location.href = $option.attr("data-url");
});

$(document).on("click", "#remove_client_id", function () {
    var $option = $(this);
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


$(document).on("click", "#add_client_id", function () {


    var name_id = $("#name_id").val();
    var last_name_id = $("#last_name_id").val();
    var number_id = $("#number_id").val();



    if (name_id == '' | last_name_id == '' | number_id == '') {
        Swal.fire({
            title: "Favor completar todos los campos",
            text: "Presione ok para cerrar",
            icon: "info"
        });
    } else {

        $.post("AddClient", { Name: name_id, LastName: last_name_id, Telephone: number_id }, function (data) {

            Swal.fire({
                title: data.message,
                text: "Presione Ok para cerrar!",
                icon: "success"

            }).then(function () {

                window.location.href = "GetAllClient";
            });
        });

    }
});


$("#add_client").on("click", function () {
    window.location.href = "AddClient";
});

