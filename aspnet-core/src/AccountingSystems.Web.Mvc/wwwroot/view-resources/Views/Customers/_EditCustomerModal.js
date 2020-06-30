(function ($) {

    var _customerService = abp.services.app.customer;
    var _$modal = $('#CustomerEditModal');
    var _$form = $('form[name=CustomerEditForm]');

    $('#salemanCodeEdit').change(function (e) {

        var salesmanCode = $("#salemanCodeEdit").val();

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Salesman/GetSalesmanName?salesmanCode=' + salesmanCode,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (result) {
                console.log(result);
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

        var customers = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

        abp.ui.setBusy(_$form);
        _customerService.update(customers).done(function () {
            _$modal.modal('hide');
            location.reload(true); //reload page to see edited location!
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }
    $("#nextBtnEdit").click(function (e) {
        $("#nextTabEdit").addClass("active");
        $("#firstTabEdit").removeClass("active");
    });
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