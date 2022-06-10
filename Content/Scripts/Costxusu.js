var dataTable

$(function () {
    $("button#btn-Buscar").on("click", function () {

        var controlError = 0;

        $("input[required]").each(function () {

            if ($(this).val() == "") {
                $(this).css("border", "1px solid red");
                formAprobado = false;
                controlError++;
            } else {

                if ($(this).val().length < $(this).attr("data-min")) {
                    $(this).css("border", "1px solid red");
                    formAprobado = false;
                    controlError++;
                } else {
                    $(this).css("border", "1px solid green");
                }

            }
        });

        if (controlError == 0) {

            $("button#btn-continuar").attr("disabled", "disabled");
            var data = {
                "Usucent": $("input#Usucent").val(),
            }

            console.log("enviando=>", data);


            $('#table_id').DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": $url + '/Costxusu/IdUsuario',
                    "type": 'POST',
                    "data": data,
                    "datatype": 'json'
                },
                pageLength: 10,
                filter: true,
                responsivePriority: 1,
                data: null,
                columns: [
                    { "data": "usce_Idusuario_fk", "name": 'Usuario', "autoWidth": true },
                    { "data": "usce_Idcentro_fk", "name": 'Centro de Costo', "autoWidth": true }
                ],
                "bBestroy": true,
                "destroy": true,
            })
        };
        $.ajax(settings);
    });

});

