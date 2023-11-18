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
    pascalToCamel();
});

function pascalToCamel() {
    var regex = /^([A-Z])(\w*)$/gi;
    var nuevoTexto = fileContent.replace(regex, function(match, group1, group2){
        return group1.toLowerCase + group2;
    });
    var p = document.createElement('p');
    p.textContent = nuevoTexto;

    // Añade el nuevo elemento p a la página web, debajo del botón
    document.body.appendChild(p);
}

function camelToPascal(){
    var regex = /^([a-z])(\w*)$/gm;
    var nuevoTexto = fileContent.replace(regex, function(match, group1, group2){
        return group1.toUpperCase() + group2;
    });
    var p = document.createElement('p');
    p.textContent = nuevoTexto;

    // Añade el nuevo elemento p a la página web, debajo del botón
    document.body.appendChild(p);
}

document.getElementById('replaceButtonText').addEventListener('click', function replaceButtonTextClicked() {
    var text = document.getElementById('searchInput');
    camelToPascalText(text.value);
});

function camelToPascalText(str) {
    var regex = /^([a-z])(\w*)$/gm;
    var nuevoTexto = str.replace(regex, function(match, group1, group2){
        return group1.toUpperCase() + group2;
    });
    var p = document.createElement('p');
    p.textContent = nuevoTexto;

    // Añade el nuevo elemento p a la página web, debajo del botón
    document.body.appendChild(p);
}

function pascalToCamelText(str) {
    var regex = /^([A-Z])(\w*)$/gm;
    var nuevoTexto = str.replace(regex, function(match, group1, group2){
        return group1.toLowerCase() + group2;
    });
    var p = document.createElement('p');
    p.textContent = nuevoTexto;

    // Añade el nuevo elemento p a la página web, debajo del botón
    document.body.appendChild(p);
}

document.getElementById('replaceButtonPascalCamel').addEventListener('click', function replaceButtonPascalCamelClicked() {
    var text = document.getElementById('searchInput');
    pascalToCamelText(text.value);
});
