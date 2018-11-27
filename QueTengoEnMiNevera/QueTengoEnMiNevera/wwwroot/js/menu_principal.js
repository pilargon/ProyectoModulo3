
let menu_options = document.getElementsByClassName("menu_option");
for (let i = 0; i < menu_options.length; i++) {
    menu_options[i].addEventListener("click", function () {
        alert(this.innerHTML);
    });
}

//let ingredientesDisponibles = document.getElementsByClassName("ingredientesDisponibles");
//for (let i = 0; i < ingredientesDisponibles.length; i++) {
//    ingredientesDisponibles[i].addEventListener("click",RecetasController.About(this.innerHTML));
//}



//DE AQUI PARA ABAJO,HACIENDO PRUEBAS
//let ingredientesDisponibles = JSON.parse(localStorage.getItem("ingrediente"));//aqui tambien pasar a JSON
//if (ingredientesDisponibles !== null) {
//    document.getElementById("mostrar").innerHTML = ingredientesDisponibles.Nombre;
//}

//function getPerson() {
//    let ingredientesDisponibles = document.getElementById("ingrediente").value;

//    let ingredientes = { nombre: nombre }

//    document.getElementById("mostrar").innerHTML = ingrediente.nombre;

//    localStorage.setItem("ingrediente", JSON.stringify(ingrediente));//TENEMOS QUE PASARLO A JSON PORQUE SI NO,NO RECONOCE EL STRING
//}