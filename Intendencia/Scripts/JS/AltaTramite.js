$().ready(function () {


    $("#CedulaSolicitante").blur(function () {
        habilitarCampos();
    });


    function habilitarCampos() {
        var cedula = $("#CedulaSolicitante").val();
        deshabilitarCampos();
        if (cedula != "") {
            $.ajax({
                url: "Expedientes/existeSolicitante",
                type: 'POST',
                data: { cedula:cedula},
                
                success: function (result) {
                    if (result=="true") {
                        $("select[name = 'idTramiteSeleccionado']").prop("disabled", false);
                        $("#btnExpediente").prop("disabled", false);
                    } else {
                        $("#msjSolicitante").html("No se encontró la cedula. Ingrese el solicitante para continuar.");
                        $("#btnSolicitante").prop("disabled", false);
                    }
                }
            });

        }
    }

    function deshabilitarCampos() {
        $("#btnExpediente").prop("disabled", true);
        $("#btnSolicitante").prop("disabled", true);
        $("select[name = 'idTramiteSeleccionado']").prop("disabled", true);
        $("#msjSolicitante").html("");
    }
});