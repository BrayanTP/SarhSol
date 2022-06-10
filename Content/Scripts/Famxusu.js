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
                "Cedula": $("input#Cedula").val(),
            }

            console.log("enviando=>", data);


            $('#table_id').DataTable({
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": $url + '/Famxusu/IdUsuario',
                    "type": 'POST',
                    "data": data,
                    "datatype": 'json'
                },
                pageLength: 10,
                filter: true,
                responsivePriority: 1,
                data: null,
                columns: [
                    { "data": "fam_idUsuario_fk", "name": 'Parentesco', "autoWidth": true },
                    { "data": "fam_NombreCompleto", "name": 'Parentesco', "autoWidth": true },
                    { "data": "fam_DocumentoFamiliar", "name": 'Parentesco', "autoWidth": true },
                    { "data": "fam_Parentesco_Familiar", "name": 'Parentesco', "autoWidth": true }
                ],
                "bBestroy": true,
                "destroy": true,
            })
        };
        $.ajax(settings);
    });
});

