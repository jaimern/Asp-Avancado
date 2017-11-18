var Index = {
    viewModel: {
        produtos: ko.observableArray()
    },

    inicializar: function () {

        this.conectarLeilaoHub();
        ko.applyBindings(this.viewModel);
        this.ObterOfertas();
    },
    conectarLeilaoHub: function () {
        var connection = $.hubConnection();
        var hub = connection.createHubProxy("LeilaoHub");

        hub.on("atualizarOfertas", this.ObterOfertas.bind(this));
        connection.start();
    },

    //atualizarOfertas: function () {
    //    this.viewModel.produtos.push({
    //        id: 1,
    //        nome: "Grampeador",
    //        preco: 11.3,
    //        estoque: 1,
    //        categoriaNome: "Papelaria"
    //    })
    //}

    ObterOfertas: function () {
        var self = this;
        $.getJSON("/api/Vendas/Leiloes", function (response) {
            self.viewModel.produtos(response)

        });
    }
};