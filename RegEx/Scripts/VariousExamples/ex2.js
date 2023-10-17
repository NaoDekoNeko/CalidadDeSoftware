function reemplazarImporte(texto, tipoCambio) {
    // Crear una nueva expresión regular para buscar importes en soles
    // Supongamos que el formato es 'S/123.45'
    var regex = /S\/(\d+(\.\d{2})?)/g;

    // Usar la función replace() para reemplazar los importes
    var nuevoTexto = texto.replace(regex, function(match, p1) {
        // Convertir el importe a dólares
        var importeDolares = parseFloat(p1) / tipoCambio;
        
        // Formatear el importe a 2 decimales y agregar el símbolo del dólar
        return '$' + importeDolares.toFixed(2);
    });

    return nuevoTexto;
}

// Uso de la función
var texto = "El total es S/100.00";
var tipoCambio = 3.8;

var resultado = reemplazarImporte(texto, tipoCambio);
console.log(resultado);  // Salida: "El total es $26.32"
