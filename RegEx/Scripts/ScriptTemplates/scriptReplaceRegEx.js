function reemplazarCadena(texto, buscar) {
    // Crear una nueva expresión regular
    // 'g' es para global, reemplaza todas las ocurrencias
    // 'i' es para ignorar mayúsculas y minúsculas
    var regex = new RegExp(buscar, 'gi');

    // Usar la función replace() para reemplazar las cadenas
    var nuevoTexto = texto.replace(regex, function(match, p1) {
        //aquí va cómo reemplazas esa cadena, la lógica etc
        const reemplazo = '***';
        //en el retorno debes devolver la cadena que reemplazará a la original
        return reemplazo;
    });

    return nuevoTexto;
}