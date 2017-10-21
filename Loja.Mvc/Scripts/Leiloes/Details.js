//Kyle Simpson
//object literal
var Details = {
    produtoId: 0,
    nomeParticipante: "",

    inicializar: function (produtoId) {
        this.produtoId = produtoId;
        this.coectarLeilaoHub();
        this.vinculareventos();
    },

    coectarLeilaoHub: function () {

        var connection = $.hubConnection();
        var hub = connection.createHubProxy("LeilaoHub");

        connection.start();
    },

    vinculareventos: function () {
        $("#entratButton").on("click", function () {
            this.entrarLeilao();
        });
    },

    entrarLeilao: function(){
        this.nomeParticipante = $("#nomeParticipante".val());
        //this.leilaoHub.invoke("Participar", this.nomeParticipante, this.produtoId);
        $("#participanteDiv").hide();
        $("#lanceDiv").show();
        $("#valorLance").focus();
}

};