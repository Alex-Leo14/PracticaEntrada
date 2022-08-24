
var producto = {
    _URL_Controller: "/Producto",
    index: function () {
        $.ajax({
            url: producto._URL_Controller + "/Listar",
            type: 'POST',
            dataType: "json",
            data: {},
            contentType: "application/json; charset=utf-8",
            beforeSend: function () {
                $('.ibox-content').addClass('sk-loading');
            },
            success: function (res) {
                $('.ibox-content').removeClass('sk-loading');
                producto.SendData(res);

            },
            error: function (res) {
                $('.ibox-content').removeClass('sk-loading');
                //toastr.error("Error al cargar registros");
            }
        });
        $('#btnCrear').off().on('click', function () {
            producto.nuevo();
        });
        $('#TbProd tbody').on('click', '#btnEdit', function () {
            let dtTable = $('#TbProd').DataTable();
            let cr = $(this).closest("tr");
            let objData = dtTable.row(cr).data();
            producto.editar(objData);
        });

        $('#TbProd tbody').on('click', '#btnAnul', function () {
            let dtTable = $('#TbProd').DataTable();
            let cr = $(this).closest("tr");
            let objData = dtTable.row(cr).data();
            producto.anular(objData);
        });


        $('#txtstrProductoDesc').val('');
        $('#txtintCantidad').val('');
        $('#txtdecPrecio').val('');



    },
    nuevo: function () {

        $.ajax({
            cache: false,
            async: true,
            type: "GET",
            url: producto._URL_Controller + "/_Create",
            data: {},
            success: function (response) {
                $('#myModal').modal('show');
                $('#lblTitulo').text('Nueva Venta');
                $('#resultado').html(response);

                $('#btnGuardar').off().on('click', function () {
                    producto.Insert();
                });
            }
        });

    },
    Insert: function () {

        let obj = new Object();
        //obj.intProductoID = $('#txtintProductoID').val();
        obj.strProductoDesc = $('#txtstrProductoDesc').val();
        obj.intCantidad = $('#txtintCantidad').val();
        obj.decPrecio = $('#txtdecPrecio').val();
        if (obj.strProductoDesc === "") {
            toastr.error('!!! No Existe una Descripción ');
            $('#txtstrProductoDesc').focus();
            return;
        }

        _URL_Controller = '/Producto/Insert/'

        $.ajax({
            cache: false,
            async: true,
            type: "POST",
            url: _URL_Controller,
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                if (res.Satisfactorio) {
                    toastr.success('!!Se Grabo Correctamente')
                    $('#myModal').modal('hide');
                    //$.toast('!!Se Grabo Correctamente')

                    producto.index();
                }
                else {
                    console.log(res);
                    //$.toast('Hubo un Error')
                    //toastr.warning('!!! Error inesperado. !');

                }
            },
            error: function (res) {
                console.log(res);
                toastr.error('!!! Error');
                $('#myModal').modal('hide');
            }
        });
    },
    editar: function (data) {

        $.ajax({
            cache: false,
            async: true,
            type: "GET",
            url: producto._URL_Controller + "/_Create",
            data: {},
            success: function (response) {
                $('#myModal').modal('show');
                $('#lblTitulo').text('Editar Venta');
                $('#resultado').html(response);

                $('#txtintProductoId').val(data["intProductoId"]);
                $('#txtstrProductoDesc').val(data["strProductoDesc"]);
                $('#txtintCantidad').val(data["intCantidad"]);
                $('#txtdecPrecio').val(data["decPrecio"]);
               

                $('#btnGuardar').off().on('click', function () {
                    producto.Update();
                });
            }
        });
    },
    Update: function () {

        let obj = new Object();

        obj.intProductoId = $('#txtintProductoId').val();
        obj.strProductoDesc = $('#txtstrProductoDesc').val();
        obj.intCantidad = $('#txtintCantidad').val();
        obj.decPrecio = $('#txtdecPrecio').val();

        if (obj.strProductoDesc === "") {
            toastr.error('!!! No Existe una Descripción ');
            $('#txtstrProductoDesc').focus();
            return;
        }

        _URL_Controller = '/Producto/Act/'

        $.ajax({
            cache: false,
            async: true,
            type: "POST",
            url: _URL_Controller,
            data: JSON.stringify(obj),
            contentType: "application/json; charset=utf-8",
            success: function (res) {
                if (res.Satisfactorio) {
                    toastr.success('!!! Datos Modificados correctamente !!');
                    $('#myModal').modal('hide');
                    producto.index();
                }
                else {
                    toastr.warning('!!! Error Inesperado. !');
                    $('#myModal').modal('hide');
                }
            },
            error: function (res) {
                console.log(res);
                toastr.error('!!! Error');
                $('#myModal').modal('hide');
            }
        });
    },
    anular: function (data) {
        let objEntidad = new Object();
        objEntidad.intProductoId = data["intProductoId"];

        swal({
            title: "Continuar Proceso",
            text: "Estas seguro que Desea Anular : " + data["strProductoDesc"],
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#1CB394",
            confirmButtonText: 'Continuar',
            closeOnConfirm: true,
            showLoaderOnConfirm: true
        }, function () {
            $.ajax({
                url: producto._URL_Controller + '/Anular',
                type: 'POST',
                dataType: "json",
                data: JSON.stringify(objEntidad),
                contentType: "application/json; charset=utf-8",
                success: function (res) {

                    if (res.Satisfactorio) {
                        toastr.success('!!! Datos Anulados Correctamente');
                        producto.index();
                    }
                    else {
                        toastr.error('!!! Anulación Erroneo')
                    }
                },
                error: function (res) {
                    //toastr.error('!!! Error al Anular Datos')
                }
            });
        });
    },
    SendData: function (request) {
        let dtData = request
        let table = $('#TbProd').DataTable({
            destroy: true,
            responsive: true,
            processing: true,
            filter: true,
            orderMulti: false,
            pageLength: 50,
            dom: '<"html5buttons"B>lTfgitp',
            buttons: [
                {
                    extend: 'excelHtml5', className: 'btn btn-office-excel btn-sm btn-rounded',
                    text: '<span class="fa fa-file-excel-o"></span> Excel Export',
                    title: 'Producto',
                    customize: function (xlsx) {
                        // Obtenga los estilos incorporados
                        // consulte buttons.html5.js "xl / styles.xml" para la estructura XML
                        var styles = xlsx.xl['styles.xml'];

                        // Cree su propio estilo para usar el formato de número "Texto" con id: 49
                        var style = '<xf numFmtId="49" fontId="0" fillId="0" borderId="0" xfId="0" applyFont="1" applyFill="1" applyBorder="1" applyNumberFormat="1"/>';
                        // Agregar nuevo nodo y actualizar contador
                        el = $('cellXfs', styles);
                        el.append(style).attr('count', parseInt(el.attr('count')) + 1);
                        // Índice de nuestro nuevo estilo
                        var styleIdx = $('xf', el).length - 1;

                        // Aplicar nuevo estilo a la primera columna (A)
                        var sheet = xlsx.xl.worksheets['sheet1.xml'];
                        //Establecer nuevo estilo predeterminado para la columna (opcional)
                        $('col:eq(0)', sheet).attr('style', styleIdx);

                        // Aplicar nuevo estilo a las filas existentes de la primera columna ('B')
                        // Saltar la fila del encabezado
                        $('row:gt(0) c[r^="A"]', sheet).attr('s', styleIdx);
                    },
                    exportOptions: {
                        format: {
                            body: function (data, row, column, node) {
                                return column === 0 ? "\0" + data : data;
                            }
                        },
                        columns: [0, 1, 2, 3, 4, 5]
                    },
                },
            ],
            language: {
                emptyTable: "No existen registros",
                loadingRecords: "Cargando ...",
                info: "Mostrando _START_ a _END_ de _TOTAL_ registro(s)",
                infoFiltered: "No existen registros",
                search: "Ingrese filtro",
                lengthMenu: "Filtrando _MENU_ Archivos por Página",
                paginate: {
                    first: "Primero",
                    previous: "Anterior",
                    next: "Siguiente",
                    last: "Ultimo"
                },
                responsive: true,
                aria: {
                    sortAscending: ": activate to sort column ascending",
                    sortDescending: ": activate to sort column descending"
                }
            },
            lengthMenu: [[10, 25, 50, 100, -1], [10, 25, 50, 100, 'Todos']],
            data: dtData,
            columns: [
                { data: "intProductoId", "autoWidth": false },
                { data: "strProductoDesc", "autoWidth": false },
                { data: "intCantidad", "autoWidth": false },
                { data: "decPrecio", "autoWidth": false },
               
                {
                    data: "intProductoId", "autoWidth": true, "render": function (data, type, row, meta) {
                        var a = '';
                        a = '<button id="btnEdit" class="btn btn-success btn-sm" title="Editar"> <span class="fa fa-pencil" aria-hidden="true"></span></button>&nbsp;'
                        a += '<button id="btnAnul" class="btn btn-danger btn-sm" title="Anular"> <span class="fa fa-trash" aria-hidden="true"></span></button>'
                        return a;
                    }
                },


            ],
            columnDefs: [
                { "width": "10px", "targets": 0 },
                { "width": "10px", "targets": 4 }
            ]
        });
    },
};