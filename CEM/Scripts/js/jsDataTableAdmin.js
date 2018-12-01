

$(document).ready(function () {
    $("#msjExito").hide();
    $('#TUsuarios').DataTable({
        language: {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ Registros",
            "sZeroRecords": "&nbsp;",
            "sEmptyTable": "&nbsp;",
            "sInfo": "Encontrados: _TOTAL_ Registros (Mostrando del _START_ al _END_)",
            "sInfoEmpty": "* No se han encontrado resultados en la búsqueda",
            "sInfoFiltered": "",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        aoColumnDefs: [{ 'bSortable': false, 'aTargets': ['no-sortable'] }],responive:true
    });

    $('#TPDE').DataTable({
        language: {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ Registros",
            "sZeroRecords": "&nbsp;",
            "sEmptyTable": "&nbsp;",
            "sInfo": "Encontrados: _TOTAL_ Registros (Mostrando del _START_ al _END_)",
            "sInfoEmpty": "* No se han encontrado resultados en la búsqueda",
            "sInfoFiltered": "",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        aoColumnDefs: [{ 'bSortable': false, 'aTargets': ['no-sortable'] }]
    });

    $('#TCentros').DataTable({
        language: {
            "sProcessing": "Procesando...",
            "sLengthMenu": "Mostrar _MENU_ Registros",
            "sZeroRecords": "&nbsp;",
            "sEmptyTable": "&nbsp;",
            "sInfo": "Encontrados: _TOTAL_ Registros (Mostrando del _START_ al _END_)",
            "sInfoEmpty": "* No se han encontrado resultados en la búsqueda",
            "sInfoFiltered": "",
            "sInfoPostFix": "",
            "sSearch": "Buscar:",
            "sUrl": "",
            "sInfoThousands": ",",
            "sLoadingRecords": "Cargando...",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "oAria": {
                "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                "sSortDescending": ": Activar para ordenar la columna de manera descendente"
            }
        },
        aoColumnDefs: [{ 'bSortable': false, 'aTargets': ['no-sortable'] }]
    });

    alert('pooh');
});