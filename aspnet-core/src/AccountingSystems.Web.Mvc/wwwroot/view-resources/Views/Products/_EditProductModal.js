(function ($) {

    var _productService = abp.services.app.product;
    var _$modal = $('#ProductEditModal');
    var _$form = $('form[name=ProductEditForm]');


    $('#SuppCodeEdit').change(function (e) {

        var supplierCode = $("#SuppCodeEdit").val();

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Supplier/GetSupplierName?supplierCode=' + supplierCode,
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            dataType: 'json',
            success: function (result) {
                $('#SupplierNameEdit').val(result.name).focus();
                $('#SupplierIdEdit').val(result.id);
            },
            error: function (e) { }
        });
    });

    $("#nextBtnEdit").click(function () {
        $("#nextTabEdit").addClass("active");
        $("#firstTabEdit").removeClass("active");
    });

    function save() {

        if (!_$form.valid()) {
            return;
        }

        var product = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

        abp.ui.setBusy(_$form);
        _productService.update(product).done(function () {
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