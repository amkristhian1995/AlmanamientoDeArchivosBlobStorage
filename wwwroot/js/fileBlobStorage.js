function CargarBlobStorage() {
    let filebs = document.getElementById("file-bs");
    let datafile = new FormData();
    let files = filebs.files;
    if (files.length > 0) {
        let archivo = files[0];
        datafile.append('file', archivo);
        $.ajax({
            url: "/FileBlobStorage/CargarArchivo",
            type: "POST",
            data: datafile,
            processData: false,
            contentType: false,
            success: function (s) {
                alert(s);
            }, error: function (e) {
                alert("error");
            }
        });
    } else {
        alert("Selecciones 1 archivo");
    }
}