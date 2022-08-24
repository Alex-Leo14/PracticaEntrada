$(function () {
    $("#cboNegocio").change(function () {
        $("#cboNegocio").empty();
        $("#cboNegocio").val(null).trigger("change");
        if (valor != '0') {
            var negocio = $("#cboNegocio").val();
            var pais = "155";

            $.ajax({
                type: "POST",
                async: true,
                url: "/Account/GetCuenta",
                contentType: "application/json",
                dataType: "Json",
                data: JSON.stringify({ COD_NEGOCIO: negocio, COD_PAIS: pais }),
                error: function (ex) {
                },
                success: function (data) {
                    $('#cboCuenta').empty();
                    data.forEach(function (entry) {
                        $('#cboCuenta').append(
                            $('<option></option>').val('0').html('Seleccione')
                        );
                        entry.data.forEach(function (entry) {
                            $('#cboCuenta').append(
                                $('<option></option>').val(entry.COD_CUENTA).html(entry.DESC_CUENTA)
                            );
                        });
                    });

                },
            });

        } else {
            //rolModule.RolPuntoVenta();
        }
    });
});