$(document).ready(function () {
    async function buscarPesoVeiculo(codigo) {
        try {
            const response = await $.ajax({
                url: '/Fretes/BuscarPesoVeiculo?veiculo=' + codigo,
                method: 'GET',
                dataType: 'json'
            });

            if (response) {
                return parseFloat(response.peso);
            } else {
                return null;
            }
        } catch (error) {
            console.error('Erro ao buscar o veiculo:', error);
            return null;
        }
    }

    async function buscarPesoProduto(codigo) {
        try {
            const response = await $.ajax({
                url: '/Fretes/buscarPesoProduto?produto=' + codigo,
                method: 'GET',
                dataType: 'json'
            });

            if (response) {
                return parseFloat(response.peso);
            } else {
                return null;
            }
        } catch (error) {
            console.error('Erro ao buscar o produto:', error);
            return null;
        }
    }

    async function calcularFrete() {
        var distancia = parseFloat($("#Distancia").val());
        var veiculo = parseFloat($("#IdVeiculo").val());
        var produto = parseFloat($("#IdProduto").val());
        var pesoVeiculo = await buscarPesoVeiculo(veiculo);
        var pesoProduto = await buscarPesoProduto(produto);

        var valorTotal = distancia * pesoVeiculo * pesoProduto;

        // Cálculo da Taxa
        var taxa = 0;
        if (distancia <= 100) {
            taxa = valorTotal * 0.05;
        } else if (distancia <= 200) {
            taxa = valorTotal * 0.07;
        } else if (distancia <= 500) {
            taxa = valorTotal * 0.09;
        } else if (distancia > 500) {
            taxa = valorTotal * 0.10;
        }


        // Atualiza os campos na interface do usuário
        $("#Taxa").val(taxa.toFixed(2));
        $("#ValorTotal").val(valorTotal.toFixed(2));
    }

    // Chama a função calcularFrete sempre que algum dos campos relevantes for alterado
    $("#Distancia, #IdVeiculo, #IdProduto").on("change", function () {
        calcularFrete();
    });
});