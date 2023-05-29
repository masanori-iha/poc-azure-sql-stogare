import { CreateService } from './services/CreateService.js';
import { Usuario } from './model/Usuario.js';

$('.create').on('click', function () {

    let usuario = new Usuario($('#Nome').val(), $('#Idade').val());

    CreateService.create(usuario)
        .then(function (response) {
            $('.voltar').click();
        })
        .catch(function (err) {
            console.log('err: ', err.responseText);
        })
});

$('.voltar').on('click', function () {
    $('#container-adicionar').hide(500);
    $('#container-adicionar').html('');

    $('#container-lista').show(700);
});