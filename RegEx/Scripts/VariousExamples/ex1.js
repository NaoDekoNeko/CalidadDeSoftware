function reemplazarCadena(texto, buscar, reemplazar) {
    // Crear una nueva expresión regular
    // 'g' es para global, reemplaza todas las ocurrencias
    // 'i' es para ignorar mayúsculas y minúsculas
    var regex = new RegExp(buscar, 'gi');

    // Usar la función replace() para reemplazar las cadenas
    var nuevoTexto = texto.replace(regex, reemplazar);

    return nuevoTexto;
}

// Uso de la función
var texto = "Hola Mundo!";
var buscar = "mundo";
var reemplazar = "JavaScript";

var resultado = reemplazarCadena(texto, buscar, reemplazar);
console.log(resultado);  // Salida: "Hola JavaScript!"
