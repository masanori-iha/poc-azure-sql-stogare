import { PartialBlobs } from './services/partialBlobsService.js';

$('.obter-imagem').on('click', function () {
    let imagem = this;
    let uri = $(imagem).eq(0).data("custom-value-uri");

    PartialBlobs.ObterImagem(uri)
        .then(function (response) {
            $('#container-imagem').html(response);
        })
        .catch(function () {
            $('#container-imagem').html('');
        });
});

$('.excluir').on('click', function () {
    let name = $(this).eq(0).data("custom-value-name");

    PartialBlobs.Excluir(name)
        .then(function (response) {
            $('#container-imagem').html('');
        })
        .catch(function () {
            $('#container-imagem').html('');
        });

});