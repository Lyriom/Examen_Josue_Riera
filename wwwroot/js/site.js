// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function mostrarAlerta() {
    alert("Mi nombre es Josue y mi hobbie es chambear.");
    cambiarColorBoton();
}

function cambiarColorBoton() {
    const boton = document.querySelector('.btn-info');
    boton.classList.remove('btn-info');
    boton.classList.add('btn-success');
    boton.innerText = "Información Mostrada";
}

