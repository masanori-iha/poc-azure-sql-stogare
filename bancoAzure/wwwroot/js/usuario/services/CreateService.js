export class CreateService {
    static create(usuario) {

        console.log('usuario recebido: ', usuario);
        console.log(JSON.stringify(usuario));

        return $.ajax({
            url: "/Home/Adicionar",
            type: 'POST',
            contentType: 'application/json; charset=UTF-8',
            data: JSON.stringify(usuario),
            success: function (response) {
                return response;
            },
            error: function (err) {
                return err;
            }
        });
    }
}