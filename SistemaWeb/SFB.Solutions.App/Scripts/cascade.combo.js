$(document).on('change', '[data-cascade-combo]', function (event) {
    //debugger;
    var id = $(this).attr('data-cascade-combo');

    var url = $(this).attr('data-cascade-combo-source');

    var paramName = $(this).attr('data-cascade-combo-param-name');

    var data = {};
    data[paramName] = id;

    $.ajax({
        url: url,
        data: { COD_NEGOCIO: $(this).val() },
        success: function (data) {

            $(id).html('');
            //debugger;
            $.each(data,
                function (index, type) {
                    var content = '<option value="' + type.Value + '">' + type.Text + '</option>';
                    $(id).append(content);
                });
        }
    });
});