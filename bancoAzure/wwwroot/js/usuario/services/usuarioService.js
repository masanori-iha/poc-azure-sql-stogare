export class UsuarioService {   

    static Alerta(msg) {
        return $.ajax({
            url: '/Home/Alerta',
            type: 'GET',
            success: function (response) {
                return response;
            },
            error: function (err) {
                return err;
            }
        });
    }

    static Excluir(id) {
        return $.ajax({
            url: '/Home/Excluir',
            type: 'PUT',
            data: { id },
            success: function (response) {
                return response;
            },
            error: function (err) {
                return err;
            }
        });
    }

    static AdicionarGet() {
        return $.ajax({
            url: '/Home/Adicionar',
            type: 'GET',
            success: function (response) {
                return response;
            },
            error: function (err) {
                return err;
            }
        });
    }

    static UploadFile(file) {
        let formData = new FormData();
        formData.append('files', file);

        return $.ajax({
            url: '/Home/Upload',
            type: 'POST',
            dataType: 'json',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                return response;
            },
            error: function (err) {
                return err;
            }
        })
    }

    static ListarImagens() {
        return $.ajax({
            url: '/Home/ListarImagens',
            type: 'GET',
            success: function (response) {
                return response;
            },
            error: function (err) {
                return err;
            }
        });
    }
}