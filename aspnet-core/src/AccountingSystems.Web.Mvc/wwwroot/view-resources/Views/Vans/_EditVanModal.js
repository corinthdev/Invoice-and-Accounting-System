(function ($) {

    var _vanService = abp.services.app.van;
    var _$modal = $('#VanEditModal');
    var _$form = $('form[name=VanEditForm]');

    $('#SalesCodeEdit').change(function (e) {

        var salesmanCode = $("#SalesCodeEdit").val();

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Salesman/GetSalesmanName?salesmanCode=' + salesmanCode,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (result) {
                $('#SalesmanNameEdit').val(result.name).focus();
                $('#SalesmanIdEdit').val(result.id);
            },
            error: function (e) { }
        }); 
    });
    function save() {

        if (!_$form.valid()) {
            return;
        }

        var van = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

        abp.ui.setBusy(_$form);
        _vanService.update(van).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited location!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //Handle save button click
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //Handle enter key
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);