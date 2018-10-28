function GenerarReporte(idAlumno, idPrograma) {
    var params = { 'idAlumno': idAlumno, 'idPrograma': idPrograma };
    $.ajax({
        url: '@Url.Action("GenerarReporte", "User")',
        type: 'POST',
        data: params,
        success: function (result) {
            //alert(result);
            if (result === 'true') {
                toastr.success('La descarga del certificado comenzara en breve');
                window.open('http://localhost:64400/Scripts/Documentos/certificadoAlumno.docx');
            }
            else {
                toastr.error(result);
            }
        },
        error: function () {
            alert('Ajax arroja error');
        }
    }
    );
}