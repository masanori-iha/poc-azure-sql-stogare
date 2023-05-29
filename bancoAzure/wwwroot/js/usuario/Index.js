import { UsuarioService } from './services/usuarioService.js'

( function() {
    $('.testeALerta').on('click', function () {
        UsuarioService.Alerta('Masanori Iha Teste')
            .then(function (response) {
                alert(response.mensagem);
            })
            .catch(function (err) {
                console.log('err: ', err);
            });
    });


    $('.excluir').on('click', function () {
        let id = $('#id-usuario').val();

        UsuarioService.Excluir(id)
            .then(function (response) {
                window.location.href = "/Home/Index";
            })
            .catch(function (err) {
                console.log('err: ', err);
            });
    });

    $('.get-adicionar').on('click', function () {
        UsuarioService.AdicionarGet()
            .then(function (data) {
                $('#container-lista').hide(500);

                $('#container-adicionar').html(data);
                $('#container-adicionar').show(700);
            })
            .catch(function (err) {
                console.log('err: ', err);
            });
    });

    $('input[name="file-upload"]').on('change', function () {
        console.log('alterado');
        console.log('this: ', this.files[0]);

        let file = this.files[0];

        UsuarioService.UploadFile(file);
    });

    $('.listar-imagens').on('click', function () {
        UsuarioService.ListarImagens()
            .then(function (data) {
                $('#container-list-blobs').html(data);
                $('#container-list-blobs').show(700);
            });
    });

})()