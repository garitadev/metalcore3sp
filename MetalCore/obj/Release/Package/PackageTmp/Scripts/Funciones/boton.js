let form = document.querySelector("#form"); //almacena el formulario
let boton = document.querySelector("#boton");//y el boton 
let formA = document.querySelector("#formA"); //almacena el formulario
let botonActua = document.querySelector("#botonActua");//y el botonActua 
let formIn = document.querySelector("#formIn");
let botonIn = document.querySelector("#botonIn");

function Habilitar() {

    let desabilitar = false;

    if (form.idRol.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (form.Nombre.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (form.Apelli.value == "") {
        desabilitar = true;

    }
    if (form.email.value == "") {
        desabilitar = true;

    }
    if (form.cedu.value == "") {
        desabilitar = true;

    }
    if (form.pass.value == "") {
        desabilitar = true;

    }
    if (desabilitar == true) {
        boton.disabled = true;
       

    }
    else {
        boton.disabled = false;
       

    }

}

form.addEventListener("keyup", Habilitar) //evento para verificar que el usuario esta escribiendo




function HabilitarActua() {

    let desabilitar = false;

    if (formA.idRol.value == "") {
        desabilitar = true;

    }
    if (formA.Nombre.value == "") {
        desabilitar = true;

    }
    if (formA.Apelli.value == "") {
        desabilitar = true;

    }
    if (formA.email.value == "") {
        desabilitar = true;

    }
    if (formA.idEstado.value == "") {
        desabilitar = true;

    }
    if (desabilitar == true) {

        botonActua.disabled = true;

    }
    else {

        botonActua.disabled = false;

    }
    formA.addEventListener("keyup", HabilitarActua) //evento para verificar que el usuario esta escribiendo


}

//inventario
function HabilitarIn() {

    let desabilitar = false;

    if (formIn.idPro.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (formIn.nombre.value == "") {
        desabilitar = true;//cambia el valor

    }
    if (formIn.marca.value == "") {
        desabilitar = true;

    }
    if (formIn.canti.value == "") {
        desabilitar = true;

    }
    if (formIn.Preci.value == "") {
        desabilitar = true;

    }
   
    if (desabilitar == true) {
        botonIn.disabled = true;


    }
    else {
        botonIn.disabled = false;


    }
    formIn.addEventListener("keyup", HabilitarIn) //evento para verificar que el usuario esta escribiendo
}


//precio de los productos

function EncontrarPrecio() {

    var IdProducto = $('#IdProducto').val();
    let Precio = $("#Precio").val();



    $.ajax({
        type: "POST",
        url: '/Trabajo/EncontrarPrecio',
        data: {
            IdProducto: IdProducto,
            Precio: Precio
        },
        dateType: 'json',
        success: function (response) {
            $("#IdProducto").removeAttr('disabled');

            document.getElementById("Precio").value = response;

        },
        error: function (response) {
            $("#IdProducto").attr('disabled', 'disabled');
            document.getElementById("Precio").value = "ERROR"

        }
    });
}