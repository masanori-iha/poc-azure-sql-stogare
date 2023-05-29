export class PartialBlobs {

    static ObterImagem(uri) {
        return $.ajax({
            type: 'GET',
            url: '/Home/ObterImagem',
            data: { uri },
            success: function (result) {
                return result;
            },
            error: function (err) {
                return err;
            }
        });
    }


    static Excluir(name) {
        return $.ajax({
            type: 'DELETE',
            url: '/Home/Excluir',
            data: { nome: name },
            success: function (result) {
                return result;
            },
            error: function (err) {
                return err;
            }
        });
    }
}