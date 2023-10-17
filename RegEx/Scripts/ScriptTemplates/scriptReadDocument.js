document.getElementById('fileInput').addEventListener('change', function selectedFileChanged() {
    if (this.files.length === 0) {
      console.log('No file selected.');
      return;
    }
  
    var file = this.files[0];
    var reader = new FileReader();
  
    reader.onload = function fileReadCompleted() {
      document.getElementById('content').innerText = reader.result;
    };
  
    reader.readAsText(file);
  });
  