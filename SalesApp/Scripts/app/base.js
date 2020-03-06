var app = (function () {
    var _lib;
    var _usuarios;
    var _geografias;
    var _productos;
    var _paquetes;
    var _salidas;
    var _ventas;
    var _ventasReservas;
    return {
        usuarios: _usuarios,
        geografias: _geografias,
        lib: _lib,
        productos: _productos,
        paquetes: _paquetes,
        salidas: _salidas,
        ventas: _ventas,
        ventasReservas: _ventasReservas
    };
})();

app.lib = (function () {

    /**
     * @description Funcion asincronica genérica
     */
    function _generalAsync(url, data, success, error, dataType, type, async, showModal) {

        //type = typeof type !== 'undefined' ? type : "GET";
        //async = typeof async !== 'undefined' ? async : true;
        //showModal = typeof showModal !== 'undefined' ? showModal : false;

        if (!showModal) {
            waitingDialog.show('Procesando', { dialogSize: 'sm' });
        }

        $.ajax({
            url: url,
            data: data,
            dataType: dataType,
            type: type || 'GET',
            cache: false,
            async: async || true,
            success: function (retorno) {
                success(retorno);
                waitingDialog.hide();
            },
            complete: function (code, textstatus) {
                waitingDialog.hide();
                _ajaxComplete(code, textstatus);
            },
            error: function (err) {
                error(err);
                waitingDialog.hide();
            }
        });
    }

    /**
     * @description Funcion standard para el llenado de los Select
     */
    function _llenarSelect(selector, data, defaultText) {
        $(selector).children().remove();
        if (data === null || data.length === null) return;
        $(selector).append($("<option></option>").attr("value", "").text(defaultText));
        data.forEach(function (item) {
            $(selector).append($("<option></option>").attr("value", item.Id).text(item.Name));
        });
    }
    
    function _llenarContainer(contenedor, view) {
        $(contenedor).html(view);
    }

    function _ajaxComplete(code, textstatus) {
        if (code.status === 302) {
            location.href = xhr.getResponseHeader("Location");
        }
    }

    function _getURLParameter(url, paramName) {
        paramName = paramName.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + paramName + "=([^&#]*)";
        var regex = new RegExp(regexS);
        var results = regex.exec(url);
        if (results === null)
            return "";
        else
            return results[1];
    }

    return {
        generalAsync: _generalAsync,
        llenarSelect: _llenarSelect,
        llenarContainer: _llenarContainer,
        getURLParameter: _getURLParameter
    };
})();
