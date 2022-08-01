$(document).ready(function () {
    console.log("Ready")
    $("#btnAsignar").attr('disabled', 'disabled');

    $("#dataTable").dataTable().fnDestroy();

    $('#dataTable').dataTable({
        "language": {
            "url": "http://cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json"
        }
    })

});

function isNumber(evt) {
    var iKeyCode = (evt.witch) ? evt.witch : evt.keyCode
    if (iKeyCode < 48 || iKeyCode > 57) {
        return false;
    }
    return true;
}




function DetalleTrabajo(Descripcion, NombreUsuario) {
    console.log("hola")
   $('#mtxtNombre').val(NombreUsuario);
   $('#mtxtDescripcion').val(Descripcion);

}

