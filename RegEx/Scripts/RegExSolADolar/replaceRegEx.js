var fileContent = '';

document.getElementById('fileInput').addEventListener('change', function selectedFileChanged() {
  if (this.files.length === 0) {
    console.log('No file selected.');
    return;
  }

  var file = this.files[0];
  var reader = new FileReader();

  reader.onload = function fileReadCompleted() {
    // Almacena el contenido del archivo en la variable fileContent
    fileContent = reader.result;

    document.getElementById('content').innerText = reader.result;

    // Habilita el botón después de que el archivo se haya leído e impreso
    document.getElementById('replaceButton').disabled = false;
  };

  reader.readAsText(file);
});

document.getElementById('replaceButton').addEventListener('click', function replaceButtonClicked() {
  // Llama a la función reemplazarImporte cuando se haga clic en el botón
  reemplazarImporte();
});

function reemplazarImporte(){
  var regex = /S\/[\s]?\.[\s]?(\d+(\.\d{1,2})?)/gi;
  var nuevoTexto = fileContent.replace(regex, function(match, p1) {
    var importeDolares = parseFloat(p1) / 3.8;
    return '$/.' + importeDolares.toFixed(2);
  });
  var p = document.createElement('p');
  p.textContent = nuevoTexto;

  // Añade el nuevo elemento p a la página web, debajo del botón
  document.body.appendChild(p);
}