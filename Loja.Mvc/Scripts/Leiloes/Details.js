//Kyle Simpson
//object literal
var Details = {
    produtoId: 0,
    nomeParticipante: "",
    leilaoHub: {},
    connectionId:"",

    inicializar: function (produtoId) {
        this.produtoId = produtoId;
        this.conectarLeilaoHub();
        this.vinculareventos();
    },

    conectarLeilaoHub: function () {
        var self = this;
        var connection = $.hubConnection();
        this.leilaoHub = connection.createHubProxy("LeilaoHub");
        //hub.on("atualizarOfertas", function () { document.location.reload(); });
        
        connection.start().done(function () { self.connectionId = connection.id });


    },

    vinculareventos: function () {
        var self = this;
        $("#entrarButton").on("click", function () {
            self.entrarLeilao();
        });

        $("#enviarLanceButton").on("click", function () {
            self.RealizarLance();
        });

        this.leilaoHub.on("receberLike", function (nomeRemetente) { self.receberLike(nomeRemetente) });

        this.leilaoHub.on("adicionarMensagem", function (nomeParticipante, connectionId, mensagem) {
            self.adicionarMensagem(nomeParticipante, connectionId, mensagem);

            $(document).on("click", "a[data-connection-id]",
                function () {
                    self.enviarLike($(this).data("connection-id"));
                });

        });
    },

    entrarLeilao: function () {
        this.nomeParticipante = $("#nomeParticipante").val();
        this.leilaoHub.invoke("Participar", this.nomeParticipante, this.produtoId);
        $("#participanteDiv").hide();
        $("#lanceDiv").show();
        $("#valorLance").focus();
    },

    adicionarMensagem: function (nomeParticipante, connectionId, mensagem) {
        $("#lancesRealizadosTable").append(this.montarMensagem(nomeParticipante, connectionId, mensagem));
    },
    montarMensagem: function (nomeRemetente, connectionId, mensagem) {
        var tr = "<tr>";
        tr += "<td>" + nomeRemetente + "</td>";
        tr += "<td>" + mensagem + "</td>";

        var like = "<a data-connection-id='" + connectionId + "' href='#'>" +
                    "<span class='glyphicon glyphicon-thumbs-up' style='font-size:18px'></span></a>";
        var enviadaPorMim = this.connectionId === connectionId;

        tr += "<td>" + (enviadaPorMim ? "" : like) + "</td>";

        tr += "</tr>";

        return tr;
    },

    RealizarLance: function () {
        this.leilaoHub.invoke("RealizarLance", this.nomeParticipante, this.connectionId,
            $("#valorLance").val(), this.produtoId);
    },

    enviarLike:function(connectionIdDestinatario){
        this.leilaoHub.invoke("EnviarLike", this.nomeParticipante, connectionIdDestinatario);
    },

    receberLike: function (nomeRemetente) {
        $("#sinoNotificacoes")
            .popover("destroy")
            .popover({
                content: "<span class='glyphicon glyphicon-thumbs-up' style='font-size:24px'></span>",
                html: true,
                placement: "left",
                title: nomeRemetente + " diz:"
            })
            .popover("show");
    }

};