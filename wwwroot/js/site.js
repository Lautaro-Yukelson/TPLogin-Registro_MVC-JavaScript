// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.addEventListener("DOMContentLoaded", () => {
    const contrasena = document.getElementById("ContrasenaR");
    const caracteresEspeciales = ["!", "@", "#", "$", "%", "&"];
    const letrasMayusculas = ["A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M","N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"];
    

    contrasena.addEventListener("input", (event) => {
      const contrasenaValue = event.target.value;
      const contieneCaracterEspecial = caracteresEspeciales.some(caracter => contrasenaValue.includes(caracter));
      const contieneLetraMayuscula = letrasMayusculas.some(caracter => contrasenaValue.includes(caracter));
      
      if (contrasenaValue.length >= 8 && contieneCaracterEspecial && contieneLetraMayuscula) {
        console.log("Contraseña válida");
        contrasena.style.border = "2px solid green";
      } else {
        contrasena.style.border = "2px solid red";
        console.log("Contraseña no válida");
      }
    });
});