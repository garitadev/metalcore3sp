function EnviarEstado() {
    //var IdTrabajoEstado = $('#IdTrabajoEstado').val();
    let idEstado = $('#idEstado').val();

    $.ajax({
        type: "POST",
        url: '/Trabajo/idEspecifico',
        data: {
            // IdTrabajoEstado: IdTrabajoEstado,
            idEstado: idEstado

        },
        dataType: 'json',
        success: function (response) {
            let items = "";
            for (var i = 0; i < response.length; i++) {

                items +=


                    "<div class='col-xl-3 col-md-6 mb-4'>" +
                    "<div class='card border-left-success shadow h-100 py-2'>" +
                    "<div class='card-body'>" +
                    "<div class='row no-gutters align-items-center'>" +
                    "<div class='col mr-2'>" +
                    "<div class='text-xs h5 font-weight-bold text-striped text-uppercase mb-1'>  Trabajo:" + response[i].IdTrabajo + "</div>" +
                    "<div class='text-xs  h6 font-weight-bold table-striped  mb-1'>Encargado:" + response[i].Nombre + "</div>" +
                    "<div class=' text-xs  h6 mb-0 text-uppercase font-weight-bold text-gray-800'>Estado:" + response[i].Estado + "</div>" +
                    "</div >" +
                    "</div >" +
                    "</div >" +
                    "</div >" +
                    "</div >"
            }

            document.getElementById("MiCard").innerHTML = items;

        },
        error: function (response) {
            $("#IdProducto").attr('disabled', 'disabled');
            document.getElementById("IdTrabajoEstado").value = "ERROR"
        }
    });
}